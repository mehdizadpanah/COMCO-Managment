using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SH.Data.ModelVM.Authentication
{
    public class SessionVM
    {
            public Guid ID { get; set; }
            public string TokenID { get; set; }
            public DateTime ExpiryDate { get; set; }
            public string UserName { get; set; }
            public string IP { get; set; }
            public string barInfo { get; set; }

        
    }
}
