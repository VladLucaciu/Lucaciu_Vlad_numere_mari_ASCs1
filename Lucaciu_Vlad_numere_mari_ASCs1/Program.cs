using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lucaciu_Vlad_numere_mari_ASCs1
{
    class Program
    {
               
            static void convertire(int[] vectorNumere, string numar) //converteste string-ul intr-un vector fiecare cifra ocupand un element din tablou
            {
                for (int i = 0; i < numar.Length; i++)//luam fiecare char din string de pe pozitia 0 pana la lungimea lui
                {
                    char c = numar[i];//il punem intr-o variabila char
                            vectorNumere[numar.Length - i] = Convert.ToInt32(new string(c, 1));
                }
            }

            static void Main(string[] args)
            {
                Console.WriteLine("Selectati dintre optiunile: ");
                Console.WriteLine("Adunare- Aduna doua numere mari");
                Console.WriteLine("Scadere- Scade doua numere mari");

                string raspuns = Console.ReadLine();

                string numar1, numar2;
                Console.WriteLine("Introduceti primul numar: ");
                numar1 = Console.ReadLine();


                Console.WriteLine("Introduceti al doilea numar: ");
                numar2 = Console.ReadLine();

                //verificam daca e adunare sau scadere 
                if (raspuns == "adunare" || raspuns == "Adunare" || raspuns == "ADUNARE" || raspuns == "    aDUNARE")
                {
                    //declaram t care sa retina 
                    int t = 0, max;

                    //comparam daca al doilea numar e mai lung decat primul
                    if (numar1.Length < numar2.Length)
                    {
                        //max este lungimea numarului mai mare
                        //declaram a si b ca vectori pentru numarul 1 si numarul 2 respectiv
                        //in vectorul rezultat punem rezultatul adunarii (il declaram cu lungimea max+1 in caz ca o sa aiba o cifra in plus)
                        max = numar2.Length;
                        int[] a = new int[max], b = new int[max], rezultat = new int[max + 1];

                        //elementele pe care le stim le punem deja in fiecare vector
                        convertire(a, numar1);
                        convertire(b, numar2);

                        //facem completarea cu 0 uri pentru numarul mai mic
                        for (int i = numar1.Length; i < max; i++)
                            a[i] = 0;

                        //facem adunarea
                        for (int i = 0; i < max; i++)
                        {
                            int cifra = a[i] + b[i] + t;
                            rezultat[i] = cifra % 10;
                            //t-ul retine o cifra in caz ca a si b da peste 10, ca sa fie adunat pentru urmatoarea cifra
                            t = cifra / 10;
                        }

                        //afisam rezultatul in ordine inversa adica cum ar trebui sa fie
                        Console.Write("Rezultatul este: ");
                        //daca t e mai mare decat 0 
                        if (t > 0)
                        {
                            //il punem in ultima cifra
                            rezultat[max] = t;
                            for (int i = max; i >= 0; i--)
                                Console.Write("{0}", rezultat[i]);
                        }
                        else
                        {
                            //daca nu, il luam in considerare (pentru ca ar fi 0)
                            for (int i = max - 1; i >= 0; i--)
                                Console.Write("{0}", rezultat[i]);
                        }
                    }
                    else//acelasi lucru il facem si pentru b adica al doilea numar
                    {
                        max = numar1.Length;
                        int[] b = new int[max], a = new int[max], rezultat = new int[max];

                        convertire(a, numar1);
                        convertire(b, numar2);

                        for (int i = numar1.Length; i < max; i++)
                            b[i] = 0;
                        for (int i = 0; i < max; i++)
                        {
                            int cifra = a[i] + b[i] + t;
                            rezultat[i] = cifra % 10;
                            t = cifra / 10;
                        }
                        Console.Write("Rezultatul este: ");
                        if (t > 0)
                        {
                            rezultat[max] = t;
                            for (int i = max; i >= 0; i--)
                                Console.Write("{0}", rezultat[i]);
                        }
                        else
                        {
                            for (int i = max - 1; i >= 0; i--)
                                Console.Write("{0}", rezultat[i]);
                        }
                    }
                }
                //daca raspunsul a fost scadere
                else if (raspuns == "scadere" || raspuns == "Scadere" || raspuns == "SCADERE" || raspuns == "sCADERE")
                {
                    //comparam care dintre numere este mai "lung"
                    if (numar1.Length > numar2.Length)
                    {
                        //ca si anterior declaram max si variabila de transport
                        int t = 0, max;
                        max = numar1.Length;
                        //declaram vectorii pentru primul numar si al doilea
                        //de aceasta data rezultatul nu are nevoie de o zecimala in plus pentru ca e scadere
                        int[] a = new int[max], b = new int[max], rezultat = new int[max];

                        //convertire in vectori
                        convertire(a, numar1);
                        convertire(b, numar2);


                        for (int i = 0; i < max; i++)
                        {
                            //fiecare pozitie face scadere
                            rezultat[i] = a[i] - b[i] + t;
                            if (rezultat[i] < 0)//daca e mai mic adaugam un zece si trasportul e -1 care se va scadea la urmatoare rulare
                            {
                                rezultat[i] += 10;
                                t = -1;
                            }
                            else//daca nu e mai mic, resetam numarul de trasport
                                t = 0;
                        }
                        //scadem zero-urile nesemnificative pentru ca nu vrem sa fie afisate in fata numarului
                        max--;
                        while (max > 0 && rezultat[max] != 0)
                            max--;

                        //afisarea
                        Console.Write("Rezultatul este: ");
                        for (int i = max; i > 0; i++)
                            Console.WriteLine("{0}", rezultat[i]);
                    }
                    else//procedam ca si inainte numai ca scaderile sunt invers din b cu a 
                    {
                        int t = 0, max;
                        //si max preia de la numarul mai mare adica numarul 2
                        max = numar2.Length;

                        int[] a = new int[max], b = new int[max], rezultat = new int[max];

                        convertire(a, numar1);
                        convertire(b, numar2);


                        for (int i = 0; i < max; i++)
                        {
                            rezultat[i] = b[i] - a[i] + t;
                            if (rezultat[i] < 0)
                            {
                                rezultat[i] += 10;
                                t = -1;
                            }
                            else
                                t = 0;
                        }
                        //scadem zero-urile nesemnificative
                        max--;
                        while (max > 0 && rezultat[max] != 0)
                            max--;

                        //afisarea
                        Console.Write("Rezultatul este: ");
                        for (int i = max; i > 0; i++)
                            Console.WriteLine("{0}", rezultat[i]);
                    }
                }
                else
                    Console.WriteLine("Optiune incorecta");
            }
    }
}



