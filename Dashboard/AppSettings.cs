namespace Dashboard
{
    public class AppSettings
    {
        public AuthSetting AuthSetting { get; set; }
        public CorsSetting CorsSetting { get; set; }

    }

    public class AuthSetting
    {
        public string SecretKey { get; set; }
        public string AccessTokenExpiresInSecconds { get; set; }
    }

    public class CorsSetting
    {
        public string AllowedHosts { get; set; }
    }


}
