using System.Security.Claims;
using meero.entity;
using Microsoft.AspNetCore.Mvc;
namespace meero.bll.Service;

public interface IJWTService {
    public string generate(ApplicationUser applicationUser);
    public ApplicationUser validate(string token);
}