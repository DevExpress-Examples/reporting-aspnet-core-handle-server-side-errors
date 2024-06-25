<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/166224491/18.2.5%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T830477)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
[![](https://img.shields.io/badge/💬_Leave_Feedback-feecdd?style=flat-square)](#does-this-example-address-your-development-requirementsobjectives)
<!-- default badges end -->
# How to handle server-side errors in ASP.NET Core reporting controls

This example demonstrates how to process errors that occur on ASP.NET Core reporting controls' server side.

* The [ReportDesignerExceptionHandler](https://docs.devexpress.com/XtraReports/DevExpress.XtraReports.Web.ReportDesigner.Services.ReportDesignerExceptionHandler) class is used for the [End-User Report Designer](https://docs.devexpress.com/XtraReports/400249/create-end-user-reporting-applications/web-reporting/asp-net-core-reporting/end-user-report-designer) control.
* The [WebDocumentViewerExceptionHandler](https://docs.devexpress.com/XtraReports/400248/create-end-user-reporting-applications/web-reporting/asp-net-core-reporting/document-viewer) class is used for the separate [Web Document Viewer](https://docs.devexpress.com/XtraReports/17738/create-end-user-reporting-applications/web-reporting/asp-net-webforms-reporting/document-viewer/html5-document-viewer) control and the Report Designer's built-in Document Viewer.

These classes expose the following methods:
* [GetExceptionMessage](https://docs.devexpress.com/XtraReports/DevExpress.XtraReports.Web.ClientControls.ExceptionHandler.GetExceptionMessage(System.Exception)) to handle all possible errors independently from their types;
* [GetDocumentCreationExceptionMessage](https://docs.devexpress.com/XtraReports/DevExpress.XtraReports.Web.WebDocumentViewer.WebDocumentViewerExceptionHandler.GetDocumentCreationExceptionMessage(DocumentCreationException)) to handle errors related to the document creation process;
* [GetFaultExceptionMessage](http://docs.devexpress.com/XtraReports/DevExpress.XtraReports.Web.ClientControls.ExceptionHandler.GetFaultExceptionMessage(System.ServiceModel.FaultException)) to handle [FaultException](https://docs.microsoft.com/en-us/dotnet/api/system.servicemodel.faultexception);
* [GetUnknownExceptionMessage](https://docs.devexpress.com/XtraReports/DevExpress.XtraReports.Web.ClientControls.ExceptionHandler.GetUnknownExceptionMessage(System.Exception)) to handle other unknown exceptions, for which reporting controls show the standard 'Internal Server Error' message.

This example contains several report layouts and emulates exceptions that can be raised when you work with reporting controls. 

The following table lists errors from this example and methods used to process these errors.

| Sample Error | Exception Type | Processing Method |
|---|---|---|
| Broken Report Layout | [XmlException](https://docs.microsoft.com/en-us/dotnet/api/system.xml.xmlexception) | [GetUnknownExceptionMessage](https://docs.devexpress.com/XtraReports/DevExpress.XtraReports.Web.ClientControls.ExceptionHandler.GetUnknownExceptionMessage(System.Exception))|
| File Not Found | [FileNotFoundException](https://docs.microsoft.com/en-us/dotnet/api/system.io.filenotfoundexception) | [GetUnknownExceptionMessage](https://docs.devexpress.com/XtraReports/DevExpress.XtraReports.Web.ClientControls.ExceptionHandler.GetUnknownExceptionMessage(System.Exception))|
| Standard Exception on BeforePrint | [UnauthorizedAccessException](https://docs.microsoft.com/en-us/dotnet/api/system.unauthorizedaccessexception) | [GetDocumentCreationExceptionMessage](https://docs.devexpress.com/XtraReports/DevExpress.XtraReports.Web.WebDocumentViewer.WebDocumentViewerExceptionHandler.GetDocumentCreationExceptionMessage(DocumentCreationException))
| Custom Exception on BeforePrint | CustomInvalidRangeException (descendant from [Exception](https://docs.microsoft.com/en-us/dotnet/api/system.exception)) | [GetDocumentCreationExceptionMessage](https://docs.devexpress.com/XtraReports/DevExpress.XtraReports.Web.WebDocumentViewer.WebDocumentViewerExceptionHandler.GetDocumentCreationExceptionMessage(DocumentCreationException))
| Invalid Report URL (Designer) | FaultException  | [GetFaultExceptionMessage](http://docs.devexpress.com/XtraReports/DevExpress.XtraReports.Web.ClientControls.ExceptionHandler.GetFaultExceptionMessage(System.ServiceModel.FaultException))
| Custom Document Operation (Viewer) | FaultException  | [GetFaultExceptionMessage](http://docs.devexpress.com/XtraReports/DevExpress.XtraReports.Web.ClientControls.ExceptionHandler.GetFaultExceptionMessage(System.ServiceModel.FaultException))

**See also**

[How to handle server-side errors in web reporting controls (ASP.NET WebForms/MVC)](https://github.com/DevExpress-Examples/how-to-handle-server-side-errors-in-web-reporting-controls)
<!-- feedback -->
## Does this example address your development requirements/objectives?

[<img src="https://www.devexpress.com/support/examples/i/yes-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=reporting-aspnet-core-handle-server-side-errors&~~~was_helpful=yes) [<img src="https://www.devexpress.com/support/examples/i/no-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=reporting-aspnet-core-handle-server-side-errors&~~~was_helpful=no)

(you will be redirected to DevExpress.com to submit your response)
<!-- feedback end -->
