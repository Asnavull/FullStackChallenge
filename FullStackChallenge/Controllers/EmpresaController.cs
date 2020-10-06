using FullStackChallenge.Business;
using FullStackChallenge.Data.ValueObjects;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Tapioca.HATEOAS;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FullStackChallenge.Controllers
{
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class EmpresaController : ControllerBase
    {
        private readonly IEmpresaBusiness _empresaBusiness;

        public EmpresaController(IEmpresaBusiness business)
        {
            _empresaBusiness = business;
        }

        // GET: api/<EmpresaController>
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<Empresa>))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [TypeFilter(typeof(HyperMediaFilter))]
        public List<Empresa> Get()
        {
            return _empresaBusiness.FindAll();
        }

        // GET api/<EmpresaController>/5
        [HttpGet("{documento}")]
        [ProducesResponseType(200, Type = typeof(Empresa))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(404)]
        [TypeFilter(typeof(HyperMediaFilter))]
        public ActionResult Get(long documento)
        {
            if (documento == null)
                return BadRequest();
            else
            {
                var retorno = _empresaBusiness.FindByCnpj(documento);

                if (retorno == null)
                    return NotFound();
                else
                    return new ObjectResult(retorno);
            }
        }

        // POST api/<EmpresaController>
        [HttpPost]
        [ProducesResponseType(201, Type = typeof(Fornecedor))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [TypeFilter(typeof(HyperMediaFilter))]
        public ActionResult Post([FromBody] Empresa empresa)
        {
            if (empresa == null)
                return BadRequest();
            else
                return new ObjectResult(_empresaBusiness.Create(empresa));
        }

        // PUT api/<EmpresaController>/5
        [HttpPut]
        [ProducesResponseType(202, Type = typeof(Fornecedor))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [TypeFilter(typeof(HyperMediaFilter))]
        public ActionResult Put([FromBody] Empresa empresa)
        {
            if (empresa == null)
                return BadRequest();
            else
                return new ObjectResult(_empresaBusiness.Update(empresa));
        }

        // DELETE api/<EmpresaController>/5
        [HttpDelete("{documento}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [TypeFilter(typeof(HyperMediaFilter))]
        public ActionResult Delete(long documento)
        {
            if (documento == null)
            {
                return BadRequest();
            }
            else
            {
                var empresa = _empresaBusiness.FindByCnpj(documento);

                if (empresa == null)
                {
                    return NotFound();
                }
                else
                {
                    _empresaBusiness.Delete(empresa);

                    return Ok();
                }
            }
        }
    }
}