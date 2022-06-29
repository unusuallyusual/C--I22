using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TelegaBot
{
  public struct MessageLog
  {
    public string time { get; set; }

    public string id { get; set; }

    public string message { get; set; }

    public string firstName { get; set; }

    public MessageLog(string time, string id, string message, string firstName)
    {
      this.time = time;
      this.id = id;
      this.message = message;
      this.firstName = firstName;
    }
  }
}
