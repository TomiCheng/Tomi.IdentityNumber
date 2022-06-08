using System;
using System.Linq;

namespace Tomi.IdentityNumber
{
    public interface IIdentityNumber
    {
        bool Verify(string identityNumber);
        string Generate();
    }
}
