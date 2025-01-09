using NetPay.Data;
using NetPay.Data.Models.Enums;
using NetPay.DataProcessor.ExportDtos;
using NetPay.Helper;
using Newtonsoft.Json;

namespace NetPay.DataProcessor
{
    public class Serializer
    {
        public static string ExportHouseholdsWhichHaveExpensesToPay(NetPayContext context)
        {
            var householdsToExport = context.Households
                .Where(h => h.Expenses.Any(e => e.PaymentStatus != PaymentStatus.Paid))
                .Select(h => new HouseholdExportDto()
                {
                    ContactPerson = h.ContactPerson,
                    Email = h.Email,
                    PhoneNumber = h.PhoneNumber,
                    Expenses = h.Expenses
                        .Where(e => e.PaymentStatus != PaymentStatus.Paid)    
                        .Select(e => new ExpenseExportDto()
                        {
                            ExpenseName = e.ExpenseName,
                            Amount = e.Amount.ToString("f2"),
                            PaymentDate = e.DueDate.ToString("yyyy-MM-dd"),
                            ServiceName = e.Service.ServiceName
                        })
                        .OrderBy(e => e.PaymentDate)
                        .ThenBy(e => e.Amount)
                        .ToArray(),
                })
                .OrderBy(h => h.ContactPerson)
                .ToArray();

            return XmlSerializationHelper.Serialize(householdsToExport, "Households");
        }

        public static string ExportAllServicesWithSuppliers(NetPayContext context)
        {
            var servicesToExport = context.Services
                .OrderBy(s => s.ServiceName)
                .Select(s => new
                {
                    ServiceName = s.ServiceName,
                    Suppliers = s.SuppliersServices
                        .OrderBy(ss => ss.Supplier.SupplierName)
                        .Select(ss => new
                        {
                            SupplierName = ss.Supplier.SupplierName
                        })
                        .ToArray()
                })                
                .ToArray();

            var settings = new JsonSerializerSettings()
            {                
                Formatting = Formatting.Indented,
            };

            return JsonConvert.SerializeObject(servicesToExport, settings);
        }
    }
}
