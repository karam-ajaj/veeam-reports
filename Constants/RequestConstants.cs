namespace RESTfulAPIConsume.Constants
{
    
    public static class RequestConstants {

        public const string APIUrl = "http://Veeam.FQDN/api";
        public const string SessionRequestUrl = APIUrl + "/sessionMngr/";
        public const string GetReportsUrl = APIUrl + "/backupFiles?format=Entity";
        public const string path_json = @"D:\folder\downloads\report.json";
        public const string path_csv = @"D:\folder\downloads\report.csv";
        public const string path_xlsx = @"D:\folder\downloads\report.xlsx";

        public const string usernName = "administrator";
        public const string password = "password";
        // authorization header format is "username:password"
        public const string auth = usernName + ":" + password;
        public const string UserAgent = "User-Agent";
        public const string UserAgentValue = "Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/58.0.3029.110 Safari/537.36";
    }
}

