// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

object obj = "Hallo Welt";
obj = 3_476_235.5m;

//casting + type check (doof)
if (obj is string)
{
    string objAsString = (string)obj;
    Console.WriteLine(objAsString);
}

//boxing (besser)
string objAsStringBoxing = obj as string;
if (objAsStringBoxing != null)
{
    Console.WriteLine(objAsStringBoxing);
}

//pattern matching (best)
if (obj is string objAsStringPattern)
{
    Console.WriteLine(objAsStringPattern);
}


Console.WriteLine("Wert: " + obj + " mm");
Console.WriteLine(string.Format("Wert {0:N} mm", obj));
Console.WriteLine($"Wert {obj:N} mm");


using (var sw = new StreamWriter("TolleDatei.txt"))
{
    sw.WriteLine("aaaaaaaaa");
} //sw.Dispose();//=> sw.Flush(); sw.Close();


using var sw2 = new StreamWriter("TolleDatei.txt");
sw2.WriteLine("aaaaaaaaa");
