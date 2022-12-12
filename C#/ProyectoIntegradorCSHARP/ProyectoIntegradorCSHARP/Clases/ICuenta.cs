using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoIntegradorCSHARP.Clases
{
    interface ICuenta
    {
        String subtotal();
        String IVA();
        String total();
    }
}
