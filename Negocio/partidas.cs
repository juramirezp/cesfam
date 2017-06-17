using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class partidas
    {
        public int id { get; set; }
        public int med_id { get; set; }
        public DateTime fecha_elab { get; set; }
        public DateTime fecha_venc { get; set; }
        public DateTime fecha { get; set; }
        public int cantidad { get; set; }

        public bool CrearPartida(int med_id, DateTime fecha_elab, DateTime fecha_venc, int cantidad)
        {
            try
            {
                Datos2.PARTIDAS p = new Datos2.PARTIDAS();
                p.ID = GenerarId();
                p.MED_ID = med_id;
                p.FECHA_ELAB = fecha_elab;
                p.FECHA_VENC = fecha_venc;
                p.FECHA = DateTime.Today;
                p.CANTIDAD = cantidad;
                acceso.Cesfam.PARTIDAS.Add(p);
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
                    Datos2.PARTIDAS v = acceso.Cesfam.PARTIDAS.FirstOrDefault(a => a.ID == id);

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

        public Datos2.PARTIDAS BuscarPartida(int id)
        {
            try
            {
                return acceso.Cesfam.PARTIDAS.FirstOrDefault(p => p.ID == id);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool ModificarPartida(int id, int med_id, DateTime fecha_elab, DateTime fecha_venc, int cantidad)
        {
            try
            {
                Datos2.PARTIDAS p = BuscarPartida(id);
                p.MED_ID = med_id;
                p.FECHA_ELAB = fecha_elab;
                p.FECHA_VENC = fecha_venc;
                p.CANTIDAD = cantidad;
                acceso.Cesfam.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<Negocio.partidas> ListarPartidas()
        {
            try
            {
                List<Datos2.PARTIDAS> partidas = (from x in acceso.Cesfam.PARTIDAS select x).ToList();
                List<Negocio.partidas> lista = new List<Negocio.partidas>();

                foreach (var item in partidas)
                {
                    Negocio.partidas p = new Negocio.partidas();
                    p.id = Convert.ToInt32(item.ID);
                    p.med_id = Convert.ToInt32(item.MED_ID);
                    p.fecha_elab = Convert.ToDateTime(item.FECHA_ELAB);
                    p.fecha_venc = Convert.ToDateTime(item.FECHA_VENC);
                    p.cantidad = Convert.ToInt32(item.CANTIDAD);
                    lista.Add(p);
                }
                return lista;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool EliminarPartida(int id)
        {
            try
            {
                Datos2.PARTIDAS p = BuscarPartida(id);
                acceso.Cesfam.PARTIDAS.Remove(p);
                acceso.Cesfam.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
