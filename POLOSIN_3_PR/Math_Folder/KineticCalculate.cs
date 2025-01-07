using POLOSIN_3_PR.Classes_Folder;
using System.Collections.ObjectModel;
using System.Data;
using OdeLibrary;
using System.Diagnostics;
using System.IO;
using Newtonsoft.Json;
using POLOSIN_3_PR.Async_Methods;

namespace POLOSIN_3_PR.Math_Folder
{
    public class KineticCalculate
    {

        public Dictionary<string, List<double>> CalculateDifferentialEquations(List<string> chemicalEquation, 
            List<float> velocityConst, List<float> initialConcentration, float processTime, float processStep)
        {
            Dictionary<string, List<double>> results = new Dictionary<string, List<double>>();
            // Данные для передачи
            string[] equations = chemicalEquation.ToArray();  // Массив уравнений
            float[] rateConstants = velocityConst.ToArray();  // Массив констант скорости
            float[] inticonc = initialConcentration.ToArray();  // Массив констант скорости
            float time = processTime;  // Общее время
            float timeStep = processStep;  // Шаг по времени

            // Записываем данные в JSON-файл
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(new
            {
                Equations = equations,
                RateConstants = rateConstants,
                Time = time,
                TimeStep = timeStep,
                InitialConcentrations = inticonc
            });

            File.WriteAllText("input.json", json);

            // Запуск Python-скрипта
            ProcessStartInfo start = new ProcessStartInfo();
            start.FileName = "C:\\Users\\egor_\\AppData\\Local\\Programs\\Python\\Python313\\python.exe";  // Или полный путь к python.exe
            start.Arguments = "D:\\prog\\Polosin\\POLOSIN\\POLOSIN_3_PR\\bin\\Debug\\net8.0-windows";  // Имя Python-скрипта
            start.UseShellExecute = false;
            start.RedirectStandardOutput = true;
            start.RedirectStandardError = true;
            start.CreateNoWindow = true;

            using (Process process = Process.Start(start)!)
            {
                
            }

            if (File.Exists("output.json"))
            {
                string outputJson = File.ReadAllText("output.json");
                results = JsonConvert.DeserializeObject<Dictionary<string, List<double>>>(outputJson)!;
            }
            else
            {
                Logger.PrintMessageAsync("Файл output.json не найден", System.Windows.MessageBoxImage.Error);
            }
            return results;
        }

    }
}
