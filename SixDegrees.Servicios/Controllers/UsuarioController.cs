using Microsoft.AspNetCore.Mvc;
using SixDegrees.Entidades;
using SixDegrees.Negocio;

namespace SixDegrees.Servicios.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsuarioController : Controller
{
    private readonly IUsuarioServicio _servicio;

    public UsuarioController(IUsuarioServicio servicio)
    {
        _servicio = servicio;
    }

    [HttpGet("ObtenerUsuarios")]
    public IActionResult ObtenerTodos()
    {
        try
        {
            var usuarios = _servicio.ObtenerTodos();
            return Ok(usuarios);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new { mensaje = ex.Message });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { mensaje = $"Error interno del servidor, error: {ex.Message}" });
        }
    }

    [HttpGet("ObtenerUsuariosXId/{id}")]
    public IActionResult ObtenerPorId(int id)
    {
        try
        {
            var usuario = _servicio.ObtenerPorId(id);
            return usuario != null ? Ok(usuario) : NotFound($"El usuario con Id {id} no se encontro.");
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new { mensaje = ex.Message });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { mensaje = $"Error interno del servidor, error: {ex.Message}" });
        }
    }

    [HttpPost("CrearUsuario")]
    public IActionResult Crear([FromBody] Usuario usuario)
    {
        try
        {
            _servicio.Crear(usuario);
            return CreatedAtAction(nameof(ObtenerPorId), new { id = usuario.UsuID }, usuario);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new { mensaje = ex.Message });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { mensaje = $"Error interno del servidor, error: {ex.Message}" });
        }
    }

    [HttpPut("ActualizarUsuario")]
    public IActionResult Actualizar([FromBody] Usuario usuario)
    {
        try
        {
            _servicio.Actualizar(usuario);
            return Ok(new { mensaje = "Usuario actualizado correctamente." });
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new { mensaje = ex.Message });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { mensaje = "Error interno del servidor", detalle = ex.Message });
        }
    }

    [HttpDelete("EliminarUsuario/{id}")]
    public IActionResult Eliminar(int id)
    {
        try
        {
            _servicio.Eliminar(id);
            return Ok(new { mensaje = "Usuario eliminado correctamente." });
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new { mensaje = ex.Message });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { mensaje = $"Error interno del servidor, error: {ex.Message}" });
        }
    }
}