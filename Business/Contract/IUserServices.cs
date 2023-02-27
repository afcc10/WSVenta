using Common.Utilities.Response;
using Common.Utilities.Services;
using Models.Request;

namespace Business.Contract
{
    public interface IUserServices
    {
        UserResponse Auth(AuthRequest authRequest);
    }
}
