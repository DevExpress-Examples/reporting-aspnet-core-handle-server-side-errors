using System;
using DevExpress.XtraReports.UI;

namespace DXAspNetCoreApp.Reports
{
    public partial class XtraReportWithException : XtraReport
    {
        public XtraReportWithException()
        {
            InitializeComponent();
        }

        protected override void BeforeReportPrint() {
            throw new UnauthorizedAccessException();
        }

        private void InitializeComponent()
        {
            DevExpress.XtraReports.ReportInitializer reportInitializer = new DevExpress.XtraReports.ReportInitializer(this, "DXAspNetCoreApp.Reports.XtraReportWithException.repx");

            // Controls
            this.TopMargin = reportInitializer.GetControl<DevExpress.XtraReports.UI.TopMarginBand>("TopMargin");
            this.BottomMargin = reportInitializer.GetControl<DevExpress.XtraReports.UI.BottomMarginBand>("BottomMargin");
            this.Detail = reportInitializer.GetControl<DevExpress.XtraReports.UI.DetailBand>("Detail");
            this.xrLabel1 = reportInitializer.GetControl<DevExpress.XtraReports.UI.XRLabel>("xrLabel1");
        }
        private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
        private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.XRLabel xrLabel1;
    }
}
