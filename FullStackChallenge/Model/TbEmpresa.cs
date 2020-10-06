using FullStackChallenge.Model.Base;
using System.Collections.Generic;

namespace FullStackChallenge.Model
{
    public partial class TbEmpresa : BaseEntity
    {
        public TbEmpresa()
        {
            TbEmpresaFornecedor = new HashSet<TbEmpresaFornecedor>();
        }

        public string NomeFantasia { get; set; }
        public string Uf { get; set; }
        public long Documento { get; set; }

        public virtual ICollection<TbEmpresaFornecedor> TbEmpresaFornecedor { get; set; }
    }
}