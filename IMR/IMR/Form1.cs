using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IMR
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            


        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sexo = "";
            if (this.rdbFemenino.Checked)
            {
                sexo = "femenino";
            }
            if (this.rdbMasculino.Checked)
            {
                sexo = "masculino";
            }
            int peso;
            float altura;
            int edad;
            int.TryParse(this.txtPeso.Text, out peso);
            int.TryParse(this.txtEdad.Text, out edad);
            float.TryParse(this.txtAltura.Text, out altura);
            IMRClass IMR = new IMRClass(sexo, peso, altura, edad);
            lblTotal.Text = IMR.CalcularIMR().ToString();
        }
    }
}
