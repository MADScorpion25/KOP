
namespace UserControlsTest
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonClearComboBox = new System.Windows.Forms.Button();
            this.userControlListBox = new VisualComponents.UserControlListBox();
            this.userControlComboBox = new VisualComponents.UserControlComboBox();
            this.buttonGetObject = new System.Windows.Forms.Button();
            this.labelObjectInfo = new System.Windows.Forms.Label();
            this.labelComboBox = new System.Windows.Forms.Label();
            this.buttonGetFromComboBox = new System.Windows.Forms.Button();
            this.labelEvents = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonClearComboBox
            // 
            this.buttonClearComboBox.Location = new System.Drawing.Point(392, 113);
            this.buttonClearComboBox.Name = "buttonClearComboBox";
            this.buttonClearComboBox.Size = new System.Drawing.Size(103, 23);
            this.buttonClearComboBox.TabIndex = 2;
            this.buttonClearComboBox.Text = "Очистить";
            this.buttonClearComboBox.UseVisualStyleBackColor = true;
            this.buttonClearComboBox.Click += new System.EventHandler(this.buttonClearComboBox_Click);
            // 
            // userControlListBox
            // 
            this.userControlListBox.Location = new System.Drawing.Point(3, 2);
            this.userControlListBox.Name = "userControlListBox";
            this.userControlListBox.SelectedRowIndex = -1;
            this.userControlListBox.Size = new System.Drawing.Size(287, 180);
            this.userControlListBox.TabIndex = 1;
            // 
            // userControlComboBox
            // 
            this.userControlComboBox.Location = new System.Drawing.Point(255, -25);
            this.userControlComboBox.Name = "userControlComboBox";
            this.userControlComboBox.SelectedValue = "";
            this.userControlComboBox.Size = new System.Drawing.Size(408, 141);
            this.userControlComboBox.TabIndex = 0;
            // 
            // buttonGetObject
            // 
            this.buttonGetObject.Location = new System.Drawing.Point(85, 188);
            this.buttonGetObject.Name = "buttonGetObject";
            this.buttonGetObject.Size = new System.Drawing.Size(94, 23);
            this.buttonGetObject.TabIndex = 3;
            this.buttonGetObject.Text = "Извлечь объект";
            this.buttonGetObject.UseVisualStyleBackColor = true;
            this.buttonGetObject.Click += new System.EventHandler(this.buttonGetObject_Click);
            // 
            // labelObjectInfo
            // 
            this.labelObjectInfo.AutoSize = true;
            this.labelObjectInfo.Location = new System.Drawing.Point(29, 254);
            this.labelObjectInfo.Name = "labelObjectInfo";
            this.labelObjectInfo.Size = new System.Drawing.Size(46, 17);
            this.labelObjectInfo.TabIndex = 4;
            this.labelObjectInfo.Text = "label1";
            // 
            // labelComboBox
            // 
            this.labelComboBox.AutoSize = true;
            this.labelComboBox.Location = new System.Drawing.Point(682, 71);
            this.labelComboBox.Name = "labelComboBox";
            this.labelComboBox.Size = new System.Drawing.Size(46, 17);
            this.labelComboBox.TabIndex = 6;
            this.labelComboBox.Text = "label1";
            // 
            // buttonGetFromComboBox
            // 
            this.buttonGetFromComboBox.Location = new System.Drawing.Point(532, 68);
            this.buttonGetFromComboBox.Name = "buttonGetFromComboBox";
            this.buttonGetFromComboBox.Size = new System.Drawing.Size(94, 23);
            this.buttonGetFromComboBox.TabIndex = 5;
            this.buttonGetFromComboBox.Text = "Извлечь объект";
            this.buttonGetFromComboBox.UseVisualStyleBackColor = true;
            this.buttonGetFromComboBox.Click += new System.EventHandler(this.buttonGetFromComboBox_Click);
            // 
            // labelEvents
            // 
            this.labelEvents.AutoSize = true;
            this.labelEvents.Location = new System.Drawing.Point(700, 203);
            this.labelEvents.Name = "labelEvents";
            this.labelEvents.Size = new System.Drawing.Size(16, 17);
            this.labelEvents.TabIndex = 7;
            this.labelEvents.Text = "0";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.labelEvents);
            this.Controls.Add(this.labelComboBox);
            this.Controls.Add(this.buttonGetFromComboBox);
            this.Controls.Add(this.labelObjectInfo);
            this.Controls.Add(this.buttonGetObject);
            this.Controls.Add(this.buttonClearComboBox);
            this.Controls.Add(this.userControlListBox);
            this.Controls.Add(this.userControlComboBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private VisualComponents.UserControlComboBox userControlComboBox;
        private VisualComponents.UserControlListBox userControlListBox;
        private System.Windows.Forms.Button buttonClearComboBox;
        private System.Windows.Forms.Button buttonGetObject;
        private System.Windows.Forms.Label labelObjectInfo;
        private System.Windows.Forms.Label labelComboBox;
        private System.Windows.Forms.Button buttonGetFromComboBox;
        private System.Windows.Forms.Label labelEvents;
    }
}

