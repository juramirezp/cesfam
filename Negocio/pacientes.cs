using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class pacientes
    {
        public int id { get; set; }
        public String rut { get; set; }
        public String nombre { get; set; }
        public String direccion { get; set; }
        public String comuna { get; set; }
        public DateTime nacimiento { get; set; }
        public int telefono { get; set; }
        public String email { get; set; }

        public Negocio.pacientes ObtenerPaciente(String rut)
        {
            try
            {
                Datos2.PACIENTES p = acceso.Cesfam.PACIENTES.FirstOrDefault(d => d.RUT == rut);
                Negocio.pacientes pac = new Negocio.pacientes();

                pac.id = Convert.ToInt32(p.ID);
                pac.rut = p.RUT;
                pac.nombre = p.NOMBRE;
                pac.direccion = p.DIRECCION;
                pac.comuna = p.COMUNA;
                pac.nacimiento = Convert.ToDateTime(p.NACIMIENTO);
                pac.telefono = Convert.ToInt32(p.TELEFONO);
                pac.email = p.EMAIL;

                return pac;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool CrearPaciente(String rut, String nombre, String direccion, String comuna, DateTime nacimiento, int telefono, String email)
        {
            try
            {
                Datos2.PACIENTES p = new Datos2.PACIENTES();
                p.ID = GenerarId();
                p.RUT = rut;
                p.NOMBRE = nombre;
                p.DIRECCION = direccion;
                p.COMUNA = comuna;
                p.NACIMIENTO = nacimiento;
                p.TELEFONO = telefono;
                p.EMAIL = email;
                acceso.Cesfam.PACIENTES.Add(p);
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
                    Datos2.PACIENTES v = acceso.Cesfam.PACIENTES.FirstOrDefault(a => a.ID == id);

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

        public Datos2.PACIENTES BuscarPaciente(int id)
        {
            try
            {
                return acceso.Cesfam.PACIENTES.FirstOrDefault(p => p.ID == id);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool ModificarPaciente(int id, String rut, String nombre, String direccion, String comuna, DateTime nacimiento, int telefono, String email)
        {
            try
            {
                Datos2.PACIENTES p = BuscarPaciente(id);
                p.RUT = rut;
                p.NOMBRE = nombre;
                p.DIRECCION = direccion;
                p.COMUNA = comuna;
                p.NACIMIENTO = nacimiento;
                p.TELEFONO = telefono;
                p.EMAIL = email;
                acceso.Cesfam.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<Negocio.pacientes> ListarPacientes()
        {
            try
            {
                List<Datos2.PACIENTES> pacientes = (from x in acceso.Cesfam.PACIENTES select x).ToList();
                List<Negocio.pacientes> lista = new List<Negocio.pacientes>();

                foreach (var item in pacientes)
                {
                    Negocio.pacientes p = new Negocio.pacientes();
                    p.id = Convert.ToInt32(item.ID);
                    p.rut = item.RUT;
                    p.nombre = item.NOMBRE;
                    p.direccion = item.DIRECCION;
                    p.comuna = item.COMUNA;
                    p.nacimiento = Convert.ToDateTime(item.NACIMIENTO);
                    p.telefono = Convert.ToInt32(item.TELEFONO);
                    p.email = item.EMAIL;
                    lista.Add(p);
                }
                return lista;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool EliminarPaciente(int id)
        {
            try
            {
                Datos2.PACIENTES p = BuscarPaciente(id);
                acceso.Cesfam.PACIENTES.Remove(p);
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
