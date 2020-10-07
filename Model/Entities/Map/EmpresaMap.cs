using Dapper.FluentMap.Mapping;

namespace Model.Entities.Map
{
    public class EmpresaMap : EntityMap<TbEmpresa>
    {
        public EmpresaMap()
        {
            Map(x => x.DataCadastro).ToColumn("DATA_CADASTRO");
            Map(x => x.NomeFantasia).ToColumn("NOME_FANTASIA");
        }
    }
}