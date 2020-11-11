using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using LagringsKlass;

namespace AdressBoken
{
    class Program
    {
        private static List<lagring> Adressbok = new List<lagring>();
        static void Main()
        {
            string read_FilePath = @"C:\Users\Dator 7\Pictures\FilenHuss.txt";
            string write_FilePath = @"C:\Users\Dator 7\Pictures\FilenHussUt.txt";
           

            ReadFromFile(read_FilePath);
            
            foreach(lagring entry in Adressbok)
            {
                entry.Print();
            }

            //kommandon 
            Console.WriteLine("Välkommen till adressbokens meny!");
            Console.WriteLine("1.lägg till ny användare!");
            Console.WriteLine("2.Ta bort ny användare!");
            Console.WriteLine("3.Ändra i användare!");
            Console.WriteLine("4.Avsluta programmet");
            Console.WriteLine("skriv in siffran för ditt önskade alternativ:");
            string user_input;

            do
            {
                user_input = Console.ReadLine();
                if (user_input.Equals(@"1"))
                {
                    Console.WriteLine("Skriv in Namn,Adress,Email och telefonnummer för den nya kontakten!Skriv in namn först:");
                    lagring temp;
                    string n, a, e, p;
                    n = Console.ReadLine();
                    a = Console.ReadLine();
                    e = Console.ReadLine();
                    p = Console.ReadLine();
                    temp = new lagring(n, a, e, p);
                    Adressbok.Add(temp);
                    Console.WriteLine(@"Namn Tillagt");

                }
                else if (user_input.Equals(@"2"))
                {
                    Console.WriteLine("Skriv in namnet på den användare du vill ta bort?");
                    string r_name = Console.ReadLine();
                    int Found_Index;
                    Found_Index = Find(r_name);
                    if (Found_Index == 10000)
                    {
                        Console.WriteLine("Användare ej funnen");
                    }
                    else
                    {
                        Adressbok.RemoveAt(Found_Index);
                        Console.WriteLine("Användare borttagen!");
                    }


                }
                else if (user_input.Equals(@"3"))
                {
                    Console.WriteLine("Vilken användare vill bör ändras? Skriv in namnet:");
                    string to_change = Console.ReadLine();
                    int index_of_object_to_change = Find(to_change);

                    Console.WriteLine("Vad i användaren vill du ändra? skriv namnet på det du vill ändra när du valt");
                    Console.WriteLine("1.namn");
                    Console.WriteLine("2.adress");
                    Console.WriteLine("3.email");
                    Console.WriteLine("4.telefonnummer");
                    string change_what = Console.ReadLine();
                    string change_to;

                    if (change_what.Equals(@"1"))
                    {
                        Console.WriteLine("Ändra namn till:");
                        change_to = Console.ReadLine();
                        Adressbok[index_of_object_to_change].SetName(change_to);
                        Console.WriteLine("Ändring gjord! Returnerar till basen");

                    }
                    else if (change_what.Equals(@"2"))
                    {
                        Console.WriteLine("Ändra adress till:");
                        change_to = Console.ReadLine();
                        Adressbok[index_of_object_to_change].SetAdress(change_to);
                        Console.WriteLine("Ändring gjord! Returnerar till basen");

                    }
                    else if (change_what.Equals(@"3"))
                    {
                        Console.WriteLine("Ändra email till:");
                        change_to = Console.ReadLine();
                        Adressbok[index_of_object_to_change].SetEmail(change_to);
                        Console.WriteLine("Ändring gjord! Returnerar till basen");


                    }
                    else if (change_what.Equals(@"4"))
                    {
                        Console.WriteLine("Ändra telefonnummer till:");
                        change_to = Console.ReadLine();
                        Adressbok[index_of_object_to_change].SetPhoneNR(change_to);
                        Console.WriteLine("Ändring gjord! Returnerar till basen");

                    }
                    else
                    {
                        Console.WriteLine("Fel inamtning! Returnerar till basen");
                    }




                }

            } while (!user_input.Equals(@"4"));

            WriteToFile(write_FilePath);

        } 

        public static void ReadFromFile(String path)
        {
            using (StreamReader sr = new StreamReader(path))
            {
                string line;
                do
                {
                    lagring tmp = new lagring();
                    tmp.SetName(sr.ReadLine());
                    tmp.SetAdress(sr.ReadLine());
                    tmp.SetEmail(sr.ReadLine());
                    tmp.SetPhoneNR(sr.ReadLine());
                    Adressbok.Add(tmp);
                } while (!sr.EndOfStream);
            }
        } 

        public static void WriteToFile(string path)
        {
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(path))
            {
                foreach(lagring element in Adressbok)
                {
                    file.WriteLine(element.GetName());
                    file.WriteLine(element.GetAdress());
                    file.WriteLine(element.GetEmail());
                    file.WriteLine(element.GetPhoneNR());
                }
            }
        } 
        public static int Find(string name)
        {
            int i = 0;
            foreach(lagring element in Adressbok)
            {
                if (element.GetName().Equals(name))
                {
                    return i; 
                }
                else
                {
                    i++;
                }
            }
            return 10000;// dummy värde 
        }
    }
}
