using SixDegrees.AccesoDatos;
using SixDegrees.Entidades;

namespace SixDegrees.Negocio;

public class UsuarioServicio : IUsuarioServicio
{
    private readonly IUsuarioRepositorio _repositorio;

    public UsuarioServicio(IUsuarioRepositorio repositorio)
    {
        _repositorio = repositorio;
    }

    public IEnumerable<Usuario> ObtenerTodos() => _repositorio.ObtenerTodos();

    public Usuario? ObtenerPorId(int id)
    {
        return _repositorio.ObtenerTodos().FirstOrDefault(x => x.UsuID == id);
    }

    public void Crear(Usuario usuario)
    {
        if (string.IsNullOrWhiteSpace(usuario.Nombre))
            throw new ArgumentException("El nombre no puede ser vacio.");

        if (string.IsNullOrWhiteSpace(usuario.Apellido))
            throw new ArgumentException("El apellido no puede ser vacio.");

        var usuarios = _repositorio.ObtenerTodos();

        var ultimoId = usuarios.Any()
            ? usuarios.Max(u => u.UsuID)
            : 0;

        usuario.UsuID = ultimoId + 1;

        _repositorio.Crear(usuario);
    }

    public void Actualizar(Usuario usuario)
    {
        if (string.IsNullOrWhiteSpace(usuario.Nombre))
            throw new ArgumentException("El nombre no puede ser vacio.");

        if (string.IsNullOrWhiteSpace(usuario.Apellido))
            throw new ArgumentException("El apellido no puede ser vacio.");

        var existente = ObtenerPorId(int.Parse(usuario.UsuID.ToString()));
        if (existente == null)
            throw new InvalidOperationException($"El usuario con id {usuario.UsuID} no existe.");

        _repositorio.Actualizar(usuario);
    }

    public void Eliminar(int id)
    {
        var existente = ObtenerPorId(id);
        if (existente == null)
            throw new InvalidOperationException("El usuario no existe.");

        _repositorio.Eliminar(id);
    }
}