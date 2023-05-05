using envioMasivoCorreos.Common;
using envioMasivoCorreos.Dtos;
using envioMasivoCorreos.Models;
using envioMasivoCorreos.Utils;
using Microsoft.Extensions.Configuration;
using Serilog;

internal class Program
{
    static ConfigurationSmtpClient? _configurationSmtpClient;
    static ProcessMassiveEmail _processMassiveEmail = new ProcessMassiveEmail();

    private static void Main(string[] args)
    {
        //Config Logger
        Log.Logger = new LoggerConfiguration()
                        .WriteTo.File(@$"C:\Logs\{DateTime.Now:yyyy-MM-dd}-log.txt", rollingInterval: RollingInterval.Day)
                        .CreateLogger(); // cambiar por ruta para que se escriba en el proyecto

        Log.Information("Initialize serilog");

        //Create a builder and config
        Log.Information("Create a builder and config");
        var builder = new ConfigurationBuilder().AddJsonFile($"appsettings.json", true, true);
        var config = builder.Build();        

        //Initialize smtp credentials
        Log.Information("initialize smtp credentials");        
        _configurationSmtpClient = new ConfigurationSmtpClient()
        {
            Host = config["ConfigurationSmtpClient:Host"],
            Port = int.Parse(config["ConfigurationSmtpClient:Port"]),
            EnableSsl = bool.Parse(config["ConfigurationSmtpClient:EnableSsl"]),
            User = config["ConfigurationSmtpClient:User"],
            Password = config["ConfigurationSmtpClient:Password"]
        };

        //Execute EmailMassive
        Log.Information("Execute EmailMassive");
        Console.WriteLine("Se ejecutara el metodo EmailMassive");

        _processMassiveEmail.EmailMassive(_configurationSmtpClient);     
    }
}