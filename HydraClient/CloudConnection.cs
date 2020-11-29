using System;
using System.IO;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using XmlTcpSerializables;

namespace HydraClient
{
    public class CloudConnection
    {
        readonly string serverAddress;
        readonly int port;
        readonly BinaryFormatter serializer = new BinaryFormatter();
        public bool Connected
        {
            get
            {
                if (client is null)
                    return false;
                return client.Connected;
            }
        }
        TcpClient client;
        NetworkStream netStream;

        public CloudConnection(string serverAddress, int port)
        {
            this.serverAddress = serverAddress;
            this.port = port;
        }

        public void Connect()
        {
            try
            {
                client = new TcpClient(serverAddress, port);
                netStream = client.GetStream();
            }
            catch (Exception)
            {
                Disconnect();
                throw;
            }
        }
        public void Disconnect()
        {
            netStream?.Close();
            client?.Close();
        }

        #region Requests
        public TcpResponse Authorize(
            string login,
            string password) => GetResponse(new TcpRequest(login, password, "auth"));
        public TcpResponse Register(
            string login,
            string password,
            string email) => GetResponse(new TcpRequest(login, password, "regi", extra: email));
        public TcpResponse GetFolder(
            string login,
            string password,
            string folderGuid) => GetResponse(new TcpRequest(login, password, "getf", folderGuid));
        public TcpResponse Upload(
            string login,
            string password,
            string parentGuid,
            string source) => GetResponse(new TcpRequest(login, password, "upld", parentGuid, extra: source));
        public TcpResponse Download(
            string login,
            string password,
            string fileGuid,
            string destination) => GetResponse(new TcpRequest(login, password, "down", fileGuid, extra: destination));
        public TcpResponse CreateFolder(
            string login,
            string password,
            string parentGuid,
            string name = null) => GetResponse(new TcpRequest(login, password, "cdir", parentGuid, extra: name));
        public TcpResponse Copy(
            string login,
            string password,
            string objectGuid,
            string parentGuid) => GetResponse(new TcpRequest(login, password, "copy", objectGuid, parentGuid));
        public TcpResponse Move(
            string login,
            string password,
            string objectGuid,
            string parentGuid) => GetResponse(new TcpRequest(login, password, "move", objectGuid, parentGuid));
        public TcpResponse Rename(
            string login,
            string password,
            string objectGuid,
            string newName) => GetResponse(new TcpRequest(login, password, "rnme", objectGuid, extra: newName));
        public TcpResponse Delete(
            string login,
            string password,
            string objectGuid) => GetResponse(new TcpRequest(login, password, "dele", objectGuid));
        public TcpResponse ShareUser(
            string login,
            string password,
            string folderGuid,
            string whomToShare,
            bool fullAccess) => GetResponse(new TcpRequest(login, password, "shru", folderGuid, extra: whomToShare, mustHaveFullAccess: fullAccess));
        public TcpResponse UnshareUser(
            string login,
            string password,
            string folderGuid,
            string whomToShare) => GetResponse(new TcpRequest(login, password, "unsu", folderGuid, extra: whomToShare));
        public TcpResponse UnshareAll(
            string login,
            string password,
            string folderGuid) => GetResponse(new TcpRequest(login, password, "unsa", folderGuid));
        public TcpResponse GetSharings(
            string login,
            string password) => GetResponse(new TcpRequest(login, password, "gets"));
        //public TcpResponse Sample(
        //    string login,
        //    string password) => GetResponse(new TcpRequest(login, password, ""));
        #endregion

        private TcpResponse GetResponse(TcpRequest request)
        {
            try
            {
                if (!Connected) Connect();

                string filename = request.extra;
                if (request.action.ToLower() == "upld")
                {
                    request.extra = new FileInfo(filename).Name;
                }
                serializer.Serialize(netStream, request);
                var response = (TcpResponse)serializer.Deserialize(netStream);

                if (request.action == "upld" && response.status == 0)
                {
                    try
                    {
                        using (FileStream stream = new FileStream(filename, FileMode.Open))
                        {
                            FileDescriptor fileDescriptor = new FileDescriptor(stream.Length);
                            fileDescriptor.WriteData(stream);
                            serializer.Serialize(netStream, fileDescriptor);
                        }
                    }
                    finally
                    {
                        response = (TcpResponse)serializer.Deserialize(netStream);
                    }
                }
                if (request.action == "down" && response.status == 0)
                {
                    try
                    {
                        using (FileStream stream = new FileStream(request.extra, FileMode.Create))
                        {
                            FileDescriptor fileDescriptor = (FileDescriptor)serializer.Deserialize(netStream);
                            stream.Write(fileDescriptor.Data, 0, fileDescriptor.Data.Length);
                        }
                    }
                    finally
                    {
                        response = (TcpResponse)serializer.Deserialize(netStream);
                    }
                }
                return response;
            }
            catch (IOException)
            {
                Disconnect();
                return new TcpResponse(1, "Connection broke");
            }
        }
    }
}
