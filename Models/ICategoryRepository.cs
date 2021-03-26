using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AishasBakingShop.Models
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> AllCategories { get; }
    }
}
