using Restaurant.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Restaurant.Areas.Admin.ViewModels
{
    public class MasterOfferModel
    {
        [Key]
        public int MasterOfferId { get; set; }

        public string? MasterOfferTitle { get; set; }

        public string? MasterOfferBreef { get; set; }

        public string? MasterOfferDesc { get; set; }

        public string? MasterOfferImageUrl { get; set; }
        [NotMapped]
        public IFormFile Files { get; set; }

        public bool? IsActive { get; set; }

    }
}
