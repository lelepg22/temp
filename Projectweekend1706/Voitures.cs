using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projectweekend1706
{
    public class Voitures
    {
        public string plaque;
        public string annee;

        public Dictionary<string, Voitures> allVoitures;
        public Voitures(string pPlaque, string pAnne)
        {
            pPlaque = plaque;
            pAnne = annee;
        }

    }
}
