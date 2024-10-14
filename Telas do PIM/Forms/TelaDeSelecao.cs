using Microsoft.Extensions.DependencyInjection;

namespace Telas_do_PIM.Forms
{
    public partial class TelaDeSelecao : Form
    {
        public TelaDeSelecao()
        {
            InitializeComponent();
            FormClosing += FormClosingAction;
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

        private void Rbtnfunc_Click(object sender, EventArgs e)
        {
            using (var fmTelaCadastroFuncionario = Program.ServiceProvider.GetRequiredService<TelaCadastro>())
            {
                this.Hide();
                fmTelaCadastroFuncionario.StartPosition = FormStartPosition.CenterScreen;
                fmTelaCadastroFuncionario.ShowDialog();
                fmTelaCadastroFuncionario.EAdm = false;
            }
        }

        private void Rbtnadm_Click(object sender, EventArgs e)
        {
            using (var fmTelaCadastroFuncionario = Program.ServiceProvider.GetRequiredService<TelaCadastro>())
            {
                this.Hide();
                fmTelaCadastroFuncionario.EAdm = true;
                fmTelaCadastroFuncionario.StartPosition = FormStartPosition.CenterScreen;
                fmTelaCadastroFuncionario.ShowDialog();
            }
        }

        private void Rbtncliente_Click(object sender, EventArgs e)
        {
            using (var fmTelaCadastroCliente = Program.ServiceProvider.GetRequiredService<TelaCadastroCliente>())
            {
                this.Visible = false;
                this.Hide();
                fmTelaCadastroCliente.StartPosition = FormStartPosition.CenterScreen;
                fmTelaCadastroCliente.ShowDialog();
            }
        }
        private void Rbtndashboard_MouseHover(object sender, EventArgs e)
        {
            Rbtndashboard.Checked = true;
        }
        private void Rbtnfunc_MouseHover(object sender, EventArgs e)
        {
            Rbtnfunc.Checked = true;
        }
        private void Rbtnadm_MouseHover(object sender, EventArgs e)
        {
            Rbtnadm.Checked = true;
        }
        private void Rbtncliente_MouseHover(object sender, EventArgs e)
        {
            Rbtncliente.Checked = true;
        }
    }
}
