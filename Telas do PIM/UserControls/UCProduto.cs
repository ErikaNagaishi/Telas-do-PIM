using System.Globalization;
using Telas_do_PIM.Forms;

namespace Telas_do_PIM.UserControls
{
    public partial class UCProduto : UserControl
    {
        private string nome;
        private decimal valor;
        private int maxQtd;
        private int maxQtdUpDown;
        private Image imagemProduto;
        private int qtd = 0;

        private TelaPrincipal telaPrincipal;

        private decimal valorTotal;
        public string Nome { get => nome; }
        public decimal Valor { get => valor; }
        public int MaxQtd { get => maxQtd; set => maxQtd = value; }
        public int MaxQtdUpDown { get => maxQtdUpDown; set => maxQtdUpDown = value; }
        public Image ImagemProduto { get => imagemProduto; }
        public decimal ValorTotal { get => valorTotal; set => valorTotal = value; }
        public int Qtd { get => qtd; set => qtd = value; }

        public int NumericUpDown { set => upDownQtd.Maximum = value; }

        public UCProduto(string nome, decimal valor, int maxQtd, int qtd, Image imagemProduto, TelaPrincipal telaPrincipal)
        {
            InitializeComponent();

            this.nome = nome;
            this.valor = valor;
            this.maxQtd = maxQtd;
            this.maxQtdUpDown = maxQtd;
            this.Qtd = qtd;
            this.imagemProduto = imagemProduto;
            this.telaPrincipal = telaPrincipal;

            this.upDownQtd.Maximum = this.maxQtdUpDown;
            this.labelNomeProduto.Text = nome;
            this.labelValorProduto.Text = valor.ToString("C", CultureInfo.GetCultureInfo("pt-BR"));
            this.pictureBoxProduto.Image = imagemProduto;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if(upDownQtd.Value > this.MaxQtd)
            {
                return;
            }
            qtd += (int)upDownQtd.Value;
            valorTotal = qtd * this.valor;

            this.maxQtdUpDown -= (int)upDownQtd.Value;
            this.upDownQtd.Maximum = this.maxQtdUpDown;
            //this.upDownQtd.Value = 0;


            telaPrincipal.AdicionaNoCarrinho(this);
        }

        private void upDownQtd_ValueChanged(object sender, EventArgs e)
        {
            this.btnAdd.Enabled = (upDownQtd.Value > 0 );
        }
    }
}
