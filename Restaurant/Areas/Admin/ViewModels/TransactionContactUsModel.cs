using System.ComponentModel.DataAnnotations;

namespace Restaurant.Areas.Admin.ViewModels
{
    public class TransactionContactUsModel
    {
        [Key]
        public int TransactionContactUsId { get; set; }

        public string? TransactionContactUsFullName { get; set; }

        public string? TransactionContactUsEmail { get; set; }

        public string? TransactionContactUsSubject { get; set; }

        public string? TransactionContactUsMessage { get; set; }

    }
}
