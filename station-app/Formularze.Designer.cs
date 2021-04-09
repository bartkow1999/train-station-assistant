
namespace station_app
{
    partial class FormularzeForm
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.aktualnyRozkladLabel = new System.Windows.Forms.Label();
            this.formularzDataGridView = new System.Windows.Forms.DataGridView();
            this.dodajElementButton = new System.Windows.Forms.Button();
            this.edytujElementButton = new System.Windows.Forms.Button();
            this.usunElementButton = new System.Windows.Forms.Button();
            this.zaladujDaneButton = new System.Windows.Forms.Button();
            this.wyjdzButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.szukajButton = new System.Windows.Forms.Button();
            this.szukajLabel = new System.Windows.Forms.Label();
            this.kryteriumLabel = new System.Windows.Forms.Label();
            this.kryteriumComboBox = new System.Windows.Forms.ComboBox();
            this.szukajTextBox = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.zaladujDaneComboBox = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.formularzDataGridView)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // aktualnyRozkladLabel
            // 
            this.aktualnyRozkladLabel.AutoSize = true;
            this.aktualnyRozkladLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.aktualnyRozkladLabel.Location = new System.Drawing.Point(17, 14);
            this.aktualnyRozkladLabel.Name = "aktualnyRozkladLabel";
            this.aktualnyRozkladLabel.Size = new System.Drawing.Size(137, 18);
            this.aktualnyRozkladLabel.TabIndex = 1;
            this.aktualnyRozkladLabel.Text = "Aktualny rozkład:";
            // 
            // formularzDataGridView
            // 
            this.formularzDataGridView.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.formularzDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.formularzDataGridView.GridColor = System.Drawing.SystemColors.WindowFrame;
            this.formularzDataGridView.Location = new System.Drawing.Point(12, 38);
            this.formularzDataGridView.Name = "formularzDataGridView";
            this.formularzDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.formularzDataGridView.Size = new System.Drawing.Size(1276, 466);
            this.formularzDataGridView.TabIndex = 4;
            // 
            // dodajElementButton
            // 
            this.dodajElementButton.FlatAppearance.BorderSize = 2;
            this.dodajElementButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dodajElementButton.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.dodajElementButton.Location = new System.Drawing.Point(640, 628);
            this.dodajElementButton.Name = "dodajElementButton";
            this.dodajElementButton.Size = new System.Drawing.Size(150, 100);
            this.dodajElementButton.TabIndex = 8;
            this.dodajElementButton.Text = "Dodaj rekord";
            this.dodajElementButton.UseVisualStyleBackColor = true;
            this.dodajElementButton.Click += new System.EventHandler(this.dodajElementButton_Click);
            // 
            // edytujElementButton
            // 
            this.edytujElementButton.FlatAppearance.BorderSize = 2;
            this.edytujElementButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.edytujElementButton.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.edytujElementButton.Location = new System.Drawing.Point(796, 628);
            this.edytujElementButton.Name = "edytujElementButton";
            this.edytujElementButton.Size = new System.Drawing.Size(150, 100);
            this.edytujElementButton.TabIndex = 9;
            this.edytujElementButton.Text = "Edytuj rekord";
            this.edytujElementButton.UseVisualStyleBackColor = true;
            this.edytujElementButton.Click += new System.EventHandler(this.edytujElementButton_Click);
            // 
            // usunElementButton
            // 
            this.usunElementButton.FlatAppearance.BorderSize = 2;
            this.usunElementButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.usunElementButton.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.usunElementButton.Location = new System.Drawing.Point(952, 628);
            this.usunElementButton.Name = "usunElementButton";
            this.usunElementButton.Size = new System.Drawing.Size(150, 100);
            this.usunElementButton.TabIndex = 10;
            this.usunElementButton.Text = "Usuń rekord";
            this.usunElementButton.UseVisualStyleBackColor = true;
            this.usunElementButton.Click += new System.EventHandler(this.usunElementButton_Click);
            // 
            // zaladujDaneButton
            // 
            this.zaladujDaneButton.FlatAppearance.BorderSize = 2;
            this.zaladujDaneButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.zaladujDaneButton.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.zaladujDaneButton.Location = new System.Drawing.Point(323, 19);
            this.zaladujDaneButton.Name = "zaladujDaneButton";
            this.zaladujDaneButton.Size = new System.Drawing.Size(132, 38);
            this.zaladujDaneButton.TabIndex = 13;
            this.zaladujDaneButton.Text = "Załaduj dane";
            this.zaladujDaneButton.UseVisualStyleBackColor = true;
            this.zaladujDaneButton.Click += new System.EventHandler(this.zaladujDaneButton_Click);
            // 
            // wyjdzButton
            // 
            this.wyjdzButton.FlatAppearance.BorderSize = 2;
            this.wyjdzButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.wyjdzButton.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.wyjdzButton.Location = new System.Drawing.Point(1138, 628);
            this.wyjdzButton.Name = "wyjdzButton";
            this.wyjdzButton.Size = new System.Drawing.Size(150, 100);
            this.wyjdzButton.TabIndex = 14;
            this.wyjdzButton.Text = "Wyjdź";
            this.wyjdzButton.UseVisualStyleBackColor = true;
            this.wyjdzButton.Click += new System.EventHandler(this.wyjdzButton_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel8);
            this.panel1.Controls.Add(this.formularzDataGridView);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1300, 510);
            this.panel1.TabIndex = 15;
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.panel8.Controls.Add(this.label1);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel8.Location = new System.Drawing.Point(0, 0);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(1300, 32);
            this.panel8.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(14, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tablica:";
            // 
            // szukajButton
            // 
            this.szukajButton.FlatAppearance.BorderSize = 2;
            this.szukajButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.szukajButton.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.szukajButton.Location = new System.Drawing.Point(335, 153);
            this.szukajButton.Name = "szukajButton";
            this.szukajButton.Size = new System.Drawing.Size(120, 34);
            this.szukajButton.TabIndex = 3;
            this.szukajButton.Text = "szukaj";
            this.szukajButton.UseVisualStyleBackColor = true;
            this.szukajButton.Visible = false;
            // 
            // szukajLabel
            // 
            this.szukajLabel.AutoSize = true;
            this.szukajLabel.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.szukajLabel.Location = new System.Drawing.Point(16, 96);
            this.szukajLabel.Name = "szukajLabel";
            this.szukajLabel.Size = new System.Drawing.Size(40, 21);
            this.szukajLabel.TabIndex = 5;
            this.szukajLabel.Text = "Filtr:";
            this.szukajLabel.Visible = false;
            // 
            // kryteriumLabel
            // 
            this.kryteriumLabel.AutoSize = true;
            this.kryteriumLabel.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.kryteriumLabel.Location = new System.Drawing.Point(369, 94);
            this.kryteriumLabel.Name = "kryteriumLabel";
            this.kryteriumLabel.Size = new System.Drawing.Size(86, 21);
            this.kryteriumLabel.TabIndex = 6;
            this.kryteriumLabel.Text = "Kryterium:";
            this.kryteriumLabel.Visible = false;
            // 
            // kryteriumComboBox
            // 
            this.kryteriumComboBox.FormattingEnabled = true;
            this.kryteriumComboBox.Location = new System.Drawing.Point(245, 118);
            this.kryteriumComboBox.Name = "kryteriumComboBox";
            this.kryteriumComboBox.Size = new System.Drawing.Size(210, 29);
            this.kryteriumComboBox.TabIndex = 7;
            this.kryteriumComboBox.Visible = false;
            // 
            // szukajTextBox
            // 
            this.szukajTextBox.Location = new System.Drawing.Point(20, 120);
            this.szukajTextBox.Name = "szukajTextBox";
            this.szukajTextBox.Size = new System.Drawing.Size(210, 27);
            this.szukajTextBox.TabIndex = 2;
            this.szukajTextBox.Visible = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.zaladujDaneComboBox);
            this.panel2.Controls.Add(this.szukajTextBox);
            this.panel2.Controls.Add(this.kryteriumComboBox);
            this.panel2.Controls.Add(this.zaladujDaneButton);
            this.panel2.Controls.Add(this.kryteriumLabel);
            this.panel2.Controls.Add(this.szukajLabel);
            this.panel2.Controls.Add(this.szukajButton);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 510);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(489, 230);
            this.panel2.TabIndex = 16;
            // 
            // zaladujDaneComboBox
            // 
            this.zaladujDaneComboBox.FormattingEnabled = true;
            this.zaladujDaneComboBox.Location = new System.Drawing.Point(20, 25);
            this.zaladujDaneComboBox.Name = "zaladujDaneComboBox";
            this.zaladujDaneComboBox.Size = new System.Drawing.Size(287, 29);
            this.zaladujDaneComboBox.TabIndex = 14;
            // 
            // FormularzeForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.ClientSize = new System.Drawing.Size(1300, 740);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.edytujElementButton);
            this.Controls.Add(this.wyjdzButton);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.aktualnyRozkladLabel);
            this.Controls.Add(this.usunElementButton);
            this.Controls.Add(this.dodajElementButton);
            this.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FormularzeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Formularze";
            ((System.ComponentModel.ISupportInitialize)(this.formularzDataGridView)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label aktualnyRozkladLabel;
        private System.Windows.Forms.DataGridView formularzDataGridView;
        private System.Windows.Forms.Button dodajElementButton;
        private System.Windows.Forms.Button edytujElementButton;
        private System.Windows.Forms.Button usunElementButton;
        private System.Windows.Forms.Button zaladujDaneButton;
        private System.Windows.Forms.Button wyjdzButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button szukajButton;
        private System.Windows.Forms.Label szukajLabel;
        private System.Windows.Forms.Label kryteriumLabel;
        private System.Windows.Forms.ComboBox kryteriumComboBox;
        private System.Windows.Forms.TextBox szukajTextBox;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox zaladujDaneComboBox;
    }
}

