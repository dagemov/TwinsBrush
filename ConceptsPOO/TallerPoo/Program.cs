/*
 En un supermercado podemos encontrar 3 clases de productos
, 1)
los productos de precio fijo, son la mayoría, 
son los productos que tienen un precio invariable (Coca cola, leche, pan, ETC),
2) 
los productos de precio variable que su precio lo determina su peso o longitud o alguna otra medida como peso o metraje (Carne, Frutas, Alambre)
, 
3)
los productos compuestos, que son, normalmente, promociones donde se juntan dos o más productos ya sean de precio fijo o de precio variable
y se les hace un descuento por venir empaquetados o en “combo”.

Implemente una solución de consola en C# que, usando este diagrama de clases:

 */
using TallerPoo;

Console.WriteLine("PRODUCTS");
Console.WriteLine("-------------------------------------------------");
Product product1 = new FixedPriceProduct()
{
    Description = "Vino Gato Negro",
    Id = 1010,
    Price = 46000M,
    Tax = 0.19F
};
Product product2 = new FixedPriceProduct()
{
    Description = "Pan Bimbo Artesanal",
    Id = 2020,
    Price = 1560M,
    Tax = 0.19F
};
Product product3 = new VariablePriceProduct()
{
    Description = "Queso Holandes",
    Id = 3030,
    Measurement = "Kilo",
    Price = 32000M,
    Quantity = 0.536F,
    Tax = 0.19F
};
Product product4 = new VariablePriceProduct()
{
    Description = "Cabano",
    Id = 4040,
    Measurement = "Kilo",
    Price = 18000M,
    Quantity = 0.389F,
    Tax = 0.19F
};
Product product5 = new ComposedProduct()
{
    Description = "Ancheta #1",
    Discount = 0.12F,
    Id = 5050,
    Products = new List<Product>() { product1, product2, product3, product4 }
};
Console.WriteLine(product1);
Console.WriteLine(product2);
Console.WriteLine(product3);
Console.WriteLine(product4);
Console.WriteLine(product5);

Invoice invoice = new Invoice();
invoice.AddProduct(product1);
invoice.AddProduct(product3);
invoice.AddProduct(product5);
Console.WriteLine(invoice);

