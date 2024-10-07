using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Telas_do_PIM.Forms
{
    public partial class TelaDeSelecao : Form
    {
        public TelaDeSelecao()
        {
            InitializeComponent();
        }

        private void Rbtnfunc_Click(object sender, EventArgs e)
        {
            TelaCadastro fmTelaCadastroFuncionario = new(false);
            fmTelaCadastroFuncionario.Show();
            this.Close();
        }

        private void Rbtnfunc_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Rbtnadm_CheckedChanged(object sender, EventArgs e)
        {
            TelaCadastro fmTelaCadastroFuncionario = new(true);
            fmTelaCadastroFuncionario.Show();
            this.Close();
        }

        private void Rbtncliente_CheckedChanged(object sender, EventArgs e)
        {
            TelaCadastroCliente fmTelaCadastroCliente = new();
            fmTelaCadastroCliente.Show();
            this.Close();
        }
    }
}
