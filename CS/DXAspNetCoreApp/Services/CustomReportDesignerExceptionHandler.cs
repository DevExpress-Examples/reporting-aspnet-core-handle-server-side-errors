using System;
using System.IO;
using DevExpress.XtraReports.Web.ClientControls;
#if NETFRAMEWORK
using System.ServiceModel;
#endif
using DevExpress.XtraReports.Web.ReportDesigner.Services;

namespace DXAspNetCoreApp.Services {
	public class CustomReportDesignerExceptionHandler : ReportDesignerExceptionHandler, IReportDesignerExceptionHandler {
        public override string GetUnknownExceptionMessage(Exception ex) {
            if (ex is FileNotFoundException) {
#if DEBUG
                return $"Debug mode. {ex.Message}.";
#else
                return "File is not found.";
#endif
            }
            
            return $"{ex.GetType().Name} occurred. See the log file for more details.";
        }

        public override string GetFaultExceptionMessage(FaultException ex) {
            return $"FaultException occurred: {ex.Message}.";
        }
    }
}