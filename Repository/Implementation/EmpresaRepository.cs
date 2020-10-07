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
    public class EmpresaRepository : DapperContext, IEmpresaRepository
    {
        public EmpresaRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public TbEmpresa Create(TbEmpresa entity)
        {
            using var conn = GetSqlConnection();
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                var query = "INSERT INTO TB_EMPRESA (NOME_FANTASIA, UF, DOCUMENTO) VALUES( @NomeFantasia, @Uf, @Documento)";

                return conn.Query<TbEmpresa>(query, entity).FirstOrDefault();
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

                var query = "UPDATE TB_EMPRESA SET ATIVO = 0 WHERE ID = @id";

                conn.Query<TbEmpresa>(query, id);
            }
            finally
            {
                conn.Close();
            }
        }

        public List<TbEmpresa> FindAll()
        {
            using var conn = GetSqlConnection();
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                var query = @"SELECT A.*, B.*
                              FROM TB_EMPRESA A
                              LEFT JOIN TB_EMPRESA_FORNECEDOR C ON C.ID_EMPRESA = A.ID
                              LEFT JOIN TB_FORNECEDOR B ON C.ID_FORNECEDOR = B.ID";

                var empresas = conn.Query<TbEmpresa, TbFornecedor, TbEmpresa>(query, (TbEmpresa, TbFornecedor) =>
                {
                    TbEmpresa.Fornecedores.Add(TbFornecedor);
                    return TbEmpresa;
                }, splitOn: "id").ToList();

                return empresas;
            }
            catch
            {
                return new List<TbEmpresa>();
            }
            finally
            {
                conn.Close();
            }
        }

        public TbEmpresa FindByCnpj(long cnpj)
        {
            using var conn = GetSqlConnection();
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                var query = @"SELECT A.*, B.*
                              FROM TB_EMPRESA A
                              LEFT JOIN TB_EMPRESA_FORNECEDOR C ON C.ID_EMPRESA = A.ID
                              LEFT JOIN TB_FORNECEDOR B ON C.ID_FORNECEDOR = B.ID
                              WHERE A.DOCUMENTO = @cnpj";

                var empresa = conn.Query<TbEmpresa, TbFornecedor, TbEmpresa>(query, (TbEmpresa, TbFornecedor) =>
                {
                    TbEmpresa.Fornecedores.Add(TbFornecedor);
                    return TbEmpresa;
                }, cnpj, splitOn: "id").SingleOrDefault();

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

        public TbEmpresa FindById(Guid id)
        {
            using var conn = GetSqlConnection();
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                var query = @"SELECT A.*, B.*
                              FROM TB_EMPRESA A
                              LEFT JOIN TB_EMPRESA_FORNECEDOR C ON C.ID_EMPRESA = A.ID
                              LEFT JOIN TB_FORNECEDOR B ON C.ID_FORNECEDOR = B.ID
                              WHERE A.ID = @id";

                var empresa = conn.Query<TbEmpresa, TbFornecedor, TbEmpresa>(query, (TbEmpresa, TbFornecedor) =>
                {
                    TbEmpresa.Fornecedores.Add(TbFornecedor);
                    return TbEmpresa;
                }, id, splitOn: "id").SingleOrDefault();

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

        public List<TbEmpresa> FindByName(string nome)
        {
            using var conn = GetSqlConnection();
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                var query = @"SELECT A.*, B.*
                              FROM TB_EMPRESA A
                              LEFT JOIN TB_EMPRESA_FORNECEDOR C ON C.ID_EMPRESA = A.ID
                              LEFT JOIN TB_FORNECEDOR B ON C.ID_FORNECEDOR = B.ID
                              WHERE A.NOME_FANTASIA LIKE '%@nome%'";

                var empresa = conn.Query<TbEmpresa, TbFornecedor, TbEmpresa>(query, (TbEmpresa, TbFornecedor) =>
                {
                    TbEmpresa.Fornecedores.Add(TbFornecedor);
                    return TbEmpresa;
                }, nome, splitOn: "id").ToList();

                return empresa;
            }
            catch
            {
                return new List<TbEmpresa>();
            }
            finally
            {
                conn.Close();
            }
        }

        public TbEmpresa Update(TbEmpresa entity)
        {
            using var conn = GetSqlConnection();
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                var query = @"UPDATE TB_EMPRESA SET NOME_FANTASIA = @NomeFantasia, UF = @Uf, DOCUMENTO = @Documento";

                return conn.Query<TbEmpresa>(query, entity).FirstOrDefault();
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