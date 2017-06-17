using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class alertas
    {
        public int id { get; set; }
        public int pac_id { get; set; }
        public int res_id { get; set; }
        public DateTime fecha { get; set; }

        public bool CrearAlerta(int pac_id, int res_id)
        {
            try
            {
                Datos2.ALERTAS a = new Datos2.ALERTAS();
                a.ID = GenerarId();
                a.PAC_ID = pac_id;
                a.RES_ID = res_id;
                a.FECHA = DateTime.Today;
                acceso.Cesfam.ALERTAS.Add(a);
                acceso.Cesfam.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public int GenerarId()
        {
            try
            {
                Random rnd = new Random();
                bool ok = false;

                while (ok)
                {
                    id = rnd.Next();
                    Datos2.ALERTAS v = acceso.Cesfam.ALERTAS.FirstOrDefault(a => a.ID == id);

                    if (v == null)
                    {
                        ok = true;
                    }
                }
                return id;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public List<Negocio.alertas> Listaralertas()
        {
            List<Datos2.ALERTAS> alertas = (from x in acceso.Cesfam.ALERTAS select x).ToList();
            List<Negocio.alertas> lista = new List<Negocio.alertas>();

            foreach (var item in alertas)
            {
                Negocio.alertas a = new Negocio.alertas();
                a.id = Convert.ToInt32(item.ID);
                a.pac_id = Convert.ToInt32(item.PAC_ID);
                a.res_id = Convert.ToInt32(item.RES_ID);
                a.fecha = Convert.ToDateTime(item.FECHA);
                lista.Add(a);
            }
            return lista;
        }
    }
}
