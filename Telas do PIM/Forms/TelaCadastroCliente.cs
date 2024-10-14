using Microsoft.Extensions.DependencyInjection;
using System.Windows.Forms.VisualStyles;
using Telas_do_PIM.Models;

namespace Telas_do_PIM.Forms
{
    public partial class TelaCadastroCliente : Form
    {
        private readonly GenesisSolutionsContext genesisContext;
        private readonly TelaDeSelecao _telaDeSelecao;
        public TelaCadastroCliente(GenesisSolutionsContext genesisSolutionsContext, TelaDeSelecao telaDeSelecao)
        {
            _telaDeSelecao = telaDeSelecao;
            genesisContext = genesisSolutionsContext;
            InitializeComponent();
            FormClosing += FormClosingAction;

            TxtSenha.KeyDown += TelaDeCadastroCliente_KeyDown;
            TxtConfSenha.KeyDown += TelaDeCadastroCliente_KeyDown;

            pictureBoxHidePassword.Hide();
            pictureBoxHideConfPassword.Hide();
        }

        private void FormClosingAction(object? sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                switch (MessageBox.Show(this, "Tem certeza que deseja encerrar?", "Confirme", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    //Stay on this form
                    case DialogResult.No:
                        e.Cancel = true;
                        break;
                    default:
                        try
                        {
                            Application.Exit();
                            //Environment.Exit(0);
                        }
                        catch
                        {
                            Application.Exit();
                        }
                        break;
                }
            }
        }
        private void TelaDeCadastroCliente_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                RealizaCadastro();
            }
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
            RealizaCadastro();
        }

        private void RealizaCadastro()
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
                    CnpjCliente = TxtCNPJ.Text,
                    Email = TxtEmail.Text,
                    SenhaCliente = TxtSenha.Text,
                    EnderecoCliente = TxtEndereco.Text,
                    Numero = TxtNumeracao.Text,
                    Cep = TxtCEP.Text,
                };
                genesisContext.Clientes.Add(cliente);
                genesisContext.SaveChanges();

                MessageBox.Show("Cliente Cadastrado com sucesso!");

                //Chamar novamente o mesmo form para resetar os campos de textbox
                using (var fmTelaCadastroCliente = Program.ServiceProvider.GetRequiredService<TelaCadastroCliente>())
                {
                    this.Visible = false;
                    this.Hide();
                    fmTelaCadastroCliente.StartPosition = FormStartPosition.CenterScreen;
                    fmTelaCadastroCliente.ShowDialog();
                }
            }
        }

        private void BtnVoltar_Click(object sender, EventArgs e)
        {
            this.Hide();
            _telaDeSelecao.StartPosition = FormStartPosition.CenterScreen;
            _telaDeSelecao.ShowDialog();
        }

        private void pictureBoxHidePassword_Click(object sender, EventArgs e)
        {
            pictureBoxHidePassword.Hide();
            pictureBoxShowPassword.Show();

            TxtSenha.PasswordChar = '*';
        }

        private void pictureBoxShowConfPassword_Click(object sender, EventArgs e)
        {
            pictureBoxHideConfPassword.Show();
            pictureBoxShowConfPassword.Hide();
            TxtConfSenha.PasswordChar = '\0';
        }

        private void pictureBoxHideConfPassword_Click(object sender, EventArgs e)
        {
            pictureBoxHideConfPassword.Hide();
            pictureBoxShowConfPassword.Show();

            TxtConfSenha.PasswordChar = '*';
        }

        private void pictureBoxShowPassword_Click(object sender, EventArgs e)
        {
            pictureBoxHidePassword.Show();
            pictureBoxShowPassword.Hide();
            TxtSenha.PasswordChar = '\0';
        }
    }
}
