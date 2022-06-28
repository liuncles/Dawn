namespace Dawn.Entities.System
{
    /// <summary>
    /// 用户角色表
    /// </summary>
    [SugarTable("sys_user_role")]
    public class SysUserRole : UserRoleBase<int>
    {
        public SysUserRole() { }

        public SysUserRole(int uid, int rid)
        {
            UserId = uid;
            RoleId = rid;
            IsDeleted = false;
            CreatedId = uid;
            CreatedTime = DateTime.Now;
        }
    }
}
