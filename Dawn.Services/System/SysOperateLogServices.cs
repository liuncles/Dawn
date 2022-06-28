namespace Dawn.Services.System
{
    /// <summary>
    /// 操作日志服务
    /// </summary>
    public class SysOperateLogServices : ServicesBase<SysOperateLog>, ISysOperateLogServices
    {
        IRepositoryBase<SysOperateLog> _dal;
        public SysOperateLogServices(IRepositoryBase<SysOperateLog> dal)
        {
            this._dal = dal;
            base._iRepositoryBase = dal;
        }
    }
}
