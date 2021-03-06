﻿using OrangeBricks.Web.Models;

namespace OrangeBricks.Web.Controllers.Viewings.Commands
{
    public class AcceptViewingCommandHandler
    {
        private readonly IOrangeBricksContext _context;

        public AcceptViewingCommandHandler(IOrangeBricksContext context)
        {
            _context = context;
        }

        public void Handle(AcceptViewingCommand command)
        {
            var viewing = _context.Viewings.Find(command.ViewingId);
            if (viewing != null)
            {
                viewing.ViewingStatus = ViewingStatus.Accepted;
                _context.SaveChanges();
            }
        }
    }
}