using System;
using BE;
using DAL;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoogleMapsApi;
using GoogleMapsApi.Entities.Directions.Request;
using GoogleMapsApi.Entities.Directions.Response;

namespace BL
{
    public class BL_imp : IBL
    {
        #region fields
        private Dal_imp dal = new Dal_imp();
        public delegate bool ConCond (Contract c);
        #endregion
        #region nanny
        public void Add_Nanny(Nanny n)
        {
            if (n.Age() < 18)
                throw new Exception("nanny can't be younger than 18");
            dal.Add_Nanny(n);
        }
        public void Remove_Nanny(Nanny n)
        {
            dal.Remove_Nanny(n);
        }
        public void Update_Nanny(Nanny n)
        {
            if (n.Age() < 18)
                throw new Exception("nanny can't be younger than 18");
            dal.Update_Nanny(n);
        }
        #endregion
        #region mother
        public void Add_Mother(Mother m)
        {
            dal.Add_Mother(m);
        }
        public void Remove_Mother(Mother m)
        {
            dal.Remove_Mother(m);
        }
        public void Update_Mother(Mother m)
        {
            dal.Update_Mother(m);
        }
        #endregion
        #region child
        public void Add_Child(Child c)
        {
            dal.Add_Child(c);
        }
        public void Remove_Child(Child c)
        {
            dal.Remove_Child(c);
        }
        public void Update_Child(Child c)
        {
            dal.Update_Child(c);
        }
        #endregion
        #region contract
        public void Add_Contract(Contract c)
        {
            int counter = 0;
            Child child = dal.GetChild().Find(x => x.IdC == c.IdChild);
            Nanny nanny = dal.GetNanny().Find(x => x.ID == c.IdNanny);
            Mother mother = dal.GetMother().Find(x => x.ID == child.IdM);
            double pay = nanny.SalaryMonth;

            child.BirthDate.AddMonths(3);
            if (child.BirthDate > DateTime.Now)
                throw new Exception("child can't be older than 3 months");

            foreach (Contract cont in GetContract())
            {
                if (cont.IdNanny == c.IdNanny)
                    counter++;
            }
            if (counter >= nanny.MaxChild)
                throw new Exception("This nanny is fully booked!");

            c.IsHour = (mother.IsHour && nanny.IsHour);
            counter = 0;
            foreach (Contract cont in GetContract())
            {
                string idM = dal.GetChild().Find(x => x.IdC == cont.IdChild).IdM;
                if (cont.IdNanny == nanny.ID && idM == mother.ID)
                    counter++;
            }
            if (c.IsHour)
            {
                c.PayHour = nanny.PayHour;
                double time = 0;
                for (int i = 0; i < 6; i++)
                    if (mother.NannyDay[i])
                    {
                        time += (mother.NannyTime[i, 1] - mother.NannyTime[i, 0]).Hours;
                        time += (mother.NannyTime[i, 1] - mother.NannyTime[i, 0]).Minutes / 60;
                    }
                time *= 4;
                pay = time * nanny.PayHour;
            }
            else pay = nanny.SalaryMonth;

            c.Salary = pay - pay * (counter) * 0.2;

            dal.Add_Contract(c);
        }
        public void Remove_Contract(Contract c)
        {
            dal.Remove_Contract(c);
        }
        public void Update_Contract(Contract c)
        {
            Remove_Contract(c);
            Add_Contract(c);
        }
        #endregion
        #region functions
        public static int CalculateDistance(string source, string dest)
        {
            var drivingDirectionRequest = new DirectionsRequest
            {
                TravelMode = TravelMode.Walking,
                Origin = source,
                Destination = dest,
            };
            DirectionsResponse drivingDirections = GoogleMaps.Directions.Query(drivingDirectionRequest);
            Route route = drivingDirections.Routes.First();
            Leg leg = route.Legs.First();
            return leg.Distance.Value;
        }

