using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class entregas
    {
        public int id { get; set; }
        public int usu_id { get; set; }
        public int pac_id { get; set; }
        public int id_producto { get; set; }
        public DateTime fecha { get; set; }


        public bool CrearEntrega(int usu_id, int pac_id, int id_producto)
        {
            try
            {
                Datos2.ENTREGAS e = new Datos2.ENTREGAS();
                e.ID = GenerarId();
                e.USU_ID = usu_id;
                e.PAC_ID = pac_id;
                e.ID_PRODUCTO = id_producto;
                e.FECHA = DateTime.Today;
                acceso.Cesfam.ENTREGAS.Add(e);
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
                    Datos2.ENTREGAS v = acceso.Cesfam.ENTREGAS.FirstOrDefault(a => a.ID == id);

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

        public Datos2.ENTREGAS BuscarEntrega(int id)
        {
            try
            {
                return acceso.Cesfam.ENTREGAS.FirstOrDefault(e => e.ID == id);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool ModificarEntrega(int id, int usu_id, int pac_id, int id_producto)
        {
            try
            {
                Datos2.ENTREGAS e = BuscarEntrega(id);
                e.USU_ID = usu_id;
                e.PAC_ID = pac_id;
                e.ID_PRODUCTO = id_producto;
                acceso.Cesfam.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<Negocio.entregas> ListarEntregas()
        {
            try
            {
                List<Datos2.ENTREGAS> entregas = (from x in acceso.Cesfam.ENTREGAS select x).ToList();
                List<Negocio.entregas> lista = new List<Negocio.entregas>();

                foreach (var item in entregas)
                {
                    entregas e = new Negocio.entregas();
                    e.id = Convert.ToInt32(item.ID);
                    e.usu_id = Convert.ToInt32(item.USU_ID);
                    e.pac_id = Convert.ToInt32(item.PAC_ID);
                    e.id_producto = Convert.ToInt32(item.ID_PRODUCTO);
                    e.fecha = Convert.ToDateTime(item.FECHA);
                    lista.Add(e);
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
