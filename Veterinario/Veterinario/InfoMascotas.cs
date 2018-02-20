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
    public partial class InfoMascotas : Form

    {
        Mascota mascota = new Mascota();
        Conexion conex = new Conexion();
        int idMascota;
        string nombre;
        public InfoMascotas(Mascota animal)
        {
            this.mascota = animal;
            InitializeComponent();
            this.CenterToScreen();
            rellenarCampos();
        }


        private void rellenarCampos()
        {
            string imagen = mascota.imagen;
            tbChip.Text = Convert.ToString(mascota.chip);
            tbEspecie.Text = mascota.especie;
            tbId.Text = Convert.ToString(mascota.idMascota);
            //tbnacimiento.Text = Convert.ToString(mascota.fechaNacimiento);
            dtFechaNac.Value = mascota.fechaNacimiento;
            tbNombre.Text = mascota.nombre;
            tbPropietario.Text = Convert.ToString(mascota.propietario);
            tbRaza.Text = mascota.raza;
            tbSexo.Text = mascota.sexo;
            Console.WriteLine("..\\..\\fotos\\"+ imagen);
            pbFoto.Image = Image.FromFile("..\\..\\fotos\\" + imagen);

        }
     

        private void btnEditar_Click(object sender, EventArgs e)
        {
            tbChip.Enabled = true;
            tbEspecie.Enabled = true;
            dtFechaNac.Enabled = true;
            tbNombre.Enabled = true;
            tbPropietario.Enabled = true;
            tbRaza.Enabled = true;
            tbSexo.Enabled = true;

            btnGuardar.Visible = true;
            btnCancelar.Visible = true;

            btnEditar.Enabled = false;
            btnEliminar.Enabled = false;
            btnVisitas.Enabled = false;

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            tbChip.Enabled = false;
            tbEspecie.Enabled = false;
            dtFechaNac.Enabled = false;
            tbNombre.Enabled = false;
            tbPropietario.Enabled = false;
            tbRaza.Enabled = false;
            tbSexo.Enabled = false;

            btnGuardar.Visible = false;
            btnCancelar.Visible = false;

            btnEditar.Enabled = true;
            btnEliminar.Enabled = true;
            btnVisitas.Enabled = true;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

            const string mensaje ="¿Estas seguro de que quieres borrar este registro?";
            const string titulo = "AVISO";
            var result = MessageBox.Show(mensaje, titulo, MessageBoxButtons.YesNo,  MessageBoxIcon.Question);

            // If the no button was pressed ...
            if (result == DialogResult.Yes)
            {
                conex.eliminarMascota(Convert.ToInt32(tbId.Text));
                this.Close();
            }


        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
             idMascota = Convert.ToInt32(tbId.Text);
            int chip = Convert.ToInt32(tbChip.Text);
            nombre = tbNombre.Text;
            int propietario = Convert.ToInt32(tbPropietario.Text);
            string especie = tbEspecie.Text;
            string raza = tbRaza.Text;
            string fecha = dtFechaNac.Value.ToString("yyyy-MM-dd");
            string sexo = tbSexo.Text;

            conex.modificarMascota(idMascota, nombre, sexo, raza, especie, chip, fecha, propietario);

            
            
            tbChip.Enabled = false;
            tbEspecie.Enabled = false;
            dtFechaNac.Enabled = false;
            tbNombre.Enabled = false;
            tbPropietario.Enabled = false;
            tbRaza.Enabled = false;
            tbSexo.Enabled = false;

            btnGuardar.Visible = false;
            btnCancelar.Visible = false;

            btnEditar.Enabled = true;
            btnEliminar.Enabled = true;
            btnVisitas.Enabled = true;

            MessageBox.Show("Se han realizado los cambios correctamente", "Aviso");
        }

        private void btnVisitas_Click(object sender, EventArgs e)
        {
            idMascota = Convert.ToInt32(tbId.Text);
            nombre = tbNombre.Text;
            ListaVisitas visitas = new ListaVisitas(idMascota, nombre);
            visitas.ShowDialog();
        }
    }
}
