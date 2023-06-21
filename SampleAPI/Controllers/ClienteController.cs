using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SampleAPI.DTO;
using SampleAPI.Model;
using SampleAPI.Repository;

namespace SampleAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class ClienteController : ControllerBase
{
    private  readonly AppDbContext _repository;
    private  readonly IMapper _mapper;

    public ClienteController(AppDbContext appDbContext,
    IMapper mapper)
    {
        _repository = appDbContext;
        _mapper = mapper;
    }

    [HttpPatch]
    [Route("/cliente/{id}")]
    public IActionResult Patch([FromBody]Cliente model, [FromRoute]int id)
    {
        try
        {
            var client = _repository.Clientes.Find(id);
            if (client == null) {
                return NotFound();
            }

            _repository.Entry(client).CurrentValues.SetValues(model);
            var result = _repository.SaveChanges();
            if (result > 0) {
                return Ok();
            }

            return BadRequest();
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpPut]
    [Route("/cliente")]
    public IActionResult Put([FromBody]Cliente model)
    {
        try
        {
            _repository.Add(model);
            var result = _repository.SaveChanges();
            if (result > 0) {
                return Ok();
            }
            
            return BadRequest();
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpPost]
    [Route("/cliente")]
    public IActionResult Post([FromBody]ClienteDTO clienteDTO)
    {
        try
        {

           var model = _mapper.Map<Cliente>(clienteDTO);

            _repository.Clientes.Add(model);
            var result = _repository.SaveChanges();
            if (result > 0) {
                return Ok();
            }
            
            return BadRequest();
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpDelete]
    [Route("/cliente/{id}")]
    public IActionResult Delete(int id)
    {
        try
        {
            var client = _repository.Clientes.Find(id);
            if (client == null) {
                return NotFound();
            }
            
            _repository.Clientes.Remove(client);
            var resultado = _repository.SaveChanges();

            if (resultado > 0) {
                return Ok();
            }

            return Ok(resultado);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }


    [HttpGet()]
    [Route("/cliente/{id}")]
    public ActionResult<Cliente> Get(int id)
    {
        try
        {
            var client = _repository.Clientes.Find(id);
            if (client == null) {
                return NotFound();
            }

            return Ok(client);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpGet()]
    [Route("/cliente")]
    public ActionResult<List<Cliente>> GetAll()
    {

        try
        {
            var clientes = _repository.Clientes.ToList();
            if (clientes == null || clientes.Count == 0) {
                return NotFound();
            }

            return Ok(clientes);
        }
        catch (Exception ex)
        {            
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }

    }

    [HttpGet()]
    [Route("/cliente/status")]
    public ActionResult<List<Cliente>> GetWithQuerie([FromQuery]StatusDto status)
    {

        try
        {
            var clientes = _repository.Clientes.Where(x => x.Status.Equals(status)).ToList();
            if (clientes == null || clientes.Count == 0) {
                return NotFound();
            }

            return Ok(clientes);
        }
        catch (Exception ex)
        {            
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }
}
