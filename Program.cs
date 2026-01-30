using System.Net.WebSockets;
using PracticaTP1;

string rutaArchivoCadeteria = "Datos/cadeteria.csv";
string rutaArchivoCadetes = "Datos/cadetes.csv";

int opcionMenu;
bool usandoPrograma = true;

var AyudaArchivos = new AccesoADatosCSV();

var cadeteria = AyudaArchivos.CrearCadeteria(rutaArchivoCadeteria);

AyudaArchivos.CargarCadetes(rutaArchivoCadetes, cadeteria.listaCadetes);

while (usandoPrograma)
{
    System.Console.WriteLine("**** Gestion de pedidos ****");
    System.Console.WriteLine("1. Dar de alta un pedido");
    System.Console.WriteLine("2. Asignar un pedido a un cadete");
    System.Console.WriteLine("3. Cambiar estado del pedido");
    System.Console.WriteLine("4. Reasignar un pedido");
    System.Console.WriteLine("5. Finalizar gestion");

    do
    {
        System.Console.WriteLine("Ingrese la opcion del menu");
        opcionMenu = int.Parse(Console.ReadLine());
    } while (opcionMenu >= 5 && opcionMenu <= 1);

    switch (opcionMenu)
    {
        case 1:
            int nroPedido;
            string observacionPedido, nombreCliente, direccionCliente, datosReferencia, telefonoCliente;
            System.Console.WriteLine("-Nro Pedido:");
            nroPedido = int.Parse(Console.ReadLine());
            System.Console.WriteLine("Observacion del pedido");
            observacionPedido = System.Console.ReadLine();
            System.Console.WriteLine("Nombre cliente");
            nombreCliente = System.Console.ReadLine();
            System.Console.WriteLine("Direccion cliente");
            direccionCliente = System.Console.ReadLine();
            System.Console.WriteLine("Datos referencia");
            datosReferencia = System.Console.ReadLine();
            System.Console.WriteLine("Telefono cliente");
            telefonoCliente = System.Console.ReadLine();

            var cliente = new Cliente(nombreCliente, direccionCliente, telefonoCliente, datosReferencia);

            cadeteria.DarAltaPedido(nroPedido, observacionPedido, cliente);
            System.Console.WriteLine("Pedido Ingresado");
            break;
        case 2:
            int idCadete;
            System.Console.WriteLine("Ingrese el ID del cadete");
            idCadete = int.Parse(Console.ReadLine());
            System.Console.WriteLine("Ingrese el nro Pedido a asingar");
            nroPedido = int.Parse(Console.ReadLine());
            var pedido = cadeteria.BuscarUnPedidoPorId(nroPedido);
            cadeteria.AsignarPedido(idCadete, pedido);
            System.Console.WriteLine("Pedido asignado");
            break;
        case 3:
            int nroEstado;
            System.Console.WriteLine("Ingrese nro Pedido");
            nroPedido = int.Parse(Console.ReadLine());

            Console.WriteLine("Seleccione el nuevo estado:\n1-Asignado\n2-En Camino\n3-Entregado\n4-Cancelado");
            nroEstado = int.Parse(Console.ReadLine());
            Estado nuevoEstado = (Estado)nroEstado;
            cadeteria.CambiarEstadoPedido(nroPedido, nuevoEstado);
            break;
        case 4:
            System.Console.WriteLine("Ingrese nro Pedido");
            nroPedido = int.Parse(Console.ReadLine());
            System.Console.WriteLine("Ingrese nro cadete para reasigar");
            idCadete = int.Parse(Console.ReadLine());
            cadeteria.ReasignarPedido(nroPedido, idCadete);
            break;
        case 5:
            usandoPrograma = false;
            break;
    }
}
