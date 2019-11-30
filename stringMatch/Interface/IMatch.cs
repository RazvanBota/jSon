using System;
using System.Collections.Generic;
using System.Text;

namespace stringMatch
{
    interface IMatch
    {
        bool IsSuccesful();
        string RemainingText();
    }
}
