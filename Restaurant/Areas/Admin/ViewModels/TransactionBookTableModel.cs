using System.ComponentModel.DataAnnotations;

namespace Restaurant.Areas.Admin.ViewModels
{
    public class TransactionBookTableModel
    {
        [Key]
        public int TransactionBookTableId { get; set; }

        public string? TransactionBookTableFullName { get; set; }

        public string? TransactionBookTableEmail { get; set; }

        public string? TransactionBookTableMobileNumber { get; set; }

        public DateTime? TransactionBookTableDate { get; set; }



    }
}
