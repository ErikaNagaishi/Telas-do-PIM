using System.Net.Mail;
using System.Net;
using Microsoft.Extensions.Configuration;
using Telas_do_PIM.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Telas_do_PIM.Forms
{
    public partial class TelaEsqueceuSenha : Form
    {
        private IConfiguration configuration;
        private GenesisSolutionsContext genesisSolutionsContext;

        private Funcionario? funcionario = null;
        private Cliente? cliente = null;

        private string codigo = string.Empty;

        public TelaEsqueceuSenha(IConfiguration configuration, GenesisSolutionsContext genesisContext)
        {
            this.configuration = configuration;
            this.genesisSolutionsContext = genesisContext;
            FormClosing += FormClosingAction;
            InitializeComponent();
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

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            string nome = string.Empty;

            for (int i = 0; i < 6; i++)
            {
                codigo += new Random().Next(1, 9).ToString();
            }

            cliente = genesisSolutionsContext.Clientes.AsNoTracking().FirstOrDefault(x => x.Email.Equals(textBoxEmail.Text));
            funcionario = genesisSolutionsContext.Funcionarios.AsNoTracking().FirstOrDefault(x => x.Email.Equals(textBoxEmail.Text));

            if (cliente != null)
            {
                nome = cliente.RazaoSocial;
            }
            if (funcionario != null)
            {
                nome = funcionario.Nome;
            }

            if (cliente == null && funcionario == null)
            {
                MessageBox.Show("Email não encontrado");
                return;
            }

            EnviarEmailVerificacao(codigo, textBoxEmail.Text, nome).Wait();

            painelInformarCodigo.BringToFront();
        }

        private void TelaEsqueceuSenha_Load(object sender, EventArgs e)
        {
            painelConfirmacao.BringToFront();
        }

        private async Task EnviarEmailVerificacao(string codigo, string toEmail, string nome)
        {
            try
            {
                MailMessage mailMessage = new MailMessage();
                mailMessage.IsBodyHtml = true;
                mailMessage.From = new MailAddress(configuration.GetSection("EmailConfiguration:EMAIL").Value, "Genesis Solutions");
                mailMessage.To.Add(toEmail);
                mailMessage.Subject = "Recuperação de senha Genesis Solutions";
                //mailMessage.Body = subject == null ? $"Informação: {informacao}<br>Detalhe: {message}<br>StackTrace: {stackTrace}<br>Para mais detalhes acesse a tabela log_erros_backend" : $"Informação: {informacao}";

                StreamReader sr = new StreamReader("./Resources/TemplateEnviaEmailRecuperacao.html");

                string htmlBody = sr.ReadToEnd();
                htmlBody = htmlBody.Replace("{nomeUsuario}", nome);
                htmlBody = htmlBody.Replace("{codigoRecuperacao}", codigo);

                mailMessage.Body = htmlBody;
                mailMessage.IsBodyHtml = true;

                SmtpClient smtpClient = new SmtpClient();
                smtpClient.Host = configuration.GetSection("EmailConfiguration:HOST").Value;
                smtpClient.Port = int.Parse(configuration.GetSection("EmailConfiguration:port").Value);
                smtpClient.UseDefaultCredentials = bool.Parse(configuration.GetSection("EmailConfiguration:DEFAULT_CREDENTIALS").Value);
                smtpClient.Credentials = new NetworkCredential(configuration.GetSection("EmailConfiguration:EMAIL").Value,
                                                                configuration.GetSection("EmailConfiguration:PASSWORD").Value);
                smtpClient.EnableSsl = bool.Parse(configuration.GetSection("EmailConfiguration:ENABLE_SSL").Value);

                smtpClient.SendAsync(mailMessage, null);
            }
            catch (Exception exception)
            {
                MessageBox.Show("Não foi possível enviar o email:\n" + exception.Message);
            }
        }

        private void btnConfirmarCodigo_Click(object sender, EventArgs e)
        {
            if (textBoxInformeCodigo.Text.Equals(this.codigo))
            {
                painelConfirmarSenha.BringToFront();
                textBoxInformeCodigo.Text = string.Empty;
            }
            else
            {
                MessageBox.Show("Código incorreto");
            }
        }

        private void btnConfirmarSenha_Click(object sender, EventArgs e)
        {
            if (textBoxSenha.Text.Length <= 5)
            {
                MessageBox.Show("Senha muito curta. Informe uma senha com 6 dígitos ou mais");
                return;
            }
            if (textBoxSenha.Text == textBoxConfirmeSenha.Text)
            {
                if (cliente is not null)
                {
                    cliente.SenhaCliente = textBoxConfirmeSenha.Text;
                    genesisSolutionsContext.Clientes.Update(cliente);
                }
                else if (funcionario is not null)
                {
                    funcionario.Senha = textBoxConfirmeSenha.Text;

                    genesisSolutionsContext.Funcionarios.Update(funcionario);
                }

                genesisSolutionsContext.SaveChanges();
                MessageBox.Show("Senha atualizada com sucesso");

                using (var fmTelaLogin = Program.ServiceProvider.GetRequiredService<TelaDeLogin>())
                {
                    this.Hide();
                    fmTelaLogin.StartPosition = FormStartPosition.CenterScreen;
                    fmTelaLogin.ShowDialog();
                }
                return;
            }
            else
            {
                MessageBox.Show("As senhas são diferentes");
            }
        }
        private void pictureBoxHidePassword_Click(object sender, EventArgs e)
        {
            pictureBoxHidePassword.Hide();
            pictureBoxShowPassword.Show();

            textBoxSenha.PasswordChar = '*';
        }

        private void pictureBoxShowConfPassword_Click(object sender, EventArgs e)
        {
            pictureBoxHideConfPassword.Show();
            pictureBoxShowConfPassword.Hide();
            textBoxConfirmeSenha.PasswordChar = '\0';
        }

        private void pictureBoxHideConfPassword_Click(object sender, EventArgs e)
        {
            pictureBoxHideConfPassword.Hide();
            pictureBoxShowConfPassword.Show();

            textBoxConfirmeSenha.PasswordChar = '*';
        }

        private void pictureBoxShowPassword_Click(object sender, EventArgs e)
        {
            pictureBoxHidePassword.Show();
            pictureBoxShowPassword.Hide();
            textBoxSenha.PasswordChar = '\0';
        }

        private void btnVoltarInforme_Click(object sender, EventArgs e)
        {
            using (var fmTelaLogin = Program.ServiceProvider.GetRequiredService<TelaDeLogin>())
            {
                this.Hide();
                fmTelaLogin.StartPosition = FormStartPosition.CenterScreen;
                fmTelaLogin.ShowDialog();
            }
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            using (var fmTelaLogin = Program.ServiceProvider.GetRequiredService<TelaDeLogin>())
            {
                this.Hide();
                fmTelaLogin.StartPosition = FormStartPosition.CenterScreen;
                fmTelaLogin.ShowDialog();
            }
        }

        private void btnVoltarEmail_Click(object sender, EventArgs e)
        {
            using (var fmTelaLogin = Program.ServiceProvider.GetRequiredService<TelaDeLogin>())
            {
                this.Hide();
                fmTelaLogin.StartPosition = FormStartPosition.CenterScreen;
                fmTelaLogin.ShowDialog();
            }
        }
    }
}
