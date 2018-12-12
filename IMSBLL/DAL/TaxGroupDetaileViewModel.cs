using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMSBLL.DAL
{
    public class TaxGroupDetaileViewModel
    {
        public int groupId { get; set; }
        public int typeId { get; set; }
        public int taxdetailId { get; set; }
        public decimal? taxPercentage { get; set; }
        public string groupName { get; set; }
        public string typeName { get; set; }
    }
}
