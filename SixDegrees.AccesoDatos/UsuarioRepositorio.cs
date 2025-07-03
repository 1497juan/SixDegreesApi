using System.Data;
using SixDegrees.Entidades;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace SixDegrees.AccesoDatos;

public class UsuarioRepositorio : IUsuarioRepositorio
{
    private readonly IConfiguration _configuration;
    private readonly string _connectionString;

    public UsuarioRepositorio(IConfiguration configuration)
    {
        _configuration = configuration;
        _connectionString = _configuration.GetConnectionString("DefaultConnection")!;
    }

    private IDbConnection Conexion => new SqlConnection(_connectionString);

    public IEnumerable<Usuario> ObtenerTodos()
    {
        using var db = Conexion;
        return db.Query<Usuario>("SELECT * FROM Usuario");
    }

    public void Crear(Usuario usuario)
    {
        using var db = Conexion;
        var sql = "INSERT INTO Usuario (UsuID, Nombre, Apellido) VALUES (@UsuID, @Nombre, @Apellido)";
        db.Execute(sql, usuario);
    }

    public void Actualizar(Usuario usuario)
    {
        using var db = Conexion;
        var sql = "UPDATE Usuario SET Nombre = @Nombre, Apellido = @Apellido WHERE UsuID = @UsuID";
        db.Execute(sql, usuario);
    }

    public void Eliminar(int id)
    {
        using var db = Conexion;
        var sql = "DELETE FROM Usuario WHERE UsuID = @Id";
        db.Execute(sql, new { Id = id });
    }
}