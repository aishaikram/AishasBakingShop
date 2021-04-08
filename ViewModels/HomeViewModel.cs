using TheBakingCentre.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheBakingCentre.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Pie> PiesofTheWeek { get; set; }
    }
}
