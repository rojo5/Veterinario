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
    public partial class Contenedor : Form
    {
        //Pruebas de conexion

        Conexion conex = new Conexion();
        
        // Mascota[] listadoMascotas = new Mascota[99]; // meter valor devuelto por la consulta
        DataTable consultaMascotas;
        List<Mascota> listaMascotas;
        public Contenedor()
        {
            InitializeComponent();
            //this.SystemColorsChanged += System.Drawing
            this.CenterToScreen();
            consultaMascotas = conex.obtenerMascotas();
            obtenerListado();
            dataGridViewMascotas.DataSource = consultaMascotas;

        }

        public void obtenerListado()
        {
            listaMascotas = consultaMascotas.AsEnumerable()
                .Select(row => new Mascota
                {
                    /*  CardName = String.IsNullOrEmpty(row.Field<string>(1))
                      ? "not found"
                      : row.Field<string>(1),*/
                    idMascota = row.Field<int?>(0).GetValueOrDefault(),
                    nombre = row.Field<string>(1),
                    sexo = row.Field<string>(2),
                    raza = row.Field<string>(3),
                    especie = row.Field<string>(4),
                    chip = row.Field<int?>(5).GetValueOrDefault(),
                    fechaNacimiento = row.Field<DateTime>(6),
                    propietario = row.Field<int?>(7).GetValueOrDefault(),
                    imagen = String.IsNullOrEmpty(row.Field<string>(8))
                      ? "notImage.png"
                      : row.Field<string>(8)
                }).ToList();
        }
        

        private void dataGridViewMascotas_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int identificador;
            if ( dataGridViewMascotas.SelectedCells.Count > 0)
            {
                int index = dataGridViewMascotas.SelectedCells[0].RowIndex;

                DataGridViewRow filaSeleccionada = dataGridViewMascotas.Rows[index];

                 identificador = Convert.ToInt32(filaSeleccionada.Cells["id_mascota"].Value);

                Console.WriteLine("Identificador: " + identificador);

                foreach (Mascota animal in listaMascotas)
                {

                    if (animal.idMascota.Equals(identificador))
                    {
                        InfoMascotas inf = new InfoMascotas(animal);
                        inf.FormClosed += new System.Windows.Forms.FormClosedEventHandler(form_FormClosed);
                        inf.ShowDialog();
                    }
                    
                }
            }


           
        }

        private void form_FormClosed(object sender, FormClosedEventArgs e)
        {
            actualizar();
        }

        private void btnNuevaMascota_Click(object sender, EventArgs e)
        {
            NuevaMascota nuevaMascota = new NuevaMascota();
            nuevaMascota.FormClosed += new System.Windows.Forms.FormClosedEventHandler(form_FormClosed);
            nuevaMascota.ShowDialog();
            
        }

        public void actualizar()
        {
           
            consultaMascotas = conex.obtenerMascotas();
            obtenerListado();
            dataGridViewMascotas.DataSource = consultaMascotas;
        }


        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string textoBuscado = tbBuscador.Text;

            if(textoBuscado == "")
            {
                return;
            }

            listaMascotas = null;
            consultaMascotas = null;
            dataGridViewMascotas.DataSource = null;
            dataGridViewMascotas.Refresh();
            consultaMascotas = conex.buscarMascota(textoBuscado );
            obtenerListado();
            dataGridViewMascotas.DataSource = consultaMascotas;
            
        }
    }
}
