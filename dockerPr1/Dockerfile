# Используем базовый образ с .NET SDK для сборки приложения
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build

# Устанавливаем рабочую директорию
WORKDIR /src

# Копируем файлы проекта в контейнер
COPY . .

# Восстанавливаем зависимости и собираем проект
RUN dotnet restore "dockerPr1.csproj"
RUN dotnet build "dockerPr1.csproj" -c Release -o /app/build

# Публикуем проект
FROM build AS publish
RUN dotnet publish "dockerPr1.csproj" -c Release -o /app/publish

# Используем базовый образ с .NET Runtime для запуска приложения
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime

# Устанавливаем рабочую директорию
WORKDIR /app

# Копируем собранное приложение из стадии сборки
COPY --from=publish /app/publish .

# Указываем точку входа для запуска приложения
ENTRYPOINT ["dotnet", "dockerPr1.dll"]