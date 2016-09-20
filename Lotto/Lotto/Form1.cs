using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace Lotto
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            // TODO Unsichtbare Controls werden beim programmstart nicht erzeugt, ergo kein zugriff moeglich 
            //ArrayList hiddenControls = new ArrayList(100);
            //foreach (object o in tableLayoutPanel1.Controls)
            //{
            //    Control c = (Control) o;
            //    if (c.Visible == false)
            //    {
            //        hiddenControls.Add(c);
            //    }
            //    c.Visible = true;
            //}
            //foreach (Control control in hiddenControls)
            //{
            //    control.Visible = false;
            //}
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            int row = tableLayoutPanel1.GetPositionFromControl((Control)sender).Row;
            bool vis = ((CheckBox) sender).Checked;
            for (int i = 1; i < tableLayoutPanel1.ColumnCount; i++)
            {
                try
                {
                    Control con = tableLayoutPanel1.GetControlFromPosition(i, row);
                    con.Visible = vis;
                }
                catch (NullReferenceException)
                {
                    
                }
            }
        }



    }
}
