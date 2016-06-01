using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NaturalLanguageDateTime.NLDT
{
    public class IsA
    {
        public static bool Preposition(string preposition)
        {
            return Prepositions.Is(preposition);
        }

        public static bool CardinalNumber(string cardinal)
        {
            return CardinalNumbers.IsA(cardinal);
        }

        public static bool OrdinalNumber(string ordinalNumber)
        {
            return OrdinalNumbers.IsA(ordinalNumber);
        }

        public static bool Pronoun(string pronoun)
        {
            return Pronouns.IsA(pronoun);
        }

        public static bool Noun(string noun)
        {
            return Nouns.IsA(noun);
        }
    }
}
