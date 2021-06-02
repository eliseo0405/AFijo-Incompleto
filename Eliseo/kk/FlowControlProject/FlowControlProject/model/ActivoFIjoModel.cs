using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowControlProject.model
{
    class ActivoFIjoModel
    {
        
        private ActivoFijoModel[] activosFijo;
        private ActivoFijoModel() { }
        {

        }
        private void Add (activosFijo af)
        {
            if (activos == null)
            {
                activos = new ActivoFijo[1];
                activos[0] = af;
                return activos;
            }
            ActivoFijo[] temp = new ActivoFijo[activos.Length + 1];
            Array.Copy(activos, temp, activos.Length);
            temp[temp.Length - 1] = af;

            return temp;
        }

    public void Remove(int index)
    {
            if (index < 0)
            {
                return;
            }

            if(activosFijo == null)
            {
            return;
            }

            if(index >= activosFijo.Length)
            {
            throw new IndexOutOfRangeException($"El Index {index} está fuera de rango");
            }

            if(index == 0 && activosFijo.Length == 1)
            {
            activosFijo == null;
            }
        ActivosFijo[] temp = new ActivoFijo[activosFijo.Length - 1];
        if (index == 0 && activosFijo.Lenght ==1 )
        {
            activosFijo = null;
            return;
        }

        if(index == activosFijo.Length - 1)
        {
            Array.Copy(activosFijo, 0, tmp, 0, tmp.Length);
            activosFijo = tmp;
            return;
        }
        Array.Copy(activosFijo, 0, tmp, index);
        Array.Copy(activosFijo, index + 1, tmp.index, (tmp.Length - index));
        ActivosFijo = temp;
    }

   public ActivosFijo[] GetAll()
    {
        return ActivosFijo;
    }
}

