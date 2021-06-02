using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowControlProject.Services
{
    class SDADecremental : IDepreciacion
    {
        public decimal[] CalcularDepreciacion(decimal valor, decimal valorSalv, int vidaUtil)
        {
            int factor = (1 - (valorSalv / valor));
            decimal[] dep = new decimal[vidaUtil];
            for (int i = 0, k = vidaUtil; i < vidaUtil; i++)
            {
                dep[i] = (valor - valorSalv) * k++ / factor;
            }
            return dep;
        }
    }
}
