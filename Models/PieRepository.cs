using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheBakingCentre.Models
{
    // A cllas to connect to the underlying data source class/data context/EF Core class
    public class PieRepository :IPieRepository
    {
        private readonly AppDbContext _appDbContext;
        // ad db context is already registered as service, we can inject in the constructor
        public PieRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        //AllPies is the property of the interface
        public IEnumerable<Pie> AllPies => _appDbContext.Pies.Include(c => c.Category);
           

        public IEnumerable<Pie> PiesOfTheWeek
        {
            get
            {
                return _appDbContext.Pies.Include(c => c.Category).Where(p => p.IsPieOfTheWeek);
            }
        }

        public Pie GetPieById(int pieId)
        {
            return _appDbContext.Pies.FirstOrDefault(p => p.PieId == pieId);


        }
    }
}
