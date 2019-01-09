using System;
using System.IO;
using System.Text;
using System.Xml;

namespace OmaSharp.WapProvisioning
{
    public static class ExtensionsMethods
    {
        public static string ToHexString(this byte[] byteArray) 
            => BitConverter.ToString(byteArray);

        public static byte[] ToHexStringBytes(this byte[] byteArray)
            => Encoding.ASCII.GetBytes(byteArray.ToHexString().Replace("-", ""));
    }
}
