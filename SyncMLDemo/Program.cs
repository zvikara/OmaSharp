using System;
using System.Text;
using OmaSharp.WBXML;

namespace SyncMLDemo
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //Encoding and decoding of DevInf sample (Section 9)
            //http://www.openmobilealliance.org/tech/affiliates/syncml/syncml_devinf_v11_20020215.pdf
            ExecuteDevInfClientSample();
            Console.ReadLine();

            //Encoding and decoding of Sync Initialization Package from Client (Example 4.1)
            //Note: The DevInf is added as opaque data. 
            //http://www.openmobilealliance.org/tech/affiliates/syncml/syncml_sync_protocol_v11_20020215.pdf
            ExecuteSyncInitializationClientSample();
            Console.ReadLine();

            //Encoding and decoding of DevInf sample (Example 4.2)
            //http://www.openmobilealliance.org/tech/affiliates/syncml/syncml_sync_protocol_v11_20020215.pdf
            ExecuteDevInfServerSample();
            Console.ReadLine();

            //Encoding and decoding of Sync Initialization Package from Server (Example 4.2)
            //Note: The DevInf is added as opaque data. 
            //http://www.openmobilealliance.org/tech/affiliates/syncml/syncml_sync_protocol_v11_20020215.pdf
            ExecuteSyncInitializationServerSample();
            Console.ReadLine();

            //Encoding and decoding of Sending Modifications Package to Server (Example 5.1)
            //Note: no vCard data is added
            //http://www.openmobilealliance.org/tech/affiliates/syncml/syncml_sync_protocol_v11_20020215.pdf
            ExecuteSendingModificationsToServerSample();
            Console.ReadLine();

            //Encoding and decoding of Sending Modifications Package to Client (Example 5.2)
            //Note: no vCard data is added
            //http://www.openmobilealliance.org/tech/affiliates/syncml/syncml_sync_protocol_v11_20020215.pdf
            ExecuteSendingModificationsToClientSample();
            Console.ReadLine();

            //Encoding and decoding of Data Update Status Package to Server (Example 5.3)
            //http://www.openmobilealliance.org/tech/affiliates/syncml/syncml_sync_protocol_v11_20020215.pdf
            ExecuteDataUpdateStatusToServerSample();
            Console.ReadLine();

            //Encoding and decoding of Map Acknowledgement Package from Server(Example 5.4)
            //http://www.openmobilealliance.org/tech/affiliates/syncml/syncml_sync_protocol_v11_20020215.pdf
            ExecuteMapAcknowledgementFromServerSample();
            Console.ReadLine();
        }

        private static void ExecuteDevInfClientSample()
        {
            var devInfDocument = new WbxmlDocument();
            devInfDocument.VersionNumber = 1.3;
            devInfDocument.TagCodeSpace = new DevInfCodeSpace();
            devInfDocument.Load("devinf_client.xml");

            Console.WriteLine("DevInf Client: WBXML output");
            byte[] devInfBytes = devInfDocument.GetBytes();
            Console.WriteLine(PrintHex(devInfBytes));

            var decodeDevInfDocument = new WbxmlDocument();
            decodeDevInfDocument.TagCodeSpace = new DevInfCodeSpace();
            decodeDevInfDocument.LoadBytes(devInfBytes);
            decodeDevInfDocument.Save("devinf_client_output.xml");

            Console.WriteLine("DevInf Client: XML output");
            Console.WriteLine(decodeDevInfDocument.OuterXml);
        }

        private static void ExecuteSyncInitializationClientSample()
        {
            var syncMLDocument = new WbxmlDocument();
            syncMLDocument.VersionNumber = 1.2;
            syncMLDocument.TagCodeSpace = new SyncMLCodeSpace();
            syncMLDocument.OpaqueDataExpressions.Add(
                new OpaqueDataExpression("Data", "../../Meta[Type='application/vnd.syncml-devinf+wbxml']"));
            syncMLDocument.Load("syncml_example_4_1.xml");

            Console.WriteLine("SyncML Example 4.1: WBXML output");
            byte[] syncmlBytes = syncMLDocument.GetBytes();
            Console.WriteLine(PrintHex(syncmlBytes));

            var decodeSyncMLDocument = new WbxmlDocument();
            decodeSyncMLDocument.TagCodeSpace = new SyncMLCodeSpace();
            decodeSyncMLDocument.LoadBytes(syncmlBytes);
            decodeSyncMLDocument.Save("syncml_example_4_1_output.xml");

            Console.WriteLine("SyncML Example 4.1: XML output");
            Console.WriteLine(decodeSyncMLDocument.OuterXml);
        }

        private static void ExecuteDevInfServerSample()
        {
            var devInfDocument = new WbxmlDocument();
            devInfDocument.VersionNumber = 1.3;
            devInfDocument.TagCodeSpace = new DevInfCodeSpace();
            devInfDocument.Load("devinf_server.xml");

            Console.WriteLine("DevInf Server: WBXML output");
            byte[] devInfBytes = devInfDocument.GetBytes();
            Console.WriteLine(PrintHex(devInfBytes));

            var decodeDevInfDocument = new WbxmlDocument();
            decodeDevInfDocument.TagCodeSpace = new DevInfCodeSpace();
            decodeDevInfDocument.LoadBytes(devInfBytes);
            decodeDevInfDocument.Save("devinf_server_output.xml");

            Console.WriteLine("DevInf Server: XML output");
            Console.WriteLine(decodeDevInfDocument.OuterXml);
        }

        private static void ExecuteSyncInitializationServerSample()
        {
            var syncMLDocument = new WbxmlDocument();
            syncMLDocument.VersionNumber = 1.2;
            syncMLDocument.TagCodeSpace = new SyncMLCodeSpace();
            syncMLDocument.OpaqueDataExpressions.Add(
                new OpaqueDataExpression("Data", "../../Meta[Type='application/vnd.syncml-devinf+wbxml']"));
            syncMLDocument.Load("syncml_example_4_2.xml");

            Console.WriteLine("SyncML Example 4.2: WBXML output");
            byte[] syncmlBytes = syncMLDocument.GetBytes();
            Console.WriteLine(PrintHex(syncmlBytes));

            var decodeSyncMLDocument = new WbxmlDocument();
            decodeSyncMLDocument.TagCodeSpace = new SyncMLCodeSpace();
            decodeSyncMLDocument.LoadBytes(syncmlBytes);
            decodeSyncMLDocument.Save("syncml_example_4_2_output.xml");

            Console.WriteLine("SyncML Example 4.2: XML output");
            Console.WriteLine(decodeSyncMLDocument.OuterXml);
        }

        private static void ExecuteSendingModificationsToServerSample()
        {
            var syncMLDocument = new WbxmlDocument();
            syncMLDocument.VersionNumber = 1.2;
            syncMLDocument.TagCodeSpace = new SyncMLCodeSpace();
            syncMLDocument.Load("syncml_example_5_1.xml");

            Console.WriteLine("SyncML Example 5.1: WBXML output");
            byte[] syncmlBytes = syncMLDocument.GetBytes();
            Console.WriteLine(PrintHex(syncmlBytes));

            var decodeSyncMLDocument = new WbxmlDocument();
            decodeSyncMLDocument.TagCodeSpace = new SyncMLCodeSpace();
            decodeSyncMLDocument.LoadBytes(syncmlBytes);
            decodeSyncMLDocument.Save("syncml_example_5_1_output.xml");

            Console.WriteLine("SyncML Example 5.1: XML output");
            Console.WriteLine(decodeSyncMLDocument.OuterXml);
        }

        private static void ExecuteSendingModificationsToClientSample()
        {
            var syncMLDocument = new WbxmlDocument();
            syncMLDocument.VersionNumber = 1.2;
            syncMLDocument.TagCodeSpace = new SyncMLCodeSpace();
            syncMLDocument.Load("syncml_example_5_2.xml");

            Console.WriteLine("SyncML Example 5.2: WBXML output");
            byte[] syncmlBytes = syncMLDocument.GetBytes();
            Console.WriteLine(PrintHex(syncmlBytes));

            var decodeSyncMLDocument = new WbxmlDocument();
            decodeSyncMLDocument.TagCodeSpace = new SyncMLCodeSpace();
            decodeSyncMLDocument.LoadBytes(syncmlBytes);
            decodeSyncMLDocument.Save("syncml_example_5_2_output.xml");

            Console.WriteLine("SyncML Example 5.2: XML output");
            Console.WriteLine(decodeSyncMLDocument.OuterXml);
        }

        private static void ExecuteDataUpdateStatusToServerSample()
        {
            var syncMLDocument = new WbxmlDocument();
            syncMLDocument.VersionNumber = 1.2;
            syncMLDocument.TagCodeSpace = new SyncMLCodeSpace();
            syncMLDocument.Load("syncml_example_5_3.xml");

            Console.WriteLine("SyncML Example 5.3: WBXML output");
            byte[] syncmlBytes = syncMLDocument.GetBytes();
            Console.WriteLine(PrintHex(syncmlBytes));

            var decodeSyncMLDocument = new WbxmlDocument();
            decodeSyncMLDocument.TagCodeSpace = new SyncMLCodeSpace();
            decodeSyncMLDocument.LoadBytes(syncmlBytes);
            decodeSyncMLDocument.Save("syncml_example_5_3_output.xml");

            Console.WriteLine("SyncML Example 5.3: XML output");
            Console.WriteLine(decodeSyncMLDocument.OuterXml);
        }

        private static void ExecuteMapAcknowledgementFromServerSample()
        {
            var syncMLDocument = new WbxmlDocument();
            syncMLDocument.VersionNumber = 1.2;
            syncMLDocument.TagCodeSpace = new SyncMLCodeSpace();
            syncMLDocument.Load("syncml_example_5_4.xml");

            Console.WriteLine("SyncML Example 5.4: WBXML output");
            byte[] syncmlBytes = syncMLDocument.GetBytes();
            Console.WriteLine(PrintHex(syncmlBytes));

            var decodeSyncMLDocument = new WbxmlDocument();
            decodeSyncMLDocument.TagCodeSpace = new SyncMLCodeSpace();
            decodeSyncMLDocument.LoadBytes(syncmlBytes);
            decodeSyncMLDocument.Save("syncml_example_5_4_output.xml");

            Console.WriteLine("SyncML Example 5.4: XML output");
            Console.WriteLine(decodeSyncMLDocument.OuterXml);
        }

        private static string PrintHex(byte[] bytes)
        {
            var stringReturn = new StringBuilder();
            foreach (byte byteItem in bytes)
            {
                stringReturn.Append(byteItem.ToString("X2"));
            }
            return stringReturn.ToString();
        }
    }
}