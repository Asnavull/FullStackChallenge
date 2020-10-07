using Dapper.FluentMap.Mapping;

namespace Model.Entities.Map
{
    public class EmpresaFornecedorMap : EntityMap<TbEmpresaFornecedor>
    {
        public EmpresaFornecedorMap()
        {
            Map(x => x.DataCadastro).ToColumn("DATA_CADASTRO");
            Map(x => x.IdEmpresa).ToColumn("ID_EMPRESA");
            Map(x => x.IdFornecedor).ToColumn("ID_FORNECEDOR");
        }
    }
}