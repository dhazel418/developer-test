using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using OrangeBricks.Web.Controllers.Offers.ViewModels;
using OrangeBricks.Web.Models;

namespace OrangeBricks.Web.Controllers.Offers.Builders
{
    public class MyOffersViewModelBuilder
    {
        private readonly IOrangeBricksContext _context;

        public MyOffersViewModelBuilder(IOrangeBricksContext context)
        {
            _context = context;
        }

        public MyOffersViewModel Build(string buyerId)
        {
            List<MyOfferViewModel> offers = _context.Properties
                .AsNoTracking()
                .Include(a => a.Offers)
                .SelectMany(b => b.Offers, (p, o) => new { Prop = p, Offr = o})
                .Where(c => c.Offr.BuyerUserId == buyerId)
                .Select(d => new MyOfferViewModel
                {
                    PropertyId = d.Prop.Id,
                    StreetName = d.Prop.StreetName,
                    PropertyType = d.Prop.PropertyType,
                    Amount = d.Offr.Amount,
                    CreatedAt = d.Offr.CreatedAt,
                    Status = d.Offr.Status.ToString()
                })
                .ToList();

            return new MyOffersViewModel
            {
                Offers = offers
            };
        }
    }
}