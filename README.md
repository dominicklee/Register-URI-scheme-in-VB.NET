# Register URI scheme in VB.NET
Basic example of how to register a new URI scheme in VB.NET

## Overview ##
As we have seen over the years, there are many applications such as Skype, Zoom, Leap Motion, Postman, etc that use URI schemes to convey information from web hyperlinks to an application on a computer. This is often helpful because data can be relayed to a computer with a specific application. Today, we are going to demonstrate an example of that using VB.NET on a Windows PC.

![Screenshot](https://raw.githubusercontent.com/dominicklee/Register-URI-scheme-in-VB.NET/main/screenshot.png)

## Usage ##
1. Download this repository and open the solution.
2. Rename the `UriScheme` to whatever "protocol" you want people to type in the browser. Rename `FriendlyName` to the formal name of your application.
3. Run the `RegisterUriScheme()` function to add your app in the registry. You can create a setting to run this the first time.
4. Run the `UnegisterUriScheme()` function to remove your app from the registry. You should allow users to run this function in case they want to uninstall your app.
5. On form startup, you can get the string from `getParams()`. If the string is not blank, then someone started your app from the URI schema.

## Tips ##
If you plan to use this method in a production setting, ensure that you provide HTTP link to a page prior to providing the user the schema link to help the end-user understand what is happening. Some browsers such as Chrome warns users prior to them opening an application.

Additionally, do **not** use this method to convey directories for file/folder modification, creation, or deletion. This will introduce security vulnerabilities to hackers. Even if your own links or app is not malicious, hackers will have a means to breach computers that run your application.

Special thanks to [hmeziantou](https://www.meziantou.net/registering-an-application-to-a-uri-scheme-using-net.htm "meziantou") for the inspiration.