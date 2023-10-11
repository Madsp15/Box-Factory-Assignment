using infrastructure;
using Microsoft.AspNetCore.Mvc;
using service;
using WebApplication2.TransferModels;

namespace WebApplication2.Controllers;

[ApiController]
public class LoginController : ControllerBase
{
    private readonly LoginService _loginService;

    public LoginController(LoginService loginService)
    {
        _loginService = loginService;
    }
    
    [Route("/api/boxes/login")]
    [HttpPost]
    public bool Login([FromBody] LoginDto loginDto)
    {
        return _loginService.Login(loginDto.Username, loginDto.Password);
    }

    [Route("/api/boxes/register")]
    [HttpPost]
    public bool Register([FromBody] RegisterDto registerDto)
    {
        return _loginService.Register(registerDto.Username, registerDto.Email, registerDto.Password);
    }

}