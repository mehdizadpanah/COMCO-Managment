using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SH.Data.ModelVM
{
    public  class DefaultModelVm
    {
        public ProgramUserVm Creator { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public ProgramUserVm UpdatedBy { get; set; }

    }
}
