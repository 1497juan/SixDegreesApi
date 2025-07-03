using SixDegrees.Entidades;

namespace SixDegrees.Negocio;

public interface IUsuarioServicio
{
    IEnumerable<Usuario> ObtenerTodos();
    Usuario? ObtenerPorId(int id);
    void Crear(Usuario usuario);
    void Actualizar(Usuario usuario);
    void Eliminar(int id);

}