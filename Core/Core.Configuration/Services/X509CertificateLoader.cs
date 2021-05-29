using Core.Configuration.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Security.Cryptography.X509Certificates;
using System.Threading;

namespace Core.Configuration.Services
{
    public sealed class X509CertificateLoader : IX509CertificateLoader
    {
        private IOptionsSnapshot<JwtProcessingOptions> _options;

        public Lazy<X509Certificate2> CertificateForJwtProcessing { get; }

        public X509CertificateLoader(IOptionsSnapshot<JwtProcessingOptions> options)
        {
            _options = options;

            CertificateForJwtProcessing = new Lazy<X509Certificate2>(
                LoadForJwtProcessing,
                LazyThreadSafetyMode.ExecutionAndPublication);
        }

        private X509Certificate2 LoadForJwtProcessing()
        {
            return LoadForJwtProcessingInternal(_options.Value.X509CertificateName);
        }

        private static X509Certificate2 LoadForJwtProcessingInternal(string certFriendlyName)
        {
            var store = new X509Store(StoreName.My,
                            StoreLocation.CurrentUser,
                            OpenFlags.OpenExistingOnly | OpenFlags.ReadOnly);

            using (store)
            {
                // The FriendlyName field is not constant field. So the built-in search doesn't work for it.
                // I guess approach below will be ok for this project.
                foreach (var cert in store.Certificates)
                {
                    if (cert.FriendlyName == certFriendlyName)
                    {
                        return cert;
                    }
                }

                // It would be better to throw ConfigurationException.
                // But it requires to install a special NuGet package.
                throw new InvalidOperationException("Cannot find a X.509 certificate for work with JWT.");
            }
        }

        public static X509Certificate2 LoadCertificateForJwtProcessing(IConfiguration configuration)
        {
            var certName = configuration.GetValue<string>("Jwt:X509CertificateName");
            return LoadForJwtProcessingInternal(certName);
        }
    }
}
