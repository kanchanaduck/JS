using System;
using System.ComponentModel.DataAnnotations;

namespace JKSAPI
{
    public class T_WORK_CENTER_MODEL
    {
        public int id { get; set; }
        public string wc_code { get; set; }
        public string model_code { get; set; }
        public int statusactive { get; set; }
        public string update_by { get; set; }
        public DateTime update_date { get; set; }
    }

    public class T_MODEL_PROCESS
    {
        public int id { get; set; }
        public string model_code { get; set; }
        public string process_code { get; set; }
        public int statusactive { get; set; }
        public string update_by { get; set; }
        public DateTime update_date { get; set; }
    }

    public class T_PROCESS_CELL
    {
        public int id { get; set; }
        public string process_code { get; set; }
        public string cell_code { get; set; }
        public int statusactive { get; set; }
        public string update_by { get; set; }
        public DateTime update_date { get; set; }
    }

    public class T_CELL_SHIFT
    {
        public int id { get; set; }
        public string cell_code { get; set; }
        public string shift_code { get; set; }
        public int statusactive { get; set; }
        public string update_by { get; set; }
        public DateTime update_date { get; set; }
    }

    public class T_MANPOWER
    {
        [Key]
        public int id { get; set; }
        public string wc_code { get; set; }
        public string model_code { get; set; }
        public string process_code { get; set; }
        public string cell_code { get; set; }
        public int category { get; set; }
        public string shift_code { get; set; }
        public int manpower { get; set; }
        public int op_meister { get; set; }
        public int sp_meister { get; set; }
        public DateTime update_date { get; set; }
        public string update_by { get; set; }
        public string block_group_code { get; set; }
        public string gb_cell_code { get; set; }
    }

    public class T_MANPOWER_SEARCH
    {
        public int id { get; set; }
        public string wc_code { get; set; }
        public string model_code { get; set; }
        public string process_code { get; set; }
        public string cell_code { get; set; }
        public string shift_code { get; set; }
    }


    public class V_WORK_CENTER_MODEL
    {
        public int id { get; set; }
        public string wc_code { get; set; }
        public string wc_detail { get; set; }
        public string model_code { get; set; }
        public string model_detail { get; set; }
        public int statusactive { get; set; }
    }

    public class V_MODEL_PROCESS
    {
        public int id { get; set; }
        public string model_code { get; set; }
        public string model_detail { get; set; }
        public string process_code { get; set; }
        public string process_detail { get; set; }
        public int statusactive { get; set; }
    }

    public class V_PROCESS_CELL
    {
        public int id { get; set; }
        public string process_code { get; set; }
        public string process_detail { get; set; }
        public string cell_code { get; set; }
        public string cell_detail { get; set; }
        public int statusactive { get; set; }
    }

    public class V_CELL_SHIFT
    {
        public int id { get; set; }
        public string cell_code { get; set; }
        public string cell_detail { get; set; }
        public string shift_code { get; set; }
        public string shift_detail { get; set; }
        public int statusactive { get; set; }
    }

    public class V_MANPOWER
    {
        public int id { get; set; }
        public string wc_code { get; set; }
        public string wc_detail { get; set; }
        public string model_code { get; set; }
        public string model_detail { get; set; }
        public string process_code { get; set; }
        public string process_detail { get; set; }
        public string cell_code { get; set; }
        public string cell_detail { get; set; }
        public int category { get; set; }
        public string shift_code { get; set; }
        public string shift_detail { get; set; }
        public int manpower { get; set; }
        public int op_meister { get; set; }
        public int sp_meister { get; set; }
        public string block_group_code { get; set; }
        public string block_group_detail { get; set; }
        public string gb_cell_code { get; set; }
    }
}