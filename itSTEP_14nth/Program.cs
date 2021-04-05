using System;

namespace itSTEP_14nth
{
    class Program
    {
        private delegate void stepTaskHandler(string s);

        static void Main()
        {
            stepTaskHandler del = Method1;
            del += Method2;

            foreach (stepTaskHandler nextDel in del.GetInvocationList())
            {
                try
                {
                    nextDel.Invoke("Yooper");
                }
                catch (Exception xx)
                {
                    Console.WriteLine(string.Format("Exception in {0}: {1}", nextDel.Method.Name, xx.Message));
                }
            }
        }

        static void Method1(string text)
        {
            throw new Exception(string.Format("Problem in Method1: {0}",text));
        }

        static void Method2(string name)
        {
            Console.WriteLine("Method2, {0}", name);
        }
    }

}

