using System.Collections.Generic;

namespace OrangeBricks.Web.Controllers.Viewings.ViewModels
{
    public class ViewingsViewModel
    {
        public int PropertyId { get; set; }
        public string PropertyType { get; set; }
        public int NumberOfBedrooms { get; set; }
        public string StreetName { get; set; }
        public bool HasViewings { get; set; }
        public IEnumerable<ViewingViewModel> Viewings { get; set; }
    }
}