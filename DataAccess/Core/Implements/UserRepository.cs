using AutoMapper;
using Common;
using Common.Helpers;
using Common.Utilities.Response;
using Common.Utilities.Services;
using DataAccess.Core.Contract;
using DataAccess.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Models.Request;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Core.Implements
{
    public class UserRepository : IUserRepository
    {
        #region Propierties
        private readonly VentaRealContext context;
        private readonly ILogger<UserRepository> _logger;
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;
        #endregion

        #region Contructor
        public UserRepository(VentaRealContext context, 
            ILogger<UserRepository> logger, IMapper mapper,
            IConfiguration config)
        {
            this.context = context;
            _logger = logger;
            _mapper = mapper;
            _config = config;
        }
        #endregion

        public UserResponse Auth(AuthRequest authRequest)
        {
            UserResponse response = new UserResponse();

            string spassword = Encrypt.GetSHA256(authRequest.Password);

            var usuario = context.Usuario.Where(x=> x.Email.Equals(authRequest.Email) &&
                                                    x.Password.Equals(spassword)).FirstOrDefault();

            if (usuario == null) return null;
            response.Email = usuario.Email;
            response.Token = GetToken(usuario);

            return response;
        }

        private string GetToken(Usuario model)
        {   
            string secret = _config.GetSection("Secret").Value;            
            
            var claims = new ClaimsIdentity();
            claims.AddClaim(new Claim(ClaimTypes.NameIdentifier, model.Nombre));
            claims.AddClaim(new Claim(ClaimTypes.Email, model.Email));

            var tokenDescription = new SecurityTokenDescriptor()
            {
                Subject = claims,
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secret)), SecurityAlgorithms.HmacSha256Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var createdToken = tokenHandler.CreateToken(tokenDescription);

            return tokenHandler.WriteToken(createdToken);
        }
    }
}
