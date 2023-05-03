using Grpc.Net.Client;
using JackXue.Grpc.Service.Protos;

namespace JackXue.Grpc.Client
{
    public class UserTest
    {
        public void GetUserInfo()
        {
            //使用http
            AppContext.SetSwitch("System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport", true);
            const string urlHttps = "http://localhost:7037";
            ////使用https
            //const string urlHttps = "https://localhost:7037";

            using (var channel = GrpcChannel.ForAddress(urlHttps))
            {
                var client = new User.UserClient(channel);
                var userInfo = client.GetUserInfo(new UserInfoRequest()
                {
                    UserName = "JackXue",
                    UserAge = 32
                });

                //打印服务方法返回的结果
                Console.WriteLine($"{userInfo.UserName}，{userInfo.UserAge}，{userInfo.Address}");
            }

            Console.ReadKey();
        }
    }
}
