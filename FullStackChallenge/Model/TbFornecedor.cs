using FullStackChallenge.Model.Base;
using System;
using System.Collections.Generic;

namespace FullStackChallenge.Model
{
    public partial class TbFornecedor : BaseEntity
    {
        public TbFornecedor()
        {
            TbEmpresaFornecedor = new HashSet<TbEmpresaFornecedor>();
        }

        public string Nome { get; set; }
        public string Email { get; set; }
        public long CpfCnpj { get; set; }
        public long? Rg { get; set; }
        public DateTime? DataNascimento { get; set; }

        public virtual ICollection<TbEmpresaFornecedor> TbEmpresaFornecedor { get; set; }
    }
}