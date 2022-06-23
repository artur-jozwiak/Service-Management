using Poligon;
using System.Diagnostics;

Blog blogprograming = new Blog()
{
    Title = "Programowanie jest Cool",
    Posts = BlogPostsAboutPrograming.Get()
};

Blog blogspeaking = new Blog()
{
    Title = "Przemawianie to Moc",
    Posts = BlogPostsAboutSpeeaking.Get()
};

List<Blog> blogs = new List<Blog>();
blogs.Add(blogprograming);
blogs.Add(blogspeaking);

var postAll = blogs.SelectMany(b => b.Posts).Select(b => b.Subject).Distinct();
var json1 = Newtonsoft.Json.JsonConvert.SerializeObject(postAll);
Debugger.Break();
