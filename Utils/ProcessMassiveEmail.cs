using envioMasivoCorreos.Dtos;
using envioMasivoCorreos.Models;
using Serilog;
using System.Net.Mail;

namespace envioMasivoCorreos.Utils
{
    public class ProcessMassiveEmail
    {
        static SendEmail _sendEmail = new SendEmail();
        static Util _util = new Util();

        public void EmailMassive(ConfigurationSmtpClient _smtp)
        {
            try
            {
                //initialize SmtpClient
                Log.Information("Initialize SmtpClient");
                SmtpClient smtpClient = _sendEmail.InitializeConfiguration(_smtp);

                var utilList = _util.GetData().ToList();

                for (int i = 1; i < utilList.Count(); i++)
                {
                    var emp = utilList[i].Split('|').ToArray();
                    if (emp.Length < 3) return;
                    Log.Information("_____________________________________________________________________");
                    Log.Information($"EMAIL NRO:{i} | fecha: {DateTime.Now}");
                    Console.WriteLine("_____________________________________________________________________");
                    Console.WriteLine($"EMAIL NRO:{i} | fecha: {DateTime.Now}");
                    EnterpriseDataDto data = new EnterpriseDataDto()
                    {
                        RUC = emp[0],
                        Email = emp[1],
                        EmailADM = string.IsNullOrEmpty(emp[2]) ? string.Empty : emp[2],
                        Phone = emp[3],
                        Departament = emp[4],
                        Province = emp[5],
                        District = emp[6],
                        BusinessName = emp[7],
                        Heading = emp[8],
                        WebPage = emp[9],
                    };
                    Log.Information($"User :{data.RUC} | Email :{data.Email} | Phone :{data.BusinessName}");
                    Console.WriteLine($"User :{data.RUC} | Email :{data.Email} | Phone :{data.BusinessName}");

                    MailMessage mail = _util.GetMailMessage(data, _smtp);

                    bool rpta = _sendEmail.Send(smtpClient, mail);
                }
            }
            catch (Exception ex)
            {
                Log.Error($"Error in method Program.EmailMassive : {ex.Message}");
                Console.WriteLine($"Error in method Program.EmailMassive : {ex.Message}");
            }
        }

    }
}
