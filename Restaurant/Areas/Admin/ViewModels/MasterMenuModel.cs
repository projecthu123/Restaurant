using System.ComponentModel.DataAnnotations;

namespace Restaurant.Areas.Admin.ViewModels
{
    public class MasterMenuModel
    {
        [Key]
        public int MasterMenuId { get; set; }

        public string MasterMenuName { get; set; } = null!;

        public string MasterMenuUrl { get; set; } = null!;
        public bool? IsActive { get; set; }
    }
}
