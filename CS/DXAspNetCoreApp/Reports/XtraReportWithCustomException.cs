using System;
using DevExpress.XtraReports.UI;

namespace DXAspNetCoreApp.Reports {
    public partial class XtraReportWithCustomException : XtraReport {
        public XtraReportWithCustomException() {
            InitializeComponent();
        }
        private void InitializeComponent() {
            DevExpress.XtraReports.ReportInitializer reportInitializer = new DevExpress.XtraReports.ReportInitializer(this, "DXAspNetCoreApp.Reports.XtraReportWithCustomException.repx");

            // Controls
            this.TopMargin = reportInitializer.GetControl<DevExpress.XtraReports.UI.TopMarginBand>("TopMargin");
            this.BottomMargin = reportInitializer.GetControl<DevExpress.XtraReports.UI.BottomMarginBand>("BottomMargin");
            this.Detail = reportInitializer.GetControl<DevExpress.XtraReports.UI.DetailBand>("Detail");
            this.xrLabel3 = reportInitializer.GetControl<DevExpress.XtraReports.UI.XRLabel>("xrLabel3");
            this.xrLabel2 = reportInitializer.GetControl<DevExpress.XtraReports.UI.XRLabel>("xrLabel2");
            this.xrLabel1 = reportInitializer.GetControl<DevExpress.XtraReports.UI.XRLabel>("xrLabel1");

            // Parameters
            this.StartDate = reportInitializer.GetParameter("StartDate");
            this.EndDate = reportInitializer.GetParameter("EndDate");
        }

        protected override void BeforeReportPrint() {
            var startDateParameter = Parameters["StartDate"];
            var endDateParameter = Parameters["EndDate"];
            if(startDateParameter != null || endDateParameter != null || startDateParameter.Type == typeof(DateTime) || endDateParameter.Type == typeof(DateTime)) {
                var startDate = (DateTime)startDateParameter.Value;
                var endDate = (DateTime)endDateParameter.Value;
                if(endDate - startDate > TimeSpan.FromDays(14)) {
                    throw new CustomInvalidRangeException(startDate, endDate, $"CustomInvalidRangeException occurred. Specified range exceeds 14 days.");
                } else if(endDate < startDate) {
                    throw new CustomInvalidRangeException(startDate, endDate, $"CustomInvalidRangeException occurred. End date should be greater than start date.");
                }
            }
            base.BeforeReportPrint();
        }

        private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
        private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.XRLabel xrLabel3;
        private DevExpress.XtraReports.UI.XRLabel xrLabel2;
        private DevExpress.XtraReports.UI.XRLabel xrLabel1;
        private DevExpress.XtraReports.Parameters.Parameter StartDate;
        private DevExpress.XtraReports.Parameters.Parameter EndDate;
    }
}
