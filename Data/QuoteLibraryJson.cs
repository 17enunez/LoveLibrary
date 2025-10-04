using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace LoveLibrary.Data
{
    public static class QuoteLibraryJson
    {
        private static readonly Dictionary<string, List<string>> _quotes;

        static QuoteLibraryJson()
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Data", "quotes.json");
            var jsonString = File.ReadAllText(filePath);
            _quotes = JsonSerializer.Deserialize<Dictionary<string, List<string>>>(jsonString)
                      ?? new Dictionary<string, List<string>>();
        }

        public static Dictionary<string, List<string>> Quotes => _quotes;
    }
}