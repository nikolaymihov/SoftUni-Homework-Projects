namespace GIT.Controllers
{
    using MyWebServer.Http;
    using MyWebServer.Controllers;

    public class UsersController : Controller
    {
        public HttpResponse Register() => View();

        public HttpResponse Login() => View();
    }
}
