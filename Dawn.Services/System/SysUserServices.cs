namespace Dawn.Services.System
{
    /// <summary>
    /// 用户服务
    /// </summary>
    public class SysUserServices : ServicesBase<SysUser>, ISysUserServices
    {
        private readonly IRepositoryBase<SysUser> _dal;
        private readonly IRepositoryBase<SysUserRole> _userRoleRepository;
        private readonly IRepositoryBase<SysRole> _roleRepository;
        public SysUserServices(IRepositoryBase<SysUser> dal, IRepositoryBase<SysUserRole> userRoleRepository, IRepositoryBase<SysRole> roleRepository)
        {
            this._dal = dal;
            _userRoleRepository = userRoleRepository;
            _roleRepository = roleRepository;
            base._iRepositoryBase = dal;
        }

        /// <summary>
        /// 保存用户
        /// </summary>
        /// <param name="loginName"></param>
        /// <param name="loginPwd"></param>
        /// <returns></returns>
        public async Task<SysUser> SaveUser(string userName, string password)
        {
            SysUser sysUser = new SysUser(userName, password);
            SysUser entity = new SysUser();
            var userList = await base.QueryAsync(a => a.UserName == sysUser.UserName && a.Password == sysUser.Password && a.UserNick == sysUser.UserNick);
            if (userList.Count > 0)
            {
                entity = userList.FirstOrDefault();
            }
            else
            {
                var id = await base.AddAsync(sysUser);
                entity = await base.FindAsync(id);
            }
            return entity;
        }

        /// <summary>
        /// 获取用户角色名称
        /// </summary>
        /// <param name="loginName"></param>
        /// <param name="loginPwd"></param>
        /// <returns></returns>
        public async Task<string> GetUserRoleNameStr(string userName, string password)
        {
            string roleName = "";
            var user = (await base.QueryAsync(a => a.UserName == userName && a.Password == password)).FirstOrDefault();
            var roleList = await _roleRepository.QueryAsync(a => a.IsDeleted == false);
            if (user != null)
            {
                var userRoles = await _userRoleRepository.QueryAsync(ur => ur.UserId == user.Id);
                if (userRoles.Count > 0)
                {
                    var arr = userRoles.Select(ur => ur.RoleId.ObjToString()).ToList();
                    var roles = roleList.Where(d => arr.Contains(d.Id.ObjToString()));

                    roleName = string.Join(',', roles.Select(r => r.Name).ToArray());
                }
            }
            return roleName;
        }
    }
}
