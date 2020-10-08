using Business;
using FluentValidation;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Model.Data.Dto;
using Model.Data.ValueObjects;
using Model.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using Tapioca.HATEOAS;

namespace FullStackChallengeBackEnd.Controllers
{
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class EmpresaController : ControllerBase
    {
        private readonly IEmpresaBusiness _empresaBusiness;
        private readonly IValidator<Empresa> _validator;

        public EmpresaController(IEmpresaBusiness business, IValidator<Empresa> validator)
        {
            _empresaBusiness = business;
            _validator = validator;
        }

        // GET: api/<EmpresaController>
        [HttpGet]
        [EnableCors("AllowSpecificOrigin")]
        [ProducesResponseType(200, Type = typeof(List<Empresa>))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [TypeFilter(typeof(HyperMediaFilter))]
        public List<Empresa> Get()
        {
            return _empresaBusiness.FindAll();
        }

        // GET api/<EmpresaController>/5
        [HttpGet("find")]
        [EnableCors("AllowSpecificOrigin")]
        [ProducesResponseType(200, Type = typeof(List<Empresa>))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [TypeFilter(typeof(HyperMediaFilter))]
        public ActionResult Get(long? documento, string nome)
        {
            if (documento == null && string.IsNullOrWhiteSpace(nome))
                return BadRequest();
            else if (documento.HasValue)
            {
                if (!UtilValidation.ValidaCnpj(documento.Value))
                    return BadRequest("Cnpj inválido");

                var retorno = new List<Empresa>() { _empresaBusiness.FindByCnpj(documento.Value) };

                if (!retorno.Any())
                    return NotFound();
                else
                    return new ObjectResult(retorno);
            }
            else
            {
                var retorno = _empresaBusiness.FindByName(nome);

                if (retorno == null)
                    return NotFound();
                else
                    return new ObjectResult(retorno);
            }
        }

        // GET api/<EmpresaController>/5
        [HttpGet("{id}")]
        [EnableCors("AllowSpecificOrigin")]
        [ProducesResponseType(200, Type = typeof(List<Empresa>))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [TypeFilter(typeof(HyperMediaFilter))]
        public ActionResult Get(Guid id)
        {
            var retorno = new List<Empresa>() { _empresaBusiness.FindByID(id) };

            if (!retorno.Any())
                return NotFound();
            else
                return new ObjectResult(retorno);
        }

        // POST api/<EmpresaController>
        [HttpPost]
        [EnableCors("AllowSpecificOrigin")]
        [ProducesResponseType(201, Type = typeof(Fornecedor))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [TypeFilter(typeof(HyperMediaFilter))]
        public ActionResult Post([FromBody] Empresa empresa)
        {
            var validation = _validator.Validate(empresa);

            if (!validation.IsValid)
                return BadRequest(validation.Errors);
            else
                return new ObjectResult(_empresaBusiness.Create(empresa));
        }

        // PUT api/<EmpresaController>/5
        [HttpPut]
        [EnableCors("AllowSpecificOrigin")]
        [ProducesResponseType(202, Type = typeof(Fornecedor))]
        [ProducesResponseType(400)]
        [TypeFilter(typeof(HyperMediaFilter))]
        public ActionResult Put([FromBody] Empresa empresa)
        {
            var validation = _validator.Validate(empresa);

            if (!validation.IsValid)
                return BadRequest(validation.Errors);
            else
                return new ObjectResult(_empresaBusiness.Update(empresa));
        }

        [HttpPatch("add")]
        [EnableCors("AllowSpecificOrigin")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [TypeFilter(typeof(HyperMediaFilter))]
        public ActionResult PatchAdd([FromBody] PatchDto ids)
        {
            return new ObjectResult(_empresaBusiness.AddFornecedor(ids.IdPrimeiro, ids.IdSegundo));
        }

        [HttpPatch("remove")]
        [EnableCors("AllowSpecificOrigin")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [TypeFilter(typeof(HyperMediaFilter))]
        public ActionResult PatchRemove([FromBody] PatchDto ids)
        {
            return new ObjectResult(_empresaBusiness.RemoveFornecedor(ids.IdPrimeiro, ids.IdSegundo));
        }

        // DELETE api/<EmpresaController>/5
        [HttpDelete("{id}")]
        [EnableCors("AllowSpecificOrigin")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [TypeFilter(typeof(HyperMediaFilter))]
        public ActionResult Delete(Guid id)
        {
            _empresaBusiness.Delete(id);

            return Ok();
        }
    }
}