using System.ComponentModel.DataAnnotations;

namespace Restaurant.Areas.Admin.ViewModels
{
    public class MasterContactUsInformationModel
    {
        [Key]
        public int MasterContactUsInformationId { get; set; }
        [Required(ErrorMessage = "Fill")]
        public string? MasterContactUsInformationIdesc { get; set; }
        [Required(ErrorMessage = "Fill")]
        public string? MasterContactUsInformationImageUrl { get; set; }
        [Required(ErrorMessage = "Fill")]
        public string? MasterContactUsInformationRedirect { get; set; }

        public string? MasterContactUsInformationTitle { get; set; }

        public IFormFile? Files { get; set; }
        public bool? IsActive { get; set; }
    }
}
