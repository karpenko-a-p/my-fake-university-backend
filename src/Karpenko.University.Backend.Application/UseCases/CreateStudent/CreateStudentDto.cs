﻿namespace Karpenko.University.Backend.Application.UseCases.CreateStudent;

/// <summary>
/// Данные для создания новой записи аккаунта студента в БД 
/// </summary>
/// <param name="Name">Имя</param>
/// <param name="Email">Почта</param>
/// <param name="HashedPassword">Хэшированный пароль</param>
public sealed record CreateStudentDto(
  string Name,
  string Email,
  string HashedPassword);