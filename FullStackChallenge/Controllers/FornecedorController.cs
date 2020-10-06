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
    public class FornecedorController : ControllerBase
    {
        private readonly IFornecedorBusiness _fornecedorBusiness;

        public FornecedorController(IFornecedorBusiness fornecedorBusiness)
        {
            _fornecedorBusiness = fornecedorBusiness;
        }

        // GET: api/<FornecedorController>
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<Fornecedor>))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [TypeFilter(typeof(HyperMediaFilter))]
        public List<Fornecedor> Get()
        {
            return _fornecedorBusiness.FindAll();
        }

        // GET api/<FornecedorController>/5
        [HttpGet("{documento}")]
        [ProducesResponseType(200, Type = typeof(Fornecedor))]
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
                var retorno = _fornecedorBusiness.FindByCpfCnpj(documento);

                if (retorno == null)
                    return NotFound();
                else
                    return Ok(retorno);
            }
        }

        // POST api/<FornecedorController>
        [HttpPost]
        [ProducesResponseType(201, Type = typeof(Fornecedor))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [TypeFilter(typeof(HyperMediaFilter))]
        public ActionResult Post([FromBody] Fornecedor fornecedor)
        {
            if (fornecedor == null)
                return BadRequest();
            else
                return new ObjectResult(_fornecedorBusiness.Create(fornecedor));
        }

        // PUT api/<FornecedorController>/5
        [HttpPut]
        [ProducesResponseType(202, Type = typeof(Fornecedor))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [TypeFilter(typeof(HyperMediaFilter))]
        public ActionResult Put([FromBody] Fornecedor fornecedor)
        {
            if (fornecedor == null)
                return BadRequest();
            else
                return new ObjectResult(_fornecedorBusiness.Update(fornecedor));
        }

        // DELETE api/<FornecedorController>/5
        [HttpDelete("{documento}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [TypeFilter(typeof(HyperMediaFilter))]
        public ActionResult Delete(long documento)
        {
            if (documento == null)
                return BadRequest();
            else
            {
                var fornecedor = _fornecedorBusiness.FindByCpfCnpj(documento);

                if (fornecedor == null)
                    return NotFound();
                else
                {
                    _fornecedorBusiness.Delete(fornecedor);

                    return Ok();
                }
            }
        }
    }
}