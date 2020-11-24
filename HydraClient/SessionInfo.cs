using HydraClassLibrary.ClientEntities;
using System;

namespace HydraClient
{
    public class SessionInfo
    {
        public ClientUser CurrentUser { get; private set; }
        public ClientFolder CurrentFolder { get; private set; }
        public object Buffer { get; private set; }
        public Type BufferType { get; private set; }
        public bool IsCopy { get; private set; }

        public void Authorize(ClientUser user)
        {
            CurrentUser = user;
            LoadFolder(CurrentUser.Login, "root\\");
        }
        public void ReloadFolder()
        {
            LoadFolder(CurrentUser.Login, CurrentFolder.FullPath);
        }
        public void LoadFolder(string owner, string path)
        {
            if (owner != null && path != null && path != "")
            {
                var folder = Program.cloudConnection?.GetFolder(CurrentUser, owner, path);
                CurrentFolder = folder ?? CurrentFolder;
            }
            else if (CurrentFolder?.Owner == null && CurrentFolder?.Name == "Sharings")
                LoadShares();
            else if (CurrentUser != null)
                CurrentFolder = Program.cloudConnection?.GetFolder(CurrentUser, CurrentUser.Login, "root\\");
        }
        public void LoadShares()
        {
            CurrentFolder = Program.cloudConnection?.GetShared(CurrentUser) ?? CurrentFolder;
        }
        public void FillBuffer(ClientFolder folder, bool isCopy)
        {
            Buffer = folder;
            BufferType = folder.GetType();
            IsCopy = isCopy;
        }
        public void FillBuffer(ClientFile file, bool isCopy)
        {
            Buffer = file;
            BufferType = file.GetType();
            IsCopy = isCopy;
        }
        public void CleanBuffer()
        {
            Buffer = null;
            BufferType = null;
        }
    }
}
