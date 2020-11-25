using System.Windows.Forms;
using XmlTcpSerializables;

namespace HydraClient
{
    public class SessionInfo
    {
        public string Login { get; private set; }
        public string Password { get; private set; }
        public FolderInfo CurrentFolder { get; private set; }
        public string BufferId { get; private set; }
        public bool IsCopy { get; private set; }

        #region Requests
        public void Authorize(string login, string password)
        {
            Login = login;
            Password = password;
            var res = Program.cloudConnection?.Authorize(login, password);
            ShowResponse(res);

            LoadFolder("");
        }
        public void Register(string login, string password, string email)
        {
            Login = login;
            Password = password;
            var res = Program.cloudConnection?.Register(login, password, email);
            ShowResponse(res);

            LoadFolder("");
        }

        public void LoadFolder(string guid)
        {
            var res = Program.cloudConnection?.GetFolder(Login, Password, guid);
            CurrentFolder = res?.folder ?? CurrentFolder;
            ShowResponse(res);
        }
        public void Upload(string source, string destination)
        {
            //var res = Program.cloudConnection.CreateFolder(Login, Password);
        }
        public void Download(string source, string destination)
        {
            //var res = Program.cloudConnection.CreateFolder(Login, Password);
        }
        public void CreateFolder()
        {
            var res = Program.cloudConnection?.CreateFolder(Login, Password, CurrentFolder.data.guid);
            ShowResponse(res);
        }
        public void Copy()
        {
            var res = Program.cloudConnection?.Copy(Login, Password,  BufferId, CurrentFolder.data.guid);
            ShowResponse(res);
        }
        public void Move()
        {
            var res = Program.cloudConnection?.Move(Login, Password,  BufferId, CurrentFolder.data.guid);
            CleanBuffer();
            ShowResponse(res);
        }
        public void Rename(string ren, string newName)
        {
            var res = Program.cloudConnection?.Rename(Login, Password, ren, newName);
            ShowResponse(res);
        }
        public void Delete(string del)
        {
            var res = Program.cloudConnection?.Delete(Login, Password, del);
            ShowResponse(res);
        }
        public void Share(string obj, string whomToShare, bool fullAccess)
        {
            var res = Program.cloudConnection?.ShareUser(Login, Password, obj, whomToShare, fullAccess);
            ShowResponse(res);
        }
        public void Unshare(string obj, string whomToUnshare)
        {
            var res = Program.cloudConnection?.UnshareUser(Login, Password, obj, whomToUnshare);
            ShowResponse(res);
        }
        public void UnshareAll(string obj)
        {
            var res = Program.cloudConnection?.UnshareAll(Login, Password, obj);
            ShowResponse(res);
        }
        public void LoadShares()
        {
            var res = Program.cloudConnection?.GetShared(Login, Password);
            CurrentFolder = res?.folder ?? CurrentFolder;
            ShowResponse(res);
        }
        #endregion

        public void ReloadFolder()
        {
            LoadFolder(CurrentFolder.data.guid);
        }
        public void FillBuffer(string bufferId, bool isCopy)
        {
            BufferId = bufferId;
            IsCopy = isCopy;
        }
        private void CleanBuffer()
        {
            BufferId = null;
        }
        public void ShowResponse(TcpResponse res)
        {
            if (res != null)
            MessageBox.Show($"Status code: {res.status}", $"{res.message}\n{res.extra}");
        }
    }
}
