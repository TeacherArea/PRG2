using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Fordonsregister
{
    public partial class Bilregister : Form
    {
        List<Fordon> fordonsLista = new List<Fordon>(); // skapa en lista

        public Bilregister()
        {
            InitializeComponent();
            dropDownList_Typ.SelectedItem = dropDownList_Typ.Items[0];
            btn_Sok.Visible = false; // möjlig utökning av appen
            btn_SparaAndringar.Visible = false; // möjlig utökning av appen
        }
        private void Btn_Registrera_Click(object sender, EventArgs e)
        {
            try
            {
                Fordon fordon = new Fordon((Fordon.Typ)dropDownList_Typ.SelectedIndex); // här skpas objektet

                string regNr = txtBoxIn_RegNr.Text;
                fordon.RegistreringsNummer = regNr; // här anropas egenskapen RegNr, och i dess set-metod valideras 

                fordonsLista.Add(fordon); // lägg till objektet till listan
                listBox_Register.Items.Add(fordon); // visa objektet i användargränssnittet

                txtBoxIn_RegNr.Clear();
                txtBoxIn_Märke.Clear();
                txtBoxIn_Modell.Clear();
            }

            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, Text);
            }
        }

        private void radioBtn_CheckedChanged(object sender, EventArgs e)
        {
            listBox_Register.Items.Clear();
            foreach (Fordon f in fordonsLista)
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
