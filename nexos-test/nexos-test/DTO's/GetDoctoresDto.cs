using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace nexos_test.DTO_s
{
    public class GetDoctoresDto
    {
        public int PacienteNombres { get; set; }
        public List<GetPacienteDoctDto> Paciente { get; set; }
    }
}
