using NonVisualComponents.models;
using System;
using System.Collections.Generic;
using Xceed.Document.NET;
using Xceed.Words.NET;

namespace UnvisualComponents
{
    public class TableDocument<T>
    {
        public void CreateTableDocument(string path, string title, List<CellInfo> cellsOrHorizintalMergeInfo, int[] columnWidth, string[] dataColumnsPropertiesPattern, T[] objectsData)
        {
            if(string.IsNullOrEmpty(path) || string.IsNullOrEmpty(title) || cellsOrHorizintalMergeInfo.Count < 1 || columnWidth.Length < 1 || dataColumnsPropertiesPattern.Length < 1 || objectsData.Length < 1 
                || columnWidth.Length != dataColumnsPropertiesPattern.Length || dataColumnsPropertiesPattern.Length != objectsData.Length)
            {
                throw new Exception("Некорректные или пустые данные");
            }

            using (var document = DocX.Create(path))
            {
                document.InsertParagraph(title)
                    .Bold()
                    .FontSize(20);
                Table table = document.AddTable(objectsData.Length + 2, columnWidth.Length);
                table.Alignment = Alignment.center;
                table.Design = TableDesign.TableGrid;
              

                HashSet<int> mergedHorizontal = new HashSet<int>();
                foreach(var pair in cellsOrHorizintalMergeInfo)
                {
                    if(pair.HorizontalMerged)
                    {
                        for(int i = pair.StartIndex; i <= pair.EndIndex; i++)
                        {
                            mergedHorizontal.Add(i % columnWidth.Length);
                        }
                    }
                }

                FindVerticalMergeOrSimple(table, cellsOrHorizintalMergeInfo, columnWidth, mergedHorizontal);

                MergeHorizontal(table, cellsOrHorizintalMergeInfo, columnWidth);

                AddTableData(table, objectsData, dataColumnsPropertiesPattern);

                document.InsertTable(table);
                document.Save();
            }
        }
        private void MergeCellsInRow(string content, int rowIndex, int startIndex, int endIndex, Table table)
        {
            table.Rows[rowIndex].Cells[startIndex].RemoveParagraphAt(0);
            table.Rows[rowIndex].Cells[startIndex].InsertParagraph(content);
            table.Rows[rowIndex].MergeCells(startIndex, endIndex);
        }

        private void MergeHorizontal(Table table, List<CellInfo> cellsOrHorizintalMergeInfo, int[] columnWidth)
        {
            foreach (var cellInfo in cellsOrHorizintalMergeInfo)
            {

                if (cellInfo.HorizontalMerged && cellInfo.Index / columnWidth.Length >= 1)
                {
                    MergeCellsInRow(cellInfo.Data, 1, cellInfo.StartIndex % columnWidth.Length, cellInfo.EndIndex % columnWidth.Length, table);
                }
                else if (cellInfo.HorizontalMerged)
                {
                    MergeCellsInRow(cellInfo.Data, 0, cellInfo.StartIndex % columnWidth.Length, cellInfo.EndIndex % columnWidth.Length, table);
                }
            }
        }

        private void FindVerticalMergeOrSimple(Table table, List<CellInfo> cellsOrHorizintalMergeInfo, int[] columnWidth, HashSet<int> mergedHorizontal)
        {
            Row headerRow = table.Rows[0];
            Row underHeaderRow = table.Rows[1];
            foreach (var cellInfo in cellsOrHorizintalMergeInfo)
            {
                int column = cellInfo.Index % columnWidth.Length;
                Cell cell = headerRow.Cells[column];
                if (!cellInfo.HorizontalMerged && !mergedHorizontal.Contains(column))
                {
                    cell.Paragraphs[0].Append(cellInfo.Data);
                    cell.Width = columnWidth[column];
                    table.MergeCellsInColumn(column, 0, 1);
                    continue;
                }
                else if (!cellInfo.HorizontalMerged && mergedHorizontal.Contains(column) && cellInfo.Index / columnWidth.Length > 0)
                {
                    cell = underHeaderRow.Cells[column];
                    cell.Paragraphs[0].Append(cellInfo.Data);
                    cell.Width = columnWidth[column];
                }
                else if (!cellInfo.HorizontalMerged && mergedHorizontal.Contains(column))
                {
                    cell.Paragraphs[0].Append(cellInfo.Data);
                    cell.Width = columnWidth[column];
                }
            }
        }
        private void AddTableData(Table table, T[] objectsData, string[] dataColumnsPropertiesPattern)
        {
            for (int i = 0; i < objectsData.Length; i++)
            {
                Row row = table.Rows[i + 2];
                for (int j = 0; j < dataColumnsPropertiesPattern.Length; j++)
                {
                    Type myType = typeof(T);
                    var field = myType.GetProperty(dataColumnsPropertiesPattern[j]);
                    var fieldValue = field?.GetValue(objectsData[i]);

                    Cell cell = row.Cells[j];
                    cell.Paragraphs[0].Append(fieldValue.ToString());
                    row.Cells.Add(cell);

                }
            }
        }
    }
}
