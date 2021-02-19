﻿using System;
using System.Linq;
using System.Web.Mvc;
using MvcMusicStore.Models;
using MvcMusicStore.ViewModels;
using System.Collections.Generic;
using MusicStore.DiscountEngine;

namespace MvcMusicStore.Controllers
{
    public class ShoppingCartController : Controller
    {
        MusicStoreEntities storeDB = new MusicStoreEntities();

        //
        // GET: /ShoppingCart/

        public ActionResult Index()
        {
            var cart = ShoppingCart.GetCart(this.HttpContext);

            // Set up our ViewModel
            ShoppingCartViewModel viewModel = GetCartTotals(cart);

            // Return the view
            return View(viewModel);
        }

       
        //
        // GET: /Store/AddToCart/5

        public ActionResult AddToCart(int id)
        {

            // Retrieve the album from the database
            var addedAlbum = storeDB.Albums
                .Single(album => album.AlbumId == id);

            // Add it to the shopping cart
            var cart = ShoppingCart.GetCart(this.HttpContext);

            cart.AddToCart(addedAlbum);

           
            // Go back to the main store page for more shopping
            return RedirectToAction("Index");
        }

      

        //
        // AJAX: /ShoppingCart/RemoveFromCart/5

        [HttpPost]
        public ActionResult RemoveFromCart(int id)
        {
            // Remove the item from the cart
            var cart = ShoppingCart.GetCart(this.HttpContext);

            // Get the name of the album to display confirmation
            var album = storeDB.Carts
                .Single(item => item.RecordId == id).Album;
            // Remove from cart
            int itemCount = cart.RemoveFromCart(id);

            var shoppingcartTotals = GetCartTotals(cart);
            // Display the confirmation message
            var results = new ShoppingCartRemoveViewModel
            {
                Message = Server.HtmlEncode(album.Title) +
                    " has been removed from your shopping cart.",
                CartTotal = shoppingcartTotals.CartTotal,
                CartCount = cart.GetCount(),
                ItemCount = itemCount,
                Discount = shoppingcartTotals.Discount,
                DeleteId = id
            };

            

            return Json(results);
        }

        private static ShoppingCartViewModel GetCartTotals(ShoppingCart cart)
        {
            var cartItems = cart.GetCartItems();
            var discountPercentage = Engine.GetDiscountForCartItems(cartItems);
            var totalBeforeDiscount = cart.GetTotal();
            var total = totalBeforeDiscount - ((totalBeforeDiscount / 100) * discountPercentage);
            var viewModel = new ShoppingCartViewModel
            {
                CartItems = cartItems,
                CartTotal = total,
                Discount = discountPercentage
            };
            return viewModel;
        }


        private double GetShoppingbasketTotalRange(ShoppingCart cart)
        {
            return Convert.ToDouble(cart.GetTotal());
        }
        //
        // GET: /ShoppingCart/CartSummary

        [ChildActionOnly]
        public ActionResult CartSummary()
        {
            var cart = ShoppingCart.GetCart(this.HttpContext);

            ViewData["CartCount"] = cart.GetCount();

            return PartialView("CartSummary");
        }


    }


}