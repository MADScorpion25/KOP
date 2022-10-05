using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xceed.Document.NET;
using Xceed.Words.NET;

namespace UnvisualComponents
{
    public class TextDocument
    {
        public void CreateWordChart(string path, string documentName, string[] paragraphs)
        {
            if (string.IsNullOrEmpty(path) || string.IsNullOrEmpty(documentName) || paragraphs.Length == 0)
            {
                throw new Exception("Input data has empty fields");
            }
           
            using (var document = DocX.Create(path))
            {
                document.InsertParagraph(documentName)
                    .FontSize(20)
                    .Alignment = Alignment.center;
                foreach (var par in paragraphs)
                {
                    document.InsertParagraph(par)
                        .Bold()
                        .FontSize(18);
                }
                document.Save();
            }
        }
    }
}
