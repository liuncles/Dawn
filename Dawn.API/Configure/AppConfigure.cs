namespace Dawn.API
{
    public class AppConfigure
    {
        /// <summary>
        /// HTTP配置
        /// </summary>
        /// <param name="app"></param>
        /// <exception cref="Exception"></exception>
        public static void Configure(WebApplication? app)
        {
            if (app == null) throw new Exception("WebApplication is NUll");
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthentication(); //鉴权
            app.UseAuthorization();  //授权

            app.MapControllers();

            app.Run();
        }
    }
}
