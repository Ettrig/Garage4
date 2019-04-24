using System;
using System.Collections.Generic;
using System.Text;

namespace GarageProject
{
    class TypeListItem
    {
        private string namn;
        public string Namn { get => namn; set => namn = value; }

        private int antal;
        public int Antal { get => antal; set => antal = value; }

        public TypeListItem( string name, int count)
        {
            namn = name;
            antal = count; 
        }
    }
}
