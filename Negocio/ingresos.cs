using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class ingresos
    {
        public int id { get; set; }
        public int med_id { get; set; }
        public int par_id { get; set; }
        public int usu_id { get; set; }
        public int cantidad { get; set; }
        public DateTime fecha { get; set; }


        public bool CrearIngreso(int med_id, int par_id, int usu_id, int cantidad)
        {
            try
            {
                Datos2.INGRESOS i = new Datos2.INGRESOS();
                i.ID = GenerarId();
                i.MED_ID = med_id;
                i.PAR_ID = par_id;
                i.USU_ID = usu_id;
                i.CANTIDAD = cantidad;
                i.FECHA = DateTime.Today;
                acceso.Cesfam.INGRESOS.Add(i);
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
                    Datos2.INGRESOS v = acceso.Cesfam.INGRESOS.FirstOrDefault(a => a.ID == id);

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

        public Datos2.INGRESOS BuscarIngreso(int id)
        {
            try
            {
                return acceso.Cesfam.INGRESOS.FirstOrDefault(i => i.ID == id);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool ModificarIngreso(int id, int med_id, int par_id, int usu_id, int cantidad)
        {
            try
            {
                Datos2.INGRESOS i = BuscarIngreso(id);
                i.MED_ID = med_id;
                i.PAR_ID = par_id;
                i.USU_ID = usu_id;
                i.CANTIDAD = cantidad;
                acceso.Cesfam.INGRESOS.Add(i);
                acceso.Cesfam.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<Negocio.ingresos> ListarIngresos()
        {
            try
            {
                List<Datos2.INGRESOS> ingresos = (from x in acceso.Cesfam.INGRESOS select x).ToList();
                List<Negocio.ingresos> lista = new List<Negocio.ingresos>();

                foreach (var item in ingresos)
                {
                    Negocio.ingresos i = new Negocio.ingresos();
                    i.id = Convert.ToInt32(item.ID);
                    i.med_id = Convert.ToInt32(item.MED_ID);
                    i.par_id = Convert.ToInt32(item.PAR_ID);
                    i.usu_id = Convert.ToInt32(item.USU_ID);
                    i.cantidad = Convert.ToInt32(item.CANTIDAD);
                    lista.Add(i);
                }
                return lista;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
