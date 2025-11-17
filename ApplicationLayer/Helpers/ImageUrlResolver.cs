using AutoMapper;
using CoreLayer.DTOs.PersonDTOs;
using CoreLayer.Entities;
using CoreLayer.Interfaces.Helpers;
using System.Reflection.Metadata.Ecma335;


namespace ApplicationLayer.Helpers
{
    public class ImageUrlResolver : IValueResolver<Person, PersonDTO, string?>
    {
        private readonly IUrlBuilder _urlBuilder;
        public ImageUrlResolver(IUrlBuilder urlBuilder)
        {
            _urlBuilder = urlBuilder;
        }
        public string? Resolve(Person source, PersonDTO destination, string? destMember, ResolutionContext context)
        {
            return source.ImageName == null? null : _urlBuilder.BuildImageUrl(source.ImageName);
        }
    }
}
