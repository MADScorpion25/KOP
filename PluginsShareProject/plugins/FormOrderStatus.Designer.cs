namespace PluginsShareProject.plugins
{
    partial class FormOrderStatus
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
            this.dataGridViewStatuses = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStatuses)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewStatuses
            // 
            this.dataGridViewStatuses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewStatuses.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewStatuses.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewStatuses.Name = "dataGridViewStatuses";
            this.dataGridViewStatuses.RowHeadersWidth = 51;
            this.dataGridViewStatuses.RowTemplate.Height = 24;
            this.dataGridViewStatuses.Size = new System.Drawing.Size(446, 360);
            this.dataGridViewStatuses.TabIndex = 0;
            this.dataGridViewStatuses.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewStatuses_CellEndEdit);
            this.dataGridViewStatuses.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridViewStatuses_KeyDown);
            // 
            // FormOrderStatus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(446, 360);
            this.Controls.Add(this.dataGridViewStatuses);
            this.Name = "FormOrderStatus";
            this.Text = "FormOrderStatus";
            this.Load += new System.EventHandler(this.FormOrderStatus_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStatuses)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewStatuses;
    }
}