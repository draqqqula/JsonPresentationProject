using JsonApplication.Controllers.Dto;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using System.Text.Json;

namespace JsonApplication.Controllers
{
    [ApiController]
    [Route("json-test")]
    public class MainController : Controller
    {
        [JsonOnlyFilter]
        [HttpPost("test-max-number")]
        public async Task<IActionResult> TestMaxNumber(TestDto dto)
        {
            return Ok(dto);
        }

        [JsonOnlyFilter]
        [HttpPost("test-json-array")]
        public async Task<IActionResult> TestJsonArray(ArrayDto dto)
        {
            return Ok(dto);
        }

        [JsonOnlyFilter]
        [HttpPost("test-json-array-only")]
        public async Task<IActionResult> TestJsonArrayNoObject(int[] dto)
        {
            return Ok(dto);
        }

        [JsonOnlyFilter]
        [HttpPost("test-json-number-only")]
        public async Task<IActionResult> TestJsonNumberOnly([FromBody]int num)
        {
            return Ok(num);
        }

        [JsonOnlyFilter]
        [HttpPost("test-json-string-only")]
        public async Task<IActionResult> TestJsonStringOnly([FromBody] string line)
        {
            return Ok(line);
        }

        [JsonOnlyFilter]
        [HttpPost("test-no-json-number-only")]
        public async Task<IActionResult> TestNoJsonNumberOnly(int num)
        {
            return Ok(num);
        }

        /// <summary>
        /// <list>
        /// <item>если это массив - возвращает последний элемент,</item>
        /// <item>если это объект - возвращает название последнего поля</item>
        /// <item>если это что-то другое - название типа</item>
        /// </list>
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        [JsonOnlyFilter]
        [HttpPost("test-json-element")]
        public async Task<IActionResult> TestJsonElement(JsonElement json)
        {
            switch (json.ValueKind)
            {
                case JsonValueKind.Array:
                    return new OkObjectResult(json.EnumerateArray().Last());
                case JsonValueKind.Object:
                    return new OkObjectResult(json.EnumerateObject().Last().Name);
                default:
                    return new OkObjectResult(json.ValueKind.ToString());
            }
        }
    }
}
