using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Restaurant.Areas.Admin.ViewModels
{
    public class MasterServiceModel
    {
        [Key]
        public int MasterServiceId { get; set; }

        public string? MasterServicesTitle { get; set; }

        public string? MasterServicesDesc { get; set; }

        public string? MasterServicesImage { get; set; }

        public bool? IsActive { get; set; }

        public string? Icon { get; set; }

        [NotMapped]
        public IFormFile? files { get; set; }
    }
}
