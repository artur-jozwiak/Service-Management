using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poligon
{
    public class Blog
    {
        public IEnumerable<BlogPost> Posts { get; set; }

        public string Title { get; set; }


    }

    public class BlogPost
    {
        public string Title { get; set; }

        public string Author { get; set; }

        public string Subject { get; set; }
    }
    public static class BlogPostsAboutPrograming
    {
        public static string GetJson()
        {
            var list = Get();
            return Newtonsoft.Json.JsonConvert.SerializeObject(list);
        }

        public static IEnumerable<BlogPost> Get()
        {
            List<BlogPost> blogPosts = new List<BlogPost>();

            BlogPost p1 = new BlogPost()
            {
                Title = "Kuberetes i Docker : Wytłumacz mi i pokaż",
                Author = "Jacke",
                Subject = "Kubernetes"
            };

            BlogPost p2 = new BlogPost()
            {
                Title = "Zakup mieszkania w Warszawie : Zarobki programisty",
                Author = "Damian",
                Subject = "Filozfia"
            };

            BlogPost p3 = new BlogPost()
            {
                Title = "Wypoczęty programista. CO ? : Aktywny programista",
                Author = "Damian",
                Subject = "Filozfia"
            };

            BlogPost p4 = new BlogPost()
            {
                Title = "Zakładanie Rodziny czy Kariera czy Marzenia : Serce Programisty",
                Author = "Damian",
                Subject = "Filozfia"
            };

            BlogPost p5 = new BlogPost()
            {
                Title = "Sukces? To gra długodystansowa : Aktywny programista",
                Author = "Damian",
                Subject = "Filozfia"
            };

            BlogPost p6 = new BlogPost()
            {
                Title = "Co nowego w C# 9.0 ? Rekordy i Pattern Matching",
                Author = "Cezary",
                Subject = "c#"
            };

            BlogPost p7 = new BlogPost()
            {
                Title = "Asynchroniczny C# : Awaitables, Maszyna stanów i TaskCompletionSource",
                Author = "Cezary",
                Subject = "C#"
            };

            BlogPost p8 = new BlogPost()
            {
                Title = "TDD z C# : Test jednostkowy z XUnit, NUnit, MSUnit",
                Author = "Cezary",
                Subject = "c#"
            };

            BlogPost p9 = new BlogPost()
            {
                Title = "Higher Order Function : Przykłady Funkcji wyższego rzędu w C#",
                Author = "Cezary",
                Subject = "Csharp"
            };

            BlogPost p10 = new BlogPost()
            {
                Title = "Mailchimp i ASP.NET : Stworzenie newslettera",
                Author = "Kamil",
                Subject = "ASP.NET"
            };

            BlogPost p11 = new BlogPost()
            {
                Title = "ASP.NET i Angular : Caching, konfiguracja, REST API, Components",
                Author = "Adam",
                Subject = "asp net"
            };

            BlogPost p12 = new BlogPost()
            {
                Title = "Kurs ASP.NET i Angular : Zobaczmy domyślny szablon",
                Author = "Adam",
                Subject = "ASP.NET"
            };

            BlogPost p13 = new BlogPost()
            {
                Title = "ASP.NET Core Response Compression na Blog",
                Author = "Kamil",
                Subject = "ASP.NET"
            };

            blogPosts.Add(p1); blogPosts.Add(p2);
            blogPosts.Add(p3); blogPosts.Add(p4);
            blogPosts.Add(p5); blogPosts.Add(p6);
            blogPosts.Add(p7); blogPosts.Add(p8);
            blogPosts.Add(p9); blogPosts.Add(p10);
            blogPosts.Add(p11); blogPosts.Add(p12);
            blogPosts.Add(p13);

            return blogPosts;
        }
    }

    public static class BlogPostsAboutSpeeaking
    {
        public static string GetJson()
        {
            var list = Get();
            return Newtonsoft.Json.JsonConvert.SerializeObject(list);
        }

        public static IEnumerable<BlogPost> Get()
        {
            List<BlogPost> blogPosts = new List<BlogPost>();

            BlogPost p1 = new BlogPost()
            {
                Title = "JAK COVID zmienił świat przemawiania",
                Author = "Jacke",
                Subject = "Przemawianie"
            };

            BlogPost p2 = new BlogPost()
            {
                Title = "SŁUCHANIE i rzeczywiste powody by nauczyć się słuchać",
                Author = "Damian",
                Subject = "Przemawianie"
            };

            BlogPost p3 = new BlogPost()
            {
                Title = "Pisać czy nie pisać mowy DLACZEGO",
                Author = "Damian",
                Subject = "Przemawianie"
            };

            BlogPost p4 = new BlogPost()
            {
                Title = "Jordan Peterson i posprzątaj swój POKÓJ",
                Author = "Damian",
                Subject = "Samorozwój"
            };

            BlogPost p5 = new BlogPost()
            {
                Title = "5 obaw z którymi trzeba się ZMIERZYĆ",
                Author = "Damian",
                Subject = "Samorozwój"
            };

            BlogPost p6 = new BlogPost()
            {
                Title = "Mentorować JAK I PO CO ? ",
                Author = "Cezary",
                Subject = "Samorozwój"
            };

            BlogPost p7 = new BlogPost()
            {
                Title = "4 typy CHARYZMY",
                Author = "Cezary",
                Subject = "Książki"
            };

            BlogPost p8 = new BlogPost()
            {
                Title = "Fight Club i gdzie jest współczesna MĘSKOŚĆ",
                Author = "Cezary",
                Subject = "Książki"
            };

            BlogPost p9 = new BlogPost()
            {
                Title = "TEORIA przywiązania WEDŁUG KSIĄŻKI ATTACHED AUTORÓW RACHEL S.F.HELLER,AMIR LEVINE",
                Author = "Cezary",
                Subject = "Książki"
            };

            BlogPost p10 = new BlogPost()
            {
                Title = "32 pomysłów na tworzenie ARGUMENTÓW",
                Author = "Kamil",
                Subject = "Przemawianie"
            };

            BlogPost p11 = new BlogPost()
            {
                Title = "The COMPOUND EFFECT Codzienne działanie, masowe REZULTATY",
                Author = "Adam",
                Subject = "Książki"
            };

            BlogPost p12 = new BlogPost()
            {
                Title = "Ekstaza i koncentracja stanu FLOW",
                Author = "Adam",
                Subject = "Książki"
            };


            blogPosts.Add(p1); blogPosts.Add(p2);
            blogPosts.Add(p3); blogPosts.Add(p4);
            blogPosts.Add(p5); blogPosts.Add(p6);
            blogPosts.Add(p7); blogPosts.Add(p8);
            blogPosts.Add(p9); blogPosts.Add(p10);
            blogPosts.Add(p11); blogPosts.Add(p12);

            return blogPosts;
        }

    }
}
