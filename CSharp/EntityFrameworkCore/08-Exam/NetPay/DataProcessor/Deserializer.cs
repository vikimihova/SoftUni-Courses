using NetPay.Data;
using System.ComponentModel.DataAnnotations;
using NetPay.Helper;
using NetPay.DataProcessor.ImportDtos;
using NetPay.Data.Models;
using System.Text;
using Newtonsoft.Json;
using System.Globalization;
using NetPay.Data.Models.Enums;

namespace NetPay.DataProcessor
{
    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data format!";
        private const string DuplicationDataMessage = "Error! Data duplicated.";
        private const string SuccessfullyImportedHousehold = "Successfully imported household. Contact person: {0}";
        private const string SuccessfullyImportedExpense = "Successfully imported expense. {0}, Amount: {1}";

        public static string ImportHouseholds(NetPayContext context, string xmlString)
        {
            var householdDtos = XmlSerializationHelper.Deserialize<HouseholdImportDto[]>(xmlString, "Households");

            List<Household> householdsToImport = new List<Household>();
            StringBuilder sb = new StringBuilder();

            foreach (var dto in householdDtos)
            {
                if (!IsValid(dto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (householdsToImport.Any(h => h.ContactPerson == dto.ContactPerson
                                            || h.Email == dto.Email
                                            || h.PhoneNumber == dto.PhoneNumber))
                {
                    sb.AppendLine(DuplicationDataMessage);
                    continue;
                }

                Household household = new Household()
                {
                    ContactPerson = dto.ContactPerson,
                    Email = dto.Email,
                    PhoneNumber = dto.PhoneNumber,
                }; 

                householdsToImport.Add(household);
                sb.AppendLine(string.Format(SuccessfullyImportedHousehold, dto.ContactPerson));
            }

            context.Households.AddRange(householdsToImport);
            context.SaveChanges();

            return sb.ToString().Trim();
        }

        public static string ImportExpenses(NetPayContext context, string jsonString)
        {
            var expenseDtos = JsonConvert.DeserializeObject<ExpenseImportDto[]>(jsonString);

            StringBuilder sb = new StringBuilder();
            List<Expense> expensesToImport = new List<Expense>();

            int[] validHouseholdIds = context.Households.Select(h => h.Id).ToArray();
            int[] validServiceIds = context.Services.Select(s => s.Id).ToArray();

            foreach (var dto in expenseDtos)
            {
                bool isDueDateValid = DateTime.TryParse(dto.DueDate, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dtoDueDate);
                bool isPaymentStatusValid = PaymentStatus.TryParse(dto.PaymentStatus, out PaymentStatus dtoPaymentStatus);

                if (!IsValid(dto)
                    || isDueDateValid == false
                    || isPaymentStatusValid == false
                    || !validHouseholdIds.Contains(dto.HouseholdId)
                    || !validServiceIds.Contains(dto.ServiceId))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Expense expense = new Expense()
                {
                    ExpenseName = dto.ExpenseName,
                    Amount = dto.Amount,
                    DueDate = dtoDueDate,
                    PaymentStatus = dtoPaymentStatus,
                    HouseholdId = dto.HouseholdId,
                    ServiceId = dto.ServiceId,
                };

                expensesToImport.Add(expense);
                sb.AppendLine(string.Format(SuccessfullyImportedExpense, dto.ExpenseName, dto.Amount.ToString("f2")));
            }

            context.Expenses.AddRange(expensesToImport);
            context.SaveChanges();

            return sb.ToString().Trim();
        }

        public static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResults = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(dto, validationContext, validationResults, true);

            foreach(var result in validationResults)
            {
                string currvValidationMessage = result.ErrorMessage;
            }

            return isValid;
        }
    }
}
