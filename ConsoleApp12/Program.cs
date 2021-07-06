using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp12
{
    public delegate void Func(string data);
    public class MethodHelper
    {
        public static string Space(string str)
        {
            var sb = new StringBuilder();

            for (int i = 0; i < str.Length; i++)
            {
                if (i > 0 && i < str.Length)
                    sb.Append('_');
                sb.Append(str[i]);
            }

            return sb.ToString();
        }

        public static string Reverse(string str)
        {
            var sb = new StringBuilder(str);

            for (int i = 0, length = str.Length / 2; i < length; i++)
            {
                var secondIndex = str.Length - 1 - i;
                var tmp = sb[i];

                sb[i] = sb[secondIndex];
                sb[secondIndex] = tmp;
            }

            return sb.ToString();
        }
    }

    public class MyClass
    {

        public void Space(string str)
        {
            Console.WriteLine(MethodHelper.Space(str));
        }

        public void Reverse(string str)
        {
            Console.WriteLine(MethodHelper.Reverse(str));
        }

    }


    public class Run
    {
        public void RunFunc(Func func, string data)
        {
            func.Invoke(data);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter string: ");

            var str = Console.ReadLine();

            var cls = new MyClass();

            Func funcDell = cls.Space;
            funcDell += cls.Reverse;

            var run = new Run();

            run.RunFunc(funcDell, str);
        }
    }
}
