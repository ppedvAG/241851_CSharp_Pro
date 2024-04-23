using HalloDelegate;

Console.WriteLine("Hello, World!");

var btn = new MyButton();
btn.TripleClick += MyClick;
btn.TripleClick += MyClick;
btn.TripleClick -= MyClick;
btn.TripleClick -= MyClick;
btn.TripleClick += MyClick;

for (int i = 0; i < 100; i++)
{
    Console.WriteLine($"Click {i}");
    btn.Click();
}

void MyClick (object sender, int e)
{
    Console.WriteLine($"*** TRIPLE CLICK {e}");
}