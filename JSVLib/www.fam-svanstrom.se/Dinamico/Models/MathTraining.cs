using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Mvc;
using N2;
using N2.Web;
using N2.Details;

namespace Dinamico.Models
{
    /// <summary>
    /// This class represents the data transfer object that encapsulates 
    /// the information used by the template.
    /// </summary>
    [PageDefinition("MathTrainingController")]
    [WithEditableTitle, WithEditableName]
    public class MathTraining : PageModelBase
    {
        [EditableFreeTextArea("Text", 100)]
        public virtual string Text
        {
            get { return (string)(GetDetail("Text") ?? string.Empty); }
            set { SetDetail("Text", value, string.Empty); }
        }

        [Required]
        [Display(Name = "Nivå")]
        public Level level { get; set; }
        [Required]
        [Display(Name = "Antal tal")]
        public int numbers { get; set; }

        [Display(Name = "Nivåer")]
        public SelectList Levels
        {
            get
            {
                var list = (from object value in Enum.GetValues(typeof(Level))
                            select new EnumList() { Value = (int)value, 
                                Text = GetEnumDescriptionFromValue(value) }).ToList();
                //list.Insert(0, new EnumList() { Text = "Välj här" });
                return new SelectList(list, "Value", "Text");
            }
        }

        private string GetEnumDescriptionFromValue(object inValue)
        {
            var descr = "";
            Type enumType = typeof (Level);
            string memberName = Enum.GetName(enumType, inValue);
            var memberInfo = enumType.GetMember(memberName).FirstOrDefault();
            if(memberInfo != null)
            {
                var attrib = memberInfo.GetCustomAttributes(typeof (DescriptionAttribute), true).FirstOrDefault() as DescriptionAttribute;
                if (attrib != null)
                    descr = attrib.Description;
            }
            return descr;
        }

        [Display(Name = "Antal tal")]
        public SelectList NumberCount
        {
            get
            {
                List<int> list = new List<int>();
                for (int i = 1; i <= 10; i++)
                {
                    list.Add(i * 10);
                }
                var selList = new SelectList(list);
                return selList;
            }
        }

        public IEnumerable<MathItem> GetItems(int numberOfItems, Level level)
        {
            var list = new List<MathItem>();
            var max1 = level == Level.Plus || level == Level.Minus ? 10 : 5;
            var min1 = level == Level.Plus || level == Level.Minus ? 5 : 0;
            var rnd = new Random();

            while (numberOfItems-- > 0)
            {
                var op = Operators.Instance.GetOperator(level);
                int num1 = rnd.Next(min1, max1);
                int max2 = level == Level.Plus || level == Level.Minus ? 20 : 5;
                int num2 = rnd.Next(level == Level.Plus || level == Level.Minus ? 10 : 0, max2);

                list.Add(new MathItem(num1, num2, op));
            }
            return list;
        }

    }

    internal class EnumList
    {
        public int Value { get; set; }
        public string Text { get; set; }
    }

    public enum Level
    {
        [Description("Plus")]
        Plus,
        [Description("Minus")]
        Minus,
        [Description("Multiplikation")]
        Multiply,
        [Description("Division")]
        Divide
    }

    public class Operators
    {
        public const int Plus = 0;
        public const int Minus = 1;
        public const int Multiply = 2;
        public const int Divide = 3;

        private readonly Dictionary<int, string> _opDict = new Dictionary<int, string>()
                                                              {
                                                                  { Plus, "+"},
                                                                  { Minus, "-"},
                                                                  { Multiply, "*"},
                                                                  { Divide, "/"}
                                                                };

        static Operators() { }
        public static readonly Operators Instance = new Operators();

        public string GetOperator()
        {
            return this[new Random().Next(_opDict.Count - 1)];
        }

        public string GetOperator(Level idx)
        {
            return _opDict[(int)idx];
        }

        public string this[int idx]
        {
            get { return GetOperator((Level)idx); }
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
            get { return _operator; }
        }
    }
}
