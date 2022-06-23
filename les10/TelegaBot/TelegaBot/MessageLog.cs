using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegaBot
{
  public struct MessageLog
  {
    public DateTime Time { get; set; }

    public long Id { get; set; }

    public string Msg { get; set; }

    public string FirstName { get; set; }

    public MessageLog(DateTime Time, long Id, string Msg, string FirstName)
    {
      this.Time = Time;
      this.Id = Id;
      this.Msg = Msg;
      this.FirstName = FirstName;
    }
  }
}
