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
            SetControlVisibility();
        }

        private void SetControlVisibility()
        {
            for (int i = 0; i < tippsPanel.RowCount; i++)
            {
                bool vis = ((CheckBox) tippsPanel.GetControlFromPosition(0, i)).Checked;
                if (vis == false)
                {
                    SetRowVisibility(i, false);
                }
            }
        }

        private void SetRowVisibility(int row, bool visible)
        {
            for (int i = 1; i < tippsPanel.ColumnCount; i++)
            {
                tippsPanel.GetControlFromPosition(i, row).Visible = visible;
            }
        }

        private void checkBox_CheckedChanged(object sender, EventArgs e)
        {
            int row = tippsPanel.GetPositionFromControl((Control)sender).Row;
            bool vis = ((CheckBox) sender).Checked;
            SetRowVisibility(row,vis);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Lottoschein lotto = new Lottoschein(textBox1.Text);

           //to do
        }



    }
}
