using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class motivoeliminacion
    {
        public int id { get; set; }
        public String nombre { get; set; }

        public bool CrearMotivoeliminacion(String nombre)
        {
            try
            {
                Datos2.MOTIVO_ELIMINACION me = new Datos2.MOTIVO_ELIMINACION();
                me.ID = GenerarId();
                me.NOMBRE = nombre;
                acceso.Cesfam.MOTIVO_ELIMINACION.Add(me);
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
                    Datos2.MOTIVO_ELIMINACION v = acceso.Cesfam.MOTIVO_ELIMINACION.FirstOrDefault(a => a.ID == id);

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

        public Datos2.MOTIVO_ELIMINACION BuscarMotivoeliminacion(int id)
        {
            try
            {
                return acceso.Cesfam.MOTIVO_ELIMINACION.FirstOrDefault(me => me.ID == id);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool ModificarMotivoeliminacion(int id, String nombre)
        {
            try
            {
                Datos2.MOTIVO_ELIMINACION me = BuscarMotivoeliminacion(id);
                me.NOMBRE = nombre;
                acceso.Cesfam.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<Negocio.motivoeliminacion> ListarMotivos()
        {
            try
            {
                List<Datos2.MOTIVO_ELIMINACION> motivos = (from x in acceso.Cesfam.MOTIVO_ELIMINACION select x).ToList();
                List<Negocio.motivoeliminacion> lista = new List<Negocio.motivoeliminacion>();

                foreach (var item in motivos)
                {
                    Negocio.motivoeliminacion me = new Negocio.motivoeliminacion();
                    me.id = Convert.ToInt32(item.ID);
                    me.nombre = item.NOMBRE;
                    lista.Add(me);
                }
                return lista;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool EliminarMotivo(int id)
        {
            try
            {
                Datos2.MOTIVO_ELIMINACION me = BuscarMotivoeliminacion(id);
                acceso.Cesfam.MOTIVO_ELIMINACION.Remove(me);
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
