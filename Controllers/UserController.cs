using System.Net;
using Microsoft.AspNetCore.Mvc;
namespace api1.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class UserController: ControllerBase
{
    [HttpGet]
    public IActionResult Ip()
    {
        var remoteIpAddress = "";
        var remoteIp = HttpContext.Connection.RemoteIpAddress;
        string? ip = HttpContext.Request.Headers.ContainsKey("X-Client-IP") ? HttpContext.Request?.Headers["X-Client-IP"].FirstOrDefault()
                        : HttpContext.Request?.Headers["X-Forwarded-For"].FirstOrDefault();
        string v = ip != null ? ip : "";
        ip = v;
        try
        {
            IPAddress iPAddress = IPAddress.Parse(ip);
            if (iPAddress.IsIPv4MappedToIPv6)
            {
                remoteIpAddress = iPAddress.MapToIPv4().ToString();
            }
            else
            {
                remoteIpAddress = ip;
            }
        } catch {}
        

        return Ok($"{remoteIp} - {remoteIpAddress}");
    }
}