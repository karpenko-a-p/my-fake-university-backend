# Мой пет-проект на тему личной онлайн школы с курсами📚

## Немного о проекте
Проект представляет собой монолитный бэк на C# ASP.NET версии 8.
Старался соответствовать всем канонам чистой архитектуры, так что приложение разбито на слои.
Прописывал кастомную валидацию для данных (от FluentValidation решил отказаться, написал свою похожую реализацию).
Авторизация через JWT токен, токен сохраняется в куках.
Админский функционал для модерации курсов, студентов и т.д. отсутствует, только клиентский функционал

### Стэк:
- C# ASP.NET (8-я версия) соответственно
- EFCore для управления БД
- СУБД Postgres
- В качестве кэша Redis
- Docker