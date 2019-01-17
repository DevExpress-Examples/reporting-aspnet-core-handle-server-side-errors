using System;
using System.IO;
using DevExpress.XtraReports.Web.ClientControls;
#if NETFRAMEWORK
using System.ServiceModel;
# endif
using DevExpress.XtraReports.Web.WebDocumentViewer;

namespace DXAspNetCoreApp.Services {
	public class CustomWebDocumentViewerExceptionHandler : WebDocumentViewerExceptionHandler, IWebDocumentViewerExceptionHandler {
		public override string GetDocumentCreationExceptionMessage(DocumentCreationException ex) {
            var customExpressionException = ex.GetBaseException() as CustomInvalidRangeException;
            if (customExpressionException != null) {
				return customExpressionException.DetailedMessage;
			} else {
				return base.GetDocumentCreationExceptionMessage(ex);
			};
		}

		public override string GetFaultExceptionMessage(FaultException faultException) {
			return $"FaultException occurred: {faultException.Message}.";
		}
	
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
	}
}