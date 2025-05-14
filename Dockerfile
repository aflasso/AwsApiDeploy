FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /MoneyBankService

COPY ./MoneyBankService/*.sln ./
COPY ./MoneyBankService/MoneyBankService.Api/*.csproj ./MoneyBankService.Api/
COPY ./MoneyBankService/MoneyBankService.Application/*.csproj ./MoneyBankService.Application/
COPY ./MoneyBankService/MoneyBankService.Domain/*.csproj ./MoneyBankService.Domain/
COPY ./MoneyBankService/MoneyBankService.Infrastructure/*.csproj ./MoneyBankService.Infrastructure/
RUN dotnet restore 

COPY ./MoneyBankService/. .
WORKDIR /MoneyBankService/MoneyBankService.Api
RUN dotnet publish -c release -o /app

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app ./
ENTRYPOINT ["dotnet", "MoneyBankService.Api.dll"]