using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace nexos_test.Models
{
    public class CitasModel
    {
        [Key]
        public int CitaID { get; set; }
        public string CitaDate { get; set; }
        public string CitaPacienteID { get; set; }
        public int CitaDoctorID { get; set; }
        public string CitaTOTAL { get; set; }
        public PacientesModel Pacientes { get; set; }
        public DoctoresModel Doctores { get; set; }
    }
}
