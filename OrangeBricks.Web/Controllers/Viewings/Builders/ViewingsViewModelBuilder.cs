using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using OrangeBricks.Web.Controllers.Viewings.ViewModels;
using OrangeBricks.Web.Models;

namespace OrangeBricks.Web.Controllers.Viewings.Builders
{
    public class ViewingsViewModelBuilder
    {
        private readonly IOrangeBricksContext _context;

        public ViewingsViewModelBuilder(IOrangeBricksContext context)
        {
            _context = context;
        }

        public ViewingsViewModel Build(int id)
        {
            var property = _context.Properties
                .AsNoTracking()
                .Where(p => p.Id == id)
                .Include(b => b.Viewings)
                .SingleOrDefault();

            if (property != null)
            {
                var viewings = property.Viewings ?? new List<Viewing>();
                return new ViewingsViewModel
                {
                    PropertyId = property.Id,
                    PropertyType = property.PropertyType,
                    NumberOfBedrooms = property.NumberOfBedrooms,
                    StreetName = property.StreetName,
                    HasViewings = viewings.Any(),
                    Viewings = viewings.Select(a => new ViewingViewModel
                    {
                        Id = a.Id,
                        RequestedDate = a.RequestedDateTime.Date,
                        RequestedTime = a.RequestedDateTime,
                        IsRequested = a.ViewingStatus == ViewingStatus.Requested,
                        Status = a.ViewingStatus.ToString()
                    })
                };
            }

            return new ViewingsViewModel();
        }
    }
}