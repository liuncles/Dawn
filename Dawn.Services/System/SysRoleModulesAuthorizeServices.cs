using Dawn.Repository;

namespace Dawn.Services.System
{
    /// <summary>
    /// 角色模块与授权服务
    /// </summary>
    public class SysRoleModulesAuthorizeServices : ServicesBase<SysRoleModulesAuthorize>, ISysRoleModulesAuthorizeServices
    {
        readonly IRoleModulesAuthorizeRepository _dal;
        readonly IRepositoryBase<SysRole> _roleRepository;
        readonly IRepositoryBase<SysModules> _modulesRepository;

        // 将多个仓储接口注入
        public SysRoleModulesAuthorizeServices(
            IRoleModulesAuthorizeRepository dal,
            IRepositoryBase<SysRole> roleRepository,
            IRepositoryBase<SysModules> modulesRepository)
        {
            this._dal = dal;
            this._roleRepository = roleRepository;
            this._modulesRepository = modulesRepository;
            base._iRepositoryBase = dal;
        }

        /// <summary>
        /// 查询多表数据
        /// </summary>
        /// <returns></returns>
        public async Task<List<TestMuchTableResult>> QueryManyTable()
        {
            return await _dal.QueryManyTable();
        }

        /// <summary>
        /// 获取全部 角色模块(按钮)关系数据
        /// </summary>
        /// <returns></returns>
        [Caching(AbsoluteExpiration = 10)]
        public async Task<List<SysRoleModulesAuthorize>> GetRoleModules()
        {
            var roleModulesAuthorize = await base.QueryAsync(a => a.IsDeleted == false);
            var roles = await _roleRepository.QueryAsync(a => a.IsDeleted == false);
            var modules = await _modulesRepository.QueryAsync(a => a.IsDeleted == false);

            if (roleModulesAuthorize.Count > 0)
            {
                foreach (var item in roleModulesAuthorize)
                {
                    item.Role = roles.FirstOrDefault(d => d.Id == item.RoleId);
                    item.Modules = modules.FirstOrDefault(d => d.Id == item.ModulesId);
                }
            }
            return roleModulesAuthorize;
        }

        /// <summary>
        /// 角色模块map
        /// </summary>
        /// <returns></returns>
        public async Task<List<SysRoleModulesAuthorize>> RoleModulesMaps()
        {
            return await _dal.RoleModulesMaps();
        }

        /// <summary>
        /// 查询出角色-模块-授权关系表全部Map属性数据
        /// </summary>
        /// <returns></returns>
        public async Task<List<SysRoleModulesAuthorize>> GetRMAMaps()
        {
            return await _dal.GetRMAMaps();
        }

        /// <summary>
        /// 批量更新模块与授权的关系
        /// </summary>
        /// <param name="modulesId">模块主键</param>
        /// <param name="authorizeId">授权主键</param>
        /// <returns></returns>
        public async Task UpdateModulesId(int modulesId, int authorizeId)
        {
            await _dal.UpdateModulesId(modulesId, authorizeId);
        }
    }
}
