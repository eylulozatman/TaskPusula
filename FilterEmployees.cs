using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

public class Program
{   
    
     public static string FilterEmployees(IEnumerable<(string Name, int Age, string Department, decimal Salary, DateTime HireDate)> employees)
    {
        if (employees == null)
            return "{}"; //  Eğer liste null ise boş JSON döndür

        //  Filtreleme kriterleri
        var filteredEmployees = employees
            .Where(emp => emp.Age >= 25 && emp.Age <= 40           //  Yaş 25-40 arası
                       && (emp.Department == "IT" || emp.Department == "Finance") // CL: Departman IT veya Finance
                       && emp.Salary >= 5000 && emp.Salary <= 9000  //  Maaş 5000-9000 arası
                       && emp.HireDate.Year > 2017)                //  İşe giriş 2017 sonrası
            .ToList();

        //  İsim sıralama: önce uzunluk azalan, sonra alfabetik
        var sortedNames = filteredEmployees
            .OrderByDescending(emp => emp.Name.Length)
            .ThenBy(emp => emp.Name)
            .Select(emp => emp.Name)
            .ToList();


        var result = new
        {
            Names = sortedNames,
            TotalSalary = filteredEmployees.Sum(emp => emp.Salary),     //  Toplam maaş
            AverageSalary = filteredEmployees.Count > 0 ? Math.Round(filteredEmployees.Average(emp => emp.Salary), 2) : 0, // Ortalama maaş, iki ondalık yuvarlanmış
            MinSalary = filteredEmployees.Any() ? filteredEmployees.Min(emp => emp.Salary) : 0, //  En düşük maaş
            MaxSalary = filteredEmployees.Any() ? filteredEmployees.Max(emp => emp.Salary) : 0, //  En yüksek maaş
            filteredEmployees.Count                              //  Toplam çalışan sayısı
        };

        return JsonSerializer.Serialize(result); //  JSON formatında döndür
    }
  
}
