namespace Dawn.Serilog.Es.Formatters
{
    public class LogConfigDto
    {
        /// <summary>
        /// tcp日志的host地址
        /// </summary>
        public string TcpAddressHost { set; get; }

        /// <summary>
        /// tcp日志的port地址
        /// </summary>
        public int TcpAddressPort { set; get; }

        public List<Configsinfo> ConfigsInfo { get; set; }
    }

    public class Configsinfo
    {
        public string FiedName { get; set; }

        public string FiedValue { get; set; }
    }
}