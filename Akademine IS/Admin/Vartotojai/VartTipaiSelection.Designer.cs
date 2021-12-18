
namespace Akademine_IS
{
    partial class VartTipaiSelection
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
            this.VartTipaiSelectionGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.VartTipaiSelectionGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // VartTipaiSelectionGridView
            // 
            this.VartTipaiSelectionGridView.AllowUserToAddRows = false;
            this.VartTipaiSelectionGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.VartTipaiSelectionGridView.Location = new System.Drawing.Point(44, 65);
            this.VartTipaiSelectionGridView.Name = "VartTipaiSelectionGridView";
            this.VartTipaiSelectionGridView.Size = new System.Drawing.Size(712, 321);
            this.VartTipaiSelectionGridView.TabIndex = 3;
            this.VartTipaiSelectionGridView.DoubleClick += new System.EventHandler(this.VartTipaiSelectionGridView_DoubleClick);
            // 
            // VartTipaiSelection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.VartTipaiSelectionGridView);
            this.Name = "VartTipaiSelection";
            this.Text = "VartTipaiSelection";
            ((System.ComponentModel.ISupportInitialize)(this.VartTipaiSelectionGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView VartTipaiSelectionGridView;
    }
}