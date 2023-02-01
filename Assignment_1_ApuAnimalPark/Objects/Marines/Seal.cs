using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_1_ApuAnimalPark.Objects.Marines
{
    public class Seal : Marine
    {
        public string Can_do_tricks { get; set; }

        public Seal(double weight,string sound,string canDoTricks) : base(weight,sound)
        {
            Can_do_tricks = canDoTricks;
        }

        public override string ToString()
        {
            string strOut = base.ToString();
            strOut += string.Format("Can do tricks?: {0,-25}\nAnimal: {1,-25}", Can_do_tricks, typeof(Seal).Name);
            return strOut;
        }

    }
}
