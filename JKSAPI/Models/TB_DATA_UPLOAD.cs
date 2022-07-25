using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace JKSAPI
{

    public class T_FILE_MODEL
    {
        // [Key]
        // public int id { get; set; }
        public string file_name { get; set; }
        public IFormFile file_form { get; set; }
        public string update_by { get; set; }
    }
    public class T_NADAMS
    {
        [Key]
        public DateTime date_time { get; set; }
        public string body_no { get; set; }
        public string model { get; set; }
        public string mercury { get; set; }
        public string shift { get; set; }
        public string cell { get; set; }
        public int qt_num { get; set; }
        public int qt_in_pallet { get; set; }
        public string status { get; set; }
        public string pallet_no { get; set; }
        public string carton_no { get; set; }

    }
    
    public class T_NADAMS_TEMP
    {
        [Key]
        public DateTime date_time { get; set; }
        public string body_no { get; set; }
        public string model { get; set; }
        public string mercury { get; set; }
        public string shift { get; set; }
        public string cell { get; set; }
        public int? qt_num { get; set; }
        public int? qt_in_pallet { get; set; }
        public string status { get; set; }
        public string pallet_no { get; set; }
        public string carton_no { get; set; }

    }

    public class T_ST_DB
    {
        public int id { get; set; }
        public string model { get; set; }
        public string mercury { get; set; }
        public string type { get; set; }
        public string reader { get; set; }
        public string process_name { get; set; }
        [DataType("DECIMAL(18,2)")]
        public decimal? process_qty { get; set; }
        public string cell { get; set; }
        public DateTime update_date { get; set; }
        public string update_by { get; set; }
    }

    public class T_ST_DB_TEMP
    {
        public int id { get; set; }
        public string model { get; set; }
        public string mercury { get; set; }
        public string type { get; set; }
        public string reader { get; set; }
        public string process_name { get; set; }
        [DataType("DECIMAL(18,2)")]
        public decimal? process_qty { get; set; }
        public string cell { get; set; }
        public DateTime update_date { get; set; }
        public string update_by { get; set; }
    }

    public class data_euc
    {
        public string success { get; set; }
        public List<T_EUC> data { get; set; }
    }
    public class T_EUC
    {
        public DateTime? date_time { get; set; }
        public string body_no { get; set; }
        public string model { get; set; }
        public string mercury { get; set; }
        public string shift { get; set; }
        public string cell { get; set; }
        public int? qt_num { get; set; }
        public int? qt_in_pallet { get; set; }
        public string status { get; set; }
        public string pallet_no { get; set; }
        public string carton_no { get; set; }
    }
    public class T_MER{
        public string[] mercury {get; set;}
    }

}