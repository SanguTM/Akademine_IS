
namespace Akademine_IS
{
    partial class StudentuGrupesEdit
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
            this.StudentuGrupesIdBox = new System.Windows.Forms.TextBox();
            this.Pavadinimas = new System.Windows.Forms.Label();
            this.Kodas = new System.Windows.Forms.Label();
            this.StudentuGrupesId = new System.Windows.Forms.Label();
            this.PriskirtiDalykus = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // PriskirtiStudenta
            // 
            this.PriskirtiStudenta.Location = new System.Drawing.Point(441, 218);
            this.PriskirtiStudenta.Name = "PriskirtiStudenta";
            this.PriskirtiStudenta.Size = new System.Drawing.Size(100, 23);
            this.PriskirtiStudenta.TabIndex = 80;
            this.PriskirtiStudenta.Text = "Priskirti studentą";
            this.PriskirtiStudenta.UseVisualStyleBackColor = true;
            this.PriskirtiStudenta.Click += new System.EventHandler(this.PriskirtiStudenta_Click);
            // 
            // Uzdaryti
            // 
            this.Uzdaryti.Location = new System.Drawing.Point(466, 353);
            this.Uzdaryti.Name = "Uzdaryti";
            this.Uzdaryti.Size = new System.Drawing.Size(75, 23);
            this.Uzdaryti.TabIndex = 79;
            this.Uzdaryti.Text = "Uzdaryti";
            this.Uzdaryti.UseVisualStyleBackColor = true;
            this.Uzdaryti.Click += new System.EventHandler(this.Uzdaryti_Click);
            // 
            // Isaugoti
            // 
            this.Isaugoti.Location = new System.Drawing.Point(263, 353);
            this.Isaugoti.Name = "Isaugoti";
            this.Isaugoti.Size = new System.Drawing.Size(75, 23);
            this.Isaugoti.TabIndex = 78;
            this.Isaugoti.Text = "Issaugoti";
            this.Isaugoti.UseVisualStyleBackColor = true;
            this.Isaugoti.Click += new System.EventHandler(this.Isaugoti_Click);
            // 
            // PavadinimasBox
            // 
            this.PavadinimasBox.Location = new System.Drawing.Point(441, 143);
            this.PavadinimasBox.Name = "PavadinimasBox";
            this.PavadinimasBox.Size = new System.Drawing.Size(100, 20);
            this.PavadinimasBox.TabIndex = 76;
            // 
            // KodasBox
            // 
            this.KodasBox.Location = new System.Drawing.Point(441, 109);
            this.KodasBox.Name = "KodasBox";
            this.KodasBox.Size = new System.Drawing.Size(100, 20);
            this.KodasBox.TabIndex = 75;
            // 
            // StudentuGrupesIdBox
            // 
            this.StudentuGrupesIdBox.Location = new System.Drawing.Point(441, 74);
            this.StudentuGrupesIdBox.Name = "StudentuGrupesIdBox";
            this.StudentuGrupesIdBox.ReadOnly = true;
            this.StudentuGrupesIdBox.Size = new System.Drawing.Size(100, 20);
            this.StudentuGrupesIdBox.TabIndex = 74;
            // 
            // Pavadinimas
            // 
            this.Pavadinimas.AutoSize = true;
            this.Pavadinimas.Location = new System.Drawing.Point(278, 150);
            this.Pavadinimas.Name = "Pavadinimas";
            this.Pavadinimas.Size = new System.Drawing.Size(67, 13);
            this.Pavadinimas.TabIndex = 72;
            this.Pavadinimas.Text = "Pavadinimas";
            // 
            // Kodas
            // 
            this.Kodas.AutoSize = true;
            this.Kodas.Location = new System.Drawing.Point(308, 116);
            this.Kodas.Name = "Kodas";
            this.Kodas.Size = new System.Drawing.Size(37, 13);
            this.Kodas.TabIndex = 71;
            this.Kodas.Text = "Kodas";
            // 
            // StudentuGrupesId
            // 
            this.StudentuGrupesId.AutoSize = true;
            this.StudentuGrupesId.Location = new System.Drawing.Point(260, 77);
            this.StudentuGrupesId.Name = "StudentuGrupesId";
            this.StudentuGrupesId.Size = new System.Drawing.Size(97, 13);
            this.StudentuGrupesId.TabIndex = 70;
            this.StudentuGrupesId.Text = "Studentų grupes Id";
            // 
            // PriskirtiDalykus
            // 
            this.PriskirtiDalykus.Location = new System.Drawing.Point(441, 247);
            this.PriskirtiDalykus.Name = "PriskirtiDalykus";
            this.PriskirtiDalykus.Size = new System.Drawing.Size(100, 23);
            this.PriskirtiDalykus.TabIndex = 81;
            this.PriskirtiDalykus.Text = "Priskirti dalykus";
            this.PriskirtiDalykus.UseVisualStyleBackColor = true;
            this.PriskirtiDalykus.Click += new System.EventHandler(this.PriskirtiDalykus_Click);
            // 
            // StudentuGrupesEdit
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
            this.Controls.Add(this.StudentuGrupesIdBox);
            this.Controls.Add(this.Pavadinimas);
            this.Controls.Add(this.Kodas);
            this.Controls.Add(this.StudentuGrupesId);
            this.Name = "StudentuGrupesEdit";
            this.Text = "StudentuGrupesEdit";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button PriskirtiStudenta;
        private System.Windows.Forms.Button Uzdaryti;
        private System.Windows.Forms.Button Isaugoti;
        private System.Windows.Forms.TextBox PavadinimasBox;
        private System.Windows.Forms.TextBox KodasBox;
        private System.Windows.Forms.TextBox StudentuGrupesIdBox;
        private System.Windows.Forms.Label Pavadinimas;
        private System.Windows.Forms.Label Kodas;
        private System.Windows.Forms.Label StudentuGrupesId;
        private System.Windows.Forms.Button PriskirtiDalykus;
    }
}