using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using MinimalApi.Exemplo.Models;
using MinimalApi.Exemplo.Repositories;
using MinimalApi.Exemplo.Validator;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<UsuarioRespository>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<UsuarioValidator>());

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();

/// <summary>
/// Listagem de todos os usuários
/// </summary>
app.MapGet("/usuarios",
[ProducesResponseType(200, Type = (typeof(List<Usuario>)))]
(UsuarioRespository repo) =>
{
    return Results.Ok(repo.BuscarTodos());
});

/// <summary>
/// Listagem de um usuário por Id
/// </summary>
app.MapGet("/usuarios/{id}",
[ProducesResponseType(200, Type = (typeof(Usuario)))]
(UsuarioRespository repo, Guid id) =>
{
    var usuario = repo.BuscarPorId(id);
    return usuario is not null ? Results.Ok(usuario) : Results.NotFound();
});

/// <summary>
/// Criação de um usuário
/// </summary>
app.MapPost("/usuarios",
[ProducesResponseType(201, Type = (typeof(Usuario)))]
(UsuarioRespository repo, IValidator <Usuario> validator, Usuario usuario) =>
{
    var resultadoValidator = validator.Validate(usuario);
    if (!resultadoValidator.IsValid)
    {
        var erros = new { errors = resultadoValidator.Errors.Select(x => x.ErrorMessage) };
        return Results.BadRequest(erros);
    }

    repo.Criar(usuario);
    return Results.Created($"/usuarios/{usuario.Id}", usuario);
});

/// <summary>
/// Atualização dos dados de um usuário
/// </summary>
app.MapPut("/usuarios/{id}",
[ProducesResponseType(200, Type = (typeof(Usuario)))]
(UsuarioRespository repo, Guid id, Usuario usuarioUpdate) =>
{
    var usuarioRepo = repo.BuscarPorId(id);
    if (usuarioRepo is null)
        return Results.NotFound();

    repo.Update(usuarioUpdate);
    return Results.Ok(usuarioUpdate);
});

/// <summary>
/// Delete de um usuário
/// </summary>
app.MapDelete("/usuarios/{id}",
[ProducesResponseType(200)]
(UsuarioRespository repo, Guid id) =>
{
    repo.Delete(id);
    return Results.Ok();
});

app.Run();
