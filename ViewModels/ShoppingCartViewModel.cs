﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheBakingCentre.Models;

namespace TheBakingCentre.ViewModels
{
    public class ShoppingCartViewModel
    {
        public ShoppingCart ShoppingCart { get; set; }
        public int ShoppingCartTotalAmount { get; set; }
        public decimal ShoppingCartTotalPrice { get; set; }

    }
}