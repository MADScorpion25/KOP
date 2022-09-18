using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace VisualComponents
{
    public partial class UserControlListBox : UserControl
    {
        private string layout;
        private char beginSeparator, endSeparator;
        private List<string> fieldNames;
        public int SelectedRowIndex
        {
            get => listBox.SelectedIndex;
            set {
                if (value >= -1 && value < listBox.Items.Count)
                {
                    listBox.SelectedIndex = value;
                }
            }
        }
        public UserControlListBox()
        {
            InitializeComponent();
            fieldNames = new List<string>();
        }
        public void SetVisualLayout(string layout, char beginSeparator, char endSeparator)
        {
            this.layout = layout;
            this.beginSeparator = beginSeparator;
            this.endSeparator = endSeparator;
            foreach(string subStr in layout.Split(beginSeparator))
            {
                string[] endSeparate = subStr.Split(endSeparator);
                if(endSeparate.Length == 2)
                {
                    fieldNames.Add(endSeparate[0]);
                }
            }
        }

        public void SetListData<T>(List<T> list)
        {
            foreach(T obj in list){
                string rowString = layout;
                foreach(string fieldName in fieldNames)
                {
                    Type myType = typeof(T);
                    var field = myType.GetProperty(fieldName);
                    var fieldValue = field?.GetValue(obj);

                    if(fieldValue != null)
                    rowString = rowString.Replace(beginSeparator + fieldName + endSeparator, fieldValue.ToString());
                }
                listBox.Items.Add(rowString);
            }
        }

        public T GetSelectedObject<T>() where T : class, new()
        {
            if (fieldNames.Count == 0 || SelectedRowIndex <= -1 || SelectedRowIndex >= listBox.Items.Count) return null;
            T obj = Activator.CreateInstance<T>();
            List<string> otherTemplateText = new List<string>();
            string nextSeparated = layout;

            foreach(string field in fieldNames)
            {
                string separator = beginSeparator + field + endSeparator;
                string[] separateRes = nextSeparated.Split(new string[] { separator }, StringSplitOptions.None);
                otherTemplateText.Add(separateRes[0]);
                nextSeparated = separateRes[1];
            }
            
            if(!string.IsNullOrEmpty(nextSeparated))
            otherTemplateText.Add(nextSeparated);
            string[] fieldValues = listBox.SelectedItem.ToString().Split(otherTemplateText.ToArray(), StringSplitOptions.RemoveEmptyEntries);

            for(int i = 0; i < fieldValues.Length; i++)
            {
                Type myType = typeof(T);
                var field = myType.GetProperty(fieldNames.ElementAt(i));
                Type propertyType = field.PropertyType;
                field.SetValue(obj, Convert.ChangeType(fieldValues.ElementAt(i), propertyType));
            }

            return obj;
        }
    }
}
