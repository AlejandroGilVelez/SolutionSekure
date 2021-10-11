using System;

namespace SC.Sekure.Helpers.ObjectsUtils.HelperObjectUtils
{
    public static class EnvironmentHelper
    {
        /// <summary>
        /// GetCountryOrDefault
        /// </summary>
        /// <param name="defaultCountry"></param>
        /// <returns></returns>
        public static string GetCountryOrDefault(string defaultCountry)
        {
            const string CREDINET_COUNTRY = "CREDINET_COUNTRY";
            string country = GetVariable(CREDINET_COUNTRY);

            return string.IsNullOrEmpty(country) ? defaultCountry : country;
        }

        /// <summary>
        /// GetSubDomainOrDefault
        /// </summary>
        /// <param name="defaultSubDomain"></param>
        /// <returns></returns>
        public static string GetSubDomainOrDefault(string defaultSubDomain)
        {
            const string CREDINET_SUBDOMAIN = "CREDINET_SUBDOMAIN";
            string subDomain = GetVariable(CREDINET_SUBDOMAIN);

            return string.IsNullOrEmpty(subDomain) ? defaultSubDomain : subDomain;
        }

        /// <summary>
        /// GetVariable
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        private static string GetVariable(string name)
        {
            return Environment.GetEnvironmentVariable(name);
        }
    }
}
