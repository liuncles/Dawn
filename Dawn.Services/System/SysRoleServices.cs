namespace Dawn.Services.System
{
    /// <summary>
    /// 角色服务
    /// </summary>
    public class SysRoleServices : ServicesBase<SysRole>, ISysRoleServices
    {
        IRepositoryBase<SysRole> _dal;
        public SysRoleServices(IRepositoryBase<SysRole> dal)
        {
            this._dal = dal;
            base._iRepositoryBase = dal;
        }

        /// <summary>
        /// 保存角色
        /// </summary>
        /// <param name="roleName"></param>
        /// <returns></returns>
        public async Task<SysRole> SaveRole(string roleName)
        {
            SysRole role = new SysRole(roleName);
            SysRole entity = new SysRole();
            var userList = await base.QueryAsync(a => a.Name == role.Name && a.Enabled);
            if (userList.Count > 0)
            {
                entity = userList.FirstOrDefault();
            }
            else
            {
                var id = await base.AddAsync(role);
                entity = await base.FindAsync(id);
            }
            return entity;
        }

        /// <summary>
        /// 根据rid获取角色名称
        /// </summary>
        /// <param name="rid"></param>
        /// <returns></returns>
        [Caching(AbsoluteExpiration = 30)]
        public async Task<string?> GetRoleNameByRid(int rid)
        {
            return (await FindAsync(rid))?.Name;
        }
    }
}
