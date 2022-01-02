
namespace Akademine_IS
{
    partial class NewVertinimai
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
            this.PastabaBox = new System.Windows.Forms.TextBox();
            this.PazymysBox = new System.Windows.Forms.TextBox();
            this.Pastaba = new System.Windows.Forms.Label();
            this.Pazymys = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Uzdaryti
            // 
            this.Uzdaryti.Location = new System.Drawing.Point(448, 353);
            this.Uzdaryti.Name = "Uzdaryti";
            this.Uzdaryti.Size = new System.Drawing.Size(75, 23);
            this.Uzdaryti.TabIndex = 49;
            this.Uzdaryti.Text = "Uzdaryti";
            this.Uzdaryti.UseVisualStyleBackColor = true;
            this.Uzdaryti.Click += new System.EventHandler(this.Uzdaryti_Click);
            // 
            // Isaugoti
            // 
            this.Isaugoti.Location = new System.Drawing.Point(231, 353);
            this.Isaugoti.Name = "Isaugoti";
            this.Isaugoti.Size = new System.Drawing.Size(75, 23);
            this.Isaugoti.TabIndex = 48;
            this.Isaugoti.Text = "Issaugoti";
            this.Isaugoti.UseVisualStyleBackColor = true;
            this.Isaugoti.Click += new System.EventHandler(this.Isaugoti_Click);
            // 
            // PastabaBox
            // 
            this.PastabaBox.Location = new System.Drawing.Point(423, 178);
            this.PastabaBox.Name = "PastabaBox";
            this.PastabaBox.Size = new System.Drawing.Size(100, 20);
            this.PastabaBox.TabIndex = 45;
            // 
            // PazymysBox
            // 
            this.PazymysBox.Location = new System.Drawing.Point(423, 143);
            this.PazymysBox.Name = "PazymysBox";
            this.PazymysBox.Size = new System.Drawing.Size(100, 20);
            this.PazymysBox.TabIndex = 44;
            // 
            // Pastaba
            // 
            this.Pastaba.AutoSize = true;
            this.Pastaba.Location = new System.Drawing.Point(260, 185);
            this.Pastaba.Name = "Pastaba";
            this.Pastaba.Size = new System.Drawing.Size(46, 13);
            this.Pastaba.TabIndex = 38;
            this.Pastaba.Text = "Pastaba";
            // 
            // Pazymys
            // 
            this.Pazymys.AutoSize = true;
            this.Pazymys.Location = new System.Drawing.Point(258, 150);
            this.Pazymys.Name = "Pazymys";
            this.Pazymys.Size = new System.Drawing.Size(48, 13);
            this.Pazymys.TabIndex = 37;
            this.Pazymys.Text = "Pažymys";
            // 
            // NewVertinimai
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Uzdaryti);
            this.Controls.Add(this.Isaugoti);
            this.Controls.Add(this.PastabaBox);
            this.Controls.Add(this.PazymysBox);
            this.Controls.Add(this.Pastaba);
            this.Controls.Add(this.Pazymys);
            this.Name = "NewVertinimai";
            this.Text = "NewVertinimai";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button Uzdaryti;
        private System.Windows.Forms.Button Isaugoti;
        private System.Windows.Forms.TextBox PastabaBox;
        private System.Windows.Forms.TextBox PazymysBox;
        private System.Windows.Forms.Label Pastaba;
        private System.Windows.Forms.Label Pazymys;
    }
}