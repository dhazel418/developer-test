using System;
using System.ComponentModel.DataAnnotations;

namespace OrangeBricks.Web.Controllers.Property.ViewModels
{
    public class BookViewingViewModel
    {
        public int PropertyId { get; set; }
        public string PropertyType { get; set; }
        public string StreetName { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "dd/MM/yyyy", ApplyFormatInEditMode = true)]
        public DateTime? RequestedDate { get; set; }

        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "HH:mm", ApplyFormatInEditMode = true)]
        public DateTime? RequestedTime { get; set; }
    }
}