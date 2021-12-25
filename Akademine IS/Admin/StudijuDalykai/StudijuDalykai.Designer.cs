
namespace Akademine_IS
{
    partial class StudijuDalykai
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
            this.Naujas = new System.Windows.Forms.Button();
            this.CloseForm = new System.Windows.Forms.Button();
            this.StudijuDalykaiGridView = new System.Windows.Forms.DataGridView();
            this.PriskirtiDestytojus = new System.Windows.Forms.Button();
            this.Istrinti = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.StudijuDalykaiGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // Redaguoti
            // 
            this.Redaguoti.Location = new System.Drawing.Point(171, 22);
            this.Redaguoti.Name = "Redaguoti";
            this.Redaguoti.Size = new System.Drawing.Size(75, 23);
            this.Redaguoti.TabIndex = 8;
            this.Redaguoti.Text = "Redaguoti";
            this.Redaguoti.UseVisualStyleBackColor = true;
            this.Redaguoti.Click += new System.EventHandler(this.Redaguoti_Click);
            // 
            // Naujas
            // 
            this.Naujas.Location = new System.Drawing.Point(44, 22);
            this.Naujas.Name = "Naujas";
            this.Naujas.Size = new System.Drawing.Size(75, 23);
            this.Naujas.TabIndex = 7;
            this.Naujas.Text = "Naujas";
            this.Naujas.UseVisualStyleBackColor = true;
            this.Naujas.Click += new System.EventHandler(this.Naujas_Click);
            // 
            // CloseForm
            // 
            this.CloseForm.Location = new System.Drawing.Point(346, 405);
            this.CloseForm.Name = "CloseForm";
            this.CloseForm.Size = new System.Drawing.Size(75, 23);
            this.CloseForm.TabIndex = 6;
            this.CloseForm.Text = "Uzdaryti";
            this.CloseForm.UseVisualStyleBackColor = true;
            this.CloseForm.Click += new System.EventHandler(this.CloseForm_Click);
            // 
            // StudijuDalykaiGridView
            // 
            this.StudijuDalykaiGridView.AllowUserToAddRows = false;
            this.StudijuDalykaiGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.StudijuDalykaiGridView.Location = new System.Drawing.Point(44, 67);
            this.StudijuDalykaiGridView.Name = "StudijuDalykaiGridView";
            this.StudijuDalykaiGridView.Size = new System.Drawing.Size(712, 321);
            this.StudijuDalykaiGridView.TabIndex = 5;
            this.StudijuDalykaiGridView.DoubleClick += new System.EventHandler(this.StudijuDalykaiGridView_DoubleClick);
            // 
            // PriskirtiDestytojus
            // 
            this.PriskirtiDestytojus.Location = new System.Drawing.Point(636, 22);
            this.PriskirtiDestytojus.Name = "PriskirtiDestytojus";
            this.PriskirtiDestytojus.Size = new System.Drawing.Size(120, 23);
            this.PriskirtiDestytojus.TabIndex = 9;
            this.PriskirtiDestytojus.Text = "Priskirti destytojus";
            this.PriskirtiDestytojus.UseVisualStyleBackColor = true;
            this.PriskirtiDestytojus.Click += new System.EventHandler(this.PriskirtiDestytojus_Click);
            // 
            // Istrinti
            // 
            this.Istrinti.Location = new System.Drawing.Point(304, 22);
            this.Istrinti.Name = "Istrinti";
            this.Istrinti.Size = new System.Drawing.Size(75, 23);
            this.Istrinti.TabIndex = 10;
            this.Istrinti.Text = "Ištrinti";
            this.Istrinti.UseVisualStyleBackColor = true;
            this.Istrinti.Click += new System.EventHandler(this.Istrinti_Click);
            // 
            // StudijuDalykai
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Istrinti);
            this.Controls.Add(this.PriskirtiDestytojus);
            this.Controls.Add(this.Redaguoti);
            this.Controls.Add(this.Naujas);
            this.Controls.Add(this.CloseForm);
            this.Controls.Add(this.StudijuDalykaiGridView);
            this.Name = "StudijuDalykai";
            this.Text = "StudijuDalykai";
            ((System.ComponentModel.ISupportInitialize)(this.StudijuDalykaiGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Redaguoti;
        private System.Windows.Forms.Button Naujas;
        private System.Windows.Forms.Button CloseForm;
        private System.Windows.Forms.DataGridView StudijuDalykaiGridView;
        private System.Windows.Forms.Button PriskirtiDestytojus;
        private System.Windows.Forms.Button Istrinti;
    }
}