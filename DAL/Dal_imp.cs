using System;
using BE;
using DS;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Dal_imp : Idal
    {
        #region nanny
        public void Add_Nanny(Nanny n)
        {
            foreach (Nanny item in DataSource.Nannies)
                if (item.ID == n.ID)
                    throw new Exception("This Nanny has already entered!");
            DataSource.Nannies.Add(n);
        }
        public void Remove_Nanny(Nanny n)
        {
            bool check = true;
            foreach (Nanny item in DataSource.Nannies)
                if (item.ID == n.ID)
                    check = false;
            if (check)
                throw new Exception("This Nanny does not exist!");
            DataSource.Nannies.Remove(n);
        }
        public void Update_Nanny(Nanny n)
        {
            Remove_Nanny(n);
            Add_Nanny(n);
        }
        #endregion
        #region mother
        public void Add_Mother(Mother m)
        {
            foreach (Mother item in DataSource.Mothers)
                if (item.ID == m.ID)
                    throw new Exception("This mother has already entered!");
            DataSource.Mothers.Add(m);
        }
        public void Remove_Mother(Mother m)
        {
            bool check = true;
            foreach (Mother item in DataSource.Mothers)
                if (item.ID == m.ID)
                    check = false;
            if (check)
                throw new Exception("This nanny does not exist!");
            DataSource.Mothers.Remove(m);
        }
        public void Update_Mother(Mother m)
        {
            Remove_Mother(m);
            Add_Mother(m);
        }
        #endregion
        #region child
        public void Add_Child(Child c)
        {
            foreach (Child item in GetChild())
                if (item.IdC == c.IdC)
                    throw new Exception("This child has already entered!");
            DataSource.Children.Add(c);
        }
        public void Remove_Child(Child c)
        {
            bool check = true;
            foreach (Child item in DataSource.Children)
                if (item.IdC == c.IdC)
                    check = false;
            if (check)
                throw new Exception("This child does not exist");
            DataSource.Children.Remove(c);
        }
        public void Update_Child(Child c)
        {
            Remove_Child(c);
            Add_Child(c);
        }
        #endregion
        #region contract
        public void Add_Contract(Contract c)
        {
            foreach (Contract item in DataSource.Contracts)
                if (item.Num == c.Num)
                    throw new Exception("This contract has already entered!");
            DataSource.Contracts.Add(c);
        }
        public void Remove_Contract(Contract c)
        {
            bool check = true;
            foreach (Contract item in DataSource.Contracts)
                if (item.Num == c.Num)
                    check = false;
            if (check)
                throw new Exception("This contract does not exist!");
            DataSource.Contracts.Remove(c);
        }
        public void Update_Contract(Contract c)
        {
            Remove_Contract(c);
            Add_Contract(c);
        }
        #endregion
        #region gets
        public List<Nanny> GetNanny() =>(from n in DataSource.Nannies
                                                orderby n.ID
                                                select n).ToList();
        public List<Mother> GetMother() =>(from m in DataSource.Mothers
                                                  orderby m.ID
                                                  select m).ToList();
        public List<Child> GetChild() => (from c in DataSource.Children
                                                 orderby c.IdC
                                                 select c).ToList();
        public List<Contract> GetContract() => (from c in DataSource.Contracts
                                                       orderby c.Num
                                                       select c).ToList();
        #endregion
    }
}
