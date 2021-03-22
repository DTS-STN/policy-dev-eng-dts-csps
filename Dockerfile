FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env
WORKDIR /app 
#
# copy csproj and restore as distinct layers
COPY *.sln .
COPY pde_poc_web/*.csproj ./pde_poc_web/
COPY pde_poc_rule/*.csproj ./pde_poc_rule/
COPY pde_poc_sim/*.csproj ./pde_poc_sim/
COPY pde_poc.Tests/*.csproj ./pde_poc.Tests/ 
#
RUN dotnet restore 
#
# copy everything else and build app
COPY pde_poc_web/. ./pde_poc_web/
COPY pde_poc_rule/. ./pde_poc_rule/
COPY pde_poc_sim/. ./pde_poc_sim/ 
#
WORKDIR /app
RUN dotnet publish -c Release -o ./publish
#
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS runtime
WORKDIR /app 
#
COPY --from=build-env /app/publish .
ENTRYPOINT ["dotnet", "pde-poc-web.dll"]