using AutoMapper;
using Buku.API.Models;
using Buku.BussinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Buku.API.Mappings
{
    public class BukuAPIMapper : Profile
    {
        protected override void Configure()
        {
            // BO to API
            CreateMap<Author, AuthorResponse>()
                .ForMember(dest => dest.Id , opt => opt.MapFrom(src => src.Id));
            CreateMap<Book, BookResponse>()
                .ForMember(dest => dest.AuthorResponse, opt => opt.MapFrom(src => src.Author))
                .ForMember(dest => dest.StudentResponse, opt => opt.MapFrom(src => src.Student));
            CreateMap<Student, StudentResponse>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));
            CreateMap<Book, BookRequest>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));

            // API to BO
            CreateMap<BookResponse, Book>()
                .ForMember(dest => dest.Author, opt => opt.Ignore())
                .ForMember(dest => dest.Student, opt => opt.Ignore())
                .ForMember(dest => dest.AuthorId, opt => opt.Ignore())
                .ForMember(dest => dest.StudentId, opt => opt.Ignore())
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));
            CreateMap<AuthorResponse, Author>()
                .ForMember(dest => dest.LastName, opt => opt.Ignore())
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));
            CreateMap<StudentResponse, Student>()
                .ForMember(dest => dest.LastName, opt => opt.Ignore())
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));
            CreateMap<BookRequest, Book>()
                .ForMember(dest => dest.Author, opt => opt.Ignore())
                .ForMember(dest => dest.Student, opt => opt.Ignore())
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));
        }

    }
}
