using System;
using System.Collections.Generic;
using System.Text;

namespace BE
{
    public class Child
    {
        #region fields
        private string idC;
        private string idM;
        private string name;
        private DateTime birthDate;
        private bool isSpecial;
        private string specialNeeds;
        #endregion
        public Child() { isSpecial = false; }
        public Child(string idC, string idM, string name, DateTime bD, string sp)
        {
            CheckId(idC);
            this.idC = idC;
            CheckId(idM);
            this.idM = idM;
            Name = name;
            BirthDate = bD;
            SpecialNeeds = sp;
            if (sp == null)
                isSpecial = false;
            else isSpecial = true;
        }

        #region properties
        public string IdC
        {
            get => idC;
            set
            {
                if(idC==null)
                {
                    CheckId(value);
                    idC = value;
                }
            }
        }

        public string IdM => idM;

        public string Name
        {
            get => name;
            set
            {
                char t;
                if (value == null)
                    throw new Exception("Enter a name!");
                for (int i = 0; i < value.Length; ++i)
                {
                    t = value.ToCharArray()[i];
                    if (t < 'A' || t > 'Z' && t < 'a' || t > 'z')
                        throw new Exception("This name is invalid!");
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
                    throw new Exception("birth date can't be in the future!");
                birthDate = value;
            }
        }
        public bool IsSpecial { get => isSpecial; set => isSpecial = value; }
        public string SpecialNeeds
        {
            get => specialNeeds;
            set
            {
                specialNeeds = value;
                if (specialNeeds != null)
                    isSpecial = true;
            }
        }
        #endregion

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
            if (id == null)
                throw new Exception("Enter Id!");
            for (int i = 0; i < id.Length; i++)
            {
                t = id.ToCharArray()[i];
                if (t < '0' || t > '9')
                    throw new Exception("Id is invalid!");
            }
        }
    }
}
