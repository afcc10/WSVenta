using AutoMapper;
using Common;
using Common.Helpers;
using Common.Utilities.Response;
using Common.Utilities.Services;
using DataAccess.Core.Contract;
using DataAccess.Models;
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
        private readonly AppSettings _appSettings;
        #endregion

        #region Contructor
        public UserRepository(VentaRealContext context, 
            ILogger<UserRepository> logger, IMapper mapper,
            IOptions<AppSettings> options)
        {
            this.context = context;
            _logger = logger;
            _mapper = mapper;
            _appSettings = options.Value;
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
            var tokenHandler = new JwtSecurityTokenHandler();
            var llave = Encoding.ASCII.GetBytes(_appSettings.Secreto);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(
                    new Claim[]
                    {
                        new Claim(ClaimTypes.NameIdentifier,model.Id.ToString()),
                        new Claim(ClaimTypes.Email,model.Email)
                    }
                    ),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(llave), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
