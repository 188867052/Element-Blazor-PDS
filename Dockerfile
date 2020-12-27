FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
COPY . .

RUN dotnet restore "src/IssueManage.Web/IssueManage.Web.csproj"
RUN dotnet build "src/IssueManage.Web/IssueManage.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "src/IssueManage.Web/IssueManage.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "IssueManage.Web.dll"]
