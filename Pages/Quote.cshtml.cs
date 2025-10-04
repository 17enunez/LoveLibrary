using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using LoveLibrary.Data;
using System;
using System.Collections.Generic;

namespace LoveLibrary.Pages
{
    public class QuoteModel : PageModel
    {
        [BindProperty]
        public string? Mood { get; set; }

        public string Quote { get; set; } = "";
        public string BackgroundImage { get; set; } = "";

        // Keep track of last index used for each mood
        private static readonly Dictionary<string, int> lastQuoteIndex = new Dictionary<string, int>();
        private static readonly Dictionary<string, int> lastImageIndex = new Dictionary<string, int>();

        public void OnPost()
        {
            if (!string.IsNullOrEmpty(Mood) && QuoteLibraryJson.Quotes.ContainsKey(Mood))
            {
                // Rotate quotes
                var quotes = QuoteLibraryJson.Quotes[Mood];
                int quoteIndex = lastQuoteIndex.ContainsKey(Mood) 
                    ? (lastQuoteIndex[Mood] + 1) % quotes.Count 
                    : 0;
                Quote = quotes[quoteIndex];
                lastQuoteIndex[Mood] = quoteIndex;

                // Rotate images
                if (MoodImages.Backgrounds.ContainsKey(Mood) && MoodImages.Backgrounds[Mood].Count > 0)
                {
                    var images = MoodImages.Backgrounds[Mood];
                    int imgIndex = lastImageIndex.ContainsKey(Mood) 
                        ? (lastImageIndex[Mood] + 1) % images.Count 
                        : 0;
                    BackgroundImage = images[imgIndex];
                    lastImageIndex[Mood] = imgIndex;
                }
            }
            else
            {
                Quote = "I love you in every mood ❤️";
                BackgroundImage = "";
            }
        }
    }
}