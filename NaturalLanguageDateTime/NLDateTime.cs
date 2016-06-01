using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaturalLanguageDateTime.NLDT
{
    public class NLDateTime
    {
        public DateTime DateTime { get; set; }
        public DateTime Date { get { return DateTime.Date; } }
        public List<IPart> Parts { get; set; }

        public override string ToString()
        {
            return DateTime.ToString();
        }

        public NLDateTime()
        {
            DateTime = new DateTime();
        }

        public static NLDateTime ParseString(string str)
        {
            return new NLDateTime().Parse(str);
        }

        public static IDTime Evaluate(string str)
        {
            NLDateTime dt = ParseString(str);
            return dt.Evaluate();
        }

        public IDTime Evaluate()
        {
            return Evaluate(Parts);
        }

        public IDTime Evaluate(List<IPart> parts)
        {
            //If you like followin code clap your hands! :)
            List<IPart> reversed = parts.ToList();
            reversed.Reverse();
            Stack<IPart> pq = new Stack<IPart>(reversed);
            if (pq.Count == 1)
            {
                return pq.Peek() as IDTime;
            }
            else if (pq.Count > 1)
            {
                while (pq.Count > 1)
                {
                    IPart op1 = pq.Pop(); //first
                    IPart op2 = pq.Pop(); //second 
                    IPart result;
                    if (op1.Takes(op2))
                    {
                        result = op1.Take(op2);
                    }
                    else if (op2.Takes(op1))
                    {
                        result = op2.Take(op1);
                    }
                    else
                    {
                        throw new ArgumentException("Could not evaluate " + op1.GetType() + " and " + op2.GetType());
                    }
                    pq.Push(result);
                }
            }
            return pq.Peek() as DTime;
        }

        public List<IPart> AsParts(string str)
        {
            String LastWord = "";
            String LastNumber = "";

            List<IPart> Parts = new List<IPart>();

            int position = 0;
            char at;

            while (position < str.Length)
            {
                at = str[position];
                Trace.Write(String.Format("At position {0}. Character {1}", position, at));

                //Skip unprintable characters
                if (!Char.IsLetterOrDigit(at))
                {
                    position++;
                    Trace.Write("Skipped{n}".Replace("{n}", Environment.NewLine));
                    continue; //=skip;
                }

                if (Char.IsDigit(at)) //read all following digits
                {
                    StringBuilder number = new StringBuilder();
                    number.Append(at);
                    Trace.Write(String.Format("Digit found {0}", at));
                    position++;
                    int pos = position;
                    while (pos < str.Length && Char.IsDigit(str[pos]))
                    {
                        char c = str[pos];
                        //Take next digit
                        at = c;
                        number.Append(at);
                        Trace.Write(String.Format("Digit found {0}", at));
                        pos++;
                        position++;
                    }

                    LastNumber = number.ToString();
                    Trace.Write(String.Format("Adding CardinalNumber {0} {n}".Replace("{n}", Environment.NewLine), LastNumber));
                    Parts.Add(CardinalNumber.From(LastNumber));
                }

                if (Char.IsLetter(at))
                {
                    StringBuilder word = new StringBuilder();
                    word.Append(at);
                    Trace.Write(String.Format("Letter found {0}", at));
                    position++;
                    int pos = position;
                    while (pos < str.Length && Char.IsLetter(str[pos]))
                    {
                        char c = str[pos];
                        //Take next letter
                        at = c;
                        word.Append(at);
                        Trace.Write(String.Format("Letter found {0}", at));
                        pos++;
                        position++;
                    }

                    LastWord = word.ToString();
                    //Now test what got.
                    if (IsA.CardinalNumber(LastWord))
                    {
                        Parts.Add(CardinalNumber.From(LastWord));
                        Trace.Write(String.Format("Adding CardinalNumber {0} {n}".Replace("{n}", Environment.NewLine), LastWord));
                    }
                    else if (IsA.Preposition(LastWord))
                    {
                        Parts.Add(Preposition.From(LastWord));
                        Trace.Write(String.Format("Adding Preposition {0} {n}".Replace("{n}", Environment.NewLine), LastWord));
                    }
                    else if (IsA.Noun(LastWord))
                    {
                        Trace.Write(String.Format("Adding Noun {0} {n}".Replace("{n}", Environment.NewLine), LastWord));
                        Parts.Add(Noun.From(LastWord));
                    }
                    else if (IsA.Pronoun(LastWord))
                    {
                        Trace.Write(String.Format("Adding Pronoun {0} {n}".Replace("{n}", Environment.NewLine), LastWord));
                        Parts.Add(Pronoun.From(LastWord));
                    }
                    else if (IsA.OrdinalNumber(LastWord))
                    {
                        Trace.Write(String.Format("Adding OrdinalNumber {0} {n}".Replace("{n}", Environment.NewLine), LastWord));
                        Parts.Add(OrdinalNumber.From(LastWord));
                    }
                }
            }
            return Parts;
        }

        public NLDateTime Parse(string str)
        {

            Parts = AsParts(str);

            foreach (string word in str.Split('.'))
            {
                switch (word.ToLower())
                {
                    case "yesterday":
                        DateTime = DateTime.Now.AddDays(-1);
                        break;
                    case "tomorrow":
                        DateTime = DateTime.Now.AddDays(+1);
                        break;
                    case "today":
                        DateTime = DateTime.Now;
                        break;
                    case "plus":
                        throw new NotImplementedException();
                    case "minus":
                        throw new NotImplementedException();
                    case "next":
                        throw new NotImplementedException();
                    case "last":
                        throw new NotImplementedException();
                }
            }
            return this;
        }
    }
}
