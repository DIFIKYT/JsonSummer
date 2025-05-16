using System;
using System.IO;
using Newtonsoft.Json.Linq;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.json";
        string outputPath = "output.json";

        if (File.Exists(inputPath) == false)
        {
            Console.WriteLine("Файл input.json не найден.");
            return;
        }

        string json = File.ReadAllText(inputPath);
        JObject jObject = JObject.Parse(json);

        double sum = 0;
        foreach (JProperty property in jObject.Properties())
        {
            if (double.TryParse(property.Value.ToString(), out double value))
            {
                sum += value;
            }
        }

        JObject result = new()
        {
            ["sum"] = sum
        };

        File.WriteAllText(outputPath, result.ToString());
        Console.WriteLine($"Сумма: {sum}");
    }
}
