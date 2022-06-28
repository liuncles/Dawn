namespace Dawn.IServices.System
{
    /// <summary>
    /// 用户角色
    /// 接口
    /// </summary>
    public interface ISysUserRoleServices : IServicesBase<SysUserRole>
    {
        Task<SysUserRole> SaveUserRole(int uid, int rid);
        Task<int> GetRoleIdByUid(int uid);
    }
}
