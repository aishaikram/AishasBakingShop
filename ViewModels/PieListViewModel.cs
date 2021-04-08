using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheBakingCentre.Models;

namespace TheBakingCentre.ViewModels
{
    public class PieListViewModel
    {
        public IEnumerable<Pie> Pies { get; set; }
        public string CurrentCategory { get; set; }
    }
}
