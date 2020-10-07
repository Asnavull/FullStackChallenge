using Model.Entities.Base;
using System;
using System.Collections.Generic;

namespace Model.Entities
{
    public class TbFornecedor : BaseEntity
    {
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public long CpfCnpj { get; set; } = 0;
        public long? Rg { get; set; } = null;
        public DateTime? DataNascimento { get; set; } = null;
        public List<TbEmpresa> Empresas { get; set; } = new List<TbEmpresa>();
    }
}