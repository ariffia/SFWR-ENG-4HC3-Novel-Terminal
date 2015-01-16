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
using Wpf6.Core;
using System.Threading;
using System.Collections;
using System.IO;

namespace Wpf6
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static TextBox input_text_box;
        private static TextBox output_text_box;
        private static Folder home_folder;
        private static Folder current_folder;
        private static ArrayList command_history;
        private static ArrayList outputs;
        static GridSplitter splitter_static;
        static bool ctrl_down = false;
        static bool flipper = true;
        static int history_counter;
        static ScrollViewer output_sv;

        //window
        private static Status status_window;
        private static Auto_complete auto_complete_window;

        public MainWindow()
        {
            InitializeComponent();

            //init content
            CoreSystem.InitContent2();

            ////status window
            status_window = new Status();
            status_window.Show();

            //auto complete
            auto_complete_window = new Auto_complete();

            //load text box & text block
            input_text_box = input_field;
            output_text_box = output_field;

            //Thread
            Alpha alpha = new Alpha();
            Thread thread = new Thread(new ThreadStart(alpha.Beta));
            thread.Start();

            //install key down handler to text box
            input_text_box.KeyDown += new KeyEventHandler(InputFieldKeyDown);

            //history
            command_history = new ArrayList();

            //outputs
            outputs = new ArrayList();

            //set focus to input text box
            input_text_box.Focus();

            //create text file
            //String application_directory = System.AppDomain.CurrentDomain.BaseDirectory;
            //String path = application_directory + "TextFile.txt";
            //status_window.status_text_block.Text = application_directory;
            //FileStream fs = null;
            //if (!File.Exists(path))
            //{
            //    fs = File.Create(path);
            //}

            //key up in input field
            history_counter = 0;

            //ouput scroll
            output_sv = output_scroll_viewer;
        }

        public void expander()
        {
            String application_directory = System.AppDomain.CurrentDomain.BaseDirectory;
            String path = application_directory + "TextFile.txt";
            status_window.status_text_block.Text = application_directory;
            if (File.Exists(path))
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    String raw = sr.ReadLine();
                    String[] raws = raw.Split('=');
                    if (raws[1].Equals("false"))
                    {
                        //Get grid splitter
                        Grid grid = grid_base;
                        ColumnDefinition c1 = grid.ColumnDefinitions[0];
                        c1.Width = new GridLength(0, GridUnitType.Star);
                        ColumnDefinition c2 = grid.ColumnDefinitions[1];
                        c2.Width = new GridLength(100, GridUnitType.Star);
                    }

                }
            }
        }

        //text box key down handler
        public static void InputFieldKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                //command extract
                String[] strings = input_text_box.Text.Split(' ');

                //command output
                String output_string = CoreSystem.CommandEnter(input_text_box.Text);
                outputs.Add(output_string);
                StringBuilder output_sb = new StringBuilder();
                for (int i = 0; i < outputs.Count; i++)
                {
                    output_sb.AppendLine("[" + i.ToString() + "] $~ " + outputs[i].ToString());
                }
                //clear command
                //2nd last
                //if (strings[0].Equals("clear"))
                //{
                //    for (int i = 0; i < 100; i++)
                //    {
                //        output_sb.AppendLine("-");
                //    }
                //}

                //print to text box
                output_text_box.Text = output_sb.ToString();

                //last
                command_history.Add(input_text_box.Text);
                input_text_box.Text = "";

                //up history
                history_counter = 0;

                //output scroll to end
                output_sv.ScrollToEnd();
            }
            else
            {
            }

            ////auto complete
            //var location = input_text_box.PointToScreen(new Point(0, 0));
            //auto_complete_window.Left = location.X;
            //auto_complete_window.Top = location.Y - auto_complete_window.Height;
            //auto_complete_window.Show();
            //input_text_box.Focus();
        }

        public class Alpha
        {
            public void Beta()
            {
                while (true)
                {
                }
            }
        };

        //input field text changed
        private void input_field_TextChanged(object sender, TextChangedEventArgs e)
        {
            //update the history string array
            StringBuilder str_builder = new StringBuilder();
            for (int i = 0; i < command_history.Count; i++)
            {
                str_builder.AppendLine("[" + i.ToString() + "] " + command_history[i].ToString());
            }

            //process the history bar
            String history_str_to_print = str_builder.ToString();
            if (history_str_to_print.Length > 2)
            {
                history_str_to_print = history_str_to_print.Remove(history_str_to_print.Length - 2, 2); //remove the last "\n"
            }
            history_text_box.Text = history_str_to_print;
            history_scroll_viewer.ScrollToEnd();

            //manual tab update
            String raw_string = input_text_box.Text;
            String[] strings = raw_string.Split(' ');
            UpdateManualTab(strings[0]);
        }

        private void history_text_box_TextChanged(object sender, TextChangedEventArgs e)
        {
            //update the history string array
            StringBuilder str_builder = new StringBuilder();
            for (int i = 0; i < command_history.Count; i++)
            {
                str_builder.AppendLine("[" + i.ToString() + "] " + command_history[i].ToString());
            }

            //process the history bar
            String history_str_to_print = str_builder.ToString();
            if (history_str_to_print.Length > 2)
            {
                history_str_to_print = history_str_to_print.Remove(history_str_to_print.Length - 2, 2); //remove the last "\n"
            }
            history_text_box.Text = history_str_to_print;
            history_scroll_viewer.ScrollToEnd();
            history_text_box.Select(history_text_box.Text.Length, 0);
        }

        //manual tab update
        public void UpdateManualTab(String command) {
            StringBuilder manual_sb = new StringBuilder();

            //clear the text box
            manual_text_box.Text = "";

            if (false) 
            {
                manual_sb.AppendLine("NAME");
                manual_sb.AppendLine("");
                manual_sb.AppendLine("");
                manual_sb.AppendLine("");
                manual_sb.AppendLine("SYNOPSIS");
                manual_sb.AppendLine("");
                manual_sb.AppendLine("");
                manual_sb.AppendLine("");
                manual_sb.AppendLine("DESCRIPTION");
                manual_sb.AppendLine("");
                manual_sb.AppendLine("");
                manual_text_box.Text = manual_sb.ToString();
            }
            else if (command.Equals("cd"))  //cd
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
            else if (command.Equals("date")) //date
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
            else if (command.Equals("pwd"))  //pwd
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

            }
        }

        //Quit
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        //New window
        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            //moves the old application location a bit
            //this.Left = this.Left - 8;
            //this.Top = this.Top - 30;

            //call the new window
            MainWindow new_main_window = new MainWindow();
            new_main_window.Show();
        }

        //Open About window
        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            AboutWindow about_window = new AboutWindow();
            about_window.Show();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (ctrl_down)
            {
                if (e.Key == Key.Q)
                {
                    if (flipper)
                    {
                        //Get grid splitter
                        Grid grid = grid_base;
                        ColumnDefinition c1 = grid.ColumnDefinitions[0];
                        c1.Width = new GridLength(30, GridUnitType.Star);
                        ColumnDefinition c2 = grid.ColumnDefinitions[1];
                        c2.Width = new GridLength(70, GridUnitType.Star);
                        history_tab.Focus();
                        input_text_box.Focus();
                    }
                    else
                    {
                        //Get grid splitter
                        Grid grid = grid_base;
                        ColumnDefinition c1 = grid.ColumnDefinitions[0];
                        c1.Width = new GridLength(0, GridUnitType.Star);
                        ColumnDefinition c2 = grid.ColumnDefinitions[1];
                        c2.Width = new GridLength(100, GridUnitType.Star);
                    }
                    flipper = !flipper;
                }
            }
            if (e.Key == Key.LeftCtrl)
            {
                ctrl_down = true;
            }
        }

        private void input_field_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void input_field_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Up)
            {
                if (history_counter < command_history.Count)
                {
                    input_field.Text = command_history[command_history.Count - history_counter - 1].ToString();
                    history_counter++;
                }
            }
        }

        private void Window_Activated(object sender, EventArgs e)
        {
            //expander();
        }

        private void Window_Initialized(object sender, EventArgs e)
        {
            //expander();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //expander();
        }

        private void Window_ContentRendered(object sender, EventArgs e)
        {
            expander();
        }

        private void MenuItem_Click_3(object sender, RoutedEventArgs e)
        {
            SettingsWindow settings_win = new SettingsWindow();
            settings_win.Show();
        }
    }
}
