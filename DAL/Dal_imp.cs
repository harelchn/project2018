using System;
using BE;
using DS;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    class Dal_imp : Idal
    {
        //Dal_imp data = new Dal_imp();
        
        public void Add_Nanny(Nanny n)
        {
            foreach (Nanny item in DataSource.Nannies)
                if (item.ID == n.ID)
                    throw Exception;
            DataSource.Nannies.Add(n);
        }
        public void Remove_Nanny(Nanny n)
        {
            bool check = true;
            foreach (Nanny item in DataSource.Nannies)
                if (item.ID == n.ID)
                    check = false;
            if (check)
                throw Exception;
            DataSource.Nannies.Remove(n);
        }
        public void Update_Nanny(Nanny n){}

        public void Add_Mother(Mother m)
        {
            foreach (Mother item in DataSource.Mothers)
                if (item.ID == m.ID)
                    throw Exception;
            DataSource.Mothers.Add(m);
        }
        public void Remove_Mother(Mother m)
        {
            bool check = true;
            foreach (Mother item in DataSource.Mothers)
                if (item.ID == m.ID)
                    check = false;
            if (check)
                throw Exception;
            DataSource.Mothers.Remove(m);
        }
        public void Update_Mother(Mother m){}

        public void Add_Child(Child c)
        {
            foreach (Child item in DataSource.Children)
                if (item.IdC == c.IdC)
                    throw Exception;
            DataSource.Children.Add(c);
        }
        public void Remove_Child(Child c)
        {
            bool check = true;
            foreach (Child item in DataSource.Children)
                if (item.IdC == c.IdC)
                    check = false;
            if (check)
                throw Exception;
            DataSource.Children.Remove(c);
        }
        public void Update_Child(Child c){}

        public void Add_Contract(Contract c)
        {
            foreach (Contract item in DataSource.Contracts)
                if (item.Num == c.Num)
                    throw Exception;
            DataSource.Contracts.Add(c);
        }
        public void Remove_Contract(Contract c)
        {
            bool check = true;
            foreach (Contract item in DataSource.Contracts)
                if (item.Num == c.Num)
                    check = false;
            if (check)
                throw Exception;
            DataSource.Contracts.Remove(c);
        }
        public void Update_Contract(Contract c){}

        public List<Nanny> GetNanny(){ return DataSource.Nannies; }
        public List<Mother> GetMother(){ return DataSource.Mothers; }
        public List<Child> GetChild(){ return DataSource.Children; }
        public List<Contract> GetContract(){ return DataSource.Contracts; }
    }
}
