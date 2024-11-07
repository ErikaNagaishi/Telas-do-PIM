using Microsoft.Extensions.DependencyInjection;
using System.Text.RegularExpressions;
using Telas_do_PIM.Models;

namespace Telas_do_PIM.Forms
{
    public partial class TelaCadastroFuncionario : Form
    {
        private readonly TelaDeSelecao _telaDeSelecao;

        private readonly GenesisSolutionsContext genesisContext;
        public TelaCadastroFuncionario(GenesisSolutionsContext genesisSolutionsContext, TelaDeSelecao telaDeSelecao)
        {
            _telaDeSelecao = telaDeSelecao;
            genesisContext = genesisSolutionsContext;
            InitializeComponent();
            FormClosing += FormClosingAction;

            TxtSenha.KeyDown += TelaDeCadastro_KeyDown;
            TxtConfSenha.KeyDown += TelaDeCadastro_KeyDown;

            pictureBoxHideConfPassword.Hide();
            pictureBoxHidePassword.Hide();

            var perfis = genesisContext.Perfils.Select(e => e.Id + " - " + e.Perfil1).ToArray();

            cmbBoxPerfil.Items.AddRange(perfis);
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
                        }
                        catch
                        {
                            Application.Exit();
                        }
                        break;
                }
            }
        }
        private void TelaDeCadastro_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                RealizaCadastro();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void BtnCadastrar_Click(object sender, EventArgs e)
        {
            RealizaCadastro();
        }

        private void RealizaCadastro()
        {
            if (ValidaCadastro())
            {
                var idPerfil = int.Parse(cmbBoxPerfil.Items[cmbBoxPerfil.SelectedIndex].ToString().Split('-')[0]);
                Funcionario funcionario = new Funcionario()
                {
                    Nome = TxtNome.Text,
                    Cpf = TxtCPF.Text,
                    Telefone = TxtTelefone.Text,
                    Email = TxtEmail.Text,
                    Senha = TxtSenha.Text,
                    Endereço = TxtEndereco.Text,
                    IdPerfil = idPerfil

                };
                genesisContext.Funcionarios.Add(funcionario);
                genesisContext.SaveChanges();

                MessageBox.Show("Funcionário Cadastrado com sucesso!");
                using (var fmTelaCadastro = Program.ServiceProvider.GetRequiredService<TelaCadastroFuncionario>())
                {
                    this.Hide();
                    fmTelaCadastro.StartPosition = FormStartPosition.CenterScreen;
                    fmTelaCadastro.ShowDialog();
                }
            }
        }

        private bool ValidaCadastro()
        {
            if (!ValidarCPF(TxtCPF.Text))
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
            if (string.IsNullOrEmpty(TxtEndereco.Text))
            {
                MessageBox.Show("Endereço não pode ser em branco");
                return false;
            }
            if (string.IsNullOrEmpty(TxtTelefone.Text))
            {
                MessageBox.Show("Telefone não pode ser em branco");
                return false;
            }
            if (string.IsNullOrEmpty(TxtNome.Text))
            {
                MessageBox.Show("Nome não pode ser em branco");
                return false;
            }

            if(genesisContext.Funcionarios.Any(f => f.Cpf.Equals(TxtCPF.Text)))
            {
                MessageBox.Show("CPF já está cadastrado");
                return false;
            }

            if (genesisContext.Funcionarios.Any(f => f.Email.Equals(TxtEmail.Text)))
            {
                MessageBox.Show("Email já está cadastrado");
                return false;
            }
            if(cmbBoxPerfil.SelectedIndex == -1)
            {
                MessageBox.Show("Informe um perfil");
                return false;
            }

            return true;
        }

        public static bool ValidarCPF(string cpf)
        {
            // Remove caracteres não numéricos
            cpf = new string(cpf.Where(char.IsDigit).ToArray());

            // Verifica se o CPF possui 11 dígitos
            if (cpf.Length != 11)
                return false;

            // Verifica se todos os dígitos são iguais
            if (cpf.Distinct().Count() == 1)
                return false;

            // Calcula o primeiro dígito verificador
            int soma = 0;
            for (int i = 0; i < 9; i++)
                soma += int.Parse(cpf[i].ToString()) * (10 - i);
            int resto = soma % 11;

            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            if (resto != int.Parse(cpf[9].ToString()))
                return false;


            // Calcula o segundo dígito verificador
            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(cpf[i].ToString()) * (11 - i);
            resto = soma % 11;

            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            if (resto != int.Parse(cpf[10].ToString()))
                return false;


            // Se passou por todas as verificações, o CPF é válido
            return true;
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

        private void btnVoltar_Click(object sender, EventArgs e)
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
