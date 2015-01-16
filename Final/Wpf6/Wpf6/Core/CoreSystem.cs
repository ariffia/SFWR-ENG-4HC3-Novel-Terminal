using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Wpf6.Core
{
    public static class CoreSystem
    {
        //master folders
        private static Folder[] folders = {
                                              new Folder("home", "/home"), //home  /home    #0
                                              new Folder("folder1", "/home/folder1"), //folder1   /home/folder1 #1
                                              new Folder("folder2", "/home/folder2"), //folder2   /home/folder2 #2
                                              new Folder("folder3", "/home/folder1/folder3"), //folder3   /home/folder1/folder3 #3
                                              new Folder("folder4", "/home/folder1/folder4")  //folder4   /home/folder1/folder4 #4
                                          };

        //current folder init
        private static Folder current_folder = folders[0];

        //main
        public static void main(String[] args)
        {
        }

        public static void InitContent2() {
            folders[0].AddFile(new FileSystem("file1"));
            folders[0].AddFile(new FileSystem("file2"));
            folders[0].AddFile(new FileSystem("file3"));
        }

        //command enter
        public static String CommandEnter(String raw_command)
        {
            String[] strings = raw_command.Split(' ');

            if (false)
            {
            }
            else if (strings[0].Equals("cd"))  //cd
            {
                if (strings.Length == 1)
                {
                    current_folder = folders[0];
                }
                else if (strings[1].Equals(folders[0].getFolderAddress()))   //dir == home
                {
                    current_folder = folders[0];
                }
                else if (strings[1].Equals(folders[1].getFolderAddress()))   //dir == folder1
                {
                    current_folder = folders[1];
                }
                else if (strings[1].Equals(folders[2].getFolderAddress()))   //dir == folder2
                {
                    current_folder = folders[2];
                }
                else if (strings[1].Equals(folders[3].getFolderAddress()))   //dir == folder3
                {
                    current_folder = folders[3];
                }
                else if (strings[1].Equals(folders[4].getFolderAddress()))   //dir == folder4
                {
                    current_folder = folders[4];
                }
                else
                {
                }
                return current_folder.getFolderAddress();
            }
            else if (strings[0].Equals("clear"))   //clear
            {
                return "\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n";
            }
            else if (strings[0].Equals("date")) //date
            {
                DateTime date_time = DateTime.Now;
                StringBuilder string_builder = new StringBuilder();
                string_builder.Append(date_time.DayOfWeek.ToString());
                string_builder.Append("   ");
                string_builder.Append(date_time.ToLongDateString());
                string_builder.Append("   ");
                string_builder.Append(date_time.ToShortTimeString());
                return string_builder.ToString();
            }
            else if (strings[0].Equals("dir")) //dir
            {
                return "";
            }
            else if (strings[0].Equals("echo"))    //echo
            {
                return "";
            }
            else if (strings[0].Equals("file"))    //file
            {
                return "";
            }
            else if (strings[0].Equals("history")) //history
            {
                return "";
            }
            else if (strings[0].Equals("ls"))  //ls
            {
                return current_folder.GetLsString();
            }
            else if (strings[0].Equals("man")) //man
            {
                return "";
            }
            else if (strings[0].Equals("mkdir"))   //mkdir
            {
                return "";
            }
            else if (strings[0].Equals("mv"))  //mv
            {
                return "";
            }
            else if (strings[0].Equals("pwd"))  //pwd
            {
                return current_folder.getFolderAddress().ToString();
            }
            else if (strings[0].Equals("rm"))  //rm
            {
                return "";
            }
            else if (strings[0].Equals("rmdir"))   //rmdir
            {
                return "";
            }
            else if (strings[0].Equals("!!"))  //!!
            {
                return "";
            }
            else
            {
                return "<" + raw_command + ">" + " is not a command";
            }
            return "";
        }
    }
}
