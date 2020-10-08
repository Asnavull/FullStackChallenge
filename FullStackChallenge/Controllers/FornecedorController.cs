using Business;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Model.Data.Dto;
using Model.Data.ValueObjects;
using System;
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
        private readonly IValidator<Fornecedor> _validatorFornecedor;

        public FornecedorController(IFornecedorBusiness fornecedorBusiness, IValidator<Fornecedor> validator)
        {
            _fornecedorBusiness = fornecedorBusiness;
            _validatorFornecedor = validator;
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
                    return new ObjectResult(retorno);
            }
            else if (!string.IsNullOrWhiteSpace(email))
            {
                var retorno = new List<Fornecedor>() { _fornecedorBusiness.FindByEmail(email) };

                if (!retorno.Any())
                    return NotFound();
                else
                    return new ObjectResult(retorno);
            }
            else
            {
                var retorno = _fornecedorBusiness.FindByName(nome);

                if (retorno == null)
                    return NotFound();
                else
                    return new ObjectResult(retorno);
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
            var validation = _validatorFornecedor.Validate(fornecedor);

            if (!validation.IsValid)
                return BadRequest(validation.Errors);
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
            var validation = _validatorFornecedor.Validate(fornecedor);

            if (!validation.IsValid)
                return BadRequest(validation.Errors);
            else
                return new ObjectResult(_fornecedorBusiness.Update(fornecedor));
        }

        [HttpPatch("add")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [TypeFilter(typeof(HyperMediaFilter))]
        public ActionResult PatchAdd([FromBody] PatchDto ids)
        {
            return new ObjectResult(_fornecedorBusiness.AddEmpresa(ids.IdPrimeiro, ids.IdSegundo));
        }

        [HttpPatch("remove")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [TypeFilter(typeof(HyperMediaFilter))]
        public ActionResult PatchRemove([FromBody] PatchDto ids)
        {
            return new ObjectResult(_fornecedorBusiness.RemoveEmpresa(ids.IdPrimeiro, ids.IdSegundo));
        }

        // DELETE api/<FornecedorController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [TypeFilter(typeof(HyperMediaFilter))]
        public ActionResult Delete(Guid id)
        {
            _fornecedorBusiness.Delete(id);

            return Ok();
        }
    }
}