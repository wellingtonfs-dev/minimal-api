using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MinimalApi.Dominio.Entidades;
using MinimalApi.Dominio.Servico;
using MinimalApi.Infraestrutura.Db;

namespace Test.Dominio.Entidades;



[TestClass]
public class AdministradorServicoTest
{
    private DbContexto CriarContextoDeTeste()
    {
        var assemblyPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        var path = Path.GetFullPath(Path.Combine(assemblyPath ?? "","..","..",".."));

        // Configurar o ConfigurationBuilder
        var builder = new ConfigurationBuilder()
          .SetBasePath(path ?? Directory.GetCurrentDirectory())
          .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
          .AddEnvironmentVariables();

        var configuration = builder.Build();  

        return new DbContexto(configuration);
    }

    [TestMethod]
    public void TestandoSalvarAdministrador()
    {
        // Arrange
        var context = CriarContextoDeTeste();
        context.Database.ExecuteSqlRaw("TRUNCATE TABLE Administradores");

        var adm = new Administrador();                      
        adm.Email = "teste@teste.com";
        adm.Senha = "123456";
        adm.Perfil = "Adm";
        var administradorServico = new AdministradorServico(context);


        // Act  
        administradorServico.Incluir(adm);
        

        // Assert
        Assert.AreEqual(1, administradorServico.Todos(1).Count());
        
    }

    [TestMethod]
    public void TestandoBuscarPorId()
    {
        // Arrange
        var context = CriarContextoDeTeste();
        context.Database.ExecuteSqlRaw("TRUNCATE TABLE Administradores");

        var adm = new Administrador();                      
        adm.Email = "teste@teste.com";
        adm.Senha = "123456";
        adm.Perfil = "Adm";
        var administradorServico = new AdministradorServico(context);


        // Act  
        administradorServico.Incluir(adm);
        var admDoBanco = administradorServico.BuscaPorId(adm.Id);
        

        // Assert
        Assert.AreEqual(1, admDoBanco.Id);
        
    }
}
