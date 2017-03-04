using System;
using System.Collections.Generic;
using OrangeBricks.Web.Models;

namespace OrangeBricks.Web.Controllers.Property.Commands
{
    public class MakeOfferCommandHandler
    {
        private readonly IOrangeBricksContext _context;

        public MakeOfferCommandHandler(IOrangeBricksContext context)
        {
            _context = context;
        }

        public void Handle(MakeOfferCommand command, string buyerId)
        {
            var property = _context.Properties.Find(command.PropertyId);

            if (property != null)
            {
                var offer = new Offer
                {
                    Amount = command.Offer,
                    Status = OfferStatus.Pending,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    BuyerUserId = buyerId
                };

                if (property.Offers == null)
                {
                    property.Offers = new List<Offer>();
                }

                property.Offers.Add(offer);

                _context.SaveChanges();
            }
        }
    }
}