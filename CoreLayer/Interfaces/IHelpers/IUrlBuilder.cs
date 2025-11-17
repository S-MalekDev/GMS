using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Interfaces.Helpers
{
    public interface IUrlBuilder
    {
        string? BuildImageUrl(string? imageName);
    }
}
