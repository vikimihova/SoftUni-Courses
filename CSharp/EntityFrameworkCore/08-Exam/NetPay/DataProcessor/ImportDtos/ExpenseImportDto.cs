using NetPay.Data.Models;
using NetPay.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetPay.DataProcessor.ImportDtos
{
    public class ExpenseImportDto
    {
        [Required]
        [MinLength(5)]
        [MaxLength(50)]
        public string ExpenseName { get; set; }

        [Required]
        [Range(typeof(decimal), "0.01", "100000")]
        public decimal Amount { get; set; }

        [Required]
        [RegularExpression(@"[0-9]{4}-[0-9]{2}-[0-9]{2}")]
        public string DueDate { get; set; }

        [Required]
        public string PaymentStatus { get; set; }

        [Required]
        public int HouseholdId { get; set; }

        [Required]
        public int ServiceId { get; set; }
    }
}
