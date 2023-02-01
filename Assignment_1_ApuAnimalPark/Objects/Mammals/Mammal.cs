﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment_1_ApuAnimalPark.Objects.AnimalsGen;

namespace Assignment_1_ApuAnimalPark.Objects.Mammals
{
    public class Mammal : Animal
    {
        public int Number_Of_Teeth { get; set; }
        public int Tail_Length { get; set; }

        public Mammal(int numOfTeeth, int tailLength)
        {
            Number_Of_Teeth = numOfTeeth;
            Tail_Length = tailLength;
        }

        public override string ToString()
        {
            string strOut = base.ToString();
            strOut += string.Format("Teeth Number: {0,-25} \nTail Length: {1,-25}\n",Number_Of_Teeth,Tail_Length);
            return strOut;
        }
    }
}