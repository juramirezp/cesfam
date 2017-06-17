using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class pacientestutores
    {
        public int id { get; set; }
        public int tut_id { get; set; }
        public int pac_id { get; set; }
        public String parentesco { get; set; }

        public bool CrearPacientestutores(int tut_id, int pac_id, String parentesco)
        {
            try
            {
                Datos2.PACIENTES_TUTORES pt = new Datos2.PACIENTES_TUTORES();
                pt.ID = GenerarId();
                pt.TUT_ID = tut_id;
                pt.PAC_ID = pac_id;
                pt.PARENTESCO = parentesco;
                acceso.Cesfam.PACIENTES_TUTORES.Add(pt);
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
                    Datos2.PACIENTES_TUTORES v = acceso.Cesfam.PACIENTES_TUTORES.FirstOrDefault(a => a.ID == id);

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

        public Datos2.PACIENTES_TUTORES BuscarPacientestutores(int id)
        {
            try
            {
                return acceso.Cesfam.PACIENTES_TUTORES.FirstOrDefault(pt => pt.ID == id);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool ModificarPacientestutores(int id, int tut_id, int pac_id, String parentesco)
        {
            try
            {
                Datos2.PACIENTES_TUTORES p = BuscarPacientestutores(id);
                p.TUT_ID = tut_id;
                p.PAC_ID = pac_id;
                p.PARENTESCO = parentesco;
                acceso.Cesfam.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<Negocio.pacientestutores> ListarPacientestutores()
        {
            try
            {
                List<Datos2.PACIENTES_TUTORES> pacientestutores = (from x in acceso.Cesfam.PACIENTES_TUTORES select x).ToList();
                List<Negocio.pacientestutores> lista = new List<Negocio.pacientestutores>();

                foreach (var item in pacientestutores)
                {
                    Negocio.pacientestutores p = new Negocio.pacientestutores();
                    p.id = Convert.ToInt32(item.ID);
                    p.pac_id = Convert.ToInt32(item.PAC_ID);
                    p.parentesco = item.PARENTESCO;
                    lista.Add(p);
                }
                return lista;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool EliminarPacientestutores(int id)
        {
            try
            {
                Datos2.PACIENTES_TUTORES p = BuscarPacientestutores(id);
                acceso.Cesfam.PACIENTES_TUTORES.Remove(p);
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
