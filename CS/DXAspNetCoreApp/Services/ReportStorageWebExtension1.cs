using System.Collections.Generic;
using System.IO;
using DevExpress.XtraReports.UI;
using DevExpress.XtraReports.Web.Extensions;
using DXAspNetCoreApp.Reports;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace DXAspNetCoreApp {
    public class ReportStorageWebExtension1 : ReportStorageWebExtension {

        readonly string reportDirectory;
        const string ReprtFileExtension = ".repx";

		public ReportStorageWebExtension1(IHostEnvironment env) {
            reportDirectory = Path.Combine(env.ContentRootPath, "Reports");
		}

		public override bool CanSetData(string url) {
			return base.CanSetData(url);
		}

		public override bool IsValidUrl(string url) {
			return url != "invalidUrl";
		}

		public override byte[] GetData(string url) {
			XtraReport report;
			if (url == "brokenReportLayout") {
				report = XtraReport.FromFile(Path.Combine(reportDirectory, "BrokenLayout" + ReprtFileExtension));
			} else if (url == "fileNotFound") { 
				report = XtraReport.FromFile(url);
			} else if (url == "reportWithCustomException") {
				report = new XtraReportWithCustomException();
            } else if (url == "reportWithException") {
				report = new XtraReportWithException();
            } else if (url == "ValidReport") {
				report = new ValidReport();
            }
            else
				throw new KeyNotFoundException(url);
			using (var ms = new MemoryStream()) {
				report.SaveLayoutToXml(ms);
				return ms.ToArray();
			}
		}

		public override Dictionary<string, string> GetUrls() {
			return base.GetUrls();
		}

		public override void SetData(XtraReport report, string url) {
			base.SetData(report, url);
		}

		public override string SetNewData(XtraReport report, string defaultUrl) {
			return base.SetNewData(report, defaultUrl);
		}
	}
}