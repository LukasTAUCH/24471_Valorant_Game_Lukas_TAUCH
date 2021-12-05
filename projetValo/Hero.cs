using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projetValo
{
    public class Hero
    {
        #region Attributs
        public string HeroName { get; set; }
        public double Life { get; set; }
        #endregion

        #region Builders
        public Hero(string _HeroName, double _Life)
        {
            HeroName = _HeroName;
            Life = _Life;
        }
        public Hero()
        {

        }
        #endregion
    }

}
