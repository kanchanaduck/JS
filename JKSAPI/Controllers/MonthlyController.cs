using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using Microsoft.Extensions.Configuration;
using OfficeOpenXml.Style;
using System.Drawing;
using System.Globalization;
using System.IO;
using OfficeOpenXml;

namespace JKSAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MonthlyController : ControllerBase
    {
        private readonly DBContext context;
        private IConfiguration configuration;
        public MonthlyController(DBContext context, IConfiguration _configuration)
        {
            this.context = context;
            this.configuration = _configuration;
        }

        /// <summary>
        /// SP Detail.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /Monthly/Detail
        ///     {
        ///        "start_date": "2021-05-01",
        ///        "end_date": "2021-05-17",
        ///        "wc_code": "",
        ///        "model_code": "",
        ///        "process_code": "",
        ///        "cell_code": "",
        ///        "shift_code": ""
        ///     }
        ///
        /// </remarks>
        [HttpPost]
        [Route("Detail")]
        public IActionResult S_Detail(Post_Summary data)
        {
            try
            {
                var d1 = Convert.ToDateTime(data.start_date).ToString("yyyy-MM-dd");
                var d2 = Convert.ToDateTime(data.end_date).ToString("yyyy-MM-dd");

                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                string constr = this.configuration.GetConnectionString("ConnStr");
                using (SqlConnection con = new SqlConnection(constr))
                {
                    // string query = @"EXEC [dbo].[S_Monthly_Report_Detail] @start_date = N'" + d1 + "', @end_date = N'" + d2 + "' "
                    // + " , @wc_code = N'" + data.wc_code + "' "
                    // + " , @model_code = N'" + data.model_code + "' "
                    // + " , @shift_code = N'" + data.shift_code + "' ";

                    string query = @"EXEC [dbo].[S_Monthly_Report_Detail_2] @start_date = N'" + d1 + "', @end_date = N'" + d2 + "' "
                    + " , @wc_code = N'" + data.wc_code + "' "
                    + " , @model_code = N'" + data.model_code + "' "
                    + " , @process_code = N'" + data.process_code + "' "
                    + " , @cell_code = N'" + data.cell_code + "' "
                    + " , @shift_code = N'" + data.shift_code + "' ";

                    using (SqlCommand cmd = new SqlCommand(query))
                    {
                        cmd.Connection = con;
                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            // sda.Fill(ds);
                            sda.Fill(dt);
                            if (dt.Rows.Count > 0)
                            {
                                sda.Fill(ds);
                            }
                            else
                            {
                                return NotFound("ไม่พบข้อมูล");
                            }
                        }
                    }
                }

                return Ok(ds);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// SP TSS.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /Monthly/TSS
        ///     {
        ///        "start_date": "2020-10-01",
        ///        "end_date": "2020-10-15",
        ///        "wc_code": "WC-004",
        ///        "model_code": "M-013",
        ///        "shift_code": "S-001"
        ///     }
        ///
        /// </remarks>
        [HttpPost]
        [Route("TSS")]
        public IActionResult S_TSS(Post_Summary data)
        {
            try
            {
                var d1 = Convert.ToDateTime(data.start_date).ToString("yyyy-MM-dd");
                var d2 = Convert.ToDateTime(data.end_date).ToString("yyyy-MM-dd");

                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                string constr = this.configuration.GetConnectionString("ConnStr");
                using (SqlConnection con = new SqlConnection(constr))
                {
                    // string query = "EXEC [dbo].[S_Monthly_Report_TSS] @start_date = N'" + d1 + "', @end_date = N'" + d2 + "', @wc_code = N'" + data.wc_code + "', @model_code = N'" + data.model_code + "', @shift_code = N'" + data.shift_code + "'";
                    string query = @"EXEC [dbo].[S_Monthly_Report_TSS_2] @start_date = N'" + d1 + "', @end_date = N'" + d2 + "' "
                    + " , @wc_code = N'" + data.wc_code + "' "
                    + " , @model_code = N'" + data.model_code + "' "
                    + " , @process_code = N'" + data.process_code + "' "
                    + " , @cell_code = N'" + data.cell_code + "' "
                    + " , @shift_code = N'" + data.shift_code + "' ";

                    using (SqlCommand cmd = new SqlCommand(query))
                    {
                        cmd.Connection = con;
                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            //sda.Fill(ds);
                            sda.Fill(dt);
                            if (dt.Rows.Count > 0)
                            {
                                DataRow dr = dt.NewRow();
                                dr["tss_code"] = "non";
                                dr["tss_info"] = "Non-working time";
                                decimal sum = 0;
                                for (int i = 0; i < dt.Columns.Count; i++)
                                {
                                    if (i > 1)
                                    {
                                        sum = 0;
                                        for (int j = 0; j < dt.Rows.Count; j++)
                                        {
                                            var query_cal = context.M_TSS.Where(x => x.tss_code == dt.Rows[j]["tss_code"].ToString() && 
                                            x.cal_extrawork == false && x.cal_jobspecial == false).FirstOrDefault();
                                            
                                            // if (dt.Rows[j]["tss_code"].ToString() != "150" && dt.Rows[j]["tss_code"].ToString() != "160")
                                            if (query_cal != null)
                                            {
                                                // Console.WriteLine("tss_code: " + dt.Rows[j]["tss_code"].ToString());
                                                sum += (decimal)dt.Rows[j][i];
                                            }
                                        }
                                        dr[i] = sum;
                                    }
                                }
                                dt.Rows.InsertAt(dr, 0);
                            }
                            else
                            {
                                return NotFound("ไม่พบข้อมูล");
                            }
                        }
                    }
                }
                return Ok(dt);
            }
            catch (Exception)
            {
                throw;
            }
        }


        /// <summary>
        /// Export excel monthly report.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /Monthly/exportMonthly
        ///     {
        ///        "start_date": "2020-10-01",
        ///        "end_date": "2020-10-15",
        ///        "wc_code": "WC-004",
        ///        "model_code": "M-013",
        ///        "shift_code": "all"
        ///     }
        ///
        /// </remarks>
        [HttpPost("exportMonthly")]
        public async Task<IActionResult> exportMonthly(Post_Summary data)
        {
            try
            {
                // query data from database
                await Task.Yield();
                DataTable dtTSS = getTSS(data);
                DataTable dtDetail = getDetail(data);

                var stream = new MemoryStream();
                using (var package = new ExcelPackage(stream))
                {
                    if (dtTSS.Rows.Count > 0)
                    {
                        Console.WriteLine("tss > 0");
                        if (dtDetail.Rows.Count > 0)
                        {
                            Console.WriteLine("Detail > 0");
                            int countTSS = dtTSS.Columns.Count + 1;
                            int countDT = dtDetail.Columns.Count + 1;
                            int rowTss = 14;
                            int rowDetail = 2;
                            int eRowTSS = dtTSS.Rows.Count;
                            var workSheet = package.Workbook.Worksheets.Add("Sheet1");
                            var wsBarChart = package.Workbook.Worksheets.Add("Data_Chart");
                            // workSheet.Cells[rowDetail, 1].LoadFromDataTable(dtDetail, true);
                            // workSheet.Cells[rowTss, 1].LoadFromDataTable(dtTSS, true);
                            dataTss(countTSS, countDT, dtTSS, dtDetail, rowTss, rowDetail, eRowTSS, workSheet, wsBarChart);
                        }
                        else
                        {
                            return BadRequest("ไม่พบข้อมูล");
                        }
                    }
                    else
                    {
                        Console.WriteLine("tss < 0");
                        if (dtDetail.Rows.Count > 0)
                        {
                            Console.WriteLine("Detail > 0 :2");
                            int countDT = dtDetail.Columns.Count + 1;
                            int rowDetail = 2;
                            var workSheet = package.Workbook.Worksheets.Add("Sheet1");
                            var wsBarChart = package.Workbook.Worksheets.Add("Data_Chart");
                            nonTss(dtDetail, workSheet, countDT, rowDetail, wsBarChart);
                        }
                        else
                        {
                            return BadRequest("ไม่พบข้อมูล");
                        }
                    }

                    package.Save();
                }
                stream.Position = 0;

                string excelName = $"MonthlyReport-{DateTime.Now.ToString("yyyyMMddHHmmssfff")}.xlsx";
                return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", excelName);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }

        /// Have data TSS
        private void dataTss(int countTSS, int countDT, DataTable dtTSS, DataTable dtDetail, int rowTss, int rowDetail, int eRowTSS, ExcelWorksheet ws, ExcelWorksheet wsBarChart)
        {
            ////////////////////////////////////////////// TSS
            int startIndexOfRowT = 14;
            string[] t_special_job = new string[countTSS];
            string[] t_extra_work = new string[countTSS];
            string[] t_non_work = new string[countTSS];
            setDataTSS(ws, startIndexOfRowT, dtTSS, t_special_job, t_extra_work, t_non_work);
            ////////////////////////////////////////////// Detail
            int startIndexOfRow = 2;
            string[] t_actual_time = new string[countDT];
            string[] t_standard = new string[countDT];
            setDataDetail(ws, startIndexOfRow, dtDetail, t_special_job, t_extra_work, t_non_work, t_actual_time, t_standard);
            // Set row 3:6
            ws.Cells[3, 2].Value = "Worker Performance";
            ws.Cells[4, 2].Value = "Operation Rate";
            ws.Cells[5, 2].Value = "Total Performance";
            ws.Cells[6, 2].Value = "Total efficiency";
            // Set header column 1
            ws.Cells[rowTss, 2].Value = "TSS";
            ws.Cells[rowDetail, 2].Value = "Detail";

            // Set style
            stylesheets("DT", rowDetail, 0, countDT, ws);
            stylesheets("TSS", rowTss, eRowTSS, countTSS - 1, ws);
            // Set BarChart
            setBarChart(wsBarChart, dtDetail);
        }
        private void setDataTSS(ExcelWorksheet ws, int startIndexOfRow, DataTable dt, string[] t_special_job, string[] t_extra_work, string[] t_non_work)
        {
            // Adding Headers 
            for (int i = 1; i < dt.Columns.Count; i++)
            {
                ws.Cells[startIndexOfRow, i + 1].Value = dt.Columns[i].ColumnName;
            }
            // Adding rows
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                startIndexOfRow++;
                for (int j = 1; j < dt.Columns.Count; j++)
                {
                    ws.Cells[startIndexOfRow, j + 1].Value = dt.Rows[i][j].ToString();
                    if (j != 1)
                    {
                        var query_extrawork = context.M_TSS.Where(x => x.tss_code == dt.Rows[i][0].ToString() && x.cal_extrawork == false).FirstOrDefault();
                        var query_jobspecial = context.M_TSS.Where(x => x.tss_code == dt.Rows[i][0].ToString() && x.cal_jobspecial == false).FirstOrDefault();

                        // if (dt.Rows[i][0].ToString() == "150")
                        if (query_extrawork != null)
                        {
                            t_special_job[j - 1] = dt.Rows[i][j].ToString();
                        }
                        // else if (dt.Rows[i][0].ToString() == "160")
                        else if (query_jobspecial != null)
                        {
                            t_extra_work[j - 1] = dt.Rows[i][j].ToString();
                        }
                        else if (dt.Rows[i][0].ToString() == "non")
                        {
                            t_non_work[j - 1] = dt.Rows[i][j].ToString();
                        }
                    }
                }
            }
        }
        private void setDataDetail(ExcelWorksheet ws, int startIndexOfRow, DataTable dt, string[] t_special_job, string[] t_extra_work, string[] t_non_work, string[] t_actual_time, string[] t_standard)
        {
            // Adding Headers 
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                ws.Cells[startIndexOfRow, (i + 2)].Value = dt.Columns[i].ColumnName;
            }
            // Adding rows
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                startIndexOfRow++;
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    ws.Cells[(startIndexOfRow + 4), (j + 2)].Value = dt.Rows[i][j].ToString().Replace("_", " ");
                    if (j != 0)
                    {
                        if (dt.Rows[i][0].ToString() == "Total_standard")
                        {
                            t_standard[j - 1] = dt.Rows[i][j].ToString();
                        }
                        else if (dt.Rows[i][0].ToString() == "Total_actual_time")
                        {
                            t_actual_time[j - 1] = dt.Rows[i][j].ToString();
                        }
                    }
                }
            }

            // sum of row 2:5
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    double wp = 0;
                    double or1 = 0, or2 = 0, sumor = 0;
                    double tp = 0, te = 0;
                    wp = (Convert.ToDouble(t_standard[j]) / Convert.ToDouble(t_actual_time[j])) * 100;

                    or1 = (Convert.ToDouble(t_actual_time[j]) + Convert.ToDouble(t_special_job[j + 1]) + Convert.ToDouble(t_extra_work[j + 1]));
                    or2 = (Convert.ToDouble(t_actual_time[j]) + Convert.ToDouble(t_special_job[j + 1]) + Convert.ToDouble(t_extra_work[j + 1]) + Convert.ToDouble(t_non_work[j + 1]));
                    sumor = (or1 / or2) * 100;

                    tp = (wp * sumor) / 100;
                    te = ((wp + 0) * sumor) / 100;

                    ws.Cells[3, (j + 3)].Value = wp;
                    ws.Cells[4, (j + 3)].Value = sumor;
                    ws.Cells[5, (j + 3)].Value = tp;
                    ws.Cells[6, (j + 3)].Value = te;

                    ws.Cells[3, (j + 3), 6, (j + 3)].Style.Numberformat.Format = "#0\\.00%";
                }
            }

        }

        /// non TSS
        private void nonTss(DataTable dtDetail, ExcelWorksheet ws, int countDT, int rowDetail, ExcelWorksheet wsBarChart)
        {
            ////////////////////////////////////////////// Detail
            int startIndexOfRow = 2;
            string[] t_actual_time = new string[countDT];
            string[] t_standard = new string[countDT];
            setDataDetail_nonTSS(ws, startIndexOfRow, dtDetail, t_actual_time, t_standard);
            // Set row 3:6
            ws.Cells[3, 2].Value = "Worker Performance";
            ws.Cells[4, 2].Value = "Operation Rate";
            ws.Cells[5, 2].Value = "Total Performance";
            ws.Cells[6, 2].Value = "Total efficiency";
            // Set header column 1
            ws.Cells[rowDetail, 2].Value = "Detail";

            // Set style
            stylesheets("DT", rowDetail, 0, countDT, ws);
            // Set BarChart
            setBarChart(wsBarChart, dtDetail);
        }
        private void setDataDetail_nonTSS(ExcelWorksheet ws, int startIndexOfRow, DataTable dt, string[] t_actual_time, string[] t_standard)
        {
            // Adding Headers 
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                ws.Cells[startIndexOfRow, (i + 2)].Value = dt.Columns[i].ColumnName;
            }
            // Adding rows
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                startIndexOfRow++;
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    ws.Cells[(startIndexOfRow + 4), (j + 2)].Value = dt.Rows[i][j].ToString().Replace("_", " ");
                    if (j != 0)
                    {
                        if (dt.Rows[i][0].ToString() == "Total_standard")
                        {
                            t_standard[j - 1] = dt.Rows[i][j].ToString();
                        }
                        else if (dt.Rows[i][0].ToString() == "Total_actual_time")
                        {
                            t_actual_time[j - 1] = dt.Rows[i][j].ToString();
                        }
                    }
                }
            }

            // sum of row 2:5
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    double wp = 0;
                    double or1 = 0, or2 = 0, sumor = 0;
                    double tp = 0, te = 0;
                    wp = (Convert.ToDouble(t_standard[j]) / Convert.ToDouble(t_actual_time[j])) * 100;

                    or1 = Convert.ToDouble(t_actual_time[j]);
                    or2 = Convert.ToDouble(t_actual_time[j]);
                    sumor = (or1 / or2) * 100;

                    tp = (wp * sumor) / 100;
                    te = ((wp + 0) * sumor) / 100;

                    ws.Cells[3, (j + 3)].Value = wp;
                    ws.Cells[4, (j + 3)].Value = sumor;
                    ws.Cells[5, (j + 3)].Value = tp;
                    ws.Cells[6, (j + 3)].Value = te;

                    ws.Cells[3, (j + 3), 6, (j + 3)].Style.Numberformat.Format = "#0\\.00%";
                }
            }
        }

        /// DataTable
        private DataTable getDetail(Post_Summary data)
        {
            var d1 = Convert.ToDateTime(data.start_date).ToString("yyyy-MM-dd");
            var d2 = Convert.ToDateTime(data.end_date).ToString("yyyy-MM-dd");

            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            string constr = this.configuration.GetConnectionString("ConnStr");
            using (SqlConnection con = new SqlConnection(constr))
            {
                // string query = "EXEC [dbo].[S_Monthly_Report_Detail] @start_date = N'" + d1 + "', @end_date = N'" + d2 + "', @wc_code = N'" + data.wc_code + "', @model_code = N'" + data.model_code + "', @shift_code = N'" + data.shift_code + "'";
                string query = @"EXEC [dbo].[S_Monthly_Report_Detail_2] @start_date = N'" + d1 + "', @end_date = N'" + d2 + "' "
                                    + " , @wc_code = N'" + data.wc_code + "' "
                                    + " , @model_code = N'" + data.model_code + "' "
                                    + " , @process_code = N'" + data.process_code + "' "
                                    + " , @cell_code = N'" + data.cell_code + "' "
                                    + " , @shift_code = N'" + data.shift_code + "' ";

                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Connection = con;
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        sda.Fill(dt);
                    }
                }
            }

            return dt;
        }
        private DataTable getTSS(Post_Summary data)
        {
            var startdate = Convert.ToDateTime(data.start_date).ToString("yyyy-MM-dd");
            var enddate = Convert.ToDateTime(data.end_date).ToString("yyyy-MM-dd");

            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            string constr = this.configuration.GetConnectionString("ConnStr");
            using (SqlConnection con = new SqlConnection(constr))
            {
                // string query = "EXEC [dbo].[S_Monthly_Report_TSS] @start_date = N'" + startdate + "', @end_date = N'" + enddate + "', @wc_code = N'" + data.wc_code + "', @model_code = N'" + data.model_code + "', @shift_code = N'" + data.shift_code + "'";
                string query = @"EXEC [dbo].[S_Monthly_Report_TSS_2] @start_date = N'" + startdate + "', @end_date = N'" + enddate + "' "
                    + " , @wc_code = N'" + data.wc_code + "' "
                    + " , @model_code = N'" + data.model_code + "' "
                    + " , @process_code = N'" + data.process_code + "' "
                    + " , @cell_code = N'" + data.cell_code + "' "
                    + " , @shift_code = N'" + data.shift_code + "' ";
                Console.WriteLine(query);
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Connection = con;
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        //sda.Fill(ds);
                        sda.Fill(dt);
                        if (dt.Rows.Count > 0)
                        {
                            DataRow dr = dt.NewRow();
                            dr["tss_code"] = "non";
                            dr["tss_info"] = "Non-working time";
                            decimal sum = 0;
                            for (int i = 0; i < dt.Columns.Count; i++)
                            {
                                if (i > 1)
                                {
                                    sum = 0;
                                    for (int j = 0; j < dt.Rows.Count; j++)
                                    {
                                        var query_cal = context.M_TSS.Where(x => x.tss_code == dt.Rows[j]["tss_code"].ToString() && 
                                            x.cal_extrawork == false && x.cal_jobspecial == false).FirstOrDefault();

                                        // if (dt.Rows[j]["tss_code"].ToString() != "150" && dt.Rows[j]["tss_code"].ToString() != "160")
                                        if (query_cal != null)
                                        {
                                            sum += (decimal)dt.Rows[j][i];
                                        }
                                    }
                                    dr[i] = sum;
                                }
                            }
                            dt.Rows.InsertAt(dr, 0);
                        }
                    }
                }
            }
            return dt;
        }

        /// Set excel
        private void stylesheets(string name, int row, int eRowTSS, int endCol, ExcelWorksheet ws)
        {
            using (var range = ws.Cells[row, 2, row, endCol])  //Address "A4:..4"
            {
                range.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                range.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                range.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                range.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                range.Style.Font.Name = "Calibri";
                range.Style.Font.Size = 11;
                range.Style.Font.Bold = true;
                range.Style.WrapText = true;
                range.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                range.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            }
            ws.Cells[row, 2, row, endCol].Style.Fill.PatternType = ExcelFillStyle.Solid;
            Color colFromHex = System.Drawing.ColorTranslator.FromHtml("#A9D08E");
            ws.Cells[row, 2, row, endCol].Style.Fill.BackgroundColor.SetColor(colFromHex);

            // Set colunm width
            for (int col = 3; col <= endCol; col++)
            {
                ws.Column(col).Width = 10;
            }
            ws.Column(2).Width = 18;

            if (name == "DT")
            {   // detail
                using (var range = ws.Cells[2, 2, 11, endCol])  //Address "A4:..4"
                {
                    range.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    range.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                }
                ws.Cells[6, 2, 6, endCol].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                ws.Cells[11, 2, 11, endCol].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                ws.Cells[3, 3, 11, endCol].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
            }
            else
            { // tss
                int endRow = (eRowTSS + row);
                using (var range = ws.Cells[row, 2, endRow, endCol])  //Address "A4:..4"
                {
                    range.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    range.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                }
                ws.Cells[endRow, 2, endRow, endCol].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                ws.Cells[row + 1, 3, endRow, endCol].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
            }
        }
        private void setBarChart(ExcelWorksheet ws, DataTable dt)
        {
            // Adding rows
            int start_row = 1;
            int start_col = 0;
            for (int i = 0; i < dt.Rows.Count - 1; i++)
            {
                start_row++;
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    if (j == 0)
                    {
                        ws.Cells[(start_row), (j + 1)].Value = dt.Rows[i][j].ToString().Replace("_", " ");
                    }
                    else if (j == 1)
                    {
                        if (dt.Rows[i][0].ToString() == "PF_Loss")
                        {
                            ws.Cells[(start_row), (j + 2)].Value = (decimal)(dt.Rows[i][j]);
                        }
                        else if (dt.Rows[i][0].ToString() == "Total_standard")
                        {
                            ws.Cells[(start_row), (j + 2)].Value = (decimal)(dt.Rows[i][j]);
                        }
                        else
                        {
                            ws.Cells[(start_row), (j + 1)].Value = (decimal)(dt.Rows[i][j]);
                        }
                        start_col = 6;
                    }
                    else
                    {
                        ws.Cells[(start_row), start_col].Value = dt.Rows[i][0].ToString().Replace("_", " ");
                        if (dt.Rows[i][0].ToString() == "PF_Loss")
                        {
                            ws.Cells[(start_row), start_col + 2].Value = (decimal)(dt.Rows[i][j]);
                        }
                        else if (dt.Rows[i][0].ToString() == "Total_standard")
                        {
                            ws.Cells[(start_row), start_col + 2].Value = (decimal)(dt.Rows[i][j]);
                        }
                        else
                        {
                            ws.Cells[(start_row), start_col + 1].Value = (decimal) (dt.Rows[i][j]);
                        }
                        start_col += 5;
                    }
                }
            }
            // Adding Headers
            int start_bar = 1;
            int col = 0;
            for (int i = 1; i < dt.Columns.Count; i++)
            {
                if (i > 1)
                {
                    ws.Cells[start_bar, col].Value = "ใช้สำหรับกราฟ " + dt.Columns[i].ColumnName;
                    using (var range = ws.Cells[start_bar + 1, col, start_bar + 4, col + 2])  //Address "A4:..4"
                    {
                        range.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                        range.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                        range.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                        range.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                        range.AutoFitColumns();
                    }
                    col += 5;
                }
                else
                {
                    ws.Cells[start_bar, i].Value = "ใช้สำหรับกราฟ " + dt.Columns[i].ColumnName;
                    using (var range = ws.Cells[start_bar + 1, col + 1, start_bar + 4, col + 3])  //Address "A4:..4"
                    {
                        range.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                        range.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                        range.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                        range.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                        range.AutoFitColumns();
                    }
                    col = 6;
                }
            }
            // End data bar chart
        }

    }
}

// var allowedStatus = new[]{ "A", "B", "C" };
// var filteredOrders = orders.Order.Where(o => allowedStatus.Contains(o.StatusCode));
// or in query syntax:

// var filteredOrders = from order in orders.Order
//                      where allowedStatus.Contains(order.StatusCode)
//                      select order;