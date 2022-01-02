
namespace Akademine_IS
{
    partial class Destytojai_Menu
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
            this.Nustatymai = new System.Windows.Forms.Button();
            this.IrasytiPazymi = new System.Windows.Forms.Button();
            this.CurrentUser = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Nustatymai
            // 
            this.Nustatymai.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.Nustatymai.Location = new System.Drawing.Point(132, 129);
            this.Nustatymai.Name = "Nustatymai";
            this.Nustatymai.Size = new System.Drawing.Size(237, 74);
            this.Nustatymai.TabIndex = 8;
            this.Nustatymai.Text = "Nustatymai";
            this.Nustatymai.UseVisualStyleBackColor = true;
            this.Nustatymai.Click += new System.EventHandler(this.Nustatymai_Click);
            // 
            // IrasytiPazymi
            // 
            this.IrasytiPazymi.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.IrasytiPazymi.Location = new System.Drawing.Point(432, 129);
            this.IrasytiPazymi.Name = "IrasytiPazymi";
            this.IrasytiPazymi.Size = new System.Drawing.Size(237, 74);
            this.IrasytiPazymi.TabIndex = 5;
            this.IrasytiPazymi.Text = "Įrašyti pažymį";
            this.IrasytiPazymi.UseVisualStyleBackColor = true;
            this.IrasytiPazymi.Click += new System.EventHandler(this.IrasytiPazymi_Click);
            // 
            // CurrentUser
            // 
            this.CurrentUser.AutoSize = true;
            this.CurrentUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.CurrentUser.Location = new System.Drawing.Point(68, 40);
            this.CurrentUser.Name = "CurrentUser";
            this.CurrentUser.Size = new System.Drawing.Size(0, 29);
            this.CurrentUser.TabIndex = 9;
            // 
            // Destytojai_Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.CurrentUser);
            this.Controls.Add(this.Nustatymai);
            this.Controls.Add(this.IrasytiPazymi);
            this.Name = "Destytojai_Menu";
            this.Text = "Destytojai_Menu";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Nustatymai;
        private System.Windows.Forms.Button IrasytiPazymi;
        private System.Windows.Forms.Label CurrentUser;
    }
}