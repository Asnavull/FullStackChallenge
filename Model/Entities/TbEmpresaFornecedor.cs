using Model.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Entities
{
    public class TbEmpresaFornecedor : BaseEntity
    {
        public Guid IdEmpresa { get; set; }
        public Guid IdFornecedor { get; set; }
    }
}
