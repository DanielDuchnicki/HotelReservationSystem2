using System;
using Microsoft.Owin;
using Microsoft.Owin.Hosting;
using Owin;

[assembly: OwinStartup(typeof(API.Program))]
namespace API
{
    public class Program
    {
        static void Main(string[] args)
        {
            using (WebApp.Start("http://localhost:51663", Configuration))
            {
                Console.WriteLine("Press [enter] to quit...");
                Console.ReadLine();
            }
        }
        public static void Configuration(IAppBuilder appBuilder)
        {
            appBuilder.Run(context =>
            {
                context.Response.ContentType = "text/plain";
                return context.Response.WriteAsync("Hello, world.");
            });
        }
    }

}
