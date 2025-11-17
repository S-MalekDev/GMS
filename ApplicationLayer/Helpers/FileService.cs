using CoreLayer.Configurations;
using CoreLayer.DTOs.PersonDTOs.PersonImage;
using CoreLayer.Entities;
using CoreLayer.Interfaces.Helpers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Helpers
{
    public class FileService : IFileService
    {
        private static readonly List<string> _allowedImageExtensions = new()
        {
            ".jpg", ".jpeg", ".png", ".gif", ".bmp", ".tiff", ".webp", ".svg", ".ico", ".heic", ".avif"
        };

        private readonly string _personImageDirectory;
        public FileService(IOptions<GeneralSettings> options)
        {
            _personImageDirectory = options.Value.PersonImageUploadDirectory?? 
                throw new InvalidOperationException("PersonImageUploadDirectory is not configured.");

            CreateDirectory(_personImageDirectory);
        }

        private void CreateDirectory(string directory)
        {
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
        }

        private string GenerateGuidFilePath(string directory, string extension)
        {
            var newImageFileName = Guid.NewGuid().ToString("N").ToLower() + extension;
            return Path.Combine(directory, newImageFileName);
        }


        public async Task<bool> SavePersonImageAsync(ImageFileDTO imageFileDTO)
        {

            if (imageFileDTO.Content == null || imageFileDTO.Content.Length == 0 
                || !_allowedImageExtensions.Contains(imageFileDTO.Extension.ToLowerInvariant()))
                return false;

            
            var imagePath = GenerateGuidFilePath(_personImageDirectory, imageFileDTO.Extension);

            using var fileStream = new FileStream(imagePath, FileMode.Create, FileAccess.Write);
            await imageFileDTO.Content.CopyToAsync(fileStream);
            imageFileDTO.SavedFilePath = imagePath;
            return true;
        }

        public async Task<bool> UpdatePersonImageAsync(ImageFileDTO imageFileDTO, string? oldImageName)
        {
            if (imageFileDTO.Content == null || imageFileDTO.Content.Length == 0
                || !_allowedImageExtensions.Contains(imageFileDTO.Extension.ToLowerInvariant()))
                return false;

            if(oldImageName != null)
            {
                await DeletePersonImageAsync(oldImageName);
            }

            return await SavePersonImageAsync(imageFileDTO);
        }

        public  Task<bool> DeletePersonImageAsync(string imageName)
        {
            if (string.IsNullOrEmpty(imageName)) return Task.FromResult(false);

            var imagePath = Path.Combine(_personImageDirectory, imageName);

            if (File.Exists(imagePath))
                File.Delete(imagePath);

            return Task.FromResult(true);
        }
    }
}
