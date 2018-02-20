using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Veterinario
{
    public class Mascota
    {
        public string nombre, sexo, raza, especie, imagen;
        public int idMascota, chip, propietario;
        public DateTime  fechaNacimiento;

        public Mascota() { }

        public Mascota(int idMascota, string nombre, string sexo, string raza, string especie,
            int chip, DateTime fecha, int propietario, string imagen)
        {
            this.idMascota = idMascota;
            this.nombre = nombre;
            this.sexo = sexo;
            this.raza = raza;
            this.especie = especie;
            this.chip = chip;
            this.fechaNacimiento = fecha;
            this.propietario = propietario;
            this.imagen = imagen;
        }


    }
}
