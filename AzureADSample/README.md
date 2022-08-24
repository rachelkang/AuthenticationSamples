---
name: .NET MAUI - Simple Azure AD Authentication Sample
description: "This sample only demostrates Authentication with using Azure AD (Microsoft Login Only)"
page_type: sample
languages: 
- csharp
- xaml
products:
- dotnet-maui 
- dotnet-core
urlFragment: authentication-AD
---

<h1 align="center">Simple Azure AD Authentication Sample</h1>

<div align="center">
Built in .NET MAUI and used Azure AD for Auth Service. This sample only demonstrates Authentication using the [Azure Active Directory](https://docs.microsoft.com/en-us/azure/active-directory/fundamentals/active-directory-whatis) and the [Microsoft Authentication Library](https://docs.microsoft.com/en-us/azure/active-directory/develop/msal-overview (MSAL for Microsoft Login Only) </br>
This sample currently works for Windows and Android</br></br>
</div>

##  MSAL Login
<p align="center">
    <img width="400" src="./screenshots/Start.gif">
</p>

##  Existing Account Login
<p align="center">
    <img width="400" src="./screenshots/ExistingAccount.gif">
</p>


## NuGet Packages
- `Microsoft.Identity.Client`
- `System.IdentityModel.Tokens.Jwt`


Before running the app:
- [Create project and deploy the backend](https://docs.microsoft.com/en-us/azure/developer/mobile-apps/azure-mobile-apps/quickstarts/maui)
- [Register the application](https://docs.microsoft.com/en-us/azure/active-directory/develop/quickstart-register-app)
After completing these steps you will be able to retrieve a ClientId from the Azure AD Directory that should be used in the Services/Constants.cs file

<p align="center">
<img src="https://docs.microsoft.com/en-us/azure/active-directory/develop/media/quickstart-register-app/portal-03-app-reg-02.png"/>
</p>

For more information about the sample see:
- [What is Azure AD](https://docs.microsoft.com/en-us/azure/active-directory/fundamentals/active-directory-whatis)
- [What is MSAL](https://docs.microsoft.com/en-us/azure/active-directory/develop/msal-overview)
- [Intro to Azure AD Tenants](https://docs.microsoft.com/en-us/microsoft-365/education/deploy/intro-azure-active-directory)
