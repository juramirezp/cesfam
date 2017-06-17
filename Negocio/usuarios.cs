using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class usuarios
    {
        //Declaración de los atributos de la clase Usuario
        public int id { get; set; }
        public int tip_id { get; set; }
        public String rut { get; set; }
        public String nombre { get; set; }
        public int telefono { get; set; }
        public String email { get; set; }
        public String pass { get; set; }
        public int estado { get; set; }
        
        public bool CrearUsuario(int tip_id, String rut, String nombre, int telefono, String email, String pass, int estado)
        {
            try
            {
                Datos2.USUARIOS u = new Datos2.USUARIOS();
                u.RUT = rut;
                u.NOMBRE = nombre;
                u.TELEFONO = telefono;
                u.EMAIL = email;
                u.PASS = pass;
                u.ESTADO = estado;
                acceso.Cesfam.USUARIOS.Add(u);
                acceso.Cesfam.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        
        public Datos2.USUARIOS BuscarUsuario(int id)
        {
            try
            {
                return acceso.Cesfam.USUARIOS.FirstOrDefault(u => u.ID == id);
            }
            catch (Exception)
            {
                return null;
            }
        }
        
        public bool ModificarUsuario(int id, int tip_id, String rut, String nombre, int telefono, String email, String pass, int estado)
        {
            try
            {
                //Buscar usuario en Datos2 a traves de metodo ya declarado
                Datos2.USUARIOS u = BuscarUsuario(id);
                //Reemplazo de informacion antigua por nuevos Datos2
                u.RUT = rut;
                u.NOMBRE = nombre;
                u.TELEFONO = telefono;
                u.EMAIL = email;
                u.PASS = pass;
                u.ESTADO = estado;
                //Se guardan Cambios
                acceso.Cesfam.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        //Metodo que devuelve una lista de los usuarios registrados
        public List<Negocio.usuarios> ListarUsuarios()
        {
            try
            {
                //Genera una lista con los usuarios de la Datos2
                List<Datos2.USUARIOS> usuarios = (from x in acceso.Cesfam.USUARIOS select x).ToList();
                //Crea una lista vacia de usuarios del tipo Negocio para posteriormente retornarla
                List<Negocio.usuarios> lista = new List<Negocio.usuarios>();

                //Ciclo que permite copiar de los elementos de la Datos2 a uno manejable por los metodos que llaman a la función
                foreach (var item in usuarios)
                {
                    Negocio.usuarios u = new Negocio.usuarios();
                    u.id = Convert.ToInt32(item.ID);
                    u.nombre = item.NOMBRE;
                    u.rut = item.RUT;
                    u.telefono = Convert.ToInt32(item.TELEFONO);
                    u.email = item.EMAIL;
                    u.pass = item.PASS;
                    u.estado = Convert.ToInt32(item.ESTADO);
                    lista.Add(u);
                }

                return lista;
            }
            catch (Exception)
            {
                return null;
            }
        }

        //MEtodo que elimina un usuario identificado por su id
        public bool EliminarUsuario(int id)
        {
            try
            {
                //Busqueda del usuario a tarves del metodo BuscarUsuario()
                Datos2.USUARIOS u = BuscarUsuario(id);
                //Eliminar el usuario y guardar los cambios en la Datos2
                acceso.Cesfam.USUARIOS.Remove(u);
                acceso.Cesfam.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        //Metodo que valida los Datos2 de ingreso de un usuario
        public bool ValidarUsuario(String rut, String pass)
        {
            try
            {
                //Busca un usuario por su rut
                Datos2.USUARIOS user = acceso.Cesfam.USUARIOS.First(u => u.RUT == rut);
                //Valida que exista el usuario y que la contraseña ingresada coincida
                if (user.PASS == pass && user.ESTADO == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public string DeployUser(String rut)
        {
            try
            {
                //Busca un usuario por su rut
                Datos2.USUARIOS user = acceso.Cesfam.USUARIOS.First(u => u.RUT == rut);
                //Valida que exista el usuario y que la contraseña ingresada coincida
                return user.NOMBRE;
            }
            catch (Exception e)
            {
                return e.ToString();
            }
        }

        //Buscar usuario por su rut
        public Datos2.USUARIOS BuscarUsuarioPorRut(String rut)
        {
            try
            {
                //Si existe retorna el usuario que corresponda
                return acceso.Cesfam.USUARIOS.First(u => u.RUT == rut);
            }
            catch (Exception)
            {
                return null;
            }
        }

        //Deshabilita un usuario identificado por su rut
        public String DeshabilitarUsuario(String rut)
        {
            try
            {
                //Busca un usuario usando el metodo BuscarUsuarioPorRut()
                Datos2.USUARIOS user = BuscarUsuarioPorRut(rut);

                //valida que el usuario exista
                if (user != null)
                {
                    //Valida que el usuario este activo
                    if (user.ESTADO == 1)
                    {
                        //Deshabilita al usuario
                        user.ESTADO = 0;
                        return "El usuario a sido deshabilitado";
                    }
                    else
                    {
                        return "Usuario ya se encuentra deshabilitado";
                    }
                }
                else
                {
                    return "Usuario no existe";
                }
            }
            catch (Exception)
            {
                return "Error al deshabilitar usuario";
            }
        }

        //Listar usuario usando un filtro definido por el usuario
        public List<Negocio.usuarios> FiltrarUsuarios(String opcion, String valor)
        {
            try
            {
                //Lista los usuario usando el metodo ListarUsuarios()
                List<Negocio.usuarios> usuarios = ListarUsuarios();
                //Crea un lista vacia en donde almacenar los usuarios
                List<Negocio.usuarios> lista = new List<Negocio.usuarios>();

                //Itera por la lista de usuarios recuperada
                foreach (var item in usuarios)
                {
                    //Valida el filtro seleccionado por el usuario
                    switch (opcion)
                    {
                        case "rut":
                            if (item.rut == valor)
                            {
                                lista.Add(item);
                            }
                            break;
                        case "nombre":
                            if (item.nombre == valor)
                            {
                                lista.Add(item);
                            }
                            break;
                        case "email":
                            if (item.email == valor)
                            {
                                lista.Add(item);
                            }
                            break;
                        default:
                            break;
                    }
                }

                return lista;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public Negocio.usuarios ObtenerUsuario(String rut)
        {
            try
            {
                Datos2.USUARIOS u = acceso.Cesfam.USUARIOS.FirstOrDefault(p => p.RUT == rut);
                Negocio.usuarios user = new Negocio.usuarios();

                user.id = Convert.ToInt32(u.ID);
                user.tip_id = Convert.ToInt32(u.TIP_ID);
                user.rut = u.RUT;
                user.nombre = u.NOMBRE;
                user.telefono = Convert.ToInt32(u.TELEFONO);
                user.email = u.EMAIL;
                user.pass = u.PASS;
                user.estado = Convert.ToInt32(u.ESTADO);

                return user;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
