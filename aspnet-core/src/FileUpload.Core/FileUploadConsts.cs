using FileUpload.Debugging;

namespace FileUpload
{
    public class FileUploadConsts
    {
        public const string LocalizationSourceName = "FileUpload";

        public const string ConnectionStringName = "Default";

        public const bool MultiTenancyEnabled = true;


        /// <summary>
        /// Default pass phrase for SimpleStringCipher decrypt/encrypt operations
        /// </summary>
        public static readonly string DefaultPassPhrase =
            DebugHelper.IsDebug ? "gsKxGZ012HLL3MI5" : "83d055c48c5e4185a5e287b71e063c03";
    }
}
