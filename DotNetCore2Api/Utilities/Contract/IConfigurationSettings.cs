using System;
using System.Collections.Generic;
using System.Text;

namespace Utilities.Contract
{
    public interface IConfigurationSettings
    {
        string Issuer();

        string Audience();

        string SigninKey();
    }
}
