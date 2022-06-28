using Dawn.Entities;

namespace Dawn.Commons.DB
{
    public class ApiResult
    {
        public int Status { get; set; } = 200;
        public string Value { get; set; } = "";
        public MsgEntity<string> MsgEntity = new MsgEntity<string>() { };

        public ApiResult(StatusCode apiCode, string msg = null)
        {
            switch (apiCode)
            {
                case StatusCode.CODE401:
                    {
                        Status = 401;
                        Value = "很抱歉，您无权访问该接口，请确保已经登录!";
                    }
                    break;
                case StatusCode.CODE403:
                    {
                        Status = 403;
                        Value = "很抱歉，您的访问权限等级不够，联系管理员!";
                    }
                    break;
                case StatusCode.CODE404:
                    {
                        Status = 404;
                        Value = "资源不存在!";
                    }
                    break;
                case StatusCode.CODE500:
                    {
                        Status = 500;
                        Value = msg;
                    }
                    break;
            }

            MsgEntity = new MsgEntity<string>()
            {
                status = Status,
                msg = Value,
                success = apiCode != StatusCode.CODE200
            };
        }
    }

    public enum StatusCode
    {
        CODE200,
        CODE401,
        CODE403,
        CODE404,
        CODE500
    }
}