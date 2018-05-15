FROM microsoft/dotnet:2.0-sdk
COPY pub/ /root/
WORKDIR /root/
ENV ASPNETCORE_URLS="http://localhost:5000"
ENV ASPNETCORE_ENVIRONMENT Local  
EXPOSE 80/tcp
ENTRYPOINT ["dotnet", "HM.CourseManagement.Web.dll"]