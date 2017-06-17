using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class eliminaciones
    {
        public int id { get; set; }
        public int usu_id { get; set; }
        public int mot_id { get; set; }
        public int med_id { get; set; }
        public int par_id { get; set; }
        public int cantidad { get; set; }
        public DateTime fecha { get; set; }

        public bool CrearEliminacion(int usu_id, int mot_id, int med_id, int par_id, int cantidad)
        {
            try
            {
                Datos2.ELIMINACIONES e = new Datos2.ELIMINACIONES();
                e.ID = GenerarId();
                e.USU_ID = usu_id;
                e.MOT_ID = mot_id;
                e.MED_ID = med_id;
                e.PAR_ID = par_id;
                e.CANTIDAD = cantidad;
                e.FECHA = DateTime.Today;
                acceso.Cesfam.ELIMINACIONES.Add(e);
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
                    Datos2.ELIMINACIONES v = acceso.Cesfam.ELIMINACIONES.FirstOrDefault(a => a.ID == id);

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

        public Datos2.ELIMINACIONES BuscarEliminacion(int id)
        {
            try
            {
                return acceso.Cesfam.ELIMINACIONES.FirstOrDefault(d => d.ID == id);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool ModificarEliminacion(int id, int usu_id, int mot_id, int med_id, int par_id, int cantidad)
        {
            try
            {
                Datos2.ELIMINACIONES e = BuscarEliminacion(id);
                e.USU_ID = usu_id;
                e.MOT_ID = mot_id;
                e.MED_ID = med_id;
                e.PAR_ID = par_id;
                e.CANTIDAD = cantidad;
                acceso.Cesfam.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<Negocio.eliminaciones> ListarElminaciones()
        {
            List<Datos2.ELIMINACIONES> eliminaciones = (from x in acceso.Cesfam.ELIMINACIONES select x).ToList();
            List<Negocio.eliminaciones> lista = new List<Negocio.eliminaciones>();

            foreach (var item in eliminaciones)
            {
                Negocio.eliminaciones e = new Negocio.eliminaciones();
                e.id = Convert.ToInt32(item.ID);
                e.usu_id = Convert.ToInt32(item.USU_ID);
                e.mot_id = Convert.ToInt32(item.MOT_ID);
                e.med_id = Convert.ToInt32(item.MED_ID);
                e.par_id = Convert.ToInt32(item.PAR_ID);
                e.cantidad = Convert.ToInt32(item.CANTIDAD);
                e.fecha = Convert.ToDateTime(item.FECHA);
                lista.Add(e);
            }
            return lista;
        }
    }
}
