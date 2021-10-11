
namespace SC.Sekure.Helpers.ObjectsUtils.HelperObjectUtils
{
    public class AppSettings
    {
        /// <summary>
        /// Gets or sets the application identifier.
        /// </summary>
        /// <value>
        /// The application identifier.
        /// </value>
        public string AppId { get; set; }

        /// <summary>
        /// Gets or sets the application secret.
        /// </summary>
        /// <value>
        /// The application secret.
        /// </value>
        public string AppSecret { get; set; }

        /// <summary>
        /// Gets or sets the default country.
        /// </summary>
        /// <value>
        /// The default country.
        /// </value>
        public string DefaultCountry { get; set; }

        /// <summary>
        /// Service to consume for testing
        /// </summary>
        /// <value>
        /// The default country.
        /// </value>
        public string ServiceApiUrl { get; set; }

        /// <summary>
        /// Service key sekure
        /// </summary>
        public SekureService SekureService { get; set; }

    }

    public class SekureService
    {
        public string SkrKey { get; set; }

        public string UrlBase { get; set; }
    }
}
