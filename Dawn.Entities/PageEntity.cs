using AutoMapper;

namespace Dawn.Entities
{
    /// <summary>
    /// 通用分页信息类
    /// </summary>
    public class PageEntity<T>
    {
        /// <summary>
        /// 当前页标
        /// </summary>
        public int page { get; set; } = 1;

        /// <summary>
        /// 总页数
        /// </summary>
        public int pageCount => (int)Math.Ceiling((decimal)dataCount / PageSize);

        /// <summary>
        /// 数据总数
        /// </summary>
        public int dataCount { get; set; } = 0;

        /// <summary>
        /// 每页大小
        /// </summary>
        public int PageSize { set; get; } = 20;

        /// <summary>
        /// 返回数据
        /// </summary>
        public List<T> data { get; set; }

        public PageEntity() { }

        public PageEntity(int page, int dataCount, int pageSize, List<T> data)
        {
            this.page = page;
            this.dataCount = dataCount;
            PageSize = pageSize;
            this.data = data;
        }

        public PageEntity<TOut> ConvertTo<TOut>()
        {
            return new PageEntity<TOut>(page, dataCount, PageSize, default);
        }

        public PageEntity<TOut> ConvertTo<TOut>(IMapper mapper)
        {
            var entity = ConvertTo<TOut>();

            if (data != null)
            {
                entity.data = mapper.Map<List<TOut>>(data);
            }
            return entity;
        }

        public PageEntity<TOut> ConvertTo<TOut>(IMapper mapper, Action<IMappingOperationOptions> options)
        {
            var entity = ConvertTo<TOut>();
            if (data != null)
            {
                entity.data = mapper.Map<List<TOut>>(data, options);
            }
            return entity;
        }
    }
}
