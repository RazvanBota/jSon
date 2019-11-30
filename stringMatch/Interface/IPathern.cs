using System;
using System.Collections.Generic;
using System.Text;

namespace stringMatch
{
    interface IPattern
    {
        IMatch Match(string myString);
    }
}
