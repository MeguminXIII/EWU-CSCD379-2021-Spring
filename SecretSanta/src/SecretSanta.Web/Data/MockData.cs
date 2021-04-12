using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using SecretSanta.Web.ViewModels;

namespace SecretSanta.Web.Data
{
    public static class MockData
    {
        public static List<GroupViewModel> Groups = new List<GroupViewModel>
        {
            new GroupViewModel {GroupName = Users[0].GroupName, Users = new List<UserViewModel>{Users[0], Users[1]}}
        };

        public static List<UserViewModel> Users = new List<UserViewModel>
        {
            new UserViewModel {FirstName = "John", LastName = "Doe", GroupName="Anonymous", UserID=0, Gifts = GiftsList[0]},
            new UserViewModel {FirstName = "Jane", LastName = "Doe", GroupName="Anonymous", UserID=1, Gifts = GiftsList[1]},
        };

        public static Dictionary<int, List<GiftViewModel>> GiftsList = new Dictionary<int, List<GiftViewModel>>
        {
            [0] = new List<GiftViewModel>{
                new GiftViewModel {GiftName = "Coal", GiftDescription="A lump of coal", GiftUrl="https://www.google.com/search?q=lump+of+coal&source=lnms&tbm=isch&sa=X&ved=2ahUKEwjy6dTqqvnvAhX9HzQIHWSzB7IQ_AUoAnoECAEQBA&biw=1536&bih=758&dpr=1.25", GiftPriority = 1, GiftUser = "John Doe"},
                new GiftViewModel {GiftName = "Cookie", GiftDescription="A single, solitary cookie", GiftUrl="https://www.google.com/search?q=cookie&tbm=isch&ved=2ahUKEwjxwMfrqvnvAhUsAjQIHVnmBA4Q2-cCegQIABAA&oq=cookie&gs_lcp=CgNpbWcQAzICCAAyBQgAELEDMgUIABCxAzIECAAQQzIFCAAQsQMyAggAMgUIABCxAzIFCAAQsQMyBQgAELEDMgIIADoICAAQsQMQgwFQyOkMWMHvDGDR8AxoAHAAeACAAY8BiAHkBZIBAzAuNpgBAKABAaoBC2d3cy13aXotaW1nwAEB&sclient=img&ei=QZF0YLGcL6yE0PEP2cyTcA&bih=758&biw=1536", GiftPriority = 1, GiftUser = "John Doe"},
            },

            [1] = new List<GiftViewModel>{
                new GiftViewModel {GiftName = "Red", GiftDescription="It's red?", GiftUrl="https://www.google.com/search?q=red&oq=red&aqs=chrome..69i57j69i59j69i60l6.502j0j9&sourceid=chrome&ie=UTF-8", GiftPriority = 1, GiftUser = "Jane Doe"},
                new GiftViewModel {GiftName = "Blue", GiftDescription="It's blue?", GiftUrl="https://www.google.com/search?q=blue&oq=blue&aqs=chrome..69i57j69i61j5.641j0j9&sourceid=chrome&ie=UTF-8", GiftPriority = 1, GiftUser = "Jane Doe"},
            }
        };

    }
}