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
        List<Fordon> fordon = new List<Fordon>();
        
        public Form_Main()
        {
            InitializeComponent();
            dropDownList_Typ.SelectedItem = dropDownList_Typ.Items[0];
            btn_Sok.Visible = false;
            btn_SparaAndringar.Visible = false;
        }
        private void Btn_Registrera_Click(object sender, EventArgs e)
        {
            string regNr = Fordon.GodkännRegNr(txtBoxIn_RegNr.Text);
            if (regNr == null)
            {
                MessageBox.Show("Vänligen använd formatet ABC123", Text);
                return;
            }

            foreach (Fordon f in fordon)
            {
                if (regNr == f.RegNr)
                {
                    MessageBox.Show("Registreingsnumret finns redan inlagt i registret", Text); 
                }
            }
            Fordon nyttFordon = new Fordon(regNr, txtBoxIn_Märke.Text, txtBoxIn_Modell.Text, 
                (Fordon.Typ)dropDownList_Typ.SelectedIndex);

            fordon.Add(nyttFordon);
            listBox_Register.Items.Add(nyttFordon);
            txtBoxIn_RegNr.Clear();
            txtBoxIn_Märke.Clear();
            txtBoxIn_Modell.Clear();
        }

        private void radioBtn_CheckedChanged(object sender, EventArgs e)
        {
            listBox_Register.Items.Clear();
            foreach (Fordon f in fordon)
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
