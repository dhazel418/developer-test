using System;

namespace OrangeBricks.Web.Controllers.Viewings.ViewModels
{
    public class ViewingViewModel
    {
        public int Id;
        public DateTime RequestedDate { get; set; }
        public DateTime RequestedTime { get; set; }
        public bool IsRequested { get; set; }
        public string Status { get; set; }
    }
}