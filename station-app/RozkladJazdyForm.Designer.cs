
namespace station_app
{
    partial class RozkladJazdyForm
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
            this.aktualnyRozkladDataGridView = new System.Windows.Forms.DataGridView();
            this.dodajPolaczenieButton = new System.Windows.Forms.Button();
            this.edytujPolaczenieButton = new System.Windows.Forms.Button();
            this.usunPolaczenieButton = new System.Windows.Forms.Button();
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
            ((System.ComponentModel.ISupportInitialize)(this.aktualnyRozkladDataGridView)).BeginInit();
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
            // aktualnePomoceDataGridView
            // 
            this.aktualnyRozkladDataGridView.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.aktualnyRozkladDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.aktualnyRozkladDataGridView.GridColor = System.Drawing.SystemColors.WindowFrame;
            this.aktualnyRozkladDataGridView.Location = new System.Drawing.Point(12, 38);
            this.aktualnyRozkladDataGridView.Name = "aktualnePomoceDataGridView";
            this.aktualnyRozkladDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.aktualnyRozkladDataGridView.Size = new System.Drawing.Size(1276, 466);
            this.aktualnyRozkladDataGridView.TabIndex = 4;
            // 
            // dodajPolaczenieButton
            // 
            this.dodajPolaczenieButton.FlatAppearance.BorderSize = 2;
            this.dodajPolaczenieButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dodajPolaczenieButton.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.dodajPolaczenieButton.Location = new System.Drawing.Point(640, 628);
            this.dodajPolaczenieButton.Name = "dodajPolaczenieButton";
            this.dodajPolaczenieButton.Size = new System.Drawing.Size(150, 100);
            this.dodajPolaczenieButton.TabIndex = 8;
            this.dodajPolaczenieButton.Text = "Dodaj połaczenie do rozkładu";
            this.dodajPolaczenieButton.UseVisualStyleBackColor = true;
            this.dodajPolaczenieButton.Click += new System.EventHandler(this.dodajPolaczenieButton_Click);
            // 
            // edytujPolaczenieButton
            // 
            this.edytujPolaczenieButton.FlatAppearance.BorderSize = 2;
            this.edytujPolaczenieButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.edytujPolaczenieButton.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.edytujPolaczenieButton.Location = new System.Drawing.Point(796, 628);
            this.edytujPolaczenieButton.Name = "edytujPolaczenieButton";
            this.edytujPolaczenieButton.Size = new System.Drawing.Size(150, 100);
            this.edytujPolaczenieButton.TabIndex = 9;
            this.edytujPolaczenieButton.Text = "Edytuj połaczenie z rozkładu";
            this.edytujPolaczenieButton.UseVisualStyleBackColor = true;
            this.edytujPolaczenieButton.Click += new System.EventHandler(this.edytujPolaczenieButton_Click);
            // 
            // usunPolaczenieButton
            // 
            this.usunPolaczenieButton.FlatAppearance.BorderSize = 2;
            this.usunPolaczenieButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.usunPolaczenieButton.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.usunPolaczenieButton.Location = new System.Drawing.Point(952, 628);
            this.usunPolaczenieButton.Name = "usunPolaczenieButton";
            this.usunPolaczenieButton.Size = new System.Drawing.Size(150, 100);
            this.usunPolaczenieButton.TabIndex = 10;
            this.usunPolaczenieButton.Text = "Usuń połaczenie z rozkładu";
            this.usunPolaczenieButton.UseVisualStyleBackColor = true;
            this.usunPolaczenieButton.Click += new System.EventHandler(this.usunPolaczenieButton_Click);
            // 
            // zaladujDaneButton
            // 
            this.zaladujDaneButton.FlatAppearance.BorderSize = 2;
            this.zaladujDaneButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.zaladujDaneButton.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.zaladujDaneButton.Location = new System.Drawing.Point(15, 6);
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
            this.panel1.Controls.Add(this.aktualnyRozkladDataGridView);
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
            this.label1.Location = new System.Drawing.Point(11, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(225, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Aktualny rozkład połączeń:";
            // 
            // szukajButton
            // 
            this.szukajButton.FlatAppearance.BorderSize = 2;
            this.szukajButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.szukajButton.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.szukajButton.Location = new System.Drawing.Point(335, 129);
            this.szukajButton.Name = "szukajButton";
            this.szukajButton.Size = new System.Drawing.Size(120, 34);
            this.szukajButton.TabIndex = 3;
            this.szukajButton.Text = "szukaj";
            this.szukajButton.UseVisualStyleBackColor = true;
            this.szukajButton.Click += new System.EventHandler(this.szukajButton_Click);
            // 
            // szukajLabel
            // 
            this.szukajLabel.AutoSize = true;
            this.szukajLabel.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.szukajLabel.Location = new System.Drawing.Point(16, 72);
            this.szukajLabel.Name = "szukajLabel";
            this.szukajLabel.Size = new System.Drawing.Size(40, 21);
            this.szukajLabel.TabIndex = 5;
            this.szukajLabel.Text = "Filtr:";
            // 
            // kryteriumLabel
            // 
            this.kryteriumLabel.AutoSize = true;
            this.kryteriumLabel.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.kryteriumLabel.Location = new System.Drawing.Point(369, 70);
            this.kryteriumLabel.Name = "kryteriumLabel";
            this.kryteriumLabel.Size = new System.Drawing.Size(86, 21);
            this.kryteriumLabel.TabIndex = 6;
            this.kryteriumLabel.Text = "Kryterium:";
            // 
            // kryteriumComboBox
            // 
            this.kryteriumComboBox.FormattingEnabled = true;
            this.kryteriumComboBox.Location = new System.Drawing.Point(245, 94);
            this.kryteriumComboBox.Name = "kryteriumComboBox";
            this.kryteriumComboBox.Size = new System.Drawing.Size(210, 29);
            this.kryteriumComboBox.TabIndex = 7;
            // 
            // szukajTextBox
            // 
            this.szukajTextBox.Location = new System.Drawing.Point(20, 96);
            this.szukajTextBox.Name = "szukajTextBox";
            this.szukajTextBox.Size = new System.Drawing.Size(210, 27);
            this.szukajTextBox.TabIndex = 2;
            // 
            // panel2
            // 
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
            // RozkladJazdyForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.ClientSize = new System.Drawing.Size(1300, 740);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.edytujPolaczenieButton);
            this.Controls.Add(this.wyjdzButton);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.aktualnyRozkladLabel);
            this.Controls.Add(this.usunPolaczenieButton);
            this.Controls.Add(this.dodajPolaczenieButton);
            this.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "RozkladJazdyForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Rozkład jazdy";
            ((System.ComponentModel.ISupportInitialize)(this.aktualnyRozkladDataGridView)).EndInit();
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
        private System.Windows.Forms.DataGridView aktualnyRozkladDataGridView;
        private System.Windows.Forms.Button dodajPolaczenieButton;
        private System.Windows.Forms.Button edytujPolaczenieButton;
        private System.Windows.Forms.Button usunPolaczenieButton;
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
    }
}

