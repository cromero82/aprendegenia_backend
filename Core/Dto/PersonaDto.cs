using System;
using System.Collections.Generic;
using System.Text;

namespace Infraestructura.Dto
{
    public class PersonaDto
    {
        public int Id { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public string Direccion { get; set; }
    }
}
