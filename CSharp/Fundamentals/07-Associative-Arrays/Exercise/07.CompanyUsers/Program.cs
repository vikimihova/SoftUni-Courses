namespace _07_CompanyUsers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var employeeLists = new Dictionary<string, List<string>>();

            string inputLine = Console.ReadLine();

            while (inputLine != "End")
            {
                string[] information = inputLine.Split(" -> ");
                string company = information[0];
                string employeeId = information[1];

                if (!employeeLists.ContainsKey(company))
                {
                    employeeLists.Add(company, new List<string>());
                    employeeLists[company].Add(employeeId);
                }
                else
                {
                    if (!employeeLists[company].Contains(employeeId))
                    {
                        employeeLists[company].Add(employeeId);
                    }                    
                }

                inputLine = Console.ReadLine();
            }

            foreach (var company in employeeLists)
            {
                Console.WriteLine($"{company.Key}");
                foreach (var employee in company.Value)
                {
                    Console.WriteLine($"-- {employee}");
                }
            }
        }
    }
}