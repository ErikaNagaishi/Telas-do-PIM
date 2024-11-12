using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Telas_do_PIM.Models;

namespace Telas_do_PIM.Forms
{
    public partial class TelaDeSelecao : Form
    {
        private readonly GenesisSolutionsContext genesisContext;
        public TelaDeSelecao(GenesisSolutionsContext genesisSolutionsContext)
        {
            genesisContext = genesisSolutionsContext;
            InitializeComponent();
            FormClosing += FormClosingAction;
            VerificaAcessosFuncionario();
        }

        private void VerificaAcessosFuncionario()
        {
            var perfilUsuario = Program.funcionarioLogado.IdPerfil;

            //Buscar os nomes dos radioButton que redirecionam para cada form
            var telasComAcesso = genesisContext.PerfilTelas.Where(e=> e.IdPerfil == perfilUsuario).Select(e=> e.IdTelaNavigation.IdentificacaoTela).ToList();

            //Reflection. Buscar todos os radioButtons desse form
            var radioButtons = this.GetType().GetFields(BindingFlags.Instance | BindingFlags.NonPublic).Where(e=> e.Name.Contains("rbtn")).ToList();

            radioButtons.ForEach(rbtn =>
            {
                if(telasComAcesso.Any(e=> e.Equals(rbtn.Name)))
                {
                    var radioButton = (RadioButton?)rbtn.GetValue(this);
                    if (radioButton != null)
                    {
                        //Se o nome do radioButton for encontrado na consulta do banco então o acesso é liberado
                        radioButton.Enabled = true;
                    }
                }
            });
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

        private void rbtnCadastroFuncionario_Click(object sender, EventArgs e)
        {
            using (var fmTelaCadastroFuncionario = Program.ServiceProvider.GetRequiredService<TelaCadastroFuncionario>())
            {
                this.Hide();
                fmTelaCadastroFuncionario.StartPosition = FormStartPosition.CenterScreen;
                fmTelaCadastroFuncionario.ShowDialog();
            }
        }

        private void rbtnMantutencaoFuncionario_Click(object sender, EventArgs e)
        {
            using (var fmTelaManutencaoAdm = Program.ServiceProvider.GetRequiredService<TelaManutencaoFuncionario>())
            {
                this.Hide();
                fmTelaManutencaoAdm.StartPosition = FormStartPosition.CenterScreen;
                fmTelaManutencaoAdm.ShowDialog();
            }
        }

        private void rbtnCadastroClientes_Click(object sender, EventArgs e)
        {
            using (var fmTelaCadastroCliente = Program.ServiceProvider.GetRequiredService<TelaCadastroCliente>())
            {
                this.Hide();
                fmTelaCadastroCliente.StartPosition = FormStartPosition.CenterScreen;
                fmTelaCadastroCliente.ShowDialog();
            }
        }
        private void rbtnManutencaoClientes_Click(object sender, EventArgs e)
        {
            using (var fmTelaManutencaoCliente = Program.ServiceProvider.GetRequiredService<TelaManutencaoClientes>())
            {
                this.Hide();
                fmTelaManutencaoCliente.StartPosition = FormStartPosition.CenterScreen;
                fmTelaManutencaoCliente.ShowDialog();
            }
        }
        private void rbtnManutencaoProdutos_Click(object sender, EventArgs e)
        {
            using (var fmTelaManutencaoProduto = Program.ServiceProvider.GetRequiredService<TelaManutencaoProdutos>())
            {
                this.Hide();
                fmTelaManutencaoProduto.StartPosition = FormStartPosition.CenterScreen;
                fmTelaManutencaoProduto.ShowDialog();
            }
        }
      
        private void rbtnCadastroFuncionario_MouseHover(object sender, EventArgs e)
        {
            rbtnCadastroFuncionario.Checked = true;
        }
        private void rbtnMantutencaoFuncionario_MouseHover(object sender, EventArgs e)
        {
            rbtnMantutencaoFuncionario.Checked = true;
        }
        private void rbtnCadastroClientes_MouseHover(object sender, EventArgs e)
        {
            rbtnCadastroCliente.Checked = true;
        }
        private void rbtnManutencaoClientes_MouseHover(object sender, EventArgs e)
        {
            rbtnManutencaoClientes.Checked = true;
        }
        private void rbtnManutencaoProdutos_MouseHover(object sender, EventArgs e)
        {
            rbtnManutencaoProdutos.Checked = true;
        }

    }
}
