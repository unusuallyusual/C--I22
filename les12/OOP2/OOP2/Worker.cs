using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP2
{
  abstract class Worker
  {
    public abstract List<Client> ShowData(List<Client> clients);
  }
}
