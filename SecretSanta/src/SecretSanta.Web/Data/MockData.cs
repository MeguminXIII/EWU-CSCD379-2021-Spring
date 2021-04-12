using System.Collections.Generic;
using SecretSanta.Web.ViewModels;

namespace SecretSanta.Web.Data
{
    public static class MockData
    {
        public static List<GiftViewModel> Gifts = new List<GiftViewModel>{
            new GiftViewModel{Id = 0, Title = "Lootbox", Description = "Let your friends know that you would rather leave their gift up to chance rather than give a bad gift.", Url="https://www.ea.com", Priority = 4, UserId = 0},
            new GiftViewModel{Id = 1, Title = "Giftcard", Description = "For when you either dont know your friend enough. Or know them a little too well.", Url="http://NotASketchyShop.com.", Priority = 1, UserId = 1}
        };


        public static List<UserViewModel> Users = new List<UserViewModel>{
            new UserViewModel{Id = 0, FirstName = "Rob", LastName = "Boss"},
            new UserViewModel{Id = 1, FirstName = "Rick", LastName= "Vames"}
        };
    }
}