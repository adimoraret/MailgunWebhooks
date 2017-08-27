# MailgunWebhooks #
Mailgun Webhooks WebAPI Endpoints

[![Build Status](https://travis-ci.org/adimoraret/MailgunWebhooks.svg?branch=master)](https://travis-ci.org/adimoraret/MailgunWebhooks.svg?branch=master)

To test Webhooks with online data, you need to expose your local website on internet. Here is a nice clean way to do it with Visual Studio and IIS Express.  

* Open MailgunWebhooks WebAPI solution in Visual Studio.
* Open %YOUR WORKSPACE%\MailgunWebhooks\\.vs\config\applicationhost.config
* In applicationhost.config look for your Site xml node
* If 65008 is your port, add the following line 
```xml
<binding protocol="http" bindingInformation="*:65008:" /><bindings> 
```
* Example
```xml
<site name="MailgunWebhooks" id="2">
    <application path="/" applicationPool="Clr4IntegratedAppPool">
        <virtualDirectory path="/" physicalPath="C:\Workspace\csharp\MailgunWebhooks\MailgunWebhooks" />
    </application>
    <bindings>
        <binding protocol="http" bindingInformation="*:65008:" />
        <binding protocol="http" bindingInformation="*:65008:localhost" />
    </bindings>
</site>
```
* Open %YOUR WORKSPACE%\MailgunWebhooks\\packages.config and replace port 65008 with your port
* Run your solution from Visual Studio (F5)
* Open your terminal and navigate to the solution folder to install the npm packages and run start
```
npm install
```
```
npm start
```
* The output of "npm start" should be similar with the following:
```
> mailgun-webhooks@1.0.0 start C:\Workspace\csharp\MailgunWebhooks
> lt --port 65008 --open

your url is: https://elemuzzmps.localtunnel.me
```
* The presented url should be opened into your browser

In web.config, change the value of Mailgun key with your Mailgun key
```xml
<add key="MailgunKey" value="#########" />
``` 

Configure the webhooks on the mailgun website similar to:
* https://elemuzzmps.localtunnel.me/api/mailgun/event/deliver
* https://elemuzzmps.localtunnel.me/api/mailgun/event/drop
* https://elemuzzmps.localtunnel.me/api/mailgun/event/bounce
* https://elemuzzmps.localtunnel.me/api/mailgun/event/spam
* https://elemuzzmps.localtunnel.me/api/mailgun/event/unsubscribe
* https://elemuzzmps.localtunnel.me/api/mailgun/event/click
* https://elemuzzmps.localtunnel.me/api/mailgun/event/open

