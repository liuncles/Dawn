namespace Dawn.API.Filter
{
    /// <summary>
    /// 全局模型状态验证过滤器
    /// </summary>
    public class GlobalModelStateValidationFilter : ActionFilterAttribute
    {

        //[DebuggerStepThrough]
        //public override void OnActionExecuting(ActionExecutingContext context)
        //{
        //    if (context.ModelState.IsValid)
        //    {
        //        return;
        //    }

        //    ApiResult modelStateResult = new ApiResult();
        //    foreach (ModelStateEntry value in context.ModelState.Values)
        //    {
        //        foreach (ModelError error in value.Errors)
        //        {
        //            modelStateResult.Message = modelStateResult.Message + error.ErrorMessage + "|";
        //        }
        //    }
        //    context.Result = new ObjectResult(modelStateResult);
        //}
    }
}
