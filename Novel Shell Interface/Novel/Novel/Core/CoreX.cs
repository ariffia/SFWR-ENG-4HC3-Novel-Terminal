using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Novel.Core
{
    class CoreX
    {
        //Master folders
        private static FolderX[] folders = {
                                              new FolderX("/home/"),    //#0
                                              new FolderX("/home/documents/"), //#1
                                              new FolderX("/home/downloads/"), //#2
                                              new FolderX("/home/documents/4hc3/"), //#3
                                              new FolderX("/home/documents/milestone3/")  //#4
                                          };

        //Current folder init
        private static FolderX current_folder = folders[0]; //home

        //Main
        public static void main(String[] args)
        {
        }

        //Initialize the folder structure
        public static void FoldersInit() {
            //home
            folders[0].AddFolder(folders[1]);   //documents
            folders[0].AddFolder(folders[2]);   //downloads
            folders[0].AddFile(new FileX("file1"));
            folders[0].AddFile(new FileX("file2"));
            folders[0].AddFile(new FileX("file3"));

            //documents
            folders[1].AddFolder(folders[3]);   //4hc3
            folders[1].AddFolder(folders[3]);   //milestone3
            folders[1].AddFile(new FileX("file4"));
            folders[1].AddFile(new FileX("file5"));

            //downloads
            folders[2].AddFile(new FileX("file6"));
            folders[2].AddFile(new FileX("file7"));

            //4hc3
            folders[3].AddFile(new FileX("file8"));
            folders[3].AddFile(new FileX("file9"));

            //milestone3
            folders[4].AddFile(new FileX("file10"));
            folders[4].AddFile(new FileX("file11"));
        }

        //COMMAND ENTER
        //Take a raw command
        //Return an output string
        public static String CommandEnter(String raw_command)
        {
            String[] strings = raw_command.Split(' ');

            if (strings[0].Equals("cd"))  //cd
            {
                if (strings.Length == 1)
                {
                    current_folder = folders[0];
                }
                else if (strings[1].Equals(folders[0].GetFolderAddress()))   //dir == home
                {
                    current_folder = folders[0];
                }
                else if (strings[1].Equals(folders[1].GetFolderAddress()))   //dir == folder1
                {
                    current_folder = folders[1];
                }
                else if (strings[1].Equals(folders[2].GetFolderAddress()))   //dir == folder2
                {
                    current_folder = folders[2];
                }
                else if (strings[1].Equals(folders[3].GetFolderAddress()))   //dir == folder3
                {
                    current_folder = folders[3];
                }
                else if (strings[1].Equals(folders[4].GetFolderAddress()))   //dir == folder4
                {
                    current_folder = folders[4];
                }
                else
                {
                }
                return current_folder.GetFolderAddress();
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
                if (strings.Length > 1)  //check for error
                {
                    StringBuilder sb = new StringBuilder();
                    for (int i = 0; i < strings.Length - 1; i++)
                    {
                        sb.Append(strings[i + 1]);
                    }
                    return sb.ToString();
                }
                else
                {
                    return "";
                }
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
                return current_folder.GetFolderAddress().ToString();
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
        }
    }
}
