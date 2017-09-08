using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirdChat_Client
{

    public class TextEventArgs : EventArgs
    {
        // Private field exposed by the Text property
        private string text;

        public TextEventArgs(string text)
        {
            this.text = text;
        }

        // Read only property.
        public string Text
        {
            get { return text; }
        }
    }
}
