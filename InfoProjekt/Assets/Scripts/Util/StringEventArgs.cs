using System;

namespace Util
{
    public class StringEventArgs: EventArgs
    {
        public string data { get; set; }

        public StringEventArgs(string data)
        {
            this.data = data;
        }
    }
}