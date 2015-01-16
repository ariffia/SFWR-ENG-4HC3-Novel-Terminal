using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Wpf6.Core
{
    class Folder
    {
        String address;
        String folder_name;
        Folder parent;
        ArrayList children = new ArrayList();
        ArrayList files = new ArrayList();

        //constructor
        public Folder(String folder_name, String address)
        {
            this.address = address;
            this.folder_name = folder_name;
        }

        //public get address
        public String getFolderAddress()
        {
            return this.address;
        }

        //get folder name
        public String getFolderName()
        {
            return this.folder_name;
        }

        //add children
        public void AddChild(Folder child) {
            children.Add(child);
        }

        //add files
        public void AddFile(FileSystem file)
        {
            files.Add(file);
        }

        //LsPrint
        public String GetLsString()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < files.Count; i++)
            {
                FileSystem this_file = (FileSystem)files[i];
                sb.Append(this_file.GetFileName());
            }
            for (int i = 0; i < children.Count; i++)
            {
                sb.Append(children[i].ToString());
            }
            return sb.ToString();
        }
    }
}
