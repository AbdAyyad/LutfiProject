using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Security.Cryptography;
using System.Xml.Serialization;
using System.IO;

namespace GraduationProject
{
    class RsaEncryption
    {
        private RSACryptoServiceProvider cypher;
        private string publicKeyXml;
        private string privateKeyXml;
        private RSAParameters parameters;

        public RsaEncryption()
        {
            cypher = new RSACryptoServiceProvider(2048);
            Console.WriteLine(cypher.KeySize);
            parameters = cypher.ExportParameters(true);
            initKey();
        }

        public RsaEncryption(string publicKeyXml, string privateKeyXml)
        {
            cypher = new RSACryptoServiceProvider(2048);
            this.publicKeyXml = publicKeyXml;
            this.privateKeyXml = privateKeyXml;
        }

        private void initKey()
        {
            var stringWriter = new StringWriter();

            var serilizer = new XmlSerializer(typeof(RSAParameters));
            var publicKeyObject = cypher.ExportParameters(false);
            serilizer.Serialize(stringWriter, publicKeyObject);
            this.publicKeyXml = stringWriter.ToString();

            stringWriter = new StringWriter();
            var privateKeyObject = cypher.ExportParameters(true);
            serilizer.Serialize(stringWriter, privateKeyObject);
            this.privateKeyXml = stringWriter.ToString();

        }

        public byte[] Encrypt(byte[] data)
        {
            cypher.ImportParameters(parameters);
            return cypher.Encrypt(data,true);
        }

        public byte[] Decrypt(byte[] data)
        {
            cypher.ImportParameters(parameters);
            return cypher.Decrypt(data, true);
        }

        public string PublicKeyXml {
            get {
                return publicKeyXml;
            }
        }

        public string PrivateKeyXml
        {
            get
            {
                return privateKeyXml;
            }
        }
    }
}
