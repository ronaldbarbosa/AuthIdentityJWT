using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.Text;
using Microsoft.AspNetCore.Identity.Data;
using Newtonsoft.Json;

namespace AuthIdentityJWT.Web.MVC.Controllers;

public class IdentityController : Controller
{
    [HttpGet]
    public IActionResult Login()
    {
        ViewData["body"] = "body";
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> Login(LoginRequest model)
    {
        var client = new HttpClient();
        var stringContent = JsonConvert.SerializeObject(model);
        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Post,
            RequestUri = new Uri("http://localhost:5059/login"),
            Content = new StringContent(stringContent, Encoding.UTF8, "application/json")
        };
        using (var response = await client.SendAsync(request))
        {
            var body = await response.Content.ReadAsStringAsync();
            ViewData["body"] = body;
        }
        return View();
    }
}