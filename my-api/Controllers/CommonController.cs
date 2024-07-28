using Microsoft.AspNetCore.Mvc;
using my_api.React.User;
using System.Text.Json;

namespace my_api.Controllers
{
    [ApiController]
    [Route("api/react")]
    public class CommonController : ControllerBase
    {
        [HttpPost("{reactObject}/{type}/{operation}")]
        public async Task<ActionResult> HandleRequest(string reactObject, string type, string operation)
        {
            object? result = null;
            try
            {
                using StreamReader reader = new(Request.Body, leaveOpen: false);
                var bodyAsString = await reader.ReadToEndAsync();

                var postParams = new Dictionary<string, string>();

                if (!string.IsNullOrEmpty(bodyAsString))
                {
                    var test = JsonSerializer.Deserialize<Dictionary<string, object>>(bodyAsString);
                    foreach (var item in test)
                        postParams[item.Key] = item.Value.ToString() ?? string.Empty;
                }

                switch (reactObject)
                {
                    case "user":
                        result = UserController.HandleRequest(type, operation, postParams);
                        if (result == null)
                            throw new Exception("Error getting data");
                        break;
                    default:
                        throw new Exception("Error, invalid type");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest(ex.Message);
            }
            return Ok(result);
        }
    }
}
