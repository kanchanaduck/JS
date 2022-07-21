using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System;
using Microsoft.EntityFrameworkCore;
using System.IO;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.Globalization;
using System.Drawing;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Reflection;

namespace JKSAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SummaryController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly DBContext context;
        public SummaryController(IConfiguration config, DBContext context)
        {
            _config = config;
            this.context = context;
        }
        /// <summary>
        /// Add SummaryAll.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /Summary/SummaryAll/Add
        ///     {
        ///         {
        ///           "date_input": "2021-03-31",
        ///           "wc_code": "WC-004",
        ///           "model_code": "M-013",
        ///           "process_code": "P-037",
        ///           "cell_code": "C-001",
        ///           "shift_code": "S-002",
        ///           "production_shift": "2",
        ///           "block_group_code": "1",
        ///           "gb_cell_code": "G31",
        ///           "op_meister": 24,
        ///           "sp_meister": 3,
        ///           "manpower": 27,
        ///           "manpower_attendance": 25,
        ///           "manpower_absent": 2,
        ///           "extra_work": 0,
        ///           "job_special": 0,
        ///           "total_extra_job": 0,
        ///           "actual_output": 0,
        ///           "reject_off": 0,
        ///           "working_time": 0,
        ///           "working_man": 0,
        ///           "overtime": 0,
        ///           "accident": 0,
        ///           "manpower_out_flow": 0,
        ///           "manpower_in_flow": 0,
        ///           "actual_working_man": 12960,
        ///           "detail_working": 12960,
        ///           "unknown_time": 0,
        ///           "worker_performance": "0.00",
        ///           "operation_rate": "100.00",
        ///           "total_performance": "0.00",
        ///           "comment": "",
        ///           "ot_60_qty": 0,
        ///           "ot_60_total": 0,
        ///           "ot_120_qty": 0,
        ///           "ot_120_total": 0,
        ///           "ot_150_qty": 0,
        ///           "ot_150_total": 0,
        ///           "ot_other_qty": 0,
        ///           "ot_other_min": 0,
        ///           "ot_other_total": 0,
        ///           "clinic_30_qty": 0,
        ///           "clinic_30_total": 0,
        ///           "clinic_60_qty": 0,
        ///           "clinic_60_total": 0,
        ///           "clinic_90_qty": 0,
        ///           "clinic_90_total": 0,
        ///           "clinic_120_qty": 0,
        ///           "clinic_120_total": 0,
        ///           "clinic_other_qty": 0,
        ///           "clinic_other_min": 0,
        ///           "clinic_other_total": 0,
        ///           "leave_halfe_qty": 0,
        ///           "leave_halfe_min": 0,
        ///           "leave_halfe_total": 0,
        ///           "out_flow_qty": 0,
        ///           "out_flow_min": 0,
        ///           "out_flow_total": 0,
        ///           "in_flow_qty": 0,
        ///           "in_flow_min": 0,
        ///           "in_flow_total": 0,
        ///           "total_overtime": 0,
        ///           "standard_time": 0,
        ///           "actual_time": 12960,
        ///           "total_time": 12960,
        ///           "actual_time_op_sp": 12960,
        ///           "total_time_op_sp": 12960,
        ///           "userid": "admin",
        ///           "ot_60_qty_sp": 0,
        ///           "ot_120_qty_sp": 0,
        ///           "ot_150_qty_sp": 0,
        ///           "ot_other_qty_sp": 0,
        ///           "clinic_30_qty_sp": 0,
        ///           "clinic_60_qty_sp": 0,
        ///           "clinic_90_qty_sp": 0,
        ///           "clinic_120_qty_sp": 0,
        ///           "clinic_other_qty_sp": 0,
        ///           "leave_halfe_qty_sp": 0,
        ///           "out_flow_qty_sp": 0,
        ///           "in_flow_qty_sp": 0,
        ///           "manpower_attendance_sp": 25,
        ///           "manpower_absent_sp": 2,
        ///           "working_man_op_sp": 0,
        ///           "overtime_op_sp": 0,
        ///           "accident_op_sp": 0,
        ///           "manpower_out_flow_op_sp": 0,
        ///           "manpower_in_flow_op_sp": 0,
        ///           "actual_working_man_op_sp": 12960,
        ///           "detail_working_op_sp": 12960,
        ///           "unknown_time_op_sp": 0,
        ///           "worker_performance_op_sp": "0.00",
        ///           "operation_rate_op_sp": "100.00",
        ///           "total_performance_op_sp": "0.00"
        ///         }
        ///     }
        ///
        /// </remarks>
        [HttpPost]
        [Route("SummaryAll/Add")]
        public async Task<IActionResult> AddSummaryAll([FromBody] T_SUMMARY_DATA data)
        {
            using (var dbContextTransaction = context.Database.BeginTransaction())
            {
                try
                {
                    var vaules_jks = await context.T_SUMMARY_JKS.FirstOrDefaultAsync
                    (x => x.date_input == data.date_input
                    && x.wc_code == data.wc_code
                    && x.model_code == data.model_code
                    && x.process_code == data.process_code
                    && x.cell_code == data.cell_code
                    && x.shift_code == data.shift_code
                    && x.production_shift == data.production_shift);

                    if (vaules_jks == null)
                    {
                        double tp = 0;
                        double worker_performance = 0, operation_rate = 0;
                        worker_performance = ((Convert.ToDouble(data.standard_time) / Convert.ToDouble(data.total_time)) * 100);
                        operation_rate = ((Convert.ToDouble(data.total_time) + Convert.ToDouble(data.extra_work) + Convert.ToDouble(data.job_special)) / Convert.ToDouble(data.detail_working)) * 100;
                        tp = (worker_performance * operation_rate) / 100;

                        double tp_op_sp = 0;
                        double worker_performance_op_sp = 0, operation_rate_op_sp = 0;
                        worker_performance_op_sp = ((Convert.ToDouble(data.standard_time_op_sp) / Convert.ToDouble(data.total_time_op_sp)) * 100);
                        operation_rate_op_sp = ((Convert.ToDouble(data.total_time_op_sp) + Convert.ToDouble(data.extra_work) + Convert.ToDouble(data.job_special)) / Convert.ToDouble(data.detail_working_op_sp)) * 100;
                        tp_op_sp = (worker_performance_op_sp * operation_rate_op_sp) / 100;


                        Console.WriteLine("1");
                        T_SUMMARY_JKS data_jks = new T_SUMMARY_JKS();
                        data_jks.date_input = data.date_input;
                        data_jks.wc_code = data.wc_code;
                        data_jks.model_code = data.model_code;
                        data_jks.process_code = data.process_code;
                        data_jks.cell_code = data.cell_code;
                        data_jks.shift_code = data.shift_code;
                        data_jks.production_shift = data.production_shift;

                        data_jks.block_group_code = data.block_group_code;
                        data_jks.gb_cell_code = data.gb_cell_code;
                        data_jks.op_meister = data.op_meister;
                        data_jks.sp_meister = data.sp_meister;
                        //
                        data_jks.manpower = data.op_meister + data.sp_meister;
                        //
                        data_jks.manpower_attendance = data.manpower_attendance;
                        data_jks.manpower_absent = data.manpower_absent;

                        data_jks.manpower_attendance_sp = data.manpower_attendance_sp;
                        data_jks.manpower_absent_sp = data.manpower_absent_sp;
                        //
                        data_jks.extra_work = data.extra_work;
                        data_jks.job_special = data.job_special;
                        data_jks.total_extra_job = data.total_extra_job;
                        data_jks.actual_output = data.actual_output;
                        data_jks.reject_off = data.reject_off;
                        data_jks.working_time = data.working_time;
                        data_jks.working_man = data.working_man;
                        data_jks.overtime = data.overtime;
                        data_jks.accident = data.accident;
                        data_jks.manpower_out_flow = data.manpower_out_flow;
                        data_jks.manpower_in_flow = data.manpower_in_flow;
                        data_jks.actual_working_man = data.actual_working_man;
                        data_jks.detail_working = data.detail_working;
                        data_jks.unknown_time = data.unknown_time;
                        data_jks.worker_performance = Math.Round(worker_performance, 2).ToString();
                        data_jks.operation_rate = Math.Round(operation_rate, 2).ToString();
                        data_jks.total_performance = Math.Round(tp, 2).ToString();
                        data_jks.comment = data.comment;
                        data_jks.working_man_op_sp = data.working_man_op_sp;
                        data_jks.overtime_op_sp = data.overtime_op_sp;
                        data_jks.accident_op_sp = data.accident_op_sp;
                        data_jks.manpower_out_flow_op_sp = data.manpower_out_flow_op_sp;
                        data_jks.manpower_in_flow_op_sp = data.manpower_in_flow_op_sp;
                        data_jks.actual_working_man_op_sp = data.actual_working_man_op_sp;
                        data_jks.detail_working_op_sp = data.detail_working_op_sp;
                        data_jks.unknown_time_op_sp = data.unknown_time_op_sp;
                        data_jks.worker_performance_op_sp = Math.Round(worker_performance_op_sp, 2).ToString();
                        data_jks.operation_rate_op_sp = Math.Round(operation_rate_op_sp, 2).ToString();
                        data_jks.total_performance_op_sp = Math.Round(tp_op_sp, 2).ToString();

                        data_jks.ins_by = data.userid;
                        data_jks.ins_date = DateTime.Now;
                        data_jks.update_by = null;
                        data_jks.update_date = DateTime.Now;

                        context.Add(data_jks);
                        await context.SaveChangesAsync();
                    }
                    else
                    {
                        double tp = 0;
                        double worker_performance = 0, operation_rate = 0;
                        worker_performance = ((Convert.ToDouble(data.standard_time) / Convert.ToDouble(data.total_time)) * 100);
                        operation_rate = ((Convert.ToDouble(data.total_time) + Convert.ToDouble(data.extra_work) + Convert.ToDouble(data.job_special)) / Convert.ToDouble(data.detail_working)) * 100;
                        tp = (worker_performance * operation_rate) / 100;

                        // worker_performance, operation_rate, total_performance    OP + SP
                        double tp_op_sp = 0;
                        double worker_performance_op_sp = 0, operation_rate_op_sp = 0;
                        worker_performance_op_sp = ((Convert.ToDouble(data.standard_time_op_sp) / Convert.ToDouble(data.total_time_op_sp)) * 100);
                        operation_rate_op_sp = ((Convert.ToDouble(data.total_time_op_sp) + Convert.ToDouble(data.extra_work) + Convert.ToDouble(data.job_special)) / Convert.ToDouble(data.detail_working_op_sp)) * 100;
                        tp_op_sp = (worker_performance_op_sp * operation_rate_op_sp) / 100;

                        // Console.WriteLine("worker_performance: " + worker_performance.ToString());
                        // Console.WriteLine("operation_rate: " + operation_rate.ToString());
                        // Console.WriteLine(Math.Round(tp, 2).ToString());

                        vaules_jks.block_group_code = data.block_group_code;
                        vaules_jks.gb_cell_code = data.gb_cell_code;
                        vaules_jks.op_meister = data.op_meister;
                        vaules_jks.sp_meister = data.sp_meister;
                        //
                        vaules_jks.manpower = data.op_meister + data.sp_meister;
                        //
                        vaules_jks.manpower_attendance = data.manpower_attendance;
                        vaules_jks.manpower_absent = data.manpower_absent;

                        vaules_jks.manpower_attendance_sp = data.manpower_attendance_sp;
                        vaules_jks.manpower_absent_sp = data.manpower_absent_sp;
                        //
                        vaules_jks.extra_work = data.extra_work;
                        vaules_jks.job_special = data.job_special;
                        vaules_jks.total_extra_job = data.total_extra_job;
                        vaules_jks.actual_output = data.actual_output;
                        vaules_jks.reject_off = data.reject_off;
                        vaules_jks.working_time = data.working_time;
                        vaules_jks.working_man = data.working_man;
                        vaules_jks.overtime = data.overtime;
                        vaules_jks.accident = data.accident;
                        vaules_jks.manpower_out_flow = data.manpower_out_flow;
                        vaules_jks.manpower_in_flow = data.manpower_in_flow;
                        vaules_jks.actual_working_man = data.actual_working_man;
                        vaules_jks.detail_working = data.detail_working;
                        vaules_jks.unknown_time = data.unknown_time;
                        vaules_jks.worker_performance = Math.Round(worker_performance, 2).ToString();
                        vaules_jks.operation_rate = Math.Round(operation_rate, 2).ToString();
                        vaules_jks.total_performance = Math.Round(tp, 2).ToString();
                        vaules_jks.comment = data.comment;
                        vaules_jks.working_man_op_sp = data.working_man_op_sp;
                        vaules_jks.overtime_op_sp = data.overtime_op_sp;
                        vaules_jks.accident_op_sp = data.accident_op_sp;
                        vaules_jks.manpower_out_flow_op_sp = data.manpower_out_flow_op_sp;
                        vaules_jks.manpower_in_flow_op_sp = data.manpower_in_flow_op_sp;
                        vaules_jks.actual_working_man_op_sp = data.actual_working_man_op_sp;
                        vaules_jks.detail_working_op_sp = data.detail_working_op_sp;
                        vaules_jks.unknown_time_op_sp = data.unknown_time_op_sp;
                        vaules_jks.worker_performance_op_sp = Math.Round(worker_performance_op_sp, 2).ToString();
                        vaules_jks.operation_rate_op_sp = Math.Round(operation_rate_op_sp, 2).ToString();
                        vaules_jks.total_performance_op_sp = Math.Round(tp_op_sp, 2).ToString();

                        vaules_jks.update_by = data.userid;
                        vaules_jks.update_date = DateTime.Now;

                        await context.SaveChangesAsync();
                    }

                    var vaules_ot = await context.T_SUMMARY_OT.FirstOrDefaultAsync
                    (x => x.date_input == data.date_input
                        && x.wc_code == data.wc_code
                        && x.model_code == data.model_code
                        && x.process_code == data.process_code
                        && x.cell_code == data.cell_code
                        && x.shift_code == data.shift_code
                        && x.production_shift == data.production_shift);

                    if (vaules_ot == null)
                    {
                        Console.WriteLine("OT 1");
                        T_SUMMARY_OT data_ot = new T_SUMMARY_OT();
                        data_ot.date_input = data.date_input;
                        data_ot.wc_code = data.wc_code;
                        data_ot.model_code = data.model_code;
                        data_ot.process_code = data.process_code;
                        data_ot.cell_code = data.cell_code;
                        data_ot.shift_code = data.shift_code;
                        data_ot.production_shift = data.production_shift;

                        data_ot.block_group_code = data.block_group_code;
                        data_ot.gb_cell_code = data.gb_cell_code;
                        data_ot.ot_60_qty = data.ot_60_qty;
                        data_ot.ot_60_total = data.ot_60_total;
                        data_ot.ot_120_qty = data.ot_120_qty;
                        data_ot.ot_120_total = data.ot_120_total;
                        data_ot.ot_150_qty = data.ot_150_qty;
                        data_ot.ot_150_total = data.ot_150_total;
                        data_ot.ot_other_qty = data.ot_other_qty;
                        data_ot.ot_other_min = data.ot_other_min;
                        data_ot.ot_other_total = data.ot_other_total;
                        data_ot.clinic_30_qty = data.clinic_30_qty;
                        data_ot.clinic_30_total = data.clinic_30_total;
                        data_ot.clinic_60_qty = data.clinic_60_qty;
                        data_ot.clinic_60_total = data.clinic_60_total;
                        data_ot.clinic_90_qty = data.clinic_90_qty;
                        data_ot.clinic_90_total = data.clinic_90_total;
                        data_ot.clinic_120_qty = data.clinic_120_qty;
                        data_ot.clinic_120_total = data.clinic_120_total;
                        data_ot.clinic_other_qty = data.clinic_other_qty;
                        data_ot.clinic_other_min = data.clinic_other_min;
                        data_ot.clinic_other_total = data.clinic_other_total;
                        data_ot.leave_halfe_qty = data.leave_halfe_qty;
                        data_ot.leave_halfe_min = data.leave_halfe_min;
                        data_ot.leave_halfe_total = data.leave_halfe_total;
                        data_ot.out_flow_qty = data.out_flow_qty;
                        data_ot.out_flow_min = data.out_flow_min;
                        data_ot.out_flow_total = data.out_flow_total;
                        data_ot.in_flow_qty = data.in_flow_qty;
                        data_ot.in_flow_min = data.in_flow_min;
                        data_ot.in_flow_total = data.in_flow_total;
                        data_ot.total_overtime = data.total_overtime;
                        data_ot.standard_time = data.standard_time;
                        data_ot.standard_time_op_sp = data.standard_time_op_sp;
                        data_ot.actual_time = data.actual_time;
                        data_ot.total_time = data.total_time;
                        data_ot.actual_time_op_sp = data.actual_time_op_sp;
                        data_ot.total_time_op_sp = data.total_time_op_sp;
                        data_ot.ins_by = data.userid;
                        data_ot.ins_date = DateTime.Now;
                        data_ot.update_by = null;
                        data_ot.update_date = DateTime.Now;
                        data_ot.ot_60_qty_sp = data.ot_60_qty_sp;
                        data_ot.ot_120_qty_sp = data.ot_120_qty_sp;
                        data_ot.ot_150_qty_sp = data.ot_150_qty_sp;
                        data_ot.ot_other_qty_sp = data.ot_other_qty_sp;
                        data_ot.clinic_30_qty_sp = data.clinic_30_qty_sp;
                        data_ot.clinic_60_qty_sp = data.clinic_60_qty_sp;
                        data_ot.clinic_90_qty_sp = data.clinic_90_qty_sp;
                        data_ot.clinic_120_qty_sp = data.clinic_120_qty_sp;
                        data_ot.clinic_other_qty_sp = data.clinic_other_qty_sp;
                        data_ot.leave_halfe_qty_sp = data.leave_halfe_qty_sp;
                        data_ot.out_flow_qty_sp = data.out_flow_qty_sp;
                        data_ot.in_flow_qty_sp = data.in_flow_qty_sp;

                        context.Add(data_ot);
                        await context.SaveChangesAsync();
                    }
                    else
                    {
                        Console.WriteLine("OT 2");
                        vaules_ot.block_group_code = data.block_group_code;
                        vaules_ot.gb_cell_code = data.gb_cell_code;
                        vaules_ot.ot_60_qty = data.ot_60_qty;
                        vaules_ot.ot_60_total = data.ot_60_total;
                        vaules_ot.ot_120_qty = data.ot_120_qty;
                        vaules_ot.ot_120_total = data.ot_120_total;
                        vaules_ot.ot_150_qty = data.ot_150_qty;
                        vaules_ot.ot_150_total = data.ot_150_total;
                        vaules_ot.ot_other_qty = data.ot_other_qty;
                        vaules_ot.ot_other_min = data.ot_other_min;
                        vaules_ot.ot_other_total = data.ot_other_total;
                        vaules_ot.clinic_30_qty = data.clinic_30_qty;
                        vaules_ot.clinic_30_total = data.clinic_30_total;
                        vaules_ot.clinic_60_qty = data.clinic_60_qty;
                        vaules_ot.clinic_60_total = data.clinic_60_total;
                        vaules_ot.clinic_90_qty = data.clinic_90_qty;
                        vaules_ot.clinic_90_total = data.clinic_90_total;
                        vaules_ot.clinic_120_qty = data.clinic_120_qty;
                        vaules_ot.clinic_120_total = data.clinic_120_total;
                        vaules_ot.clinic_other_qty = data.clinic_other_qty;
                        vaules_ot.clinic_other_min = data.clinic_other_min;
                        vaules_ot.clinic_other_total = data.clinic_other_total;
                        vaules_ot.leave_halfe_qty = data.leave_halfe_qty;
                        vaules_ot.leave_halfe_min = data.leave_halfe_min;
                        vaules_ot.leave_halfe_total = data.leave_halfe_total;
                        vaules_ot.out_flow_qty = data.out_flow_qty;
                        vaules_ot.out_flow_min = data.out_flow_min;
                        vaules_ot.out_flow_total = data.out_flow_total;
                        vaules_ot.in_flow_qty = data.in_flow_qty;
                        vaules_ot.in_flow_min = data.in_flow_min;
                        vaules_ot.in_flow_total = data.in_flow_total;
                        vaules_ot.total_overtime = data.total_overtime;
                        vaules_ot.standard_time = data.standard_time;
                        vaules_ot.standard_time_op_sp = data.standard_time_op_sp;
                        vaules_ot.actual_time = data.actual_time;
                        vaules_ot.total_time = data.total_time;
                        vaules_ot.actual_time_op_sp = data.actual_time_op_sp;
                        vaules_ot.total_time_op_sp = data.total_time_op_sp;
                        vaules_ot.update_by = data.userid;
                        vaules_ot.update_date = DateTime.Now;
                        vaules_ot.ot_60_qty_sp = data.ot_60_qty_sp;
                        vaules_ot.ot_120_qty_sp = data.ot_120_qty_sp;
                        vaules_ot.ot_150_qty_sp = data.ot_150_qty_sp;
                        vaules_ot.ot_other_qty_sp = data.ot_other_qty_sp;
                        vaules_ot.clinic_30_qty_sp = data.clinic_30_qty_sp;
                        vaules_ot.clinic_60_qty_sp = data.clinic_60_qty_sp;
                        vaules_ot.clinic_90_qty_sp = data.clinic_90_qty_sp;
                        vaules_ot.clinic_120_qty_sp = data.clinic_120_qty_sp;
                        vaules_ot.clinic_other_qty_sp = data.clinic_other_qty_sp;
                        vaules_ot.leave_halfe_qty_sp = data.leave_halfe_qty_sp;
                        vaules_ot.out_flow_qty_sp = data.out_flow_qty_sp;
                        vaules_ot.in_flow_qty_sp = data.in_flow_qty_sp;

                        await context.SaveChangesAsync();
                    }

                    dbContextTransaction.Commit();
                    return Ok();
                }
                catch (Exception ex)
                {
                    dbContextTransaction.Rollback();
                    Console.WriteLine(ex);
                    return BadRequest("ไม่สามารถบันทึกข้อมูลได้ : " + ex);
                }
            }
        }

        /// <summary>
        /// Search SummaryAll.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /Summary/SummaryAll/Search
        ///     {
        ///         "date_input": "2021-01-13",
        ///         "wc_code": "string",
        ///         "model_code": "string",
        ///         "process_code": "string",
        ///         "cell_code": "string",
        ///         "shift_code": "string",
        ///         "production_shift": "string",
        ///         "block_group_code": "string",
        ///         "gb_cell_code": "string"
        ///     }
        ///
        /// </remarks>
        [HttpPost]
        [Route("SummaryAll/Search")]
        public async Task<ActionResult> SummaryAll(T_SUMMARY_DATA data)
        {
            var tss = await (from e in context.V_SUMMARY_TSS
                             where e.date_input == data.date_input
                                    && e.wc_code == data.wc_code
                                    && e.model_code == data.model_code
                                    && e.process_code == data.process_code
                                    && e.cell_code == data.cell_code
                                    && e.shift_code == data.shift_code
                                    && e.production_shift == data.production_shift
                                    && e.block_group_code == data.block_group_code
                                    && e.gb_cell_code == data.gb_cell_code
                             select new
                             {
                                 tss_code = e.tss_code,
                                 extra_work_no = e.extra_work_no,
                                 manpower_pers = e.manpower_pers,
                                 tss_min = e.tss_min,
                                 mc_qty = e.mc_qty,
                                 loss_time = e.loss_time
                             }).ToListAsync();


            var result = await (from e in context.V_SUMMARY_JKS_OT
                                where e.date_input == data.date_input
                                        && e.wc_code == data.wc_code
                                        && e.model_code == data.model_code
                                        && e.process_code == data.process_code
                                        && e.cell_code == data.cell_code
                                        && e.shift_code == data.shift_code
                                        && e.production_shift == data.production_shift
                                        && e.block_group_code == data.block_group_code
                                        && e.gb_cell_code == data.gb_cell_code
                                select new
                                {
                                    production_shift = e.production_shift,
                                    block_group_code = e.block_group_code,
                                    gb_cell_code = e.gb_cell_code,

                                    op_meister = e.op_meister,
                                    sp_meister = e.sp_meister,
                                    manpower = e.manpower,
                                    manpower_attendance = e.manpower_attendance,
                                    manpower_absent = e.manpower_absent,
                                    extra_work = e.extra_work,
                                    job_special = e.job_special,
                                    total_extra_job = e.total_extra_job,
                                    // actual_output = e.actual_output,
                                    reject_off = e.reject_off,
                                    working_time = e.working_time,
                                    working_man = e.working_man,
                                    overtime = e.overtime,
                                    accident = e.accident,
                                    manpower_out_flow = e.manpower_out_flow,
                                    manpower_in_flow = e.manpower_in_flow,
                                    actual_working_man = e.actual_working_man,
                                    detail_working = e.detail_working,
                                    unknown_time = e.unknown_time,
                                    worker_performance = e.worker_performance,
                                    operation_rate = e.operation_rate,
                                    total_performance = e.total_performance,
                                    comment = e.comment,

                                    ot_60_qty = e.ot_60_qty,
                                    ot_60_total = e.ot_60_total,
                                    ot_120_qty = e.ot_120_qty,
                                    ot_120_total = e.ot_120_total,
                                    ot_150_qty = e.ot_150_qty,
                                    ot_150_total = e.ot_150_total,
                                    ot_other_qty = e.ot_other_qty,
                                    ot_other_min = e.ot_other_min,
                                    ot_other_total = e.ot_other_total,
                                    clinic_30_qty = e.clinic_30_qty,
                                    clinic_30_total = e.clinic_30_total,
                                    clinic_60_qty = e.clinic_60_qty,
                                    clinic_60_total = e.clinic_60_total,
                                    clinic_90_qty = e.clinic_90_qty,
                                    clinic_90_total = e.clinic_90_total,
                                    clinic_120_qty = e.clinic_120_qty,
                                    clinic_120_total = e.clinic_120_total,
                                    clinic_other_qty = e.clinic_other_qty,
                                    clinic_other_min = e.clinic_other_min,
                                    clinic_other_total = e.clinic_other_total,
                                    leave_halfe_qty = e.leave_halfe_qty,
                                    leave_halfe_min = e.leave_halfe_min,
                                    leave_halfe_total = e.leave_halfe_total,
                                    out_flow_qty = e.out_flow_qty,
                                    out_flow_min = e.out_flow_min,
                                    out_flow_total = e.out_flow_total,
                                    in_flow_qty = e.in_flow_qty,
                                    in_flow_min = e.in_flow_min,
                                    in_flow_total = e.in_flow_total,
                                    total_overtime = e.total_overtime,
                                    // standard_time = e.standard_time,
                                    actual_time = e.actual_time,
                                    total_time = e.total_time,
                                    actual_time_op_sp = e.actual_time_op_sp,
                                    total_time_op_sp = e.total_time_op_sp,
                                    t_summary_tss = tss,

                                    ot_60_qty_sp = e.ot_60_qty_sp,
                                    ot_120_qty_sp = e.ot_120_qty_sp,
                                    ot_150_qty_sp = e.ot_150_qty_sp,
                                    ot_other_qty_sp = e.ot_other_qty_sp,
                                    clinic_30_qty_sp = e.clinic_30_qty_sp,
                                    clinic_60_qty_sp = e.clinic_60_qty_sp,
                                    clinic_90_qty_sp = e.clinic_90_qty_sp,
                                    clinic_120_qty_sp = e.clinic_120_qty_sp,
                                    clinic_other_qty_sp = e.clinic_other_qty_sp,
                                    leave_halfe_qty_sp = e.leave_halfe_qty_sp,
                                    out_flow_qty_sp = e.out_flow_qty_sp,
                                    in_flow_qty_sp = e.in_flow_qty_sp,

                                    manpower_attendance_sp = e.manpower_attendance_sp,
                                    manpower_absent_sp = e.manpower_absent_sp,
                                    working_man_op_sp = e.working_man_op_sp,
                                    overtime_op_sp = e.overtime_op_sp,
                                    accident_op_sp = e.accident_op_sp,
                                    manpower_out_flow_op_sp = e.manpower_out_flow_op_sp,
                                    manpower_in_flow_op_sp = e.manpower_in_flow_op_sp,
                                    actual_working_man_op_sp = e.actual_working_man_op_sp,
                                    detail_working_op_sp = e.detail_working_op_sp,
                                    unknown_time_op_sp = e.unknown_time_op_sp,
                                    worker_performance_op_sp = e.worker_performance_op_sp,
                                    operation_rate_op_sp = e.operation_rate_op_sp,
                                    total_performance_op_sp = e.total_performance_op_sp,

                                }).FirstOrDefaultAsync();

            if (result == null)
            {
                return NotFound("ไม่พบข้อมูล");
            }
            else
            {
                return Ok(result);
            }
        }

        /// <summary>
        /// Search ST SummaryAll.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /Summary/SummaryAll/SearchST
        ///     {
        ///         "date_input": "2021-02-08",
        ///         "wc_code": "WC-004",
        ///         "model_code": "M-009",
        ///         "process_code": "P-037",
        ///         "cell_code": "C-001",
        ///         "shift_code": "S-001",
        ///         "production_shift": "2",
        ///         "block_group_code": "1",
        ///         "gb_cell_code": "G33"
        ///     }
        ///
        /// </remarks>
        [HttpPost]
        [Route("SummaryAll/SearchST")]
        public async Task<ActionResult> SearchST(T_SUMMARY_DATA data)
        {
            var chk_result = await context.V_SUMMARY_JKS_OT.Where(e => 
                                e.date_input == data.date_input
                                && e.wc_code == data.wc_code
                                && e.model_code == data.model_code
                                && e.process_code == data.process_code
                                && e.cell_code == data.cell_code
                                && e.shift_code == data.shift_code
                                && e.production_shift == data.production_shift
                                && e.block_group_code == data.block_group_code
                                && e.gb_cell_code == data.gb_cell_code
                                ).ToListAsync();
            // Console.WriteLine(data.date_input);
            // Console.WriteLine(data.wc_code);
            // Console.WriteLine(data.model_code);
            // Console.WriteLine(data.process_code);
            // Console.WriteLine(data.cell_code);
            // Console.WriteLine(data.shift_code);
            // Console.WriteLine(data.production_shift);
            // Console.WriteLine(data.block_group_code);
            // Console.WriteLine(data.gb_cell_code);
            var p = await (from e in context.M_PROCESS
                           where e.process_code == data.process_code
                           select new
                           {
                               process_detail = e.process_detail
                           }).FirstOrDefaultAsync();

            var c = await (from e in context.M_CELL
                           where e.cell_code == data.cell_code
                           select new
                           {
                               cell_detail = e.cell_detail
                           }).FirstOrDefaultAsync();

            if (chk_result.Count > 0)
            {
                var d1 = Convert.ToDateTime(data.date_input).ToString("yyyy-MM-dd") + " 08:00:00.000";
                var d2 = Convert.ToDateTime(data.date_input).AddDays(1).ToString("yyyy-MM-dd") + " 07:59:59.999";

                var result_ST = await context.S_SUMMARY_OUTPUT.FromSqlInterpolated(@$"Exec S_SUMMARY_OUTPUT 
                        @process_name = { p.process_detail }, 
                        @date_1 = { d1 }, @date_2 = { d2 }, 
                        @shift = { data.production_shift } ,
                        @model = { data.model_code }").ToListAsync();

                if (result_ST.Count > 0)
                {
                    return Ok(result_ST.Where(e => e.cell == c.cell_detail.ToString()).FirstOrDefault());
                }
                else
                {
                    return NotFound("ไม่พบข้อมูล");
                }
            }
            else
            {
                Console.WriteLine("else");
                try
                {
                    List<S_SUMMARY_OUTPUT> a = new List<S_SUMMARY_OUTPUT>();
                    a.Add(new S_SUMMARY_OUTPUT
                    {
                        cell = c.cell_detail,
                        count_1 = chk_result[0].actual_output,
                        qty_1 = chk_result[0].standard_time
                    });

                    var result_ST = a;

                    return Ok(result_ST.FirstOrDefault());
                }
                catch
                {
                    return NotFound("ไม่พบข้อมูล");
                }

            }
        }


        [HttpPost]
        [Route("SummaryAll/Delete")]
        public async Task<IActionResult> DeleteTssTemp([FromBody] T_SUMMARY_DATA data)
        {
            try
            {
                var existing = context.T_SUMMARY_JKS.Where(x => x.date_input == data.date_input
                && x.wc_code == data.wc_code
                && x.model_code == data.model_code
                && x.process_code == data.process_code
                && x.cell_code == data.cell_code
                && x.shift_code == data.shift_code
                && x.production_shift == data.production_shift).ToList();
                if (existing.Any())
                {
                    Console.WriteLine("delete T_SUMMARY_JKS");
                    context.T_SUMMARY_JKS.RemoveRange(existing);
                    await context.SaveChangesAsync();
                }

                var existing2 = context.T_SUMMARY_OT.Where(x => x.date_input == data.date_input
                && x.wc_code == data.wc_code
                && x.model_code == data.model_code
                && x.process_code == data.process_code
                && x.cell_code == data.cell_code
                && x.shift_code == data.shift_code
                && x.production_shift == data.production_shift).ToList();
                if (existing2.Any())
                {
                    Console.WriteLine("delete T_SUMMARY_OT");
                    context.T_SUMMARY_OT.RemoveRange(existing2);
                    await context.SaveChangesAsync();
                }

                var existing3 = context.T_SUMMARY_TSS.Where(x => x.date_input == data.date_input
                && x.wc_code == data.wc_code
                && x.model_code == data.model_code
                && x.process_code == data.process_code
                && x.cell_code == data.cell_code
                && x.shift_code == data.shift_code
                && x.production_shift == data.production_shift).ToList();
                if (existing3.Any())
                {
                    Console.WriteLine("delete T_SUMMARY_TSS");
                    context.T_SUMMARY_TSS.RemoveRange(existing3);
                    await context.SaveChangesAsync();
                }

                return Ok();
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex);
            }
        }

        [HttpPost]
        [Route("barchart")]
        public async Task<ActionResult> Barchart(T_SUMMARY_DATA data)
        {
            var d1 = Convert.ToDateTime(data.date_input).ToString("yyyy-MM-dd") + " 00:00:00.000";

            var result = await (from e in context.V_CHART
                                where e.date_input == data.date_input
                                && e.wc_code == data.wc_code
                                && e.model_code == data.model_code
                                && e.process_code == data.process_code
                                && e.cell_code == data.cell_code
                                && e.shift_code == data.shift_code
                                && e.production_shift == data.production_shift

                                select new
                                {
                                    total_working_time = e.Total_Working_Time,
                                    total_actual_time = e.Total_actual_time,
                                    non_working_time = e.Non_working_time,
                                    total_standard_time = e.Total_standard_time,
                                    pf_loss = e.PF_Loss,
                                    production_shift = e.production_shift,
                                    gb_cell_code = e.gb_cell_code,
                                    process_detail = e.process_detail,
                                    years = e.date_input.ToString("yyyy")
                                }).ToListAsync();

            return Ok(result.FirstOrDefault());
        }

        /////////////////////////////////////////////// Report Summary
        /// <summary>
        /// Export excel SummaryJKS.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /Summary/exportSummaryJKS
        ///     {
        ///        "start_date": "2020-10-01",
        ///        "end_date": "2020-10-15",
        ///        "wc_code": "WC-004",
        ///        "model_code": "M-013"
        ///     }
        ///
        /// </remarks>
        [HttpPost("exportSummaryJKS")]
        public async Task<IActionResult> exportSummaryJKS(Post_Summary data)
        {
            try
            {
                // query data from database  
                await Task.Yield();
                var startdate = DateTime.ParseExact(data.start_date, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
                var enddate = DateTime.ParseExact(data.end_date, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);

                var wc_data = context.M_WORK_CENTER.Where(e => e.wc_code == data.wc_code).FirstOrDefault();
                var model_data = context.M_MODEL.Where(e => e.model_code == data.model_code).FirstOrDefault();
                var process_data = context.M_PROCESS.Where(e => e.process_code == data.process_code).FirstOrDefault();
                var cell_data = context.M_CELL.Where(e => e.cell_code == data.cell_code).FirstOrDefault();
                var shift_data = context.M_BLOCK_SHIFT.Where(e => e.shift_code == data.shift_code).FirstOrDefault();
                string wc, model, process, cell, shift;
                if (wc_data == null) { wc = ""; } else { wc = wc_data.wc_detail; }
                if (model_data == null) { model = ""; } else { model = model_data.model_detail; }
                if (process_data == null) { process = ""; } else { process = process_data.process_detail; }
                if (cell_data == null) { cell = ""; } else { cell = cell_data.cell_detail; }
                if (shift_data == null) { shift = ""; } else { shift = shift_data.shift_detail; }

                List<V_Report_SummaryJKS> list = new List<V_Report_SummaryJKS>();
                list = await context.V_ReportSummaryJKS.AsNoTracking()
                    .Where(x => (x.date_input >= startdate && x.date_input <= enddate)
                    && x.wc_detail.Contains(wc) && x.model_detail.Contains(model)
                    && x.process_detail.Contains(process) && x.cell_detail.Contains(cell) && x.shift_detail.Contains(shift))
                    .OrderBy(x => x.date_input).ThenBy(x => x.wc_detail).ThenBy(x => x.model_detail)
                    .ThenBy(x => x.process_detail).ThenBy(x => x.cell_detail).ThenBy(x => x.production_shift)
                    .ThenBy(x => x.block_group).ThenBy(x => x.gb_cell_code).ToListAsync();

                if (list.Count > 0)
                {
                    // Excel
                    var stream = new MemoryStream();
                    using (var package = new ExcelPackage(stream))
                    {
                        var workSheet = package.Workbook.Worksheets.Add("Summary JKS");
                        workSheet.Cells[4, 2].LoadFromCollection(list, true); //เขียนข้อมูลให้อัตโนมัติ row 4, col 1

                        // Row num
                        int recordIndex = 5;
                        foreach (var item in list)
                        {
                            workSheet.Cells[recordIndex, 1].Value = (recordIndex - 4).ToString();
                            recordIndex++;
                        }

                        // Header
                        List<string> headerColumns = new List<string>()
                        {
                            // "No.", "Date (MM/DD/YY)", "WC","Model", "Cell Code/PROCESS", "CELL",
                            // "Block Shift", "Production Shift", "Block Group", "Gobal Cell Code",
                            // "Manpower OP", "Manpower SP", "Manpower Base", "Manpower Attendance", "Manpower Absent",
                            // "Extra Work (Mins)", "Job Special (Mins)", "Total Extra Job (Mins)", "Actual Output", "Reject Off",
                            // "Working Time (Mins)", "Working man Total", "01  Overtime (Mins)", "02  Accident (Mins)", "03  Manpower Out Flow (Mins)",
                            // "04  Manpower In Flow (Mins)", "Actual Working Man (Mins)", "Detail Working (Mins)", "Unknown Time (Mins)", "Worker Performane",
                            // "Operation Rate", "Total Performance"
                            //Rev.03
                            "No.", "Date (MM/DD/YY)", "WC","Model", "Cell Code/PROCESS", "CELL",
                            "Block Shift", "Production Shift", "Block Group", "Gobal Cell Code",
                            "OP", "OP Attendance", "SP", "SP Attendance", "TTL Manpower",  "OP Absent", "SP Absent",
                            "Extra Work (Mins)", "Job Special (Mins)", "Total Extra Job (Mins)", "Actual Output", "Reject Off",
                            "Working Time (Mins)", "OP Working man Total", "01  Overtime (Mins)", "02  Accident (Mins)", "03  Manpower Out Flow (Mins)",
                            "04  Manpower In Flow (Mins)", "Actual Working Man (Mins)", "Detail Working (Mins)", "Unknown Time (Mins)", 
                            "SP Working man Total", "SP Overtime (Mins)", "SP Accident (Mins)", "SP Manpower Out Flow (Mins)","SP Manpower In Flow (Mins)","SP Actual Working Man (Mins)",
                            "SP Detail Working (Mins)","SP Unknown Time (Mins)","OP Worker Performane", "OP Operation Rate", "OP Total Performance",
                            "OP+SP Worker Performane", "OP+SP Operation Rate", "OP+SP Total Performance"
                        }; 
                        stylesheets("Summary JKS", headerColumns, 45, recordIndex, workSheet);

                        package.Save();
                    }
                    stream.Position = 0;
                    string excelName = $"SummaryJKS-{DateTime.Now.ToString("yyyyMMddHHmmssfff")}.xlsx";
                    return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", excelName);
                }
                else
                {
                    // Console.WriteLine("null");
                    return BadRequest("ไม่พบข้อมูล");
                }
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex);
            }
        }

        /// <summary>
        /// Export excel SummaryOT.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /Summary/exportSummaryOT
        ///     {
        ///        "start_date": "2020-10-01",
        ///        "end_date": "2020-10-15",
        ///        "wc_code": "WC-004",
        ///        "model_code": "M-013"
        ///     }
        ///
        /// </remarks>
        [HttpPost("exportSummaryOT")]
        public async Task<IActionResult> exportSummaryOT(Post_Summary data)
        {
            try
            {
                // query data from database  
                await Task.Yield();
                var startdate = DateTime.ParseExact(data.start_date, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
                var enddate = DateTime.ParseExact(data.end_date, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);

                var wc_data = context.M_WORK_CENTER.Where(e => e.wc_code == data.wc_code).FirstOrDefault();
                var model_data = context.M_MODEL.Where(e => e.model_code == data.model_code).FirstOrDefault();
                var process_data = context.M_PROCESS.Where(e => e.process_code == data.process_code).FirstOrDefault();
                var cell_data = context.M_CELL.Where(e => e.cell_code == data.cell_code).FirstOrDefault();
                var shift_data = context.M_BLOCK_SHIFT.Where(e => e.shift_code == data.shift_code).FirstOrDefault();
                string wc, model, process, cell, shift;
                if (wc_data == null) { wc = ""; } else { wc = wc_data.wc_detail; }
                if (model_data == null) { model = ""; } else { model = model_data.model_detail; }
                if (process_data == null) { process = ""; } else { process = process_data.process_detail; }
                if (cell_data == null) { cell = ""; } else { cell = cell_data.cell_detail; }
                if (shift_data == null) { shift = ""; } else { shift = shift_data.shift_detail; }

                List<V_Report_SummaryOT> list = new List<V_Report_SummaryOT>();
                list = await context.V_ReportSummaryOT.AsNoTracking()
                    .Where(x => (x.date_input >= startdate && x.date_input <= enddate)
                    && x.wc_detail.Contains(wc) && x.model_detail.Contains(model)
                    && x.process_detail.Contains(process) && x.cell_detail.Contains(cell) && x.shift_detail.Contains(shift))
                    .OrderBy(x => x.date_input).ThenBy(x => x.wc_detail).ThenBy(x => x.model_detail)
                    .ThenBy(x => x.process_detail).ThenBy(x => x.cell_detail).ThenBy(x => x.production_shift)
                    .ThenBy(x => x.block_group).ThenBy(x => x.gb_cell_code).ToListAsync();

                if (list.Count > 0)
                {
                    var stream = new MemoryStream();
                    using (var package = new ExcelPackage(stream))
                    {
                        var workSheet = package.Workbook.Worksheets.Add("Summary OT Emergency");
                        workSheet.Cells[4, 2].LoadFromCollection(list, true); //เขียนข้อมูลให้อัตโนมัติ row 4, col 1

                        // Row num
                        int recordIndex = 5;
                        foreach (var item in list)
                        {
                            workSheet.Cells[recordIndex, 1].Value = (recordIndex - 4).ToString();
                            recordIndex++;
                        }

                        // Header
                        List<string> headerColumns = new List<string>()
                        {
                            // "No.", "Date (MM/DD/YY)", "WC","Model", "Cell Code/PROCESS", "CELL",
                            // "Block Shift", "Production Shift", "Block Group", "Gobal Cell Code",
                            // "Q'ty Manpower", "Total OT 60 Mins", "Q'ty Manpower", "Total OT 120 Mins", "Q'ty Manpower",
                            // "Total OT 150 Mins", "Q'ty Manpower", "Mins", "Total OT Other", "Q'ty Manpower",
                            // "Total Clinic 30 Mins", "Q'ty Manpower", "Total Clinic  60 Mins", "Q'ty Manpower", "Total Clinic 90 Mins",
                            // "Q'ty Manpower", "Total Clinic 120 Mins", "Q'ty Manpower", "Mins", "Clinic Other",
                            // "Q'ty Manpower", "Mins", "Leave 0.5 Day", "Q'ty Manpower", "Mins",
                            // "Manpower Out Flow", "Q'ty Manpower", "Mins", "Manpower In Flow", "Total Overtime / Emergency",
                            // "Standard Time", "Time (Min)", "Total Time (Min)"
                            "No.", "Date (MM/DD/YY)", "WC","Model", "Cell Code/PROCESS", "CELL",
                            "Block Shift", "Production Shift", "Block Group", "Gobal Cell Code",
                            "OP Q'ty", "SP Q'ty","Total OT 60 Mins", 
                            "OP Q'ty", "SP Q'ty","Total OT 120 Mins", 
                            "OP Q'ty", "SP Q'ty","Total OT 150 Mins", 
                            "OP Q'ty", "SP Q'ty","Mins", "Total OT Other", 
                            "OP Q'ty", "SP Q'ty","Total Clinic 30 Mins",
                            "OP Q'ty", "SP Q'ty","Total Clinic  60 Mins", 
                            "OP Q'ty", "SP Q'ty", "Total Clinic 90 Mins",
                            "OP Q'ty", "SP Q'ty", "Total Clinic 120 Mins", 
                            "OP Q'ty", "SP Q'ty", "Mins", "Clinic Other",
                            "OP Q'ty", "SP Q'ty", "Mins", "Leave 0.5 Day", 
                            "OP Q'ty", "SP Q'ty", "Mins", "Manpower Out Flow", 
                            "OP Q'ty", "SP Q'ty", "Mins", "Manpower In Flow", 
                            "Total Overtime / Emergency", "OP Standard Time", "OP Time (Min)", "OP Total Time (Min)",
                            "OP+SP Standard Time", "OP+SP Time (Min)", "OP+SP Total Time (Min)"
                        };

                        stylesheets("Summary OT Emergency", headerColumns, 58, recordIndex, workSheet);

                        package.Save();
                    }
                    stream.Position = 0;
                    string excelName = $"SummaryOT-{DateTime.Now.ToString("yyyyMMddHHmmssfff")}.xlsx";
                    return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", excelName);
                }
                else
                {
                    // Console.WriteLine("null");
                    return BadRequest("ไม่พบข้อมูล");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }

        /// <summary>
        /// Export excel SummaryTSS.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /Summary/exportSummaryTSS
        ///     {
        ///        "start_date": "2020-10-01",
        ///        "end_date": "2020-10-15",
        ///        "wc_code": "WC-004",
        ///        "model_code": "M-013"
        ///     }
        ///
        /// </remarks>
        [HttpPost("exportSummaryTSS")]
        public async Task<IActionResult> exportSummaryTSS(Post_Summary data)
        {
            try
            {
                // query data from database  
                await Task.Yield();
                var startdate = DateTime.ParseExact(data.start_date, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
                var enddate = DateTime.ParseExact(data.end_date, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);

                var wc_data = context.M_WORK_CENTER.Where(e => e.wc_code == data.wc_code).FirstOrDefault();
                var model_data = context.M_MODEL.Where(e => e.model_code == data.model_code).FirstOrDefault();
                var process_data = context.M_PROCESS.Where(e => e.process_code == data.process_code).FirstOrDefault();
                var cell_data = context.M_CELL.Where(e => e.cell_code == data.cell_code).FirstOrDefault();
                var shift_data = context.M_BLOCK_SHIFT.Where(e => e.shift_code == data.shift_code).FirstOrDefault();
                string wc, model, process, cell, shift;
                if (wc_data == null) { wc = ""; } else { wc = wc_data.wc_detail; }
                if (model_data == null) { model = ""; } else { model = model_data.model_detail; }
                if (process_data == null) { process = ""; } else { process = process_data.process_detail; }
                if (cell_data == null) { cell = ""; } else { cell = cell_data.cell_detail; }
                if (shift_data == null) { shift = ""; } else { shift = shift_data.shift_detail; }

                List<V_Report_SummaryTSS> list = new List<V_Report_SummaryTSS>();
                list = await context.V_ReportSummaryTSS.AsNoTracking()
                    .Where(x => (x.date_input >= startdate && x.date_input <= enddate)
                    && x.wc_detail.Contains(wc) && x.model_detail.Contains(model)
                    && x.process_detail.Contains(process) && x.cell_detail.Contains(cell) && x.shift_detail.Contains(shift))
                    .OrderBy(x => x.date_input).ThenBy(x => x.wc_detail).ThenBy(x => x.model_detail)
                    .ThenBy(x => x.process_detail).ThenBy(x => x.cell_detail).ThenBy(x => x.production_shift)
                    .ThenBy(x => x.block_group).ThenBy(x => x.gb_cell_code).ToListAsync();

                if (list.Count > 0)
                {
                    var stream = new MemoryStream();
                    using (var package = new ExcelPackage(stream))
                    {
                        var workSheet = package.Workbook.Worksheets.Add("Summary TSS");
                        workSheet.Cells[4, 2].LoadFromCollection(list, true); //เขียนข้อมูลให้อัตโนมัติ row 4, col 1

                        // Row num
                        int recordIndex = 5;
                        foreach (var item in list)
                        {
                            workSheet.Cells[recordIndex, 1].Value = (recordIndex - 4).ToString();
                            recordIndex++;
                        }

                        // Header : Extra Work No. / Part No. ขอเปลี่ยนเป็น Detail
                        List<string> headerColumns = new List<string>()
                        {
                            "No.", "Date (MM/DD/YY)", "WC","Model", "Cell Code/PROCESS", "CELL",
                            "Block Shift", "Production Shift", "Block Group", "Gobal Cell Code",
                            "Code", "Detail", "Manpower (Pers)", "TSS (Min)", "Q'ty M/C",
                            "Loss Time"
                        };

                        stylesheets("Summary TSS", headerColumns, 16, recordIndex, workSheet);

                        package.Save();
                    }
                    stream.Position = 0;
                    string excelName = $"SummaryTSS-{DateTime.Now.ToString("yyyyMMddHHmmssfff")}.xlsx";
                    return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", excelName);
                }
                else
                {
                    // Console.WriteLine("null");
                    return BadRequest("ไม่พบข้อมูล");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }

        /// <summary>
        /// Export excel SummaryReport old.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /Summary/exportSummaryold
        ///     {
        ///        "start_date": "2020-10-01",
        ///        "end_date": "2020-10-15",
        ///        "wc_code": "WC-004",
        ///        "model_code": "M-013"
        ///     }
        ///
        /// </remarks>
        [HttpPost("exportSummaryold")]
        public async Task<IActionResult> exportSummaryold(Post_Summary data)
        {
            try
            {
                // query data from database  
                await Task.Yield();
                var startdate = DateTime.ParseExact(data.start_date, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
                var enddate = DateTime.ParseExact(data.end_date, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);

                var wc_data = context.M_WORK_CENTER.Where(e => e.wc_code == data.wc_code).FirstOrDefault();
                var model_data = context.M_MODEL.Where(e => e.model_code == data.model_code).FirstOrDefault();

                List<V_Report_SummaryJKS> listjks = new List<V_Report_SummaryJKS>();
                List<V_Report_SummaryOT> listot = new List<V_Report_SummaryOT>();
                List<V_Report_SummaryTSS> listtss = new List<V_Report_SummaryTSS>();

                if (data.wc_code == "" && data.model_code == "")
                {
                    listjks = await context.V_ReportSummaryJKS.AsNoTracking()
                                .Where(x => (x.date_input >= startdate && x.date_input <= enddate))

                                .OrderBy(x => x.date_input).ThenBy(x => x.wc_detail).ThenBy(x => x.model_detail)
                                .ThenBy(x => x.process_detail).ThenBy(x => x.cell_detail).ThenBy(x => x.production_shift)
                                .ThenBy(x => x.block_group).ThenBy(x => x.gb_cell_code).ToListAsync();

                    listot = await context.V_ReportSummaryOT.AsNoTracking()
                    .Where(x => (x.date_input >= startdate && x.date_input <= enddate))

                    .OrderBy(x => x.date_input).ThenBy(x => x.wc_detail).ThenBy(x => x.model_detail)
                    .ThenBy(x => x.process_detail).ThenBy(x => x.cell_detail).ThenBy(x => x.production_shift)
                    .ThenBy(x => x.block_group).ThenBy(x => x.gb_cell_code).ToListAsync();

                    listtss = await context.V_ReportSummaryTSS.AsNoTracking()
                    .Where(x => (x.date_input >= startdate && x.date_input <= enddate))

                    .OrderBy(x => x.date_input).ThenBy(x => x.wc_detail).ThenBy(x => x.model_detail)
                    .ThenBy(x => x.process_detail).ThenBy(x => x.cell_detail).ThenBy(x => x.production_shift)
                    .ThenBy(x => x.block_group).ThenBy(x => x.gb_cell_code).ToListAsync();
                }
                else if (data.model_code == "")
                {
                    listjks = await context.V_ReportSummaryJKS.AsNoTracking()
                    .Where(x => (x.date_input >= startdate && x.date_input <= enddate) && x.wc_detail == wc_data.wc_detail)

                    .OrderBy(x => x.date_input).ThenBy(x => x.wc_detail).ThenBy(x => x.model_detail)
                    .ThenBy(x => x.process_detail).ThenBy(x => x.cell_detail).ThenBy(x => x.production_shift)
                    .ThenBy(x => x.block_group).ThenBy(x => x.gb_cell_code).ToListAsync();

                    listot = await context.V_ReportSummaryOT.AsNoTracking()
                    .Where(x => (x.date_input >= startdate && x.date_input <= enddate) && x.wc_detail == wc_data.wc_detail)
                    .OrderBy(x => x.date_input).ThenBy(x => x.wc_detail).ThenBy(x => x.model_detail)
                    .ThenBy(x => x.process_detail).ThenBy(x => x.cell_detail).ThenBy(x => x.production_shift)
                    .ThenBy(x => x.block_group).ThenBy(x => x.gb_cell_code).ToListAsync();

                    listtss = await context.V_ReportSummaryTSS.AsNoTracking()
                    .Where(x => (x.date_input >= startdate && x.date_input <= enddate) && x.wc_detail == wc_data.wc_detail)
                    .OrderBy(x => x.date_input).ThenBy(x => x.wc_detail).ThenBy(x => x.model_detail)
                    .ThenBy(x => x.process_detail).ThenBy(x => x.cell_detail).ThenBy(x => x.production_shift)
                    .ThenBy(x => x.block_group).ThenBy(x => x.gb_cell_code).ToListAsync();
                }
                else
                {
                    listjks = await context.V_ReportSummaryJKS.AsNoTracking()
                    .Where(x => (x.date_input >= startdate && x.date_input <= enddate)
                    && x.wc_detail == wc_data.wc_detail && x.model_detail == model_data.model_detail)

                    .OrderBy(x => x.date_input).ThenBy(x => x.wc_detail).ThenBy(x => x.model_detail)
                    .ThenBy(x => x.process_detail).ThenBy(x => x.cell_detail).ThenBy(x => x.production_shift)
                    .ThenBy(x => x.block_group).ThenBy(x => x.gb_cell_code).ToListAsync();

                    listot = await context.V_ReportSummaryOT.AsNoTracking()
                    .Where(x => (x.date_input >= startdate && x.date_input <= enddate)
                    && x.wc_detail == wc_data.wc_detail && x.model_detail == model_data.model_detail)

                    .OrderBy(x => x.date_input).ThenBy(x => x.wc_detail).ThenBy(x => x.model_detail)
                    .ThenBy(x => x.process_detail).ThenBy(x => x.cell_detail).ThenBy(x => x.production_shift)
                    .ThenBy(x => x.block_group).ThenBy(x => x.gb_cell_code).ToListAsync();

                    listtss = await context.V_ReportSummaryTSS.AsNoTracking()
                    .Where(x => (x.date_input >= startdate && x.date_input <= enddate)
                    && x.wc_detail == wc_data.wc_detail && x.model_detail == model_data.model_detail)

                    .OrderBy(x => x.date_input).ThenBy(x => x.wc_detail).ThenBy(x => x.model_detail)
                    .ThenBy(x => x.process_detail).ThenBy(x => x.cell_detail).ThenBy(x => x.production_shift)
                    .ThenBy(x => x.block_group).ThenBy(x => x.gb_cell_code).ToListAsync();
                }

                if (listjks.Count > 0)
                {
                    var stream = new MemoryStream();
                    using (var package = new ExcelPackage(stream))
                    {
                        // Header
                        List<string> headerColumns = new List<string>()
                        {
                            "No.", "Date (MM/DD/YY)", "WC","Model", "Cell Code/PROCESS", "CELL",
                            "Block Shift", "Production Shift", "Block Group", "Gobal Cell Code",
                            "Manpower OP", "Manpower SP", "Manpower Base", "Manpower Attendance", "Manpower Absent",
                            "Extra Work (Mins)", "Job Special (Mins)", "Total Extra Job (Mins)", "Actual Output", "Reject Off",
                            "Working Time (Mins)", "Working man Total", "01  Overtime (Mins)", "02  Accident (Mins)", "03  Manpower Out Flow (Mins)",
                            "04  Manpower In Flow (Mins)", "Actual Working Man (Mins)", "Detail Working (Mins)", "Unknown Time (Mins)", "Worker Performane",
                            "Operation Rate", "Total Performance"
                        };
                        var ws1 = package.Workbook.Worksheets.Add("Summary JKS");
                        ws1.Cells[4, 2].LoadFromCollection(listjks, true);
                        // Row num
                        int recordIndex = 5;
                        foreach (var item in listjks)
                        {
                            ws1.Cells[recordIndex, 1].Value = (recordIndex - 4).ToString();
                            recordIndex++;
                        }
                        stylesheets("Summary JKS", headerColumns, 32, recordIndex, ws1);
                        /////////////////////////////////////////////////////////////////////////
                        List<string> headerColumnsOT = new List<string>()
                        {
                            "No.", "Date (MM/DD/YY)", "WC","Model", "Cell Code/PROCESS", "CELL",
                            "Block Shift", "Production Shift", "Block Group", "Gobal Cell Code",
                            "Q'ty Manpower", "Total OT 60 Mins", "Q'ty Manpower", "Total OT 120 Mins", "Q'ty Manpower",
                            "Total OT 150 Mins", "Q'ty Manpower", "Mins", "Total OT Other", "Q'ty Manpower",
                            "Total Clinic 30 Mins", "Q'ty Manpower", "Total Clinic  60 Mins", "Q'ty Manpower", "Total Clinic 90 Mins",
                            "Q'ty Manpower", "Total Clinic 120 Mins", "Q'ty Manpower", "Mins", "Clinic Other",
                            "Q'ty Manpower", "Mins", "Leave 0.5 Day", "Q'ty Manpower", "Mins",
                            "Manpower Out Flow", "Q'ty Manpower", "Mins", "Manpower In Flow", "Total Overtime / Emergency",
                            "Standard Time", "Time (Min)", "Total Time (Min)"
                        };
                        var ws2 = package.Workbook.Worksheets.Add("Summary OT Emergency");
                        ws2.Cells[4, 2].LoadFromCollection(listot, true);
                        // Row num
                        int recordIndexOT = 5;
                        foreach (var item in listot)
                        {
                            ws2.Cells[recordIndexOT, 1].Value = (recordIndexOT - 4).ToString();
                            recordIndexOT++;
                        }
                        stylesheets("Summary OT Emergency", headerColumnsOT, 43, recordIndexOT, ws2);
                        /////////////////////////////////////////////////////////////////////////
                        // Header : Extra Work No. / Part No. ขอเปลี่ยนเป็น Detail
                        List<string> headerColumnsTSS = new List<string>()
                        {
                            "No.", "Date (MM/DD/YY)", "WC","Model", "Cell Code/PROCESS", "CELL",
                            "Block Shift", "Production Shift", "Block Group", "Gobal Cell Code",
                            "Code", "Detail", "Manpower (Pers)", "TSS (Min)", "Q'ty M/C",
                            "Loss Time"
                        };
                        var ws3 = package.Workbook.Worksheets.Add("Summary TSS");
                        ws3.Cells[4, 2].LoadFromCollection(listtss, true);
                        // Row num
                        int recordIndexTSS = 5;
                        foreach (var item in listtss)
                        {
                            ws3.Cells[recordIndexTSS, 1].Value = (recordIndexTSS - 4).ToString();
                            recordIndexTSS++;
                        }
                        stylesheets("Summary TSS", headerColumnsTSS, 16, recordIndexTSS, ws3);

                        package.Save();
                    }
                    stream.Position = 0;
                    string excelName = $"SummaryReport-{DateTime.Now.ToString("yyyyMMddHHmmssfff")}.xlsx";
                    return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", excelName);
                }
                else
                { // Console.WriteLine("null");
                    return BadRequest("ไม่พบข้อมูล");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }

        /// <summary>
        /// Export excel SummaryReport.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /Summary/exportSummary
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
        [HttpPost("exportSummary")]
        public async Task<IActionResult> exportSummary(Post_Summary data)
        {
            try
            {
                // query data from database  
                await Task.Yield();
                var startdate = DateTime.ParseExact(data.start_date, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
                var enddate = DateTime.ParseExact(data.end_date, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);

                var wc_data = context.M_WORK_CENTER.Where(e => e.wc_code == data.wc_code).FirstOrDefault();
                var model_data = context.M_MODEL.Where(e => e.model_code == data.model_code).FirstOrDefault();
                var process_data = context.M_PROCESS.Where(e => e.process_code == data.process_code).FirstOrDefault();
                var cell_data = context.M_CELL.Where(e => e.cell_code == data.cell_code).FirstOrDefault();
                var shift_data = context.M_BLOCK_SHIFT.Where(e => e.shift_code == data.shift_code).FirstOrDefault();
                string wc, model, process, cell, shift;
                if (wc_data == null) { wc = ""; } else { wc = wc_data.wc_detail; }
                if (model_data == null) { model = ""; } else { model = model_data.model_detail; }
                if (process_data == null) { process = ""; } else { process = process_data.process_detail; }
                if (cell_data == null) { cell = ""; } else { cell = cell_data.cell_detail; }
                if (shift_data == null) { shift = ""; } else { shift = shift_data.shift_detail; }

                List<V_Report_SummaryJKS> listjks = new List<V_Report_SummaryJKS>();
                List<V_Report_SummaryOT> listot = new List<V_Report_SummaryOT>();
                List<V_Report_SummaryTSS> listtss = new List<V_Report_SummaryTSS>();

                listjks = await context.V_ReportSummaryJKS.AsNoTracking()
                    .Where(x => (x.date_input >= startdate && x.date_input <= enddate)
                    && x.wc_detail.Contains(wc) && x.model_detail.Contains(model)
                    && x.process_detail.Contains(process) && x.cell_detail.Contains(cell) && x.shift_detail.Contains(shift))
                    .OrderBy(x => x.date_input).ThenBy(x => x.wc_detail).ThenBy(x => x.model_detail)
                    .ThenBy(x => x.process_detail).ThenBy(x => x.cell_detail).ThenBy(x => x.production_shift)
                    .ThenBy(x => x.block_group).ThenBy(x => x.gb_cell_code).ToListAsync();

                listot = await context.V_ReportSummaryOT.AsNoTracking()
                    .Where(x => (x.date_input >= startdate && x.date_input <= enddate)
                    && x.wc_detail.Contains(wc) && x.model_detail.Contains(model)
                    && x.process_detail.Contains(process) && x.cell_detail.Contains(cell) && x.shift_detail.Contains(shift))
                    .OrderBy(x => x.date_input).ThenBy(x => x.wc_detail).ThenBy(x => x.model_detail)
                    .ThenBy(x => x.process_detail).ThenBy(x => x.cell_detail).ThenBy(x => x.production_shift)
                    .ThenBy(x => x.block_group).ThenBy(x => x.gb_cell_code).ToListAsync();

                listtss = await context.V_ReportSummaryTSS.AsNoTracking()
                    .Where(x => (x.date_input >= startdate && x.date_input <= enddate)
                    && x.wc_detail.Contains(wc) && x.model_detail.Contains(model)
                    && x.process_detail.Contains(process) && x.cell_detail.Contains(cell) && x.shift_detail.Contains(shift))
                    .OrderBy(x => x.date_input).ThenBy(x => x.wc_detail).ThenBy(x => x.model_detail)
                    .ThenBy(x => x.process_detail).ThenBy(x => x.cell_detail).ThenBy(x => x.production_shift)
                    .ThenBy(x => x.block_group).ThenBy(x => x.gb_cell_code).ToListAsync();

                if (listjks.Count > 0)
                {
                    var stream = new MemoryStream();
                    using (var package = new ExcelPackage(stream))
                    {
                        // Header
                        List<string> headerColumns = new List<string>()
                        {
                            // "No.", "Date (MM/DD/YY)", "WC","Model", "Cell Code/PROCESS", "CELL",
                            // "Block Shift", "Production Shift", "Block Group", "Gobal Cell Code",
                            // "Manpower OP", "Manpower SP", "Manpower Base", "Manpower Attendance", "Manpower Absent",
                            // "Extra Work (Mins)", "Job Special (Mins)", "Total Extra Job (Mins)", "Actual Output", "Reject Off",
                            // "Working Time (Mins)", "Working man Total", "01  Overtime (Mins)", "02  Accident (Mins)", "03  Manpower Out Flow (Mins)",
                            // "04  Manpower In Flow (Mins)", "Actual Working Man (Mins)", "Detail Working (Mins)", "Unknown Time (Mins)", "Worker Performane",
                            // "Operation Rate", "Total Performance"
                            "No.", "Date (MM/DD/YY)", "WC","Model", "Cell Code/PROCESS", "CELL",
                            "Block Shift", "Production Shift", "Block Group", "Gobal Cell Code",
                            "OP", "OP Attendance", "SP", "SP Attendance", "TTL Manpower",  "OP Absent", "SP Absent",
                            "Extra Work (Mins)", "Job Special (Mins)", "Total Extra Job (Mins)", "Actual Output", "Reject Off",
                            "Working Time (Mins)", "OP Working man Total", "01  Overtime (Mins)", "02  Accident (Mins)", "03  Manpower Out Flow (Mins)",
                            "04  Manpower In Flow (Mins)", "Actual Working Man (Mins)", "Detail Working (Mins)", "Unknown Time (Mins)", 
                            "SP Working man Total", "SP Overtime (Mins)", "SP Accident (Mins)", "SP Manpower Out Flow (Mins)","SP Manpower In Flow (Mins)","SP Actual Working Man (Mins)",
                            "SP Detail Working (Mins)","SP Unknown Time (Mins)","OP Worker Performane", "OP Operation Rate", "OP Total Performance",
                            "OP+SP Worker Performane", "OP+SP Operation Rate", "OP+SP Total Performance"
                        };
                        var ws1 = package.Workbook.Worksheets.Add("Summary JKS");
                        ws1.Cells[4, 2].LoadFromCollection(listjks, true);
                        // Row num
                        int recordIndex = 5;
                        foreach (var item in listjks)
                        {
                            ws1.Cells[recordIndex, 1].Value = (recordIndex - 4).ToString();
                            recordIndex++;
                        }
                        stylesheets("Summary JKS", headerColumns, 45, recordIndex, ws1);
                        /////////////////////////////////////////////////////////////////////////
                        List<string> headerColumnsOT = new List<string>()
                        {
                            // "No.", "Date (MM/DD/YY)", "WC","Model", "Cell Code/PROCESS", "CELL",
                            // "Block Shift", "Production Shift", "Block Group", "Gobal Cell Code",
                            // "Q'ty Manpower", "Total OT 60 Mins", "Q'ty Manpower", "Total OT 120 Mins", "Q'ty Manpower",
                            // "Total OT 150 Mins", "Q'ty Manpower", "Mins", "Total OT Other", "Q'ty Manpower",
                            // "Total Clinic 30 Mins", "Q'ty Manpower", "Total Clinic  60 Mins", "Q'ty Manpower", "Total Clinic 90 Mins",
                            // "Q'ty Manpower", "Total Clinic 120 Mins", "Q'ty Manpower", "Mins", "Clinic Other",
                            // "Q'ty Manpower", "Mins", "Leave 0.5 Day", "Q'ty Manpower", "Mins",
                            // "Manpower Out Flow", "Q'ty Manpower", "Mins", "Manpower In Flow", "Total Overtime / Emergency",
                            // "Standard Time", "Time (Min)", "Total Time (Min)"
                            "No.", "Date (MM/DD/YY)", "WC","Model", "Cell Code/PROCESS", "CELL",
                            "Block Shift", "Production Shift", "Block Group", "Gobal Cell Code",
                            "OP Q'ty", "SP Q'ty","Total OT 60 Mins", 
                            "OP Q'ty", "SP Q'ty","Total OT 120 Mins", 
                            "OP Q'ty", "SP Q'ty","Total OT 150 Mins", 
                            "OP Q'ty", "SP Q'ty","Mins", "Total OT Other", 
                            "OP Q'ty", "SP Q'ty","Total Clinic 30 Mins",
                            "OP Q'ty", "SP Q'ty","Total Clinic  60 Mins", 
                            "OP Q'ty", "SP Q'ty", "Total Clinic 90 Mins",
                            "OP Q'ty", "SP Q'ty", "Total Clinic 120 Mins", 
                            "OP Q'ty", "SP Q'ty", "Mins", "Clinic Other",
                            "OP Q'ty", "SP Q'ty", "Mins", "Leave 0.5 Day", 
                            "OP Q'ty", "SP Q'ty", "Mins", "Manpower Out Flow", 
                            "OP Q'ty", "SP Q'ty", "Mins", "Manpower In Flow", 
                            "Total Overtime / Emergency", "OP Standard Time", "OP Time (Min)", "OP Total Time (Min)",
                            "OP+SP Standard Time", "OP+SP Time (Min)", "OP+SP Total Time (Min)"
                        };
                        var ws2 = package.Workbook.Worksheets.Add("Summary OT Emergency");
                        ws2.Cells[4, 2].LoadFromCollection(listot, true);
                        // Row num
                        int recordIndexOT = 5;
                        foreach (var item in listot)
                        {
                            ws2.Cells[recordIndexOT, 1].Value = (recordIndexOT - 4).ToString();
                            recordIndexOT++;
                        }
                        stylesheets("Summary OT Emergency", headerColumnsOT, 58, recordIndexOT, ws2);
                        /////////////////////////////////////////////////////////////////////////
                        // Header : Extra Work No. / Part No. ขอเปลี่ยนเป็น Detail
                        List<string> headerColumnsTSS = new List<string>()
                        {
                            "No.", "Date (MM/DD/YY)", "WC","Model", "Cell Code/PROCESS", "CELL",
                            "Block Shift", "Production Shift", "Block Group", "Gobal Cell Code",
                            "Code", "Detail", "Manpower (Pers)", "TSS (Min)", "Q'ty M/C",
                            "Loss Time"
                        };
                        var ws3 = package.Workbook.Worksheets.Add("Summary TSS");
                        ws3.Cells[4, 2].LoadFromCollection(listtss, true);
                        // Row num
                        int recordIndexTSS = 5;
                        foreach (var item in listtss)
                        {
                            ws3.Cells[recordIndexTSS, 1].Value = (recordIndexTSS - 4).ToString();
                            recordIndexTSS++;
                        }
                        stylesheets("Summary TSS", headerColumnsTSS, 16, recordIndexTSS, ws3);

                        package.Save();
                    }
                    stream.Position = 0;
                    string excelName = $"SummaryReport-{DateTime.Now.ToString("yyyyMMddHHmmssfff")}.xlsx";
                    return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", excelName);
                }
                else
                { // Console.WriteLine("null");
                    return BadRequest("ไม่พบข้อมูล");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }

        /// <summary>
        /// Export excel History.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /Summary/exportHistory
        ///     {
        ///        "start_date": "2021-03-01",
        ///        "end_date": "2021-03-25",
        ///        "wc_code": "WC-004",
        ///        "model_code": "M-013"
        ///     }
        ///
        /// </remarks>
        [HttpPost("exportHistory")]
        public async Task<IActionResult> exportHistory(Post_Summary data)
        {
            try
            {
                // query data from database  
                await Task.Yield();
                var startdate = DateTime.ParseExact(data.start_date, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
                var enddate = DateTime.ParseExact(data.end_date, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);

                var wc_data = context.M_WORK_CENTER.Where(e => e.wc_code == data.wc_code).FirstOrDefault();
                var model_data = context.M_MODEL.Where(e => e.model_code == data.model_code).FirstOrDefault();
                var process_data = context.M_PROCESS.Where(e => e.process_code == data.process_code).FirstOrDefault();
                var cell_data = context.M_CELL.Where(e => e.cell_code == data.cell_code).FirstOrDefault();
                var shift_data = context.M_BLOCK_SHIFT.Where(e => e.shift_code == data.shift_code).FirstOrDefault();
                string wc, model, process, cell, shift;
                if (wc_data == null) { wc = ""; } else { wc = wc_data.wc_detail; }
                if (model_data == null) { model = ""; } else { model = model_data.model_detail; }
                if (process_data == null) { process = ""; } else { process = process_data.process_detail; }
                if (cell_data == null) { cell = ""; } else { cell = cell_data.cell_detail; }
                if (shift_data == null) { shift = ""; } else { shift = shift_data.shift_detail; }

                List<V_ReportHistory> list = new List<V_ReportHistory>();
                list = await context.V_ReportHistory.AsNoTracking()
                    .Where(x => (x.date_input >= startdate && x.date_input <= enddate)
                    && x.wc_detail.Contains(wc) && x.model_detail.Contains(model)
                    && x.process_detail.Contains(process) && x.cell_detail.Contains(cell) && x.shift_detail.Contains(shift))
                    .OrderBy(x => x.date_input).ThenBy(x => x.wc_detail).ThenBy(x => x.model_detail)
                    .ThenBy(x => x.process_detail).ThenBy(x => x.cell_detail).ThenBy(x => x.production_shift)
                    .ThenBy(x => x.block_group).ThenBy(x => x.gb_cell_code).ToListAsync();

                if (list.Count > 0)
                {
                    // Excel
                    var stream = new MemoryStream();
                    using (var package = new ExcelPackage(stream))
                    {
                        var workSheet = package.Workbook.Worksheets.Add("History");
                        workSheet.Cells[4, 2].LoadFromCollection(list, true); //เขียนข้อมูลให้อัตโนมัติ row 4, col 1

                        // Row num
                        int recordIndex = 5;
                        foreach (var item in list)
                        {
                            workSheet.Cells[recordIndex, 1].Value = (recordIndex - 4).ToString();
                            recordIndex++;
                        }

                        // Header
                        List<string> headerColumns = new List<string>()
                        {
                            // "No.", "Date (MM/DD/YY)", "WC","Model", "Cell Code/PROCESS", "CELL",
                            // "Block Shift", "Production Shift", "Block Group", "Gobal Cell Code",
                            // "Manpower OP", "Manpower SP", "Manpower Base", "Manpower Attendance", "Manpower Absent",
                            // "Extra Work (Mins)", "Job Special (Mins)", "Total Extra Job (Mins)", "Actual Output", "Reject Off",
                            // "Working Time (Mins)", "Working man Total", "01  Overtime (Mins)", "02  Accident (Mins)", "03  Manpower Out Flow (Mins)",
                            // "04  Manpower In Flow (Mins)", "Actual Working Man (Mins)", "Detail Working (Mins)", "Unknown Time (Mins)", "Worker Performane",
                            // "Operation Rate", "Total Performance",
                            // "Input By", "Input Date (MM/DD/YY hh:mm:ss)", "Update By", "Update Date (MM/DD/YY hh:mm:ss)"

                            "No.", "Date (MM/DD/YY)", "WC","Model", "Cell Code/PROCESS", "CELL",
                            "Block Shift", "Production Shift", "Block Group", "Gobal Cell Code",
                            "OP", "OP Attendance", "SP", "SP Attendance", "TTL Manpower",  "OP Absent", "SP Absent",
                            "Extra Work (Mins)", "Job Special (Mins)", "Total Extra Job (Mins)", "Actual Output", "Reject Off",
                            "Working Time (Mins)", "OP Working man Total", "01  Overtime (Mins)", "02  Accident (Mins)", "03  Manpower Out Flow (Mins)",
                            "04  Manpower In Flow (Mins)", "Actual Working Man (Mins)", "Detail Working (Mins)", "Unknown Time (Mins)", 
                            "SP Working man Total", "SP Overtime (Mins)", "SP Accident (Mins)", "SP Manpower Out Flow (Mins)","SP Manpower In Flow (Mins)","SP Actual Working Man (Mins)",
                            "SP Detail Working (Mins)","SP Unknown Time (Mins)","OP Worker Performane", "OP Operation Rate", "OP Total Performance",
                            "OP+SP Worker Performane", "OP+SP Operation Rate", "OP+SP Total Performance",
                            "Input By", "Input Date (MM/DD/YY hh:mm:ss)", "Update By", "Update Date (MM/DD/YY hh:mm:ss)"
                        };
                        stylesheets("Report History", headerColumns, 49, recordIndex, workSheet);

                        package.Save();
                    }
                    stream.Position = 0;
                    string excelName = $"HistoryJKS-{DateTime.Now.ToString("yyyyMMddHHmmssfff")}.xlsx";
                    return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", excelName);
                }
                else
                {
                    // Console.WriteLine("null");
                    return BadRequest("ไม่พบข้อมูล");
                }
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex);
            }
        }
        private void stylesheets(string namesheet, List<string> headerColumns, int endCol, int recordIndex, ExcelWorksheet ws)
        {
            int index = 1;
            foreach (var item in headerColumns)
            {
                ws.Cells[4, index++].Value = item;
            }

            // Set style header
            ws.Cells[2, 1].Value = namesheet;    //Address "A2"
            ws.Cells[2, 1].Style.Font.Size = 20;

            using (var range = ws.Cells[4, 1, 4, endCol])  //Address "A4:..4"
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
            ws.Row(4).Height = 45.75;
            ws.Cells["A4:H4"].Style.Fill.PatternType = ExcelFillStyle.Solid;
            ws.Cells["A4:H4"].Style.Fill.BackgroundColor.SetColor(Color.Yellow);

            // Format date  Address "B5:B last row" :: row 5, col B , last row, col B
            ws.Cells[5, 2, recordIndex, 2].Style.Numberformat.Format = DateTimeFormatInfo.CurrentInfo.ShortDatePattern;
            ws.Cells[5, 2, recordIndex, 2].Style.Numberformat.Format = "MM/dd/yyyy";
            // Set colunm width
            for (int col = 2; col <= endCol; col++)
            {
                ws.Column(col).Width = 14;
            }

        }
        private DataTable get_datatable(string query)
        {
            DataTable dt = new DataTable();
            string constr = this._config.GetConnectionString("ConnStr");
            using (SqlConnection con = new SqlConnection(constr))
            {
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

    }
}