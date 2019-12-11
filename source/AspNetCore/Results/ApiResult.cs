using DotNetCore.Objects;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DotNetCore.AspNetCore
{
    public class ApiResult : IActionResult
    {
        private readonly IResult _result;

        private ApiResult(IResult result)
        {
            _result = result;
        }

        private ApiResult(object data)
        {
            _result = DataResult<object>.Success(data);
        }

        public static IActionResult Create(IResult result)
        {
            return new ApiResult(result);
        }

        public static IActionResult Create(object data)
        {
            return new ApiResult(data);
        }

        public async Task ExecuteResultAsync(ActionContext context)
        {
            object value = default;

            if (_result.Failed)
            {
                value = _result.Message;
            }
            else if (_result.GetType().GetGenericTypeDefinition() == typeof(DataResult<>))
            {
                value = ((dynamic)_result).Data;
            }

            var objectResult = new ObjectResult(value)
            {
                StatusCode = _result.Succeeded ? StatusCodes.Status200OK : StatusCodes.Status422UnprocessableEntity
            };

            await objectResult.ExecuteResultAsync(context);
        }
    }
}
