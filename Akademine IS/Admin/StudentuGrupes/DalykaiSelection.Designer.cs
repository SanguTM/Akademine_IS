
namespace Akademine_IS
{
    partial class DalykaiSelection
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
            this.DalykaiSelectionGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.DalykaiSelectionGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // DalykaiSelectionGridView
            // 
            this.DalykaiSelectionGridView.AllowUserToAddRows = false;
            this.DalykaiSelectionGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DalykaiSelectionGridView.Location = new System.Drawing.Point(44, 65);
            this.DalykaiSelectionGridView.Name = "DalykaiSelectionGridView";
            this.DalykaiSelectionGridView.Size = new System.Drawing.Size(712, 321);
            this.DalykaiSelectionGridView.TabIndex = 5;
            this.DalykaiSelectionGridView.DoubleClick += new System.EventHandler(this.DalykaiSelectionGridView_DoubleClick);
            // 
            // DalykaiSelection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.DalykaiSelectionGridView);
            this.Name = "DalykaiSelection";
            this.Text = "DalykaiSelection";
            ((System.ComponentModel.ISupportInitialize)(this.DalykaiSelectionGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DalykaiSelectionGridView;
    }
}