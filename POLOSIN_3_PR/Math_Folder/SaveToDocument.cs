using ClosedXML.Excel;
using Microsoft.Win32;
using POLOSIN_3_PR.Async_Methods;
using System.Data;
using System.Windows;

namespace POLOSIN_3_PR.Math_Folder
{
    public class SaveToDocument
    {
        private const int componentStartColumn = 9;
        private const int componentStartRow = 3;

        private const int chemicalEquationStartColumn = 4;
        private const int chemicalEquationStartRow = 3;
        /// <summary>
        /// Сохранение в виде отчета
        /// </summary>
        public void SaveToDocumentExcel(DataTable componentsDataTable, float temperature, float processTime, float processTimeStep, float timeCount, float memoryUsed)
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

                    worksheet.Cell(6, 1).Value = "Затраченное время, мс";
                    worksheet.Cell(6, 1).Style.Font.Bold = true;

                    worksheet.Cell(7, 1).Value = "Производительность, МБ";
                    worksheet.Cell(7, 1).Style.Font.Bold = true;                  

                    worksheet.Cell(chemicalEquationStartRow - 1, chemicalEquationStartColumn).Value = "Реакция";
                    worksheet.Cell(chemicalEquationStartRow - 1, chemicalEquationStartColumn).Style.Font.Bold = true;

                    worksheet.Cell(chemicalEquationStartRow - 1, chemicalEquationStartColumn + 1).Value = "Пред. множитель";
                    worksheet.Cell(chemicalEquationStartRow - 1, chemicalEquationStartColumn + 1).Style.Font.Bold = true;

                    worksheet.Cell(chemicalEquationStartRow - 1, chemicalEquationStartColumn + 2).Value = "Энергия активации";
                    worksheet.Cell(chemicalEquationStartRow - 1, chemicalEquationStartColumn + 2).Style.Font.Bold = true;

                    worksheet.Cell(1, 2).Value = temperature;
                    worksheet.Cell(2, 2).Value = processTime;
                    worksheet.Cell(3, 2).Value = processTimeStep;

                    worksheet.Cell(6, 2).Value = timeCount;
                    worksheet.Cell(7, 2).Value = memoryUsed;

                    // все что выше, это определение колонок в Excel 

                    for (int i = 0; i < MainWindow.chemicalEquations!.Count; i++) // характеристики реакций
                    {
                        worksheet.Cell(chemicalEquationStartRow + i, chemicalEquationStartColumn).Value = MainWindow.chemicalEquations[i]._OverralReactionText!;
                        worksheet.Cell(chemicalEquationStartRow + i, chemicalEquationStartColumn + 1).Value = MainWindow.chemicalEquations[i]._PredExp!;
                        worksheet.Cell(chemicalEquationStartRow + i, chemicalEquationStartColumn + 2).Value = MainWindow.chemicalEquations[i]._ActivateEnergy!;
                    }

                    for (int i = 0; i < componentsDataTable.Columns.Count; i++) // компоненты
                        worksheet.Cell(componentStartRow - 1, componentStartColumn + i).Value = componentsDataTable.Columns[i].ColumnName;

                    for (int i = 0; i < componentsDataTable.Rows.Count; i++)
                    {
                        for (int j = 0; j < componentsDataTable.Columns.Count; j++) // и их концентрации
                        {
                            var value = Math.Round(float.Parse(componentsDataTable.Rows[i][componentsDataTable.Columns[j]].ToString()!), 5);
                            worksheet.Cell(componentStartRow + i, componentStartColumn + j).Value = value;
                        }
                    }

                    worksheet.Columns().AdjustToContents(); // по ширине текста колонки
                    workbook.SaveAs(filename);
                }
                Logger.PrintMessageAsync("Отчет успешно сохранен", MessageBoxImage.Information);
            }
            else
            {
                Logger.PrintMessageAsync("Ошибка сохранения результатов в отчет", MessageBoxImage.Error);
                return;
            }
            
        }
    }
}
