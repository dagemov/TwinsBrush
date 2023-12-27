

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
Console.WriteLine(employee1);
Console.WriteLine(employee2);
