
namespace Akademine_IS
{
    partial class PasirinktiStudentuGrupe
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
            this.DestStudentuGrupesGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.DestStudentuGrupesGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // DestStudentuGrupesGridView
            // 
            this.DestStudentuGrupesGridView.AllowUserToAddRows = false;
            this.DestStudentuGrupesGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DestStudentuGrupesGridView.Location = new System.Drawing.Point(44, 65);
            this.DestStudentuGrupesGridView.Name = "DestStudentuGrupesGridView";
            this.DestStudentuGrupesGridView.Size = new System.Drawing.Size(712, 321);
            this.DestStudentuGrupesGridView.TabIndex = 3;
            this.DestStudentuGrupesGridView.DoubleClick += new System.EventHandler(this.DestStudentuGrupesGridView_DoubleClick);
            // 
            // PasirinktiStudentuGrupe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.DestStudentuGrupesGridView);
            this.Name = "PasirinktiStudentuGrupe";
            this.Text = "PasirinktiStudentuGrupe";
            ((System.ComponentModel.ISupportInitialize)(this.DestStudentuGrupesGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DestStudentuGrupesGridView;
    }
}