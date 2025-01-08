using CarDealer.Data;
using CarDealer.DTOs.Export;
using CarDealer.DTOs.Import;
using CarDealer.Models;
using Castle.Core.Resource;
using System.Globalization;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main()
        {
            // IMPORTANT: SoftUni-provided skeleton with pre-written code deliberately excluded from solution

            CarDealerContext context = new CarDealerContext();

            string suppliersText = File.ReadAllText("../../../Datasets/suppliers.xml");
            string partsText = File.ReadAllText("../../../Datasets/parts.xml");
            string carsText = File.ReadAllText("../../../Datasets/cars.xml");
            string customersText = File.ReadAllText("../../../Datasets/customers.xml");
            string salesText = File.ReadAllText("../../../Datasets/sales.xml");


            //Console.WriteLine(ImportSuppliers(context, suppliersText));
            //Console.WriteLine(ImportParts(context, partsText));
            //Console.WriteLine(ImportCars(context, carsText));
            //Console.WriteLine(ImportCustomers(context, customersText));
            //Console.WriteLine(ImportSales(context, salesText));

            Console.WriteLine(GetCarsWithTheirListOfParts(context));
        }

        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportSuppliersDTO[]), new XmlRootAttribute("Suppliers"));

            ImportSuppliersDTO[] supplierDTOs;

            using (var reader = new StringReader(inputXml))
            {
                supplierDTOs = (ImportSuppliersDTO[])xmlSerializer.Deserialize(reader);
            }

            Supplier[] suppliers = supplierDTOs.
                Select(x => new Supplier
                {
                    Name = x.Name,
                    IsImporter = x.IsImporter,
                })
                .ToArray();

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Length}";
        }

        public static string ImportParts(CarDealerContext context, string inputXml)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportPartsDto[]), new XmlRootAttribute("Parts"));

            ImportPartsDto[] partDtos;

            using (var reader = new StringReader(inputXml))
            {
                partDtos = (ImportPartsDto[])xmlSerializer.Deserialize(reader);
            }

            var validSupplierIds = context.Suppliers.
                Select(s => s.Id)
                .ToArray();

            Part[] parts = partDtos
                .Where(x => validSupplierIds.Contains(x.SupplierId))
                .Select(x => new Part
                {
                    Name = x.Name,
                    Price = x.Price,
                    Quantity = x.Quantity,
                    SupplierId = x.SupplierId,
                })
                .ToArray();

            context.Parts.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {parts.Length}";
        }

        public static string ImportCars(CarDealerContext context, string inputXml)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportCarsDto[]), new XmlRootAttribute("Cars"));

            ImportCarsDto[] carDtos;

            using (var reader = new StringReader(inputXml))
            {
                carDtos = (ImportCarsDto[])xmlSerializer.Deserialize(reader);
            }

            List<Car> cars = new List<Car>();

            foreach (var carDto in carDtos)
            {
                Car car = new Car()
                {
                    Make = carDto.Make,
                    Model = carDto.Model,
                    TraveledDistance = carDto.TraveledDistance,
                };

                var validPartIds = context.Parts
                    .Select(x => x.Id);

                int[] carPartIds = carDto.PartIds
                    .Where(x => validPartIds.Contains(x.Id))
                    .Select(x => x.Id)
                    .Distinct()
                    .ToArray();

                var carParts = new List<PartCar>();

                foreach (var partId in carPartIds)
                {
                    PartCar partCar = new PartCar()
                    {
                        Car = car,
                        PartId = partId,
                    };

                    carParts.Add(partCar);
                }

                car.PartsCars = carParts;
                cars.Add(car);
            }

            context.Cars.AddRange(cars);
            context.SaveChanges();

            return $"Successfully imported {cars.Count}";
        }

        public static string ImportCustomers(CarDealerContext context, string inputXml)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportCustomersDto[]), new XmlRootAttribute("Customers"));

            ImportCustomersDto[] customerDtos;

            using (var reader = new StringReader(inputXml))
            {
                customerDtos = (ImportCustomersDto[])xmlSerializer.Deserialize(reader);
            }

            Customer[] customers = customerDtos
                .Select(x => new Customer
                {
                    Name = x.Name,
                    BirthDate = x.BirthDate,
                    IsYoungDriver = x.IsYoungDriver,
                })
                .ToArray();

            context.Customers.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Length}";
        }

        public static string ImportSales(CarDealerContext context, string inputXml)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportSalesDto[]), new XmlRootAttribute("Sales"));

            ImportSalesDto[] saleDtos;

            using (var reader = new StringReader(inputXml))
            {
                saleDtos = (ImportSalesDto[])xmlSerializer.Deserialize(reader);
            }

            int[] validCarIds = context.Cars
                .Select(x => x.Id)
                .ToArray();

            var validSales = saleDtos
                .Where(x => validCarIds.Contains(x.CarId))
                .ToArray();

            Sale[] sales = validSales
                .Select(x => new Sale()
                {
                    Discount = x.Discount,
                    CarId = x.CarId,
                    CustomerId = x.CustomerId,
                })
                .ToArray();

            context.Sales.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Length}";
        }

        public static string GetCarsWithDistance(CarDealerContext context)
        {
            var carsWithDistance = context.Cars
                .Where(x => x.TraveledDistance > 2_000_000)
                .Select(x => new CarWithDistanceExportDto()
                {
                    Make = x.Make,
                    Model = x.Model,
                    TraveledDistance = x.TraveledDistance,
                })
                .OrderBy(x => x.Make)
                .ThenBy(x => x.Model)
                .Take(10)
                .ToArray();

            return SerializeToXml(carsWithDistance, "cars");
        }

        public static string GetCarsFromMakeBmw(CarDealerContext context)
        {
            var bmwCars = context.Cars
                .Where(x => x.Make == "BMW")
                .Select(x => new BmwCarsExportDto()
                {
                    Id = x.Id,
                    Model = x.Model,
                    TraveledDistance = x.TraveledDistance,
                })
                .OrderBy(x => x.Model)
                .ThenByDescending(x => x.TraveledDistance)
                .ToArray();

            return SerializeToXml(bmwCars, "cars", true);
        }

        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var localSuppliers = context.Suppliers
                .Where(x => x.IsImporter == false)
                .Select(x => new LocalSupplierExportDto()
                {
                    Id = x.Id,
                    Name = x.Name,
                    PartsCount = x.Parts.Count,
                })
                .ToArray();

            return SerializeToXml(localSuppliers, "suppliers");
        }

        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var cars = context.Cars
                .Select(x => new CarsWithListOfPartsDto()
                {
                    Make = x.Make,
                    Model = x.Model,
                    TraveledDistance = x.TraveledDistance,
                    Parts = x.PartsCars
                        .Select(x => new PartCarExportDto()
                        {
                            Name = x.Part.Name,
                            Price = x.Part.Price,
                        })
                        .OrderByDescending(x => x.Price)
                        .ToArray()
                })
                .OrderByDescending(x => x.TraveledDistance)
                .ThenBy(x => x.Model)
                .Take(5)
                .ToArray();

            return SerializeToXml(cars, "cars");
        }

        private static string SerializeToXml<T>(T dto, string xmlRootAttribute, bool omitDeclaration = false)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T), new XmlRootAttribute(xmlRootAttribute));
            StringBuilder stringBuilder = new StringBuilder();

            XmlWriterSettings settings = new XmlWriterSettings
            {
                OmitXmlDeclaration = omitDeclaration,
                Encoding = new UTF8Encoding(false),
                Indent = true
            };

            using (StringWriter stringWriter = new StringWriter(stringBuilder, CultureInfo.InvariantCulture))
            using (XmlWriter xmlWriter = XmlWriter.Create(stringWriter, settings))
            {
                XmlSerializerNamespaces xmlSerializerNamespaces = new XmlSerializerNamespaces();
                xmlSerializerNamespaces.Add(string.Empty, string.Empty);

                try
                {
                    xmlSerializer.Serialize(xmlWriter, dto, xmlSerializerNamespaces);
                }
                catch (Exception)
                {
                    throw;
                }
            }

            return stringBuilder.ToString();
        }
    }
}