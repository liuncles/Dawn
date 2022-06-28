namespace Dawn.Entities.System
{
    /// <summary>
    /// 角色模块与授权关系表
    /// </summary>
    [SugarTable("sys_role_modules_authorize")]
    public class SysRoleModulesAuthorize : RoleModulesAuthorizeBase<int>
    {
        public SysRoleModulesAuthorize() { }

        // 下边三个实体参数，只是做传参作用，所以忽略下
        [SugarColumn(IsIgnore = true)]
        public SysRole Role { get; set; }

        [SugarColumn(IsIgnore = true)]
        public SysModules Modules { get; set; }

        [SugarColumn(IsIgnore = true)]
        public SysAuthorize Authorize { get; set; }
    }
}
