

using ConceptsPOO;

Console.WriteLine("**** { POO CONCEPTS } ****");

//Date date = new Date(2022,2,11);

try
{
	Console.WriteLine(new Date(2022, 2, 11));

	Console.WriteLine(new Date(2022, 12, 29));

	Console.WriteLine(new Date(2021, 8, 18));

	Console.WriteLine(new Date(2012, 1, 14));

	Console.WriteLine(new Date(2001, 9, 11));

	Console.WriteLine(new Date(2003, 2,28));
}
catch (Exception error)
{

	Console.WriteLine(error.Message);
}

