using PreParcial2.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PreParcial2
{
    public partial class Form1 : Form

    {
        AgenciaControllers agencia = new AgenciaControllers();
        public Form1()
        {
            InitializeComponent();
        }


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



        private void Form1_Load(object sender, EventArgs e)/// ESTO ES PERSISTENCIA PORQUE ESTOY MANTENIENDO
        {                                                 /// EL ESTADO DEL PROGRAMA ES LA INFORMACION Y EL ESTADO EN EL QUEdó                  
            FileStream fs = null;
            try
            {
                fs = new FileStream("agencia.dat", FileMode.OpenOrCreate, FileAccess.Read);
                BinaryFormatter bf = new BinaryFormatter();
                agencia = bf.Deserialize(fs) as AgenciaControllers;

            }
            catch { }
            finally
            {
                if (fs != null) fs.Close();

            }
            if (agencia != null)
            {
                agencia = new AgenciaControllers();

                agencia.AgregarVehiculo("ABC123", 45312756);
                agencia.AgregarVehiculo("ABC345", 35122536);
                agencia.AgregarVehiculo("AAA111", 33666336);
            }


        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            FileStream fs = null;
            try
            {
                fs = new FileStream("agencia.dat", FileMode.OpenOrCreate, FileAccess.Write);
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fs, agencia);
            }
            catch { }
            finally
            {
                if (fs != null) fs.Close();
            }
        }


        private void btnImportar_Click(object sender, EventArgs e)
        {

            openFileDialog1.Title = "Lista de vehiculos";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string path = openFileDialog1.FileName;

                FileStream fs = null;
                StreamReader sr = null;
                try
                {
                    fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Read);

                    sr = new StreamReader(fs);
                    while (sr.EndOfStream == false)
                    {
                        string linea = sr.ReadLine();
                        string[] campos = linea.Split(';');

                        string nroPantente = campos[0];
                        int dniDueño = Convert.ToInt32(campos[1]);

                        agencia.AgregarVehiculo(nroPantente, dniDueño);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error en la importación");
                }
                finally
                {
                    if (sr != null) sr.Close();
                    if (fs != null) fs.Close();

                }





            }
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Title = "Exportando los archivos";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string path = saveFileDialog1.FileName;

                FileStream fs = null;
                StreamWriter sw = null;
                try
                {
                    fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write);

                    sw = new StreamWriter(fs);

                    string linea = "TIPO:DENUNCIA;NroTicket;Fecha;Patente";
                    sw.WriteLine(linea);
                    linea = "TIPO:CLIENTE;NroTicket;Fecha;DNI";
                    sw.WriteLine(linea);

                    foreach (Ticket ticket in agencia.ListaAtendidos)
                    {
                        linea = ticket.ToString();
                        sw.WriteLine(linea);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error en la exportación");
                }
                finally
                {
                    if (sw != null) sw.Close();
                    if (fs != null) fs.Close();

                }
            }
        }
    }
}
