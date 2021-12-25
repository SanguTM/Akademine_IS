
namespace Akademine_IS
{
    partial class PasirinktiStudentoDalyka
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
            this.StudDalykaiGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.StudDalykaiGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // StudDalykaiGridView
            // 
            this.StudDalykaiGridView.AllowUserToAddRows = false;
            this.StudDalykaiGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.StudDalykaiGridView.Location = new System.Drawing.Point(44, 65);
            this.StudDalykaiGridView.Name = "StudDalykaiGridView";
            this.StudDalykaiGridView.Size = new System.Drawing.Size(712, 321);
            this.StudDalykaiGridView.TabIndex = 3;
            this.StudDalykaiGridView.DoubleClick += new System.EventHandler(this.StudDalykaiGridView_DoubleClick);
            // 
            // PasirinktiStudentoDalyka
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.StudDalykaiGridView);
            this.Name = "PasirinktiStudentoDalyka";
            this.Text = "PasirinktiStudentoDalyka";
            ((System.ComponentModel.ISupportInitialize)(this.StudDalykaiGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView StudDalykaiGridView;
    }
}