namespace Dawn.Services.System
{
    /// <summary>
    /// 授权服务
    /// </summary>
    public class SysAuthorizeServices : ServicesBase<SysAuthorize>, ISysAuthorizeServices
    {
        IRepositoryBase<SysAuthorize> _dal;
        public SysAuthorizeServices(IRepositoryBase<SysAuthorize> dal)
        {
            this._dal = dal;
            base._iRepositoryBase = dal;
        }
    }
}
