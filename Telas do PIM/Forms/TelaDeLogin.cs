using Microsoft.Data.SqlClient;
using Microsoft.Extensions.DependencyInjection;
using Telas_do_PIM.Models;

namespace Telas_do_PIM.Forms
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
            while (tentativas < 2)
            {
                try
                {
                    if (genesisContext.Funcionarios.Any(e => e.Email == usuario && e.Senha == senha))
                    {
                        //MessageBox.Show("Acesso Liberado!");
                        Program.funcionarioLogado = genesisContext.Funcionarios.First(e => e.Email == usuario && e.Senha == senha);
                        this.Hide();

                        using (var fmTelaDeSelecao = Program.ServiceProvider.GetRequiredService<TelaDeSelecao>())
                        {
                            this.Hide();
                            fmTelaDeSelecao.StartPosition = FormStartPosition.CenterScreen;
                            fmTelaDeSelecao.ShowDialog();
                        }

                    }
                    if (genesisContext.Clientes.Any(e => e.Email == usuario && e.SenhaCliente == senha))
                    {
                        Program.clienteLogado = genesisContext.Clientes.First(e => e.Email == usuario && e.SenhaCliente == senha);
                        this.Hide();
                        using (var fmTelaPrincipalCliente = Program.ServiceProvider.GetRequiredService<TelaPrincipal>())
                        {
                            this.Hide();
                            fmTelaPrincipalCliente.StartPosition = FormStartPosition.CenterScreen;
                            fmTelaPrincipalCliente.ShowDialog();
                        }
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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void linkEsqueceuSenha_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            using (var fmTelaEsqueceuSenha = Program.ServiceProvider.GetRequiredService<TelaEsqueceuSenha>())
            {
                this.Hide();
                fmTelaEsqueceuSenha.StartPosition = FormStartPosition.CenterScreen;
                fmTelaEsqueceuSenha.ShowDialog();
            }
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            using (var fmTelaCadastroCliente = Program.ServiceProvider.GetRequiredService<TelaCadastroCliente>())
            {
                this.Hide();
                fmTelaCadastroCliente.StartPosition = FormStartPosition.CenterScreen;
                fmTelaCadastroCliente.cadastroCliente = true;
                fmTelaCadastroCliente.ShowDialog();
            }
        }
    }
}
