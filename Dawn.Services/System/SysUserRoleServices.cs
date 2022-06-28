namespace Dawn.Services.System
{
    /// <summary>
    /// 用户角色服务
    /// </summary>
    public class SysUserRoleServices : ServicesBase<SysUserRole>, ISysUserRoleServices
    {
        IRepositoryBase<SysUserRole> _dal;
        public SysUserRoleServices(IRepositoryBase<SysUserRole> dal)
        {
            this._dal = dal;
            base._iRepositoryBase = dal;
        }

        /// <summary>
        /// 保存用户角色
        /// </summary>
        /// <param name="uid"></param>
        /// <param name="rid"></param>
        /// <returns></returns>
        public async Task<SysUserRole> SaveUserRole(int uid, int rid)
        {
            SysUserRole userRole = new SysUserRole(uid, rid);

            SysUserRole entity = new SysUserRole();
            var userList = await base.QueryAsync(a => a.UserId == userRole.UserId && a.RoleId == userRole.RoleId);
            if (userList.Count > 0)
            {
                entity = userList.FirstOrDefault();
            }
            else
            {
                var id = await base.AddAsync(userRole);
                entity = await base.FindAsync(id);
            }
            return entity;
        }

        /// <summary>
        /// 根据uid获取角色Id
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        [Caching(AbsoluteExpiration = 30)]
        public async Task<int> GetRoleIdByUid(int uid)
        {
            return ((await QueryAsync(d => d.UserId == uid)).OrderByDescending(d => d.Id).LastOrDefault()?.RoleId).ObjToInt();
        }
    }
}
