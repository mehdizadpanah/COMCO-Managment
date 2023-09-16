using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SH.Data.Model
{
    public class ProgramUserVM
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime ExpireTime { get; set; }
    }
}
