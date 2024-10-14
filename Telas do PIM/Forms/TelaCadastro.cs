using Microsoft.Extensions.DependencyInjection;
using System.Windows.Forms.VisualStyles;
using Telas_do_PIM.Models;

namespace Telas_do_PIM.Forms
{
    public partial class TelaCadastro : Form
    {
        private bool eAdm;
        private readonly TelaDeSelecao _telaDeSelecao;

        public bool EAdm

        {
            set
            {
                eAdm = value;
                LblCadastro.Text = (eAdm) ? "Cadastre um ADM" : "Cadastre um funcinário";
            }
            get
            {
                return eAdm;
            }
        }

        private readonly GenesisSolutionsContext genesisContext;
        public TelaCadastro(GenesisSolutionsContext genesisSolutionsContext, TelaDeSelecao telaDeSelecao)
        {
            _telaDeSelecao = telaDeSelecao;
            genesisContext = genesisSolutionsContext;
            InitializeComponent();
            FormClosing += FormClosingAction;

            TxtSenha.KeyDown += TelaDeCadastro_KeyDown;
            TxtConfSenha.KeyDown += TelaDeCadastro_KeyDown;

            pictureBoxHideConfPassword.Hide();
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
            if (!TxtSenha.Text.Equals(TxtConfSenha.Text))
            {
                MessageBox.Show("Senha não confere");
            }

            else
            {
                if (EAdm)
                {
                    Adm Adm = new()
                    {
                        Nome = TxtNome.Text,
                        Cpf = TxtCPF.Text,
                        Telefone = TxtTelefone.Text,
                        Email = TxtEmail.Text,
                        Senha = TxtSenha.Text,
                        Endereço = TxtEndereco.Text
                    };
                    genesisContext.Adms.Add(Adm);
                    genesisContext.SaveChanges();

                    MessageBox.Show("Administrador Cadastrado com sucesso!");
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
                    genesisContext.Funcionarios.Add(funcionario);
                    genesisContext.SaveChanges();

                    MessageBox.Show("Funcionário Cadastrado com sucesso!");
                }
                using (var fmTelaCadastro = Program.ServiceProvider.GetRequiredService<TelaCadastro>())
                {
                    this.Hide();
                    fmTelaCadastro.StartPosition = FormStartPosition.CenterScreen;
                    fmTelaCadastro.EAdm = this.EAdm;
                    fmTelaCadastro.ShowDialog();
                }
            }
        }

        private void LblCadastro_Click(object sender, EventArgs e)
        {

        }

        private void TxtConfSenha_TextChanged(object sender, EventArgs e)
        {

        }

        private void TelaCadastro_Load(object sender, EventArgs e)
        {

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
