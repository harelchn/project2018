using System;
using System.Collections.Generic;
using System.Text;

namespace BE
{
    public class Child
    {
        private readonly string idC;
        private readonly string idM;
        private string name;
        private DateTime birthDate;
        private bool isSpecial;
        private string specialNeeds;

        public Child(string idC, string idM, string name, DateTime bD, bool isS, string sp)
        {
            CheckId(idC);
            this.idC = idC;
            CheckId(idM);
            this.idM = idM;
            Name = name;
            BirthDate = bD;
            IsSpecial = isS;
            SpecialNeeds = sp;
        }

        public string IdC => idC;

        public string IdM => idM;

        public string Name
        {
            get => name;
            set
            {
                char t;
                for (int i = 0; i < value.Length; ++i)
                {
                    t = value.ToCharArray()[i];
                    if (t < 'A' || t > 'Z' && t < 'a' || t > 'z')
                        throw;
                }
                name = value;
            }
        }
        public DateTime BirthDate
        {
            get => birthDate;
            set
            {
                if (value > DateTime.Now)
                    throw;
                birthDate = value;
            }
        }
        public bool IsSpecial { get => isSpecial; set => isSpecial = value; }
        public string SpecialNeeds { get => specialNeeds; set => specialNeeds = value; }

        public override string ToString()
        {
            string ret = "Name: " + Name + @"
                ID of the child: " + IdC + @"
                ID of the mother: " + IdM + @"
                Age: " + Age() + @"
                Special needs: " + Special();

            return ret;
        }

        private int Age()
        {
            if (BirthDate.Month > DateTime.Now.Month)
                return DateTime.Now.Year - BirthDate.Year;
            if (BirthDate.Month == DateTime.Now.Month && BirthDate.Day >= DateTime.Now.Day)
                return DateTime.Now.Year - BirthDate.Year;
            return DateTime.Now.Year - BirthDate.Year - 1;
        }

        private string Special()
        {
            if (IsSpecial)
                return '\n' + SpecialNeeds;
            return "No";
        }

        private void CheckId(string id)
        {
            char t;
            for (int i = 0; i < id.Length; i++)
            {
                t = id.ToCharArray()[i];
                if (t < '0' || t > '9')
                    throw;
            }
        }
    }
}
