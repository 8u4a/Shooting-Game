using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Weaponry
{
    public enum WeaponType
    {
        Ranged,
        Melee
    }
    public enum DamageSpread
    {
        Focused,
        Splash
    }

    public enum DamageType
    {
        Fire,
        Frost,
        Physical,
        Poison
    }

    public enum WeaponClass
    {
        Common,
        Rare,
        Legendary,
        Set
    }



    public class Weapon
    {
        public WeaponType Type { get; set; }
        public DamageSpread Spread { get; set; }
        public DamageType DmgType { get; set; }
        public WeaponClass Class { get; set; }
        public List<Augment> Augments { get; set; }
        public string Name { get; set; }
        public int Damage
        {
            get
            {
                return this.CalculateDamage();
            }
        }


        public Weapon(string name, WeaponClass weaponClass)
        {
            this.Class = weaponClass;
            this.Augments = new List<Augment>();
            this.Name = name;
          
        }

        private int CalculateDamage()
        {
            var totalDamage = CalculateBaseDamageByClass() + GetDmgFrAllAugments();
            return totalDamage;
        }

        private int CalculateBaseDamageByClass()
        {

            if (this.Class == WeaponClass.Common)
                return 50;
            else if (this.Class == WeaponClass.Legendary)
                return 300;
            else if (this.Class == WeaponClass.Set)
                return 500;
            else
                return 100;
        }

        private int GetDmgFrAllAugments()
        {
            var totalExtraDmg = 0;
            for (var i = 0; i < this.Augments.Count; i++ )
            {
                var currentAugment = Augments[i];
                totalExtraDmg = totalExtraDmg + currentAugment.ExtraDmg;
            }
            return totalExtraDmg;
        }

        public override string ToString()
        {
            return $"Attacking with: {Name}, augmented with: {GetNamesOfAugments()} items";
        }

        private string GetNamesOfAugments()
        {
            string nameOfAugments = string.Empty;
            for (var i = 0; i < Augments.Count; i++)
            {

                var comma = i == 0 ? string.Empty : " , ";
                nameOfAugments = nameOfAugments + comma + Augments[i].Name;
            }
            return nameOfAugments;
            
        }
    }

    public enum AugmentType
    {
        Gem,
        Rune
    }

    public class Augment
    {
        public string Name { get; set; }
        public AugmentType Type { get; set; }
        public int ExtraDmg { get; set; }

        public Augment(string name, AugmentType type )
        {
            this.Name = name;
            if (type == AugmentType.Gem) ExtraDmg = 20;
            else ExtraDmg = 40;
        }


    }
}