        public List<Nanny> AptNannies (Mother m)
        {
            List<List<int>> degree = new List<List<int>>();
            for (int i = 0; i < 6; i++)
                degree.Add(new List<int>());

            List<Nanny> nans = new List<Nanny>();
            for (int j=0; j < GetNanny().Count; ++j)
            {
                int i;
                for (i = 0; i < 6; i++)
                {
                    if (m.NannyDay[i] && !GetNanny()[j].WorkDay[i])
                        break;
                    if (GetNanny()[j].WorkTime[i, 0] > m.NannyTime[i, 0] 
                        || GetNanny()[j].WorkTime[i, 1] > m.NannyTime[i, 1])
                        break;
                }
                if (i == 6)
                    nans.Add(GetNanny()[j]);
                else degree[i].Add(j);
            }
            if (nans.Count == 0)
                return Apt2(degree);
            return nans;
        }

        public List<Nanny> Close(Mother m, double dist)
        {
            List<Nanny> nans = new List<Nanny>();
            foreach (Nanny n in GetNanny())
            {
                if (m.AddressNanny != null
                    && CalculateDistance(m.AddressNanny, n.Address) <= dist)
                    nans.Add(n);
                else if (m.AddressMother != null
                    && CalculateDistance(n.Address, m.AddressMother) <= dist)
                    nans.Add(n);
            }
            return nans;
        }

        public List<Child> WithoutN()
        {
            List<Child> children = new List<Child>();
            foreach (Child ch in GetChild())
            {
                bool flag = true;
                foreach (Contract con in GetContract())
                    if (ch.IdC == con.IdChild)
                        flag = false;
                if (flag)
                    children.Add(ch);
            }
            return children;
        }

        public List<Nanny> IDT_Nans() => (from n in GetNanny()
                                          where !n.DayOff_Ed
                                          select n).ToList();

        public List<Contract> Contract_Cond(ConCond Is)=> (from c in GetContract()
                                                           where Is(c)
                                                           select c).ToList();

        public int Count_Contract_Cond(ConCond Is) { return Contract_Cond(Is).Count; }

        public IEnumerable<IGrouping<int, Nanny>> GroupBy_AgeChild(bool max, bool order = false)
        {
            if (max)
            { 
                if (order)
                {
                    var nans = from n in GetNanny()
                               orderby n.MaxAge / 3
                               group n by n.MaxAge / 3;
                    return nans;
                }
                else
                {
                    var nans = from n in GetNanny()
                               group n by n.MaxAge / 3;
                    return nans;
                }
            }
            if (order)
            {
                var nans = from n in GetNanny()
                           orderby n.MinAge / 3
                           group n by n.MinAge / 3;
                return nans;
            }
            else
            {
                var nans = from n in GetNanny()
                           group n by n.MaxAge / 3;
                return nans;
            }
        }

        public IEnumerable<IGrouping<int, Contract>> GroupBy_Distance(bool order = false)
        {
            if (order)
            {
                var cons = from c in GetContract()
                           orderby CalculateDistance(FindAddress_M(c), FindAddress_N(c))
                           group c by CalculateDistance(FindAddress_M(c), FindAddress_N(c));
                return cons;
            }
            else
            {
                var cons = from c in GetContract()
                           group c by CalculateDistance(FindAddress_M(c), FindAddress_N(c));
                return cons;
            }
        }

        private string FindAddress_M(Contract c)
        {
            return GetMother().Find(x => x.ID == GetChild().Find(y => y.IdC == c.IdChild).IdM).AddressMother;
        }

        private string FindAddress_N(Contract c)
        {
            return GetNanny().Find(x => x.ID == c.IdNanny).Address;
        }

        private List<Nanny> Apt2(List<List<int>> degree)
        {
            int t;
            List<Nanny> nans = new List<Nanny>();
            for (int i = 0; i < 5; i++)
            {
                t = degree.Count - 1;
                nans.Add(GetNanny()[degree[t][0]]);
                if (degree[t].Count == 0)
                    degree.RemoveAt(t--);
                degree[t].RemoveAt(0);
            }
            return nans;
        }
        #endregion
        #region gets
        public List<Nanny> GetNanny() { return dal.GetNanny(); }
        public List<Mother> GetMother() { return dal.GetMother(); }
        public List<Child> GetChild() { return dal.GetChild(); }
        public List<Contract> GetContract() { return dal.GetContract(); }
        #endregion
    }
}
