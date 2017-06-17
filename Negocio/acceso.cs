using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class acceso
    {
        private static Datos2.CesfamEntities _cesfam;

        public static Datos2.CesfamEntities Cesfam
        {
            get
            {
                if (_cesfam == null)
                {
                    _cesfam = new Datos2.CesfamEntities();
                }
                return _cesfam;
            }
        }

        public acceso()
        {

        }
    }
}
