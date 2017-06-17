using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class tipousuarios
    {
        public int id { get; set; }
        public String nombre { get; set; }


        public bool CrearTipousuario(String nombre)
        {
            try
            {
                Datos2.TIPOS_USUARIOS t = new Datos2.TIPOS_USUARIOS();
                t.ID = GenerarId();
                t.NOMBRE = nombre;
                acceso.Cesfam.TIPOS_USUARIOS.Add(t);
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

                while (ok == false)
                {
                    id = rnd.Next(1000);
                    Datos2.TIPOS_USUARIOS t = acceso.Cesfam.TIPOS_USUARIOS.FirstOrDefault(d => d.ID == id);

                    if (t == null)
                    {
                        return id;
                    }
                }
                return id;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public Datos2.TIPOS_USUARIOS BuscarTipousuario(int id)
        {
            try
            {
                return acceso.Cesfam.TIPOS_USUARIOS.FirstOrDefault(t => t.ID == id);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool ModificarTipousuario(int id, String nombre)
        {
            try
            {
                Datos2.TIPOS_USUARIOS t = BuscarTipousuario(id);
                t.NOMBRE = nombre;
                acceso.Cesfam.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<Negocio.tipousuarios> ListarTiposusuario()
        {
            try
            {
                List<Datos2.TIPOS_USUARIOS> tipos = (from x in acceso.Cesfam.TIPOS_USUARIOS select x).ToList();
                List<Negocio.tipousuarios> lista = new List<Negocio.tipousuarios>();

                foreach (var item in tipos)
                {
                    tipousuarios t = new Negocio.tipousuarios();
                    t.id = Convert.ToInt32(item.ID);
                    t.nombre = item.NOMBRE;
                    lista.Add(t);
                }
                return lista;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool EliminarTipousuario(int id)
        {
            try
            {
                Datos2.TIPOS_USUARIOS t = BuscarTipousuario(id);
                acceso.Cesfam.TIPOS_USUARIOS.Remove(t);
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
