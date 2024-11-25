﻿using CreateStudent = Karpenko.University.Backend.Application.UseCases.CreateStudent;
using GenerateJwtToken = Karpenko.University.Backend.Application.UseCases.GenerateJwtToken;
using GetStudentByEmail = Karpenko.University.Backend.Application.UseCases.GetStudentByEmail;
using VerifyStudentPassword = Karpenko.University.Backend.Application.UseCases.VerifyStudentPassword;
using AddAccess = Karpenko.University.Backend.Application.UseCases.AddAccess;
using GetStudentById = Karpenko.University.Backend.Application.UseCases.GetStudentById;
using CheckAccess = Karpenko.University.Backend.Application.UseCases.CheckAccess;
using DeleteStudentById = Karpenko.University.Backend.Application.UseCases.DeleteStudentById;
using GetCourses = Karpenko.University.Backend.Application.UseCases.GetCourses;
using GetCourseById = Karpenko.University.Backend.Application.UseCases.GetCourseById;
using GetCoursesTags = Karpenko.University.Backend.Application.UseCases.GetCoursesTags;
using GetTagsByCourseId = Karpenko.University.Backend.Application.UseCases.GetTagsByCourseId;
using GetCoursesByTagId = Karpenko.University.Backend.Application.UseCases.GetCoursesByTagId;
using CreateComment = Karpenko.University.Backend.Application.UseCases.CreateComment;
using DeleteCommentById = Karpenko.University.Backend.Application.UseCases.DeleteCommentById;
using GetCommentsByAuthorId = Karpenko.University.Backend.Application.UseCases.GetCommentsByAuthorId;
using GetCommentsByCourseId = Karpenko.University.Backend.Application.UseCases.GetCommentsByCourseId;
using GetOrderById = Karpenko.University.Backend.Application.UseCases.GetOrderById;
using CreateOrder = Karpenko.University.Backend.Application.UseCases.CreateOrder;
using DeleteOrderById = Karpenko.University.Backend.Application.UseCases.DeleteOrderById;
using PayOrderById = Karpenko.University.Backend.Application.UseCases.PayOrderById;
using GetOrdersByOwnerId = Karpenko.University.Backend.Application.UseCases.GetOrdersByOwnerId;
using GetCourseVideo = Karpenko.University.Backend.Application.UseCases.GetCourseVideo;
using Microsoft.Extensions.DependencyInjection;

namespace Karpenko.University.Backend.Application;

/// <summary>
/// Внедрение слоя Application
/// </summary>
public static class DependencyInjection {
  /// <summary>
  /// Метод для добавления слоя к списку сервисов
  /// </summary>
  public static IServiceCollection AddApplication(this IServiceCollection services) {
    // Сценарии использования
    services.AddTransient<CreateStudent.UseCase>();
    services.AddTransient<GenerateJwtToken.UseCase>();
    services.AddTransient<VerifyStudentPassword.UseCase>();
    services.AddTransient<GetStudentByEmail.UseCase>();
    services.AddTransient<GetStudentById.UseCase>();
    services.AddTransient<DeleteStudentById.UseCase>();
    services.AddTransient<CheckAccess.UseCase>();
    services.AddTransient<AddAccess.UseCase>();
    services.AddTransient<GetCourses.UseCase>();
    services.AddTransient<GetCourseById.UseCase>();
    services.AddTransient<GetCoursesTags.UseCase>();
    services.AddTransient<GetTagsByCourseId.UseCase>();
    services.AddTransient<GetCoursesByTagId.UseCase>();
    services.AddTransient<CreateComment.UseCase>();
    services.AddTransient<DeleteCommentById.UseCase>();
    services.AddTransient<GetCommentsByAuthorId.UseCase>();
    services.AddTransient<GetCommentsByCourseId.UseCase>();
    services.AddTransient<CreateOrder.UseCase>();
    services.AddTransient<GetOrderById.UseCase>();
    services.AddTransient<DeleteOrderById.UseCase>();
    services.AddTransient<PayOrderById.UseCase>();
    services.AddTransient<GetOrdersByOwnerId.UseCase>();
    services.AddTransient<GetCourseVideo.UseCase>();

    return services;
  }
}
