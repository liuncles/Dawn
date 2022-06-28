namespace Dawn.Services.System
{
    /// <summary>
    /// 模块服务
    /// </summary>
    public class SysModulesServices : ServicesBase<SysModules>, ISysModulesServices
    {
        IRepositoryBase<SysModules> _dal;
        public SysModulesServices(IRepositoryBase<SysModules> dal)
        {
            this._dal = dal;
            base._iRepositoryBase = dal;
        }
    }
}
