using Business;
using Business.Implementation;
using Business.Validation;
using Dapper.FluentMap;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Net.Http.Headers;
using Microsoft.OpenApi.Models;
using Model.Data.ValueObjects;
using Model.Entities.Map;
using Model.Hypermedia;
using Repository;
using Repository.Implementation;
using Tapioca.HATEOAS;

namespace FullStackChallengeBackEnd
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = configuration;
            _environment = environment;
        }

        public IConfiguration Configuration { get; }
        public IWebHostEnvironment _environment { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton(Configuration);

            FluentMapper.Initialize(config =>
            {
                config.AddMap(new EmpresaMap());
                config.AddMap(new FornecedorMap());
                config.AddMap(new EmpresaFornecedorMap());
            });

            services.AddApiVersioning(options =>
            {
                options.ReportApiVersions = true;
            });

            services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigin",
                        builder =>
                        {
                            builder
                            .AllowAnyOrigin()
                            .AllowAnyMethod()
                            .AllowAnyHeader();
                        });
            });

            services.AddControllers();

            services.AddMvc(options =>
            {
                options.RespectBrowserAcceptHeader = true;
                options.FormatterMappings.SetMediaTypeMappingForFormat("xml", MediaTypeHeaderValue.Parse("text/xml"));
                options.FormatterMappings.SetMediaTypeMappingForFormat("json", MediaTypeHeaderValue.Parse("text/json"));
                options.EnableEndpointRouting = false;
            }).SetCompatibilityVersion(CompatibilityVersion.Latest).AddXmlSerializerFormatters().AddFluentValidation();

            AddSwagger(services);
            ExecuteHateOas(services);

            services.AddScoped<IEmpresaBusiness, EmpresaBusinessImplementation>();
            services.AddScoped<IFornecedorBusiness, FornecedorBusinessImplementation>();
            services.AddScoped<IEmpresaRepository, EmpresaRepository>();
            services.AddScoped<IFornecedorRepository, FornecedorRepository>();

            services.AddTransient<IValidator<Empresa>, EmpresaValidator>();
            services.AddTransient<IValidator<Fornecedor>, FornecedorValidator>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            //app.UseAuthorization();

            app.UseSwagger();

            app.UseSwaggerUI(config =>
            {
                config.SwaggerEndpoint("v1/swagger.json", "FullStackChallenge");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            var rewriteOptions = new RewriteOptions();
            rewriteOptions.AddRedirect("^$", "swagger");
            app.UseRewriter(rewriteOptions);

            app.UseCors("allowSpecificOrigin");
        }

        private void AddSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(config =>
            {
                config.SwaggerDoc("v1", new OpenApiInfo() { Title = "FullStackChallenge", Version = "v1" });
            });
        }

        private void ExecuteHateOas(IServiceCollection services)
        {
            var filterOptions = new HyperMediaFilterOptions();
            filterOptions.ObjectContentResponseEnricherList.Add(new EmpresaEnricher());
            filterOptions.ObjectContentResponseEnricherList.Add(new FornecedorEnricher());

            services.AddSingleton(filterOptions);
        }
    }
}