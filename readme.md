# XpathEncryptor

Encrypts values in XML files. Written as a tool for encrypting App.config files in client facing .NET C# base apps. The app/library is however written generically enough to be utilized for other use cases.

XpathEncryptor encryptor is desiged to be used as part of a buld and/or installation process.
## Components
### `XpathEncryptor` console app
An executable that enrypts values in an XML file. The value that you want to encrypt is specified by an XPath expression. You can target multiple values at once if your XPath returns multiple nodes.

You can invoke XpathEncryptor with the following commandline arguments:
* XML file path (e.g. app.config or web.config)
* Xpath targeting the value you want to replace
* Pass phrase (encryption key)

if no parameters are provided the app is started in interactive mode and XpathEncryptor will ask for input.

You can start the app from the commandline with arguments, e.g.:
```
XpathEncryptor.exe "..\..\..\XpathEncryptor.Consumer\bin\Debug\XpathEncryptor.Consumer.exe.config" "configuration/appSettings/add[@key='TestSetting']/@value" "VeryHard2Guess!"
```

### `XpathEncryptor.Core` library

A .NET library that is designed to be included in your app and allows you to encrypt and decrypt values. You can find an example in the `XpathEncryptor.Consumer` app how to integrate the library in your own projects. 

### `XpathEncryptor.Consumer` console app

An example app that shows how to use XpathEncryptor to decrypt a previously encrypted app.config file.
