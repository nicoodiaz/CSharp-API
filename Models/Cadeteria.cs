namespace PracticaTP1;

public class Cadeteria
{
    public string nombreCadeteria { get; set; }
    public string telefonoCadeteria { get; set; }
    public List<Cadete> listaCadetes { get; set; }
    public List<Pedidos> pedidosNoAsignados { get; set; } = new List<Pedidos>();
    public Cadeteria ()
    {
        
    }
    public Cadeteria(string nombre, string telefono, List<Cadete> listadoCadetes)
    {
        this.nombreCadeteria = nombre;
        this.telefonoCadeteria = telefono;
        this.listaCadetes = listadoCadetes;
    }
    public Cadete BuscarCadetePorID(int idCadete)
    {
        var cadeteBuscado = listaCadetes.SingleOrDefault(cadete => cadete.id == idCadete);
        if (cadeteBuscado == null)
        {
            throw new KeyNotFoundException($"No existe un cadete con el id: {idCadete}");
        }
        return cadeteBuscado;
    }
    public Pedidos BuscarUnPedidoPorId(int nroPedido)
    {
        var p = pedidosNoAsignados.FirstOrDefault(pedido => pedido.nroPedido == nroPedido);
        if (p != null) return p;

        foreach (var cadete in listaCadetes)
        {
            if (cadete.pedidosACadete == null) continue;

            var pedidoBuscado = cadete.pedidosACadete.FirstOrDefault(pedido => pedido.nroPedido == nroPedido);
            if (pedidoBuscado != null) return pedidoBuscado;
        }
        return null;
    }
    public void CambiarEstadoPedido(int nroPedido, Estado nuevoEstado)
    {
        var pedido = BuscarUnPedidoPorId(nroPedido);
        if (pedido != null) pedido.estadoPedido = nuevoEstado;
    }
    public void AgregarCadete(Cadete cadeteAgregar)
    {
        foreach (var cadete in listaCadetes)
        {
            if (listaCadetes.Any(cadete => cadete.id == cadeteAgregar.id)) return;
            listaCadetes.Add(cadeteAgregar);
        }
    }
    public Pedidos DarAltaPedido(int nroPedido, string observacion, Cliente cliente)
    {
        Pedidos nuevoPedido = new Pedidos(nroPedido, observacion, cliente);
        pedidosNoAsignados.Add(nuevoPedido);
        return nuevoPedido;
    }
    public void AsignarPedido(int idCadete, Pedidos nuevoPedido)
    {
        var cadete = BuscarCadetePorID(idCadete);
        if (cadete != null)
        {
            cadete.AgregarPedido(nuevoPedido);
            CambiarEstadoPedido(nuevoPedido.nroPedido, Estado.Asignado);
            pedidosNoAsignados.Remove(nuevoPedido);
        }
    }
    public void ReasignarPedido(int nroPedidoReasignar, int idCadeteNuevo)
    {
        Pedidos pedido = BuscarUnPedidoPorId(nroPedidoReasignar);
        if (pedido != null)
        {
            Cadete nuevoCadete = BuscarCadetePorID(idCadeteNuevo);
            if (nuevoCadete != null)
            {
                nuevoCadete.AgregarPedido(pedido);
            }
        }
    }
}