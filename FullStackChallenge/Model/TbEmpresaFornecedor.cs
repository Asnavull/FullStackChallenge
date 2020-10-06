using FullStackChallenge.Model.Base;
using System;

namespace FullStackChallenge.Model
{
    public partial class TbEmpresaFornecedor : BaseEntity
    {
        public Guid IdEmpresa { get; set; }
        public Guid IdFornecedor { get; set; }

        public virtual TbEmpresa IdEmpresaNavigation { get; set; }
        public virtual TbFornecedor IdFornecedorNavigation { get; set; }
    }
}