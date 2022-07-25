using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace JKSAPI
{
    public class T_SUMMARY_JKS
    {
        public int? id { get; set; }
        public DateTime date_input { get; set; }
        public string wc_code { get; set; }
        public string model_code { get; set; }
        public string process_code { get; set; }
        public string cell_code { get; set; }
        public string shift_code { get; set; }
        public string production_shift { get; set; }
        public string block_group_code { get; set; }
        public string gb_cell_code { get; set; }
        public int? op_meister { get; set; }
        public int? sp_meister { get; set; }
        public int? manpower { get; set; }
        public int? manpower_attendance { get; set; }
        public int? manpower_absent { get; set; }
        public int? extra_work { get; set; }
        public int? job_special { get; set; }
        public int? total_extra_job { get; set; }
        public int? actual_output { get; set; }
        public int? reject_off { get; set; }
        public int? working_time { get; set; }
        public int? working_man { get; set; }
        public int? overtime { get; set; }
        public int? accident { get; set; }
        public int? manpower_out_flow { get; set; }
        public int? manpower_in_flow { get; set; }
        public int? actual_working_man { get; set; }
        public int? detail_working { get; set; }
        public int? unknown_time { get; set; }
        public string worker_performance { get; set; }
        public string operation_rate { get; set; }
        public string total_performance { get; set; }
        public string comment { get; set; }

        public string ins_by { get; set; }
        public DateTime ins_date { get; set; }
        public string update_by { get; set; }
        public DateTime update_date { get; set; }

        // OP + SP
        public int? manpower_attendance_sp { get; set; }
        public int? manpower_absent_sp { get; set; }
        public int? working_man_op_sp { get; set; }
        public int? overtime_op_sp { get; set; }
        public int? accident_op_sp { get; set; }
        public int? manpower_out_flow_op_sp { get; set; }
        public int? manpower_in_flow_op_sp { get; set; }
        public int? actual_working_man_op_sp { get; set; }
        public int? detail_working_op_sp { get; set; }
        public int? unknown_time_op_sp { get; set; }
        public string worker_performance_op_sp { get; set; }
        public string operation_rate_op_sp { get; set; }
        public string total_performance_op_sp { get; set; }
    }

    public class T_SUMMARY_OT
    {
        public int? id { get; set; }
        public DateTime date_input { get; set; }
        public string wc_code { get; set; }
        public string model_code { get; set; }
        public string process_code { get; set; }
        public string cell_code { get; set; }
        public string shift_code { get; set; }
        public string production_shift { get; set; }
        public string block_group_code { get; set; }
        public string gb_cell_code { get; set; }
        public int? ot_60_qty { get; set; }
        public int? ot_60_total { get; set; }
        public int? ot_120_qty { get; set; }
        public int? ot_120_total { get; set; }
        public int? ot_150_qty { get; set; }
        public int? ot_150_total { get; set; }
        public int? ot_other_qty { get; set; }
        public int? ot_other_min { get; set; }
        public int? ot_other_total { get; set; }
        public int? clinic_30_qty { get; set; }
        public int? clinic_30_total { get; set; }
        public int? clinic_60_qty { get; set; }
        public int? clinic_60_total { get; set; }
        public int? clinic_90_qty { get; set; }
        public int? clinic_90_total { get; set; }
        public int? clinic_120_qty { get; set; }
        public int? clinic_120_total { get; set; }
        public int? clinic_other_qty { get; set; }
        public int? clinic_other_min { get; set; }
        public int? clinic_other_total { get; set; }
        public int? leave_halfe_qty { get; set; }
        public int? leave_halfe_min { get; set; }
        public int? leave_halfe_total { get; set; }
        public int? out_flow_qty { get; set; }
        public int? out_flow_min { get; set; }
        public int? out_flow_total { get; set; }
        public int? in_flow_qty { get; set; }
        public int? in_flow_min { get; set; }
        public int? in_flow_total { get; set; }
        public int? total_overtime { get; set; }
        [DataType("DECIMAL(18,2)")]
        public decimal?  standard_time { get; set; }
        [DataType("DECIMAL(18,2)")]
        public decimal? standard_time_op_sp { get; set; }
        [DataType("DECIMAL(18,2)")]
        public decimal? actual_time { get; set; }
        [DataType("DECIMAL(18,2)")]
        public decimal? total_time { get; set; }
        [DataType("DECIMAL(18,2)")]
        public decimal? actual_time_op_sp { get; set; }
        [DataType("DECIMAL(18,2)")]
        public decimal? total_time_op_sp { get; set; }
        public string ins_by { get; set; }
        public DateTime ins_date { get; set; }
        public string update_by { get; set; }
        public DateTime update_date { get; set; }

        // SP
        public int? ot_60_qty_sp { get; set; }
        public int? ot_120_qty_sp { get; set; }
        public int? ot_150_qty_sp { get; set; }
        public int? ot_other_qty_sp { get; set; }
        public int? clinic_30_qty_sp { get; set; }
        public int? clinic_60_qty_sp { get; set; }
        public int? clinic_90_qty_sp { get; set; }
        public int? clinic_120_qty_sp { get; set; }
        public int? clinic_other_qty_sp { get; set; }
        public int? leave_halfe_qty_sp { get; set; }
        public int? out_flow_qty_sp { get; set; }
        public int? in_flow_qty_sp { get; set; }
    }

    public class T_SUMMARY_TSS
    {
        public int? id { get; set; }
        public DateTime date_input { get; set; }
        public string wc_code { get; set; }
        public string model_code { get; set; }
        public string process_code { get; set; }
        public string cell_code { get; set; }
        public string shift_code { get; set; }
        public string production_shift { get; set; }
        public string block_group_code { get; set; }
        public string gb_cell_code { get; set; }
        public string tss_code { get; set; }
        public string extra_work_no { get; set; }
        public int? manpower_pers { get; set; }
        [DataType("DECIMAL(18,2)")]
        public decimal? tss_min { get; set; }
        public int? mc_qty { get; set; }
        [DataType("DECIMAL(18,2)")]
        public decimal? loss_time { get; set; }
        public string ins_by { get; set; }
        public DateTime ins_date { get; set; }
        public string respond { get; set; }
    }

    public class T_SUMMARY_TSS_TEMP
    {
        public int? id { get; set; }
        public DateTime date_input { get; set; }
        public string wc_code { get; set; }
        public string model_code { get; set; }
        public string process_code { get; set; }
        public string cell_code { get; set; }
        public string shift_code { get; set; }
        public string production_shift { get; set; }
        public string block_group_code { get; set; }
        public string gb_cell_code { get; set; }
        public string tss_code { get; set; }
        public string extra_work_no { get; set; }
        public int? manpower_pers { get; set; }
        [DataType("DECIMAL(18,2)")]
        public decimal? tss_min { get; set; }
        public int? mc_qty { get; set; }
        [DataType("DECIMAL(18,2)")]
        public decimal? loss_time { get; set; }
    }

    public class T_SUMMARY_DATA
    {
        public int? id { get; set; }
        public DateTime date_input { get; set; }
        public string wc_code { get; set; }
        public string model_code { get; set; }
        public string process_code { get; set; }
        public string cell_code { get; set; }
        public string shift_code { get; set; }
        public string production_shift { get; set; }
        public string block_group_code { get; set; }
        public string gb_cell_code { get; set; }

        //jks
        public int? op_meister { get; set; }
        public int? sp_meister { get; set; }
        public int? manpower { get; set; }
        public int? manpower_attendance { get; set; }
        public int? manpower_absent { get; set; }
        public int? extra_work { get; set; }
        public int? job_special { get; set; }
        public int? total_extra_job { get; set; }
        public int? actual_output { get; set; }
        public int? reject_off { get; set; }
        public int? working_time { get; set; }
        public int? working_man { get; set; }
        public int? overtime { get; set; }
        public int? accident { get; set; }
        public int? manpower_out_flow { get; set; }
        public int? manpower_in_flow { get; set; }
        public int? actual_working_man { get; set; }
        public int? detail_working { get; set; }
        public int? unknown_time { get; set; }
        public string worker_performance { get; set; }
        public string operation_rate { get; set; }
        public string total_performance { get; set; }
        public string comment { get; set; }

        //ot
        public int? ot_60_qty { get; set; }
        public int? ot_60_total { get; set; }
        public int? ot_120_qty { get; set; }
        public int? ot_120_total { get; set; }
        public int? ot_150_qty { get; set; }
        public int? ot_150_total { get; set; }
        public int? ot_other_qty { get; set; }
        public int? ot_other_min { get; set; }
        public int? ot_other_total { get; set; }
        public int? clinic_30_qty { get; set; }
        public int? clinic_30_total { get; set; }
        public int? clinic_60_qty { get; set; }
        public int? clinic_60_total { get; set; }
        public int? clinic_90_qty { get; set; }
        public int? clinic_90_total { get; set; }
        public int? clinic_120_qty { get; set; }
        public int? clinic_120_total { get; set; }
        public int? clinic_other_qty { get; set; }
        public int? clinic_other_min { get; set; }
        public int? clinic_other_total { get; set; }
        public int? leave_halfe_qty { get; set; }
        public int? leave_halfe_min { get; set; }
        public int? leave_halfe_total { get; set; }
        public int? out_flow_qty { get; set; }
        public int? out_flow_min { get; set; }
        public int? out_flow_total { get; set; }
        public int? in_flow_qty { get; set; }
        public int? in_flow_min { get; set; }
        public int? in_flow_total { get; set; }
        public int? total_overtime { get; set; }
        [DataType("DECIMAL(18,2)")]
        public decimal? standard_time { get; set; }
        [DataType("DECIMAL(18,2)")]
        public decimal? standard_time_op_sp { get; set; }
        [DataType("DECIMAL(18,2)")]
        public decimal? actual_time { get; set; }
        [DataType("DECIMAL(18,2)")]
        public decimal? total_time { get; set; }
        [DataType("DECIMAL(18,2)")]
        public decimal? actual_time_op_sp { get; set; }
        [DataType("DECIMAL(18,2)")]
        public decimal? total_time_op_sp { get; set; }

        // SP
        public int? ot_60_qty_sp { get; set; }
        public int? ot_120_qty_sp { get; set; }
        public int? ot_150_qty_sp { get; set; }
        public int? ot_other_qty_sp { get; set; }
        public int? clinic_30_qty_sp { get; set; }
        public int? clinic_60_qty_sp { get; set; }
        public int? clinic_90_qty_sp { get; set; }
        public int? clinic_120_qty_sp { get; set; }
        public int? clinic_other_qty_sp { get; set; }
        public int? leave_halfe_qty_sp { get; set; }
        public int? out_flow_qty_sp { get; set; }
        public int? in_flow_qty_sp { get; set; }

        // OP + SP
        public int? manpower_attendance_sp { get; set; }
        public int? manpower_absent_sp { get; set; }
        public int? working_man_op_sp { get; set; }
        public int? overtime_op_sp { get; set; }
        public int? accident_op_sp { get; set; }
        public int? manpower_out_flow_op_sp { get; set; }
        public int? manpower_in_flow_op_sp { get; set; }
        public int? actual_working_man_op_sp { get; set; }
        public int? detail_working_op_sp { get; set; }
        public int? unknown_time_op_sp { get; set; }
        public string worker_performance_op_sp { get; set; }
        public string operation_rate_op_sp { get; set; }
        public string total_performance_op_sp { get; set; }

        public List<T_SUMMARY_TSS> t_summary_tss { get; set; }

        public string userid { get; set; }
    }


    public class V_SUMMARY_JKS_OT
    {
        public int? id { get; set; }
        public DateTime date_input { get; set; }
        public string wc_code { get; set; }
        public string model_code { get; set; }
        public string process_code { get; set; }
        public string cell_code { get; set; }
        public string shift_code { get; set; }
        public string production_shift { get; set; }
        public string block_group_code { get; set; }
        public string gb_cell_code { get; set; }

        public string wc_detail { get; set; }
        public string model_detail { get; set; }
        public string process_detail { get; set; }
        public string cell_detail { get; set; }
        public string shift_detail { get; set; }
        public string block_group_detail { get; set; }
        public string gb_cell_detail { get; set; }
        //jks
        public int? op_meister { get; set; }
        public int? sp_meister { get; set; }
        public int? manpower { get; set; }
        public int? manpower_attendance { get; set; }
        public int? manpower_absent { get; set; }
        public int? extra_work { get; set; }
        public int? job_special { get; set; }
        public int? total_extra_job { get; set; }
        public int? actual_output { get; set; }
        public int? reject_off { get; set; }
        public int? working_time { get; set; }
        public int? working_man { get; set; }
        public int? overtime { get; set; }
        public int? accident { get; set; }
        public int? manpower_out_flow { get; set; }
        public int? manpower_in_flow { get; set; }
        public int? actual_working_man { get; set; }
        public int? detail_working { get; set; }
        public int? unknown_time { get; set; }
        public string worker_performance { get; set; }
        public string operation_rate { get; set; }
        public string total_performance { get; set; }
        public string comment { get; set; }

        //ot
        public int? ot_60_qty { get; set; }
        public int? ot_60_total { get; set; }
        public int? ot_120_qty { get; set; }
        public int? ot_120_total { get; set; }
        public int? ot_150_qty { get; set; }
        public int? ot_150_total { get; set; }
        public int? ot_other_qty { get; set; }
        public int? ot_other_min { get; set; }
        public int? ot_other_total { get; set; }
        public int? clinic_30_qty { get; set; }
        public int? clinic_30_total { get; set; }
        public int? clinic_60_qty { get; set; }
        public int? clinic_60_total { get; set; }
        public int? clinic_90_qty { get; set; }
        public int? clinic_90_total { get; set; }
        public int? clinic_120_qty { get; set; }
        public int? clinic_120_total { get; set; }
        public int? clinic_other_qty { get; set; }
        public int? clinic_other_min { get; set; }
        public int? clinic_other_total { get; set; }
        public int? leave_halfe_qty { get; set; }
        public int? leave_halfe_min { get; set; }
        public int? leave_halfe_total { get; set; }
        public int? out_flow_qty { get; set; }
        public int? out_flow_min { get; set; }
        public int? out_flow_total { get; set; }
        public int? in_flow_qty { get; set; }
        public int? in_flow_min { get; set; }
        public int? in_flow_total { get; set; }
        public int? total_overtime { get; set; }
        [DataType("DECIMAL(18,2)")]
        public decimal? standard_time { get; set; }
        [DataType("DECIMAL(18,2)")]
        public decimal? actual_time { get; set; }
        [DataType("DECIMAL(18,2)")]
        public decimal? total_time { get; set; }
        [DataType("DECIMAL(18,2)")]
        public decimal? actual_time_op_sp { get; set; }
        [DataType("DECIMAL(18,2)")]
        public decimal? total_time_op_sp { get; set; }
        
        // SP
        public int? ot_60_qty_sp { get; set; }
        public int? ot_120_qty_sp { get; set; }
        public int? ot_150_qty_sp { get; set; }
        public int? ot_other_qty_sp { get; set; }
        public int? clinic_30_qty_sp { get; set; }
        public int? clinic_60_qty_sp { get; set; }
        public int? clinic_90_qty_sp { get; set; }
        public int? clinic_120_qty_sp { get; set; }
        public int? clinic_other_qty_sp { get; set; }
        public int? leave_halfe_qty_sp { get; set; }
        public int? out_flow_qty_sp { get; set; }
        public int? in_flow_qty_sp { get; set; }

        // OP + SP
        public int? manpower_attendance_sp { get; set; }
        public int? manpower_absent_sp { get; set; }
        public int? working_man_op_sp { get; set; }
        public int? overtime_op_sp { get; set; }
        public int? accident_op_sp { get; set; }
        public int? manpower_out_flow_op_sp { get; set; }
        public int? manpower_in_flow_op_sp { get; set; }
        public int? actual_working_man_op_sp { get; set; }
        public int? detail_working_op_sp { get; set; }
        public int? unknown_time_op_sp { get; set; }
        public string worker_performance_op_sp { get; set; }
        public string operation_rate_op_sp { get; set; }
        public string total_performance_op_sp { get; set; }
    }

    public class V_SUMMARY_TSS
    {
        public int? id { get; set; }
        public DateTime date_input { get; set; }
        public string wc_code { get; set; }
        public string model_code { get; set; }
        public string process_code { get; set; }
        public string cell_code { get; set; }
        public string shift_code { get; set; }
        public string production_shift { get; set; }
        public string block_group_code { get; set; }
        public string gb_cell_code { get; set; }
        public string tss_code { get; set; }
        public string extra_work_no { get; set; }
        public int? manpower_pers { get; set; }
        public decimal? tss_min { get; set; }
        public int? mc_qty { get; set; }
        public decimal? loss_time { get; set; }

        public string shift_detail { get; set; }
    }

    public class S_SUMMARY_OUTPUT
    {
        [Key]
        public string cell { get; set; }
        public int? count_1 { get; set; }
        [DataType("DECIMAL(18,2)")]
        public decimal? qty_1 { get; set; }
    }

    public class V_CHART
    {
        [Key]
        public DateTime date_input { get; set; }
        public string wc_code { get; set; }
        public string model_code { get; set; }
        public string process_code { get; set; }
        public string process_detail { get; set; }
        public string cell_code { get; set; }
        public string shift_code { get; set; }
        public string production_shift { get; set; }
        [DataType("DECIMAL(18,2)")]
        public decimal? Total_Working_Time { get; set; }
        [DataType("DECIMAL(18,2)")]
        public decimal? Total_actual_time { get; set; }
        [DataType("DECIMAL(18,2)")]
        public decimal? Non_working_time { get; set; }
        [DataType("DECIMAL(18,2)")]
        public decimal? Total_standard_time { get; set; }
        [DataType("DECIMAL(18,2)")]
        public decimal? PF_Loss { get; set; }
        public string gb_cell_code { get; set; }

    }

    ///////////////////////////////// Report Summary
    public class Post_Summary
    {
        public string start_date { get; set; }
        public string end_date { get; set; }
        public string wc_code { get; set; }
        public string model_code { get; set; }
        public string process_code { get; set; }
        public string cell_code { get; set; }
        public string shift_code { get; set; }
    }
    public class V_Report_SummaryJKS
    {
        [Key]
        public DateTime date_input { get; set; }
        public string wc_detail { get; set; }
        public string model_detail { get; set; }
        public string process_detail { get; set; }
        public string cell_detail { get; set; }
        public string shift_detail { get; set; }
        public string production_shift { get; set; }
        public string block_group { get; set; }
        public string gb_cell_code { get; set; }
        //jks

        public int? op_meister { get; set; }
        public int? manpower_attendance { get; set; }
        public int? sp_meister { get; set; }
        public int? manpower_attendance_sp { get; set; }

        public int? manpower { get; set; }
        public int? manpower_absent { get; set; }
        public int? manpower_absent_sp { get; set; }
        public int? extra_work { get; set; }
        public int? job_special { get; set; }
        public int? total_extra_job { get; set; }
        public int? actual_output { get; set; }
        public int? reject_off { get; set; }
        public int? working_time { get; set; }
        public int? working_man { get; set; }
        public int? overtime { get; set; }
        public int? accident { get; set; }
        public int? manpower_out_flow { get; set; }
        public int? manpower_in_flow { get; set; }
        public int? actual_working_man { get; set; }
        public int? detail_working { get; set; }
        public int? unknown_time { get; set; }

        public int? working_man_op_sp { get; set; }
        public int? overtime_op_sp { get; set; }
        public int? accident_op_sp { get; set; }
        public int? manpower_out_flow_op_sp { get; set; }
        public int? manpower_in_flow_op_sp { get; set; }
        public int? actual_working_man_op_sp { get; set; }
        public int? detail_working_op_sp { get; set; }
        public int? unknown_time_op_sp { get; set; }
        public string worker_performance { get; set; }
        public string operation_rate { get; set; }
        public string total_performance { get; set; }
        public string worker_performance_op_sp { get; set; }
        public string operation_rate_op_sp { get; set; }
        public string total_performance_op_sp { get; set; }
    }
    public class V_Report_SummaryOT
    {
        [Key]
        public DateTime date_input { get; set; }
        public string wc_detail { get; set; }
        public string model_detail { get; set; }
        public string process_detail { get; set; }
        public string cell_detail { get; set; }
        public string shift_detail { get; set; }
        public string production_shift { get; set; }
        public string block_group { get; set; }
        public string gb_cell_code { get; set; }

        //ot
        public int? ot_60_qty { get; set; }
        public int? ot_60_qty_sp { get; set; }
        public int? ot_60_total { get; set; }
        public int? ot_120_qty { get; set; }
        public int? ot_120_qty_sp { get; set; }
        public int? ot_120_total { get; set; }
        public int? ot_150_qty { get; set; }
        public int? ot_150_qty_sp { get; set; }
        public int? ot_150_total { get; set; }
        public int? ot_other_qty { get; set; }
        public int? ot_other_qty_sp { get; set; }
        public int? ot_other_min { get; set; }
        public int? ot_other_total { get; set; }
        public int? clinic_30_qty { get; set; }
        public int? clinic_30_qty_sp { get; set; }
        public int? clinic_30_total { get; set; }
        public int? clinic_60_qty { get; set; }
        public int? clinic_60_qty_sp { get; set; }
        public int? clinic_60_total { get; set; }
        public int? clinic_90_qty { get; set; }
        public int? clinic_90_qty_sp { get; set; }
        public int? clinic_90_total { get; set; }
        public int? clinic_120_qty { get; set; }
        public int? clinic_120_qty_sp { get; set; }
        public int? clinic_120_total { get; set; }
        public int? clinic_other_qty { get; set; }
        public int? clinic_other_qty_sp { get; set; }
        public int? clinic_other_min { get; set; }
        public int? clinic_other_total { get; set; }
        public int? leave_halfe_qty { get; set; }
        public int? leave_halfe_qty_sp { get; set; }
        public int? leave_halfe_min { get; set; }
        public int? leave_halfe_total { get; set; }
        public int? out_flow_qty { get; set; }
        public int? out_flow_qty_sp { get; set; }
        public int? out_flow_min { get; set; }
        public int? out_flow_total { get; set; }
        public int? in_flow_qty { get; set; }
        public int? in_flow_qty_sp { get; set; }
        public int? in_flow_min { get; set; }
        public int? in_flow_total { get; set; }
        public int? total_overtime { get; set; }
        [DataType("DECIMAL(18,2)")]
        public decimal? standard_time { get; set; }
        [DataType("DECIMAL(18,2)")]
        public decimal? actual_time { get; set; }
        [DataType("DECIMAL(18,2)")]
        public decimal? total_time { get; set; }
        [DataType("DECIMAL(18,2)")]
        public decimal? standard_time_op_sp {get; set;}
        [DataType("DECIMAL(18,2)")]
        public decimal? actual_time_op_sp { get; set; }
        [DataType("DECIMAL(18,2)")]
        public decimal? total_time_op_sp { get; set; }
    }
    public class V_Report_SummaryTSS
    {
        [Key]
        public DateTime date_input { get; set; }
        public string wc_detail { get; set; }
        public string model_detail { get; set; }
        public string process_detail { get; set; }
        public string cell_detail { get; set; }
        public string shift_detail { get; set; }
        public string production_shift { get; set; }
        public string block_group { get; set; }
        public string gb_cell_code { get; set; }

        //ot
        public string tss_code { get; set; }
        public string extra_work_no { get; set; }
        public int? manpower_pers { get; set; }
        public decimal? tss_min { get; set; }
        public int? mc_qty { get; set; }
        public decimal? loss_time { get; set; }

    }
    public class V_ReportHistory
    {
        [Key]
        public DateTime date_input { get; set; }
        public string wc_detail { get; set; }
        public string model_detail { get; set; }
        public string process_detail { get; set; }
        public string cell_detail { get; set; }
        public string shift_detail { get; set; }
        public string production_shift { get; set; }
        public string block_group { get; set; }
        public string gb_cell_code { get; set; }
        //jks

        public int? op_meister { get; set; }
        public int? manpower_attendance { get; set; }
        public int? sp_meister { get; set; }
        public int? manpower_attendance_sp { get; set; }

        public int? manpower { get; set; }
        public int? manpower_absent { get; set; }
        public int? manpower_absent_sp { get; set; }
        public int? extra_work { get; set; }
        public int? job_special { get; set; }
        public int? total_extra_job { get; set; }
        public int? actual_output { get; set; }
        public int? reject_off { get; set; }
        public int? working_time { get; set; }
        public int? working_man { get; set; }
        public int? overtime { get; set; }
        public int? accident { get; set; }
        public int? manpower_out_flow { get; set; }
        public int? manpower_in_flow { get; set; }
        public int? actual_working_man { get; set; }
        public int? detail_working { get; set; }
        public int? unknown_time { get; set; }

        public int? working_man_op_sp { get; set; }
        public int? overtime_op_sp { get; set; }
        public int? accident_op_sp { get; set; }
        public int? manpower_out_flow_op_sp { get; set; }
        public int? manpower_in_flow_op_sp { get; set; }
        public int? actual_working_man_op_sp { get; set; }
        public int? detail_working_op_sp { get; set; }
        public int? unknown_time_op_sp { get; set; }
        public string worker_performance { get; set; }
        public string operation_rate { get; set; }
        public string total_performance { get; set; }
        public string worker_performance_op_sp { get; set; }
        public string operation_rate_op_sp { get; set; }
        public string total_performance_op_sp { get; set; }
        // history
        public string ins_by { get; set; }
        public string ins_date { get; set; }
        public string update_by { get; set; }
        public string update_date { get; set; }
    }
    public class Post_Calc_Actual
    {
        public string date_start { get; set; }
        public string update_by { get; set; }
        public string submit { get; set; }
    }
}