using System;
using System.Text;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;

using Models;
using OnFit;

namespace Services 
{

  public static class TokenService 
  {

    public static string GerarToken(Usuario usuario) 
    {
      var tokenHandler = new JwtSecurityTokenHandler();
      var appKey = Encoding.ASCII.GetBytes(AppKey.Key);
      var tokenDescriptor = new SecurityTokenDescriptor 
      {
        Subject = new ClaimsIdentity(new Claim[]
        {
          new Claim(ClaimTypes.Name, usuario.Id.ToString()),
          new Claim(ClaimTypes.Role, usuario.AlunoEmail.ToString())
        }),
        Expires = DateTime.UtcNow.AddHours(2),
        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(appKey),
           SecurityAlgorithms.HmacSha256Signature)        
        
      };
      var token = tokenHandler.CreateToken(tokenDescriptor);
      return tokenHandler.WriteToken(token);
    }

  }
}


