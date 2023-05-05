using envioMasivoCorreos.Dtos;
using envioMasivoCorreos.Models;
using System.Net.Mail;
using System.Reflection;
using System.Reflection.Metadata;
using static envioMasivoCorreos.Common.Constants;

namespace envioMasivoCorreos.Utils
{
    public class Util
    {
        static EmailImgCons _emailImgCons = new EmailImgCons();
        static Util _util = new Util();

        public IEnumerable<string> GetData()
        {
            var contents = File.ReadAllText(Data.DataTest.TestDatabase).Split('\n');
            return contents;
        }

        public MailMessage GetMailMessage(EnterpriseDataDto data, ConfigurationSmtpClient _smtp)
        {
            //Switch General
            #region GeneralValidate
            string body = string.Empty;
            string subject = string.Empty;
            string banner = string.Empty;


            switch (data.Heading)
            {
                case "Restaurante":

                    string restaurantTemplate = data.WebPage != "-" ? Email.Restaurant.Body.WithWeb : Email.Restaurant.Body.WithoutWeb;
                    banner = data.WebPage != "-" ? Email.Restaurant.Body.BannerWithWeb : Email.Restaurant.Body.BannerWithoutWeb;
                    subject = data.WebPage != "-" ? Email.Restaurant.SubjectWithWeb : Email.Restaurant.SubjectWithoutWeb;

                    body = File.ReadAllText(restaurantTemplate);
                    break;

                case "Constructora":

                    string constructorTemplate = data.WebPage != "-" ? Email.Constructor.Body.WithWeb : Email.Constructor.Body.WithoutWeb;
                    banner = data.WebPage != "-" ? Email.Constructor.Body.BannerWithWeb : Email.Constructor.Body.BannerWithoutWeb;
                    subject = data.WebPage != "-" ? Email.Constructor.SubjectWithWeb : Email.Constructor.SubjectWithoutWeb;

                    body = File.ReadAllText(constructorTemplate);
                    break;

                case "Inmobiliaria":

                    string estateTemplate = data.WebPage != "-" ? Email.Estate.Body.WithWeb : Email.Estate.Body.WithoutWeb;
                    banner = data.WebPage != "-" ? Email.Estate.Body.BannerWithWeb : Email.Estate.Body.BannerWithoutWeb;
                    subject = data.WebPage != "-" ? Email.Estate.SubjectWithWeb : Email.Estate.SubjectWithoutWeb;

                    body = File.ReadAllText(estateTemplate);
                    break;
            }
            #endregion

            //Create a email content
            _emailImgCons = new EmailImgCons()
            {
                Logo = Email.ImgConstants.Logo,
                Contact = Email.ImgConstants.Contact,
                Etereo = Email.ImgConstants.Etereo,
                Facebook = Email.ImgConstants.Facebook,
                Instagram = Email.ImgConstants.Instagram,
                Linkedin = Email.ImgConstants.Linkedin,
                Twitter = Email.ImgConstants.Twitter,
            };

            #region Attachments
            List<Attachment> attachments = new List<Attachment>();

            Attachment oAttachmentBanner = new Attachment(banner);
            oAttachmentBanner.ContentId = "bannerid";
            attachments.Add(oAttachmentBanner);

            Attachment oAttachmentLogo = new Attachment(_emailImgCons.Logo);
            oAttachmentLogo.ContentId = "logoid";
            attachments.Add(oAttachmentLogo);

            Attachment oAttachmentIconoWeb = new Attachment(_emailImgCons.Etereo);
            oAttachmentIconoWeb.ContentId = "iconowebid";
            attachments.Add(oAttachmentIconoWeb);

            Attachment oAttachmentIconoWsp = new Attachment(_emailImgCons.Contact);
            oAttachmentIconoWsp.ContentId = "iconowspid";
            attachments.Add(oAttachmentIconoWsp);

            Attachment oAttachmentFacebook = new Attachment(_emailImgCons.Facebook);
            oAttachmentFacebook.ContentId = "facebookid";
            attachments.Add(oAttachmentFacebook);

            Attachment oAttachmentInstagram = new Attachment(_emailImgCons.Instagram);
            oAttachmentInstagram.ContentId = "instagramid";
            attachments.Add(oAttachmentInstagram);

            Attachment oAttachmentLinkd = new Attachment(_emailImgCons.Linkedin);
            oAttachmentLinkd.ContentId = "linkdid";
            attachments.Add(oAttachmentLinkd);

            Attachment oAttachmentTwitter = new Attachment(_emailImgCons.Twitter);
            oAttachmentTwitter.ContentId = "twitterid";
            attachments.Add(oAttachmentTwitter);
            #endregion

            MailMessage mail = new MailMessage();
            mail.Body = body;
            mail.IsBodyHtml = true;
            mail.From = new MailAddress(_smtp.User.ToString());
            mail.To.Add(new MailAddress(data.Email));
            mail.Subject = subject;
            if (!string.IsNullOrEmpty(data.EmailADM))
                mail.CC.Add(new MailAddress(data.EmailADM));            
            foreach(var attachment in attachments)
                mail.Attachments.Add(attachment);

            return mail;
        }
    }
}