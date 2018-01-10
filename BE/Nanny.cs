using System;

namespace BE
{
    public class Nanny
    {
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

        public Nanny(string id, string l, string f, DateTime bD, string ph, string ad, bool el, int fl, int ex, int mC, int miA, int maA, bool isH, double payH, double sa, bool[] workD, TimeSpan[,] workT, bool dayO_Ed, string[] re, bool rel = false, bool lun=true, bool play=false)
        {
            char t;
            for (int i = 0; i < id.Length; i++)
            {
                t = id.ToCharArray()[i];
                if (t < '0' || t > '9')
                    throw;
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
                        throw;
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
                        throw;
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
                    throw;
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
                        throw;
                }
                phone = value;
            }
        }
        public string Address
        {
            get => address;
            set
            {
                char t;
                string[] check = value.Split(',', ' ');
                for (int i = 0; i < check.Length; i++)
                {
                    for (int j = 0; j < check[i].Length; ++j)
                    {
                        t = value.ToCharArray()[j];
                        if (t < 'A' || t > 'Z' && t < 'a' || t > 'z')
                            throw;
                    }
                }
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
                    throw;
                experience = value;
            }
        }
        public int MaxChild
        {
            get => maxChild;
            set
            {
                if (value < 1)
                    throw;
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
                    throw;
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
                    throw;
                payHour = value;
            }
        }
        public double SalaryMonth
        {
            get => salaryMonth;
            set
            {
                if (value < 0)
                    throw;
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

        private int Age()
        {
            if (BirthDate.Month > DateTime.Now.Month)
                return DateTime.Now.Year - BirthDate.Year;
            if (BirthDate.Month == DateTime.Now.Month && BirthDate.Day >= DateTime.Now.Day)
                return DateTime.Now.Year - BirthDate.Year;
            return DateTime.Now.Year - BirthDate.Year - 1;
        }
    }
}
