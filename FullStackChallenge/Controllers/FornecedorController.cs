using Business;
using Microsoft.AspNetCore.Mvc;
using Model.Data.ValueObjects;
using System.Collections.Generic;
using System.Linq;
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
        [TypeFilter(typeof(HyperMediaFilter))]
        public List<Fornecedor> Get()
        {
            return _fornecedorBusiness.FindAll();
        }

        // GET api/<FornecedorController>/5
        [HttpGet("find")]
        [ProducesResponseType(200, Type = typeof(Fornecedor))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [TypeFilter(typeof(HyperMediaFilter))]
        public ActionResult Get(long? documento, string email, string nome)
        {
            if (documento == null && string.IsNullOrWhiteSpace(email) && string.IsNullOrWhiteSpace(nome))
                return BadRequest();
            else if (documento.HasValue)
            {
                var retorno = new List<Fornecedor>() { _fornecedorBusiness.FindByCpfCnpj(documento.Value) };

                if (!retorno.Any())
                    return NotFound();
                else
                    return Ok(retorno);
            }
            else if (!string.IsNullOrWhiteSpace(email))
            {
                var retorno = new List<Fornecedor>() { _fornecedorBusiness.FindByEmail(email) };

                if (!retorno.Any())
                    return NotFound();
                else
                    return Ok(retorno);
            }
            else
            {
                var retorno = _fornecedorBusiness.FindByName(nome);

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
        [TypeFilter(typeof(HyperMediaFilter))]
        public ActionResult Delete(long documento)
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