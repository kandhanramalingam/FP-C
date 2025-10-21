namespace CPR.API.Models
{
    public class ApiKeyModel
    {
        public ApiKeyModel()
        {
            
        }

        public ApiKeyModel(string user, string accesskey)
        {
            User = user;
            Accesskey = accesskey;
        }

        public string User { get; set; } = string.Empty;
        public string Accesskey { get; set; } = string.Empty;
    }
}
