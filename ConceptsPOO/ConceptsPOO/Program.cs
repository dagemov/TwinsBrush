

using ConceptsPOO;

Console.WriteLine("**** { POO CONCEPTS } ****");
Console.WriteLine("===============Info==============");
Console.WriteLine("****=========================****");
//Date date = new Date(2022,2,11);

//try
//{
//	Console.WriteLine(new Date(2022, 2, 11));

//	Console.WriteLine(new Date(2022, 12, 29));

//	Console.WriteLine(new Date(2021, 8, 18));

//	Console.WriteLine(new Date(2012, 1, 14));

//	Console.WriteLine(new Date(2001, 9, 11));

//	Console.WriteLine(new Date(2003, 2,28));
//}
//catch (Exception error)
//{

//	Console.WriteLine(error.Message);
//}
Employee employee1 = new SalaryEmployee()
{
    Id = 1,
    FirstName = "Blanca Isabel",
    LastName = "Arbelaez",
    BirthDate = new Date(1990,5,23),
    HiringDate = new Date(2022,1,15),
    IsActive = true,
    Salary = 1815453.45M,
};
Employee employee2 = new CommissionEmployee() {
    Id = 2,
    FirstName = "Sebastian",
    LastName = "Martinez",
    BirthDate = new Date(2001, 12, 29),
    HiringDate = new Date(2023,12,24),
    IsActive = true,
    Sales = 95863M,
    CommisionPorcentaje = 0.05F

};
Employee employee3 = new HourlyEmployee()
{
    Id = 3,
    FirstName = "Luis",
    LastName = "Garcia",
    BirthDate = new Date(2001, 12, 29),
    HiringDate = new Date(2023, 12, 24),
    IsActive = true,
    HourValue=17M,
    Hours=30
};
Employee employee4 = new BaseCommissionEmployee() 
{
    Id = 4,
    FirstName = "Stefany",
    LastName = "Rua",
    BirthDate = new Date(1997, 5, 29),
    HiringDate = new Date(2015, 2, 24),
    IsActive = true,
    Sales = 3200M,
    CommisionPorcentaje = 0.05F,
    Base = 1000
};

ICollection<Employee> employees = new List<Employee>()
{
   employee1,employee2, employee3, employee4
};
decimal PayRoll =0;
foreach (Employee employee in employees)
{
    Console.WriteLine(employee);
    PayRoll +=employee.GetValueToPay();
}
Console.WriteLine(                 "===================================="                                 );
Console.WriteLine($"Total Nomina =>    {$"{PayRoll:C2}",15}");
//Console.WriteLine(employee1);
//Console.WriteLine(employee2);
//Console.WriteLine(employee3);
//Console.WriteLine(employee4);

Invoice invoice1 = new Invoice()
{
    Id = 1,
    Description = "Sugar",
    Quantity = 14.5F,
    Price = 0.25M,
};
Invoice invoice2 = new Invoice()
{
    Id = 1,
    Description = "Filet mignon",
    Quantity = 25.5F,
    Price = 47.25M,
};
Console.WriteLine("====================================");
Console.WriteLine("Invoncies");
Console.WriteLine(invoice1);
Console.WriteLine(invoice2);