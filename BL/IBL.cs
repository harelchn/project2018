using System;
using BE;
using DAL;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public interface IBL
    {
        void Add_Nanny(Nanny n);
        void Remove_Nanny(Nanny n);
        void Update_Nanny(Nanny n);

        void Add_Mother(Mother m);
        void Remove_Mother(Mother m);
        void Update_Mother(Mother m);

        void Add_Child(Child c);
        void Remove_Child(Child c);
        void Update_Child(Child c);

        void Add_Contract(Contract c);
        void Remove_Contract(Contract c);
        void Update_Contract(Contract c);

        List<Nanny> GetNanny();
        List<Mother> GetMother();
        List<Child> GetChild();
        List<Contract> GetContract();
    }
}
