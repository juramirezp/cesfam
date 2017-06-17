using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class laboratorios
    {
        public int id { get; set; }
        public String nombre { get; set; }


        public bool CrearLaboratorio(String nombre)
        {
            try
            {
                Datos2.LABORATORIOS l = new Datos2.LABORATORIOS();
                l.ID = GenerarId();
                l.NOMBRE = nombre;
                acceso.Cesfam.LABORATORIOS.Add(l);
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
                    Datos2.LABORATORIOS v = acceso.Cesfam.LABORATORIOS.FirstOrDefault(a => a.ID == id);

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

        public Datos2.LABORATORIOS BuscarLaboratorio(int id)
        {
            try
            {
                return acceso.Cesfam.LABORATORIOS.FirstOrDefault(f => f.ID == id);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool ModificarLaboratorio(int id, String nombre)
        {
            try
            {
                Datos2.LABORATORIOS l = BuscarLaboratorio(id);
                l.NOMBRE = nombre;
                acceso.Cesfam.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<Negocio.laboratorios> ListarLaboratorios()
        {
            try
            {
                List<Datos2.LABORATORIOS> laboratorios = (from x in acceso.Cesfam.LABORATORIOS select x).ToList();
                List<Negocio.laboratorios> lista = new List<Negocio.laboratorios>();

                foreach (var item in laboratorios)
                {
                    Negocio.laboratorios l = new Negocio.laboratorios();
                    l.id = Convert.ToInt32(item.ID);
                    l.nombre = item.NOMBRE;
                    lista.Add(l);
                }
                return lista;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public Negocio.laboratorios ObtenerLaboratorio(int id)
        {
            try
            {
                Datos2.LABORATORIOS d = BuscarLaboratorio(id);
                Negocio.laboratorios l = new Negocio.laboratorios();

                l.id = Convert.ToInt32(d.ID);
                l.nombre = l.nombre;

                return l;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
