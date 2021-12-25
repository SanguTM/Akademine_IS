
namespace Akademine_IS
{
    partial class StudentuGrupes
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
            this.Istrinti = new System.Windows.Forms.Button();
            this.PriskirtiStudentus = new System.Windows.Forms.Button();
            this.Redaguoti = new System.Windows.Forms.Button();
            this.Naujas = new System.Windows.Forms.Button();
            this.CloseForm = new System.Windows.Forms.Button();
            this.StudentuGrupesGridView = new System.Windows.Forms.DataGridView();
            this.PriskirtiDalykus = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.StudentuGrupesGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // Istrinti
            // 
            this.Istrinti.Location = new System.Drawing.Point(304, 22);
            this.Istrinti.Name = "Istrinti";
            this.Istrinti.Size = new System.Drawing.Size(75, 23);
            this.Istrinti.TabIndex = 16;
            this.Istrinti.Text = "Ištrinti";
            this.Istrinti.UseVisualStyleBackColor = true;
            this.Istrinti.Click += new System.EventHandler(this.Istrinti_Click);
            // 
            // PriskirtiStudentus
            // 
            this.PriskirtiStudentus.Location = new System.Drawing.Point(636, 22);
            this.PriskirtiStudentus.Name = "PriskirtiStudentus";
            this.PriskirtiStudentus.Size = new System.Drawing.Size(120, 23);
            this.PriskirtiStudentus.TabIndex = 15;
            this.PriskirtiStudentus.Text = "Priskirti studentus";
            this.PriskirtiStudentus.UseVisualStyleBackColor = true;
            this.PriskirtiStudentus.Click += new System.EventHandler(this.PriskirtiStudentus_Click);
            // 
            // Redaguoti
            // 
            this.Redaguoti.Location = new System.Drawing.Point(171, 22);
            this.Redaguoti.Name = "Redaguoti";
            this.Redaguoti.Size = new System.Drawing.Size(75, 23);
            this.Redaguoti.TabIndex = 14;
            this.Redaguoti.Text = "Redaguoti";
            this.Redaguoti.UseVisualStyleBackColor = true;
            this.Redaguoti.Click += new System.EventHandler(this.Redaguoti_Click);
            // 
            // Naujas
            // 
            this.Naujas.Location = new System.Drawing.Point(44, 22);
            this.Naujas.Name = "Naujas";
            this.Naujas.Size = new System.Drawing.Size(75, 23);
            this.Naujas.TabIndex = 13;
            this.Naujas.Text = "Naujas";
            this.Naujas.UseVisualStyleBackColor = true;
            this.Naujas.Click += new System.EventHandler(this.Naujas_Click);
            // 
            // CloseForm
            // 
            this.CloseForm.Location = new System.Drawing.Point(346, 405);
            this.CloseForm.Name = "CloseForm";
            this.CloseForm.Size = new System.Drawing.Size(75, 23);
            this.CloseForm.TabIndex = 12;
            this.CloseForm.Text = "Uzdaryti";
            this.CloseForm.UseVisualStyleBackColor = true;
            this.CloseForm.Click += new System.EventHandler(this.CloseForm_Click);
            // 
            // StudentuGrupesGridView
            // 
            this.StudentuGrupesGridView.AllowUserToAddRows = false;
            this.StudentuGrupesGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.StudentuGrupesGridView.Location = new System.Drawing.Point(44, 67);
            this.StudentuGrupesGridView.Name = "StudentuGrupesGridView";
            this.StudentuGrupesGridView.Size = new System.Drawing.Size(712, 321);
            this.StudentuGrupesGridView.TabIndex = 11;
            this.StudentuGrupesGridView.DoubleClick += new System.EventHandler(this.StudentuGrupesGridView_DoubleClick);
            // 
            // PriskirtiDalykus
            // 
            this.PriskirtiDalykus.Location = new System.Drawing.Point(478, 22);
            this.PriskirtiDalykus.Name = "PriskirtiDalykus";
            this.PriskirtiDalykus.Size = new System.Drawing.Size(120, 23);
            this.PriskirtiDalykus.TabIndex = 17;
            this.PriskirtiDalykus.Text = "Priskirti dalykus";
            this.PriskirtiDalykus.UseVisualStyleBackColor = true;
            this.PriskirtiDalykus.Click += new System.EventHandler(this.PriskirtiDalykus_Click);
            // 
            // StudentuGrupes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.PriskirtiDalykus);
            this.Controls.Add(this.Istrinti);
            this.Controls.Add(this.PriskirtiStudentus);
            this.Controls.Add(this.Redaguoti);
            this.Controls.Add(this.Naujas);
            this.Controls.Add(this.CloseForm);
            this.Controls.Add(this.StudentuGrupesGridView);
            this.Name = "StudentuGrupes";
            this.Text = "Studentų Grupės";
            ((System.ComponentModel.ISupportInitialize)(this.StudentuGrupesGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Istrinti;
        private System.Windows.Forms.Button PriskirtiStudentus;
        private System.Windows.Forms.Button Redaguoti;
        private System.Windows.Forms.Button Naujas;
        private System.Windows.Forms.Button CloseForm;
        private System.Windows.Forms.DataGridView StudentuGrupesGridView;
        private System.Windows.Forms.Button PriskirtiDalykus;
    }
}