using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class formulario
    {
        public int id { get; set; }
        public int usu_id { get; set; }
        public int pac_id { get; set; }
        public DateTime fecha { get; set; }


        public bool CrearFormulario(int usu_id, int pac_id)
        {
            try
            {
                Datos2.FORMULARIO f = new Datos2.FORMULARIO();
                f.ID = GenerarId();
                f.USU_ID = usu_id;
                f.PAC_ID = pac_id;
                f.FECHA = DateTime.Today;
                acceso.Cesfam.FORMULARIO.Add(f);
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
                    Datos2.FORMULARIO v = acceso.Cesfam.FORMULARIO.FirstOrDefault(a => a.ID == id);

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

        public Datos2.FORMULARIO BuscarFormulario(int id)
        {
            try
            {
                return acceso.Cesfam.FORMULARIO.FirstOrDefault(f => f.ID == id);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool ModificarFormulario(int id, int usu_id, int pac_id)
        {
            try
            {
                Datos2.FORMULARIO f = BuscarFormulario(id);
                f.USU_ID = usu_id;
                f.PAC_ID = pac_id;
                acceso.Cesfam.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<Negocio.formulario> ListarFormularios()
        {
            try
            {
                List<Datos2.FORMULARIO> formularios = (from x in acceso.Cesfam.FORMULARIO select x).ToList();
                List<Negocio.formulario> lista = new List<Negocio.formulario>();

                foreach (var item in formularios)
                {
                    Negocio.formulario f = new Negocio.formulario();
                    f.id = Convert.ToInt32(item.ID);
                    f.usu_id = Convert.ToInt32(item.USU_ID);
                    f.pac_id = Convert.ToInt32(item.PACIENTES);
                    f.fecha = Convert.ToDateTime(item.FECHA);
                    lista.Add(f);
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
