using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace SiinoCampany.Services.Interfaces
{
    public interface IHttpNativeHandler
    {
        HttpClientHandler GetHttpClientHandler();
    }
}
