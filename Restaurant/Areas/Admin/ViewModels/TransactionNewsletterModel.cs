using System.ComponentModel.DataAnnotations;

namespace Restaurant.Areas.Admin.ViewModels
{
    public class TransactionNewsletterModel
    {
        [Key]
        public int TransactionNewsletterId { get; set; }

        public string? TransactionNewsletterEmail { get; set; }

    }
}
