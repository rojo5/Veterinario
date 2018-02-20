using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Veterinario
{
    public partial class NuevaMascota : Form
    {
        public string nombre, sexo, raza, especie, imagen, fecha;
        public int  chip, propietario;
        public DateTime fechaNacimiento;

        

        Conexion conexion = new Conexion();

        public NuevaMascota()
        {
            InitializeComponent();
            this.CenterToScreen();
        }


        private void obtenerValores()
        {
            nombre = tbNombre2.Text;
            sexo = tbSexo2.Text;
            raza = tbRaza2.Text;
            especie = tbEspecie2.Text;
            chip = Convert.ToInt32(tbChip2.Text);
            propietario = Convert.ToInt32(tbPropietario2.Text);
            fecha = dtFecha.Value.ToString("yyyy-MM-dd");
            Console.WriteLine("de la caja " + fecha);

            
            

            if(tbImagen.Text == "")
            {
                imagen = "notImage.png";
            }
            else
            {
                imagen = tbImagen.Text;
            }
        }

        private void btnCancelar2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuardar2_Click(object sender, EventArgs e)
        {
            obtenerValores();
            conexion.anadirMascota(nombre, sexo, raza, especie, chip, fecha, propietario, imagen);
            this.Close();
           
            
        }
    }
}
