namespace Dawn.IServices.System
{
    /// <summary>
    /// 用户
    /// 接口
    /// </summary>
    public interface ISysUserServices : IServicesBase<SysUser>
    {
        Task<SysUser> SaveUser(string userName, string password);
        Task<string> GetUserRoleNameStr(string userName, string password);
    }
}
