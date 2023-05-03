using JackXue.Grpc.Client;
using JackXue.Grpc.Service.Protos;
using Microsoft.Extensions.DependencyInjection;

IServiceCollection services = new ServiceCollection();
// 注册UserTestIoc 服务。
services.AddTransient<UserTestIoc>();
#region gRpc Client 注册

// 注册gRpc客户端服务。
services.AddGrpcClient<User.UserClient>(options =>
{
    options.Address = new Uri("https://localhost:7055");
}).ConfigureChannel(grpcOptions =>
{

});
#endregion

// 构建容器。
IServiceProvider serviceProvider = services.BuildServiceProvider();

// 注入UserTestIoc服务。
var grpcRequestTest = serviceProvider.GetService<UserTestIoc>();

// 调用UserTestIoc服务中的GetUserInfo方法。
grpcRequestTest.GetUserInfo();
