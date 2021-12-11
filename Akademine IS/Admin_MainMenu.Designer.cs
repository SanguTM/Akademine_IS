
namespace Akademine_IS
{
    partial class Admin_MainMenu
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
            this.Vartotojai = new System.Windows.Forms.Button();
            this.StudijuDalykai = new System.Windows.Forms.Button();
            this.StudentuGrupes = new System.Windows.Forms.Button();
            this.Asmenys = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // CurrentUser
            // 
            this.CurrentUser.AutoSize = true;
            this.CurrentUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.CurrentUser.Location = new System.Drawing.Point(27, 23);
            this.CurrentUser.Name = "CurrentUser";
            this.CurrentUser.Size = new System.Drawing.Size(0, 29);
            this.CurrentUser.TabIndex = 0;
            // 
            // Vartotojai
            // 
            this.Vartotojai.Location = new System.Drawing.Point(421, 94);
            this.Vartotojai.Name = "Vartotojai";
            this.Vartotojai.Size = new System.Drawing.Size(237, 74);
            this.Vartotojai.TabIndex = 1;
            this.Vartotojai.Text = "Vartotojai";
            this.Vartotojai.UseVisualStyleBackColor = true;
            this.Vartotojai.Click += new System.EventHandler(this.Vartotojai_Click);
            // 
            // StudijuDalykai
            // 
            this.StudijuDalykai.Location = new System.Drawing.Point(121, 212);
            this.StudijuDalykai.Name = "StudijuDalykai";
            this.StudijuDalykai.Size = new System.Drawing.Size(237, 74);
            this.StudijuDalykai.TabIndex = 2;
            this.StudijuDalykai.Text = "Studiju dalykai";
            this.StudijuDalykai.UseVisualStyleBackColor = true;
            // 
            // StudentuGrupes
            // 
            this.StudentuGrupes.Location = new System.Drawing.Point(421, 212);
            this.StudentuGrupes.Name = "StudentuGrupes";
            this.StudentuGrupes.Size = new System.Drawing.Size(237, 74);
            this.StudentuGrupes.TabIndex = 3;
            this.StudentuGrupes.Text = "Studentu Grupes";
            this.StudentuGrupes.UseVisualStyleBackColor = true;
            // 
            // Asmenys
            // 
            this.Asmenys.Location = new System.Drawing.Point(121, 94);
            this.Asmenys.Name = "Asmenys";
            this.Asmenys.Size = new System.Drawing.Size(237, 74);
            this.Asmenys.TabIndex = 4;
            this.Asmenys.Text = "Asmenys";
            this.Asmenys.UseVisualStyleBackColor = true;
            // 
            // Admin_MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Asmenys);
            this.Controls.Add(this.StudentuGrupes);
            this.Controls.Add(this.StudijuDalykai);
            this.Controls.Add(this.Vartotojai);
            this.Controls.Add(this.CurrentUser);
            this.Name = "Admin_MainMenu";
            this.Text = "Pagrindinis meniu";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label CurrentUser;
        private System.Windows.Forms.Button Vartotojai;
        private System.Windows.Forms.Button StudijuDalykai;
        private System.Windows.Forms.Button StudentuGrupes;
        private System.Windows.Forms.Button Asmenys;
    }
}