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
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            gridAplicativos = new DataGridView();
            tabPage2 = new TabPage();
            chkAplicacoesPadraoComunix = new CheckBox();
            gridAplicativosAbertos = new DataGridView();
            button1 = new Button();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridAplicativos).BeginInit();
            tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridAplicativosAbertos).BeginInit();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Location = new Point(12, 12);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(832, 426);
            tabControl1.TabIndex = 3;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(gridAplicativos);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(824, 398);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "tabPage1";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // gridAplicativos
            // 
            gridAplicativos.AllowUserToAddRows = false;
            gridAplicativos.AllowUserToDeleteRows = false;
            gridAplicativos.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            gridAplicativos.BackgroundColor = SystemColors.ControlLightLight;
            gridAplicativos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridAplicativos.Location = new Point(27, 19);
            gridAplicativos.Margin = new Padding(4, 3, 4, 3);
            gridAplicativos.Name = "gridAplicativos";
            gridAplicativos.ReadOnly = true;
            gridAplicativos.RowHeadersVisible = false;
            gridAplicativos.Size = new Size(775, 352);
            gridAplicativos.TabIndex = 3;
            gridAplicativos.Leave += gridAplicativos_Leave;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(chkAplicacoesPadraoComunix);
            tabPage2.Controls.Add(gridAplicativosAbertos);
            tabPage2.Controls.Add(button1);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(824, 398);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "tabPage2";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // chkAplicacoesPadraoComunix
            // 
            chkAplicacoesPadraoComunix.AutoSize = true;
            chkAplicacoesPadraoComunix.Checked = true;
            chkAplicacoesPadraoComunix.CheckState = CheckState.Checked;
            chkAplicacoesPadraoComunix.Location = new Point(20, 20);
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
            gridAplicativosAbertos.Location = new Point(20, 45);
            gridAplicativosAbertos.Margin = new Padding(4, 3, 4, 3);
            gridAplicativosAbertos.Name = "gridAplicativosAbertos";
            gridAplicativosAbertos.ReadOnly = true;
            gridAplicativosAbertos.RowHeadersVisible = false;
            gridAplicativosAbertos.Size = new Size(775, 335);
            gridAplicativosAbertos.TabIndex = 4;
            // 
            // button1
            // 
            button1.Location = new Point(720, 16);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 1;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click_1;
            // 
            // FPrincipal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(881, 450);
            Controls.Add(tabControl1);
            Name = "FPrincipal";
            Text = "Principal";
            FormClosing += FPrincipal_FormClosing;
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gridAplicativos).EndInit();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)gridAplicativosAbertos).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private Button button1;
        private DataGridView gridAplicativos;
        private DataGridView gridAplicativosAbertos;
        private CheckBox chkAplicacoesPadraoComunix;
        private CheckBox chkCASCADIA_WINDOW;
    }
}
