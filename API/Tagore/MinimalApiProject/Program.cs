using System.ComponentModel.DataAnnotations;
using API.Models;
using Microsoft.AspNetCore.Mvc;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDataContext>();

var app = builder.Build();

Pagamento pagamento = new Pagamento();
Funcionario funcionario = new Funcionario();



// 5201
// POST: https://localhost:5201/api/funcionario/cadastrar
app.MapPost("api/funcionario/cadastrar",([FromBody] Funcionario funcionario,
    [FromServices] AppDataContext ctx) =>
{

    List<ValidationResult> erros = new
        List<ValidationResult>();
    if(!Validator.TryValidateObject(
        funcionario, new ValidationContext(funcionario),
        erros, true))
    {
        return Results.BadRequest(erros);
    }

    //RN: Não permitir produtos com o mesmo nome
    Funcionario? funcionarioBuscado = ctx.Funcionario.
        FirstOrDefault(x => x.nome == funcionario.nome);
    if (funcionarioBuscado is not null)
    {
        return Results.
            BadRequest("Já existe um produto com o mesmo nome!");
    }
});
// GET	https://localhost:5201/api/funcionario/listar
app.MapGet("api/funcionario/listar", 
    ([FromServices] AppDataContext ctx) =>
{
    if (ctx.Funcionario.Any())
    {
        return Results.Ok(ctx.Funcionario.ToList());
    }
    return Results.NotFound("Tabela vazia!");
});
// POST	https://localhost:5201/api/folha/cadastrar
app.MapPost("api/folha/cadastrar", ([FromBody] Funcionario funcionario,
    [FromServices] AppDataContext ctx) =>
{
    //Validação dos atributos do produto
    List<ValidationResult> erros = new
        List<ValidationResult>();
    if(!Validator.TryValidateObject(
        funcionario, new ValidationContext(funcionario),
        erros, true))
    {
        return Results.BadRequest(erros);
    }

// GET	https://localhost:5201/api/folha/listar
app.MapGet("api/folha/listar", ([FromServices] AppDataContext ctx) =>
{
    if (ctx.Pagamento.Any())
    {
        return Results.Ok(ctx.Pagamento.ToList());
    }
    return Results.NotFound("Tabela vazia!");
});});
// GET	https://localhost:5201/api/folha/buscar/{cpf}/{mes}/{ano}
// app.MapGet("api/folha/buscar/{cpf}/{mes}/{ano}");

app.Run();
