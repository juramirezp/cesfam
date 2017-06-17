using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class formatos
    {
        public int id { get; set; }
        public String nombre { get; set; }

        public bool CrearFormato(String nombre)
        {
            try
            {
                Datos2.FORMATOS f = new Datos2.FORMATOS();
                f.ID = GenerarId();
                f.NOMBRE = nombre;
                acceso.Cesfam.FORMATOS.Add(f);
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
                    Datos2.FORMATOS v = acceso.Cesfam.FORMATOS.FirstOrDefault(a => a.ID == id);

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

        public Datos2.FORMATOS BuscarFormato(int id)
        {
            try
            {
                return acceso.Cesfam.FORMATOS.FirstOrDefault(f => f.ID == id);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool ModificarFormato(int id, String Nombre)
        {
            try
            {
                Datos2.FORMATOS f = BuscarFormato(id);
                f.NOMBRE = nombre;
                acceso.Cesfam.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<Negocio.formatos> ListarFormatos()
        {
            try
            {
                List<Datos2.FORMATOS> formatos = (from x in acceso.Cesfam.FORMATOS select x).ToList();
                List<Negocio.formatos> lista = new List<Negocio.formatos>();

                foreach (var item in formatos)
                {
                    Negocio.formatos f = new Negocio.formatos();
                    f.id = Convert.ToInt32(item.ID);
                    f.nombre = item.NOMBRE;
                    lista.Add(f);
                }
                return lista;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public Negocio.formatos ObtenerFormato(int id)
        {
            try
            {
                Datos2.FORMATOS d = BuscarFormato(id);

                Negocio.formatos f = new Negocio.formatos();

                f.id = Convert.ToInt32(d.ID);
                f.nombre = d.NOMBRE;

                return f;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
