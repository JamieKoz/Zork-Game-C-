using System;
using System.Collections.Generic;

namespace CsharpCode.Items
{
    public class Weapon : Item

    {
        //saved into memory. These are properties
        public int BaseDmg { get; }
        public WeaponType WeaponType { get; }


        // This is constructing which is assigning values to those properties in the program into the memory of what is a weapon type.
        // baseDmg lower case is assigning the value set in program.cs to BaseDmg in upper case which is a property of a weapon. 
        public Weapon(string name, int baseDmg, WeaponType weaponType)
        {

            BaseDmg = baseDmg;

            Name = name;

            WeaponType = weaponType;
        }
    }
}