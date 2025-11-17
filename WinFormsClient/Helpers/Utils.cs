using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsClient.DTOs.PersonDTOs;

namespace WinFormsClient.Helpers
{
    public static class Utils
    {
        public static T GetEmptyOrDefault<T>()
        {
            if (typeof(T) == typeof(string))
            {
                return (T)(object)string.Empty!;
            }
            else if (typeof(System.Collections.IEnumerable).IsAssignableFrom(typeof(T)))
            {
               
                try
                {
                    return Activator.CreateInstance<T>()!;
                }
                catch
                {
                    return default!;
                }
            }
            else
            {
                return default!;
            }
        }

        public static string GetImageMimeType(string filePath)
        {
            var extension = Path.GetExtension(filePath).ToLowerInvariant();

            return extension switch
            {
                ".jpg" or ".jpeg" => "image/jpeg",
                ".png" => "image/png",
                ".gif" => "image/gif",
                ".bmp" => "image/bmp",
                ".tif" or ".tiff" => "image/tiff",
                ".webp" => "image/webp",
                ".ico" => "image/x-icon",
                ".heic" => "image/heic",
                ".heif" => "image/heif",
                ".svg" => "image/svg+xml",
                ".jfif" => "image/jpeg",
                ".pjpeg" => "image/pjpeg",
                ".pjp" => "image/jpeg",

                // fallback if unknown extension
                _ => "application/octet-stream"
            };
        }   
    }
}
