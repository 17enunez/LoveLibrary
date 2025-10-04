using System.Collections.Generic;

namespace LoveLibrary.Data
{
    public static class QuoteLibrary
    {
        public static Dictionary<string, List<string>> QuotesByMood = new()
        {
            { "happy", new List<string>
                {
                    "Your smile is my sunshine ☀️",
                    "I love how your laughter brightens my day 🌸"
                }
            },
            { "sad", new List<string>
                {
                    "I’ll hold your heart when it feels heavy ❤️",
                    "Even in storms, I’ll be your safe place ⛅"
                }
            },
            { "tired", new List<string>
                {
                    "Rest easy, my love. I’ll dream with you tonight 🌙",
                    "Even when you’re exhausted, you’re perfect to me 💕"
                }
            }
        };
    }
}