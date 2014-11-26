using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Contacts.Models.Page
{
    public enum Difficulty
    {
        Easy = 5,
        Medium = 10,
        Hard = 20
    }

    public class Operators
    {
        public const int Plus = 0;
        public const int Minus = 1;

        private readonly Dictionary<int, string> _opDict = new Dictionary<int, string>()
                                                              {
                                                                  { Plus, "+"},
                                                                  {Minus, "-"}
                                                                };

        static Operators(){}
        public static readonly Operators Instance = new Operators();

        public string GetOperator()
        {
            return this[new Random().Next(_opDict.Count - 1)];
        }

        public string GetOperator(int idx)
        {
            return _opDict[idx];
        }

        public string this[int idx]
        {
            get { return GetOperator(idx); }
        }
    }

    public class MathItem
    {
        private string _operator;
        public MathItem()
        {
            Number1 = 0;
            Number2 = 0;
        }

        public MathItem(int number1, int number2, string oper = "")
        {
            Number1 = number1;
            Number2 = number2;
            _operator = oper == "" ? Operators.Instance.GetOperator() : oper;
        }

        public int Number1 { get; private set; }
        public int Number2 { get; private set; }
        public string Operator
        {
            get { return Operators.Instance.GetOperator(); }
        }
    }

    public class MathTraining : List<MathItem>
    {
        public IEnumerable<MathItem> GetItems(int numberOfItems, Difficulty difficulty)
        {
            var list = new List<MathItem>();
            var max1 = (int)difficulty;
            var rnd = new Random();

            while (numberOfItems-- > 0)
            {
                int num1 = rnd.Next(max1);
                int max2 = 10;
                int num2 = rnd.Next(max2);

                list.Add(new MathItem(num1, num2));
            }
            return list;
        }
    }
}