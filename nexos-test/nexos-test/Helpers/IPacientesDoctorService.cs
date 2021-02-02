using nexos_test.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace nexos_test.Helpers
{
    public interface IPacientesDoctorService
    {
        List<DoctoresModel> GetDoctores();
        DoctoresModel GetDoctoresById(int Id);

    }
}
