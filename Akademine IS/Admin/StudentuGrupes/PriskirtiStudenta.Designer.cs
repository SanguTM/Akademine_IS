
namespace Akademine_IS
{
    partial class PriskirtiStudenta
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
            this.Redaguoti = new System.Windows.Forms.Button();
            this.Istrinti = new System.Windows.Forms.Button();
            this.Naujas = new System.Windows.Forms.Button();
            this.CloseForm = new System.Windows.Forms.Button();
            this.PriskirtiStudentaGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.PriskirtiStudentaGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // Redaguoti
            // 
            this.Redaguoti.Location = new System.Drawing.Point(170, 22);
            this.Redaguoti.Name = "Redaguoti";
            this.Redaguoti.Size = new System.Drawing.Size(75, 23);
            this.Redaguoti.TabIndex = 20;
            this.Redaguoti.Text = "Redaguoti";
            this.Redaguoti.UseVisualStyleBackColor = true;
            this.Redaguoti.Click += new System.EventHandler(this.Redaguoti_Click);
            // 
            // Istrinti
            // 
            this.Istrinti.Location = new System.Drawing.Point(299, 22);
            this.Istrinti.Name = "Istrinti";
            this.Istrinti.Size = new System.Drawing.Size(75, 23);
            this.Istrinti.TabIndex = 19;
            this.Istrinti.Text = "Ištrinti";
            this.Istrinti.UseVisualStyleBackColor = true;
            this.Istrinti.Click += new System.EventHandler(this.Istrinti_Click);
            // 
            // Naujas
            // 
            this.Naujas.Location = new System.Drawing.Point(44, 22);
            this.Naujas.Name = "Naujas";
            this.Naujas.Size = new System.Drawing.Size(75, 23);
            this.Naujas.TabIndex = 18;
            this.Naujas.Text = "Naujas";
            this.Naujas.UseVisualStyleBackColor = true;
            this.Naujas.Click += new System.EventHandler(this.Naujas_Click);
            // 
            // CloseForm
            // 
            this.CloseForm.Location = new System.Drawing.Point(346, 405);
            this.CloseForm.Name = "CloseForm";
            this.CloseForm.Size = new System.Drawing.Size(75, 23);
            this.CloseForm.TabIndex = 17;
            this.CloseForm.Text = "Uzdaryti";
            this.CloseForm.UseVisualStyleBackColor = true;
            this.CloseForm.Click += new System.EventHandler(this.CloseForm_Click);
            // 
            // PriskirtiStudentaGridView
            // 
            this.PriskirtiStudentaGridView.AllowUserToAddRows = false;
            this.PriskirtiStudentaGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.PriskirtiStudentaGridView.Location = new System.Drawing.Point(44, 67);
            this.PriskirtiStudentaGridView.Name = "PriskirtiStudentaGridView";
            this.PriskirtiStudentaGridView.Size = new System.Drawing.Size(712, 321);
            this.PriskirtiStudentaGridView.TabIndex = 16;
            this.PriskirtiStudentaGridView.DoubleClick += new System.EventHandler(this.PriskirtiStudentaGridView_DoubleClick);
            // 
            // PriskirtiStudenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Redaguoti);
            this.Controls.Add(this.Istrinti);
            this.Controls.Add(this.Naujas);
            this.Controls.Add(this.CloseForm);
            this.Controls.Add(this.PriskirtiStudentaGridView);
            this.Name = "PriskirtiStudenta";
            this.Text = "PriskirtiStudenta";
            ((System.ComponentModel.ISupportInitialize)(this.PriskirtiStudentaGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Redaguoti;
        private System.Windows.Forms.Button Istrinti;
        private System.Windows.Forms.Button Naujas;
        private System.Windows.Forms.Button CloseForm;
        private System.Windows.Forms.DataGridView PriskirtiStudentaGridView;
    }
}