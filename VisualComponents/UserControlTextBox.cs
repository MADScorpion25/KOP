using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace VisualComponents
{
    public partial class UserControlTextBox : UserControl
    {
        public Regex Pattern { get; set; }

        private event EventHandler _changeTextBoxValue;

        public event EventHandler SetChangeValueEvent
        {
            add { _changeTextBoxValue += value; }
            remove { _changeTextBoxValue -= value; }
        }

        public string Content
        {
            get => Regex.IsMatch(textBox.Text, Pattern.ToString()) ? textBox.Text : throw new Exception("String is not match regex pattern");
            set
            {
                if (Pattern != null && Regex.IsMatch(textBox.Text, Pattern.ToString()))
                {
                    textBox.Text = value;
                }
                else
                {
                    throw new Exception("String is not match regex pattern or pattern is empty");
                }
            }
        }

        public UserControlTextBox()
        {
            InitializeComponent();
            textBox.TextChanged += (sender, e) =>
            {
                _changeTextBoxValue?.Invoke(sender, e);
            };
        }

        public void SetToolTip(string text)
        {
            new ToolTip().SetToolTip(textBox, text);
        }

    }
}
