using System;
using System.Collections.Generic;
using MvcMusicStore.Models;

namespace MusicStore.DiscountEngine
{
    public class Engine
    {
        public static int GetDiscountForCartItems(List<Cart> items)
        {
            int discount = 0;
            // create business logic here
            int GenreItemCountRock = NumberOfAlbumsInGenre(items, "Rock");
            int GenreItemCountMetal = NumberOfAlbumsInGenre(items, "Metal");
            if (GenreItemCountRock >= 2)
                discount = 20;
            if (GenreItemCountMetal >= 4)
                discount = 15;
            if (GenreItemCountMetal >= 1 && GenreItemCountRock >= 1 && discount == 0)
                discount = 5;
            return discount;
        }

        private static int NumberOfAlbumsInGenre(List<Cart> items, string genre)
        {
            int GenreItemCount = 0;
            foreach (var item in items)
            {
                if (item.Album.Genre.Name == genre)
                    GenreItemCount += item.Count;
            }

            return GenreItemCount;
        }

    }
}
