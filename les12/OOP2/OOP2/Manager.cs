using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOP2
{
    class Manager : Worker
    {
        public override List<Client> ShowData(List<Client> clients)
        {
            return clients;
        }
    }
}
