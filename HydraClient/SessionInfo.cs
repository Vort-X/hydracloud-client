using System.IO;
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
        public CloudConnection connection;

        public SessionInfo(CloudConnection connection)
        {
            this.connection = connection ?? throw new System.ArgumentNullException(nameof(connection));
        }

        #region Requests
        public void Authorize(string login, string password)
        {
            Login = login;
            Password = password;
            var res = connection.Authorize(login, password);
            ShowResponse(res);

            LoadFolder("");
        }
        public void Register(string login, string password, string email)
        {
            Login = login;
            Password = password;
            var res = connection.Register(login, password, email);
            ShowResponse(res);

            LoadFolder("");
        }

        public void LoadFolder(string guid)
        {
            var res = connection.GetFolder(Login, Password, guid);
            CurrentFolder = res?.folder ?? CurrentFolder;
        }
        public void Upload(string source, string destination, bool isDirectory)
        {
            if (isDirectory && Directory.Exists(source))
            {
                var dir = new DirectoryInfo(source);
                var res = connection.CreateFolder(Login, Password, destination, dir.Name);
                if (res.status == 0)
                {
                    foreach (var file in dir.GetFiles())
                        Upload(file.FullName, res.extra, false);
                    foreach (var folder in dir.GetDirectories())
                        Upload(folder.FullName, res.extra, true);
                }
                else
                {
                    MessageBox.Show(res.message);
                }
            }
            else if (!isDirectory && File.Exists(source))
            {
                connection.Upload(Login, Password, destination, source);
                //var res = connection.Upload(Login, Password, destination, source);
            }
            else MessageBox.Show("Invalid file or directory path: " + source);
        }
        public void Download(string source, string destination) //destination/path - FULL NAME, NOT PARENT DIR
        {
            var res = connection.GetFolder(Login, Password, source);
            if (res.status == 0)
                DownloadFolder(source, destination);
            else
                connection.Download(Login, Password, source, destination);

            void DownloadFolder(string cloudFolderId, string path)
            {
                res = connection.GetFolder(Login, Password, cloudFolderId);
                if (res.status == 0)
                {
                    Directory.CreateDirectory(path);
                    foreach (var file in res.folder.files)
                    {
                        connection.Download(Login, Password, file.guid, $"{path}/{file.name}");
                    }
                    foreach (var folder in res.folder.childFolders)
                    {
                        DownloadFolder(folder.guid, $"{path}/{folder.name}");
                    }
                }
                else ShowResponse(res);
            }
        }
        public void CreateFolder()
        {
            var res = connection.CreateFolder(Login, Password, CurrentFolder.data.guid);
            ShowResponse(res);
        }
        public void Copy()
        {
            var res = connection.Copy(Login, Password, BufferId, CurrentFolder.data.guid);
            ShowResponse(res);
        }
        public void Move()
        {
            var res = connection.Move(Login, Password, BufferId, CurrentFolder.data.guid);
            CleanBuffer();
            ShowResponse(res);
        }
        public void Rename(string ren, string newName)
        {
            var res = connection.Rename(Login, Password, ren, newName);
            ShowResponse(res);
        }
        public void Delete(string del)
        {
            var res = connection.Delete(Login, Password, del);
            ShowResponse(res);
        }
        public void Share(string obj, string whomToShare, bool fullAccess)
        {
            var res = connection.ShareUser(Login, Password, obj, whomToShare, fullAccess);
            ShowResponse(res);
        }
        public void Unshare(string obj, string whomToUnshare)
        {
            var res = connection.UnshareUser(Login, Password, obj, whomToUnshare);
            ShowResponse(res);
        }
        public void UnshareAll(string obj)
        {
            var res = connection.UnshareAll(Login, Password, obj);
            ShowResponse(res);
        }
        public void LoadSharings()
        {
            var res = connection.GetSharings(Login, Password);
            CurrentFolder = res?.folder ?? CurrentFolder;
        }
        #endregion

        public void ReloadFolder()
        {
            if (CurrentFolder.data.guid == null)
                LoadSharings();
            else
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
            MessageBox.Show(caption: $"Status code: {res.status}", text: $"{res.message}\n{res.extra}");
        }

    }
}
