using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NaturalLanguageDateTime.NLDT
{
    public class CardinalNumber : IPart
    { 
        public int Number { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            CardinalNumber cn = obj as CardinalNumber;
            if ((System.Object)cn == null)
                return false;

            return Number == cn.Number;
        }

        public CardinalNumber(int number) 
        {
            Number = number;
        }

        public TimeSpan AsPrepositionOf(Noun noun)
        {
            return Nouns.AsTimeSpan(noun);
        } 

        public static CardinalNumber From(int number)
        {
            return new CardinalNumber(number);
        }

        public static CardinalNumber From(string LastNumber)
        {
            return new CardinalNumber(int.Parse(LastNumber));
        }

        public bool Takes(IPart part)
        {
            return false;
        }

        public IPart Take(IPart part)
        {
            throw new NotImplementedException();
        }
    }
}
