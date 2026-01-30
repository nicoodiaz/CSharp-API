namespace PracticaTP1;

public interface IAccesoADatos
{
    public Cadeteria CrearCadeteria(string rutaArchivoCadeteria);
    public void CargarCadetes(string rutaArchivoCadetes, List<Cadete> listadoCadetes);

}