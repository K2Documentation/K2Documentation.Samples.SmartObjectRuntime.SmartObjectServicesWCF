# K2Documentation.Samples.SmartObjectRuntime.SmartObjectServicesWCF
This sample code shows how to interact with the SmartObjects WCF Services.

Find more information in the K2 Developers Reference here:
https://help.k2.com/onlinehelp/k2five/DevRef/current/default.htm#Runtime/SmO-WCF/SmOWCFSamples.htm

K2 provides a Windows Communication Foundation (WCF)-based service that utilizes SOAP-based messaging to interact with a SmartObject from custom .NET applications.  This allows developers to interact with a SmartObject at runtime through a web service without requiring a reference to any SourceCode client .dlls.
The WCF services are generally used for .NET solutions with server-side processing, and they provide strongly-typed access to SmartObjects. The service supports SOAP and ATOM formats and is accessible over HTTP or HTTPS.

This project contains sample code that demonstrates the basic use of the SmartObjects WCF services:
* Simple list method for the Workflow General/Process Instance SmartObject
* Filtered list method for the Workflow General/Process Instance SmartObject

## Prerequisites
* .NET Assemblies (both assemblies are included with K2 client-side tools install and are also included in the project's References folder)
  * SourceCode.SmartObjects.Client.dll  
  To create filters for the _Filtered methods, you need to import the SourceCode.SMartObject.Client namespace but you can also construct the filter XML manually without this reference.

## Getting started
* Use these code snippets to learn about the basic use of the SmartObjects WCF services.
* Note that as this project is only sample code, it may compile but will not actually run as-is. You will need to edit the code snippets to work in your environment and with your artifacts.
* Fetch or Pull the appropriate branch of this project for your version of K2.
* Consider the Master branch the latest, up-to-date version of the sample project. Branches contain older versions. For example, there may be a branch called K2-Five-5.0 that is specific to K2 Five version 5.0. There may be another branch called K2-Five-5.3 that is specific to K2 Five version 5.3. Assume that the master branch represents the latest release version of K2 Five.
* The Visual Studio project contains a folder called "References" where you can find the referenced .NET assemblies or other uncommon assemblies. By default, try to reference these assemblies from your own environment for consistency, but we provide the referenced assemblies as a convenience in case you are not able to locate or use the referenced assemblies in your environment.
* The Visual Studio project contains a folder called "Resources". This folder contains additional resources that may be required to use the same code, such as K2 deployment packages, sample files, SQL scripts and so on.
   
## License
This project is licensed under the MIT license. Find the MIT license in LICENSE.

## Notes
* The sample code is provided as-is without warranty.
* These sample code projects are not supported by K2 product support.
* The sample code is not necessarily comprehensive for all operations, features or functionality.
* We only accept code contributions that are compatible with the MIT license (essentially, MIT and Public Domain).
