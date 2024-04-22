


namespace HalloDelegate
{
    delegate void EinfacherDelegate();
    delegate void DelegateMitPara(string txt);
    delegate long CalcDele(int a, int b);

    internal class HalloDelegate
    {
        public HalloDelegate()
        {
            EinfacherDelegate meinDele = EinfacheMethode;
            Action aAction = EinfacheMethode;
            Action aActionAno = delegate () { Console.WriteLine("Hallo Welt"); };
            Action aActionAno2 = () => { Console.WriteLine("Hallo Welt"); };
            Action aActionAno3 = () => Console.WriteLine("Hallo Welt");

            DelegateMitPara delegateMitPara = MethodeMitPara;
            Action<string> actionMitPara = MethodeMitPara;
            Action<string> actionMitParaAno = delegate (string txt) { Console.WriteLine(txt); };
            Action<string> actionMitParaAno2 = (string txt) => { Console.WriteLine(txt); };
            Action<string> actionMitParaAno3 = (txt) => Console.WriteLine(txt);
            Action<string> actionMitParaAno4 = x => Console.WriteLine(x);

            CalcDele calcDele = Minus;
            Func<int, int, long> calcDeleFunc = Sum;
            CalcDele calcDeleAno = delegate (int a, int b) { return a + b; };
            CalcDele calcDeleAno2 = (a, b) => { return a + b; };
            Func<int, int, long> calcDeleAno3 = (a, b) => a + b;

            var result = calcDele.Invoke(1, 2);

            var liste = new List<string>();
            liste.Where(x => x.StartsWith("b"));
            liste.Where(Filter);
        }

        private bool Filter(string arg)
        {
            if (arg.StartsWith("b"))
                return true;
            else
                return false;
        }

        private long Minus(int a, int b)
        {
            return a - b;
        }

        private long Sum(int a, int b)
        {
            return a + b;
        }

        private void MethodeMitPara(string name)
        {
            Console.WriteLine($"Hallo: {name}");
        }

        public void EinfacheMethode()
        {
            Console.WriteLine("Hallo");
        }
    }
}
