using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projectweekend1706
{
    public class Proprio : IImmatriculation
    {
        public string nom;
        public string rue;
        public string ville;
        public string codePostale;
        public string pays;
        public List<string> result = new List<string>();
        public OrderedNumbers plaques = new OrderedNumbers();
        public List<List<string>> voitures = new List<List<string>>();
        public List<Dictionary<string, List<string>>> allProprios = new List<Dictionary<string, List<string>>>();
        public string GetImmatriculation(string pays)
        {
            return plaques.CreatePlaque(pays).Item1;
        }
        
        public Proprio(){
          
        }
        public string CreateProprio( string nom, string rue, string ville, string pays, string codePostal)
        {
            string immatriculation  = GetImmatriculation(pays);
            List<string> lista = new List<string>() { 
                 nom, rue, ville, pays, codePostal, immatriculation };
            Dictionary<string, List<string>> dico = new Dictionary<string, List<string>>();
            dico.Add(immatriculation, lista);
            allProprios.Add(dico);
            return immatriculation;
        }

        public List<List<string>> GetByPays(string pays)
        {
            var result = allProprios.Select((x) => (x.Values)).ToList().Select(x => x.First()).ToList().Where(x => x.Contains(pays)).ToList();
            for (int i = 0; i < result.Count(); i++)
            {
                Console.WriteLine(result[i][1] + " " +  result[i][3] + " plaque :  " + result[i][5]);
            }
            Console.WriteLine("List created");
            return result;
        }
        public List<List<string>> AllVoitures()
        {
            
            for (int i = 0; i < plaques.allPlaques.Count(); i++)
            {
                result.Clear();
                var proprietaire = allProprios.Where(x => x.ContainsKey(plaques.allPlaques[i][0])).Select(x => x.Values).ToList().Select(x => x.First()).ToList();
                for (int y = 0; y < (proprietaire[0].Count()-1); y++) {
                    
                    result.Add(proprietaire[0][y]);

                }
                result.Add(plaques.allPlaques[i][0]);
                result.Add(plaques.allPlaques[i][1]);


                voitures.Add(result.ToList());
                

            }
            Console.WriteLine("Voitures ajoutee :" + voitures.Count());
            return voitures;

        }
    }
}
