namespace Dawn.Repository
{
    /// <summary>
    /// 角色菜单与权限仓储实现
    /// </summary>
    public class RoleModulesAuthorizeRepository : RepositoryBase<SysRoleModulesAuthorize>, IRoleModulesAuthorizeRepository
    {
        public RoleModulesAuthorizeRepository(ISqlSugarClient context, IUnitOfWork unitOfWork) : base(context, unitOfWork)
        {
        }

        /// <summary>
        /// 查询多表数据
        /// </summary>
        /// <returns></returns>
        public async Task<List<TestMuchTableResult>> QueryManyTable()
        {
            return await QueryManyAsync<SysRoleModulesAuthorize, SysModules, SysAuthorize, TestMuchTableResult>(
                (rma, m, p) => new object[] {
                    JoinType.Left, rma.ModulesId == m.Id,
                    JoinType.Left,  rma.AuthorizeId == p.Id
                },
                (rma, m, p) => new TestMuchTableResult()
                {
                    ModulesName = m.Name,
                    AuthorizeName = p.Name,
                    Rid = rma.RoleId,
                    Mid = rma.ModulesId,
                    Aid = rma.AuthorizeId
                },
                (rma, m, p) => rma.IsDeleted == false
                );
        }

        /// <summary>
        /// 角色模块Map
        /// SysRoleModulesAuthorize, SysModules, SysRole 三表联合
        /// 第四个类型 SysRoleModulesAuthorize 是返回值
        /// </summary>
        /// <returns></returns>
        public async Task<List<SysRoleModulesAuthorize>> RoleModulesMaps()
        {
            return await QueryManyAsync<SysRoleModulesAuthorize, SysRole, SysModules, SysRoleModulesAuthorize>(
                (rma, r, m) => new object[] {
                    JoinType.Left,  rma.RoleId == r.Id,
                    JoinType.Left, rma.ModulesId == m.Id
                },
                (rma, r, m) => new SysRoleModulesAuthorize()
                {
                    Role = r,
                    Modules = m,
                    IsDeleted = rma.IsDeleted
                },
                (rma, r, m) => rma.IsDeleted == false && r.IsDeleted == false && m.IsDeleted == false
                );
        }

        /// <summary>
        /// 查询出角色-模块-权限关系表全部Map属性数据
        /// </summary>
        /// <returns></returns>
        public async Task<List<SysRoleModulesAuthorize>> GetRMAMaps()
        {
            return await base.Context.Queryable<SysRoleModulesAuthorize>()
                .Mapper(rma => rma.Role, rma => rma.RoleId)
                .Mapper(rma => rma.Modules, rma => rma.ModulesId)
                .Mapper(rma => rma.Authorize, rma => rma.AuthorizeId)
                .Where(d => d.IsDeleted == false)
                .ToListAsync();
        }

        /// <summary>
        /// 分页查询出角色-模块-权限关系表全部Map属性数据
        /// </summary>
        /// <returns></returns>
        public async Task<List<SysRoleModulesAuthorize>> GetRMAMapsPage()
        {
            return await base.Context.Queryable<SysRoleModulesAuthorize>()
                .Mapper(rma => rma.Role, rma => rma.RoleId)
                .Mapper(rma => rma.Modules, rma => rma.ModulesId)
                .Mapper(rma => rma.Authorize, rma => rma.AuthorizeId)
                .Where(d => d.IsDeleted == false)
                .ToPageListAsync(1, 5, 10);
        }

        /// <summary>
        /// 批量更新模块与授权的关系
        /// </summary>
        /// <param name="modulesId">模块主键</param>
        /// <param name="authorizeId">授权主键</param>
        /// <returns></returns>
        public async Task UpdateModulesId(int modulesId, int authorizeId)
        {
            await base.Context.Updateable<SysRoleModulesAuthorize>(it =>
                it.ModulesId == modulesId).Where(it =>
                it.AuthorizeId == authorizeId).ExecuteCommandAsync();
        }
    }
}
