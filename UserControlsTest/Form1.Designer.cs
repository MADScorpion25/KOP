
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
            this.buttonGetObject = new System.Windows.Forms.Button();
            this.labelObjectInfo = new System.Windows.Forms.Label();
            this.labelComboBox = new System.Windows.Forms.Label();
            this.buttonGetFromComboBox = new System.Windows.Forms.Button();
            this.labelEvents = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.buttonGetFromTextBox = new System.Windows.Forms.Button();
            this.labelForTextBox = new System.Windows.Forms.Label();
            this.buttonSetComboBoxItem = new System.Windows.Forms.Button();
            this.textBoxForComboBoxItem = new System.Windows.Forms.TextBox();
            this.userControlListBox = new VisualComponents.UserControlListBox();
            this.userControlTextBox = new VisualComponents.UserControlTextBox();
            this.userControlComboBox1 = new VisualComponents.UserControlComboBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonClearComboBox
            // 
            this.buttonClearComboBox.Location = new System.Drawing.Point(12, 122);
            this.buttonClearComboBox.Name = "buttonClearComboBox";
            this.buttonClearComboBox.Size = new System.Drawing.Size(103, 23);
            this.buttonClearComboBox.TabIndex = 2;
            this.buttonClearComboBox.Text = "Очистить";
            this.buttonClearComboBox.UseVisualStyleBackColor = true;
            this.buttonClearComboBox.Click += new System.EventHandler(this.buttonClearComboBox_Click);
            // 
            // buttonGetObject
            // 
            this.buttonGetObject.Location = new System.Drawing.Point(94, 278);
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
            this.labelObjectInfo.Location = new System.Drawing.Point(91, 311);
            this.labelObjectInfo.Name = "labelObjectInfo";
            this.labelObjectInfo.Size = new System.Drawing.Size(46, 17);
            this.labelObjectInfo.TabIndex = 4;
            this.labelObjectInfo.Text = "label1";
            // 
            // labelComboBox
            // 
            this.labelComboBox.AutoSize = true;
            this.labelComboBox.Location = new System.Drawing.Point(127, 82);
            this.labelComboBox.Name = "labelComboBox";
            this.labelComboBox.Size = new System.Drawing.Size(46, 17);
            this.labelComboBox.TabIndex = 6;
            this.labelComboBox.Text = "label1";
            // 
            // buttonGetFromComboBox
            // 
            this.buttonGetFromComboBox.Location = new System.Drawing.Point(12, 79);
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
            this.labelEvents.Location = new System.Drawing.Point(328, 11);
            this.labelEvents.Name = "labelEvents";
            this.labelEvents.Size = new System.Drawing.Size(16, 17);
            this.labelEvents.TabIndex = 7;
            this.labelEvents.Text = "0";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.labelObjectInfo);
            this.panel1.Controls.Add(this.userControlListBox);
            this.panel1.Location = new System.Drawing.Point(-1, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(422, 448);
            this.panel1.TabIndex = 9;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.textBoxForComboBoxItem);
            this.panel2.Controls.Add(this.buttonSetComboBoxItem);
            this.panel2.Controls.Add(this.labelComboBox);
            this.panel2.Controls.Add(this.labelEvents);
            this.panel2.Controls.Add(this.buttonClearComboBox);
            this.panel2.Controls.Add(this.buttonGetFromComboBox);
            this.panel2.Controls.Add(this.userControlComboBox1);
            this.panel2.Location = new System.Drawing.Point(427, 1);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(361, 163);
            this.panel2.TabIndex = 10;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.labelForTextBox);
            this.panel3.Controls.Add(this.buttonGetFromTextBox);
            this.panel3.Controls.Add(this.userControlTextBox);
            this.panel3.Location = new System.Drawing.Point(427, 170);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(361, 279);
            this.panel3.TabIndex = 11;
            // 
            // buttonGetFromTextBox
            // 
            this.buttonGetFromTextBox.Location = new System.Drawing.Point(63, 136);
            this.buttonGetFromTextBox.Name = "buttonGetFromTextBox";
            this.buttonGetFromTextBox.Size = new System.Drawing.Size(94, 23);
            this.buttonGetFromTextBox.TabIndex = 8;
            this.buttonGetFromTextBox.Text = "Извлечь объект";
            this.buttonGetFromTextBox.UseVisualStyleBackColor = true;
            this.buttonGetFromTextBox.Click += new System.EventHandler(this.buttonGetFromTextBox_Click);
            // 
            // labelForTextBox
            // 
            this.labelForTextBox.AutoSize = true;
            this.labelForTextBox.Location = new System.Drawing.Point(197, 139);
            this.labelForTextBox.Name = "labelForTextBox";
            this.labelForTextBox.Size = new System.Drawing.Size(46, 17);
            this.labelForTextBox.TabIndex = 8;
            this.labelForTextBox.Text = "label1";
            // 
            // buttonSetComboBoxItem
            // 
            this.buttonSetComboBoxItem.Location = new System.Drawing.Point(223, 122);
            this.buttonSetComboBoxItem.Name = "buttonSetComboBoxItem";
            this.buttonSetComboBoxItem.Size = new System.Drawing.Size(94, 23);
            this.buttonSetComboBoxItem.TabIndex = 8;
            this.buttonSetComboBoxItem.Text = "Установить";
            this.buttonSetComboBoxItem.UseVisualStyleBackColor = true;
            this.buttonSetComboBoxItem.Click += new System.EventHandler(this.buttonSetComboBoxItem_Click);
            // 
            // textBoxForComboBoxItem
            // 
            this.textBoxForComboBoxItem.Location = new System.Drawing.Point(223, 82);
            this.textBoxForComboBoxItem.Name = "textBoxForComboBoxItem";
            this.textBoxForComboBoxItem.Size = new System.Drawing.Size(100, 22);
            this.textBoxForComboBoxItem.TabIndex = 9;
            // 
            // userControlListBox
            // 
            this.userControlListBox.Location = new System.Drawing.Point(24, 45);
            this.userControlListBox.Name = "userControlListBox";
            this.userControlListBox.SelectedRowIndex = -1;
            this.userControlListBox.Size = new System.Drawing.Size(371, 225);
            this.userControlListBox.TabIndex = 1;
            // 
            // userControlTextBox
            // 
            this.userControlTextBox.Location = new System.Drawing.Point(54, 71);
            this.userControlTextBox.Name = "userControlTextBox";
            this.userControlTextBox.Pattern = null;
            this.userControlTextBox.Size = new System.Drawing.Size(198, 30);
            this.userControlTextBox.TabIndex = 8;
            // 
            // userControlComboBox1
            // 
            this.userControlComboBox1.Location = new System.Drawing.Point(44, 11);
            this.userControlComboBox1.Name = "userControlComboBox1";
            this.userControlComboBox1.SelectedValue = "";
            this.userControlComboBox1.Size = new System.Drawing.Size(129, 34);
            this.userControlComboBox1.TabIndex = 7;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(791, 450);
            this.Controls.Add(this.buttonGetObject);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private VisualComponents.UserControlListBox userControlListBox;
        private System.Windows.Forms.Button buttonClearComboBox;
        private System.Windows.Forms.Button buttonGetObject;
        private System.Windows.Forms.Label labelObjectInfo;
        private System.Windows.Forms.Label labelComboBox;
        private System.Windows.Forms.Button buttonGetFromComboBox;
        private System.Windows.Forms.Label labelEvents;
        private VisualComponents.UserControlTextBox userControlTextBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private VisualComponents.UserControlComboBox userControlComboBox1;
        private System.Windows.Forms.Label labelForTextBox;
        private System.Windows.Forms.Button buttonGetFromTextBox;
        private System.Windows.Forms.TextBox textBoxForComboBoxItem;
        private System.Windows.Forms.Button buttonSetComboBoxItem;
    }
}

