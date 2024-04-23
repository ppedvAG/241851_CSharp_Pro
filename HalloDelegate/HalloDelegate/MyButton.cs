namespace HalloDelegate
{
    internal class MyButton
    {
        public event Action<object, int> TripleClick;


        int clickCount = 0;
        public void Click()
        {
            clickCount++;

            if (clickCount % 3 == 0)
                OnTripleClick(this, clickCount);
        }
        protected void OnTripleClick(object sender, int clickCount)
        {
            TripleClick(sender, clickCount);
        }
    }

    class MyButtonChild : MyButton
    {
        public MyButtonChild()
        {
            OnTripleClick(this, 4);
        }
    }
}
