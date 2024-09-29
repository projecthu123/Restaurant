using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Restaurant.Areas.Admin.ViewModels
{
    public class SystemSettingModel
    {
        [Key]
        public int SystemSettingId { get; set; }

        public string? SystemSettingLogoImageUrl { get; set; }

        public string? SystemSettingLogoImageUrl2 { get; set; }

        public string? SystemSettingCopyright { get; set; }

        public string? SystemSettingWelcomeNoteTitle { get; set; }

        public string? SystemSettingWelcomeNoteBreef { get; set; }

        public string? SystemSettingWelcomeNoteDesc { get; set; }

        public string? SystemSettingWelcomeNoteUrl { get; set; }

        public string? SystemSettingWelcomeNoteImageUrl { get; set; }

        public string? SystemSettingMapLocation { get; set; }

        public string? Icon { get; set; }
        public bool? IsActive { get; set; }

        [NotMapped]
        public IFormFile? files1 { get; set; }
        [NotMapped]
        public IFormFile? files2 { get; set; }

        [NotMapped]
        public IFormFile? files3 { get; set; }

    }
}

