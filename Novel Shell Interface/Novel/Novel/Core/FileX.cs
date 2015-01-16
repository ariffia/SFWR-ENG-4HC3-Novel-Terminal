using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Novel.Core
{
    class FileX
    {
        String file_name;

        public FileX(String file_name)
        {
            this.file_name = file_name;
        }

        public String GetFileName()
        {
            return file_name;
        }
    }
}
