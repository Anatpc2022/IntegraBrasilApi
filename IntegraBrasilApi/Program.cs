using IntegraBrasilApi.Interfaces;
using IntegraBrasilApi.Mappings;
using IntegraBrasilApi.Rest;
using IntegraBrasilApi.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IAddressService, AddressService>();
//builder.Services.AddSingleton<IBankService, BankService>();
builder.Services.AddSingleton<IBrasilApi, BrasilApiRest>();

builder.Services.AddAutoMapper(typeof(AddressMapping));

builder.Services.AddHttpClient<IBrasilApi, BrasilApiRest>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
