using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace nexos_test.Models
{
    public class DoctoresModel
    {
        [Key]
        public int DoctorID { get; set; }
        public int DoctorNumCred { get; set; }
        public string DoctorHopital { get; set; }
        public string DoctorNombre { get; set; }
        public string DoctorApellido  { get; set; }
        public string DoctorEspecialidad { get; set; }
        public List<CitasModel> DoctorCita { get; set; }
    }
}
