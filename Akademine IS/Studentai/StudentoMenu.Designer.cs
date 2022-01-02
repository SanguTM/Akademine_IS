
namespace Akademine_IS
{
    partial class StudentoMenu
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
            this.CurrentUser = new System.Windows.Forms.Label();
            this.Nustatymai = new System.Windows.Forms.Button();
            this.PerziuretiPazymi = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // CurrentUser
            // 
            this.CurrentUser.AutoSize = true;
            this.CurrentUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.CurrentUser.Location = new System.Drawing.Point(88, 70);
            this.CurrentUser.Name = "CurrentUser";
            this.CurrentUser.Size = new System.Drawing.Size(0, 29);
            this.CurrentUser.TabIndex = 12;
            // 
            // Nustatymai
            // 
            this.Nustatymai.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.Nustatymai.Location = new System.Drawing.Point(137, 175);
            this.Nustatymai.Name = "Nustatymai";
            this.Nustatymai.Size = new System.Drawing.Size(237, 74);
            this.Nustatymai.TabIndex = 11;
            this.Nustatymai.Text = "Nustatymai";
            this.Nustatymai.UseVisualStyleBackColor = true;
            this.Nustatymai.Click += new System.EventHandler(this.Nustatymai_Click);
            // 
            // PerziuretiPazymi
            // 
            this.PerziuretiPazymi.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.PerziuretiPazymi.Location = new System.Drawing.Point(437, 175);
            this.PerziuretiPazymi.Name = "PerziuretiPazymi";
            this.PerziuretiPazymi.Size = new System.Drawing.Size(237, 74);
            this.PerziuretiPazymi.TabIndex = 10;
            this.PerziuretiPazymi.Text = "Peržiūrėti pažymius";
            this.PerziuretiPazymi.UseVisualStyleBackColor = true;
            this.PerziuretiPazymi.Click += new System.EventHandler(this.PerziuretiPazymi_Click);
            // 
            // StudentoMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.CurrentUser);
            this.Controls.Add(this.Nustatymai);
            this.Controls.Add(this.PerziuretiPazymi);
            this.Name = "StudentoMenu";
            this.Text = "StudentoMenu";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label CurrentUser;
        private System.Windows.Forms.Button Nustatymai;
        private System.Windows.Forms.Button PerziuretiPazymi;
    }
}