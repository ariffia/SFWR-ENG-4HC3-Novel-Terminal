using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpf6.Core
{
    class Cmd
    {
        public static String[] commands = {
                                              "cd", "clear",
                                              "date", "dir",
                                              "echo",
                                              "file",
                                              "history",
                                              "ls",
                                              "man", "mkdir", "mv",
                                              "rm","rmdir",
                                              "!!"
                                          };

        //Cmd field
        String command;
        String[] options;
        String[] manuals;

        public Cmd(String command)
        {
            if (command.Equals("date")) //date
            {
                this.command = command;
                this.options = new String[0];
                this.manuals = new String[1];
                this.manuals[0] = "NAME\n\ndate - print or set the system date and time\n";
            }
            else
            {
                this.command = null;
                this.options = null;
                this.manuals = null;
            }
        }
    }
}
