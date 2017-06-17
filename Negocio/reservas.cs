using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class reservas
    {
        public int id { get; set; }
        public int pac_id { get; set; }
        public int med_id { get; set; }
        public int usu_id { get; set; }
        public int cantidad { get; set; }
        public DateTime fecha { get; set; }
        public String estado { get; set; }


        public bool CrearReserva(int pac_id, int med_id, int usu_id, int cantidad, String estado)
        {
            try
            {
                Datos2.RESERVAS r = new Datos2.RESERVAS();
                r.ID = GenerarId();
                r.PAC_ID = pac_id;
                r.MED_ID = med_id;
                r.USU_ID = usu_id;
                r.CANTIDAD = cantidad;
                r.FECHA = DateTime.Today;
                r.ESTADO = estado;
                acceso.Cesfam.RESERVAS.Add(r);
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
                    Datos2.RESERVAS v = acceso.Cesfam.RESERVAS.FirstOrDefault(a => a.ID == id);

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

        public Datos2.RESERVAS BuscarReserva(int id)
        {
            try
            {
                return acceso.Cesfam.RESERVAS.FirstOrDefault(r => r.ID == id);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool ModificarReserva(int id, int pac_id, int med_id, int usu_id, int cantidad, String estado)
        {
            try
            {
                Datos2.RESERVAS r = BuscarReserva(id);
                r.PAC_ID = pac_id;
                r.MED_ID = med_id;
                r.USU_ID = usu_id;
                r.CANTIDAD = cantidad;
                r.FECHA = DateTime.Today;
                r.ESTADO = estado;
                acceso.Cesfam.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<Negocio.reservas> ListarReservas()
        {
            try
            {
                List<Datos2.RESERVAS> reservas = (from x in acceso.Cesfam.RESERVAS select x).ToList();
                List<Negocio.reservas> lista = new List<Negocio.reservas>();

                foreach (var item in reservas)
                {
                    Negocio.reservas r = new Negocio.reservas();
                    r.id = Convert.ToInt32(item.ID);
                    r.med_id = Convert.ToInt32(item.MED_ID);
                    r.usu_id = Convert.ToInt32(item.USU_ID);
                    r.cantidad = Convert.ToInt32(item.CANTIDAD);
                    r.fecha = Convert.ToDateTime(item.FECHA);
                    r.estado = item.ESTADO;
                    lista.Add(r);
                }
                return lista;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool EliminarReserva(int id)
        {
            try
            {
                Datos2.RESERVAS r = BuscarReserva(id);
                acceso.Cesfam.RESERVAS.Remove(r);
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
