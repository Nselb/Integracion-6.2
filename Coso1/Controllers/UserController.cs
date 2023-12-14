using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Coso1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        // GET: api/<UserController>
        [HttpGet]
        public async Task<IEnumerable<User>> Get()
        {
            HttpClient client = new ();

            HttpResponseMessage response = await client.GetAsync("https://jsonplaceholder.typicode.com/users");

            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                List<User>? users = JsonConvert.DeserializeObject<List<User>>(json);
                if (users != null)
                {
                    return users;
                }
            }
            return new List<User> ();
        }
    }
}
