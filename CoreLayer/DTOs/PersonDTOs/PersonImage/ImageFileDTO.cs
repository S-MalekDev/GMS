

namespace CoreLayer.DTOs.PersonDTOs.PersonImage
{
    public class ImageFileDTO
    {
        public string FileName { get; set; }
        public string Extension => Path.GetExtension(FileName);
        public string SavedFilePath { get; set; }
        public Stream Content {  get; set; }
        public ImageFileDTO(Stream content, string fileName)
        {
            Content = content;
            FileName = fileName;
            SavedFilePath = "";
        }
    }
}
