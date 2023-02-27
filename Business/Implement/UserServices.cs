using AutoMapper;
using Business.Contract;
using Common;
using Common.Utilities.Response;
using Common.Utilities.Services;
using DataAccess.Core.Contract;
using DataAccess.Core.Implements;
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

namespace Business.Implement
{
    public class UserServices : IUserServices
    {
        #region Propierties
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;        
        #endregion

        #region Constructor
        public UserServices(IUserRepository userRepository, 
                            IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;            
        }
        #endregion


        public UserResponse Auth(AuthRequest authRequest)
        {
            var result = _userRepository.Auth(authRequest);            

            return result;
        }

        
    }
}
