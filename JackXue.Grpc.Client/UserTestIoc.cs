using JackXue.Grpc.Service.Protos;

namespace JackXue.Grpc.Client
{
    public class UserTestIoc
    {
        private readonly User.UserClient userCilent;

        public UserTestIoc(User.UserClient _userCilent)
        {
            userCilent = _userCilent;
        }

        public void GetUserInfo()
        {
            var userInfo = userCilent.GetUserInfo(new UserInfoRequest()
            {
                UserName = "JackXue - IOC",
                UserAge = 20
            });

            Console.WriteLine($"{userInfo.UserName}，{userInfo.UserAge}，{userInfo.Address}");
            Console.ReadKey();
        }
    }
}
