using Grpc.Core;
using JackXue.Grpc.Service.Protos;

namespace JackXue.Grpc.Service.Services
{
    public class UserService : User.UserBase
    {
        private readonly ILogger<UserService> _logger;
        public UserService(ILogger<UserService> logger)
        {
            _logger = logger;
        }

        public override Task<UserInfoResult> GetUserInfo(UserInfoRequest req,ServerCallContext context)
        {
            return Task.FromResult(new UserInfoResult
            {
                UserName = $"姓名：{req.UserName}",
                UserAge = req.UserAge + 10,
                Address = "地址：福建省厦门市"
            });
        }
    }
}
