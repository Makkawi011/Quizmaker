﻿using AutoMapper;

using QuizMaker.Identity;
using QuizMaker.Models;
using QuizMaker.Models.DTOs;
using QuizMaker.Requests.StudentRequests;
using QuizMaker.Requests.TeacherRequests;
using QuizMaker.Requests.UserRequests;
using QuizMaker.Responses.UserResponses;

namespace QuizMaker.Mappers;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        //student mapping
        CreateMap<StudentQuiz, Responses.StudentResponses.GetAllQuizzesResponse>()
            .ReverseMap();

        CreateMap<StudentQuiz, Responses.StudentResponses.GetQuizByIdResponse>()
            .ReverseMap();


        //teacher mapping
        CreateMap<AddQuizRequest, TeacherQuiz>()
            .ReverseMap();

        CreateMap<TeacherQuiz, Responses.TeacherResponses.GetAllQuizzesResponse>()
            .ReverseMap();

        CreateMap<TeacherQuiz, Responses.TeacherResponses.GetQuizByIdResponse>()
            .ReverseMap();

        CreateMap<UpdateQuizRequest, TeacherQuiz>()
            .ReverseMap();


        //user mapping
        CreateMap<User, UserDTO>()
            .ReverseMap();
        CreateMap<UserDTO, GetUserByIdResponse>()
            .ReverseMap();
        CreateMap<RegisterRequest, User>()
            .ForMember(dest => dest.Id , opt => opt.MapFrom(src => new Guid()));
       
        CreateMap<RegisterRequest, Student>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => new Guid()));
        
        CreateMap<RegisterRequest, Teacher>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => new Guid()));
    }
}