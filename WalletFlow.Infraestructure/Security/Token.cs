using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WalletFlow.Domain.Entities;

namespace WalletFlow.Infraestructure.Security
{
    public static class Token
    {
        // Defina o segredo utilizado para assinar o token
        private const string Secret = "fedaf7d8863b48e197b9287d492b708e"; // Este segredo deve ser mantido seguro e idealmente em um arquivo de configuração

        public static string GenerateToken(User user)
        {
            // Verifique se o nome do usuário não é nulo
            if (user.Name == null)
            {
                throw new ArgumentNullException(nameof(user.Name), "O nome do usuário não pode ser nulo.");
            }

            // Criação do token JWT
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(Secret);

            // Descrição do token (claims, expiração, assinatura, etc.)
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Name ?? "NomeDesconhecido"), // Nome do usuário
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()), // ID do usuário
                    new Claim(ClaimTypes.Role, "user") // Função do usuário
                }),
                Expires = DateTime.UtcNow.AddHours(2), // Defina o tempo de expiração do token
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Issuer = "SeuEmissor", // Emissor do token (pode ser qualquer valor)
                Audience = "SuaAudience" // Audiência (pode ser qualquer valor)
            };

            // Criação do token JWT
            var token = tokenHandler.CreateToken(tokenDescriptor);

            // Retorna o token gerado como string
            return tokenHandler.WriteToken(token);
        }
    }
}
