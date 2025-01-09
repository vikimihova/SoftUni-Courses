using Microsoft.EntityFrameworkCore;
using NetPay.Data;

namespace NetPay
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            // IMPORTANT: SoftUni-provided skeleton with pre-written code deliberately excluded from solution

            NetPayContext context = new NetPayContext();

            var projectDir = GetProjectDirectory();

            ImportEntities(context, projectDir + @"Datasets/");
            ExportEntities(context);

            using(var transaction = context.Database.BeginTransaction())
            {
                transaction.Rollback();
            }
        }

        private static void ImportEntities(NetPayContext context, string baseDir)
        {
            var households = DataProcessor.Deserializer
                .ImportHouseholds(context, File.ReadAllText(baseDir + "households.xml"));

            var expences = DataProcessor.Deserializer
                .ImportExpenses(context, File.ReadAllText(baseDir + "expences.json"));
        }

        private static void ExportEntities(NetPayContext context)
        {
            var HouseholdsHavingExpensesToPayWithAllUnpaidExpences =
                DataProcessor.Serializer.ExportHouseholdsWhichHaveExpensesToPay(context);

            Console.WriteLine(HouseholdsHavingExpensesToPayWithAllUnpaidExpences);

            var ServicesWithSuppliers =
                DataProcessor.Serializer.ExportAllServicesWithSuppliers(context);

            Console.WriteLine(ServicesWithSuppliers);
        }        

        private static object GetProjectDirectory()
        {
            var currentDirectory = Directory.GetCurrentDirectory();
            var directoryName = Path.GetFileName(currentDirectory);
            var relativePath = directoryName.StartsWith("net6.0") ? @"../../../" : string.Empty;

            return relativePath;
        }        
    }
}
