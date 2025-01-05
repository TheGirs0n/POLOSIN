using ClosedXML.Excel;
using Microsoft.Win32;
using POLOSIN_3_PR.Async_Methods;
using System.Data;
using System.Windows;

namespace POLOSIN_3_PR.Math_Folder
{
    public class SaveToDocument
    {
        private const int componentStartColumn = 4;
        private const int componentStartRow = 3;
        /// <summary>
        /// Сохранение в виде отчета
        /// </summary>
        public void SaveToDocumentExcel(DataTable componentsDataTable, float temperature, float processTime, float processTimeStep)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel файл (.xlsx)|*.xlsx|Excel файл (.xls)|*.xls";

            if (saveFileDialog.ShowDialog() == true)
            {
                string filename = saveFileDialog.FileName;

                using (XLWorkbook workbook = new XLWorkbook())
                {
                    var worksheet = workbook.AddWorksheet("WorkSheet");

                    worksheet.Cell(1, 1).Value = "Температура процесса, *C";
                    worksheet.Cell(1, 1).Style.Font.Bold = true;

                    worksheet.Cell(2, 1).Value = "Время протекания процесса, с";
                    worksheet.Cell(2, 1).Style.Font.Bold = true;

                    worksheet.Cell(3, 1).Value = "Шаг по времени, с";
                    worksheet.Cell(3, 1).Style.Font.Bold = true;

                    worksheet.Cell(1, 4).Value = "Компоненты и их концентрации";
                    worksheet.Cell(1, 4).Style.Font.Bold = true;

                    worksheet.Cell(1, 2).Value = Math.Round(temperature);
                    worksheet.Cell(2, 2).Value = Math.Round(processTime);
                    worksheet.Cell(3, 2).Value = Math.Round(processTimeStep);

                    for (int i = 0; i < componentsDataTable.Columns.Count; i++)
                        worksheet.Cell(componentStartRow - 1, componentStartColumn + i).Value = componentsDataTable.Columns[i].ColumnName;

                    for (int i = 0; i < componentsDataTable.Rows.Count; i++)
                    {
                        for (int j = 0; j < componentsDataTable.Columns.Count; j++)
                        {
                            var value = Math.Round(float.Parse(componentsDataTable.Rows[i][componentsDataTable.Columns[j]].ToString()!), 2);
                            worksheet.Cell(componentStartRow + i, componentStartColumn + j).Value = value;
                        }
                    }

                    workbook.SaveAs(filename);
                }
            }
            else
            {
                Logger.PrintMessageAsync("Ошибка сохранения результатов в отчет", MessageBoxImage.Error);
                return;
            }
            
        }
    }
}
