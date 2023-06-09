1. Add Azure AD Configuration for web.config file ###

<appSettings>
    <add key="ClientId" value="ClientId"/>
    <add key="ClientSecret" value="ClientSecret"/>
    <add key="TenantId" value="TenantId"/>
    <add key="RedirectUri" value="RedirectUri"/>
    <add key="Instance" value="Instance"/>
</appSettings>

2. Install Owin package, in package management console run this command

Install-Package Owin
Install-Package Microsoft.Owin