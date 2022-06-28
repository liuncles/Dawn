namespace Dawn.API.Filter
{
    /// <summary>
    /// 全局异常过滤器
    /// </summary>
    public class GlobalExceptionsFilter : ExceptionFilterAttribute
    {
        private readonly IWebHostEnvironment _env;

        private readonly ILogger<GlobalExceptionsFilter> _logger;

        public GlobalExceptionsFilter(IWebHostEnvironment env, ILogger<GlobalExceptionsFilter> logger)
        {
            _env = env;
            _logger = logger;
        }

        //[DebuggerStepThrough]
        //public override void OnException(ExceptionContext context)
        //{
        //    if (context.ExceptionHandled == false)
        //    {
        //        ApiResult response = new ApiResult
        //        {
        //            Status = 500,
        //            Value = context.Exception.Message
        //        };
        //        _logger.LogError(context.HttpContext.Request.Path, context.Exception, context.HttpContext.Request.Body);
        //        context.Result = new ContentResult
        //        {
        //            Content = JsonConvert.SerializeObject(response),
        //            StatusCode = 500,
        //            ContentType = "application/json;charset=utf-8"
        //        };
        //    }
        //    context.ExceptionHandled = true;
        //}
    }
}
