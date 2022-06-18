using System;

using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projectweekend1706
{
    public class OrderedNumbers : IEnumerable
    {        
        public List<int> liste = new List<int>();        
        public List<List<string>> allPlaques = new List<List<string>>();
        public List<List<string>> allPlaquesLAAS = new List<List<string>>();
        public IEnumerable<int> Primes()
        {
            for (int x = 1000; x < 9999; x++)
            {
                int n = x, a = 0;

                for (int i = 1; i <= n; i++)
                {
                    if (n % i == 0)
                    {
                        a++;
                    }
                }

                if (a == 2)
                {
                    liste.Add(n);
                }        

            }
            return liste;
        }
       


        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }
        public (string, string) CreatePlaque(string pays)
        {
            var rand = new Random();
            string anneVoiture = rand.Next(1910, 2022).ToString();
            if (liste.Count == 0)
             { Primes(); }
             if(pays == "LAAS") {  
                allPlaquesLAAS.Add(new List<string>() { liste.First().ToString() + " LAAS", anneVoiture });
                allPlaques.Add(new List<string>() { liste.First().ToString() + " LAAS" , anneVoiture });
                var created = liste.First().ToString() + " LAAS";
                liste.Remove(liste.First());

                return (created, anneVoiture);
             }
             else
             {
                
                string Valeur()
                {
                    int i = 0;
                    string testNumber = rand.Next(100, 99999).ToString();
                    while (allPlaques[i][1].Contains(testNumber))
                    {
                        testNumber = rand.Next(100, 99999).ToString();
                        i++;
                    }
                    return testNumber;
                }
                var created = Valeur() + " " + pays;
                allPlaques.Add(new List<string>() { created, anneVoiture });

                return (created, anneVoiture);

            }
        }


    }
}



