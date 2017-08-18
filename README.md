# MailgunWebhooks
Mailgun Webhooks WebAPI Endpoints

Status: Currently in Progress

Testing Webhooks locally from IIS Express
1. Download ngrok https://ngrok.com/
2. If 65008 is your port used to run the web api, then run the following command in your terminal 
```
.\ngrok.exe http 65008
```
3. The output should be similar with the following:
```
ngrok by @inconshreveable

Session Status                online
Version                       2.2.8
Region                        United States (us)
Web Interface                 http://127.0.0.1:4040
Forwarding                    http://0d19b31c.ngrok.io -> localhost:65008
Forwarding                    https://0d19b31c.ngrok.io -> localhost:65008

Connections                   ttl     opn     rt1     rt5     p50     p90
                              0       0       0.00    0.00    0.00    0.00
```
4. Open your host file and add
```
127.0.0.1 0d19b31c.ngrok.io
```
5. Open %YOUR WORKSPACE%\MailgunWebhooks\\.vs\config\applicationhost.config
6. In applicationhost.config look for your Site xml node
7. Add the following line <binding protocol="http" bindingInformation="*:65008:" /> into the <bindings> like in the following example
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
8. (Optional) Set Web Api Visual Studio project start url to http://0d19b31c.ngrok.io
9. Remember that you're in Windows so restart Visual Studio.
