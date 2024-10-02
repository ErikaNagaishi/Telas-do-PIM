using Telas_do_PIM.Models;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Telas_do_PIM
{
    public partial class TelaDeLogin : Form
    {
        public TelaDeLogin()
        {
            InitializeComponent();
            TxtUsuario.GotFocus += RemoverTxtUsuario;
            TxtSenha.GotFocus += RemoverTxtSenha;

            TxtUsuario.LostFocus += AddTxtUsuario;
            TxtSenha.LostFocus += AddTxtSenha;

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
                TxtSenha.Text = "Senha...";

        }
        private void TxtUser_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtSenha_TextChanged(object sender, EventArgs e)
        {

        }

        private void BtnEntrar_Click(object sender, EventArgs e)
        {
            var GenesisContext = new GenesisSolutionsContext( new Microsoft.EntityFrameworkCore.DbContextOptions<GenesisSolutionsContext>());
            String usuario = TxtUsuario.Text;
            String senha = TxtSenha.Text;
            if (GenesisContext.Funcionarios.Any(e=>e.Email == usuario && e.Senha == senha))
            {
                MessageBox.Show("Acesso Liberado!");
                Visible = false;
                Menu fmMenu = new Menu();
                fmMenu.Show();
                //Application.Exit();
            }
            else
            {
                MessageBox.Show("Acesso Negado!");


            }
        }
    }
}
