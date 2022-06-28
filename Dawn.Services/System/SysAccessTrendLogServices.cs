namespace Dawn.Services.System
{
    /// <summary>
    /// 用户访问趋势日志服务
    /// </summary>
    public class SysAccessTrendLogServices : ServicesBase<SysAccessTrendLog>, ISysAccessTrendLogServices
    {
        IRepositoryBase<SysAccessTrendLog> _dal;
        public SysAccessTrendLogServices(IRepositoryBase<SysAccessTrendLog> dal)
        {
            this._dal = dal;
            base._iRepositoryBase = dal;
        }
    }
}
