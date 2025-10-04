using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace LoveLibrary.Data
{
    public static class MoodImages
    {
        public static readonly Dictionary<string, List<string>> Backgrounds;

        static MoodImages()
        {
            Backgrounds = new Dictionary<string, List<string>>();
            var wwwroot = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images");

            if (!Directory.Exists(wwwroot))
                return;

            foreach (var moodFolder in Directory.GetDirectories(wwwroot))
            {
                var mood = Path.GetFileName(moodFolder);
                var images = Directory.GetFiles(moodFolder)
                                      .Where(f => f.EndsWith(".jpg") || f.EndsWith(".png") || f.EndsWith(".jpeg"))
                                      .Select(f => f.Replace(Directory.GetCurrentDirectory() + "/wwwroot", "").Replace("\\", "/"))
                                      .ToList();
                Backgrounds[mood] = images;
            }
        }
    }
}