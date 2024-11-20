using Pim_Frontend.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace Pim_Frontend.Controllers
{
    public class HomeController : Controller 
    {
        // GET: Home
        private pimEntitiesConnection db = new pimEntitiesConnection(); //vinculo entre model e controller - ################renomear pra pimDBEntities##########

        // TELA DE LOGIN
        public ActionResult Index()
        {
            return View();
        }


        // FAZ LOGIN
        [HttpPost]
        public ActionResult Index(string email, string senha, Cliente cliente)
        {
            if (!string.IsNullOrEmpty(email) || (!string.IsNullOrEmpty(senha))) //  verifica se as caixas de texto estão preenchidas
            {
                senha = Criptografia.Encrypt(cliente.Senha);
                var validar = db.Cliente.Where
                    (u => u.Email.Equals(cliente.Email)
                  &&
                  u.Senha.Equals(senha)).FirstOrDefault();
                // o código acima verifica se o email e senha digitados estão cadastrados no banco

                if (validar != null)
                {
                    Session["ClienteID"] = validar.Id;
                    return RedirectToAction("mainPage");

                }
                else
                {
                    TempData["Status"] = "erro";
                }
            }

            return View();
        }


        // TELA DE CADASTRO
        public ActionResult cadLogin()
        {
            return View();
        }


        // FAZ CADASTRO
        [HttpPost]
        public ActionResult cadLogin(string Nome, string Cnpj, string Cep, string Email, string Senha, Cliente cliente) // responsavel pela gravação
        {
            if (ModelState.IsValid)
            {
                try 
                { 
                    cliente.Senha = Criptografia.Encrypt(cliente.Senha);
                    db.Cliente.Add(cliente); // armazena cada item do formulario nos respectivos atributos da 
                    db.SaveChanges(); // salva na tabela login
                    TempData["Status"] = "sucesso";
                    return RedirectToAction("Index"); // redireciona para pagina index
                }catch (DbEntityValidationException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return View();
        }

        // CATALOGO DE PRODUTOS
        public ActionResult mainPage()
        {
            if (Session["ClienteID"] == null)
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        // FAZ LOGOUT
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index", "Home");
        }


        // CARREGA PAGINA DO PERFIL
        public ActionResult profilePage()
        {
            if (Session["ClienteID"] == null)
            {
                return RedirectToAction("Index", "Home");
            }

            int clienteId = (int)Session["ClienteID"];
            var cliente = db.Cliente.Find(clienteId);

            if (cliente == null)
            {
                return HttpNotFound();
            }

            return View(cliente);
        }

        // ATUALIZA DADOS DO PERFIL
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult profilePage(Cliente cliente)
        {

            if (Session["ClienteID"] == null)
            {
                return RedirectToAction("Index", "Home");
            }

            int clienteId = (int)Session["ClienteID"];

            if (ModelState.IsValid)
            {
                var clienteExistente = db.Cliente.Find(clienteId);
                if (clienteExistente == null)
                {
                    return HttpNotFound();
                }

                clienteExistente.Nome = cliente.Nome;
                clienteExistente.CNPJ = cliente.CNPJ;
                clienteExistente.CEP = cliente.CEP;
                clienteExistente.Email = cliente.Email;
                //clienteExistente.Senha = Criptografia.Encrypt(cliente.Senha);

                // Salva as alterações no banco de dados
                db.SaveChanges();

                TempData["Mensagem"] = "Sucesso! Perfil atualizado!";
                return RedirectToAction("mainPage"); // Redireciona para outra página após atualizar
            }

            return View(cliente); // Retorna a View com o modelo em caso de erro de validação
        }

        // PAGINA DE COMPRA
        public ActionResult checkoutPage(string produto)
        {
            if (Session["ClienteID"] == null)
            {
                return RedirectToAction("Index", "Home");
            }

            ViewBag.Produto = produto;
            TempData["Produto"] = produto;
            return View();
        }

        // ENVIA ENCOMENDA

        [HttpPost]
        public ActionResult checkoutPage(string quantidade, Encomenda encomenda)
        {

            if (ModelState.IsValid)
            {
                db.Encomenda.Add(encomenda);
                db.SaveChanges(); // salva na tabela encomendas
                TempData["Mensagem"] = "Sucesso! Pedido realizado!";


                return RedirectToAction("mainPage");
            }
            return View();
        }
    }
}