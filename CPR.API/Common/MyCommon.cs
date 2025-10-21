using CPR.API.Models;

namespace CPR.API.Common
{
    public class MyCommon
    {
        public static List<ApiKeyModel> GetApiKeys()
        {
            return
            [
                new ApiKeyModel("dev", "1779d06f-6713-47ad-8ab7-c5900f729f58")
            ];
        }
    }
}