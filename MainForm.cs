using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;
using FastColoredTextBoxNS;
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.Xml;
using System.Threading;

namespace MoreClothingGUI
{

    public partial class MainForm : Form
    {

        public FolderBrowserDialog folderBrowserDialog;
        public string selectedLoaderFolder;
        public string SDTFile;
        public string LoaderFile;
        public string MoreClothingFolder;
        public string MoreClothingSettings;
        public string AutoGenMC;
        public bool canScan;
        public bool doesConsole = false;


        enum Modtypes
        {
            Low,
            Medium,
            High
        }

        public MainForm()
        {

            InitializeComponent();

            ToolStripManager.Renderer = new ToolStripProfessionalRenderer(new CustomColorTable());

            menuStrip.ForeColor = Color.White;
            menuStrip.BackColor = Color.FromArgb(255, 40, 42, 48);

            splitContainer1.SplitterWidth = 15;
        }
        private void MainForm_Load(object sender, EventArgs e)
        {


            AllocConsole();

        }

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();

        private void testToolStripMenuItem_Click(object sender, EventArgs e)
        {
            folderBrowserDialog = new FolderBrowserDialog();
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                selectedLoaderFolder = folderBrowserDialog.SelectedPath;
                SDTFile = selectedLoaderFolder + "/SDT.swf";
                if (File.Exists(SDTFile))
                {
                    Console.WriteLine("SDT Found");
                    LoaderFile = selectedLoaderFolder + "/loader.swf";
                    if (File.Exists(LoaderFile))
                    {
                        Console.WriteLine("Loader Found");
                        MoreClothingSettings = selectedLoaderFolder + "/Settings/moreclothingV11settings.txt";
                        if (File.Exists(MoreClothingSettings))
                        {
                            string mcfs = File.ReadAllText(MoreClothingSettings);
                            fastColoredTextBoxLeft.Text = mcfs;
                            fastColoredTextBoxRight.Text = "Right click me";
                            canScan = true;
                            MoreClothingFolder = selectedLoaderFolder + "/Mods/$INIT$/moreclothingmods";

                        }
                        else
                        {
                            MessageBox.Show("moreclothingV11settings.txt\ncan not be found", "Error");
                            Console.WriteLine("moreclothingV11settings.txt\ncan not be found");
                        }

                    }
                    else
                    {
                        MessageBox.Show("Loader\ncan not be found", "Error");
                        Console.WriteLine("This is not a loader folder");
                    }
                }
                else
                {
                    MessageBox.Show("SDT.swf\ncan not be found", "Error");
                    Console.WriteLine("This is not a loader folder");
                }

            }
            else
            {

            }
        }
        private void editEntryArguments_Click(object sender, EventArgs e)
        {
            /*
             FormCollection fc = Application.OpenForms;

            foreach (Form frm in fc)
            {
                if (frm.Name == "EntryArguments")
                {
                    return;
                }
            }
            new MultiFormContext(new EntryArguments());
            */
            MessageBox.Show("Work in Progress", "Message");
        }

