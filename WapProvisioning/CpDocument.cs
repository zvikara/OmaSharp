using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using OmaSharp.WBXML;

namespace OmaSharp.WapProvisioning
{
    public class CpDocument : WbxmlDocument
    {
        public string Version { get; set; } = "1.1";
        private XmlElement wapProvisioningDoc;

        public CpDocument()
        {
            VersionNumber = 1.3;
            TagCodeSpace = new CodeSpace();
            AttributeCodeSpace = new AttrCodeSpace();
        }

        public CpDocument AddCharacteristic(string type, params string[] parms)
        {
            wapProvisioningDoc = wapProvisioningDoc ?? CreateWapProvisioningDoc();
            var characteristic = CreateElement(string.Empty, "characteristic", string.Empty);
            var characteristicType = CreateAttribute("type");
            characteristicType.Value = type;
            characteristic.Attributes.Append(characteristicType);
            foreach (var p in parms)
            {
                var nameValue = p.Split('=');
                var name = nameValue[0];
                var value = nameValue[1];
                var parm = CreateElement(string.Empty, "parm", string.Empty);
                var nameAttr = CreateAttribute("name");
                nameAttr.Value = name;
                parm.Attributes.Append(nameAttr);
                var valueAttr = CreateAttribute("value");
                valueAttr.Value = value;
                parm.Attributes.Append(valueAttr);
                characteristic.AppendChild(parm);
            }
            wapProvisioningDoc.AppendChild(characteristic);
            return this;
        }

        public void AddTheWapProvisioningDoc()
        {
            if (wapProvisioningDoc != null)
                AppendChild(wapProvisioningDoc);
        }

        private XmlElement CreateWapProvisioningDoc()
        {
            var xmlDeclaration = CreateXmlDeclaration("1.0", null, null);
            InsertBefore(xmlDeclaration, DocumentElement);
            var documentType = CreateDocumentType("wap-provisioningdoc",
                "-//WAPFORUM//DTD PROV 1.0//EN", "http://www.wapforum.org/DTD/prov.dtd", null);
            InsertBefore(documentType, DocumentElement);

            var wapProvisioningDoc = CreateElement(string.Empty, "wap-provisioningdoc", string.Empty);
            var version = CreateAttribute("version");
            version.Value = Version;
            wapProvisioningDoc.Attributes.Append(version);
            return wapProvisioningDoc;
        }

        public byte[] GetWslBytes(long imsi)
            => GetWslBytes(GetKey(imsi), WslSecurity.NetwPin);

        public byte[] GetWslBytes(string pin)
            => GetWslBytes(GetKey(pin), WslSecurity.UserPin);

        private byte[] GetWslBytes(byte[] key, WslSecurity wslSecurity)
        {
            var bytesList = new List<byte>();
            bytesList.AddRange(new byte[] { 1, 6, 0x2F, 0x1F, 0x2D, 0xB6, 0x91 });
            bytesList.Add((byte)wslSecurity);
            bytesList.Add(0x92);
            bytesList.AddRange(GetHmacSha1(key));
            bytesList.Add(0);
            bytesList.AddRange(GetBytes());
            return bytesList.ToArray();
        }

        public byte[] GetHmacSha1(long imsi)
            => GetHmacSha1(GetKey(imsi));

        public byte[] GetHmacSha1(string pin)
            => GetHmacSha1(GetKey(pin));

        private byte[] GetHmacSha1(byte[] key)
        {
            var byteArray = GetBytes();
            using (var hmac = new HMACSHA1(key))
            using (var stream = new MemoryStream(byteArray))
            {
                return hmac.ComputeHash(stream).ToHexStringBytes();
            }
        }

        private byte[] GetKey(long imsi)
            => imsi.SwapBcdBytes();

        private byte[] GetKey(string pin)
            => Encoding.ASCII.GetBytes(pin);
    }
}
