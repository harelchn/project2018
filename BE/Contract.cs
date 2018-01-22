using System;
using System.Collections.Generic;
using System.Text;

namespace BE
{
    public class Contract
    {
        #region fields
        private static int counter = 1;
        private readonly int num;
        private readonly string idNanny;
        private readonly string idChild;
        private bool isMeet;
        private bool isSigned;
        private double payHour;
        private double salary;
        private bool isHour;
        private DateTime dateBegin;
        private DateTime dateEnd;
        #endregion

        #region constructors
        public Contract(string idN, string idC, bool isM, bool isS, double payH, double sa, bool isH, DateTime dateB, DateTime dateE)
        {
            num = counter++;
            CheckId(idN);
            this.idNanny = idN;
            CheckId(idC);
            this.idChild = idC;
            IsMeet = isM;
            IsSigned = isS;
            PayHour = payH;
            Salary = sa;
            IsHour = isH;
            DateBegin = dateB;
            DateEnd = dateE;
        }

        public Contract()
        {
            num = counter++;
        }
        #endregion

        #region properties
        public int Num => num;

        public string IdNanny => idNanny;

        public string IdChild => idChild;

        public bool IsMeet { get => isMeet; set => isMeet = value; }
        public bool IsSigned { get => isSigned; set => isSigned = value; }
        public double PayHour { get => payHour; set => payHour = value; }
        public double Salary { get => salary; set => salary = value; }
        public bool IsHour { get => isHour; set => isHour = value; }
        public DateTime DateBegin { get => dateBegin; set => dateBegin = value; }
        public DateTime DateEnd
        {
            get => dateEnd;
            set
            {
                if (value <= DateBegin)
                    throw new Exception("'Date of end' can't before 'Date of begin'");
                dateEnd = value;
            }
        }

        public static int Counter { get => counter; set => counter = value; }
        #endregion

        public override string ToString()
        {
            string ret = "Number of contract: " + NumCon() + "\n" +
                "ID of nanny: "+ IdNanny +"\n" +
                "ID of child: "+IdChild+"\n" +
                "Meeting: ";
            if (IsMeet)
                ret += "it was meeting" + '\n';
            else ret += "it wasn't meeting" + '\n';
            ret += "Signing: ";
            if (IsMeet)
                ret += "a contract was signed" + '\n';
            else ret += "no contract was signed" + '\n';
            ret += "Pay per hour: " + PayHour + "\n" +
                "Salary (per month): " + Salary + "\n" +
                "Hourly payment is accepted: " + MyYesNo(IsHour) + "\n" +
                "The beginning of the transaction: " + DateBegin;
            return ret;
        }

        private string MyYesNo(bool t)
        {
            if (t)
                return "Yes";
            return "No";
        }

        private string NumCon()
        {
            string ret = null;
            int temp = Num;
            while(temp < Math.Pow(10, 8))
            {
                ret += '0';
                temp *= 10;
            }
            return ret + Num;
        }

        private void CheckId(string id)
        {
            char t;
            for (int i = 0; i < id.Length; i++)
            {
                t = id.ToCharArray()[i];
                if (t < '0' || t > '9')
                    throw new Exception("ID is invalid!");
            }
        }

    }
}
