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
            TelaCadastroFuncionario fmTelaCadastroFuncionario = new();
            fmTelaCadastroFuncionario.Show();
            this.Close();
        }

        private void Rbtnfunc_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
