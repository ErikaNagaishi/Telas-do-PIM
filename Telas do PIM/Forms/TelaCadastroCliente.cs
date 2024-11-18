using Microsoft.Extensions.DependencyInjection;
using System.Text.RegularExpressions;
using Telas_do_PIM.Models;
using ViaCep;

namespace Telas_do_PIM.Forms
{
    public partial class TelaCadastroCliente : Form
    {
        private readonly GenesisSolutionsContext genesisContext;

        public bool cadastroCliente = false;

        public bool telaAnteriorSelecao = true;
        public TelaCadastroCliente(GenesisSolutionsContext genesisSolutionsContext)
        {
            genesisContext = genesisSolutionsContext;
            InitializeComponent();
            FormClosing += FormClosingAction;

            TxtSenha.KeyDown += TelaDeCadastroCliente_KeyDown;
            TxtConfSenha.KeyDown += TelaDeCadastroCliente_KeyDown;

            TxtCEP.Leave += textCEP_Leave;

            TxtEndereco.Enabled = false;

            pictureBoxHidePassword.Hide();
            pictureBoxHideConfPassword.Hide();

            if(Program.funcionarioLogado == null)
            {
                tsUsuario.Visible = false;
                tsUsuario.Enabled = false;
            }
        }

        private void textCEP_Leave(object? sender, EventArgs e)
        {
            LocalizarCEP();
        }

        private async void LocalizarCEP()
        {
            var cep = TxtCEP.Text.Replace("-", "");
            if (!string.IsNullOrWhiteSpace(cep) &&
                ValidarCEP(cep))
            {

                var cepResultado = new ViaCepClient().Search(cep);
                if (cepResultado is not null)
                {
                    TxtEndereco.Text = cepResultado.Street;
                }
                else
                {
                    MessageBox.Show("CEP inválido");
                }
            }
            else
            {
                MessageBox.Show("CEP inválido");
            }
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
                    EnderecoCliente = TxtCEP.Text,
                    Numero = TxtNumeracao.Text,
                    Cep = TxtCEP.Text,
                };
                genesisContext.Clientes.Add(cliente);
                genesisContext.SaveChanges();

                MessageBox.Show("Cliente Cadastrado com sucesso!");

                if (!cadastroCliente)
                {
                    //Chamar novamente o mesmo form para resetar os campos de textbox
                    using (var fmTelaCadastroCliente = Program.ServiceProvider.GetRequiredService<TelaCadastroCliente>())
                    {
                        this.Visible = false;
                        this.Hide();
                        fmTelaCadastroCliente.StartPosition = FormStartPosition.CenterScreen;
                        fmTelaCadastroCliente.ShowDialog();
                    }
                }
                else
                {
                    using (var fmTelaLogin = Program.ServiceProvider.GetRequiredService<TelaDeLogin>())
                    {
                        this.Visible = false;
                        this.Hide();
                        fmTelaLogin.StartPosition = FormStartPosition.CenterScreen;
                        fmTelaLogin.ShowDialog();
                    }
                }
            }
        }

        private bool ValidaCadastro()
        {
            if (!ValidarCNPJ(TxtCNPJ.Text))
            {
                MessageBox.Show("CPF não é válido");
                return false;
            }
            if (!TxtSenha.Text.Equals(TxtConfSenha.Text))
            {
                MessageBox.Show("Senha não confere");
                return false;
            }
            if (!ValidaEmail(TxtEmail.Text))
            {
                MessageBox.Show("E-mail não é válido");
                return false;
            }
            if (string.IsNullOrEmpty(TxtCEP.Text))
            {
                MessageBox.Show("Endereço não pode ser em branco");
                return false;
            }
            if (string.IsNullOrEmpty(TxtCEP.Text))
            {
                MessageBox.Show("CEP não pode ser em branco");
                return false;
            }
            if (string.IsNullOrEmpty(TxtNome.Text))
            {
                MessageBox.Show("Nome não pode ser em branco");
                return false;
            }

            if (genesisContext.Clientes.Any(f => f.CnpjCliente.Equals(TxtCNPJ)))
            {
                MessageBox.Show("CNPJ já está cadastrado");
                return false;
            }

            if (genesisContext.Clientes.Any(f => f.Email.Equals(TxtEmail)))
            {
                MessageBox.Show("Email já está cadastrado");
                return false;
            }

            return true;
        }

        private bool ValidarCEP(string cep)
        {
            cep.Replace('-', '\0');

            // Verifica se o CEP possui exatamente 8 dígitos
            if (cep.Length != 8)
                return false;

            // Verifica se todos os caracteres são dígitos
            foreach (char c in cep)
            {
                if (!char.IsDigit(c))
                    return false;
            }

            return true;
        }
        public static bool ValidarCNPJ(string cnpj)
        {
            // Remove caracteres não numéricos
            cnpj = cnpj.Replace(".", "").Replace("-", "").Replace("/", "");

            if (cnpj.Length != 14)
                return false;

            // Primeira parte dos cálculos
            int[] multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int soma = 0;
            for (int i = 0; i < 12; i++)
                soma += int.Parse(cnpj[i].ToString()) * multiplicador1[i];
            int resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            string digito = resto.ToString();
            // Concatena o primeiro dígito verificador ao CNPJ original
            cnpj += digito;

            // Segunda parte dos cálculos
            int[] multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            soma = 0;
            for (int i = 0; i < 13; i++)
                soma += int.Parse(cnpj[i].ToString()) * multiplicador2[i];
            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito += resto.ToString();

            // Verifica se os dígitos calculados conferem com os dígitos informados
            return cnpj.EndsWith(digito);
        }

        private bool ValidaEmail(string email)
        {
            //Expressão regular para validar um e-mail
            Regex regex = new Regex(@"^([\w\-\+.]+@[a-z0-9\-]+\.[a-z]{2,6})?$", RegexOptions.IgnoreCase);

            if (string.IsNullOrEmpty(email))
            {
                return false;
            }

            if (!regex.IsMatch(email))
            {
                return false;
            }
            return true;
        }

        private void BtnVoltar_Click(object sender, EventArgs e)
        {
            if (telaAnteriorSelecao)
            {
                using (var fmTelaDeSelecao = Program.ServiceProvider.GetRequiredService<TelaDeSelecao>())
                {
                    this.Hide();
                    fmTelaDeSelecao.StartPosition = FormStartPosition.CenterScreen;
                    fmTelaDeSelecao.ShowDialog();
                }
            }
            else
            {
                using (var fmTelaDeManutencaoClientes = Program.ServiceProvider.GetRequiredService<TelaManutencaoClientes>())
                {
                    this.Hide();
                    fmTelaDeManutencaoClientes.StartPosition = FormStartPosition.CenterScreen;
                    fmTelaDeManutencaoClientes.ShowDialog();
                }
            }
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

        private void logoffToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Program.funcionarioLogado = null;

            using (var fmTelaDeLogin = Program.ServiceProvider.GetRequiredService<TelaDeLogin>())
            {
                this.Hide();
                fmTelaDeLogin.StartPosition = FormStartPosition.CenterScreen;
                fmTelaDeLogin.ShowDialog();
            }
        }
    }
}
