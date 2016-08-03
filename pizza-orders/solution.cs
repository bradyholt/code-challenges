using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Newtonsoft.Json;
using System.IO;

class Program
{
    const string PIZZA_JSON_FILE = "pizzas.json";
    const int TAKE_COUNT = 5;

    static void Main(string[] args)
    {
        string pizzasJson = File.ReadAllText(PIZZA_JSON_FILE);
        List<Pizza> orderedPizzas = JsonConvert.DeserializeObject<List<Pizza>>(pizzasJson);

        var topPizzaConfigurations = orderedPizzas
            .GroupBy(p => p.Configuration)
            .Select(group => new
                {
                    Configuration = group.Key,
                    Count = group.Count()
                })
            .OrderByDescending(p => p.Count)
            .Take(TAKE_COUNT);

        Console.WriteLine("Configuration                 Order Count");
        Console.WriteLine("=========================================");

        foreach (var s in topPizzaConfigurations)
        {
            Console.WriteLine("{0}{1}", s.Configuration.PadRight(30), s.Count);
        }

        Console.ReadLine();
    }

    class Pizza
    {
        public string[] Toppings { get; set; }

        [JsonIgnore]
        public string Configuration
        {
            get { return string.Join(", ", this.Toppings); }
        }
    }
}