using Microsoft.Data.SqlClient;
using Telas_do_PIM.Forms;
using Telas_do_PIM.Models;

namespace Telas_do_PIM
{
    public partial class TelaDeLogin : Form
    {
        private readonly GenesisSolutionsContext genesisContext;
        public TelaDeLogin(GenesisSolutionsContext genesisSolutionsContext)
        {
            genesisContext = genesisSolutionsContext;
            InitializeComponent();

            TxtSenha.KeyDown += TelaDeLogin_KeyDown;
            TxtUsuario.KeyDown += TelaDeLogin_KeyDown;

            TxtUsuario.GotFocus += RemoverTxtUsuario;
            TxtSenha.GotFocus += RemoverTxtSenha;

            TxtUsuario.LostFocus += AddTxtUsuario;
            TxtSenha.LostFocus += AddTxtSenha;

            FormClosing += FormClosingAction;

            pictureBoxHidePassword.Hide();
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

        private void TelaDeLogin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                RealizaLogin();
            }
        }

        private void RemoverTxtUsuario(object sender, EventArgs e)
        {
            if (TxtUsuario.Text == "Usuário...")
                TxtUsuario.Text = "";
        }

        private void AddTxtUsuario(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(TxtUsuario.Text))
                TxtUsuario.Text = "Usuário...";
        }
        private void RemoverTxtSenha(object sender, EventArgs e)
        {
            if (TxtSenha.Text == "Senha...")
                TxtSenha.Text = "";
            TxtSenha.PasswordChar = '*';
        }

        private void AddTxtSenha(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(TxtSenha.Text))
            {
                TxtSenha.Text = "Senha...";
                TxtSenha.PasswordChar = '\0';
            }

        }
        private void TxtUser_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtSenha_TextChanged(object sender, EventArgs e)
        {

        }

        private void BtnEntrar_Click(object sender, EventArgs e)
        {
            RealizaLogin();
        }

        private void RealizaLogin()
        {
            String usuario = TxtUsuario.Text;
            String senha = TxtSenha.Text;
            int tentativas = 0;
            //Azure deixa o banco "dormindo" e com isso a primeira tentativa de login dá erro de timeout
            while (tentativas < 3)
            {
                try
                {
                    if (genesisContext.Funcionarios.Any(e => e.Email == usuario && e.Senha == senha))
                    {
                        MessageBox.Show("Acesso Liberado!");
                        this.Hide();
                        TelaDeSelecao fmTelaDeSelecao = new();
                        fmTelaDeSelecao.StartPosition = FormStartPosition.CenterScreen;
                        fmTelaDeSelecao.ShowDialog();

                    }
                    else
                    {
                        MessageBox.Show("Acesso Negado!");
                    }
                    break;
                }
                catch (SqlException e)
                {
                    tentativas++;
                }
            }
        }

        private void pictureBoxHidePassword_Click(object sender, EventArgs e)
        {
            pictureBoxHidePassword.Hide();
            pictureBoxShowPassword.Show();

            if (TxtSenha.Text != "Senha...")
                TxtSenha.PasswordChar = '*';
        }

        private void pictureBoxShowPassword_Click(object sender, EventArgs e)
        {
            pictureBoxHidePassword.Show();
            pictureBoxShowPassword.Hide();
            TxtSenha.PasswordChar = '\0';

        }
    }
}
