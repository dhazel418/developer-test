using System;
using System.ComponentModel.DataAnnotations;

namespace OrangeBricks.Web.Models
{
    public class Viewing
    {
        [Key]
        public int Id { get; set; }

        public DateTime RequestedDateTime { get; set; }

        public ViewingStatus ViewingStatus { get; set; }

        [Required]
        public string BuyerUserId { get; set; }
    }
}