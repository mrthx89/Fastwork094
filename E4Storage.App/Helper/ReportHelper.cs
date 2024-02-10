using DevExpress.XtraPrinting;
using DevExpress.XtraReports;
using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.App.Helper
{
    public class ReportHelper
    {
        public enum StatusCetak
        {
            Preview = 0,
            Print = 1,
            Edit = 2
        }

        public class Parameter
        {
            public string Name { get; set; }
            public dynamic Value { get; set; }
        }

        [Obsolete]
        public static void ReportHandler(
            StatusCetak status,
            DataSet ds,
            string fileName,
            string title,
            List<Parameter> calculates)
        {
            XtraReport report = new XtraReport();
            XtraReport XtraReportSub = null;
            List<XRSubreport> SubReports = new List<XRSubreport>();
            // Create a new Security Permission which denies any File IO operations.
            ScriptSecurityPermission permission = new ScriptSecurityPermission("System.Security.Permissions.FileIOPermission");
            try
            {
                if (System.IO.File.Exists(System.IO.Path.Combine(Environment.CurrentDirectory, "Report", fileName)))
                {
                    report = XtraReport.FromFile(System.IO.Path.Combine(Environment.CurrentDirectory, "Report", fileName), true);

                    report.DataSource = ds;
                    report.DataMember = ds.Tables[0].TableName;

                    if (calculates != null && calculates.Count >= 1)
                    {
                        foreach (var item in calculates)
                        {
                            foreach (var cal in report.CalculatedFields)
                            {
                                if (cal.Name.Equals(item.Name))
                                {
                                    switch (cal.GetType().Name)
                                    {
                                        case "Boolean":
                                            cal.Expression = $"{((bool)item.Value).ToString().ToLower()}";
                                            break;
                                        case "Int32":
                                            cal.Expression = $"{(int)item.Value}";
                                            break;
                                        case "Int64":
                                            cal.Expression = $"{(long)item.Value}L";
                                            break;
                                        case "Decimal":
                                        case "Double":
                                            cal.Expression = $"{(double)item.Value}";
                                            break;
                                        case "DateTime":
                                            cal.Expression = $"#{item.Value:MM/dd/yyyy HH:mm:ss}#";
                                            break;
                                        default:
                                            cal.Expression = $"\"{item.Value.ToString()}\"";
                                            break;
                                    }
                                }
                            }
                        }
                    }

                    report.ScriptLanguage = ScriptLanguage.VisualBasic;
                    permission.Deny = true;
                    // Add this permission to a report's list of permissions for scripts.
                    report.ScriptSecurityPermissions.Add(permission);
                    report.Name = title;
                    report.PrintingSystem.SetCommandVisibility(PrintingSystemCommand.ClosePreview, DevExpress.XtraPrinting.CommandVisibility.None);
                    report.DisplayName = title;
                    report.ShowPrintMarginsWarning = false;
                    report.ShowPrintStatusDialog = false;

                    SubReports = report.AllControls<XRSubreport>().ToList();
                    for (int i = SubReports.Count - 1; i >= 0; i--)
                    {
                        if (!string.IsNullOrEmpty(SubReports[i].ReportSourceUrl) && !string.IsNullOrWhiteSpace(SubReports[i].ReportSourceUrl))
                        {
                            if (XtraReportSub != null)
                            {
                                XtraReportSub.Dispose();
                                XtraReportSub = null;
                            }
                            XtraReportSub = new XtraReport();
                            XtraReportSub.LoadLayout(SubReports[i].ReportSourceUrl.Replace("~", Environment.CurrentDirectory));
                            XtraReportSub.DataSource = report.DataSource;
                            SubReports[i].ReportSource = XtraReportSub;
                            SubReports[i].ReportSource.DataSource = report.DataSource;
                            SubReports[i].Report.DataSource = report.DataSource;
                            SubReports[i].BeforePrint += xrSubreport1_BeforePrint;
                        }
                    }

                    if (status == StatusCetak.Print)
                    {
                        report.PrintDialog();
                    }
                    else if (status == StatusCetak.Preview)
                    {
                        report.ShowRibbonPreviewDialog();
                    }
                    else if (status == StatusCetak.Edit)
                    {
                        report.ShowRibbonDesignerDialog();
                    }
                }
                else
                {
                    if (MsgBoxHelper.MsgQuestionYesNo($"ReportHelper.ReportHandler", null, "File " + fileName + " tidak ditemukan! Lalukan Mode Desain!", System.Windows.Forms.MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
                    {
                        report = new XtraReport();

                        report.DataSource = ds;
                        report.DataMember = ds.Tables[0].TableName;

                        if (calculates != null && calculates.Count >= 1)
                        {
                            foreach (var item in calculates)
                            {
                                foreach (var cal in report.CalculatedFields)
                                {
                                    if (cal.Name.Equals(item.Name))
                                    {
                                        switch (cal.GetType().Name)
                                        {
                                            case "Boolean":
                                                cal.Expression = $"{((bool)item.Value).ToString().ToLower()}";
                                                break;
                                            case "Int32":
                                                cal.Expression = $"{(int)item.Value}";
                                                break;
                                            case "Int64":
                                                cal.Expression = $"{(long)item.Value}L";
                                                break;
                                            case "Decimal":
                                            case "Double":
                                                cal.Expression = $"{(double)item.Value}";
                                                break;
                                            case "DateTime":
                                                cal.Expression = $"#{item.Value:MM/dd/yyyy HH:mm:ss}#";
                                                break;
                                            default:
                                                cal.Expression = $"\"{item.Value.ToString()}\"";
                                                break;
                                        }
                                    }
                                }
                            }
                        }

                        report.ScriptLanguage = ScriptLanguage.VisualBasic;
                        permission.Deny = true;
                        // Add this permission to a report's list of permissions for scripts.
                        report.ScriptSecurityPermissions.Add(permission);
                        report.Name = title;
                        report.PrintingSystem.SetCommandVisibility(PrintingSystemCommand.ClosePreview, DevExpress.XtraPrinting.CommandVisibility.None);
                        report.DisplayName = title;
                        report.ShowPrintMarginsWarning = false;
                        report.ShowPrintStatusDialog = false;

                        SubReports = report.AllControls<XRSubreport>().ToList();
                        for (int i = SubReports.Count - 1; i >= 0; i--)
                        {
                            if (!string.IsNullOrEmpty(SubReports[i].ReportSourceUrl) && !string.IsNullOrWhiteSpace(SubReports[i].ReportSourceUrl))
                            {
                                if (XtraReportSub != null)
                                {
                                    XtraReportSub.Dispose();
                                    XtraReportSub = null;
                                }
                                XtraReportSub = new XtraReport();
                                XtraReportSub.LoadLayout(SubReports[i].ReportSourceUrl.Replace("~", Environment.CurrentDirectory));
                                XtraReportSub.DataSource = report.DataSource;
                                SubReports[i].ReportSource = XtraReportSub;
                                SubReports[i].ReportSource.DataSource = report.DataSource;
                                SubReports[i].Report.DataSource = report.DataSource;
                                SubReports[i].BeforePrint += xrSubreport1_BeforePrint;
                            }
                        }

                        report.ShowRibbonDesignerDialog();
                    }
                }
            }
            catch (Exception ex)
            {
                MsgBoxHelper.MsgError($"ReportHelper.ReportHandler", ex);
            }
        }

        private static void xrSubreport1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            XRSubreport subreport = sender as XRSubreport;
            XtraReport reportSource = subreport.ReportSource as XtraReport;
            XtraReport rootSource = subreport.RootReport as XtraReport;

            //TryCast(reportSource.DataSource, ObjectDataSource).DataSource = recibo
            subreport.Report.DataSource = rootSource.DataSource;
            reportSource.Report.DataSource = subreport.Report.DataSource;
        }
    }
}
