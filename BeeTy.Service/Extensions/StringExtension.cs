using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BeeTy.Service.Extensions;

public static class StringExtension
{
    public static string Encrypt(this string password)
    {
        using var md5 = MD5.Create();
        var data = md5.ComputeHash(Encoding.UTF8.GetBytes(password));

        return Encoding.UTF8.GetString(data);
    }
}
