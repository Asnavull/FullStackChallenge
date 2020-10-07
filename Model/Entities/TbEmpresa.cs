using Model.Entities.Base;
using System.Collections.Generic;

namespace Model.Entities
{
    public class TbEmpresa : BaseEntity
    {
        public string NomeFantasia { get; set; } = string.Empty;

        public string Uf { get; set; } = string.Empty;

        public long Documento { get; set; } = 0;

        public List<TbFornecedor> Fornecedores { get; set; } = new List<TbFornecedor>();
    }
}