using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Restaurant.Areas.Admin.ViewModels
{
    public class MasterSocialMediaModel
    {
        [Key]
        public int MasterSocialMediaId { get; set; }

        public string MasterSocialMediaImageUrl { get; set; } = null!;

        public string MasterSocialMediaUrl { get; set; } = null!;

        public bool? ISActive { get; set; }

        [NotMapped]
        public IFormFile? files { get; set; }

    }
}
