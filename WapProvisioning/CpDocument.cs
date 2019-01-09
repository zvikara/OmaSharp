using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using OmaSharp.WBXML;

namespace OmaSharp.WapProvisioning
{
    public class CpDocument : WbxmlDocument
    {
        public CpDocument()
        {
            VersionNumber = 1.3;
            TagCodeSpace = new CodeSpace();
            AttributeCodeSpace = new AttrCodeSpace();
        }

        public byte[] GetWslBytes(string pin)
        {
            var bytesList = new List<byte>();
            bytesList.AddRange(new byte[] { 01, 06, 0x2F, 0x1F, 0x2D, 0xB6, 0x91, 0x81, 0x92 });
            bytesList.AddRange(GetHmacSha1(pin));
            bytesList.Add(0);
            bytesList.AddRange(GetBytes());
            return bytesList.ToArray();
        }

        public byte[] GetHmacSha1(string pin)
        {
            var key = Encoding.ASCII.GetBytes(pin);
            var byteArray = GetBytes();
            using (var hmac = new HMACSHA1(key))
            using (var stream = new MemoryStream(byteArray))
            {
                return hmac.ComputeHash(stream).ToHexStringBytes();
            }
        }
    }
}
