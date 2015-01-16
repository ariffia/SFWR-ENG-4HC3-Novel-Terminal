using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using System.Collections;
using Novel.Core;
using System.IO;

namespace Novel
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Input/output
        public static TextBox input_tb;
        public static TextBox output_tb;

        //History
        public static ArrayList command_history;
        public static int history_counter;

        //Screen outputs
        public static ArrayList outputs;

        //Sidebar flipper
        public static bool ctrl_down;
        public static bool flipper;

        public MainWindow()
        {
            InitializeComponent();

            //Initialize the folder structure
            CoreX.FoldersInit();

            //Input/Output
            input_tb = input_text_box;
            output_tb = output_text_box;

            //Set focus
            input_tb.Focus();

            //Command history
            command_history = new ArrayList();
            history_counter = 0;

            //Outputs
            outputs = new ArrayList();

            //Sidebar flipper
            ctrl_down = false;
            flipper = false;

            //Sidebar expansion
            String application_directory = System.AppDomain.CurrentDomain.BaseDirectory;
            String path = application_directory + "options";
            SideBarOpen(true);
            if (File.Exists(path))
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    String raw = sr.ReadLine();
                    String[] raws = raw.Split('=');
                    if (raws[1].Equals("false"))
                    {
                        SideBarOpen(false);
                    }
                    else if (raws[1].Equals("true"))
                    {
                        SideBarOpen(true);
                    }
                }
            }

            //Manual default text
            StringBuilder manual_sb = new StringBuilder();
            manual_sb.AppendLine("SHORTCUTS:");
            manual_sb.AppendLine("   CTRL + Q = MANUAL");
            manual_sb.AppendLine("   CTRL + W = HISTORY");
            manual_sb.AppendLine(" ");
            manual_sb.AppendLine("COMMANDS:");
            manual_sb.AppendLine("   Go to Help -> Instructions");
            manual_text_box.Text = manual_sb.ToString();
        }

        //Input text changed
        private void input_text_box_TextChanged(object sender, TextChangedEventArgs e)
        {
            //Update the history tab
            UpdateHistoryTab();

            //Update the manual tab
            String raw_string = input_text_box.Text;
            String[] strings = raw_string.Split(' ');
            UpdateManualTab(strings[0]);
        }

        //Manual tab update
        public void UpdateManualTab(String command)
        {
            StringBuilder manual_sb = new StringBuilder();

            //Clear the text box
            manual_text_box.Text = "";

            if (command.Equals("cd"))   //cd
            {
                manual_sb.AppendLine("NAME");
                manual_sb.AppendLine("");
                manual_sb.AppendLine("cd - change the shell working directory");
                manual_sb.AppendLine("");
                manual_sb.AppendLine("SYNOPSIS");
                manual_sb.AppendLine("");
                manual_sb.AppendLine("cd [DIR]");
                manual_sb.AppendLine("");
                manual_sb.AppendLine("DESCRIPTION");
                manual_sb.AppendLine("");
                manual_sb.AppendLine("Change the shell working directory.");
                manual_sb.AppendLine("Change the current directory to DIR.  The default DIR is the value of the HOME shell variable.");
                manual_text_box.Text = manual_sb.ToString();
            }
            else if (command.Equals("clear"))   //clear
            {
                manual_sb.AppendLine("NAME");
                manual_sb.AppendLine("");
                manual_sb.AppendLine("clear - clear the terminal screen");
                manual_sb.AppendLine("");
                manual_sb.AppendLine("SYNOPSIS");
                manual_sb.AppendLine("");
                manual_sb.AppendLine("clear");
                manual_sb.AppendLine("");
                manual_sb.AppendLine("DESCRIPTION");
                manual_sb.AppendLine("");
                manual_sb.AppendLine("clear clears your screen if this is possible. " +
                    "It looks in the environment for the terminal type and then in the terminfo database to figure out how to clear the screen.");
                manual_sb.AppendLine("");
                manual_sb.AppendLine("clear ignores any command-line parameters that may be present.");
                manual_text_box.Text = manual_sb.ToString();
            }
            else if (command.Equals("date"))    //date
            {
                manual_sb.AppendLine("NAME");
                manual_sb.AppendLine("");
                manual_sb.AppendLine("date - print or set the system date and time");
                manual_sb.AppendLine("");
                manual_sb.AppendLine("SYNOPSIS");
                manual_sb.AppendLine("");
                manual_sb.AppendLine("date");
                manual_sb.AppendLine("");
                manual_sb.AppendLine("DESCRIPTION");
                manual_sb.AppendLine("");
                manual_sb.AppendLine("Display the current time.");
                manual_text_box.Text = manual_sb.ToString();
            }
            else if (command.Equals("dir")) //dir
            {
                manual_sb.AppendLine("NAME");
                manual_sb.AppendLine("");
                manual_sb.AppendLine("dir - list directory contents");
                manual_sb.AppendLine("");
                manual_sb.AppendLine("SYNOPSIS");
                manual_sb.AppendLine("");
                manual_sb.AppendLine("dir");
                manual_sb.AppendLine("");
                manual_sb.AppendLine("DESCRIPTION");
                manual_sb.AppendLine("");
                manual_sb.AppendLine("List information about the current directory.");
                manual_text_box.Text = manual_sb.ToString();
            }
            else if (command.Equals("echo"))    //echo
            {
                manual_sb.AppendLine("NAME");
                manual_sb.AppendLine("");
                manual_sb.AppendLine("echo - display a line of text");
                manual_sb.AppendLine("");
                manual_sb.AppendLine("SYNOPSIS");
                manual_sb.AppendLine("");
                manual_sb.AppendLine("echo [STRING]");
                manual_sb.AppendLine("");
                manual_sb.AppendLine("DESCRIPTION");
                manual_sb.AppendLine("");
                manual_sb.AppendLine("Echo the STRING to standard output.");
                manual_text_box.Text = manual_sb.ToString();
            }
            else if (command.Equals("file"))    //file
            {
                manual_sb.AppendLine("NAME");
                manual_sb.AppendLine("");
                manual_sb.AppendLine("file - determine file type");
                manual_sb.AppendLine("");
                manual_sb.AppendLine("SYNOPSIS");
                manual_sb.AppendLine("");
                manual_sb.AppendLine("file [FILE]");
                manual_sb.AppendLine("");
                manual_sb.AppendLine("DESCRIPTION");
                manual_sb.AppendLine("");
                manual_sb.AppendLine("Any file that cannot be identified is simply said to be ‘‘data’’.");
                manual_text_box.Text = manual_sb.ToString();
            }
            else if (command.Equals("history")) //history
            {
                manual_sb.AppendLine("NAME");
                manual_sb.AppendLine("");
                manual_sb.AppendLine("history - history library");
                manual_sb.AppendLine("");
                manual_sb.AppendLine("SYNOPSIS");
                manual_sb.AppendLine("");
                manual_sb.AppendLine("history");
                manual_sb.AppendLine("");
                manual_sb.AppendLine("DESCRIPTION");
                manual_sb.AppendLine("");
                manual_sb.AppendLine("List previous commands.");
                manual_text_box.Text = manual_sb.ToString();
            }
            else if (command.Equals("ls"))  //ls
            {
                manual_sb.AppendLine("NAME");
                manual_sb.AppendLine("");
                manual_sb.AppendLine("ls - list directory contents");
                manual_sb.AppendLine("");
                manual_sb.AppendLine("SYNOPSIS");
                manual_sb.AppendLine("");
                manual_sb.AppendLine("ls [OPTION]");
                manual_sb.AppendLine("");
                manual_sb.AppendLine("DESCRIPTION");
                manual_sb.AppendLine("");
                manual_sb.AppendLine("List information about the current directory.");
                manual_sb.AppendLine("");
                manual_sb.AppendLine("[OPTION]:");
                manual_sb.AppendLine("");
                manual_sb.AppendLine("   -l use a long listing format");
                manual_sb.AppendLine("   -d list directories themselves, not their contents");
                manual_text_box.Text = manual_sb.ToString();
            }
            else if (command.Equals("man")) //man   NOT SUPPORTED
            {
                manual_sb.AppendLine("COMMAND NOT SUPPORTED YET");
                manual_text_box.Text = manual_sb.ToString();
            }
            else if (command.Equals("mkdir"))   //mkdir   NOT SUPPORTED
            {
                manual_sb.AppendLine("COMMAND NOT SUPPORTED YET");
                manual_text_box.Text = manual_sb.ToString();
            }
            else if (command.Equals("mv"))  //mv   NOT SUPPORTED
            {
                manual_sb.AppendLine("COMMAND NOT SUPPORTED YET");
                manual_text_box.Text = manual_sb.ToString();
            }
            else if (command.Equals("pwd")) //pwd
            {
                manual_sb.AppendLine("NAME");
                manual_sb.AppendLine("");
                manual_sb.AppendLine("pwd - print name of current/working directory");
                manual_sb.AppendLine("");
                manual_sb.AppendLine("SYNOPSIS");
                manual_sb.AppendLine("");
                manual_sb.AppendLine("pwd");
                manual_sb.AppendLine("");
                manual_sb.AppendLine("DESCRIPTION");
                manual_sb.AppendLine("");
                manual_sb.AppendLine("Print the full filename of the current working directory.");
                manual_text_box.Text = manual_sb.ToString();
            }
            else if (command.Equals("rm"))  //rm   NOT SUPPORTED
            {
                manual_sb.AppendLine("COMMAND NOT SUPPORTED YET");
                manual_text_box.Text = manual_sb.ToString();
            }
            else if (command.Equals("rmdir"))   //rmdir   NOT SUPPORTED
            {
                manual_sb.AppendLine("COMMAND NOT SUPPORTED YET");
                manual_text_box.Text = manual_sb.ToString();
            }
            else if (command.Equals("!!"))  //!!   NOT SUPPORTED
            {
                manual_sb.AppendLine("COMMAND NOT SUPPORTED YET");
                manual_text_box.Text = manual_sb.ToString();
            }
            else
            {
                manual_sb.AppendLine("SHORTCUTS:");
                manual_sb.AppendLine("   CTRL + Q = MANUAL");
                manual_sb.AppendLine("   CTRL + W = HISTORY");
                manual_sb.AppendLine(" ");
                manual_sb.AppendLine("COMMANDS:");
                manual_sb.AppendLine("   Go to Help -> Instructions");
                manual_text_box.Text = manual_sb.ToString();
            }
        }

        //Input key down
        private void input_text_box_KeyDown(object sender, KeyEventArgs e)
        {
            //Enter
            if (e.Key == Key.Enter)
            {
                //Split the command string
                String[] strings = input_text_box.Text.Split(' ');

                //Send input and get the output string
                String output_string = CoreX.CommandEnter(input_text_box.Text);

                //Add the output string to the outputs arraylist
                outputs.Add(output_string);

                //Print the most recent outputs to the screen
                StringBuilder output_sb = new StringBuilder();
                for (int i = 0; i < outputs.Count; i++)
                {
                    output_sb.AppendLine("[" + i.ToString() + "] $~ " + outputs[i].ToString());
                }
                output_text_box.Text = output_sb.ToString();

                //Add to history & clear the input text box
                command_history.Add(input_text_box.Text);
                input_text_box.Text = "";

                //Scroll screen to end
                output_scroll_viewer.ScrollToEnd();

                //Reset history counter
                history_counter = 0;
            }
            else
            {
            }
        }

        //Input text box key up
        private void input_text_box_KeyUp(object sender, KeyEventArgs e)
        {
            if (command_history.Count > 0)
            {
                if (e.Key == Key.Up)
                {
                    if (history_counter < command_history.Count)
                    {
                        history_counter++;
                    }
                    input_tb.Text = command_history[command_history.Count - history_counter].ToString();
                    input_tb.Select(history_text_box.Text.Length, 0);
                }
                else if (e.Key == Key.Down)
                {
                    if (history_counter > 1)
                    {
                        history_counter--;
                    }
                    else if (history_counter == 0)
                    {
                        history_counter++;
                    }
                    input_tb.Text = command_history[command_history.Count - history_counter].ToString();
                    input_tb.Select(history_text_box.Text.Length, 0);
                }
            }
        }

        //Open/close the side bar
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (ctrl_down)
            {
                if (e.Key == Key.Q)
                {
                    SideBarOpen(flipper);
                    flipper = !flipper;
                    manual_tab_item.Focus();
                    input_tb.Focus();
                }
                else if (e.Key == Key.W)
                {
                    SideBarOpen(flipper);
                    flipper = !flipper;
                    history_tab_item.Focus();
                    input_tb.Focus();
                }
            }
            if (e.Key == Key.LeftCtrl)
            {
                ctrl_down = true;
            }
        }

        //Open/close side bar
        public void SideBarOpen(bool b)
        {
            if (b)  //open
            {
                ColumnDefinition c1 = main_grid.ColumnDefinitions[0];
                c1.Width = new GridLength(30, GridUnitType.Star);
                ColumnDefinition c2 = main_grid.ColumnDefinitions[1];
                c2.Width = new GridLength(70, GridUnitType.Star);
            }
            else
            {
                ColumnDefinition c1 = main_grid.ColumnDefinitions[0];
                c1.Width = new GridLength(0, GridUnitType.Star);
                ColumnDefinition c2 = main_grid.ColumnDefinitions[1];
                c2.Width = new GridLength(100, GridUnitType.Star);
            }
        }

        //Open/close side bar
        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.LeftCtrl)
            {
                ctrl_down = false;
            }
        }

        //Open a new window
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            MainWindow new_window = new MainWindow();
            new_window.Show();
        }

        //Open the settings window
        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            SettingsWindow setting_window = new SettingsWindow();
            setting_window.Show();
        }

        //Main window close
        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        //Open about window
        private void MenuItem_Click_3(object sender, RoutedEventArgs e)
        {
            AboutWindow about_window = new AboutWindow();
            about_window.Show();
        }

        //History string preservation
        private void history_text_box_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateHistoryTab();

            history_scroll_viewer.ScrollToEnd();
            history_text_box.Select(history_text_box.Text.Length, 0);
        }

        //History update
        public void UpdateHistoryTab()
        {
            //Update the history string array
            StringBuilder str_builder = new StringBuilder();
            for (int i = 0; i < command_history.Count; i++)
            {
                str_builder.AppendLine("[" + i.ToString() + "] " + command_history[i].ToString());
            }

            //Update the history tab
            String history_str_to_print = str_builder.ToString();
            if (history_str_to_print.Length > 2)
            {
                history_str_to_print = history_str_to_print.Remove(history_str_to_print.Length - 2, 2); //Remove the last "\n"
            }
            history_text_box.Text = history_str_to_print;
            history_scroll_viewer.ScrollToEnd();
        }

        //Open instructions window
        private void MenuItem_Click_4(object sender, RoutedEventArgs e)
        {
            InstructionsWindow instructions_window = new InstructionsWindow();
            instructions_window.Show();
        }
    }
}
