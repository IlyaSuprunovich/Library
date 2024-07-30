# Library Web-Api
Этот репозиторий содержит Library Web-Api. Он разработан на .NET 7 и для его работы требуются следующие предварительные настройки:

1) .NET 7: Library Web-Api написан на ASP.NET Core Web-Api.
2) MySQL Workbench 8.0 CE: Library Web-Api использует MySQL базу данных. 
3) Vite: Для работы с фронтендом веб-приложения Library требуется установить Vite.
# Начало работы
Для запуска Library Web-Api и связанного веб-приложения выполните следующие шаги:

1) Необходимо указать желаемый пути к базам данных в appsettings.json. 
2) Выполните миграции данных для IdentityServer и Library:

    - **Для IdentityServer**:
    
      Перейдите в директорию, где находится проект `IdentityServer.Persistence`, например:
      ```sh
      cd D:\Disk\Library\IdentityServer.Persistence
      ```
      Выполните команду для создания миграции:
      ```sh
      dotnet ef migrations add Migrations
      ```
      Затем примените миграции:
      ```sh
      dotnet ef database update
      ```

    - **Для Library** тоже самое, но с путем в директорию где находится проект `Library.Persistence` 
    
3) Далее необходимо запустить сначала IdentityServer, далее Library Web-Api и только потом front-end. 

Теперь вы можете получить доступ к веб-приложению Library и взаимодействовать с ним.
