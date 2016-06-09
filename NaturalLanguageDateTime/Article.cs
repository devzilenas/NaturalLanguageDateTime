using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NaturalLanguageDateTime.NLDT
{
    class Article : IPart
    {
        public string Value; 

        public class The : Article, IEvaluatable
        {
            public The() : base("the")
            { 
            }

            public CardinalNumber AsCardinalNumber()
            { 
                return CardinalNumber.From(1);
            }

            public IPart Evaluate()
            {
                return AsCardinalNumber();
            }

            public override bool Takes(IPart part)
            {
                return true == (part is Noun);
            }

            public override IPart Take(IPart part)
            {
                if (part is Noun)
                {
                    return part.Take(AsCardinalNumber());
                }
                else
                {
                    return base.Take(part);
                }
            }
        }

        public Article()
        { 
        }

        public Article(string article)
        {
            Value = article;
        }

        public static Article From(string article)
        {
            switch (article)
            {
                case "the":
                    return new The();
                default:
                    return new Article(article);
            }
        }

        public virtual bool Takes(IPart part)
        {
            return (part is Noun) ;
        }

        public virtual IPart Take(IPart part)
        {
            throw new NotImplementedException("Article doesn't know how to take " + part.GetType());
        } 
    }
}
