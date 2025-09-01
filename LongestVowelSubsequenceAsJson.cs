using System.Linq;
using System.Text.Json;
using System.Collections.Generic;

public class Program
{
    public static string LongestVowelSubsequenceAsJson(List<string> words)
    {
        if (words == null || words.Count == 0)
            return "[]";

        var vowels = new HashSet<char> { 'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U' };
        List<string> jsonParts = new List<string>();

        foreach (var word in words)
        {
            string currentSeq = "";
            string maxSeq = "";

            foreach (char c in word)
            {
                if (vowels.Contains(c))
                {
                    currentSeq += c; // sesli harfi stirnge ekle
                    if (currentSeq.Length > maxSeq.Length)
                        maxSeq = currentSeq;  // maxSeq güncelle
                }
                else // Sessiz harf geldiyse 
                {
                    
                    currentSeq = "";  // mevcut diziyi sıfırla
                }
            }

            // JSON stringini oluştur
            // record WordVowelInfo(string word, string sequence, int length);  record veri tipi kullanılarak da oluşturulabilir

            string jsonItem = $"{{\"word\":\"{word}\",\"sequence\":\"{maxSeq}\",\"length\":{maxSeq.Length}}}";
            jsonParts.Add(jsonItem);
        }

        return "[" + string.Join(",", jsonParts) + "]";
    }

    public static void Main()
    {
        var input = new List<string> { "aeiou", "bcd", "aaa", "miscellaneous" };
        string output = LongestVowelSubsequenceAsJson(input);
        Console.WriteLine(output);
        // Çıktı: [{"word":"aeiou","sequence":"aeiou","length":5},{"word":"bcd","sequence":"","length":0},{"word":"aaa","sequence":"aaa","length":3},{"word":"miscellaneous","sequence":"eou","length":3}]
    }
}


    


