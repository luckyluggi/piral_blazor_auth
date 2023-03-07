using Framework.Authentication;
using Microsoft.Extensions.DependencyInjection;
using System;

public class Module
{
    public static void Main()
    {
        // this entrypoint should remain empty 
    }

    public static void ConfigureServices(IServiceCollection services)
    {
        //add your services here
    }
    public static void ConfigureShared(IServiceCollection services)
    {
        services.AddMyAuthentication();
        services.AddLogging();
    }
}