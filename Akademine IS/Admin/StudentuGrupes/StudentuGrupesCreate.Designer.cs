
namespace Akademine_IS
{
    partial class StudentuGrupesCreate
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
            this.PriskirtiStudenta = new System.Windows.Forms.Button();
            this.Uzdaryti = new System.Windows.Forms.Button();
            this.Isaugoti = new System.Windows.Forms.Button();
            this.PavadinimasBox = new System.Windows.Forms.TextBox();
            this.KodasBox = new System.Windows.Forms.TextBox();
            this.StudentoGrupesIdBox = new System.Windows.Forms.TextBox();
            this.Pavadinimas = new System.Windows.Forms.Label();
            this.Kodas = new System.Windows.Forms.Label();
            this.StudentoGrupesId = new System.Windows.Forms.Label();
            this.PriskirtiDalykus = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // PriskirtiStudenta
            // 
            this.PriskirtiStudenta.Location = new System.Drawing.Point(486, 25);
            this.PriskirtiStudenta.Name = "PriskirtiStudenta";
            this.PriskirtiStudenta.Size = new System.Drawing.Size(100, 23);
            this.PriskirtiStudenta.TabIndex = 69;
            this.PriskirtiStudenta.Text = "Priskirti studentą";
            this.PriskirtiStudenta.UseVisualStyleBackColor = true;
            this.PriskirtiStudenta.Visible = false;
            this.PriskirtiStudenta.Click += new System.EventHandler(this.PriskirtiStudenta_Click);
            // 
            // Uzdaryti
            // 
            this.Uzdaryti.Location = new System.Drawing.Point(466, 353);
            this.Uzdaryti.Name = "Uzdaryti";
            this.Uzdaryti.Size = new System.Drawing.Size(75, 23);
            this.Uzdaryti.TabIndex = 68;
            this.Uzdaryti.Text = "Uzdaryti";
            this.Uzdaryti.UseVisualStyleBackColor = true;
            this.Uzdaryti.Click += new System.EventHandler(this.Uzdaryti_Click);
            // 
            // Isaugoti
            // 
            this.Isaugoti.Location = new System.Drawing.Point(249, 353);
            this.Isaugoti.Name = "Isaugoti";
            this.Isaugoti.Size = new System.Drawing.Size(75, 23);
            this.Isaugoti.TabIndex = 67;
            this.Isaugoti.Text = "Issaugoti";
            this.Isaugoti.UseVisualStyleBackColor = true;
            this.Isaugoti.Click += new System.EventHandler(this.Isaugoti_Click);
            // 
            // PavadinimasBox
            // 
            this.PavadinimasBox.Location = new System.Drawing.Point(441, 143);
            this.PavadinimasBox.Name = "PavadinimasBox";
            this.PavadinimasBox.Size = new System.Drawing.Size(100, 20);
            this.PavadinimasBox.TabIndex = 65;
            // 
            // KodasBox
            // 
            this.KodasBox.Location = new System.Drawing.Point(441, 109);
            this.KodasBox.Name = "KodasBox";
            this.KodasBox.Size = new System.Drawing.Size(100, 20);
            this.KodasBox.TabIndex = 64;
            // 
            // StudentoGrupesIdBox
            // 
            this.StudentoGrupesIdBox.Location = new System.Drawing.Point(441, 74);
            this.StudentoGrupesIdBox.Name = "StudentoGrupesIdBox";
            this.StudentoGrupesIdBox.ReadOnly = true;
            this.StudentoGrupesIdBox.Size = new System.Drawing.Size(100, 20);
            this.StudentoGrupesIdBox.TabIndex = 63;
            // 
            // Pavadinimas
            // 
            this.Pavadinimas.AutoSize = true;
            this.Pavadinimas.Location = new System.Drawing.Point(257, 150);
            this.Pavadinimas.Name = "Pavadinimas";
            this.Pavadinimas.Size = new System.Drawing.Size(67, 13);
            this.Pavadinimas.TabIndex = 61;
            this.Pavadinimas.Text = "Pavadinimas";
            // 
            // Kodas
            // 
            this.Kodas.AutoSize = true;
            this.Kodas.Location = new System.Drawing.Point(287, 116);
            this.Kodas.Name = "Kodas";
            this.Kodas.Size = new System.Drawing.Size(37, 13);
            this.Kodas.TabIndex = 60;
            this.Kodas.Text = "Kodas";
            // 
            // StudentoGrupesId
            // 
            this.StudentoGrupesId.AutoSize = true;
            this.StudentoGrupesId.Location = new System.Drawing.Point(238, 81);
            this.StudentoGrupesId.Name = "StudentoGrupesId";
            this.StudentoGrupesId.Size = new System.Drawing.Size(86, 13);
            this.StudentoGrupesId.TabIndex = 59;
            this.StudentoGrupesId.Text = "Studiju grupes Id";
            // 
            // PriskirtiDalykus
            // 
            this.PriskirtiDalykus.Location = new System.Drawing.Point(610, 25);
            this.PriskirtiDalykus.Name = "PriskirtiDalykus";
            this.PriskirtiDalykus.Size = new System.Drawing.Size(100, 23);
            this.PriskirtiDalykus.TabIndex = 70;
            this.PriskirtiDalykus.Text = "Priskirti dalykus";
            this.PriskirtiDalykus.UseVisualStyleBackColor = true;
            this.PriskirtiDalykus.Visible = false;
            this.PriskirtiDalykus.Click += new System.EventHandler(this.PriskirtiDalykus_Click);
            // 
            // StudentuGrupesCreate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.PriskirtiDalykus);
            this.Controls.Add(this.PriskirtiStudenta);
            this.Controls.Add(this.Uzdaryti);
            this.Controls.Add(this.Isaugoti);
            this.Controls.Add(this.PavadinimasBox);
            this.Controls.Add(this.KodasBox);
            this.Controls.Add(this.StudentoGrupesIdBox);
            this.Controls.Add(this.Pavadinimas);
            this.Controls.Add(this.Kodas);
            this.Controls.Add(this.StudentoGrupesId);
            this.Name = "StudentuGrupesCreate";
            this.Text = "StudentuGrupesCreate";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button PriskirtiStudenta;
        private System.Windows.Forms.Button Uzdaryti;
        private System.Windows.Forms.Button Isaugoti;
        private System.Windows.Forms.TextBox PavadinimasBox;
        private System.Windows.Forms.TextBox KodasBox;
        private System.Windows.Forms.TextBox StudentoGrupesIdBox;
        private System.Windows.Forms.Label Pavadinimas;
        private System.Windows.Forms.Label Kodas;
        private System.Windows.Forms.Label StudentoGrupesId;
        private System.Windows.Forms.Button PriskirtiDalykus;
    }
}