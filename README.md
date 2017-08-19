# MailgunWebhooks #
Mailgun Webhooks WebAPI Endpoints

> Status: Currently in Progress

## Testing Webhooks locally from IIS Express ##
To test Webhooks with real data, you need to expose your local website on internet. Here is a nice clean way to do it.  

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