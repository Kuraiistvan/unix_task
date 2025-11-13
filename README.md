sadly i didnt have time for setup the authguard and for the validation of orders (POST). I am sorry for that.

VSC extensions:
- SQL server
- C#
- C# dev kit
- Docker
- .NET Install tool
- Container tools
- NuGet Gallery
- Data workspace
- Angular Language Service
- TailwindCSS IntelliSense

Requirements:
- .NET 9.0.10
- Angular 20
- Tailwind CSS
- Docker
- MSSQL server
- Postman
- Node.Js (I was using version 22.14)

Installing:
1. dotnet tool install --global dotnet-ef --version 9.0.10
2. npm install -g @angular/cli@20 (if it needs)
3. npm install tailwindcss @tailwindcss/postcss (in the client folder)
4. npm install nanoid
5. choco install mkcert
6. dotnet ef database update -s API -p Infrastructure
7. dotnet run (in the API folder)
8. ng serve (in the client folder)

Login:
 username: test
 password: 1234
