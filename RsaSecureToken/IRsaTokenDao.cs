using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RsaSecureToken
{
    public interface IRsaTokenDao
    {
        string GetRandom(string account);
    }
}
