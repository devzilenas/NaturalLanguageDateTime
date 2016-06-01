using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NaturalLanguageDateTime.NLDT
{
    class Nouns 
    {
        public static string[] AbstractNouns = new string[] { "second", "minute", "hour", "day", "week", "month", "year" };// These are abstract nouns - you cannot sense them with your 5 senses.

        public static bool IsA (string noun)
        {
            return AbstractNouns.Contains(noun);
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
                    return TimeSpan.TicksPerSecond;
                case "minute":
                    return TimeSpan.TicksPerMinute;
                case "hour":
                    return TimeSpan.TicksPerHour;
                case "day" :
                    return TimeSpan.TicksPerDay;
                case "week":
                    return Ticks(Noun.From("day")) * 7;
                case "month":
                    return Ticks(Noun.From("week")) * 4;
                case "year":
                    return Ticks(Noun.From("month")) * 2;
                default:
                    throw new ArgumentException("Got unrecognized noun: " + noun);
            }
        }

    }
}
