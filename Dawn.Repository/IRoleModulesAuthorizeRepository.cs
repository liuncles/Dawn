namespace Dawn.Repository
{
    /// <summary>
    /// 角色模块与授权仓储接口
    /// </summary>
    public interface IRoleModulesAuthorizeRepository : IRepositoryBase<SysRoleModulesAuthorize>//类名
    {
        Task<List<TestMuchTableResult>> QueryManyTable();
        Task<List<SysRoleModulesAuthorize>> RoleModulesMaps();
        Task<List<SysRoleModulesAuthorize>> GetRMAMaps();

        /// <summary>
        /// 批量更新模块与授权的关系
        /// </summary>
        /// <param name="modulesId">模块主键</param>
        /// <param name="authorizeId">授权主键</param>
        /// <returns></returns>
        Task UpdateModulesId(int modulesId, int authorizeId);
    }
}
