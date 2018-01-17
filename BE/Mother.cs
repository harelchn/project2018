using System;
using System.Collections.Generic;
using System.Text;

namespace BE
{
    public class Mother
    {
        #region fields
        private string id;
        private string l_name;
        private string f_name;
        private string phone;
        private string addressMother;
        private string addressNanny;
        private bool[] nannyDay = new bool[6];
        private TimeSpan[,] nannyTime = new TimeSpan[6, 2];
        private bool isHour;
        #endregion 
        public Mother() { }

        public Mother(string id, string l, string f, string ph, string adM, string adN, bool[] nannyD, TimeSpan[,] nannyT, bool isH)
        {
            Check_ID(id);
            L_name = l;
            F_name = f;
            Phone = ph;
            AddressMother = adM;
            AddressNanny = adN;
            NannyDay = nannyD;
            NannyTime = nannyT;
            IsHour = isH;
        }

        #region properties
        public string ID
        {
            get => id;
            set
            {
                if (id == null)
                    Check_ID(value);
            }
        }

        public string L_name
        {
            get => l_name;
            set
            {
                char t;
                for (int i = 0; i < value.Length; ++i)
                {
                    t = value.ToCharArray()[i];
                    if (t < 'A' || t > 'Z' && t < 'a' || t > 'z')
                        throw new Exception("This last name is invalid!");
                }
                l_name = value;
            }
        }

        public string F_name
        {
            get => f_name;
            set
            {
                char t;
                for (int i = 0; i < value.Length; ++i)
                {
                    t = value.ToCharArray()[i];
                    if (t < 'A' || t > 'Z' && t < 'a' || t > 'z')
                        throw new Exception("This first name is invalid!");
                }
                f_name = value;
            }
        }
        public string Phone
        {
            get => phone;
            set
            {
                char t;
                for (int i = 0; i < value.Length; i++)
                {
                    t = value.ToCharArray()[i];
                    if (t < '0' || t > '9' || value.Length != 10)
                        throw new Exception("This phone number is invalid!");
                }
                phone = value;
            }
        }
        public string AddressMother
        {
            get => addressMother;
            set
            {
                char t;
                string[] check = value.Split(','/*, ','*/);
                for (int i = 0; i < check.Length; i++)
                {
                    for (int j = 0; j < check[i].Length; ++j)
                    {
                        t = value.ToCharArray()[j];
                        if (t < 'A' || t > 'Z' && t < 'a' || t > 'z')
                            throw new Exception("Mother's address is invalid!");
                    }
                }
                addressMother = value;
            }
        }
        public string AddressNanny
        {
            get => addressNanny;
            set
            {
                char t;
                string[] check = value.Split(','/*, ','*/);
                for (int i = 0; i < check.Length; i++)
                {
                    for (int j = 0; j < check[i].Length; ++j)
                    {
                        t = value.ToCharArray()[j];
                        if (t < 'A' || t > 'Z' && t < 'a' || t > 'z')
                            throw new Exception("Nanny's address is invalid!");
                    }
                }
                addressNanny = value;
            }
        }
        public bool[] NannyDay { get => nannyDay; set => nannyDay = value; }
        public TimeSpan[,] NannyTime { get => nannyTime; set => nannyTime = value; }
        public bool IsHour { get => isHour; set => isHour = value; }
        #endregion

        public override string ToString()
        {
            string ret = "Name: " + F_name + ' ' + L_name + @"
                ID: " + ID + @"
                Phone: " + Phone + @"
                Address: " + AddressMother + @"
                Address of nanny: " + AddressNanny + @"
                Days need nanny: " + NannyD();

            return ret;
        }

        private string NannyD()
        {
            string ret = null;
            for (int i = 0; i < 6; i++)
                if (NannyDay[i])
                    ret += '\n' + day(i + 1) + ": " + NannyTime[i, 0] + '-' + NannyTime[i, 1];
            return ret;
        }

        private string day(int num)
        {
            switch (num)
            {
                case 1:
                    return "Sunday";
                case 2:
                    return "Monday";
                case 3:
                    return "Tuseday";
                case 4:
                    return "Wendesday";
                case 5:
                    return "Thursday";
                default:
                    return "Friday";
            }
        }

        private void Check_ID(string id)
        {
            char t;
            for (int i = 0; i < id.Length; i++)
            {
                t = id.ToCharArray()[i];
                if (t < '0' || t > '9')
                    throw new Exception("The ID is invalid!");
            }
            this.id = id;
        }
    }
}
