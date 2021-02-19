using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvcMusicStore.Models;

namespace MusicStore.DiscountEngine.UnitTest
{
    [TestClass]
    public class DiscountEngineTests
    {
        //When I buy 2 rock albums we provide a discount of 20%
        [TestMethod]
        public void Buy_Two_Rock_Albums_and_get_20_percent_discount()
        {
            // Arrange
            var items = new List<Cart>();
            Cart cartItem = CreateNewCartItem("Rock", 1M, "Let There Be Rock", 1);
            items.Add(cartItem);
            cartItem = CreateNewCartItem("Rock", 1M, "Fireball", 1);
            items.Add(cartItem);
            // Act
            var discountPercentage = Engine.GetDiscountForCartItems(items);
            // Assert
            Assert.AreEqual(20, discountPercentage);
        }


        //when I buy an album in rock and metal category I get 5% discount,
        //if I have not received any other discounts
        [TestMethod]
        public void Buy_Album_in_rock_and_metal_and_get_5_percent_Discount()
        {
            var items = new List<Cart>();
            Cart cartItem = CreateNewCartItem("Rock", 1M, "Let There Be Rock", 1);
            items.Add(cartItem);
            cartItem = CreateNewCartItem("Metal", 1M, "Faceless", 1);
            items.Add(cartItem);
            // Act
            var discountPercentage = Engine.GetDiscountForCartItems(items);
            // Assert
            Assert.AreEqual(5, discountPercentage);
        }

        [TestMethod]
        public void Buy_four_Albums_in_Metal_and_get_15_percent_discount()
        {
            var items = new List<Cart>();
            Cart cartItem = CreateNewCartItem("Metal", 1M, "Black Sabbath", 2);
            items.Add(cartItem);
            cartItem = CreateNewCartItem("Metal", 1M, "Faceless", 2);
            items.Add(cartItem);
            // Act
            var discountPercentage = Engine.GetDiscountForCartItems(items);
            // Assert
            Assert.AreEqual(15, discountPercentage);

        }

        private static Cart CreateNewCartItem(string genreName, decimal price, string title, int count)
        {
            var genre = new Genre() { Name = genreName };
            var album = new Album() { Price = price, Title = title, Genre = genre };
            var cartItem = new Cart() { Album = album, Count = count };
            return cartItem;
        }
    }
}
