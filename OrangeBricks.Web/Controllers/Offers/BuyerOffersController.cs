using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using OrangeBricks.Web.Attributes;
using OrangeBricks.Web.Controllers.Offers.Builders;
using OrangeBricks.Web.Controllers.Offers.ViewModels;
using OrangeBricks.Web.Models;

namespace OrangeBricks.Web.Controllers.Offers
{
    [OrangeBricksAuthorize(Roles = "Buyer")]
    public class BuyerOffersController : Controller
    {
        private readonly IOrangeBricksContext _context;

        public BuyerOffersController(IOrangeBricksContext context)
        {
            _context = context;
        }

        public ActionResult MyOffers()
        {
            MyOffersViewModelBuilder builder = new MyOffersViewModelBuilder(_context);
            string buyerId = User.Identity.GetUserId();
            MyOffersViewModel viewModel = builder.Build(buyerId);
            return View(viewModel);
        }
    }
}