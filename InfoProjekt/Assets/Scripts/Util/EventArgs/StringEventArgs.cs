namespace Util.EventArgs
{
    public class StringEventArgs: System.EventArgs
    {
        public string data { get; private set; }

        public StringEventArgs(string data)
        {
            this.data = data;
        }
    }
}