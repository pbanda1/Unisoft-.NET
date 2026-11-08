using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayerLogic.Security
{
    public interface IPasswordHasher
    {
        (string hash, string salt) Hash(string password);
        bool VerifyPassword(string password, string hash, string salt);
    }
}
