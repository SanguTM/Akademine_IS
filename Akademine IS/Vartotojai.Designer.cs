
namespace Akademine_IS
{
    partial class Vartotojai
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
            this.VartotojaiGridView = new System.Windows.Forms.DataGridView();
            this.CloseForm = new System.Windows.Forms.Button();
            this.Naujas = new System.Windows.Forms.Button();
            this.Redaguoti = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.VartotojaiGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // VartotojaiGridView
            // 
            this.VartotojaiGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.VartotojaiGridView.Location = new System.Drawing.Point(34, 68);
            this.VartotojaiGridView.Name = "VartotojaiGridView";
            this.VartotojaiGridView.Size = new System.Drawing.Size(712, 321);
            this.VartotojaiGridView.TabIndex = 1;
            // 
            // CloseForm
            // 
            this.CloseForm.Location = new System.Drawing.Point(336, 406);
            this.CloseForm.Name = "CloseForm";
            this.CloseForm.Size = new System.Drawing.Size(75, 23);
            this.CloseForm.TabIndex = 2;
            this.CloseForm.Text = "Uzdaryti";
            this.CloseForm.UseVisualStyleBackColor = true;
            this.CloseForm.Click += new System.EventHandler(this.CloseForm_Click);
            // 
            // Naujas
            // 
            this.Naujas.Location = new System.Drawing.Point(34, 23);
            this.Naujas.Name = "Naujas";
            this.Naujas.Size = new System.Drawing.Size(75, 23);
            this.Naujas.TabIndex = 3;
            this.Naujas.Text = "Naujas";
            this.Naujas.UseVisualStyleBackColor = true;
            // 
            // Redaguoti
            // 
            this.Redaguoti.Location = new System.Drawing.Point(161, 23);
            this.Redaguoti.Name = "Redaguoti";
            this.Redaguoti.Size = new System.Drawing.Size(75, 23);
            this.Redaguoti.TabIndex = 4;
            this.Redaguoti.Text = "Redaguoti";
            this.Redaguoti.UseVisualStyleBackColor = true;
            this.Redaguoti.Click += new System.EventHandler(this.Redaguoti_Click);
            // 
            // Vartotojai
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Redaguoti);
            this.Controls.Add(this.Naujas);
            this.Controls.Add(this.CloseForm);
            this.Controls.Add(this.VartotojaiGridView);
            this.Name = "Vartotojai";
            this.Text = "Vartotojai";
            ((System.ComponentModel.ISupportInitialize)(this.VartotojaiGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView VartotojaiGridView;
        private System.Windows.Forms.Button CloseForm;
        private System.Windows.Forms.Button Naujas;
        private System.Windows.Forms.Button Redaguoti;
    }
}