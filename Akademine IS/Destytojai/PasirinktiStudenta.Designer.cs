
namespace Akademine_IS
{
    partial class PasirinktiStudenta
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
            this.DestStudentaiGridView = new System.Windows.Forms.DataGridView();
            this.Pasirinkti = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DestStudentaiGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // DestStudentaiGridView
            // 
            this.DestStudentaiGridView.AllowUserToAddRows = false;
            this.DestStudentaiGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DestStudentaiGridView.Location = new System.Drawing.Point(44, 65);
            this.DestStudentaiGridView.Name = "DestStudentaiGridView";
            this.DestStudentaiGridView.Size = new System.Drawing.Size(712, 321);
            this.DestStudentaiGridView.TabIndex = 3;
            this.DestStudentaiGridView.DoubleClick += new System.EventHandler(this.DestStudentaiGridView_DoubleClick);
            // 
            // Pasirinkti
            // 
            this.Pasirinkti.Location = new System.Drawing.Point(44, 24);
            this.Pasirinkti.Name = "Pasirinkti";
            this.Pasirinkti.Size = new System.Drawing.Size(75, 23);
            this.Pasirinkti.TabIndex = 4;
            this.Pasirinkti.Text = "Pasirinkti";
            this.Pasirinkti.UseVisualStyleBackColor = true;
            this.Pasirinkti.Click += new System.EventHandler(this.Pasirinkti_Click);
            // 
            // PasirinktiStudenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Pasirinkti);
            this.Controls.Add(this.DestStudentaiGridView);
            this.Name = "PasirinktiStudenta";
            this.Text = "PasirinktiStudenta";
            ((System.ComponentModel.ISupportInitialize)(this.DestStudentaiGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DestStudentaiGridView;
        private System.Windows.Forms.Button Pasirinkti;
    }
}