using System;

namespace BE
{
    public class Nanny
    {
        #region fields
        private readonly string id;
        private string l_name;
        private string f_name;
        private DateTime birthDate;
        private string phone;
        private string address;
        private bool elevator;
        private int floor;
        private int experience;
        private int maxChild;
        private int minAge;
        private int maxAge;
        private bool isHour;
        private double payHour;
        private double salaryMonth;
        private bool[] workDay = new bool[6];
        private TimeSpan[,] workTime = new TimeSpan[6, 2];
        private bool dayOff_Ed;
        private string[] recomm;
        private bool religious;
        private bool lunch;
        private bool playground;
        #endregion
        public Nanny() { }

        public Nanny(string id, string l, string f, DateTime bD, string ph, string ad, bool el, int fl, int ex, int mC, int miA, int maA, bool isH, double payH, double sa, bool[] workD, TimeSpan[,] workT, bool dayO_Ed, string[] re, bool rel = false, bool lun=true, bool play=false)
        {
            char t;
            for (int i = 0; i < id.Length; i++)
            {
                t = id.ToCharArray()[i];
                if (t < '0' || t > '9')
                    throw new Exception("This ID is invalid!");
            }
            this.id = id;
            L_name = l;
            F_name = f;
            BirthDate = bD;
            Phone = ph;
            Address = ad;
            Elevator = el;
            Floor = fl;
            Experience = ex;
            MaxChild = mC;
            MinAge = miA;
            MaxAge = maA;
            IsHour = isH;
            PayHour = payH;
            SalaryMonth = sa;
            WorkDay = workD;
            WorkTime = workT;
            DayOff_Ed = dayO_Ed;
            Recomm = re;
            Religious = rel;
            Lunch = lun;
            Playground = play;
        }

        #region properties
        public string ID => id;

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
        public string Address
        {
            get => address;
            set
            {
                check_Address(value);
                address = value;
            }
        }
        public bool Elevator { get => elevator; set => elevator = value; }
        public int Floor { get => floor; set => floor = value; }
        public int Experience
        {
            get => experience;
            set
            {
                if (value > Age())
                    throw new Exception("'Experience' can't be bigger than 'Birth date'!");
                experience = value;
            }
        }
        public int MaxChild
        {
            get => maxChild;
            set
            {
                if (value < 1)
                    throw new Exception("'Maximum number of children' can't be smaller than 1!");
                maxChild = value;
            }
        }
        public int MinAge { get => minAge; set => minAge = value; }
        public int MaxAge
        {
            get => maxAge;
            set
            {
                if (value < MinAge)
                    throw new Exception("'Maximum age of child' can't be smaller than 'Minimum age of child'!");
                maxAge = value;
            }
        }
        public bool IsHour { get => isHour; set => isHour = value; }
        public double PayHour
        {
            get => payHour;
            set
            {
                if (value < 0)
                    throw new Exception("'Pay per hour' can't be smaller than 0!");
                payHour = value;
            }
        }
        public double SalaryMonth
        {
            get => salaryMonth;
            set
            {
                if (value < 0)
                    throw new Exception("'Salary' can't be smaller than 0!");
                salaryMonth = value;
            }
        }
        public bool[] WorkDay { get => workDay; set => workDay = value; }
        public TimeSpan[,] WorkTime { get => workTime; set => workTime = value; }
        public bool DayOff_Ed { get => dayOff_Ed; set => dayOff_Ed = value; }
        public string[] Recomm { get => recomm; set => recomm = value; }
        public bool Religious { get => religious; set => religious = value; }
        public bool Lunch { get => lunch; set => lunch = value; }
        public bool Playground { get => playground; set => playground = value; }
        #endregion

        public override string ToString()
        {
            string ret = "Name: " + F_name + ' ' + L_name + @"
                ID: " + ID + @"
                Age: " + Age() + @"
                Phone: " + Phone + @"
                Address: " + Address + @"
                Elevator: " + MyYesNo(Elevator) + @"
                Floor: " + Floor + @"
                Experience: " + Experience + @"
                Max number of children: " + MaxChild + @"
                Max age: " + MaxAge + @"
                Min age: " + MinAge + @"
                Pay per hour: " + MyYesNo(IsHour);
            if (IsHour)
                ret += ", " + PayHour;
            ret += @"
                Monthly salary: " + SalaryMonth + @"
                Working days: " + WorkD() + @"
                Day off from: " + D_Off() + @"
                Religious: " + MyYesNo(Religious) + @"
                Lunch: " + MyYesNo(Lunch) + @"
                Playground nearby : " + MyYesNo(Playground) + @"
                Recommendations: " + Recommends();

            return ret;
        }

        private string Recommends()
        {
            string ret = null;
            for (int i = 0; i < Recomm.Length; i++)
                ret += '\n' + i + ":   " + Recomm[i];
            return ret;
        }

        private string D_Off()
        {
            if (DayOff_Ed)
                return "Ministry of Education";
            return "Ministry of Industry and Trade";
        }

        private string WorkD()
        {
            string ret = null;
            for (int i = 0; i < 6; i++)
            {
                if (WorkDay[i])
                    ret += '\n' + day(i + 1) + ": " + WorkTime[i, 0] + '-' + WorkTime[i, 1];
            }
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

        private string MyYesNo(bool t)
        {
            if (t)
                return "Yes";
            return "No";
        }

        public int Age()
        {
            if (BirthDate.Month < DateTime.Now.Month
                || BirthDate.Month == DateTime.Now.Month && BirthDate.Day <= DateTime.Now.Day)
                return DateTime.Now.Year - BirthDate.Year;
            return DateTime.Now.Year - BirthDate.Year - 1;
        }

        private void check_Address(string value)
        {
            int counter = 0;
            char[] check = value.ToCharArray();
            for (int i = 0; i < check.Length; i++)
            {
                if (check[i] == ',')
                    counter++;
                else if (check[i] < 'A' || check[i] > 'Z' && check[i] < 'a' || check[i] > 'z')
                    throw new Exception("The address is invalid!");
            }
            if (counter != 2)
                throw new Exception("The address is invalid!");
        }

    }
}
