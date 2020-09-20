using System;
using System.Threading;

namespace Lab2
{
    class Program
    {
        public delegate bool DelforLab(int x, int y, int z, bool res);
        
        static void Main(string[] args)
        {
           

            Console.WriteLine("Введите m ");
            int m = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите n ");
            int n = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Введите число ");
            int chislo = Convert.ToInt32(Console.ReadLine());
            
            
            bool a = false;
            

            DelforLab delegat1 = (x, y, z, chis) =>
            {
                Random rand = new Random();
                int[,] mas = new int[x, y];
                for (int i = 0; i < x; i++)
                {
                    for (int u = 0; u < y; u++)
                    {
                        mas[i, u] = rand.Next(0, 50);
                        Thread.Sleep(50);
                    }
                }


                for (int i = 0; i < x; i++)
                {
                    for (int u = 0; u < y; u++)
                    {
                        if (mas[i, u] == z)
                        {
                            chis = true;
                        }
                    }
                }

                return chis;

            };
            IAsyncResult ar = delegat1.BeginInvoke(m, n, chislo, a, null, null);

            while (true)		

            {
                Console.Write(".");
                if(ar.AsyncWaitHandle.WaitOne(50, false))
                {
                    Console.WriteLine("Можно извлеч результат сейчас");
                    break;
                }
            }

            bool result = delegat1.EndInvoke(ar);

            if (result == true)
            {
                Console.WriteLine("Элемент существует");
            }
            else
            {
                Console.WriteLine("Элемент не существует");
            }
           
        }
    }
}
