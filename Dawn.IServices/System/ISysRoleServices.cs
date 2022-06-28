namespace Dawn.IServices.System
{
    /// <summary>
    /// 角色服务
    /// 接口
    /// </summary>
    public interface ISysRoleServices : IServicesBase<SysRole>
    {
        Task<SysRole> SaveRole(string roleName);
        Task<string> GetRoleNameByRid(int rid);
    }
}
