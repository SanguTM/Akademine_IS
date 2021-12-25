
namespace Akademine_IS
{
    partial class StudentaiSelection
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
            this.AsmSelectionGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.AsmSelectionGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // AsmSelectionGridView
            // 
            this.AsmSelectionGridView.AllowUserToAddRows = false;
            this.AsmSelectionGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.AsmSelectionGridView.Location = new System.Drawing.Point(44, 65);
            this.AsmSelectionGridView.Name = "AsmSelectionGridView";
            this.AsmSelectionGridView.Size = new System.Drawing.Size(712, 321);
            this.AsmSelectionGridView.TabIndex = 4;
            this.AsmSelectionGridView.DoubleClick += new System.EventHandler(this.AsmSelectionGridView_DoubleClick);
            // 
            // StudentaiSelection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.AsmSelectionGridView);
            this.Name = "StudentaiSelection";
            this.Text = "StudentaiSelection";
            ((System.ComponentModel.ISupportInitialize)(this.AsmSelectionGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView AsmSelectionGridView;
    }
}