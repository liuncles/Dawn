namespace Dawn.API.Filter
{
    /// <summary>
    /// 全局响应过滤器
    /// </summary>
    public class GlobalResponseFilter : ActionFilterAttribute
    {
        [DebuggerStepThrough]
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Result != null)
            {
                if (context.Result is ObjectResult)
                {
                    ObjectResult? objectResult = context.Result as ObjectResult;
                    if (objectResult?.GetType().Name == "BadRequestObjectResult")
                    {
                        context.Result = new JsonResult(new
                        {
                            StatusCode = objectResult.StatusCode,
                            Data = new
                            {

                            },
                            Message = objectResult.Value
                        });
                    }
                    else if (objectResult?.Value?.GetType().Name == "ModelStateResult")
                    {
                        ApiResult? modelStateResult = objectResult.Value as ApiResult;
                        context.Result = new JsonResult(new
                        {
                            StatusCode = modelStateResult?.Status,
                            Data = new
                            {

                            },
                            Message = modelStateResult?.Value
                        });
                    }
                    else
                    {
                        context.Result = new JsonResult(new
                        {
                            StatusCode = 200,
                            Data = objectResult?.Value
                        });
                    }
                }
                else if (context.Result is EmptyResult)
                {
                    context.Result = new JsonResult(new
                    {
                        StatusCode = 200,
                        Data = new
                        {

                        }
                    });
                }
                else if (context.Result is ApiResult)
                {
                    ApiResult? modelStateResult2 = context.Result as ApiResult;
                    context.Result = new JsonResult(new
                    {
                        StatusCode = modelStateResult2?.Status,
                        Data = new
                        {

                        },
                        Message = modelStateResult2?.Value
                    });
                }
            }

            base.OnActionExecuted(context);
        }
    }
}
