using System;
using System.Linq;
using System.Xml.Linq;
using System.Text.Json;
using System.Collections.Generic;

public class Program
{
    public static string FilterPeopleFromXml(string xmlData)
    {
        if (string.IsNullOrWhiteSpace(xmlData))
            return "{}";

        XDocument doc = XDocument.Parse(xmlData);

        // Filtrelenmiş kişiler
        var filteredPeople = doc.Descendants("Person")
                        .Select(p => new
                        {
                            Name = (string)p.Element("Name"),
                            Age = (int)p.Element("Age"),
                            Department = (string)p.Element("Department"),
                            Salary = (decimal)p.Element("Salary"),
                            HireDate = DateTime.Parse((string)p.Element("HireDate"))
                        })
                        .Where(p => p.Age > 30 &&
                                    p.Department == "IT" &&
                                    p.Salary > 5000 &&
                                    p.HireDate.Year < 2019)
                        .ToList();

        // XML'deki toplam <Person> sayısı
        int totalPersons = doc.Descendants("Person").Count();

        var result = new
        {
            Names = filteredPeople.Select(p => p.Name).OrderBy(n => n).ToList(),
            TotalSalary = filteredPeople.Sum(p => p.Salary),
            AverageSalary = filteredPeople.Count > 0 ? filteredPeople.Average(p => p.Salary) : 0,
            MaxSalary = filteredPeople.Count > 0 ? filteredPeople.Max(p => p.Salary) : 0,
            Count = totalPersons
        };

        return JsonSerializer.Serialize(result);
    }

  
       
}
