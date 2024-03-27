using NSE.WebApp.MVC.Models;

namespace NSE.WebApp.MVC.Services;

public interface IAutenticacaoService
{
    Task<LoginResponseViewModel> Login(LoginUserViewModel loginUser);

    Task<LoginResponseViewModel> Register(RegisterUserViewModel registerUser);


}