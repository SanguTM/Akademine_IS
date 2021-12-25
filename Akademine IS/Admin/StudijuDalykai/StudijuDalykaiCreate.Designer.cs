
namespace Akademine_IS
{
    partial class StudijuDalykaiCreate
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
            this.Uzdaryti = new System.Windows.Forms.Button();
            this.Isaugoti = new System.Windows.Forms.Button();
            this.AprasymasBox = new System.Windows.Forms.TextBox();
            this.PavadinimasBox = new System.Windows.Forms.TextBox();
            this.KodasBox = new System.Windows.Forms.TextBox();
            this.StdDalykoIdBox = new System.Windows.Forms.TextBox();
            this.Aprasymas = new System.Windows.Forms.Label();
            this.Pavadinimas = new System.Windows.Forms.Label();
            this.Kodas = new System.Windows.Forms.Label();
            this.StdDalykoId = new System.Windows.Forms.Label();
            this.PriskirtiDestytoja = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Uzdaryti
            // 
            this.Uzdaryti.Location = new System.Drawing.Point(478, 353);
            this.Uzdaryti.Name = "Uzdaryti";
            this.Uzdaryti.Size = new System.Drawing.Size(75, 23);
            this.Uzdaryti.TabIndex = 57;
            this.Uzdaryti.Text = "Uzdaryti";
            this.Uzdaryti.UseVisualStyleBackColor = true;
            this.Uzdaryti.Click += new System.EventHandler(this.Uzdaryti_Click);
            // 
            // Isaugoti
            // 
            this.Isaugoti.Location = new System.Drawing.Point(275, 353);
            this.Isaugoti.Name = "Isaugoti";
            this.Isaugoti.Size = new System.Drawing.Size(75, 23);
            this.Isaugoti.TabIndex = 56;
            this.Isaugoti.Text = "Issaugoti";
            this.Isaugoti.UseVisualStyleBackColor = true;
            this.Isaugoti.Click += new System.EventHandler(this.Isaugoti_Click);
            // 
            // AprasymasBox
            // 
            this.AprasymasBox.Location = new System.Drawing.Point(453, 178);
            this.AprasymasBox.Name = "AprasymasBox";
            this.AprasymasBox.Size = new System.Drawing.Size(100, 20);
            this.AprasymasBox.TabIndex = 54;
            // 
            // PavadinimasBox
            // 
            this.PavadinimasBox.Location = new System.Drawing.Point(453, 143);
            this.PavadinimasBox.Name = "PavadinimasBox";
            this.PavadinimasBox.Size = new System.Drawing.Size(100, 20);
            this.PavadinimasBox.TabIndex = 53;
            // 
            // KodasBox
            // 
            this.KodasBox.Location = new System.Drawing.Point(453, 109);
            this.KodasBox.Name = "KodasBox";
            this.KodasBox.Size = new System.Drawing.Size(100, 20);
            this.KodasBox.TabIndex = 52;
            // 
            // StdDalykoIdBox
            // 
            this.StdDalykoIdBox.Location = new System.Drawing.Point(453, 74);
            this.StdDalykoIdBox.Name = "StdDalykoIdBox";
            this.StdDalykoIdBox.ReadOnly = true;
            this.StdDalykoIdBox.Size = new System.Drawing.Size(100, 20);
            this.StdDalykoIdBox.TabIndex = 51;
            // 
            // Aprasymas
            // 
            this.Aprasymas.AutoSize = true;
            this.Aprasymas.Location = new System.Drawing.Point(299, 185);
            this.Aprasymas.Name = "Aprasymas";
            this.Aprasymas.Size = new System.Drawing.Size(58, 13);
            this.Aprasymas.TabIndex = 49;
            this.Aprasymas.Text = "Aprašymas";
            // 
            // Pavadinimas
            // 
            this.Pavadinimas.AutoSize = true;
            this.Pavadinimas.Location = new System.Drawing.Point(290, 150);
            this.Pavadinimas.Name = "Pavadinimas";
            this.Pavadinimas.Size = new System.Drawing.Size(67, 13);
            this.Pavadinimas.TabIndex = 48;
            this.Pavadinimas.Text = "Pavadinimas";
            // 
            // Kodas
            // 
            this.Kodas.AutoSize = true;
            this.Kodas.Location = new System.Drawing.Point(320, 116);
            this.Kodas.Name = "Kodas";
            this.Kodas.Size = new System.Drawing.Size(37, 13);
            this.Kodas.TabIndex = 47;
            this.Kodas.Text = "Kodas";
            // 
            // StdDalykoId
            // 
            this.StdDalykoId.AutoSize = true;
            this.StdDalykoId.Location = new System.Drawing.Point(272, 77);
            this.StdDalykoId.Name = "StdDalykoId";
            this.StdDalykoId.Size = new System.Drawing.Size(85, 13);
            this.StdDalykoId.TabIndex = 46;
            this.StdDalykoId.Text = "Studiju dalyko Id";
            // 
            // PriskirtiDestytoja
            // 
            this.PriskirtiDestytoja.Location = new System.Drawing.Point(453, 218);
            this.PriskirtiDestytoja.Name = "PriskirtiDestytoja";
            this.PriskirtiDestytoja.Size = new System.Drawing.Size(100, 23);
            this.PriskirtiDestytoja.TabIndex = 58;
            this.PriskirtiDestytoja.Text = "Priskirti dėstytoją";
            this.PriskirtiDestytoja.UseVisualStyleBackColor = true;
            this.PriskirtiDestytoja.Click += new System.EventHandler(this.PriskirtiDestytoja_Click);
            // 
            // StudijuDalykaiCreate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.PriskirtiDestytoja);
            this.Controls.Add(this.Uzdaryti);
            this.Controls.Add(this.Isaugoti);
            this.Controls.Add(this.AprasymasBox);
            this.Controls.Add(this.PavadinimasBox);
            this.Controls.Add(this.KodasBox);
            this.Controls.Add(this.StdDalykoIdBox);
            this.Controls.Add(this.Aprasymas);
            this.Controls.Add(this.Pavadinimas);
            this.Controls.Add(this.Kodas);
            this.Controls.Add(this.StdDalykoId);
            this.Name = "StudijuDalykaiCreate";
            this.Text = "StudijuDalykaiCreate";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Uzdaryti;
        private System.Windows.Forms.Button Isaugoti;
        private System.Windows.Forms.TextBox AprasymasBox;
        private System.Windows.Forms.TextBox PavadinimasBox;
        private System.Windows.Forms.TextBox KodasBox;
        private System.Windows.Forms.TextBox StdDalykoIdBox;
        private System.Windows.Forms.Label Aprasymas;
        private System.Windows.Forms.Label Pavadinimas;
        private System.Windows.Forms.Label Kodas;
        private System.Windows.Forms.Label StdDalykoId;
        private System.Windows.Forms.Button PriskirtiDestytoja;
    }
}