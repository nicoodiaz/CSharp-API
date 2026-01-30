
using System.Diagnostics.Contracts;
using System.Text.Json;

namespace PracticaTP1;

public class AccesoADatosJSON : IAccesoADatos
{
    public Cadeteria CrearCadeteria(string rutaArchivoCadeteria)
    {
        var cadeteria = new Cadeteria();
        if(File.Exists(rutaArchivoCadeteria))
        {
            string txtJson = File.ReadAllText(rutaArchivoCadeteria);
            cadeteria = JsonSerializer.Deserialize<Cadeteria>(txtJson);
            cadeteria.listaCadetes = new List<Cadete>();
            cadeteria.listadoPedidos = new List<Pedidos>();
        }
        return cadeteria;
    }
    public void CargarCadetes(string rutaArchivoCadetes, List<Cadete> listadoCadetes)
    {
        var cadetes = new List<Cadete>();
        if(File.Exists(rutaArchivoCadetes))
        {
            string txtJson = File.ReadAllText(rutaArchivoCadetes);
            cadetes = JsonSerializer.Deserialize<List<Cadete>>(txtJson);
        }
    }
}