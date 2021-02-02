using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace nexos_test.Models
{
    public class PacientesModel
    {
        [Key]
        public int? PacienteID { get; set; }
        public string PacienteNombres { get; set; }
        public string PacienteApellidos { get; set; }
        public int PacienteSegSocial { get; set; }
        public string PacienteCodPostal { get; set; }
        public string PacienteTel  { get; set; }
        public string PacienteEdad { get; set; }
        public string PacienteEmail { get; set; }
        public List<CitasModel> PacienteCita { get; set; }
    }

}
