using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections;

namespace Novel.Core
{
    class FolderX
    {
        String address;
        ArrayList folders = new ArrayList();
        ArrayList files = new ArrayList();

        //Default constructor
        public FolderX(String address)
        {
            this.address = address;
        }

        //Get address
        public String GetFolderAddress()
        {
            return this.address;
        }

        //Get folder name
        public String GetFolderName()
        {
            String[] strings = this.address.Split('/');
            return strings[strings.Length - 2];
        }

        //Add folder
        public void AddFolder(FolderX folder) {
            folders.Add(folder);
        }

        //Add file
        public void AddFile(FileX file)
        {
            files.Add(file);
        }

        //LsPrint
        public String GetLsString()
        {
            //Folders
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("FOLDER(S):   ");
            sb.Append("       ");
            for (int i = 0; i < folders.Count; i++)
            {
                FolderX folder = (FolderX)folders[i];
                sb.Append(folder.GetFolderName());
                sb.Append("   ");
            }

            //Files
            sb.AppendLine(" ");
            sb.AppendLine("       FILE(S):   ");
            sb.Append("       ");
            for (int i = 0; i < files.Count; i++)
            {
                FileX this_file = (FileX)files[i];
                sb.Append(this_file.GetFileName());
                sb.Append("   ");
            }

            return sb.ToString();
        }
    }
}
