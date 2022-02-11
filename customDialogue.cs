using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace MoreClothingGUI
{
    public partial class customDialogue : Form
    {
        public customDialogue()
        {
            InitializeComponent();
        }

        private void customDialogue_Load(object sender, EventArgs e)
        {
            //Application.DoEvents();
        }


        public class SplashForm : Form
        {
            //Delegate for cross thread call to close
            private delegate void CloseDelegate();

            //The type of form to be displayed as the splash screen.
            private static SplashForm splashForm;

            static public void ShowSplashScreen()
            {
                // Make sure it is only launched once.    
                if (splashForm != null) return;
                splashForm = new SplashForm();
                Thread thread = new Thread(new ThreadStart(SplashForm.ShowForm));
                thread.IsBackground = true;
                thread.SetApartmentState(ApartmentState.STA);
                splashForm.FormBorderStyle = FormBorderStyle.None;
                splashForm.StartPosition = FormStartPosition.CenterScreen;
                splashForm.Width = 251;
                splashForm.Height = 26;

                Label label1 = new System.Windows.Forms.Label();
                label1.AutoSize = true;
                label1.CausesValidation = false;
                label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.25F);
                label1.Location = new System.Drawing.Point(0, 0);
                label1.Name = "label1";
                label1.Size = new System.Drawing.Size(251, 26);
                label1.TabIndex = 0;
                label1.Text = "This can take a few mins";
                label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                label1.UseWaitCursor = true;

                splashForm.Controls.Add(label1);

                thread.Start();
            }

            static private void ShowForm()
            {
                if (splashForm != null) Application.Run(splashForm);
            }

            static public void CloseForm()
            {
                splashForm?.Invoke(new CloseDelegate(SplashForm.CloseFormInternal));
            }

            static private void CloseFormInternal()
            {
                if (splashForm != null)
                {
                    splashForm.Close();
                    splashForm = null;
                };
            }
        }
    }
}