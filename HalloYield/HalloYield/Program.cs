

string text=null;

if(!string.IsNullOrEmpty(text))
{
    Console.WriteLine(text);
}

Console.WriteLine("Hello, World!");

foreach (var item in GetNumbers())
{
    Console.WriteLine($"{item}");
}


IEnumerable<int> GetNumbers()
{
    yield return 2;
    yield return 2;
    yield return -6;
    yield return 7000;
    yield return -373745;

    //var resultList = new List<int>();
    //resultList.Add(2);
    //resultList.Add(2);
    //resultList.Add(-6);
    //resultList.Add(7000);
    //resultList.Add(-373745);
    //return resultList;
}
