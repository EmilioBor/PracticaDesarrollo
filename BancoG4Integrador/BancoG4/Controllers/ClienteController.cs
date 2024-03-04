using Data.Models;
using DTOs.request;
using DTOs.response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Services;
using Services.Interface;

namespace BancoG4.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _cliente;
        public ClienteController(IClienteService context)
        {
            _cliente = context;
        }

        [HttpGet]
        public async Task<IEnumerable<ClienteDTOOut>> GetAll()
        {
            return await _cliente.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ClienteDTOOut>> GetId(int id)
        {
            var cliente = await _cliente.GetById(id);
            if (cliente == null)
            {
                return NotFound(id); //Se le puede agregar mensaje
            }
            return Ok(cliente);
        }




        [HttpPost(Name = "PostCliente")]
        public async Task<IActionResult> Create(ClienteDTOIn cliente)
        {
            var nuevoCliente = await _cliente.Create(cliente);
            return CreatedAtAction(nameof(GetId), new { id = nuevoCliente.Id }, nuevoCliente);
            //CreatedAtAction: devuelve el objeto que acabamos de crear
            //enviamos la accion dentro de mi controlador, que va a manejar ese proceso
            //GetById 
            //el id va a ser el que acabamos de crear
            //y la informacion va a ser de tipo cliente
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, ClienteDTOIn cliente)
        {
            if (id != cliente.Id) //si el id que se envia es diferente al del objeto 
            {
                return BadRequest(new { message = $"El ID ({id}) de la URL no coinci con el ID ({cliente.Id}) del cuerpo de la solicitud" });
            }
            var clienteAct = await _cliente.GetById(id);
            if (clienteAct is not null)
            {
                await _cliente.Update(id, cliente);
                return NoContent();
            }
            else
            {
                return NotFound(id);
            }

            ////ver si el cliente existe en la base de dato
            //var clienteId = _cliente.Clientes.Find(id);
            //if(clienteId == null) 
            //{ 
            //    return NotFound(nameof(cliente));
            //}

            ////Datos que vamos a modificar
            //clienteId.RazonSocial=cliente.RazonSocial;
            //clienteId.Cuil = cliente.Cuil;
            //clienteId.Direccion = cliente.Direccion;
            ////guardamos en la base de datos
            //_cliente.SaveChanges();
            //return NoContent(); //estatus 204
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var clienteEli = await _cliente.GetById(id);

            if (clienteEli is not null)
            {
                await _cliente.Delete(id);
                return Ok();
            }
            else
            {
                return NotFound(id);
            }

            //    //ver si el cliente existe en la base de dato
            //    //var clienteId = _cliente.Clientes.Find(id);
            //    //if (clienteId == null)
            //    //{
            //    //    return NotFound();
            //    //}
            //    //_cliente.Clientes.Remove(clienteId);
            //    //_cliente.SaveChanges();
            //    //return Ok();
        }

       
    }
}
