using System.ComponentModel.DataAnnotations;

namespace Restaurant.Areas.Admin.ViewModels
{
    public class MasterWorkingHourModel
    {
        [Key]
        public int MasterWorkingHourId { get; set; }

        public string? MasterWorkingHoursIdName { get; set; }

        public string? MasterWorkingHoursIdTimeFormTo { get; set; }


        public bool? IsActive { get; set; }
    }
}
