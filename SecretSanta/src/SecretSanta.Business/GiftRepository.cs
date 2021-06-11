using System.Collections.Generic;
using SecretSanta.Data;

namespace SecretSanta.Business
{
    public class GiftRepository : IGiftRepository
    {



        public ICollection<Gift> List()
        {
            using DbContext dbContext = new DbContext();
            List<Gift> giftsList = new List<Gift>();
            foreach (var gift in dbContext.Gifts)
            {
                giftsList.Add(gift);
            }
            return giftsList;
        }

        public Gift? GetItem(int id)
        {
            using DbContext dbContext = new DbContext();
            Gift gift = dbContext.Gifts.Find(id);
            return gift;
        }

        public bool Remove(int id)
        {
            try
            {
                using DbContext dbContext = new DbContext();
                Gift item = dbContext.Gifts.Find(id);
                dbContext.Gifts.Remove(item);
                dbContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public Gift Create(Gift item)
        {
            if (item is null)
            {
                throw new System.ArgumentNullException(nameof(item));
            }
            using DbContext dbContext = new DbContext();
            dbContext.Gifts.Add(item);
            dbContext.SaveChangesAsync();
            return item;
        }

        public void Save(Gift item)
        {
            if (item is null)
            {
                throw new System.ArgumentNullException(nameof(item));
            }
            using DbContext dbContext = new DbContext();

            Gift temp = dbContext.Gifts.Find(item.Id);
            if (temp is null)
            {
                Create(item);
            }
            else
            {
                dbContext.Gifts.Remove(dbContext.Gifts.Find(item.Id));
                dbContext.Gifts.Add(item);
            }
            dbContext.SaveChangesAsync();
        }
    }
}