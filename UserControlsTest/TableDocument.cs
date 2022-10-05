using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Xceed.Document.NET;
using Xceed.Words.NET;

namespace UnvisualComponents
{
    public class TableDocument<T>
    {
        public void CreateTableDocument(string path, string documentName, Dictionary<string, int[]> mergeCellsInfo, int[] columnWidth, string[] dataPropertiesPattern, T[] objectsData)
        {
            if(string.IsNullOrEmpty(path) || string.IsNullOrEmpty(documentName) || mergeCellsInfo.Count < 1 || columnWidth.Length < 1 || dataPropertiesPattern.Length > 1 || objectsData.Length < 1)
            {
                throw new Exception("Input data has empty fields");
            }

            Dictionary<int, int> checkerValidate = new Dictionary<int, int>();
            foreach(var info in mergeCellsInfo.Values)
            {
                foreach(var num in info)
                {
                    int clearVal = num % columnWidth.Length;
                    if (!checkerValidate.ContainsKey(num))
                    {
                        checkerValidate.Add(clearVal, 0);
                        continue;
                    }
                    if (checkerValidate[clearVal] + 1 > 1) throw new Exception("Uncorrect merge cells data");
                    checkerValidate.Add(clearVal, checkerValidate[clearVal] + 1);
                }
            }

            using (var document = DocX.Create(path))
            {
                document.InsertParagraph(documentName)
                    .Bold()
                    .FontSize(20);
                Table table = document.AddTable(objectsData.Length + 2, columnWidth.Length);
                // располагаем таблицу по центру
                table.Alignment = Alignment.center;
                // меняем стандартный дизайн таблицы
                table.Design = TableDesign.TableGrid;
                Row headerRow = table.Rows[0];
                foreach (var pair in mergeCellsInfo)
                {
                    Row underRow = table.Rows[1];
                    if (pair.Value[0] / columnWidth.Length >= 1)
                    {
                        Cell cell = underRow.Cells[pair.Value[0] % columnWidth.Length];
                        cell.Paragraphs[0].Append(pair.Key);
                        cell.Width = columnWidth[pair.Value[0] % columnWidth.Length];
                        continue;
                    }
                    else if (pair.Value.Length == 1)
                    {
                        Cell cell = headerRow.Cells[pair.Value[0]];
                        cell.Paragraphs[0].Append(pair.Key);
                        table.MergeCellsInColumn(pair.Value[0], 0, 1);
                        continue;
                    }
                    
                    
                }
                foreach (var pair in mergeCellsInfo)
                {

                    if (pair.Value.Length > 1 && pair.Value[0] / columnWidth.Length >= 1)
                    {
                        Cell[] cells = new Cell[pair.Value[1] - pair.Value[0] + 1];
                        for (int i = 0; i < cells.Length; i++)
                        {
                            cells[i] = headerRow.Cells[i + pair.Value[0]];
                        }
                        MergeCellsInRow(pair.Key, 1, pair.Value[0], pair.Value[1], table);
                    }
                    else if(pair.Value.Length > 1)
                    {
                        Cell[] cells = new Cell[pair.Value[1] - pair.Value[0] + 1];
                        for (int i = 0; i < cells.Length; i++)
                        {
                            cells[i] = headerRow.Cells[i + pair.Value[0]];
                        }
                        MergeCellsInRow(pair.Key, 0, pair.Value[0], pair.Value[1], table);
                    }
                }
                for (int i = 0; i < objectsData.Length; i++)
                {
                    Row row = table.Rows[i + 2];
                    for (int j = 0; j < dataPropertiesPattern.Length; j++)
                    {
                        Type myType = typeof(T);
                        var field = myType.GetProperty(dataPropertiesPattern[j]);
                        var fieldValue = field?.GetValue(objectsData[i]);

                        Cell cell = row.Cells[j];
                        cell.Paragraphs[0].Append(fieldValue.ToString());
                        row.Cells.Add(cell);
                        
                    }
                }
                document.InsertTable(table);
                document.Save();
            }
        }
        private void MergeCellsInRow(string content, int colIndex, int startIndex, int endIndex, Table table)
        {
            table.Rows[colIndex].Cells[startIndex].RemoveParagraphAt(0);
            table.Rows[colIndex].Cells[startIndex].InsertParagraph(content);
            table.Rows[colIndex].MergeCells(startIndex, endIndex);
        }
    }
}
