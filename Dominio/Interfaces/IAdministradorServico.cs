using Microsoft.EntityFrameworkCore;
using MinimalApi.Dominio.Entidades;
using MinimalApi.DTOs;
using MinimalApi.Infraestrutura.Db;

namespace MinimalApi.Dominio.Interfaces;


public interface IAdministradorServico
{    
    Administrador? Login(LoginDTO loginDTO);   
}