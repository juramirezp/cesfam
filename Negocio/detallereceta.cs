using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class detallereceta
    {
        public int id { get; set; }
        public int for_id { get; set; }
        public int med_id { get; set; }
        public int ent_id { get; set; }
        public int dosis { get; set; }
        public int dias { get; set; }
        public int lapso { get; set; }
        public int cantidad { get; set; }

        public bool CrearDetalle(int for_id, int med_id, int ent_id, int dosis, int dias, int lapso)
        {
            try
            {
                Datos2.DETALLE_RECETA d = new Datos2.DETALLE_RECETA();
                d.ID = GenerarId();
                d.FOR_ID = for_id;
                d.MED_ID = med_id;
                d.ENT_ID = ent_id;
                d.DOSIS = dosis;
                d.DIAS = dias;
                d.LAPSO = lapso;
                d.CANTIDAD = CalcularCantidad(dias, lapso, dosis);
                acceso.Cesfam.DETALLE_RECETA.Add(d);
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
                    Datos2.DETALLE_RECETA v = acceso.Cesfam.DETALLE_RECETA.FirstOrDefault(a => a.ID == id);

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

        public int CalcularCantidad(int dias, int lapso, int dosis)
        {
            try
            {
                return ((dias*24)/lapso)*dosis;
            }
            catch (Exception)
            {
                return -1;
            }
        }
        public List<Negocio.detallereceta> ListarDetalles(int form_id)
        {
            List<Datos2.DETALLE_RECETA> detalles = (from x in acceso.Cesfam.DETALLE_RECETA where x.FOR_ID == form_id select x).ToList();
            List<Negocio.detallereceta> lista = new List<Negocio.detallereceta>();

            foreach (var item in detalles)
            {
                Negocio.detallereceta d = new Negocio.detallereceta();
                d.id = Convert.ToInt32(item.ID);
                d.for_id = Convert.ToInt32(item.FOR_ID);
                d.med_id = Convert.ToInt32(item.MED_ID);
                d.ent_id = Convert.ToInt32(item.ENT_ID);
                d.dosis = Convert.ToInt32(item.DOSIS);
                d.dias = Convert.ToInt32(item.DIAS);
                d.lapso = Convert.ToInt32(item.LAPSO);
                d.cantidad = Convert.ToInt32(item.CANTIDAD);
                lista.Add(d);
            }
            return lista;
        }

        public Datos2.DETALLE_RECETA BuscarDetalle(int id)
        {
            try
            {
                return acceso.Cesfam.DETALLE_RECETA.FirstOrDefault(det => det.ID == id);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool ModificarDetalle(int id, int for_id, int med_id, int ent_id, int dosis, int dias, int lapso)
        {
            try
            {
                Datos2.DETALLE_RECETA d = BuscarDetalle(id);
                d.FOR_ID = for_id;
                d.MED_ID = med_id;
                d.ENT_ID = ent_id;
                d.DOSIS = dosis;
                d.DIAS = dias;
                d.LAPSO = lapso;
                d.CANTIDAD = CalcularCantidad(dias, lapso, dosis);
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
