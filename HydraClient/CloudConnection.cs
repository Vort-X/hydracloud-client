using System;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using XmlTcpSerializables;

namespace HydraClient
{
    public class CloudConnection
    {
        readonly string serverAddress;
        readonly int port;
        readonly BinaryFormatter serializer = new BinaryFormatter();
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
            string owner,
            string folderGuid) => GetResponse(new TcpRequest(login, password, "getf", owner, folderGuid));
        public TcpResponse Upload(
            string login,
            string password,
            string owner,
            string parentGuid,
            string source) => GetResponse(new TcpRequest(login, password, "upld", owner, parentGuid, extra: source));
        public TcpResponse Download(
            string login,
            string password,
            string owner,
            string folderGuid,
            string destination) => GetResponse(new TcpRequest(login, password, "down", owner, folderGuid, extra: destination));
        public TcpResponse CreateFolder(
            string login,
            string password,
            string owner,
            string parentGuid) => GetResponse(new TcpRequest(login, password, "cdir", owner, parentGuid));
        public TcpResponse Copy(
            string login,
            string password,
            string owner,
            string folderGuid,
            string parentGuid) => GetResponse(new TcpRequest(login, password, "copy", owner, folderGuid, parentGuid));
        public TcpResponse Move(
            string login,
            string password,
            string owner,
            string folderGuid,
            string parentGuid) => GetResponse(new TcpRequest(login, password, "move", owner, folderGuid, parentGuid));
        public TcpResponse Rename(
            string login,
            string password,
            string owner,
            string folderGuid,
            string newName) => GetResponse(new TcpRequest(login, password, "rnme", owner, folderGuid, extra: newName));
        public TcpResponse Delete(
            string login,
            string password,
            string owner,
            string folderGuid) => GetResponse(new TcpRequest(login, password, "dele", owner, folderGuid));
        public TcpResponse ShareUser(
            string login,
            string password,
            string owner,
            string folderGuid,
            string whomToShare,
            bool fullAccess) => GetResponse(new TcpRequest(login, password, "shru", owner, folderGuid, extra: whomToShare, mustHaveFullAccess: fullAccess));
        public TcpResponse UnshareUser(
            string login,
            string password,
            string owner,
            string folderGuid,
            string whomToShare) => GetResponse(new TcpRequest(login, password, "unsu", owner, folderGuid, extra: whomToShare));
        public TcpResponse UnshareAll(
            string login,
            string password,
            string owner,
            string folderGuid) => GetResponse(new TcpRequest(login, password, "unsa", owner, folderGuid));
        public TcpResponse GetShares(
            string login,
            string password) => GetResponse(new TcpRequest(login, password, "gets"));
        public TcpResponse Sample(
            string login,
            string password) => GetResponse(new TcpRequest(login, password, ""));
        #endregion

        private TcpResponse GetResponse(TcpRequest request)
        {
            serializer.Serialize(netStream, request);
            var res = (TcpResponse)serializer.Deserialize(netStream);

            return res;
        }
    }
}
