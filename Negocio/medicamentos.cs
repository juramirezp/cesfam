using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class medicamentos
    {
        public int id { get; set; }
        public int lab_id { get; set; }
        public int for_id { get; set; }
        public String nombre { get; set; }
        public int contenido { get; set; }
        public int gramaje { get; set; }
        public int stock { get; set; }
        public String descripcion { get; set; }
        public String componentes { get; set; }


        public bool CrearMedicamento(int lab_id, int for_id, String nombre, int contenido, int gramaje, int stock, String descripcion, String componentes)
        {
            try
            {
                Datos2.MEDICAMENTOS m = new Datos2.MEDICAMENTOS();
                m.ID = GenerarId();
                m.LAB_ID = lab_id;
                m.FOR_ID = for_id;
                m.NOMBRE = nombre;
                m.CONTENIDO = contenido;
                m.GRAMAJE = gramaje;
                m.STOCK = stock;
                m.DESCRIPCION = descripcion;
                m.COMPONENTES = componentes;
                acceso.Cesfam.MEDICAMENTOS.Add(m);
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
                    Datos2.MEDICAMENTOS v = acceso.Cesfam.MEDICAMENTOS.FirstOrDefault(a => a.ID == id);

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

        public Datos2.MEDICAMENTOS BuscarMedicamento(int id)
        {
            try
            {
                return acceso.Cesfam.MEDICAMENTOS.FirstOrDefault(m => m.ID == id);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool ModificarMedicamento(int id, int lab_id, int for_id, String nombre, int contenido, int gramaje, int stock, String descripcion, String componentes)
        {
            try
            {
                Datos2.MEDICAMENTOS m = BuscarMedicamento(id);
                m.LAB_ID = lab_id;
                m.FOR_ID = for_id;
                m.NOMBRE = nombre;
                m.CONTENIDO = contenido;
                m.GRAMAJE = gramaje;
                m.STOCK = stock;
                m.DESCRIPCION = descripcion;
                m.COMPONENTES = componentes;
                acceso.Cesfam.MEDICAMENTOS.Add(m);
                acceso.Cesfam.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<Negocio.medicamentos> ListarMedicamentos()
        {
            try
            {
                List<Datos2.MEDICAMENTOS> medicamentos = (from x in acceso.Cesfam.MEDICAMENTOS select x).ToList();
                List<Negocio.medicamentos> lista = new List<Negocio.medicamentos>();

                foreach (var item in medicamentos)
                {
                    Negocio.medicamentos m = new Negocio.medicamentos();
                    m.id = Convert.ToInt32(item.ID);
                    m.lab_id = Convert.ToInt32(item.LAB_ID);
                    m.for_id = Convert.ToInt32(item.LAB_ID);
                    m.nombre = item.NOMBRE;
                    m.contenido = Convert.ToInt32(item.CONTENIDO);
                    m.gramaje = Convert.ToInt32(item.GRAMAJE);
                    m.stock = Convert.ToInt32(item.STOCK);
                    m.descripcion = item.DESCRIPCION;
                    m.componentes = item.COMPONENTES;
                    lista.Add(m);
                }
                return lista;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool EliminarMedicamento(int id)
        {
            try
            {
                Datos2.MEDICAMENTOS m = BuscarMedicamento(id);
                acceso.Cesfam.MEDICAMENTOS.Remove(m);
                acceso.Cesfam.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Negocio.medicamentos ObtenerMedicamento(int id)
        {
            try
            {
                Datos2.MEDICAMENTOS m = BuscarMedicamento(id);
                Negocio.medicamentos med = new Negocio.medicamentos();

                med.id = Convert.ToInt32(m.ID);
                med.lab_id = Convert.ToInt32(m.LAB_ID);
                med.for_id = Convert.ToInt32(m.FOR_ID);
                med.nombre = m.NOMBRE;
                med.contenido = Convert.ToInt32(m.CONTENIDO);
                med.gramaje = Convert.ToInt32(m.GRAMAJE);
                med.stock = Convert.ToInt32(m.STOCK);
                med.descripcion = m.DESCRIPCION;
                med.componentes = m.COMPONENTES;

                return med;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
