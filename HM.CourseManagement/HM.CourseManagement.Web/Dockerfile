#FROM microsoft/dotnet:2.0-sdk
#COPY pub/ /root/
#WORKDIR /root/
#ENV ASPNETCORE_URLS="http://localhost:5000"
#ENV ASPNETCORE_ENVIRONMENT Local  
#EXPOSE 80/tcp
#ENTRYPOINT ["dotnet", "HM.CourseManagement.Web.dll"]

FROM microsoft/aspnetcore-build:2.0 AS build-env
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY *.csproj ./
RUN dotnet restore

# Copy everything else and build
COPY . ./
RUN dotnet publish -c Release -o out

# Build runtime image
FROM microsoft/aspnetcore:2.0
WORKDIR /app
ENV ASPNETCORE_ENVIRONMENT Local  
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "HM.CourseManagement.Web.dll"]