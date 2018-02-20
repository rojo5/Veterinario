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
    public partial class ListaVisitas : Form
    {
        Conexion conex = new Conexion();
        DataTable consultaVisitas;
        List<Visita> listadoVisitas;
        int idMascota;
        string nombre;
        public ListaVisitas(int _idMascota, String _nombre)
        {
            InitializeComponent();
            idMascota = _idMascota;
            nombre = _nombre;
            consultaVisitas = conex.obtenerVisitas(_idMascota);
            dataGridViewVisitas.DataSource = consultaVisitas;
            prepararDatos(nombre);
            this.CenterToScreen();
        }

        public void prepararDatos(String nombreMascota)
        {
            obtenerListado();
            lbTitulo.Text = "Listado de visitas de " + nombreMascota;

        }

        public void obtenerListado()
        {
            listadoVisitas = consultaVisitas.AsEnumerable()
                .Select(row => new Visita
                {
                    idVisita = row.Field<int?>(0).GetValueOrDefault(),
                    mascota = row.Field<int?>(1).GetValueOrDefault(),
                    descripcionvisita = row.Field<String>(2),
                    empleado = row.Field<int?>(3).GetValueOrDefault(),
                    fechaVisita = row.Field<DateTime>(4)

                }).ToList();
        }

        private void dataGridViewVisitas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int identificadorVisita;
            if(dataGridViewVisitas.SelectedCells.Count > 0)
            {
                int index = dataGridViewVisitas.SelectedCells[0].RowIndex;

                DataGridViewRow filaSeleccionada = dataGridViewVisitas.Rows[index];

                identificadorVisita = Convert.ToInt32(filaSeleccionada.Cells["id_visita"].Value);

                foreach(Visita visita in listadoVisitas)
                {
                    if (visita.idVisita.Equals(identificadorVisita))
                    {
                        InfoVisita infoVisita = new InfoVisita(visita);
                        infoVisita.FormClosed += new System.Windows.Forms.FormClosedEventHandler(form_FormClosed);
                        infoVisita.ShowDialog();
                    }
                }
            }
        }

        private void btnNuevaVisita_Click(object sender, EventArgs e)
        {
            NuevaVisita nuevaVisita = new NuevaVisita(idMascota, nombre);
            nuevaVisita.FormClosed += new System.Windows.Forms.FormClosedEventHandler(form_FormClosed);
            nuevaVisita.ShowDialog();
        }

        private void form_FormClosed(object sender, FormClosedEventArgs e)
        {
            actualizar();
        }

        public void actualizar()
        {
            consultaVisitas = conex.obtenerVisitas(idMascota);
            dataGridViewVisitas.DataSource = consultaVisitas;
            prepararDatos(nombre);

        }
    }
}
