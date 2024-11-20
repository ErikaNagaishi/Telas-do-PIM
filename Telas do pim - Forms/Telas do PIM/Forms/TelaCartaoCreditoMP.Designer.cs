namespace Telas_do_PIM.Forms
{
    partial class TelaCartaoCreditoMP
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            webViewMP = new Microsoft.Web.WebView2.WinForms.WebView2();
            ((System.ComponentModel.ISupportInitialize)webViewMP).BeginInit();
            SuspendLayout();
            // 
            // webViewMP
            // 
            webViewMP.AllowExternalDrop = true;
            webViewMP.CreationProperties = null;
            webViewMP.DefaultBackgroundColor = Color.White;
            webViewMP.Dock = DockStyle.Fill;
            webViewMP.Location = new Point(0, 0);
            webViewMP.Name = "webViewMP";
            webViewMP.Size = new Size(800, 450);
            webViewMP.TabIndex = 0;
            webViewMP.ZoomFactor = 1D;
            // 
            // TelaCartaoCreditoMP
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(webViewMP);
            Name = "TelaCartaoCreditoMP";
            Text = "TelaCartaoCreditoMP";
            WindowState = FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)webViewMP).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Microsoft.Web.WebView2.WinForms.WebView2 webViewMP;
    }
}