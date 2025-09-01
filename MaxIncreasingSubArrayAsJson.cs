using System.Linq;
using System.Text.Json;
using System.Collections.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

public class Program
{
   
public static string MaxIncreasingSubArrayAsJson(List<int> numbers)
{
    // Eğer liste null veya boşsa, boş JSON dizisi döndür
    if (numbers == null || numbers.Count == 0)
        return "[]";

    int maxLength = 0;  // longestSubArray.Count da kullanılabilir
    List<int> currentSubArray = new List<int>();
    List<int> longestSubArray = new List<int>();

    for (int i = 0; i < numbers.Count; i++)
    {
        // İlk elemanı ekle veya artış devam ediyorsa
        if (currentSubArray.Count == 0 || numbers[i] > currentSubArray.Last())
        {
            currentSubArray.Add(numbers[i]);
        }
        else
        {
            // Artış durdu, alt diziyi kontrol et
            if (currentSubArray.Count > maxLength)
            {
                maxLength = currentSubArray.Count;
                longestSubArray = new List<int>(currentSubArray);
            }

            // Yeni alt dizi başlat
            currentSubArray.Clear();
            currentSubArray.Add(numbers[i]);
        }
    }

    // Son alt diziyi tekrar kontrol et
    if (currentSubArray.Count > maxLength)
    {
        longestSubArray = new List<int>(currentSubArray);
    }
   // json çıktısı oluşturuldu  
    return JsonSerializer.Serialize(longestSubArray);
}

  
}


