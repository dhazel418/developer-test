using System;
using System.Collections.Generic;
using OrangeBricks.Web.Models;

namespace OrangeBricks.Web.Controllers.Property.Commands
{
    public class BookViewingCommandHandler
    {
        private readonly IOrangeBricksContext _context;

        public BookViewingCommandHandler(IOrangeBricksContext context)
        {
            _context = context;
        }

        public void Handle(BookViewingCommand command, string buyerId)
        {
            var property = _context.Properties.Find(command.PropertyId);

            DateTime requestedDateTime = new DateTime(command.RequestedDate.Year, 
                                                      command.RequestedDate.Month, 
                                                      command.RequestedDate.Day, 
                                                      command.RequestedTime.Hour, 
                                                      command.RequestedTime.Minute, 
                                                      0);
            var viewing = new Viewing
            {
                RequestedDateTime = requestedDateTime,
                BuyerUserId = buyerId
            };

            if (property.Viewings == null)
            {
                property.Viewings = new List<Viewing>();
            }

            property.Viewings.Add(viewing);

            _context.SaveChanges();
        }
    }
}