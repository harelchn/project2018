using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace DS
{
    public class DataSource
    {
        private static List<Nanny> nannies = new List<Nanny>();
        private static List<Mother> mothers = new List<Mother>();
        private static List<Child> children = new List<Child>();
        private static List<Contract> contracts = new List<Contract>();

        public static List<Nanny> Nannies { get => nannies; set => nannies = value; }
        public static List<Mother> Mothers { get => mothers; set => mothers = value; }
        public static List<Child> Children { get => children; set => children = value; }
        public static List<Contract> Contracts { get => contracts; set => contracts = value; }
    }
}
