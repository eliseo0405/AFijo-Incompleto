using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowControlProject.Services
{
    interface IDepreciacion
    {
        decimal[] CalcularDepreciacion(decimal valor, decimal valorSalv, int vidaUtil);
    }
}
