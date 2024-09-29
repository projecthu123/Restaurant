using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Restaurant.Areas.Admin.ViewModels
{
    public class MasterPartnerModel
    {
        [Key]
        public int MasterPartnerId { get; set; }

        public string? MasterPartnerName { get; set; }

        public string? MasterPartnerLogoImageUrl { get; set; }

        public string? MasterPartnerWebsiteUrl { get; set; }

        [NotMapped]
        public IFormFile? files { get; set; }

        public bool? IsActive { get; set; }
    }
}
