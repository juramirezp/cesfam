using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace deploy
{
    class Program
    {
        static void Main(string[] args)
        {
            Negocio.usuarios u = new Negocio.usuarios();
            Console.WriteLine(u.DeployUser("17563572-6"));
            Console.ReadKey();
        }
    }
}
