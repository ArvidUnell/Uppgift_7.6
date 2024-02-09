using System;
namespace Uppgift_7_6
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Skriv in namn på matvaror");
            string[] varor = Console.ReadLine().Split(' ');


            Console.WriteLine("Skriv in matvarornas priser");
            int[] priser = new int[varor.Length];

            bool klar = false;
            while (!klar)
            {
                string[] priserStr = Console.ReadLine().Split(' ');

                if (priserStr.Length == priser.Length)
                {
                    klar = true;
                    for (int i = 0; i < priserStr.Length; i++)
                    {
                        if (!int.TryParse(priserStr[i], out priser[i]))
                        {
                            Console.WriteLine("En eller flera av priserna var ogiltiga. Försök igen");
                            klar = false;
                            break;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Du skrev inte in lika många priser som matvaror. Försök igen");
                }
            }


            Dictionary<string, int> prislista = new Dictionary<string, int>();
            for (int i = 0;i < varor.Length; i++)
            {
                prislista[varor[i]] = priser[i];
            }


            Console.WriteLine("Skriv in din inköpslista");

            int summa = 0;
            klar = false;
            while (!klar)
            {
                string[] inköpslista = Console.ReadLine().Split(' ');

                klar = true;
                foreach (string inköp in inköpslista)
                {
                    if (prislista.ContainsKey(inköp))
                    {
                        summa += prislista[inköp];
                    }
                    else
                    {
                        Console.WriteLine("En eller flera matvaror i din inköpslista har inget pris. Försök igen");
                        summa = 0;
                        klar = false;
                        break;
                    }
                }
            }


            Console.WriteLine($"Priset för inköpslistan är {summa}");


            Console.WriteLine("\nTryck på valfri knapp för att avsluta");
            Console.ReadKey();
        }
    }
}