using Microsoft.EntityFrameworkCore;

namespace FullStackChallenge.Model.Context
{
    public partial class SqlServerContext : DbContext
    {
        private readonly string _connectionString;

        public SqlServerContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        public SqlServerContext(DbContextOptions<SqlServerContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_connectionString);
            }
        }

        public virtual DbSet<TbEmpresa> TbEmpresa { get; set; }
        public virtual DbSet<TbEmpresaFornecedor> TbEmpresaFornecedor { get; set; }
        public virtual DbSet<TbFornecedor> TbFornecedor { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TbEmpresa>(entity =>
            {
                entity.ToTable("TB_EMPRESA");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.DataCadastro)
                    .HasColumnName("DATA_CADASTRO")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Documento).HasColumnName("DOCUMENTO");

                entity.Property(e => e.NomeFantasia)
                    .IsRequired()
                    .HasColumnName("NOME_FANTASIA")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Uf)
                    .IsRequired()
                    .HasColumnName("UF")
                    .HasMaxLength(2)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TbEmpresaFornecedor>(entity =>
            {
                entity.ToTable("TB_EMPRESA_FORNECEDOR");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.DataCadastro)
                    .HasColumnName("DATA_CADASTRO")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IdEmpresa).HasColumnName("ID_EMPRESA");

                entity.Property(e => e.IdFornecedor).HasColumnName("ID_FORNECEDOR");

                entity.HasOne(d => d.IdEmpresaNavigation)
                    .WithMany(p => p.TbEmpresaFornecedor)
                    .HasForeignKey(d => d.IdEmpresa)
                    .HasConstraintName("FK__TB_EMPRES__ID_EM__08162EEB");

                entity.HasOne(d => d.IdFornecedorNavigation)
                    .WithMany(p => p.TbEmpresaFornecedor)
                    .HasForeignKey(d => d.IdFornecedor)
                    .HasConstraintName("FK__TB_EMPRES__ID_FO__090A5324");
            });

            modelBuilder.Entity<TbFornecedor>(entity =>
            {
                entity.ToTable("TB_FORNECEDOR");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.CpfCnpj).HasColumnName("CPF_CNPJ");

                entity.Property(e => e.DataCadastro)
                    .HasColumnName("DATA_CADASTRO")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DataNascimento).HasColumnName("DATA_NASCIMENTO");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("EMAIL")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("NOME")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Rg).HasColumnName("RG");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}