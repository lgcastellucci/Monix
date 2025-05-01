namespace Monix
{
    partial class FPrincipal
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FPrincipal));
            tabControl1 = new TabControl();
            tabPageApicativos = new TabPage();
            lbTituloAplicativos = new Label();
            gridAplicativos = new DataGridView();
            tabPageAdicionarConf = new TabPage();
            chkAplicacoesPadraoComunix = new CheckBox();
            gridAplicativosAbertos = new DataGridView();
            btnConsutarJanelasAbertas = new Button();
            notifyIconMonix = new NotifyIcon(components);
            tabControl1.SuspendLayout();
            tabPageApicativos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridAplicativos).BeginInit();
            tabPageAdicionarConf.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridAplicativosAbertos).BeginInit();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPageApicativos);
            tabControl1.Controls.Add(tabPageAdicionarConf);
            tabControl1.Location = new Point(3, 12);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(446, 426);
            tabControl1.TabIndex = 3;
            // 
            // tabPageApicativos
            // 
            tabPageApicativos.Controls.Add(lbTituloAplicativos);
            tabPageApicativos.Controls.Add(gridAplicativos);
            tabPageApicativos.Location = new Point(4, 24);
            tabPageApicativos.Name = "tabPageApicativos";
            tabPageApicativos.Padding = new Padding(3);
            tabPageApicativos.Size = new Size(438, 398);
            tabPageApicativos.TabIndex = 0;
            tabPageApicativos.Text = "Apicativos";
            tabPageApicativos.UseVisualStyleBackColor = true;
            // 
            // lbTituloAplicativos
            // 
            lbTituloAplicativos.AutoSize = true;
            lbTituloAplicativos.Location = new Point(6, 12);
            lbTituloAplicativos.Name = "lbTituloAplicativos";
            lbTituloAplicativos.Size = new Size(209, 15);
            lbTituloAplicativos.TabIndex = 4;
            lbTituloAplicativos.Text = "Aplicativos que precisam estar abertos";
            // 
            // gridAplicativos
            // 
            gridAplicativos.AllowUserToAddRows = false;
            gridAplicativos.AllowUserToDeleteRows = false;
            gridAplicativos.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            gridAplicativos.BackgroundColor = SystemColors.ControlLightLight;
            gridAplicativos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridAplicativos.Location = new Point(7, 30);
            gridAplicativos.Margin = new Padding(4, 3, 4, 3);
            gridAplicativos.Name = "gridAplicativos";
            gridAplicativos.ReadOnly = true;
            gridAplicativos.RowHeadersVisible = false;
            gridAplicativos.Size = new Size(424, 362);
            gridAplicativos.TabIndex = 3;
            gridAplicativos.Leave += gridAplicativos_Leave;
            // 
            // tabPageAdicionarConf
            // 
            tabPageAdicionarConf.Controls.Add(chkAplicacoesPadraoComunix);
            tabPageAdicionarConf.Controls.Add(gridAplicativosAbertos);
            tabPageAdicionarConf.Controls.Add(btnConsutarJanelasAbertas);
            tabPageAdicionarConf.Location = new Point(4, 24);
            tabPageAdicionarConf.Name = "tabPageAdicionarConf";
            tabPageAdicionarConf.Padding = new Padding(3);
            tabPageAdicionarConf.Size = new Size(438, 398);
            tabPageAdicionarConf.TabIndex = 1;
            tabPageAdicionarConf.Text = "AdicionarConf";
            tabPageAdicionarConf.UseVisualStyleBackColor = true;
            // 
            // chkAplicacoesPadraoComunix
            // 
            chkAplicacoesPadraoComunix.AutoSize = true;
            chkAplicacoesPadraoComunix.Checked = true;
            chkAplicacoesPadraoComunix.CheckState = CheckState.Checked;
            chkAplicacoesPadraoComunix.Location = new Point(7, 347);
            chkAplicacoesPadraoComunix.Name = "chkAplicacoesPadraoComunix";
            chkAplicacoesPadraoComunix.Size = new Size(218, 19);
            chkAplicacoesPadraoComunix.TabIndex = 5;
            chkAplicacoesPadraoComunix.Text = "Somente janelas comuns a Comunix";
            chkAplicacoesPadraoComunix.UseVisualStyleBackColor = true;
            // 
            // gridAplicativosAbertos
            // 
            gridAplicativosAbertos.AllowUserToAddRows = false;
            gridAplicativosAbertos.AllowUserToDeleteRows = false;
            gridAplicativosAbertos.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            gridAplicativosAbertos.BackgroundColor = SystemColors.ControlLightLight;
            gridAplicativosAbertos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridAplicativosAbertos.Location = new Point(7, 6);
            gridAplicativosAbertos.Margin = new Padding(4, 3, 4, 3);
            gridAplicativosAbertos.Name = "gridAplicativosAbertos";
            gridAplicativosAbertos.ReadOnly = true;
            gridAplicativosAbertos.RowHeadersVisible = false;
            gridAplicativosAbertos.Size = new Size(410, 335);
            gridAplicativosAbertos.TabIndex = 4;
            // 
            // btnConsutarJanelasAbertas
            // 
            btnConsutarJanelasAbertas.Location = new Point(270, 344);
            btnConsutarJanelasAbertas.Name = "btnConsutarJanelasAbertas";
            btnConsutarJanelasAbertas.Size = new Size(169, 23);
            btnConsutarJanelasAbertas.TabIndex = 1;
            btnConsutarJanelasAbertas.Text = "Consutar Janelas Abertas";
            btnConsutarJanelasAbertas.UseVisualStyleBackColor = true;
            btnConsutarJanelasAbertas.Click += button1_Click_1;
            // 
            // notifyIconMonix
            // 
            notifyIconMonix.Icon = (Icon)resources.GetObject("notifyIconMonix.Icon");
            notifyIconMonix.Text = "Monix";
            notifyIconMonix.Visible = true;
            notifyIconMonix.DoubleClick += notifyIconMonix_DoubleClick;
            // 
            // FPrincipal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(450, 436);
            Controls.Add(tabControl1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "FPrincipal";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Monix";
            FormClosing += FPrincipal_FormClosing;
            Resize += FPrincipal_Resize;
            tabControl1.ResumeLayout(false);
            tabPageApicativos.ResumeLayout(false);
            tabPageApicativos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)gridAplicativos).EndInit();
            tabPageAdicionarConf.ResumeLayout(false);
            tabPageAdicionarConf.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)gridAplicativosAbertos).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabPageApicativos;
        private TabPage tabPageAdicionarConf;
        private Button btnConsutarJanelasAbertas;
        private DataGridView gridAplicativos;
        private DataGridView gridAplicativosAbertos;
        private CheckBox chkAplicacoesPadraoComunix;
        private CheckBox chkCASCADIA_WINDOW;
        private Label lbTituloAplicativos;
        private NotifyIcon notifyIconMonix;
    }
}