        private void zoomInToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fastColoredTextBoxLeft.Zoom += 50;
            fastColoredTextBoxRight.Zoom += 50;
        }

        private void zoomOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fastColoredTextBoxLeft.Zoom -= 50;
            fastColoredTextBoxRight.Zoom -= 50;
        }

        private void toggleOrientationToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (splitContainer1.Orientation == Orientation.Horizontal)

            {
                splitContainer1.Orientation = Orientation.Vertical;
                splitContainer1.SplitterDistance = 360;

                splitContainer1.Panel1MinSize = 360;
                splitContainer1.Panel2MinSize = 360;
                splitContainer1.Panel1MinSize = 640;
                splitContainer1.Panel2MinSize = 640;

                splitContainer1.Panel1MinSize = 0;
                splitContainer1.Panel2MinSize = 0;
                splitContainer1.Panel1MinSize = 0;
                splitContainer1.Panel2MinSize = 0;

            }
            else
            {
                splitContainer1.Orientation = Orientation.Horizontal;

                splitContainer1.SplitterDistance = 640;
                splitContainer1.Panel1MinSize = 360;
                splitContainer1.Panel2MinSize = 360;
                splitContainer1.Panel1MinSize = 640;
                splitContainer1.Panel2MinSize = 640;

                splitContainer1.Panel1MinSize = 0;
                splitContainer1.Panel2MinSize = 0;
                splitContainer1.Panel1MinSize = 0;
                splitContainer1.Panel2MinSize = 0;
            }
        }

        private void undoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            fastColoredTextBoxLeft.Undo();
        }

        private void redoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            fastColoredTextBoxLeft.Redo();
        }
        Style GreenStyle = new TextStyle(Brushes.LightGreen, null, FontStyle.Italic);
        Style LightBlueStyle = new TextStyle(Brushes.LightSkyBlue, null, FontStyle.Regular);
        Style MagentaStyle = new TextStyle(Brushes.Magenta, null, FontStyle.Italic);


        MarkerStyle SameWordsStyle = new MarkerStyle(new SolidBrush(Color.FromArgb(100, Color.LightYellow)));
        //ShortcutStyle shortCutStyle = new ShortcutStyle(Pens.DarkGray);
        private void fastColoredTextBoxLeft_TextChanged(object sender, TextChangedEventArgs e)
        {

            fastColoredTextBoxLeft.AllowSeveralTextStyleDrawing = false;

            fastColoredTextBoxLeft.ClearStylesBuffer();
            e.ChangedRange.ClearStyle(GreenStyle, LightBlueStyle);


            fastColoredTextBoxLeft.AddStyle(GreenStyle);


            e.ChangedRange.SetStyle(MagentaStyle, @"\.swf*", RegexOptions.Multiline);
            e.ChangedRange.SetStyle(MagentaStyle, @"\.png*", RegexOptions.Multiline);
            e.ChangedRange.SetStyle(MagentaStyle, @"\.mod*", RegexOptions.Multiline);
            e.ChangedRange.SetStyle(MagentaStyle, @"\.SWF*", RegexOptions.Multiline);
            e.ChangedRange.SetStyle(MagentaStyle, @"\.PNG*", RegexOptions.Multiline);
            e.ChangedRange.SetStyle(MagentaStyle, @"\.MOD*", RegexOptions.Multiline);

            e.ChangedRange.SetStyle(GreenStyle, @"//.*$", RegexOptions.Multiline);
            e.ChangedRange.SetStyle(GreenStyle, @";.*$", RegexOptions.Multiline);
            e.ChangedRange.SetStyle(LightBlueStyle, @"\b\d+[\.]?\d*([eE]\-?\d+)?[lLdDfF]?\b|\b0x[a-fA-F\d]+\b");

        }

        private void fastColoredTextBoxLeft_SelectionChangedDelayed(object sender, EventArgs e)
        {

        }

        private void fastColoredTextBoxLeft_Click(object sender, EventArgs e)
        {

            fastColoredTextBoxLeft.VisibleRange.ClearStyle(SameWordsStyle);
            if (!fastColoredTextBoxLeft.Selection.IsEmpty)
                return;//user selected diapason

            //get fragment around caret
            var fragment = fastColoredTextBoxLeft.Selection.GetFragment(@"\w");
            string text = fragment.Text;
            if (text.Length == 0)
                return;
            //highlight same words
            var ranges = fastColoredTextBoxLeft.VisibleRange.GetRanges("\\b" + text + "\\b").ToArray();
            if (ranges.Length > 1)
                foreach (var r in ranges)
                    r.SetStyle(SameWordsStyle);
        }

        private void fastColoredTextBoxRight_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                if (canScan)
                {

                    contextMenuStrip1.Show(Cursor.Position);

                }
            }
        }

        private void fastColoredTextBoxRight_TextChanged(object sender, TextChangedEventArgs e)
        {
            fastColoredTextBoxRight.AllowSeveralTextStyleDrawing = false;

            fastColoredTextBoxRight.ClearStylesBuffer();
            e.ChangedRange.ClearStyle(GreenStyle, LightBlueStyle);


            fastColoredTextBoxRight.AddStyle(GreenStyle);


            e.ChangedRange.SetStyle(MagentaStyle, @"\.swf*", RegexOptions.Multiline);
            e.ChangedRange.SetStyle(MagentaStyle, @"\.png*", RegexOptions.Multiline);
            e.ChangedRange.SetStyle(MagentaStyle, @"\.mod*", RegexOptions.Multiline);
            e.ChangedRange.SetStyle(MagentaStyle, @"\.SWF*", RegexOptions.Multiline);
            e.ChangedRange.SetStyle(MagentaStyle, @"\.PNG*", RegexOptions.Multiline);
            e.ChangedRange.SetStyle(MagentaStyle, @"\.MOD*", RegexOptions.Multiline);

            e.ChangedRange.SetStyle(GreenStyle, @"//.*$", RegexOptions.Multiline);
            e.ChangedRange.SetStyle(GreenStyle, @";.*$", RegexOptions.Multiline);
            e.ChangedRange.SetStyle(LightBlueStyle, @"\b\d+[\.]?\d*([eE]\-?\d+)?[lLdDfF]?\b|\b0x[a-fA-F\d]+\b");
        }




        public static StreamWriter writer;

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            customDialogue.SplashForm.ShowSplashScreen();
            generate(); //this takes time
            //MessageBox.Show("Done", "Generation");
            customDialogue.SplashForm.CloseForm();
        }


        public void generate()
        {
            string dir = MoreClothingFolder;
            
            FileStream ostrm;
            TextWriter oldOut = Console.Out;
            ostrm = new FileStream("./AutoMoreClothingGUIEntries.txt", FileMode.OpenOrCreate, FileAccess.Write);
            writer = new StreamWriter(ostrm);

            Console.SetOut(writer);
            Console.Clear();
            Console.WriteLine(";------ Hello World!");

            string[] allfolders = Directory.GetDirectories(dir, "*", SearchOption.AllDirectories);
            foreach (var folder in allfolders)
            {
                Console.WriteLine();
                Console.WriteLine((";------ ") + (folder.Replace(dir, "") + (" ------")));

                string[] swffiles = Directory.GetFiles(folder, "*.swf", SearchOption.TopDirectoryOnly);
                foreach (var files in swffiles)
                {

                    Console.SetOut(oldOut);
                    List<string> a = bread(files);
                    Console.SetOut(writer);
                    string mods = "";
                    foreach (string b in a)
                    {
                        if (!(b == "Background"))
                        {
                            mods += ":" + "Costume" + b;
                        }
                        else
                        {
                            mods += ":" + b;
                        }

                    }

                    Console.WriteLine(files.Replace(dir + "\\", "") + "=" + (files.Replace(folder + "\\","")).Replace(".swf","") + mods);

                }
                string[] modfiles = Directory.GetFiles(folder, "*.mod", SearchOption.TopDirectoryOnly);
                foreach (var files in modfiles)
                {
                    Console.SetOut(oldOut);
                    List<string> a = bread(files);
                    Console.SetOut(writer);
                    string mods = "";
                    foreach (string b in a)
                    {
                        if (!(b == "Background"))
                        {
                            mods += ":" + "Costume" + b;
                        }
                        else
                        {
                            mods += ":" + b;
                        }


                    }

                    Console.WriteLine(files.Replace(dir + "\\", "") + "=" + (files.Replace(folder + "\\", "")).Replace(".mod", "") + mods);
                }

                string[] bgfiles = Directory.GetFiles(folder, "*.png", SearchOption.TopDirectoryOnly);
                foreach (var files in modfiles)
                {
                    Console.SetOut(oldOut);
                    List<string> a = bread(files);
                    Console.SetOut(writer);
                    string mods = "";
                    foreach (string b in a)
                    {
                        if (!(b == "Background"))
                        {
                            mods += ":" + "Costume" + b;
                        }
                        else
                        {
                            mods += ":" + b;
                        }


                    }

                    Console.WriteLine(files.Replace(dir + "\\", "") + "=" + (files.Replace(folder + "\\", "")).Replace(".mod", "") + ":Background");
                }

            }

            writer.Close();
            ostrm.Close();
            Console.SetOut(oldOut);
            Console.WriteLine("Done");
            fastColoredTextBoxRight.Text = File.ReadAllText("AutoMoreClothingGUIEntries.txt");
            //Console.ReadLine();
        }

        List<string> bread(string f)
        {
            //Console.WriteLine();
            // Console.WriteLine((";------ ") + (folder.Replace(dir, "") + (" ------")));

            XmlDocument doc = new XmlDocument();

            if (File.Exists(f + ".xml"))
            {
                doc.Load(f + ".xml");
            }
            else
            {
                Process p = new Process();
                p.StartInfo = new ProcessStartInfo();
                p.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.CreateNoWindow = true;
                p.StartInfo.FileName = "swfmill.exe";
                p.StartInfo.Arguments = "swf2xml \"" + f + "\" \"" + f + ".xml\"";
                p.StartInfo.RedirectStandardOutput = true;
                p.Start();
                p.WaitForExit();

                doc.Load(f + ".xml");
            }

            XmlElement root = doc.DocumentElement;
            XmlNodeList nodes = root.SelectNodes("//swf/Header/tags/SymbolClass/symbols/Symbol");
            List<string> list = new List<string>();
            foreach (XmlNode node in nodes)
            {

                string name = node.Attributes["name"].Value;
                if (name.Length >= 1)
                {


                    if (name.Contains("Top"))
                    {
                        list.Add("Top");
                    }
                    else if (name.Contains("Template"))
                    {
                        int index1 = name.IndexOf('.');
                        int index2 = name.IndexOf('T');
                        int index3 = index2 - index1 - 1;
                        if ((index1 >= 1))
                        {
                            if ((index2 >= 1))
                            {
                                if (index3 > 0)
                                    list.Add(name.Substring(index1 + 1, index2 - index1 - 1));
                            }


                        }
                    }
                }

            }

            return list;
        }

        public bool debug = false; //can't stop the console for starting as visible, gets hidded in Program.cs therfore starting position is false


        private void debugToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //read first
            if (debug)
            {
                Program.HideConsoleWindow();
            }
            else
            {
                Program.ShowConsoleWindow();
            }
            debug = !debug; //now change
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (MoreClothingSettings != null)
            {
                File.WriteAllText(MoreClothingSettings, fastColoredTextBoxLeft.Text);
                MessageBox.Show("moreclothingV11settings.txt \n Saved!", "Success");
            }
            else
            {
                MessageBox.Show("Nothing to save", "Error");
            }
        }

        private void fastColoredTextBoxLeft_CustomAction(object sender, CustomActionEventArgs e)
        {

        }

        private void purgeToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (MoreClothingFolder == null)
                return;
            if (File.Exists("./AutoMoreClothingGUIEntries.txt"))
                File.Delete("./AutoMoreClothingGUIEntries.txt");
            if (MessageBox.Show("This will significantly lower your moreclothing folders file size\nBut will also significantly raise generation time\nXML files will again be Generated\nOnly do this when you want to zip and share your moreclothing Matrix.", "Are you sure?", MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
            {
               
                string dir = MoreClothingFolder;
                string[] allfolders = Directory.GetDirectories(dir, "*", SearchOption.AllDirectories);
                foreach (var folder in allfolders)
                {

                    string[] allfiles = Directory.GetFiles(folder, "*.xml", SearchOption.TopDirectoryOnly);

                    foreach (var files in allfiles)
                    {
                        if (Path.GetExtension(files)==".xml")
                            File.Delete(files);
                    }
                }
            }
            selectedLoaderFolder = null;
            SDTFile = null;
            LoaderFile = null;
            MoreClothingFolder = null;
            MoreClothingSettings = null;
            AutoGenMC = null;
            canScan = false;
            doesConsole = false;
            fastColoredTextBoxLeft.Text = "";
            fastColoredTextBoxRight.Text = "";
    }

    }





    public class CustomColorTable : ProfessionalColorTable
    {
        public override Color ImageMarginGradientBegin
        {
            get
            {
                return Color.FromArgb(255, 40, 42, 48);
            }
        }

        public override Color ImageMarginGradientMiddle
        {
            get
            {
                return Color.FromArgb(255, 40, 42, 48);
            }
        }

        public override Color ImageMarginGradientEnd
        {
            get
            {
                return Color.FromArgb(255, 40, 42, 48);
            }
        }

        public override Color ToolStripDropDownBackground
        {
            get
            {
                return Color.FromArgb(255, 40, 42, 48);
            }
        }
    }
}
