using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace envioMasivoCorreos.Common
{
    public class Constants
    {
        public struct Data
        {
            public struct DataTest
            {
                public const string TestDatabase = (@$"Data\\Test\\excelPruebas.csv");
            }
        }

        public struct Email
        {
            public struct Restaurant
            {
                public const string Name = "Restaurante";
                public const string SubjectWithWeb = "¿Estás buscando una página web más efectiva? ¡Hablemos!";
                public const string SubjectWithoutWeb = "¿Quieres vender más? Ofrece pedidos en línea en tu restaurante.";
                public const string Content = "content";
            
                public struct Body
                {
                    public const string WithWeb = (@$"Assets\\Templates\\Restaurant\\indexwithweb.html");
                    public const string WithoutWeb = (@$"Assets\\Templates\\Restaurant\\indexwithoutweb.html");
                    public const string BannerWithWeb = (@$"Assets\\Templates\\Restaurant\\Images\\bannerwithweb.jpg");
                    public const string BannerWithoutWeb = (@$"Assets\\Templates\\Restaurant\\Images\\bannerwithoutweb.jpg");
                }
            }

            public struct Constructor
            {
                public const string Name = "Constructor";
                public const string SubjectWithWeb = "¿Estás buscando una página web más efectiva? ¡Hablemos!";
                public const string SubjectWithoutWeb = "¿Está buscando una nueva página web para su empresa constructora? ¡Permítanos ayudarle!";
                public const string Content = "content";

                public struct Body
                {
                    public const string WithWeb = (@$"Assets\\Templates\\Constructor\\indexwithweb.html");
                    public const string WithoutWeb = (@$"Assets\\Templates\\Constructor\\indexwithoutweb.html");
                    public const string BannerWithWeb = (@$"Assets\\Templates\\Constructor\\Images\\bannerwithweb.jpg");
                    public const string BannerWithoutWeb = (@$"Assets\\Templates\\Constructor\\Images\\bannerwithoutweb.jpg");
                }
            }

            public struct Estate
            {
                public const string Name = "Estate";
                public const string SubjectWithWeb = "¿Estás buscando una página web más efectiva? ¡Hablemos!";
                public const string SubjectWithoutWeb = "¿Quieres una página web que represente la calidad de su trabajo y su experiencia en el sector inmobiliario? ¡Hablemos!";
                public const string Content = "content";

                public struct Body
                {
                    public const string WithWeb = (@$"Assets\\Templates\\Estate\\indexwithweb.html");
                    public const string WithoutWeb = (@$"Assets\\Templates\\Estate\\indexwithoutweb.html");
                    public const string BannerWithWeb = (@$"Assets\\Templates\\Estate\\Images\\bannerwithweb.jpg");
                    public const string BannerWithoutWeb = (@$"Assets\\Templates\\Estate\\Images\\bannerwithoutweb.jpg");
                }
            }

            public struct ImgConstants
            {
                public const string Logo = ($@"Assets\\Images\\logo-etereo-nav.png");
                public const string Contact = ($@"Assets\\Images\\contact.png");
                public const string Etereo = ($@"Assets\\Images\\etereo.png");
                public const string Facebook = ($@"Assets\\Images\\facebook-icon.png");
                public const string Instagram = ($@"Assets\\Images\\instagram-icon.png");
                public const string Linkedin = ($@"Assets\\Images\\linkedin-icon.png");
                public const string Twitter = ($@"Assets\\Images\\twitter-icon.png");
            }
        }
    }
}
