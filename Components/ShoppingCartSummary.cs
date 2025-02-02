﻿using TheBakingCentre.Models;
using TheBakingCentre.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheBakingCentre.Components
{
    public class ShoppingCartSummary : ViewComponent

    {
        private readonly ShoppingCart _shoppingCart;
        public ShoppingCartSummary(ShoppingCart shoppingCart)
        {
            _shoppingCart = shoppingCart;
        }
        //viewcomponent return type is IViewComponentResult which is specific to View Component
        
        public IViewComponentResult Invoke()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;

            var shoppingCartViewModel = new ShoppingCartViewModel
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotalAmount = _shoppingCart.GetShoppingCartTotalAmount()
                
            };

            return View(shoppingCartViewModel);
        }
    }
}
