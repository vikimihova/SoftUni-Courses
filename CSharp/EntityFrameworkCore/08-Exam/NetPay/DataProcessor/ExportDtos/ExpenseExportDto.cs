using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace NetPay.DataProcessor.ExportDtos
{
    [XmlType("Expense")]
    public class ExpenseExportDto
    {
        [XmlElement(nameof(ExpenseName))]
        public string ExpenseName { get; set; }

        [XmlElement(nameof(Amount))]
        public string Amount { get; set; }

        [XmlElement(nameof(PaymentDate))]
        public string PaymentDate { get; set; }

        [XmlElement(nameof(ServiceName))]
        public string ServiceName { get; set; }
    }
}
