using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class tutores
    {
        public int id { get; set; }
        public String rut { get; set; }
        public int telefono { get; set; }
        public String email { get; set; }
        public String direccion { get; set; }
        public String comuna { get; set; }


        public bool CrearTutor(String rut, int telefono, String email, String direccion, String comuna)
        {
            try
            {
                Datos2.TUTORES t = new Datos2.TUTORES();
                t.ID = GenerarId();
                t.RUT = rut;
                t.TELEFONO = telefono;
                t.EMAIL = email;
                t.DIRECCION = direccion;
                t.COMUNA = comuna;
                acceso.Cesfam.TUTORES.Add(t);
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
                    Datos2.TUTORES v = acceso.Cesfam.TUTORES.FirstOrDefault(a => a.ID == id);

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

        public Datos2.TUTORES BuscarTutor(int id)
        {
            try
            {
                return acceso.Cesfam.TUTORES.FirstOrDefault(t => t.ID == id);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool ModificarTutor(int id, String rut, int telefono, String email, String direccion, String comuna)
        {
            try
            {
                Datos2.TUTORES t = BuscarTutor(id);
                t.RUT = rut;
                t.TELEFONO = telefono;
                t.EMAIL = email;
                t.DIRECCION = direccion;
                t.COMUNA = comuna;
                acceso.Cesfam.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<Negocio.tutores> ListarTutores()
        {
            try
            {
                List<Datos2.TUTORES> tutores = (from x in acceso.Cesfam.TUTORES select x).ToList();
                List<Negocio.tutores> lista = new List<Negocio.tutores>();

                foreach (var item in tutores)
                {
                    Negocio.tutores t = new Negocio.tutores();
                    t.id = Convert.ToInt32(item.ID);
                    t.rut = item.RUT;
                    t.telefono = Convert.ToInt32(item.TELEFONO);
                    t.email = item.EMAIL;
                    t.direccion = item.DIRECCION;
                    t.comuna = item.COMUNA;
                    lista.Add(t);
                }
                return lista;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool EliminarTutor(int id)
        {
            try
            {
                Datos2.TUTORES t = BuscarTutor(id);
                acceso.Cesfam.TUTORES.Remove(t);
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
