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
        private readonly IDatabaseAdapter _database = new MySQL_Adapter();

        public Form1()
        {
            InitializeComponent();
            SetControlVisibility();
            Abgabedatum.Value = DateTime.Today;
            aktuelleZiehung.Value = DateTime.Today;
            laufzeit.SelectedIndex = 0;
            DateTime date = DateTime.Today;
            while ((date.DayOfWeek != DayOfWeek.Wednesday) && (date.DayOfWeek != DayOfWeek.Saturday))
            {
                date = date.AddDays(1);
            }
            Mittwoch.Checked = date.DayOfWeek == DayOfWeek.Wednesday;
            Samstag.Checked = date.DayOfWeek == DayOfWeek.Saturday;
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
            int lz = 1;
            try
            {
                lz = Convert.ToInt32(laufzeit.SelectedItem);
            }
            catch (Exception)
            {
                
            }
            Lottoschein lotto = new Lottoschein(
                losnummer.Text,
                Abgabedatum.Value,
                Samstag.Checked,
                Mittwoch.Checked,
                spiel77.Checked,
                super6.Checked,
                lz
                );
      
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

            _database.SchreibeLottoscheinInDb(lotto);
          
        }

        private void numericUpDown_ValueChanged(object sender, EventArgs e)
        {
            //todo pruefen ob neuer wert schon in zeile vorhanden, wenn ja wert in-/dekrementieren bis passender wert gefunden
        }

        private void auswertungsButton_Click(object sender, EventArgs e)
        {
            ergebnisse.Text = "";
            int [] ziehungZahlen = new int[6];
            int ziehungSuperzahl = (int) this.superzahl.Value;

             for (int i = 0; i < tableLayoutPanel1.ColumnCount; i++)
            {
                ziehungZahlen[i] = (int)((NumericUpDown)tableLayoutPanel1.GetControlFromPosition(i, 0)).Value;
            }

             Lottoschein lotto = new Lottoschein(losnummer.Text);

             for (int i = 0; i < tippsPanel.RowCount; i++)
             {
                 if (((CheckBox)tippsPanel.GetControlFromPosition(0, i)).Checked == true)
                 {
                     int[] foo = new int[6];

                     for (int j = 1; j < tippsPanel.ColumnCount; j++)
                     {

                         foo[j - 1] = Convert.ToInt32(((NumericUpDown)tippsPanel.GetControlFromPosition(j, i)).Value);
                     }

                     lotto.Add(i+1, foo);
                 }
             }

            Ziehung z = new Ziehung(ziehungZahlen, ziehungSuperzahl, aktuelleZiehung.Value);

            GewinnklassenRechner ziehungsAuswertung = new GewinnklassenRechner(lotto, ziehungZahlen, ziehungSuperzahl);
//            GewinnklassenRechner ziehungsAuswertung = new GewinnklassenRechner(_database.LeseLottoscheinAusDb(), ziehungZahlen, ziehungSuperzahl);
            foreach (string s in ziehungsAuswertung.GetErgebnisse())
            {
                ergebnisse.AppendText(s + "\n");
            }

//            _database.SchreibeZiehungInDb(z);

        }



    }
}
