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
    public partial class NuevaVisita : Form
    {
        int mascota, empleado;
        string descripcion, fecha;
        
        Conexion conex = new Conexion();
        public NuevaVisita(int idMascota, string nombre)
        {
            InitializeComponent();
            mascota = idMascota;
            dtFecha.MinDate = DateTime.Today;
            this.CenterToScreen();
            lbMascota.Text = nombre;
        }

        public void obtenerValores()
        {
            descripcion = tbDescripcion.Text;
            empleado = Convert.ToInt32(tbEmpleado.Text);
            fecha = dtFecha.Value.ToString("yyyy-MM-dd");
        }



        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAnadir_Click(object sender, EventArgs e)
        {
            obtenerValores();
            conex.anadirVisita(mascota, empleado, descripcion, fecha);
            MessageBox.Show("Se han realizado los cambios correctamente", "Aviso");
            this.Close();
        }

    }
}
