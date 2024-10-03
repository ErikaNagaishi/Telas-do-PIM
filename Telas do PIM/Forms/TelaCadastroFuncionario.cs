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
    public partial class TelaCadastroFuncionario : Form
    {
        public TelaCadastroFuncionario()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
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
                Funcionario funcionario = new Funcionario()
                {
                    Nome = TxtNome.Text,
                    Cpf = TxtCPF.Text,
                    Telefone = TxtTelefone.Text,
                    Email = TxtEmail.Text,  
                    Senha = TxtSenha.Text,
                    Endereço = TxtEndereco.Text
                };
                var GenesisContext = new GenesisSolutionsContext();
                GenesisContext.Funcionarios.Add(funcionario);
                GenesisContext.SaveChanges();

                MessageBox.Show("Funcionário Cadastrado com sucesso!");
            }
        }
    }
}
