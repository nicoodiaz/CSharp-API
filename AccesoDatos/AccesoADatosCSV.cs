using System.Xml.Schema;

namespace PracticaTP1;

public class AccesoADatosCSV : IAccesoADatos
{
    public Cadeteria CrearCadeteria(string rutaArchivoCadeteria)
    {
        var cadeteria = new Cadeteria();
        if (File.Exists(rutaArchivoCadeteria))
        {
            string[] linea = File.ReadAllLines(rutaArchivoCadeteria);
            string primeraLinea = linea[0];
            string[] datosCadeteria = primeraLinea.Split(',');
            string nombre = datosCadeteria[0];
            string telefono = datosCadeteria[1];
            
            cadeteria.nombreCadeteria = nombre;
            cadeteria.telefonoCadeteria = telefono;
            cadeteria.listaCadetes = new List<Cadete>();
            cadeteria.listadoPedidos = new List<Pedidos>();
        }
        return cadeteria;
    }
    
    public void CargarCadetes(string rutaArchivoCadetes, List<Cadete> listadoCadetes)
    {
        if (File.Exists(rutaArchivoCadetes))
        {
            using (var infoCadetes = new StreamReader(rutaArchivoCadetes))
            {
                while (!infoCadetes.EndOfStream)
                {
                    string lineaa = infoCadetes.ReadLine();
                    string[] datosCadete = lineaa.Split(';');

                    int id = int.Parse(datosCadete[0]);
                    string nombre = datosCadete[1];
                    string direccion = datosCadete[2];
                    string telefono = datosCadete[3];

                    listadoCadetes.Add(new Cadete(id, nombre, direccion, telefono));
                }
            }
        }
    }
}