namespace AccoliteLaptops.Models
{
    public static class EmployeeRespository
    {
        // List of employees and their laptop with initial data
        public static List<Laptop> Laptops { get; set; } = new List<Laptop>()
        {
            // Sample enteries
            new Laptop
            {
                Id = 1,
                EmployeeName = "Nandini",
                LaptopSerialNumber = "GCTR003",
                LaptopModel = "Dell i5"
            },
            new Laptop
            {
                Id = 2,
                EmployeeName = "Alisha",
                LaptopSerialNumber = "GCTR0456",
                LaptopModel = "Dell 13 laptop"
            },
            new Laptop
            {
                Id = 3,
                EmployeeName = "Ishita",
                LaptopSerialNumber = "GCTR9845",
                LaptopModel = "Dell Inspiron 14 Laptop"
            }
        };
    }
}
