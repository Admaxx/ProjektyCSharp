using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using PaperStoreModel.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PaperStoreApplication.Services.Account.LoginOptions
{
    internal class CreatingUsersToken
    {
        internal string CreateToken(UserCredentialsModel userData)
        {
            var creds = new SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes
                (new ConfigurationBuilder().AddJsonFile("appsettings.json").Build()["appSettings:Token"])), 
                SecurityAlgorithms.HmacSha512Signature);

            return new JwtSecurityTokenHandler() //Get token to user send
                .WriteToken(
                new JwtSecurityToken
                (
                    claims: new List<Claim>() { new Claim(ClaimTypes.Name, userData.Email) },//Setting user to claims
                    expires: DateTime.UtcNow.AddDays(1),
                    signingCredentials: creds
                ) //Getting token security
                );
        }



    }
}
