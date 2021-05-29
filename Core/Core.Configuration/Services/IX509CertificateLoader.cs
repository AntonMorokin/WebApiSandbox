using System;
using System.Security.Cryptography.X509Certificates;

namespace Core.Configuration.Services
{
    public interface IX509CertificateLoader
    {
        Lazy<X509Certificate2> CertificateForJwtProcessing { get; }
    }
}