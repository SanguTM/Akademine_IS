
namespace Akademine_IS
{
    partial class PasirinktiDalyka
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
            this.DestDalykaiGridView = new System.Windows.Forms.DataGridView();
            this.Pasirinkti = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DestDalykaiGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // DestDalykaiGridView
            // 
            this.DestDalykaiGridView.AllowUserToAddRows = false;
            this.DestDalykaiGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DestDalykaiGridView.Location = new System.Drawing.Point(44, 65);
            this.DestDalykaiGridView.Name = "DestDalykaiGridView";
            this.DestDalykaiGridView.Size = new System.Drawing.Size(712, 321);
            this.DestDalykaiGridView.TabIndex = 2;
            this.DestDalykaiGridView.DoubleClick += new System.EventHandler(this.DestDalykaiGridView_DoubleClick);
            // 
            // Pasirinkti
            // 
            this.Pasirinkti.Location = new System.Drawing.Point(44, 26);
            this.Pasirinkti.Name = "Pasirinkti";
            this.Pasirinkti.Size = new System.Drawing.Size(75, 23);
            this.Pasirinkti.TabIndex = 3;
            this.Pasirinkti.Text = "Pasirinkti";
            this.Pasirinkti.UseVisualStyleBackColor = true;
            this.Pasirinkti.Click += new System.EventHandler(this.Pasirinkti_Click);
            // 
            // PasirinktiDalyka
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Pasirinkti);
            this.Controls.Add(this.DestDalykaiGridView);
            this.Name = "PasirinktiDalyka";
            this.Text = "PasirinktiDalyka";
            ((System.ComponentModel.ISupportInitialize)(this.DestDalykaiGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DestDalykaiGridView;
        private System.Windows.Forms.Button Pasirinkti;
    }
}