using CoreLayer.DTOs.PersonDTOs.PersonImage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Interfaces.Helpers
{

    public interface IFileService
    {
        Task<bool> SavePersonImageAsync(ImageFileDTO imageFileDTO);
        Task<bool> UpdatePersonImageAsync(ImageFileDTO imageFileDTO, string? oldImageName);
        Task<bool> DeletePersonImageAsync(string ImageName);
    }
}
