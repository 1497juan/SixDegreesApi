using SixDegrees.Entidades;

namespace SixDegrees.AccesoDatos;

public interface IUsuarioRepositorio
{
    IEnumerable<Usuario> ObtenerTodos();
    void Crear(Usuario usuario);
    void Actualizar(Usuario usuario);
    void Eliminar(int id);
}