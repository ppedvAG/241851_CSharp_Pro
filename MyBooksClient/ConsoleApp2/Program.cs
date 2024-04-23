// See https://aka.ms/new-console-template for more information
using ConsoleApp2;

Console.WriteLine("Hello, World!");

var client = new swaggerClient("https://localhost:7124/", new HttpClient());
foreach (var item in await client.BooksAllAsync())
{
    Console.WriteLine(item.Titel);
} 
