using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fordonsregister
{
    public partial class Form_Main : Form
    {
        List<Fordon> fordonLista = new List<Fordon>();

        public Form_Main()
        {
            InitializeComponent();
            dropDownList_Typ.SelectedItem = dropDownList_Typ.Items[0];
            btn_Sok.Visible = false;
            btn_SparaAndringar.Visible = false;
        }
        private void Btn_Registrera_Click(object sender, EventArgs e)
        {
            try
            {   
                Fordon nyttFordon = new Fordon("", txtBoxIn_Märke.Text, txtBoxIn_Modell.Text,
                (Fordon.Typ)dropDownList_Typ.SelectedIndex);

                string regNr = txtBoxIn_RegNr.Text;
                nyttFordon.RegNr = regNr;

                fordonLista.Add(nyttFordon);
                listBox_Register.Items.Add(nyttFordon);
                txtBoxIn_RegNr.Clear();
                txtBoxIn_Märke.Clear();
                txtBoxIn_Modell.Clear();
            }

            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, Text);
            }



            /* Om man använder en metod istället för egenskaper, kan denna kod fungera istället
             * lägg märket till att denna kod använder den andra konstruktorn
             */

            //try
            //{
            //    string regNr = Fordon.GodkännRegNr(txtBoxIn_RegNr.Text);

            //    if (regNr == null)
            //    {
            //        MessageBox.Show("Vänligen använd formatet ABC123", Text);
            //        return;
            //    }

            //    foreach (Fordon f in fordonLista)
            //    {
            //        if (regNr == f.RegNr)
            //        {
            //            MessageBox.Show("Registreringsnumret finns redan inlagt i registret", Text);
            //        }
            //    }
            //    Fordon nyttFordon = new Fordon(regNr, txtBoxIn_Märke.Text, txtBoxIn_Modell.Text,
            //        (Fordon.Typ)dropDownList_Typ.SelectedIndex);

            //    fordonLista.Add(nyttFordon);
            //    listBox_Register.Items.Add(nyttFordon);
            //    txtBoxIn_RegNr.Clear();
            //    txtBoxIn_Märke.Clear();
            //    txtBoxIn_Modell.Clear();
            //}
            //catch
            //{
            //    MessageBox.Show("Något gick fel", Text);
            //}
        }

        private void radioBtn_CheckedChanged(object sender, EventArgs e)
        {
            listBox_Register.Items.Clear();
            foreach (Fordon f in fordonLista)
            {
                if (f.Fordonstyp != Fordon.Typ.Bil && radioBtn_Bilar.Checked) continue;
                if (f.Fordonstyp != Fordon.Typ.MC && radioBtn_MC.Checked) continue;
                if (f.Fordonstyp != Fordon.Typ.Lastbil && radioBtn_Lastbil.Checked) continue;
                if (f.Fordonstyp != Fordon.Typ.Släp && radioBtn_Slap.Checked) continue;
                if (f.Fordonstyp != Fordon.Typ.Mopedbil && radioBtn_Mopedbil.Checked) continue;
                listBox_Register.Items.Add(f);
            }
        }
    }
}
