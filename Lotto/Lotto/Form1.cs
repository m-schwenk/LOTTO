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
        private readonly IDatabaseAdapter _database = new DBDummy();

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

        private void abschickenbutton_Click(object sender, EventArgs e)
        {
            Lottoschein lotto = new Lottoschein(losnummer.Text);
      
            for (int i=0; i < tippsPanel.RowCount; i++)
            {
                if (((CheckBox) tippsPanel.GetControlFromPosition(0, i)).Checked==true)
                {
                    int [] foo= new int[6];

                    for  (int j=1; j < tippsPanel.ColumnCount; j++)

                    {

                       foo[j-1]=Convert.ToInt32(((NumericUpDown)tippsPanel.GetControlFromPosition(j, i)).Value);
                    }

                    lotto.Add(i,foo);
                }
            }
          
          
        }

        private void numericUpDown_ValueChanged(object sender, EventArgs e)
        {
            //todo pruefen ob neuer wert schon in zeile vorhanden, wenn ja wert in-/dekrementieren bis passender wert gefunden
        }

        private void auswertungsButton_Click(object sender, EventArgs e)
        {
            ergebnisse.Text = "";
             int [] foo= new int[6];
             int superzahl = Convert.ToInt32(((NumericUpDown)tableLayoutPanel1.GetControlFromPosition(0, 1)).Value);

             for (int i = 1; i < tableLayoutPanel1.ColumnCount; i++)
            {
                foo[i - 1] = Convert.ToInt32(((NumericUpDown)tableLayoutPanel1.GetControlFromPosition(i, 1)).Value);
            }

            Ziehung z = new Ziehung(foo, superzahl, aktuelleZiehung.Value);

            GewinnklassenRechner gew_kl = new GewinnklassenRechner(_database.LeseLottoscheinAusDb(), foo, superzahl);
            foreach (string s in gew_kl.GetErgebnisse())
            {
                ergebnisse.AppendText(s);
            }



        }



    }
}
