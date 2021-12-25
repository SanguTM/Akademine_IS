
namespace Akademine_IS
{
    partial class StudentoPazymiai
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
            this.DestStudentoPazymiaiGridView = new System.Windows.Forms.DataGridView();
            this.Naujas = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DestStudentoPazymiaiGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // DestStudentoPazymiaiGridView
            // 
            this.DestStudentoPazymiaiGridView.AllowUserToAddRows = false;
            this.DestStudentoPazymiaiGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DestStudentoPazymiaiGridView.Location = new System.Drawing.Point(44, 65);
            this.DestStudentoPazymiaiGridView.Name = "DestStudentoPazymiaiGridView";
            this.DestStudentoPazymiaiGridView.Size = new System.Drawing.Size(712, 321);
            this.DestStudentoPazymiaiGridView.TabIndex = 4;
            // 
            // Naujas
            // 
            this.Naujas.Location = new System.Drawing.Point(44, 33);
            this.Naujas.Name = "Naujas";
            this.Naujas.Size = new System.Drawing.Size(75, 23);
            this.Naujas.TabIndex = 5;
            this.Naujas.Text = "Naujas";
            this.Naujas.UseVisualStyleBackColor = true;
            this.Naujas.Click += new System.EventHandler(this.Naujas_Click);
            // 
            // StudentoPazymiai
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Naujas);
            this.Controls.Add(this.DestStudentoPazymiaiGridView);
            this.Name = "StudentoPazymiai";
            this.Text = "StudentoPazymiai";
            ((System.ComponentModel.ISupportInitialize)(this.DestStudentoPazymiaiGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DestStudentoPazymiaiGridView;
        private System.Windows.Forms.Button Naujas;
    }
}