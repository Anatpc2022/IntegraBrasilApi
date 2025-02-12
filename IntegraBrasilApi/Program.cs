// Importa as interfaces do projeto
using IntegraBrasilApi.Interfaces;

// Importa a classe de mapeamento do AutoMapper
using IntegraBrasilApi.Mappings;

// Importa a implementação da API externa
using IntegraBrasilApi.Rest;

// Importa a implementação dos serviços da aplicação
using IntegraBrasilApi.Services;

// Cria um objeto builder para configurar e construir a aplicação
var builder = WebApplication.CreateBuilder(args);

// Adiciona os controladores ao pipeline da aplicação
builder.Services.AddControllers();

// Adiciona a funcionalidade de exploração de endpoints da API
builder.Services.AddEndpointsApiExplorer();

// Adiciona o suporte ao Swagger para documentação da API
builder.Services.AddSwaggerGen();

// Registra o serviço de endereço como um singleton (instância única durante toda a aplicação)
builder.Services.AddSingleton<IAddressService, AddressService>();

//builder.Services.AddSingleton<IBankService, BankService>();

// Registra o serviço da API externa como um singleton
builder.Services.AddSingleton<IBrasilApi, BrasilApiRest>();

// Configura o AutoMapper, especificando a classe de mapeamento
builder.Services.AddAutoMapper(typeof(AddressMapping));

// Adiciona um cliente HTTP para a API externa, permitindo chamadas HTTP seguras
builder.Services.AddHttpClient<IBrasilApi, BrasilApiRest>();

// Constrói a aplicação com as configurações definidas
var app = builder.Build();

// Verifica se o ambiente é de desenvolvimento
if (app.Environment.IsDevelopment())
{
    // Habilita o Swagger para visualizar a documentação da API
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Força a aplicação a utilizar HTTPS para segurança
app.UseHttpsRedirection();

// Habilita a autorização na API (caso seja configurada futuramente)
app.UseAuthorization();

// Mapeia os controladores para que as rotas sejam reconhecidas pela aplicação
app.MapControllers();

// Inicia a execução da aplicação
app.Run();
