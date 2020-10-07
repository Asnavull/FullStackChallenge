using Dapper.FluentMap.Mapping;

namespace Model.Entities.Map
{
    public class FornecedorMap : EntityMap<TbFornecedor>
    {
        public FornecedorMap()
        {
            Map(x => x.CpfCnpj).ToColumn("CPF_CNPJ");
            Map(x => x.DataNascimento).ToColumn("DATA_NASCIMENTO");
            Map(x => x.DataCadastro).ToColumn("DATA_CADASTRO");
        }
    }
}