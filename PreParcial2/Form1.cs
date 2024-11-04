using PreParcial2.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PreParcial2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        AgenciaControllers Ag = new AgenciaControllers();

        private void btnTicket_Click(object sender, EventArgs e)
        {
            if (rbtnDenuncia.Checked)
            { 
                string patente = txbPatente.Text;

                Vehiculo v = Ag[patente];
            }

            else if (rbtnNuevo.Checked)
            {
                long dni = Convert.ToInt32(txbDNI.Text);


            }
        }
    }
}
