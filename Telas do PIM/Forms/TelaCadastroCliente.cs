using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telas_do_PIM.Models;

namespace Telas_do_PIM.Forms
{
    public partial class TelaCadastroCliente : Form
    {
        public TelaCadastroCliente()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void TxtSenha_TextChanged(object sender, EventArgs e)
        {

        }

        private void BtnCadastrar_Click(object sender, EventArgs e)
        {
            if (!TxtSenha.Text.Equals(TxtConfSenha.Text))
            {
                MessageBox.Show("Senha não confere");
            }
            else
            {

                Cliente cliente = new()
                {
                    RazaoSocial = TxtNome.Text,
                    CnpjCliente = (TxtCNPJ.Text),
                    Email = TxtEmail.Text,
                    SenhaCliente = TxtSenha.Text,
                    EnderecoCliente = TxtEndereco.Text,
                    Numero = TxtNumeracao.Text,
                    Cep = TxtCEP.Text,
                };
                var GenesisContext = new GenesisSolutionsContext();
                GenesisContext.Clientes.Add(cliente);
                GenesisContext.SaveChanges();

                MessageBox.Show("Cliente Cadastrado com sucesso!");
            }

        }
    }
}
