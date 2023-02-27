using Common.Utilities.Response;

using Models.Request;


namespace DataAccess.Core.Contract
{
    public interface IUserRepository
    {
        UserResponse Auth(AuthRequest authRequest);
    }
}
