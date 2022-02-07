using Modelos.Quote;
using System;
using System.Collections.Generic;
using System.Text;

namespace Info
{
    public class ClienteInfo
    {

        public static void  mostrarCliente(Cliente cliente)
        {
            Console.WriteLine("-------------- Cliente --------------");
            string msg = String.Format("ID: {0} -- Nombre: {1} -- Correo: {2} -- Telefono: {3} -- Ciudad: {4}",
            cliente.ClienteId,
            cliente.Nombre,
            cliente.Correo,
            cliente.Telefono,
            cliente.Ciudad
            );
            Console.WriteLine(msg);

        }

        public static void mostrarClientes(List<Cliente> clientes)
        {
            foreach(var cliente in clientes)
            {
                mostrarCliente(cliente);
            }
        }
    }
}
