FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY SendGridSample/SendGridSample.csproj SendGridSample/
RUN dotnet restore SendGridSample/SendGridSample.csproj
COPY . .
WORKDIR /src/SendGridSample
RUN dotnet build SendGridSample.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish SendGridSample.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "SendGridSample.dll"]
