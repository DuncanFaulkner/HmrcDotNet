# HmrcDotNet

![alt text](https://github.com/markogrady/HmrcDotNet/blob/master/src/HmrcDotNet.Web/wwwroot/images/HMRCWrapper.png "LOGO")

A simple .Net client wrapper for the HMRC api

https://developer.service.hmrc.gov.uk/api-documentation

## Getting Started

HmrcDotNet once tested will be available by nuget:

```powershell
PM> Install-Package ?comingsoon?
```

Once we have the package installed, we can then create a `HmrcSettings` in your appsettings.json file.

When using the latest version of aspnet I recommend you using Manage Secrets to avoid putting them into source control.
```javascript
{
  "HmrcSettings": {
    "BaseUrl": "https://test-api.service.hmrc.gov.uk/",
    "ClientId": "aFg1ZNPBSCxOk0WzW0uak32322",
    "ClientSecret": "d2a59pe0-2f52-401g-fac7-0u71mecbf718",
    "ServerToken": "",
    "CallbackUrl": "https://localhost:44309/HmrcAuth/Callback",
    "TokenUrl": "/oauth/token"
  }
}
```

You can obtain the keys when creating an app via the [HMRC TEST API website](https://developer.service.hmrc.gov.uk/developer/applications)

##Example
The following example we will receive an individual benefits objects

Once you have your access token you can pass it into a service using the settoken method and then call the relevant method
```csharp
var individualDataService = new IndividualDataService();
individualDataService.SetToken(authToken.AccessToken);
var individualBenefits = await _individualDataService.GetBenefitsAsync("2234567890", "2017-18");
```
