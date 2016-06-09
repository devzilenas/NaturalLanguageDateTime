using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NaturalLanguageDateTime.NLDT
{
    class Nouns : IDetector
    {
        public static string[] AbstractNouns = new string[] { "second", "seconds", "minute", "minutes", "hour", "hours", "day", "days", "week", "weeks", "month", "months", "year", "years" };// These are abstract nouns - you cannot sense them with your 5 senses.
        public static string[] AbstractNounsAny = new string[] { "time" }; //nouns that can have any meaning from AbstractNouns

        public static bool IsA(string noun)
        {
            return AbstractNouns.Concat<string>(AbstractNounsAny).Contains<string>(noun, StringComparer.OrdinalIgnoreCase);
        }

        public static TimeSpan AsTimeSpan(Noun noun)
        {
            return TimeSpan.FromTicks(Ticks(noun));
        }

        public static Int64 Ticks(Noun noun)
        {
            switch(noun.Value.ToLower())
            { 
                case "second":
                case "seconds":
                    return TimeSpan.TicksPerSecond;
                case "minute":
                case "minutes":
                    return TimeSpan.TicksPerMinute;
                case "hour":
                case "hours": 
                    return TimeSpan.TicksPerHour;
                case "day" :
                case "days" :
                    return TimeSpan.TicksPerDay;
                case "week":
                case "weeks":
                    return Ticks(Noun.From("day")) * 7;
                case "month":
                case "months":
                    return Ticks(Noun.From("week")) * 4;
                case "year":
                case "years":
                    return Ticks(Noun.From("month")) * 2;
                case "time":
                    return Ticks(Noun.From(AbstractNouns[new Random().Next(AbstractNouns.Length)]));//take some random noun
                default:
                    throw new ArgumentException("Got unrecognized noun: " + noun);
            }
        }

    }
}
