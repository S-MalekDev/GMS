using CoreLayer.Configurations;
using CoreLayer.Interfaces.Helpers;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Helpers
{
    public class UrlBuilder : IUrlBuilder
    {

        private readonly string _baseUrl;

        public UrlBuilder(IOptions<GeneralSettings> options)
        {
            _baseUrl = options.Value.BaseUrl;
        }

        public string? BuildImageUrl(string? imageName)
        {
            if (string.IsNullOrWhiteSpace(imageName))
                return null;

            return $"{_baseUrl}images/{imageName}";
        }
    }
}
