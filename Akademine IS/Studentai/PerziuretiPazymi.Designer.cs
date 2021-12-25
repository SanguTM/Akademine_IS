
namespace Akademine_IS
{
    partial class PerziuretiPazymi
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
            this.StudPazymiaiGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.StudPazymiaiGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // StudPazymiaiGridView
            // 
            this.StudPazymiaiGridView.AllowUserToAddRows = false;
            this.StudPazymiaiGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.StudPazymiaiGridView.Location = new System.Drawing.Point(44, 65);
            this.StudPazymiaiGridView.Name = "StudPazymiaiGridView";
            this.StudPazymiaiGridView.Size = new System.Drawing.Size(712, 321);
            this.StudPazymiaiGridView.TabIndex = 4;
            // 
            // PerziuretiPazymi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.StudPazymiaiGridView);
            this.Name = "PerziuretiPazymi";
            this.Text = "PerziuretiPazymi";
            ((System.ComponentModel.ISupportInitialize)(this.StudPazymiaiGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView StudPazymiaiGridView;
    }
}