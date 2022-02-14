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
        //Most declarations are here other than syntax color styles for FCTB and the console visibility 
        public FolderBrowserDialog folderBrowserDialog;
        public string selectedLoaderFolder;
        public string SDTFile;
        public string LoaderFile;
        public string MoreClothingFolder;
        public string MoreClothingSettings;
        public string AutoGenMC;
        public bool canScan;
        public bool doesConsole = false;

        //AllocConsole(); is called in MainForm_Load
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();
        //Todo, list xml Template types with MC types as values
        enum Modtypes
        {
            Low,
            Medium,
            High
        }

        //This is the only way to 100% theme these UI elemets, I've handled the basics for my dark mode theme, could be refined e.g. colourful accent
        public class CustomColorTable : ProfessionalColorTable
        {
            public override Color MenuItemSelected
            {
                get
                {
                    return Color.FromArgb(255, 40, 42, 48);
                }
            }
            public override Color MenuItemPressedGradientBegin
            {
                get
                {
                    return Color.FromArgb(255, 40, 42, 48);
                }
            }
            public override Color MenuItemPressedGradientEnd
            {
                get
                {
                    return Color.FromArgb(255, 40, 42, 48);
                }
            }
            public override Color MenuItemSelectedGradientBegin
            {
                get
                {
                    return Color.FromArgb(255, 40, 42, 48);
                }
            }
            public override Color MenuItemSelectedGradientEnd
            {
                get
                {
                    return Color.FromArgb(255, 40, 42, 48);
                }
            }
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



        public MainForm()
        {
            InitializeComponent();

            //Nearly zero progromatic UI
            menuStrip.Renderer = new ToolStripProfessionalRenderer(new CustomColorTable());
            menuStrip.ForeColor = Color.White;
            menuStrip.BackColor = Color.FromArgb(255, 40, 42, 48);
            splitContainer1.SplitterWidth = 15;
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            //Initializes a console sub process 
            //Not a good practice for production, I imagine
            //A debug console is stupid cool, though its not utilized for that at all
            //This console runs the previous AutoMoreClothing console app code that only worked in the IDE
            //Unless told otherwise I plan to keep this
            AllocConsole();
        }
        //can't stop the console for starting as visible, gets hidded in Program.cs therfore starting position is false
        public bool debug = false;
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
            //now toggle
            debug = !debug;
        }

        //File > Open
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

                        //checks for moreclothing versions up to V100
                        for (int i = 0; i < 100; i++)
                        {
                            if (File.Exists(selectedLoaderFolder + "/Settings/moreclothingV" + i + "settings.txt"))
                            {
                                MoreClothingSettings = selectedLoaderFolder + "/Settings/moreclothingV" + i + "settings.txt";
                                if (Directory.Exists(selectedLoaderFolder + "/Mods/$INIT$/moreclothingmods"))
                                    MoreClothingFolder = selectedLoaderFolder + "/Mods/$INIT$/moreclothingmods";
                                else
                                {
                                    MessageBox.Show("Missing Moreclothing mods folder", "Error");
                                    return;
                                }
                                Console.WriteLine("Missing Moreclothing mods folder");
                                Console.WriteLine("More Clothing Settings Found");
                                string mcfs = File.ReadAllText(MoreClothingSettings);
                                fastColoredTextBoxLeft.Text = mcfs;
                                fastColoredTextBoxRight.Text = "Right click me";
                                canScan = true;     //enables right click "Generate" context menu

                                return;
                            }
                        }
                        MessageBox.Show("Missing Moreclothing settings file", "Error");
                        Console.WriteLine("Missing Moreclothing settings file");

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

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (MoreClothingSettings != null)
            {
                File.WriteAllText(MoreClothingSettings, fastColoredTextBoxLeft.Text);
                MessageBox.Show("Settings saved!", "Success");
            }
            else
            {
                MessageBox.Show("Nothing to save", "Error");
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



        Style LightGreenStyle = new TextStyle(Brushes.LightGreen, null, FontStyle.Italic);
        Style LightBlueStyle = new TextStyle(Brushes.LightSkyBlue, null, FontStyle.Regular);
        Style LightCoralStyle = new TextStyle(Brushes.LightCoral, null, FontStyle.Italic);
        Style LightYellowStyle = new TextStyle(Brushes.Cyan, null, FontStyle.Italic);

        Style LightSalmonStyle = new TextStyle(Brushes.LightSalmon, null, FontStyle.Italic);
        MarkerStyle SameWordsStyle = new MarkerStyle(new SolidBrush(Color.FromArgb(100, Color.LightYellow)));
        //ShortcutStyle shortCutStyle = new ShortcutStyle(Pens.DarkGray);

        private void fastColoredTextBoxLeft_TextChanged(object sender, TextChangedEventArgs e)
        {

            fastColoredTextBoxLeft.AllowSeveralTextStyleDrawing = false;

            fastColoredTextBoxLeft.ClearStylesBuffer();
            e.ChangedRange.ClearStyle(LightGreenStyle, LightBlueStyle, LightCoralStyle, LightYellowStyle, LightSalmonStyle, SameWordsStyle);


            fastColoredTextBoxLeft.AddStyle(LightGreenStyle);
            fastColoredTextBoxLeft.AddStyle(LightYellowStyle);
            fastColoredTextBoxLeft.AddStyle(LightSalmonStyle);



            e.ChangedRange.SetStyle(LightYellowStyle, @"\-*", RegexOptions.Multiline);

            e.ChangedRange.SetStyle(LightCoralStyle, @"\.swf*", RegexOptions.Multiline);
            e.ChangedRange.SetStyle(LightCoralStyle, @"\.png*", RegexOptions.Multiline);
            e.ChangedRange.SetStyle(LightCoralStyle, @"\.mod*", RegexOptions.Multiline);
            e.ChangedRange.SetStyle(LightCoralStyle, @"\.SWF*", RegexOptions.Multiline);
            e.ChangedRange.SetStyle(LightCoralStyle, @"\.PNG*", RegexOptions.Multiline);
            e.ChangedRange.SetStyle(LightCoralStyle, @"\.MOD*", RegexOptions.Multiline);

            e.ChangedRange.SetStyle(LightSalmonStyle, @"\:Background", RegexOptions.Multiline);
            e.ChangedRange.SetStyle(LightSalmonStyle, @"\:StaticHair", RegexOptions.Multiline);
            e.ChangedRange.SetStyle(LightSalmonStyle, @"\:DynamicHair", RegexOptions.Multiline);
            e.ChangedRange.SetStyle(LightSalmonStyle, @"\:Body", RegexOptions.Multiline);
            e.ChangedRange.SetStyle(LightSalmonStyle, @"\:Body2", RegexOptions.Multiline);
            e.ChangedRange.SetStyle(LightSalmonStyle, @"\:Body3", RegexOptions.Multiline);
            e.ChangedRange.SetStyle(LightSalmonStyle, @"\:CostumeCollar", RegexOptions.Multiline);
            e.ChangedRange.SetStyle(LightSalmonStyle, @"\:CostumeEyewear", RegexOptions.Multiline);
            e.ChangedRange.SetStyle(LightSalmonStyle, @"\:CostumeHeadwear", RegexOptions.Multiline);
            e.ChangedRange.SetStyle(LightSalmonStyle, @"\:CostumeTop", RegexOptions.Multiline);
            e.ChangedRange.SetStyle(LightSalmonStyle, @"\:CostumeBottoms", RegexOptions.Multiline);
            e.ChangedRange.SetStyle(LightSalmonStyle, @"\:CostumeBra", RegexOptions.Multiline);
            e.ChangedRange.SetStyle(LightSalmonStyle, @"\:CostumeLegwear", RegexOptions.Multiline);
            e.ChangedRange.SetStyle(LightSalmonStyle, @"\:CostumeLegwearB", RegexOptions.Multiline);
            e.ChangedRange.SetStyle(LightSalmonStyle, @"\:CostumeFootwear", RegexOptions.Multiline);
            e.ChangedRange.SetStyle(LightSalmonStyle, @"\:CostumeTonguePiercing", RegexOptions.Multiline);
            e.ChangedRange.SetStyle(LightSalmonStyle, @"\:CostumeNipplePiercing", RegexOptions.Multiline);
            e.ChangedRange.SetStyle(LightSalmonStyle, @"\:CostumeBellyPiercing", RegexOptions.Multiline);
            e.ChangedRange.SetStyle(LightSalmonStyle, @"\:CostumeEarPiercing", RegexOptions.Multiline);

            e.ChangedRange.SetStyle(LightYellowStyle, @"\:*", RegexOptions.Multiline);
            e.ChangedRange.SetStyle(LightYellowStyle, @"\>*", RegexOptions.Multiline);
            e.ChangedRange.SetStyle(LightYellowStyle, @"\+*", RegexOptions.Multiline);
            e.ChangedRange.SetStyle(LightYellowStyle, @"\-*", RegexOptions.Multiline);

            e.ChangedRange.SetStyle(LightYellowStyle, @"\\*", RegexOptions.Multiline);

            e.ChangedRange.SetStyle(LightGreenStyle, @"//.*$", RegexOptions.Multiline);
            e.ChangedRange.SetStyle(LightGreenStyle, @";.*$", RegexOptions.Multiline);
            e.ChangedRange.SetStyle(LightBlueStyle, @"\b\d+[\.]?\d*([eE]\-?\d+)?[lLdDfF]?\b|\b0x[a-fA-F\d]+\b");

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

        private void fastColoredTextBoxRight_TextChanged(object sender, TextChangedEventArgs e)
        {
            fastColoredTextBoxRight.AllowSeveralTextStyleDrawing = false;

            fastColoredTextBoxRight.ClearStylesBuffer();
            e.ChangedRange.ClearStyle(LightGreenStyle, LightBlueStyle, LightCoralStyle, LightYellowStyle, LightSalmonStyle, SameWordsStyle);

            fastColoredTextBoxRight.AddStyle(LightGreenStyle);
            fastColoredTextBoxRight.AddStyle(LightYellowStyle);
            fastColoredTextBoxRight.AddStyle(LightSalmonStyle);

            e.ChangedRange.SetStyle(LightCoralStyle, @"\.swf*", RegexOptions.Multiline);
            e.ChangedRange.SetStyle(LightCoralStyle, @"\.png*", RegexOptions.Multiline);
            e.ChangedRange.SetStyle(LightCoralStyle, @"\.mod*", RegexOptions.Multiline);
            e.ChangedRange.SetStyle(LightCoralStyle, @"\.SWF*", RegexOptions.Multiline);
            e.ChangedRange.SetStyle(LightCoralStyle, @"\.PNG*", RegexOptions.Multiline);
            e.ChangedRange.SetStyle(LightCoralStyle, @"\.MOD*", RegexOptions.Multiline);

            e.ChangedRange.SetStyle(LightSalmonStyle, @"\:Background", RegexOptions.Multiline);
            e.ChangedRange.SetStyle(LightSalmonStyle, @"\:StaticHair", RegexOptions.Multiline);
            e.ChangedRange.SetStyle(LightSalmonStyle, @"\:DynamicHair", RegexOptions.Multiline);
            e.ChangedRange.SetStyle(LightSalmonStyle, @"\:Body", RegexOptions.Multiline);
            e.ChangedRange.SetStyle(LightSalmonStyle, @"\:Body2", RegexOptions.Multiline);
            e.ChangedRange.SetStyle(LightSalmonStyle, @"\:Body3", RegexOptions.Multiline);
            e.ChangedRange.SetStyle(LightSalmonStyle, @"\:CostumeCollar", RegexOptions.Multiline);
            e.ChangedRange.SetStyle(LightSalmonStyle, @"\:CostumeEyewear", RegexOptions.Multiline);
            e.ChangedRange.SetStyle(LightSalmonStyle, @"\:CostumeHeadwear", RegexOptions.Multiline);
            e.ChangedRange.SetStyle(LightSalmonStyle, @"\:CostumeTop", RegexOptions.Multiline);
            e.ChangedRange.SetStyle(LightSalmonStyle, @"\:CostumeBottoms", RegexOptions.Multiline);
            e.ChangedRange.SetStyle(LightSalmonStyle, @"\:CostumeBra", RegexOptions.Multiline);
            e.ChangedRange.SetStyle(LightSalmonStyle, @"\:CostumeLegwear", RegexOptions.Multiline);
            e.ChangedRange.SetStyle(LightSalmonStyle, @"\:CostumeLegwearB", RegexOptions.Multiline);
            e.ChangedRange.SetStyle(LightSalmonStyle, @"\:CostumeFootwear", RegexOptions.Multiline);
            e.ChangedRange.SetStyle(LightSalmonStyle, @"\:CostumeTonguePiercing", RegexOptions.Multiline);
            e.ChangedRange.SetStyle(LightSalmonStyle, @"\:CostumeNipplePiercing", RegexOptions.Multiline);
            e.ChangedRange.SetStyle(LightSalmonStyle, @"\:CostumeBellyPiercing", RegexOptions.Multiline);
            e.ChangedRange.SetStyle(LightSalmonStyle, @"\:CostumeEarPiercing", RegexOptions.Multiline);

            e.ChangedRange.SetStyle(LightYellowStyle, @"\:*", RegexOptions.Multiline);
            e.ChangedRange.SetStyle(LightYellowStyle, @"\>*", RegexOptions.Multiline);
            e.ChangedRange.SetStyle(LightYellowStyle, @"\+*", RegexOptions.Multiline);
            e.ChangedRange.SetStyle(LightYellowStyle, @"\-*", RegexOptions.Multiline);

            e.ChangedRange.SetStyle(LightYellowStyle, @"\\*", RegexOptions.Multiline);

            e.ChangedRange.SetStyle(LightGreenStyle, @"//.*$", RegexOptions.Multiline);
            e.ChangedRange.SetStyle(LightGreenStyle, @";.*$", RegexOptions.Multiline);
            e.ChangedRange.SetStyle(LightBlueStyle, @"\b\d+[\.]?\d*([eE]\-?\d+)?[lLdDfF]?\b|\b0x[a-fA-F\d]+\b");
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

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            customDialogue.SplashForm.ShowSplashScreen();
            generate(); //this takes time
            //MessageBox.Show("Done", "Generation");
            customDialogue.SplashForm.CloseForm();
        }

        public string getModTypes(string b)
        {
            switch (b)
            {
                case "Background":
                    return "Background";
                case "StaticHair":
                    return "StaticHair";
                case "DynamicHair":
                    return "DynamicHair";
                case "Body":
                    return "Body";
                case "Collar":
                    return "CostumeCollar";
                case "Eyewear":
                    return "CostumeEyewear";
                case "Headwear":
                    return "CostumeHeadwear";
                case "Top":
                    return "CostumeTop";
                case "Bottoms":
                    return "CostumeBottoms";
                case "Bra":
                    return "CostumeBra";
                case "Legwear":
                    return "CostumeLegwear";
                case "LegwearB":
                    return "CostumeLegwearB";
                case "Footwear":
                    return "CostumeFootwear";
                case "TonguePiercing":
                    return "CostumeTonguePiercing";
                case "NipplePiercing":
                    return "CostumeNipplePiercing";
                case "BellyPiercing":
                    return "CostumeBellyPiercing";
                case "EarPiercing":
                    return "CostumeEarPiercing";
                    default: return"";
            }
        }



    public static StreamWriter writer;

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
                        mods += ":" + getModTypes(b);
                        

                    }

                    Console.WriteLine(files.Replace(dir + "\\", "") + "=" + (files.Replace(folder + "\\", "")).Replace(".swf", "") + mods);

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
                        mods += ":" + getModTypes(b);


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

}
