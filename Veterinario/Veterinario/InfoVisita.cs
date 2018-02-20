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
    public partial class InfoVisita : Form
    {
        Visita visita = new Visita();
        Conexion conex = new Conexion();
        public InfoVisita(Visita _visita)
        {
            this.visita = _visita;
            InitializeComponent();
            rellenarCampos();
            this.CenterToScreen();
        }

        public void rellenarCampos()
        {
            lbMascota.Text = Convert.ToString(visita.mascota);
            tbEmpleado.Text = Convert.ToString(visita.empleado);
            tbDescripcion.Text = visita.descripcionvisita;
            dtFecha.Value = visita.fechaVisita;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            btnCancelar.Visible = true;
            btnGuardar.Visible = true;
            btnEliminar.Enabled = false;
            btnEditar.Enabled = false;

            tbEmpleado.Enabled = true;
            tbDescripcion.Enabled = true;
            dtFecha.Enabled = true;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            btnCancelar.Visible = false;
            btnGuardar.Visible = false;
            btnEliminar.Enabled = true;
            btnEditar.Enabled = true;

            tbEmpleado.Enabled = false;
            tbDescripcion.Enabled = false;
            dtFecha.Enabled = false;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            const string mensaje = "¿Estas seguro de que quieres borrar esta Visita?";
            const string titulo = "AVISO";
            var result = MessageBox.Show(mensaje, titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // If the no button was pressed ...
            if (result == DialogResult.Yes)
            {
                conex.eliminarVisita(visita.idVisita);
                this.Close();
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            int idVisita = visita.idVisita;
            int mascota = Convert.ToInt32(lbMascota.Text);
            string descripcion = tbDescripcion.Text;
            int empleado = Convert.ToInt32(tbEmpleado.Text);
            string fecha = dtFecha.Value.ToString("yyyy-MM-dd");

            conex.modificarVisita(idVisita, mascota, descripcion, empleado, fecha);

            tbDescripcion.Enabled = false;
            tbEmpleado.Enabled = false;
            dtFecha.Enabled = false;

            btnEditar.Enabled = true;
            btnEliminar.Enabled = true;

            btnCancelar.Visible = false;
            btnGuardar.Visible = false;


            MessageBox.Show("Se han realizado los cambios correctamente", "Aviso");
        }
    }
}
