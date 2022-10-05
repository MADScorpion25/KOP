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
        public void CreateWordChart(string path, string title, string[] paragraphs)
        {
            if (string.IsNullOrEmpty(path) || string.IsNullOrEmpty(title) || paragraphs.Length == 0)
            {
                throw new Exception("Пустые входные данные");
            }
           
            using (var document = DocX.Create(path))
            {
                document.InsertParagraph(title)
                    .FontSize(20)
                    .Bold()
                    .Alignment = Alignment.center;
                foreach (var par in paragraphs)
                {
                    document.InsertParagraph(par)
                        .FontSize(18);
                }
                document.Save();
            }
        }
    }
}
