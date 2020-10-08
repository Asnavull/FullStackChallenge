using Dapper;
using Microsoft.Extensions.Configuration;
using Model.Entities;
using Repository.Context;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Repository.Implementation
{
    public class FornecedorRepository : DapperContext, IFornecedorRepository
    {
        public FornecedorRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public TbFornecedor AddEmpresa(Guid idFornecedor, Guid idEmpresa)
        {
            using var conn = GetSqlConnection();
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                var query = @"INSERT INTO TB_EMPRESA_FORNECEDOR (ID_EMPRESA, ID_FORNECEDOR)
                              VALUES( @idEmpresa, @idFornecedor)";

                conn.Query(query, new { idEmpresa, idFornecedor });

                return FindById(idFornecedor);
            }
            catch
            {
                return null;
            }
            finally
            {
                conn.Close();
            }
        }

        public TbFornecedor Create(TbFornecedor entity)
        {
            using var conn = GetSqlConnection();
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                var query = "INSERT INTO TB_FORNECEDOR (NOME, EMAIL, CPF_CNPJ, RG, DATA_NASCIMENTO) VALUES (@Nome, @Email, @CpfCnpj, @Rg, @DataNascimento);";

                return conn.Query<TbFornecedor>(query, entity).FirstOrDefault();
            }
            catch
            {
                return null;
            }
            finally
            {
                conn.Close();
            }
        }

        public void Delete(Guid id)
        {
            using var conn = GetSqlConnection();
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                var query = "UPDATE TB_FORNECEDOR SET ATIVO = 0 WHERE ID = @id";

                conn.Query(query, new { id });
            }
            finally
            {
                conn.Close();
            }
        }

        public List<TbFornecedor> FindAll()
        {
            using var conn = GetSqlConnection();
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                var query = @"SELECT A.*, B.*
                              FROM TB_FORNECEDOR A
                              LEFT JOIN TB_EMPRESA_FORNECEDOR C ON C.ID_FORNECEDOR = A.ID
                              LEFT JOIN TB_EMPRESA B ON C.ID_EMPRESA = B.ID
                              WHERE A.ATIVO = 1";

                var empresas = conn.Query<TbFornecedor, TbEmpresa, TbFornecedor>(query, (TbFornecedor, TbEmpresa) =>
                {
                    TbFornecedor.Empresas.Add(TbEmpresa);
                    return TbFornecedor;
                }, splitOn: "id").ToList();

                return empresas;
            }
            catch
            {
                return new List<TbFornecedor>();
            }
            finally
            {
                conn.Close();
            }
        }

        public TbFornecedor FindByCpfCnpj(long cpfCnpj)
        {
            using var conn = GetSqlConnection();
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                var query = @"SELECT A.*, B.*
                              FROM TB_FORNECEDOR A
                              LEFT JOIN TB_EMPRESA_FORNECEDOR C ON C.ID_FORNECEDOR = A.ID
                              LEFT JOIN TB_EMPRESA B ON C.ID_EMPRESA = B.ID
                              WHERE A.CPF_CNPJ = @cpfCnpj AND A.ATIVO = 1";

                var empresa = conn.Query<TbFornecedor, TbEmpresa, TbFornecedor>(query, (TbFornecedor, TbEmpresa) =>
                {
                    TbFornecedor.Empresas.Add(TbEmpresa);
                    return TbFornecedor;
                }, new { cpfCnpj }, splitOn: "id").SingleOrDefault();

                return empresa;
            }
            catch
            {
                return null;
            }
            finally
            {
                conn.Close();
            }
        }

        public TbFornecedor FindByEmail(string email)
        {
            using var conn = GetSqlConnection();
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                var query = @"SELECT A.*, B.*
                              FROM TB_FORNECEDOR A
                              LEFT JOIN TB_EMPRESA_FORNECEDOR C ON C.ID_FORNECEDOR = A.ID
                              LEFT JOIN TB_EMPRESA B ON C.ID_EMPRESA = B.ID
                              WHERE A.EMAIL = @email";

                var empresa = conn.Query<TbFornecedor, TbEmpresa, TbFornecedor>(query, (TbFornecedor, TbEmpresa) =>
                {
                    TbFornecedor.Empresas.Add(TbEmpresa);
                    return TbFornecedor;
                }, new { email }, splitOn: "id").SingleOrDefault();

                return empresa;
            }
            catch
            {
                return null;
            }
            finally
            {
                conn.Close();
            }
        }

        public TbFornecedor FindById(Guid id)
        {
            using var conn = GetSqlConnection();
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                var query = @"SELECT A.*, B.*
                              FROM TB_FORNECEDOR A
                              LEFT JOIN TB_EMPRESA_FORNECEDOR C ON C.ID_FORNECEDOR = A.ID
                              LEFT JOIN TB_EMPRESA B ON C.ID_EMPRESA = B.ID
                              WHERE A.ID = @id";

                var empresa = conn.Query<TbFornecedor, TbEmpresa, TbFornecedor>(query, (TbFornecedor, TbEmpresa) =>
                {
                    TbFornecedor.Empresas.Add(TbEmpresa);
                    return TbFornecedor;
                }, new { id }, splitOn: "id").SingleOrDefault();

                return empresa;
            }
            catch
            {
                return null;
            }
            finally
            {
                conn.Close();
            }
        }

        public List<TbFornecedor> FindByName(string nome)
        {
            using var conn = GetSqlConnection();
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                var query = @"SELECT A.*, B.*
                              FROM TB_FORNECEDOR A
                              LEFT JOIN TB_EMPRESA_FORNECEDOR C ON C.ID_FORNECEDOR = A.ID
                              LEFT JOIN TB_EMPRESA B ON C.ID_EMPRESA = B.ID
                              WHERE A.NOME LIKE @nome";

                var empresa = conn.Query<TbFornecedor, TbEmpresa, TbFornecedor>(query, (TbFornecedor, TbEmpresa) =>
                {
                    TbFornecedor.Empresas.Add(TbEmpresa);
                    return TbFornecedor;
                }, new { nome = string.Concat("%", nome, "%") }, splitOn: "id").ToList();

                return empresa;
            }
            catch
            {
                return new List<TbFornecedor>();
            }
            finally
            {
                conn.Close();
            }
        }

        public bool HasCpfCnpj(long cpfCnpj)
        {
            using var conn = GetSqlConnection();
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                var query = @"SELECT COUNT(1) FROM TB_FORNECEDOR WHERE CPF_CNPJ = @cpfCnpj";

                return conn.ExecuteScalar<int>(query, new { cpfCnpj }) > 0;
            }
            catch
            {
                return true;
            }
            finally
            {
                conn.Close();
            }
        }

        public bool HasEmail(string email)
        {
            using var conn = GetSqlConnection();
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                var query = @"SELECT COUNT(1) FROM TB_FORNECEDOR WHERE EMAIL = @email";

                return conn.ExecuteScalar<int>(query, new { email }) > 0;
            }
            catch
            {
                return true;
            }
            finally
            {
                conn.Close();
            }
        }

        public TbFornecedor RemoveEmpresa(Guid idFornecedor, Guid idEmpresa)
        {
            using var conn = GetSqlConnection();
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                var query = @"UPDATE TB_EMPRESA_FORNECEDOR
                              SET ATIVO = 0
                              WHERE ID_EMPRESA = @idEmpresa
                                AND ID_FORNECEDOR = @idFornecedor";

                conn.Query(query, new { idEmpresa, idFornecedor });

                return FindById(idFornecedor);
            }
            catch
            {
                return null;
            }
            finally
            {
                conn.Close();
            }
        }

        public TbFornecedor Update(TbFornecedor entity)
        {
            using var conn = GetSqlConnection();
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                var query = @"UPDATE TB_FORNECEDOR SET NOME = @Nome, CPF_CNPJ = @CpfCnpj, DATA_NASCIMENTO = @DataNascimento, EMAIL = @Email, RG = @Rg, ATIVO = 1 WHERE ID = @Id";

                return conn.Query<TbFornecedor>(query, entity).FirstOrDefault();
            }
            catch
            {
                return null;
            }
            finally
            {
                conn.Close();
            }
        }
    }
}