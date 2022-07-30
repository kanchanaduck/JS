using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Text.RegularExpressions;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.Drawing;
using System.Globalization;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;

namespace JKSAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UploadController : ControllerBase
    {
        private readonly DBContext context;
        private IConfiguration configuration;
        public UploadController(DBContext context, IConfiguration _configuration)
        {
            this.context = context;
            this.configuration = _configuration;
        }


        private int getDayNightShift(DateTime date)
        {
            // DateTime date = DateTime.Now;
            // DateTime date = new DateTime(2012, 12, 25, 23, 30, 50); 
            var hours = date.Hour;
            int shift = 0;
            if (hours >= 8 && hours <= 19)
            {
                shift = 1;
            }
            else
            {
                shift = 2;
            }
            return shift;
        }

        [HttpPost]
        [Route("UploadNadams_old")]
        public async Task<IActionResult> UploadNadams_old([FromForm] T_FILE_MODEL file)
        {
            using (var dbContextTransaction = context.Database.BeginTransaction())
            {
                try
                {
                    // var data_old = await context.T_NADAMS.ToListAsync();
                    // context.T_NADAMS.RemoveRange(data_old);
                    DataTable dt = new DataTable();
                    string constr = this.configuration.GetConnectionString("ConnStr");
                    using (SqlConnection con = new SqlConnection(constr))
                    {
                        string query = "TRUNCATE table [JKS_SYSTEM].[dbo].[T_NADAMS]";
                        using (SqlCommand cmd = new SqlCommand(query))
                        {
                            cmd.Connection = con;
                            using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                            {
                                sda.Fill(dt);
                            }
                        }
                    }

                    // //-- string path = Directory.GetCurrentDirectory();
                    // //-- string folder1 = path.Substring(path.LastIndexOf("\\") + 1);
                    // //-- path = path.Remove(path.LastIndexOf("\\"));

                    // //-- string fullpath = Path.Combine(path, "files", file.file_name);
                    // string fullpath = Path.Combine("./files/", file.file_name);

                    // using (Stream stream = new FileStream(fullpath, FileMode.Create))
                    // {
                    //     file.file_form.CopyTo(stream);

                    //     // var path = Path.Combine(Directory.GetCurrentDirectory(), file.file_name);

                    //     stream.Dispose();
                    //     stream.Close();
                    // }

                    string rootFolder = Directory.GetCurrentDirectory();
                    string pathString = @"\API site\files\jks_system\upload\";
                    string serverPath = rootFolder.Substring(0, rootFolder.LastIndexOf(@"\")) + pathString;
                    // Create Directory
                    if (!Directory.Exists(serverPath))
                    {
                        Directory.CreateDirectory(serverPath);
                    }

                    // string fullpath = serverPath + model.file_name;
                    string fullpath = Path.Combine(serverPath + file.file_name);
                    using (Stream stream = new FileStream(fullpath, FileMode.Create))
                    {
                        file.file_form.CopyTo(stream);
                        stream.Dispose();
                        stream.Close();
                    }

                    int i = 0;


                    using (StreamReader sr = new StreamReader(fullpath))
                    {
                        while (!sr.EndOfStream)
                        {
                            string line = sr.ReadLine();
                            var data = line.Split(',');

                            if (i > 0)
                            {
                                T_NADAMS model = new T_NADAMS();
                                model.date_time = Convert.ToDateTime(data[0].Trim());
                                model.body_no = data[1].Trim();
                                model.model = data[2].Trim();
                                model.mercury = data[3].Trim();
                                model.shift = data[4].Trim();
                                model.cell = data[5].Trim();
                                model.qt_num = Convert.ToInt32(data[6].Trim());
                                model.qt_in_pallet = Convert.ToInt32(data[7].Trim());
                                model.status = data[8].Trim();
                                model.pallet_no = data[9].Trim();
                                model.carton_no = data[10].Trim();
                                // model.update_date = DateTime.Now;
                                // model.update_by = file.update_by;

                                context.Add(model);
                            }

                            i++;
                        }

                        sr.Dispose();
                        sr.Close();
                    }

                    System.IO.File.Delete(fullpath);

                    await context.SaveChangesAsync();

                    // System.GC.Collect();
                    // System.GC.WaitForPendingFinalizers();
                    dbContextTransaction.Commit();
                    return Ok();

                }
                catch (Exception ex)
                {
                    dbContextTransaction.Rollback();
                    return StatusCode(500, $"Internal server error: {ex}");
                }
            }
        }

        [HttpPost]
        [Route("UploadNadams")]
        public IActionResult UploadNadams([FromForm] T_FILE_MODEL file)
        {
            try
            {
                DataTable dt = new DataTable();
                string constr = this.configuration.GetConnectionString("ConnStr");
                //////////////////////////////////////////// TRUNCATE
                using (SqlConnection con = new SqlConnection(constr))
                {
                    string query = "TRUNCATE table [JKS_SYSTEM].[dbo].[T_NADAMS_TEMP]";
                    using (SqlCommand cmd = new SqlCommand(query))
                    {
                        cmd.Connection = con;
                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            sda.Fill(dt);
                        }
                    }
                }
                
                //////////////////////////////////////////// fullpath
                // //-- string path = Directory.GetCurrentDirectory();
                // //-- string folder1 = path.Substring(path.LastIndexOf("\\") + 1);
                // //-- path = path.Remove(path.LastIndexOf("\\"));

                // //-- string fullpath = Path.Combine(path, "files", file.file_name);
                // string fullpath = Path.Combine("./files/", file.file_name);
                // using (Stream stream = new FileStream(fullpath, FileMode.Create))
                // {
                //     file.file_form.CopyTo(stream);
                //     stream.Dispose();
                //     stream.Close();
                // }

                string rootFolder = Directory.GetCurrentDirectory();
                string pathString = @"\API site\files\jks_system\upload\";
                string serverPath = rootFolder.Substring(0, rootFolder.LastIndexOf(@"\")) + pathString;
                // Create Directory
                if (!Directory.Exists(serverPath))
                {
                    Directory.CreateDirectory(serverPath);
                }

                // string fullpath = serverPath + model.file_name;
                string fullpath = Path.Combine(serverPath + file.file_name);
                using (Stream stream = new FileStream(fullpath, FileMode.Create))
                {
                    file.file_form.CopyTo(stream);
                    stream.Dispose();
                    stream.Close();
                }

                //////////////////////////////////////////// SqlBulkCopy
                var lines = System.IO.File.ReadAllLines(fullpath);
                if (lines.Count() == 0) { }

                var columns = lines[0].Split(',');
                var table = new DataTable();
                foreach (var c in columns)
                    table.Columns.Add(c);

                for (int i = 1; i < lines.Count() - 1; i++)
                    table.Rows.Add(lines[i].Split(','));

                var sqlBulk = new SqlBulkCopy(constr);
                sqlBulk.DestinationTableName = "T_NADAMS_TEMP";
                sqlBulk.WriteToServer(table);
                //////////////////////////////////////////// Delete File
                System.IO.File.Delete(fullpath);

                //////////////////////////////////////////// S_NADAMS_UPDATE
                using (SqlConnection con = new SqlConnection(constr))
                {
                    string query = @"EXEC [dbo].[S_NADAMS_UPDATE]";

                    using (SqlCommand cmd = new SqlCommand(query))
                    {
                        cmd.Connection = con;
                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            sda.Fill(dt);
                        }
                    }
                }
                // return Ok(dt);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }


        [HttpPost]
        [Route("UploadStandard")]
        public async Task<IActionResult> UploadStandard([FromForm] T_FILE_MODEL file)
        {
            try
            {
                DataTable dt = new DataTable();
                string constr = this.configuration.GetConnectionString("ConnStr");
                using (SqlConnection con = new SqlConnection(constr))
                {
                    string query = "TRUNCATE table [JKS_SYSTEM].[dbo].[T_ST_DB_TEMP]";
                    using (SqlCommand cmd = new SqlCommand(query))
                    {
                        cmd.Connection = con;
                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            sda.Fill(dt);
                        }
                    }
                }

                //-- string path = Directory.GetCurrentDirectory();
                //-- string folder1 = path.Substring(path.LastIndexOf("\\") + 1);
                //-- path = path.Remove(path.LastIndexOf("\\"));

                //-- string fullpath = Path.Combine(path, "files", file.file_name);
                // string fullpath = Path.Combine("./files/", file.file_name);

                // using (Stream stream = new FileStream(fullpath, FileMode.Create))
                // {
                //     file.file_form.CopyTo(stream);

                //     // var path = Path.Combine(Directory.GetCurrentDirectory(), file.file_name);

                //     stream.Dispose();
                //     stream.Close();
                // }

                string rootFolder = Directory.GetCurrentDirectory();
                string pathString = @"\API site\files\jks_system\upload\";
                string serverPath = rootFolder.Substring(0, rootFolder.LastIndexOf(@"\")) + pathString;
                // Create Directory
                if (!Directory.Exists(serverPath))
                {
                    Directory.CreateDirectory(serverPath);
                }

                // string fullpath = serverPath + model.file_name;
                string fullpath = Path.Combine(serverPath + file.file_name);
                using (Stream stream = new FileStream(fullpath, FileMode.Create))
                {
                    file.file_form.CopyTo(stream);
                    stream.Dispose();
                    stream.Close();
                }

                int i = 0;

                using (StreamReader sr = new StreamReader(fullpath))
                {
                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();
                        var data = line.Split(',');

                        if (i > 0)
                        {
                            T_ST_DB_TEMP model = new T_ST_DB_TEMP();
                            model.model = data[0].Trim();
                            model.mercury = data[1].Trim();
                            model.type = data[2].Trim()== "" ? null:data[2].Trim();
                            model.reader = data[3].Trim()== "" ? null:data[3].Trim();
                            model.process_name = data[4].Trim();
                            model.process_qty = data[5].Trim() == "" ? null: Convert.ToDecimal(data[5]);
                            model.cell = data[6].Trim() == "" ? null : data[6].Trim();
                            model.update_date = DateTime.Now;
                            model.update_by = file.update_by;

                            context.Add(model);
                        }

                        i++;
                    }

                    sr.Dispose();
                    sr.Close();
                }

                System.IO.File.Delete(fullpath);

                await context.SaveChangesAsync();

                //////////////////////////////////////////// S_NADAMS_UPDATE
                using (SqlConnection con = new SqlConnection(constr))
                {
                    string query = @"EXEC [dbo].[S_ST_DB_UPDATE]";

                    using (SqlCommand cmd = new SqlCommand(query))
                    {
                        cmd.Connection = con;
                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            sda.Fill(dt);
                        }
                    }
                }

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }
        [HttpPost]
        [Route("UploadEUC")]
        public async Task<IActionResult> UploadEUC()
        {
            try
            {

                using (HttpClient client = new HttpClient())
                {
                    string body = "{ \"command\": \"SELECT DISTINCT SUBSTR( DT_INVENT_FLUCT ,1 ,4 )|| '-' || SUBSTR( DT_INVENT_FLUCT ,5 ,2 ) || '-' || SUBSTR( DT_INVENT_FLUCT ,7 ,2 ) || ' ' ||SUBSTR( TM_INVENT_FLUCT ,1 ,2 )|| ':' || SUBSTR( TM_INVENT_FLUCT ,3 ,2 ) || ':' || SUBSTR( TM_INVENT_FLUCT ,5 ,2 ) || '.' || SUBSTR( TM_INVENT_FLUCT ,5 ,2 ) As DATE_TIME " +
                   " , NULL as BODY_NO, NULL as MODEL " +
                   " , NO_PARTS as MERCURY, NULL as SHIFT, NULL as CELL , QT_FLUCT as QT_NUM " +
                   " , 0 as QT_IN_PALLET, 610 as STATUS, NULL as PALLET_NO, 'EUCS-01' as CARTON_NO " +
                   " FROM E002_INVENT_TRANSFR_HISTRY  " +
                   " WHERE CD_BLOCK_TO in ('525A','525E') AND CD_BLOCK_FRM like '55%' AND CD_INOUT_STORAGE = '30' " +
                   " and dt_invent_fluct  BETWEEN TO_CHAR(ADD_MONTHS (SYSDATE,-1), 'YYYYMM')|| '01' and TO_CHAR(SYSDATE, 'YYYYMMDD')\" }";
                    //  Console.WriteLine(body);

                    client.Timeout = TimeSpan.FromSeconds(30);
                    HttpContent content = new StringContent(body, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = client.PostAsync("http://cptsvs531:1000/middleware/oracle/euc", content).Result;
                    data_euc res = JsonConvert.DeserializeObject<data_euc>(await response.Content.ReadAsStringAsync());
                    // Console.WriteLine("res: " + res.data.Count());
                    //Console.WriteLine("res: " + res.data[110].MERCURY);

                    response.EnsureSuccessStatusCode();
                    client.Dispose();

                    var uniquePersons = res.data.GroupBy(item => item.mercury)
                                        .Select(group => new { mercury = group.Key, Items = group.ToList() })
                                        .ToList();


                    var st_dbchk = await context.T_ST_DB.ToListAsync();
                    for (int i = 0; i < uniquePersons.Count(); i++)
                    {
                        var map_data = st_dbchk.Where(x => x.mercury == uniquePersons[i].mercury).Select(c => new { cell = c.cell, model = c.model }).FirstOrDefault();
                        foreach (var item in res.data.Where(w => w.mercury == uniquePersons[i].mercury))
                        {
                            if (map_data != null)
                            {
                                item.cell = map_data.cell;
                                item.model = map_data.model;
                            }
                            item.shift = getDayNightShift(Convert.ToDateTime(item.date_time)).ToString();
                        }
                    }
                    /////////////////////////////////////////////// TURUNCATE AND DELETE T_NADAMS OF EUC
                    DataTable dt = new DataTable();
                    string constr = this.configuration.GetConnectionString("ConnStr");
                    using (SqlConnection con = new SqlConnection(constr))
                    {
                        string query = "TRUNCATE table [JKS_SYSTEM].[dbo].[T_NADAMS_TEMP]; DELETE FROM T_NADAMS WHERE CARTON_NO = 'EUCS-01'; ";
                        using (SqlCommand cmd = new SqlCommand(query))
                        {
                            cmd.Connection = con;
                            using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                            {
                                sda.Fill(dt);
                            }
                        }
                    }
                    //////////////////////////////////////////// S_NADAMS_UPDATE
                    List<T_NADAMS_TEMP> lst_ins = new List<T_NADAMS_TEMP>();
                    for (int j = 0; j < res.data.Count(); j++)
                    {
                        T_NADAMS_TEMP tb_nadam_temp = new T_NADAMS_TEMP();
                        tb_nadam_temp.date_time = Convert.ToDateTime(res.data[j].date_time);
                        tb_nadam_temp.body_no = res.data[j].body_no;
                        tb_nadam_temp.model = res.data[j].model;
                        tb_nadam_temp.mercury = res.data[j].mercury;
                        tb_nadam_temp.shift = res.data[j].shift;
                        tb_nadam_temp.cell = res.data[j].cell;
                        tb_nadam_temp.qt_num = Convert.ToInt32(res.data[j].qt_num);
                        tb_nadam_temp.qt_in_pallet = Convert.ToInt32(res.data[j].qt_in_pallet);
                        tb_nadam_temp.status = res.data[j].status;
                        tb_nadam_temp.pallet_no = res.data[j].pallet_no;
                        tb_nadam_temp.carton_no = res.data[j].carton_no;
                        lst_ins.Add(tb_nadam_temp);
                    }
                    context.T_NADAMS_TEMP.AddRange(lst_ins);
                    await context.SaveChangesAsync();

                    //////////////////////////////////////////// S_NADAMS_UPDATE
                    using (SqlConnection con = new SqlConnection(constr))
                    {
                        string query = @"EXEC [dbo].[S_NADAMS_UPDATE]";

                        using (SqlCommand cmd = new SqlCommand(query))
                        {
                            cmd.Connection = con;
                            using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                            {
                                sda.Fill(dt);
                            }
                        }
                    }

                    return Ok(lst_ins);
                }
            }
            catch (Exception a)
            {
                Console.WriteLine(a.Message);
                return BadRequest(a.Message);
            }

        }

        [HttpPost]
        [Route("UploadManpower_old")]
        public async Task<IActionResult> UploadManpower_old([FromForm] T_FILE_MODEL file)
        {
            using (var dbContextTransaction = context.Database.BeginTransaction())
            {
                string update_by = file.update_by;
                string wc_detail_ck = string.Empty;
                string model_detail_ck = string.Empty;
                string process_detail_ck = string.Empty;
                string cell_detail_ck = string.Empty;
                string shift_detail_ck = string.Empty;
                try
                {
                    var data_old = await context.T_MANPOWER.ToListAsync();
                    context.T_MANPOWER.RemoveRange(data_old);

                    //-- string path = Directory.GetCurrentDirectory();
                    //-- string folder1 = path.Substring(path.LastIndexOf("\\") + 1);
                    //-- path = path.Remove(path.LastIndexOf("\\"));

                    //-- string fullpath = Path.Combine(path, "files", file.file_name);
                    string rootFolder = Directory.GetCurrentDirectory();
                    string pathString = @"\API site\files\jks_system\upload\";
                    string serverPath = rootFolder.Substring(0, rootFolder.LastIndexOf(@"\")) + pathString;
                    // Create Directory
                    if (!Directory.Exists(serverPath))
                    {
                        Directory.CreateDirectory(serverPath);
                    }

                    // string fullpath = serverPath + model.file_name;
                    string fullpath = Path.Combine(serverPath + file.file_name);
                    using (Stream stream = new FileStream(fullpath, FileMode.Create))
                    {
                        file.file_form.CopyTo(stream);
                        stream.Dispose();
                        stream.Close();
                    }

                    int i = 0; int k = 0;
                    List<string> listnon = new List<string>();

                    using (StreamReader sr = new StreamReader(fullpath))
                    {
                        while (!sr.EndOfStream)
                        {
                            string line = sr.ReadLine();
                            var data = line.Split(',');

                            if (i > 0)
                            {
                                // Console.WriteLine("i: " + i);
                                // Console.WriteLine(data[1].Trim());
                                var wc_data = await (from a in context.T_WORK_CENTER_MODEL
                                                     join b in context.M_WORK_CENTER on a.wc_code equals b.wc_code
                                                     join c in context.M_MODEL on a.model_code equals c.model_code
                                                     where b.wc_detail == data[0].Trim() && c.model_detail == data[1].Trim()
                                                     select new
                                                     {
                                                         wc_code = b.wc_code,
                                                         wc_detail = b.wc_detail,
                                                         model_code = c.model_code,
                                                         model_detail = c.model_detail
                                                     }).FirstOrDefaultAsync();
                                var model_data = await (from a in context.T_MODEL_PROCESS
                                                        join b in context.M_MODEL on a.model_code equals b.model_code
                                                        join c in context.M_PROCESS on a.process_code equals c.process_code
                                                        where b.model_detail == data[1].Trim() && c.process_detail == data[2].Trim()
                                                        select new
                                                        {
                                                            model_code = b.model_code,
                                                            model_detail = b.model_detail,
                                                            process_code = c.process_code,
                                                            process_detail = c.process_detail
                                                        }).FirstOrDefaultAsync();
                                var process_data = await (from a in context.T_PROCESS_CELL
                                                          join b in context.M_PROCESS on a.process_code equals b.process_code
                                                          join c in context.M_CELL on a.cell_code equals c.cell_code
                                                          where b.process_detail == data[2].Trim() && c.cell_detail == data[3].Trim()
                                                          select new
                                                          {
                                                              process_code = b.process_code,
                                                              process_detail = b.process_detail,
                                                              cell_code = c.cell_code,
                                                              cell_detail = c.cell_detail
                                                          }).FirstOrDefaultAsync();
                                var cell_data = await (from a in context.T_CELL_SHIFT
                                                       join b in context.M_CELL on a.cell_code equals b.cell_code
                                                       join c in context.M_BLOCK_SHIFT on a.shift_code equals c.shift_code
                                                       where b.cell_detail == data[3].Trim() && c.shift_detail == data[4].Trim()
                                                       select new
                                                       {
                                                           cell_code = b.cell_code,
                                                           cell_detail = b.cell_detail,
                                                           shift_code = c.shift_code,
                                                           shift_detail = c.shift_detail
                                                       }).FirstOrDefaultAsync();
                                var bg_data = await context.M_BLOCK_GROUP.Where(x => x.block_group_detail == data[8].Trim()).FirstOrDefaultAsync();
                                var gb_data = await context.M_GB_CELL_CODE.Where(x => x.gb_cell_code == data[9].Trim()).FirstOrDefaultAsync();

                                string str = "";
                                if (wc_data == null || model_data == null || process_data == null || cell_data == null)
                                {
                                    Console.WriteLine("null");
                                    str = data[0].Trim() + "/" + data[1].Trim() + "/" + data[2].Trim() + "/" + data[3].Trim() + "/" + data[4].Trim() + "<br> ข้อมูลชุดนี้ไม่มีใน Master Detail <br>";
                                    listnon.Add(str);

                                    k++;
                                }
                                else if (bg_data == null || gb_data == null)
                                {
                                    str = "Block Group: " + data[8].Trim() + "<br> Gobal Cell: " + data[9].Trim() + "<br> ข้อมูลชุดนี้ไม่มีใน Master Block Group or Gobal Cell <br>";
                                    listnon.Add(str);

                                    k++;
                                }
                                else
                                {
                                    T_MANPOWER model = new T_MANPOWER();
                                    model.wc_code = wc_data.wc_code.ToString();
                                    model.model_code = model_data.model_code.ToString();
                                    model.process_code = process_data.process_code.ToString();
                                    model.cell_code = cell_data.cell_code.ToString();
                                    model.shift_code = cell_data.shift_code.ToString();
                                    model.manpower = Convert.ToInt32(data[5].Trim());
                                    model.op_meister = Convert.ToInt32(data[6].Trim());
                                    model.sp_meister = Convert.ToInt32(data[7].Trim());
                                    model.update_date = DateTime.Now;
                                    model.update_by = update_by;

                                    model.block_group_code = bg_data.block_group_code.ToString();
                                    model.gb_cell_code = data[9].Trim();

                                    wc_detail_ck = wc_data.wc_detail.ToString();
                                    model_detail_ck = model_data.model_detail.ToString();
                                    process_detail_ck = process_data.process_detail.ToString();
                                    cell_detail_ck = cell_data.cell_detail.ToString();
                                    shift_detail_ck = cell_data.shift_detail.ToString();

                                    context.Add(model);
                                }
                            }
                            i++;
                        }

                        sr.Dispose();
                        sr.Close();
                    }

                    // Console.WriteLine(k.ToString());
                    // Console.WriteLine(listnon.Count().ToString());
                    if (k > 0 && k == listnon.Count())
                    {
                        return BadRequest(listnon);
                    }
                    else
                    {
                        System.IO.File.Delete(fullpath);
                        await context.SaveChangesAsync();
                        dbContextTransaction.Commit();
                        return Ok();
                    }
                }
                catch
                {
                    dbContextTransaction.Rollback();
                    return BadRequest(wc_detail_ck + "/" + model_detail_ck + "/" + process_detail_ck + "/" + cell_detail_ck + "/" + shift_detail_ck + "<br> ข้อมูลชุดนี้ไม่มีใน Master Detail.");
                }
            }
        }


        [HttpPost]
        [Route("UploadManpower")]
        public async Task<IActionResult> UploadManpower([FromForm] T_FILE_MODEL file)
        {
            try
            {
                string rootFolder = Directory.GetCurrentDirectory();
                string pathString = @"\API site\files\jks_system\upload\";
                string serverPath = rootFolder.Substring(0, rootFolder.LastIndexOf(@"\")) + pathString;
                // Create Directory
                if (!Directory.Exists(serverPath))
                {
                    Directory.CreateDirectory(serverPath);
                }

                string fullpath = Path.Combine(serverPath + file.file_name);
                using (Stream stream = new FileStream(fullpath, FileMode.Create))
                {
                    file.file_form.CopyTo(stream);
                    stream.Dispose();
                    stream.Close();
                }

                FileInfo existingFile = new FileInfo(fullpath);
                ExcelPackage package = new ExcelPackage(existingFile);
                ExcelWorksheet worksheet = package.Workbook.Worksheets.First();//Selected Specify page
                int rows = worksheet.Dimension.End.Row;
                int cols = worksheet.Dimension.End.Column;

                int k = 0;

                List<string> listnon = new List<string>();
                List<string> listnon_wc = new List<string>();
                List<string> listnon_model = new List<string>();
                List<string> listnon_process = new List<string>();
                List<string> listnon_cell = new List<string>();
                List<string> listnon_shift = new List<string>();
                List<string> listnon_bg = new List<string>();
                List<string> listnon_gb = new List<string>();

                List<T_MANPOWER> list = new List<T_MANPOWER>();

                for (int i = 1; i <= rows; i++)
                {
                    if (i > 1)
                    {
                        string wc_detail = Convert.ToString(worksheet.Cells[i, 1].Value).Trim();   //row,col
                        string model_detail = Convert.ToString(worksheet.Cells[i, 2].Value).Trim();
                        string process_detail = Convert.ToString(worksheet.Cells[i, 3].Value).Trim();
                        string cell_detail = Convert.ToString(worksheet.Cells[i, 4].Value).Trim();
                        string shift_detail = Convert.ToString(worksheet.Cells[i, 5].Value).Trim();
                        string block_group_detail = Convert.ToString(worksheet.Cells[i, 9].Value).Trim();
                        string gb_cell_code = Convert.ToString(worksheet.Cells[i, 10].Value).Trim();

                        var wc_data = await (from a in context.T_WORK_CENTER_MODEL
                                             join b in context.M_WORK_CENTER on a.wc_code equals b.wc_code
                                             join c in context.M_MODEL on a.model_code equals c.model_code
                                             where b.wc_detail == wc_detail && c.model_detail == model_detail
                                             select new
                                             {
                                                 wc_code = b.wc_code,
                                                 wc_detail = b.wc_detail,
                                                 model_code = c.model_code,
                                                 model_detail = c.model_detail
                                             }).FirstOrDefaultAsync();
                        var model_data = await (from a in context.T_MODEL_PROCESS
                                                join b in context.M_MODEL on a.model_code equals b.model_code
                                                join c in context.M_PROCESS on a.process_code equals c.process_code
                                                where b.model_detail == model_detail && c.process_detail == process_detail
                                                select new
                                                {
                                                    model_code = b.model_code,
                                                    model_detail = b.model_detail,
                                                    process_code = c.process_code,
                                                    process_detail = c.process_detail
                                                }).FirstOrDefaultAsync();
                        var process_data = await (from a in context.T_PROCESS_CELL
                                                  join b in context.M_PROCESS on a.process_code equals b.process_code
                                                  join c in context.M_CELL on a.cell_code equals c.cell_code
                                                  where b.process_detail == process_detail && c.cell_detail == cell_detail
                                                  select new
                                                  {
                                                      process_code = b.process_code,
                                                      process_detail = b.process_detail,
                                                      cell_code = c.cell_code,
                                                      cell_detail = c.cell_detail
                                                  }).FirstOrDefaultAsync();
                        var cell_data = await (from a in context.T_CELL_SHIFT
                                               join b in context.M_CELL on a.cell_code equals b.cell_code
                                               join c in context.M_BLOCK_SHIFT on a.shift_code equals c.shift_code
                                               where b.cell_detail == cell_detail && c.shift_detail == shift_detail
                                               select new
                                               {
                                                   cell_code = b.cell_code,
                                                   cell_detail = b.cell_detail,
                                                   shift_code = c.shift_code,
                                                   shift_detail = c.shift_detail
                                               }).FirstOrDefaultAsync();
                        var bg_data = await context.M_BLOCK_GROUP.Where(x => x.block_group_detail == block_group_detail).FirstOrDefaultAsync();
                        var gb_data = await context.M_GB_CELL_CODE.Where(x => x.gb_cell_code == gb_cell_code).FirstOrDefaultAsync();

                        string str = "";
                        if (wc_data == null) { listnon_wc.Add(wc_detail); }
                        if (model_data == null) { listnon_model.Add(model_detail); }
                        if (process_data == null) { listnon_process.Add(process_detail); }
                        if (cell_data == null) { listnon_cell.Add(cell_detail); listnon_shift.Add(shift_detail); }
                        if (bg_data == null) { listnon_bg.Add(block_group_detail); }
                        if (gb_data == null) { listnon_gb.Add(gb_cell_code); }


                        if (wc_data == null || model_data == null || process_data == null || cell_data == null || bg_data == null || gb_data == null)
                        {
                            str = wc_detail + "/" + model_detail + "/" + process_detail + "/" + cell_detail + "/" + shift_detail + "/" + block_group_detail + "/" + gb_cell_code + "<br> ข้อมูลชุดนี้ไม่มีใน Master<br>";
                            listnon.Add(str);
                            k++;
                        }
                        else
                        {
                            T_MANPOWER tb = new T_MANPOWER();

                            // T_MANPOWER
                            var check = await context.T_MANPOWER.AsNoTracking().Where(x => x.wc_code == wc_data.wc_code.ToString()
                            && x.model_code == model_data.model_code.ToString()
                            && x.process_code == process_data.process_code.ToString()
                            && x.cell_code == cell_data.cell_code.ToString()
                            && x.shift_code == cell_data.shift_code.ToString()
                            && x.block_group_code == bg_data.block_group_code.ToString()
                            && x.gb_cell_code == gb_cell_code).FirstOrDefaultAsync();
                            if (check == null && wc_detail != "")
                            {
                                tb.wc_code = wc_data.wc_code.ToString();
                                tb.model_code = model_data.model_code.ToString();
                                tb.process_code = process_data.process_code.ToString();
                                tb.cell_code = cell_data.cell_code.ToString();
                                tb.shift_code = cell_data.shift_code.ToString();
                                tb.manpower = Convert.ToInt32(worksheet.Cells[i, 6].Value);
                                tb.op_meister = Convert.ToInt32(worksheet.Cells[i, 7].Value);
                                tb.sp_meister = Convert.ToInt32(worksheet.Cells[i, 8].Value);
                                tb.update_date = DateTime.Now;
                                tb.update_by = file.update_by;

                                tb.block_group_code = bg_data.block_group_code.ToString();
                                tb.gb_cell_code = gb_cell_code;

                                list.Add(tb);
                            }
                        }
                    }
                }


                if (k > 0 && k == listnon.Count())
                {
                    return BadRequest(listnon);
                }
                else
                {
                    await context.T_MANPOWER.AddRangeAsync(list);

                    System.IO.File.Delete(fullpath);

                    await context.SaveChangesAsync();
                    return Ok();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                return BadRequest("Error: " + ex.Message);
            }
        }

        /////////////////////////////////////////////////////////////////
        private void stylesheets(string namesheet, List<string> headerColumns, int endCol, int recordIndex, ExcelWorksheet ws)
        {
            int index = 1;
            foreach (var item in headerColumns)
            {
                ws.Cells[1, index++].Value = item;
            }
        }

        [HttpPost]
        [Route("upload_master_detail")]
        public async Task<IActionResult> upload_master_detail([FromForm] T_FILE_MODEL file)
        {
            try
            {
                //-- string path = Directory.GetCurrentDirectory();
                //-- string folder1 = path.Substring(path.LastIndexOf("\\") + 1);
                //-- path = path.Remove(path.LastIndexOf("\\"));

                //-- string fullpath = Path.Combine(path, "files", file.file_name);
                // string fullpath = Path.Combine("./files/", file.file_name);

                // using (Stream stream = new FileStream(fullpath, FileMode.Create))
                // {
                //     file.file_form.CopyTo(stream);
                //     stream.Dispose();
                //     stream.Close();
                // }

                string rootFolder = Directory.GetCurrentDirectory();
                string pathString = @"\API site\files\jks_system\upload\";
                string serverPath = rootFolder.Substring(0, rootFolder.LastIndexOf(@"\")) + pathString;
                // Create Directory
                if (!Directory.Exists(serverPath))
                {
                    Directory.CreateDirectory(serverPath);
                }

                // string fullpath = serverPath + model.file_name;
                string fullpath = Path.Combine(serverPath + file.file_name);
                using (Stream stream = new FileStream(fullpath, FileMode.Create))
                {
                    file.file_form.CopyTo(stream);
                    stream.Dispose();
                    stream.Close();
                }

                FileInfo existingFile = new FileInfo(fullpath);
                ExcelPackage package = new ExcelPackage(existingFile);
                ExcelWorksheet ws1 = package.Workbook.Worksheets["Master"];//Selected Specify page
                ExcelWorksheet ws2 = package.Workbook.Worksheets["Detail"];//Selected Specify page
                int rows = ws1.Dimension.End.Row;
                int cols = ws1.Dimension.End.Column;

                int rows2 = ws2.Dimension.End.Row;
                int cols2 = ws2.Dimension.End.Column;

                TB_DATA_WC list1 = new TB_DATA_WC();
                TB_DATA_MODEL list2 = new TB_DATA_MODEL();
                TB_DATA_PROCESS list3 = new TB_DATA_PROCESS();
                TB_DATA_CELL list4 = new TB_DATA_CELL();
                TB_DATA_SHIFT list5 = new TB_DATA_SHIFT();
                TB_DATA_BLOCK_GROUP list6 = new TB_DATA_BLOCK_GROUP();
                TB_DATA_GB_CELL list7 = new TB_DATA_GB_CELL();

                for (int i = 2; i <= rows; i++)
                {
                    string data1 = Convert.ToString(ws1.Cells[i, 1].Value); //wc
                    string data2 = Convert.ToString(ws1.Cells[i, 2].Value); //model
                    string data3 = Convert.ToString(ws1.Cells[i, 3].Value); //model_child
                    string data4 = Convert.ToString(ws1.Cells[i, 4].Value); //process
                    string data5 = Convert.ToString(ws1.Cells[i, 5].Value); //cell
                    string data6 = Convert.ToString(ws1.Cells[i, 6].Value); //shift
                    string data7 = Convert.ToString(ws1.Cells[i, 7].Value); //bg
                    string data8 = Convert.ToString(ws1.Cells[i, 8].Value); //bg
                    string data9 = Convert.ToString(ws1.Cells[i, 9].Value); //gb
                    string data10 = Convert.ToString(ws1.Cells[i, 10].Value);   //gb
                    if (data3 == "")
                    {
                        return BadRequest("กรุณากรอกข้อมูลคอลัมน์ model_child");
                    }
                    if (data8 == "")
                    {
                        return BadRequest("กรุณากรอกข้อมูลคอลัมน์ block_group_detail");
                    }
                    if (data10 == "")
                    {
                        return BadRequest("กรุณากรอกข้อมูลคอลัมน์ gb_cell_detail");
                    }

                    if (data1 != "")
                    {
                        var wc_data = context.M_WORK_CENTER.Where(e => e.wc_detail == data1.Trim()).FirstOrDefault();
                        if (wc_data == null)
                        {
                            var values_last = await context.M_WORK_CENTER.OrderByDescending(x => x.wc_code).Take(1).FirstOrDefaultAsync();
                            string gen_code = "WC-" + (Convert.ToInt32(values_last.wc_code.ToString().Substring(3, 3)) + 1).ToString("000");

                            list1.wc_code = gen_code;
                            list1.wc_detail = data1.ToString();
                            list1.statusactive = 1;
                            list1.update_by = file.update_by;
                            list1.update_date = DateTime.Now;
                            context.Add(list1);
                            await context.SaveChangesAsync();
                        }
                        else
                        {
                            var checkdata = context.M_WORK_CENTER.FirstOrDefault(x => x.wc_detail == data1.Trim() && x.statusactive == 0);
                            if (checkdata != null)
                            {
                                checkdata.statusactive = 1;
                                checkdata.update_by = file.update_by;
                                checkdata.update_date = DateTime.Now;
                                await context.SaveChangesAsync();
                            }
                        }
                    }

                    if (data2 != "")
                    {
                        var model_data = context.M_MODEL.Where(e => e.model_detail == data2.Trim()).FirstOrDefault();
                        if (model_data == null)
                        {
                            var values_last = await context.M_MODEL.OrderByDescending(x => x.model_code).Take(1).FirstOrDefaultAsync();
                            string gen_code = "M-" + (Convert.ToInt32(values_last.model_code.ToString().Substring(2, 3)) + 1).ToString("000");
                            list2.model_code = gen_code;
                            list2.model_detail = data2.Trim().ToString();
                            list2.model_child = data3.Trim().Replace("\"", "").ToString();
                            list2.statusactive = 1;
                            list2.update_by = file.update_by;
                            list2.update_date = DateTime.Now;
                            context.Add(list2);
                            await context.SaveChangesAsync();
                        }
                        else
                        {
                            var checkdata = context.M_MODEL.FirstOrDefault(x => x.model_detail == data2.Trim() && x.statusactive == 0);
                            if (checkdata != null)
                            {
                                checkdata.model_child = data3.Trim().Replace("\"", "").ToString();
                                checkdata.statusactive = 1;
                                checkdata.update_by = file.update_by;
                                checkdata.update_date = DateTime.Now;
                                await context.SaveChangesAsync();
                            }
                        }
                    }

                    if (data4 != "")
                    {
                        var process_data = context.M_PROCESS.Where(e => e.process_detail == data4.Trim()).FirstOrDefault();

                        if (process_data == null)
                        {
                            var values_last = await context.M_PROCESS.OrderByDescending(x => x.process_code).Take(1).FirstOrDefaultAsync();
                            string gen_code = "P-" + (Convert.ToInt32(values_last.process_code.ToString().Substring(2, 3)) + 1).ToString("000");
                            list3.process_code = gen_code;
                            list3.process_detail = data4.Trim().ToString();
                            list3.statusactive = 1;
                            list3.update_by = file.update_by;
                            list3.update_date = DateTime.Now;
                            context.Add(list3);
                            await context.SaveChangesAsync();
                        }
                        else
                        {
                            var checkdata = context.M_PROCESS.FirstOrDefault(x => x.process_detail == data4.Trim() && x.statusactive == 0);
                            if (checkdata != null)
                            {
                                checkdata.statusactive = 1;
                                checkdata.update_by = file.update_by;
                                checkdata.update_date = DateTime.Now;
                                await context.SaveChangesAsync();
                            }
                        }
                    }

                    if (data5 != "")
                    {
                        var cell_data = context.M_CELL.Where(e => e.cell_detail == data5.Trim()).FirstOrDefault();

                        if (cell_data == null)
                        {
                            var values_last = await context.M_CELL.OrderByDescending(x => x.cell_code).Take(1).FirstOrDefaultAsync();
                            string gen_code = "C-" + (Convert.ToInt32(values_last.cell_code.ToString().Substring(2, 3)) + 1).ToString("000");
                            list4.cell_code = gen_code;
                            list4.cell_detail = data5.Trim().ToString();
                            list4.statusactive = 1;
                            list4.update_by = file.update_by;
                            list4.update_date = DateTime.Now;
                            context.Add(list4);
                            await context.SaveChangesAsync();
                        }
                        else
                        {
                            var vaules2 = context.M_CELL.FirstOrDefault(x => x.cell_detail == data5.Trim() && x.statusactive == 0);
                            if (vaules2 != null)
                            {
                                vaules2.statusactive = 1;
                                vaules2.update_date = DateTime.Now;
                                await context.SaveChangesAsync();
                            }
                        }
                    }

                    if (data6 != "")
                    {
                        var shift_data = context.M_BLOCK_SHIFT.Where(e => e.shift_detail == data6.Trim()).FirstOrDefault();

                        if (shift_data == null)
                        {
                            var values_last = await context.M_BLOCK_SHIFT.OrderByDescending(x => x.shift_code).Take(1).FirstOrDefaultAsync();
                            string gen_code = "S-" + (Convert.ToInt32(values_last.shift_code.ToString().Substring(2, 3)) + 1).ToString("000");
                            list5.shift_code = gen_code;
                            list5.shift_detail = data6.Trim().ToString();
                            list5.statusactive = 1;
                            list5.update_by = file.update_by;
                            list5.update_date = DateTime.Now;
                            context.Add(list5);
                            await context.SaveChangesAsync();
                        }
                        else
                        {
                            var vaules2 = context.M_BLOCK_SHIFT.FirstOrDefault(x => x.shift_detail == data6.Trim() && x.statusactive == 0);
                            if (vaules2 != null)
                            {
                                vaules2.statusactive = 1;
                                vaules2.update_date = DateTime.Now;
                                await context.SaveChangesAsync();
                            }
                        }
                    }

                    if (data7 != "")
                    {
                        var group_data = context.M_BLOCK_GROUP.Where(e => e.block_group_code == data7.Trim() && e.block_group_detail == data8.Trim()).FirstOrDefault();

                        if (group_data == null)
                        {
                            list6.block_group_code = data7.Trim().ToString();
                            list6.block_group_detail = data8.Trim().ToString();
                            list6.statusactive = 1;
                            list6.update_by = file.update_by;
                            list6.update_date = DateTime.Now;
                            context.Add(list6);
                            await context.SaveChangesAsync();
                        }
                        else
                        {
                            var vaules2 = context.M_BLOCK_GROUP.FirstOrDefault(x => x.block_group_detail == data8.Trim() && x.statusactive == 0);
                            if (vaules2 != null)
                            {
                                vaules2.statusactive = 1;
                                vaules2.update_date = DateTime.Now;
                                await context.SaveChangesAsync();
                            }
                        }
                    }

                    if (data9 != "")
                    {
                        var gb_data = context.M_GB_CELL_CODE.Where(e => e.gb_cell_code == data9.Trim() && e.gb_cell_detail == data10.Trim()).FirstOrDefault();

                        if (gb_data == null)
                        {
                            list7.gb_cell_code = data9.Trim().ToString();
                            list7.gb_cell_detail = data10.Trim().ToString();
                            list7.statusactive = 1;
                            list7.update_by = file.update_by;
                            list7.update_date = DateTime.Now;
                            context.Add(list7);
                            await context.SaveChangesAsync();
                        }
                        else
                        {
                            var vaules2 = context.M_GB_CELL_CODE.FirstOrDefault(x => x.gb_cell_detail == data10.Trim() && x.statusactive == 0);
                            if (vaules2 != null)
                            {
                                vaules2.statusactive = 1;
                                vaules2.update_date = DateTime.Now;
                                await context.SaveChangesAsync();
                            }
                        }
                    }
                }

                T_WORK_CENTER_MODEL model1 = new T_WORK_CENTER_MODEL();
                T_MODEL_PROCESS model2 = new T_MODEL_PROCESS();
                T_PROCESS_CELL model3 = new T_PROCESS_CELL();
                T_CELL_SHIFT model4 = new T_CELL_SHIFT();
                for (int j = 2; j <= rows2; j++)
                {
                    string d1 = Convert.ToString(ws2.Cells[j, 1].Value);
                    string d2 = Convert.ToString(ws2.Cells[j, 2].Value);
                    string d3 = Convert.ToString(ws2.Cells[j, 3].Value);
                    string d4 = Convert.ToString(ws2.Cells[j, 4].Value);
                    string d5 = Convert.ToString(ws2.Cells[j, 5].Value);
                    string d6 = Convert.ToString(ws2.Cells[j, 6].Value);
                    string d7 = Convert.ToString(ws2.Cells[j, 7].Value);
                    string d8 = Convert.ToString(ws2.Cells[j, 8].Value);

                    if (d1 != "" && d2 != "")
                    {
                        var wc_data = context.M_WORK_CENTER.Where(e => e.wc_detail == d1.Trim()).FirstOrDefault();
                        var model_data = context.M_MODEL.Where(e => e.model_detail == d2.Trim()).FirstOrDefault();
                        if (wc_data == null || model_data == null)
                        {
                            return BadRequest("WC : " + d1 + "<br> Model : " + d2 + "<br> ไม่สามารถเพิ่มข้อมูลได้ เนื่องจากไม่มีใน Master");
                        }
                        else
                        {
                            var vaules = await context.T_WORK_CENTER_MODEL.FirstOrDefaultAsync(x => x.wc_code == wc_data.wc_code.ToString() && x.model_code == model_data.model_code.ToString());
                            if (vaules == null)
                            {
                                model1.wc_code = wc_data.wc_code.ToString();
                                model1.model_code = model_data.model_code.ToString();
                                model1.statusactive = 1;
                                model1.update_by = file.update_by;
                                model1.update_date = DateTime.Now;
                                context.Add(model1);
                                await context.SaveChangesAsync();
                            }
                        }
                    }

                    if (d3 != "" && d4 != "")
                    {
                        var model_data = context.M_MODEL.Where(e => e.model_detail == d3.Trim()).FirstOrDefault();
                        var process_data = context.M_PROCESS.Where(e => e.process_detail == d4.Trim()).FirstOrDefault();
                        if (model_data == null || process_data == null)
                        {
                            return BadRequest("Model : " + d2 + "<br> Process : " + d4 + "<br> ไม่สามารถเพิ่มข้อมูลได้ เนื่องจากไม่มีใน Master");
                        }
                        else
                        {
                            var vaules = await context.T_MODEL_PROCESS.FirstOrDefaultAsync(x => x.model_code == model_data.model_code.ToString() && x.process_code == process_data.process_code.ToString());
                            if (vaules == null)
                            {
                                model2.model_code = model_data.model_code.ToString();
                                model2.process_code = process_data.process_code.ToString();
                                model2.statusactive = 1;
                                model2.update_by = file.update_by;
                                model2.update_date = DateTime.Now;
                                context.Add(model2);
                                await context.SaveChangesAsync();
                            }
                        }
                    }

                    if (d5 != "" && d6 != "")
                    {
                        var process_data = context.M_PROCESS.Where(e => e.process_detail == d5.Trim()).FirstOrDefault();
                        var cell_data = context.M_CELL.Where(e => e.cell_detail == d6.Trim()).FirstOrDefault();
                        if (process_data == null || cell_data == null)
                        {
                            return BadRequest("Process : " + d5 + "<br> Cell : " + d6 + "<br> ไม่สามารถเพิ่มข้อมูลได้ เนื่องจากไม่มีใน Master");
                        }
                        else
                        {
                            var vaules = await context.T_PROCESS_CELL.FirstOrDefaultAsync(x => x.process_code == process_data.process_code.ToString() && x.cell_code == cell_data.cell_code.ToString());
                            if (vaules == null)
                            {
                                model3.process_code = process_data.process_code.ToString();
                                model3.cell_code = cell_data.cell_code.ToString();
                                model3.statusactive = 1;
                                model3.update_by = file.update_by;
                                model3.update_date = DateTime.Now;
                                context.Add(model3);
                                await context.SaveChangesAsync();
                            }
                        }
                    }

                    if (d7 != "" && d8 != "")
                    {
                        var cell_data = context.M_CELL.Where(e => e.cell_detail == d7.Trim()).FirstOrDefault();
                        var shift_data = context.M_BLOCK_SHIFT.Where(e => e.shift_detail == d8.Trim()).FirstOrDefault();
                        if (cell_data == null || shift_data == null)
                        {
                            return BadRequest("Cell : " + d7 + "<br> Shift : " + d8 + "<br> ไม่สามารถเพิ่มข้อมูลได้ เนื่องจากไม่มีใน Master");
                        }
                        else
                        {
                            var vaules = await context.T_CELL_SHIFT.FirstOrDefaultAsync(x => x.cell_code == cell_data.cell_code.ToString() && x.shift_code == shift_data.shift_code.ToString());
                            if (vaules == null)
                            {
                                model4.cell_code = cell_data.cell_code.ToString();
                                model4.shift_code = shift_data.shift_code.ToString();
                                model4.statusactive = 1;
                                model4.update_by = file.update_by;
                                model4.update_date = DateTime.Now;
                                context.Add(model4);
                                await context.SaveChangesAsync();
                            }
                        }
                    }
                }

                System.IO.File.Delete(fullpath);  //Delete file new part
                return Ok();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                return BadRequest("กรุณาติดต่อ Admin ICD: " + ex.Message);
            }
        }


        //////////////////////////////////////////////////////////////////////////
        //                          Upload Master                               //
        [HttpPost]
        [Route("UploadWorkCenter")]
        public async Task<IActionResult> UploadWorkCenter([FromForm] T_FILE_MODEL file)
        {
            using (var dbContextTransaction = context.Database.BeginTransaction())
            {
                TB_DATA_WC model = new TB_DATA_WC();
                string wc_detail_ck = string.Empty;
                try
                {
                     string rootFolder = Directory.GetCurrentDirectory();
                    string pathString = @"\API site\files\jks_system\upload\";
                    string serverPath = rootFolder.Substring(0, rootFolder.LastIndexOf(@"\")) + pathString;
                    // Create Directory
                    if (!Directory.Exists(serverPath))
                    {
                        Directory.CreateDirectory(serverPath);
                    }

                    // string fullpath = serverPath + model.file_name;
                    string fullpath = Path.Combine(serverPath + file.file_name);
                    using (Stream stream = new FileStream(fullpath, FileMode.Create))
                    {
                        file.file_form.CopyTo(stream);
                        stream.Dispose();
                        stream.Close();
                    }

                    int i = 0;
                    using (StreamReader sr = new StreamReader(fullpath))
                    {
                        while (!sr.EndOfStream)
                        {
                            string line = sr.ReadLine();
                            var data = line.Split(',');

                            if (i > 0)
                            {
                                var wc_data = context.M_WORK_CENTER.Where(e => e.wc_detail == data[0].Trim()).FirstOrDefault();

                                if (wc_data == null)
                                {
                                    var values_last = await context.M_WORK_CENTER.OrderByDescending(x => x.wc_code).Take(1).FirstOrDefaultAsync();
                                    string gen_code = "WC-" + (Convert.ToInt32(values_last.wc_code.ToString().Substring(3, 3)) + 1).ToString("000");

                                    model.wc_code = gen_code;
                                    model.wc_detail = data[0].Trim().ToString();
                                    model.statusactive = 1;
                                    model.update_by = file.update_by;
                                    model.update_date = DateTime.Now;

                                    wc_detail_ck = data[0].Trim().ToString();
                                    context.Add(model);
                                    await context.SaveChangesAsync();
                                }
                                else
                                {
                                    var checkdata = context.M_WORK_CENTER.FirstOrDefault(x => x.wc_detail == data[0].Trim() && x.statusactive == 0);
                                    if (checkdata != null)
                                    {
                                        checkdata.statusactive = 1;
                                        checkdata.update_by = file.update_by;
                                        checkdata.update_date = DateTime.Now;
                                        await context.SaveChangesAsync();
                                    }
                                }
                            }

                            i++;
                        }

                        sr.Dispose();
                        sr.Close();
                    }

                    System.IO.File.Delete(fullpath);

                    dbContextTransaction.Commit();
                    return Ok();
                }
                catch
                {
                    dbContextTransaction.Rollback();
                    return BadRequest(wc_detail_ck + " ไม่สามารถเพิ่มข้อมูลได้");
                }
            }
        }

        [HttpPost]
        [Route("UploadModel")]
        public async Task<IActionResult> UploadModel([FromForm] T_FILE_MODEL file)
        {
            using (var dbContextTransaction = context.Database.BeginTransaction())
            {
                TB_DATA_MODEL model = new TB_DATA_MODEL();
                string model_detail_ck = string.Empty;
                try
                {
                    //-- string path = Directory.GetCurrentDirectory();
                    //-- string folder1 = path.Substring(path.LastIndexOf("\\") + 1);
                    //-- path = path.Remove(path.LastIndexOf("\\"));

                    //-- string fullpath = Path.Combine(path, "files", file.file_name);
                    // string fullpath = Path.Combine("./files/", file.file_name);

                    // using (Stream stream = new FileStream(fullpath, FileMode.Create))
                    // {
                    //     file.file_form.CopyTo(stream);
                    //     // var path = Path.Combine(Directory.GetCurrentDirectory(), file.file_name);
                    //     stream.Dispose();
                    //     stream.Close();
                    // }

                    string rootFolder = Directory.GetCurrentDirectory();
                    string pathString = @"\API site\files\jks_system\upload\";
                    string serverPath = rootFolder.Substring(0, rootFolder.LastIndexOf(@"\")) + pathString;
                    // Create Directory
                    if (!Directory.Exists(serverPath))
                    {
                        Directory.CreateDirectory(serverPath);
                    }

                    // string fullpath = serverPath + model.file_name;
                    string fullpath = Path.Combine(serverPath + file.file_name);
                    using (Stream stream = new FileStream(fullpath, FileMode.Create))
                    {
                        file.file_form.CopyTo(stream);
                        stream.Dispose();
                        stream.Close();
                    }

                    int i = 0;
                    using (StreamReader sr = new StreamReader(fullpath))
                    {
                        while (!sr.EndOfStream)
                        {
                            string line = sr.ReadLine();
                            // var data = line.Split(',');
                            string[] data = Regex.Split(line, ",(?=(?:[^\"]*\"[^\"]*\")*(?![^\"]*\"))");
                            // Console.WriteLine(data[0].ToString());
                            // Console.WriteLine(data[1].ToString());

                            if (i > 0)
                            {
                                var model_data = context.M_MODEL.Where(e => e.model_detail == data[0].Trim()).FirstOrDefault();

                                if (model_data == null)
                                {
                                    var values_last = await context.M_MODEL.OrderByDescending(x => x.model_code).Take(1).FirstOrDefaultAsync();
                                    string gen_code = "M-" + (Convert.ToInt32(values_last.model_code.ToString().Substring(2, 3)) + 1).ToString("000");
                                    model.model_code = gen_code;
                                    model.model_detail = data[0].Trim().ToString();
                                    model.model_child = data[1].Trim().Replace("\"", "").ToString();
                                    model.statusactive = 1;
                                    model.update_by = file.update_by;
                                    model.update_date = DateTime.Now;

                                    model_detail_ck = data[0].Trim().ToString();
                                    context.Add(model);
                                    await context.SaveChangesAsync();
                                }
                                else
                                {
                                    var checkdata = context.M_MODEL.FirstOrDefault(x => x.model_detail == data[0].Trim() && x.statusactive == 0);
                                    if (checkdata != null)
                                    {
                                        checkdata.model_child = data[1].Trim().Replace("\"", "").ToString();
                                        checkdata.statusactive = 1;
                                        checkdata.update_by = file.update_by;
                                        checkdata.update_date = DateTime.Now;
                                        await context.SaveChangesAsync();
                                    }
                                }
                            }

                            i++;
                        }

                        sr.Dispose();
                        sr.Close();
                    }

                    System.IO.File.Delete(fullpath);

                    dbContextTransaction.Commit();
                    return Ok();
                }
                catch
                {
                    dbContextTransaction.Rollback();
                    return BadRequest(model_detail_ck + " ไม่สามารถเพิ่มข้อมูลได้");
                }
            }
        }

        [HttpPost]
        [Route("UploadProcess")]
        public async Task<IActionResult> UploadProcess([FromForm] T_FILE_MODEL file)
        {
            using (var dbContextTransaction = context.Database.BeginTransaction())
            {
                TB_DATA_PROCESS model = new TB_DATA_PROCESS();
                string process_detail_ck = string.Empty;
                try
                {
                     string rootFolder = Directory.GetCurrentDirectory();
                    string pathString = @"\API site\files\jks_system\upload\";
                    string serverPath = rootFolder.Substring(0, rootFolder.LastIndexOf(@"\")) + pathString;
                    // Create Directory
                    if (!Directory.Exists(serverPath))
                    {
                        Directory.CreateDirectory(serverPath);
                    }

                    // string fullpath = serverPath + model.file_name;
                    string fullpath = Path.Combine(serverPath + file.file_name);
                    using (Stream stream = new FileStream(fullpath, FileMode.Create))
                    {
                        file.file_form.CopyTo(stream);
                        stream.Dispose();
                        stream.Close();
                    }

                    int i = 0;
                    using (StreamReader sr = new StreamReader(fullpath))
                    {
                        while (!sr.EndOfStream)
                        {
                            string line = sr.ReadLine();
                            var data = line.Split(',');

                            if (i > 0)
                            {
                                var process_data = context.M_PROCESS.Where(e => e.process_detail == data[0].Trim()).FirstOrDefault();

                                if (process_data == null)
                                {
                                    var values_last = await context.M_PROCESS.OrderByDescending(x => x.process_code).Take(1).FirstOrDefaultAsync();
                                    string gen_code = "P-" + (Convert.ToInt32(values_last.process_code.ToString().Substring(2, 3)) + 1).ToString("000");
                                    model.process_code = gen_code;
                                    model.process_detail = data[0].Trim().ToString();
                                    model.update_by = file.update_by;
                                    model.update_date = DateTime.Now;
                                    process_detail_ck = data[0].Trim().ToString();
                                    context.Add(model);
                                    await context.SaveChangesAsync();
                                }
                                else
                                {
                                    var checkdata = context.M_PROCESS.FirstOrDefault(x => x.process_detail == data[0].Trim() && x.statusactive == 0);
                                    if (checkdata != null)
                                    {
                                        checkdata.statusactive = 1;
                                        checkdata.update_by = file.update_by;
                                        checkdata.update_date = DateTime.Now;
                                        await context.SaveChangesAsync();
                                    }
                                }
                            }

                            i++;
                        }

                        sr.Dispose();
                        sr.Close();
                    }

                    System.IO.File.Delete(fullpath);

                    dbContextTransaction.Commit();
                    return Ok();
                }
                catch
                {
                    dbContextTransaction.Rollback();
                    return BadRequest(process_detail_ck + " ไม่สามารถเพิ่มข้อมูลได้");
                }
            }
        }

        [HttpPost]
        [Route("UploadCell")]
        public async Task<IActionResult> UploadCell([FromForm] T_FILE_MODEL file)
        {
            using (var dbContextTransaction = context.Database.BeginTransaction())
            {
                TB_DATA_CELL model = new TB_DATA_CELL();
                string cell_detail_ck = string.Empty;
                try
                {
                    //-- string path = Directory.GetCurrentDirectory();
                    //-- string folder1 = path.Substring(path.LastIndexOf("\\") + 1);
                    //-- path = path.Remove(path.LastIndexOf("\\"));

                    //-- string fullpath = Path.Combine(path, "files", file.file_name);
                    // string fullpath = Path.Combine("./files/", file.file_name);

                    // using (Stream stream = new FileStream(fullpath, FileMode.Create))
                    // {
                    //     file.file_form.CopyTo(stream);
                    //     // var path = Path.Combine(Directory.GetCurrentDirectory(), file.file_name);
                    //     stream.Dispose();
                    //     stream.Close();
                    // }

                    string rootFolder = Directory.GetCurrentDirectory();
                    string pathString = @"\API site\files\jks_system\upload\";
                    string serverPath = rootFolder.Substring(0, rootFolder.LastIndexOf(@"\")) + pathString;
                    // Create Directory
                    if (!Directory.Exists(serverPath))
                    {
                        Directory.CreateDirectory(serverPath);
                    }

                    // string fullpath = serverPath + model.file_name;
                    string fullpath = Path.Combine(serverPath + file.file_name);
                    using (Stream stream = new FileStream(fullpath, FileMode.Create))
                    {
                        file.file_form.CopyTo(stream);
                        stream.Dispose();
                        stream.Close();
                    }

                    int i = 0;
                    using (StreamReader sr = new StreamReader(fullpath))
                    {
                        while (!sr.EndOfStream)
                        {
                            string line = sr.ReadLine();
                            var data = line.Split(',');

                            if (i > 0)
                            {
                                var cell_data = context.M_CELL.Where(e => e.cell_detail == data[0].Trim()).FirstOrDefault();

                                if (cell_data == null)
                                {
                                    Console.WriteLine("Null");
                                    var values_last = await context.M_CELL.OrderByDescending(x => x.cell_code).Take(1).FirstOrDefaultAsync();
                                    string gen_code = "C-" + (Convert.ToInt32(values_last.cell_code.ToString().Substring(2, 3)) + 1).ToString("000");
                                    model.cell_code = gen_code;
                                    model.cell_detail = data[0].Trim().ToString();
                                    cell_detail_ck = data[0].Trim().ToString();
                                    context.Add(model);
                                    await context.SaveChangesAsync();
                                }
                                else
                                {
                                    var vaules2 = context.M_CELL.FirstOrDefault(x => x.cell_detail == data[0].Trim() && x.statusactive == 0);
                                    if (vaules2 != null)
                                    {
                                        Console.WriteLine("!= null");
                                        vaules2.statusactive = 1;
                                        vaules2.update_date = DateTime.Now;
                                        await context.SaveChangesAsync();
                                    }
                                }
                            }

                            i++;
                        }

                        sr.Dispose();
                        sr.Close();
                    }

                    System.IO.File.Delete(fullpath);

                    dbContextTransaction.Commit();
                    return Ok();
                }
                catch
                {
                    dbContextTransaction.Rollback();
                    return BadRequest(cell_detail_ck + " ไม่สามารถเพิ่มข้อมูลได้");
                }
            }
        }

        [HttpPost]
        [Route("UploadBlockShift")]
        public async Task<IActionResult> UploadBlockShift([FromForm] T_FILE_MODEL file)
        {
            using (var dbContextTransaction = context.Database.BeginTransaction())
            {
                TB_DATA_SHIFT model = new TB_DATA_SHIFT();
                string shift_detail_ck = string.Empty;
                try
                {
                    string rootFolder = Directory.GetCurrentDirectory();
                    string pathString = @"\API site\files\jks_system\upload\";
                    string serverPath = rootFolder.Substring(0, rootFolder.LastIndexOf(@"\")) + pathString;
                    // Create Directory
                    if (!Directory.Exists(serverPath))
                    {
                        Directory.CreateDirectory(serverPath);
                    }

                    // string fullpath = serverPath + model.file_name;
                    string fullpath = Path.Combine(serverPath + file.file_name);
                    using (Stream stream = new FileStream(fullpath, FileMode.Create))
                    {
                        file.file_form.CopyTo(stream);
                        stream.Dispose();
                        stream.Close();
                    }

                    int i = 0;
                    using (StreamReader sr = new StreamReader(fullpath))
                    {
                        while (!sr.EndOfStream)
                        {
                            string line = sr.ReadLine();
                            var data = line.Split(',');

                            if (i > 0)
                            {
                                var shift_data = context.M_BLOCK_SHIFT.Where(e => e.shift_detail == data[0].Trim()).FirstOrDefault();

                                if (shift_data == null)
                                {
                                    Console.WriteLine("Null");
                                    var values_last = await context.M_BLOCK_SHIFT.OrderByDescending(x => x.shift_code).Take(1).FirstOrDefaultAsync();
                                    string gen_code = "S-" + (Convert.ToInt32(values_last.shift_code.ToString().Substring(2, 3)) + 1).ToString("000");
                                    model.shift_code = gen_code;
                                    model.shift_detail = data[0].Trim().ToString();
                                    shift_detail_ck = data[0].Trim().ToString();
                                    context.Add(model);
                                    await context.SaveChangesAsync();
                                }
                                else
                                {
                                    var vaules2 = context.M_BLOCK_SHIFT.FirstOrDefault(x => x.shift_detail == data[0].Trim() && x.statusactive == 0);
                                    if (vaules2 != null)
                                    {
                                        Console.WriteLine("!= null");
                                        vaules2.statusactive = 1;
                                        vaules2.update_date = DateTime.Now;
                                        await context.SaveChangesAsync();
                                    }
                                }
                            }

                            i++;
                        }

                        sr.Dispose();
                        sr.Close();
                    }

                    System.IO.File.Delete(fullpath);

                    dbContextTransaction.Commit();
                    return Ok();
                }
                catch
                {
                    dbContextTransaction.Rollback();
                    return BadRequest(shift_detail_ck + " ไม่สามารถเพิ่มข้อมูลได้");
                }
            }
        }

        [HttpPost]
        [Route("UploadBlockGroup")]
        public async Task<IActionResult> UploadBlockGroup([FromForm] T_FILE_MODEL file)
        {
            using (var dbContextTransaction = context.Database.BeginTransaction())
            {
                TB_DATA_BLOCK_GROUP model = new TB_DATA_BLOCK_GROUP();
                string group_code_ck = string.Empty;
                string group_detail_ck = string.Empty;
                try
                {
                    //-- string path = Directory.GetCurrentDirectory();
                    //-- string folder1 = path.Substring(path.LastIndexOf("\\") + 1);
                    //-- path = path.Remove(path.LastIndexOf("\\"));

                    //-- string fullpath = Path.Combine(path, "files", file.file_name);
                    // string fullpath = Path.Combine("./files/", file.file_name);

                    // using (Stream stream = new FileStream(fullpath, FileMode.Create))
                    // {
                    //     file.file_form.CopyTo(stream);
                    //     // var path = Path.Combine(Directory.GetCurrentDirectory(), file.file_name);
                    //     stream.Dispose();
                    //     stream.Close();
                    // }

                    string rootFolder = Directory.GetCurrentDirectory();
                    string pathString = @"\API site\files\jks_system\upload\";
                    string serverPath = rootFolder.Substring(0, rootFolder.LastIndexOf(@"\")) + pathString;
                    // Create Directory
                    if (!Directory.Exists(serverPath))
                    {
                        Directory.CreateDirectory(serverPath);
                    }

                    // string fullpath = serverPath + model.file_name;
                    string fullpath = Path.Combine(serverPath + file.file_name);
                    using (Stream stream = new FileStream(fullpath, FileMode.Create))
                    {
                        file.file_form.CopyTo(stream);
                        stream.Dispose();
                        stream.Close();
                    }

                    int i = 0;
                    using (StreamReader sr = new StreamReader(fullpath))
                    {
                        while (!sr.EndOfStream)
                        {
                            string line = sr.ReadLine();
                            var data = line.Split(',');

                            if (i > 0)
                            {
                                var group_data = context.M_BLOCK_GROUP.Where(e => e.block_group_code == data[0].Trim() && e.block_group_detail == data[1].Trim()).FirstOrDefault();
                                Console.WriteLine(data[0].Trim().ToString());
                                if (group_data == null)
                                {
                                    model.block_group_code = data[0].Trim().ToString();
                                    model.block_group_detail = data[1].Trim().ToString();
                                    group_code_ck = data[0].Trim().ToString();
                                    group_detail_ck = data[1].Trim().ToString();
                                    context.Add(model);
                                    await context.SaveChangesAsync();
                                }
                                else
                                {
                                    var vaules2 = context.M_BLOCK_GROUP.FirstOrDefault(x => x.block_group_detail == data[0].Trim() && x.statusactive == 0);
                                    if (vaules2 != null)
                                    {
                                        Console.WriteLine("!= null");
                                        vaules2.statusactive = 1;
                                        vaules2.update_date = DateTime.Now;
                                        await context.SaveChangesAsync();
                                    }
                                }
                            }

                            i++;
                        }

                        sr.Dispose();
                        sr.Close();
                    }

                    System.IO.File.Delete(fullpath);

                    dbContextTransaction.Commit();
                    return Ok();
                }
                catch
                {
                    dbContextTransaction.Rollback();
                    return BadRequest("Code : " + group_code_ck + "<br> Detail : " + group_detail_ck + "<br> ไม่สามารถเพิ่มข้อมูลได้");
                }
            }
        }

        [HttpPost]
        [Route("UploadGbCell")]
        public async Task<IActionResult> UploadGbCell([FromForm] T_FILE_MODEL file)
        {
            using (var dbContextTransaction = context.Database.BeginTransaction())
            {
                TB_DATA_GB_CELL model = new TB_DATA_GB_CELL();
                string gb_code_ck = string.Empty;
                string gb_detail_ck = string.Empty;
                try
                {
                    string rootFolder = Directory.GetCurrentDirectory();
                    string pathString = @"\API site\files\jks_system\upload\";
                    string serverPath = rootFolder.Substring(0, rootFolder.LastIndexOf(@"\")) + pathString;
                    // Create Directory
                    if (!Directory.Exists(serverPath))
                    {
                        Directory.CreateDirectory(serverPath);
                    }

                    // string fullpath = serverPath + model.file_name;
                    string fullpath = Path.Combine(serverPath + file.file_name);
                    using (Stream stream = new FileStream(fullpath, FileMode.Create))
                    {
                        file.file_form.CopyTo(stream);
                        stream.Dispose();
                        stream.Close();
                    }

                    int i = 0;
                    using (StreamReader sr = new StreamReader(fullpath))
                    {
                        while (!sr.EndOfStream)
                        {
                            string line = sr.ReadLine();
                            var data = line.Split(',');

                            if (i > 0)
                            {
                                var gb_data = context.M_GB_CELL_CODE.Where(e => e.gb_cell_code == data[0].Trim() && e.gb_cell_detail == data[1].Trim()).FirstOrDefault();
                                Console.WriteLine(data[0].Trim().ToString());
                                if (gb_data == null)
                                {
                                    model.gb_cell_code = data[0].Trim().ToString();
                                    model.gb_cell_detail = data[1].Trim().ToString();
                                    gb_code_ck = data[0].Trim().ToString();
                                    gb_detail_ck = data[1].Trim().ToString();
                                    context.Add(model);
                                    await context.SaveChangesAsync();
                                }
                                else
                                {
                                    var vaules2 = context.M_GB_CELL_CODE.FirstOrDefault(x => x.gb_cell_detail == data[0].Trim() && x.statusactive == 0);
                                    if (vaules2 != null)
                                    {
                                        Console.WriteLine("!= null");
                                        vaules2.statusactive = 1;
                                        vaules2.update_date = DateTime.Now;
                                        await context.SaveChangesAsync();
                                    }
                                }
                            }

                            i++;
                        }

                        sr.Dispose();
                        sr.Close();
                    }

                    System.IO.File.Delete(fullpath);

                    dbContextTransaction.Commit();
                    return Ok();
                }
                catch
                {
                    dbContextTransaction.Rollback();
                    return BadRequest("Code : " + gb_code_ck + "<br> Detail : " + gb_detail_ck + "<br> ไม่สามารถเพิ่มข้อมูลได้");
                }
            }
        }

        [HttpPost]
        [Route("UploadTSS")]
        public async Task<IActionResult> UploadTSS([FromForm] T_FILE_MODEL file)
        {
            using (var dbContextTransaction = context.Database.BeginTransaction())
            {
                TB_DATA_TSS model = new TB_DATA_TSS();
                string tss_code_ck = string.Empty;
                string tss_detail_ck = string.Empty;
                try
                {
                    //-- string path = Directory.GetCurrentDirectory();
                    //-- string folder1 = path.Substring(path.LastIndexOf("\\") + 1);
                    //-- path = path.Remove(path.LastIndexOf("\\"));

                    //-- string fullpath = Path.Combine(path, "files", file.file_name);
                    // string fullpath = Path.Combine("./files/", file.file_name);

                    // using (Stream stream = new FileStream(fullpath, FileMode.Create))
                    // {
                    //     file.file_form.CopyTo(stream);
                    //     // var path = Path.Combine(Directory.GetCurrentDirectory(), file.file_name);
                    //     stream.Dispose();
                    //     stream.Close();
                    // }

                    string rootFolder = Directory.GetCurrentDirectory();
                    string pathString = @"\API site\files\jks_system\upload\";
                    string serverPath = rootFolder.Substring(0, rootFolder.LastIndexOf(@"\")) + pathString;
                    // Create Directory
                    if (!Directory.Exists(serverPath))
                    {
                        Directory.CreateDirectory(serverPath);
                    }

                    // string fullpath = serverPath + model.file_name;
                    string fullpath = Path.Combine(serverPath + file.file_name);
                    using (Stream stream = new FileStream(fullpath, FileMode.Create))
                    {
                        file.file_form.CopyTo(stream);
                        stream.Dispose();
                        stream.Close();
                    }

                    int i = 0;
                    using (StreamReader sr = new StreamReader(fullpath))
                    {
                        while (!sr.EndOfStream)
                        {
                            string line = sr.ReadLine();
                            var data = line.Split(',');

                            if (i > 0)
                            {
                                var tss_data = context.M_TSS.Where(e => e.tss_code == data[0].Trim() && e.tss_detail == data[1].Trim()).FirstOrDefault();
                                Console.WriteLine(data[0].Trim().ToString());
                                if (tss_data == null)
                                {
                                    model.tss_code = data[0].Trim().ToString();
                                    model.tss_detail = data[1].Trim().ToString();
                                    tss_code_ck = data[0].Trim().ToString();
                                    tss_detail_ck = data[1].Trim().ToString();
                                    context.Add(model);
                                    await context.SaveChangesAsync();
                                }
                                else
                                {
                                    var vaules2 = context.M_TSS.FirstOrDefault(x => x.tss_detail == data[0].Trim() && x.statusactive == 0);
                                    if (vaules2 != null)
                                    {
                                        Console.WriteLine("!= null");
                                        vaules2.statusactive = 1;
                                        vaules2.update_date = DateTime.Now;
                                        await context.SaveChangesAsync();
                                    }
                                }
                            }

                            i++;
                        }

                        sr.Dispose();
                        sr.Close();
                    }

                    System.IO.File.Delete(fullpath);

                    dbContextTransaction.Commit();
                    return Ok();
                }
                catch
                {
                    dbContextTransaction.Rollback();
                    return BadRequest("Code : " + tss_code_ck + "<br> Detail : " + tss_detail_ck + "<br> ไม่สามารถเพิ่มข้อมูลได้");
                }
            }
        }
        //////////////////////////////////////////////////////////////////////////
        //                          Upload Detail                               //
        [HttpPost]
        [Route("UploadWorkcenterModel")]
        public async Task<IActionResult> UploadWorkcenterModel([FromForm] T_FILE_MODEL file)
        {
            using (var dbContextTransaction = context.Database.BeginTransaction())
            {
                string wc_detail_ck = string.Empty;
                string model_detail_ck = string.Empty;
                try
                {
                    string rootFolder = Directory.GetCurrentDirectory();
                    string pathString = @"\API site\files\jks_system\upload\";
                    string serverPath = rootFolder.Substring(0, rootFolder.LastIndexOf(@"\")) + pathString;
                    // Create Directory
                    if (!Directory.Exists(serverPath))
                    {
                        Directory.CreateDirectory(serverPath);
                    }

                    // string fullpath = serverPath + model.file_name;
                    string fullpath = Path.Combine(serverPath + file.file_name);
                    using (Stream stream = new FileStream(fullpath, FileMode.Create))
                    {
                        file.file_form.CopyTo(stream);
                        stream.Dispose();
                        stream.Close();
                    }

                    int i = 0;
                    using (StreamReader sr = new StreamReader(fullpath))
                    {
                        while (!sr.EndOfStream)
                        {
                            string line = sr.ReadLine();
                            var data = line.Split(',');

                            if (i > 0)
                            {
                                var wc_data = context.M_WORK_CENTER.Where(e => e.wc_detail == data[0].Trim()).FirstOrDefault();
                                var model_data = context.M_MODEL.Where(e => e.model_detail == data[1].Trim()).FirstOrDefault();
                                if (wc_data == null || model_data == null)
                                {
                                    wc_detail_ck = data[0].Trim();
                                    model_detail_ck = data[1].Trim();
                                    Console.WriteLine("null");
                                    return BadRequest("WC : " + wc_detail_ck + "<br> Model : " + model_detail_ck + "<br> ไม่สามารถเพิ่มข้อมูลได้ เนื่องจากไม่มีใน Master");
                                }
                                else
                                {
                                    T_WORK_CENTER_MODEL model = new T_WORK_CENTER_MODEL();
                                    var vaules = await context.T_WORK_CENTER_MODEL.FirstOrDefaultAsync(x => x.wc_code == wc_data.wc_code.ToString() && x.model_code == model_data.model_code.ToString());
                                    if (vaules == null)
                                    {
                                        model.wc_code = wc_data.wc_code.ToString();
                                        model.model_code = model_data.model_code.ToString();

                                        context.Add(model);
                                        await context.SaveChangesAsync();
                                    }
                                }
                            }

                            i++;
                        }

                        sr.Dispose();
                        sr.Close();
                    }

                    System.IO.File.Delete(fullpath);

                    dbContextTransaction.Commit();
                    return Ok();
                }
                catch
                {
                    dbContextTransaction.Rollback();
                    return BadRequest("WC : " + wc_detail_ck + "<br> Model : " + model_detail_ck + "<br> ไม่สามารถเพิ่มข้อมูลได้");
                }
            }
        }

        [HttpPost]
        [Route("UploadModelProcess")]
        public async Task<IActionResult> UploadModelProcess([FromForm] T_FILE_MODEL file)
        {
            using (var dbContextTransaction = context.Database.BeginTransaction())
            {
                string model_detail_ck = string.Empty;
                string process_detail_ck = string.Empty;
                try
                {
                    //-- string path = Directory.GetCurrentDirectory();
                    //-- string folder1 = path.Substring(path.LastIndexOf("\\") + 1);
                    //-- path = path.Remove(path.LastIndexOf("\\"));

                    //-- string fullpath = Path.Combine(path, "files", file.file_name);
                    // string fullpath = Path.Combine("./files/", file.file_name);

                    // using (Stream stream = new FileStream(fullpath, FileMode.Create))
                    // {
                    //     file.file_form.CopyTo(stream);
                    //     // var path = Path.Combine(Directory.GetCurrentDirectory(), file.file_name);
                    //     stream.Dispose();
                    //     stream.Close();
                    // }

                    string rootFolder = Directory.GetCurrentDirectory();
                    string pathString = @"\API site\files\jks_system\upload\";
                    string serverPath = rootFolder.Substring(0, rootFolder.LastIndexOf(@"\")) + pathString;
                    // Create Directory
                    if (!Directory.Exists(serverPath))
                    {
                        Directory.CreateDirectory(serverPath);
                    }

                    // string fullpath = serverPath + model.file_name;
                    string fullpath = Path.Combine(serverPath + file.file_name);
                    using (Stream stream = new FileStream(fullpath, FileMode.Create))
                    {
                        file.file_form.CopyTo(stream);
                        stream.Dispose();
                        stream.Close();
                    }

                    int i = 0;
                    using (StreamReader sr = new StreamReader(fullpath))
                    {
                        while (!sr.EndOfStream)
                        {
                            string line = sr.ReadLine();
                            var data = line.Split(',');

                            if (i > 0)
                            {
                                var model_data = context.M_MODEL.Where(e => e.model_detail == data[0].Trim()).FirstOrDefault();
                                var process_data = context.M_PROCESS.Where(e => e.process_detail == data[1].Trim()).FirstOrDefault();
                                if (model_data == null || process_data == null)
                                {
                                    model_detail_ck = data[0].Trim();
                                    process_detail_ck = data[1].Trim();
                                    Console.WriteLine("null");
                                    return BadRequest("Model : " + model_detail_ck + "<br> Process : " + process_detail_ck + "<br> ไม่สามารถเพิ่มข้อมูลได้ เนื่องจากไม่มีใน Master");
                                }
                                else
                                {
                                    T_MODEL_PROCESS model = new T_MODEL_PROCESS();
                                    var vaules = await context.T_MODEL_PROCESS.FirstOrDefaultAsync(x => x.model_code == model_data.model_code.ToString() && x.process_code == process_data.process_code.ToString());
                                    if (vaules == null)
                                    {
                                        model.model_code = model_data.model_code.ToString();
                                        model.process_code = process_data.process_code.ToString();

                                        context.Add(model);
                                        await context.SaveChangesAsync();
                                    }
                                }
                            }

                            i++;
                        }

                        sr.Dispose();
                        sr.Close();
                    }

                    System.IO.File.Delete(fullpath);

                    dbContextTransaction.Commit();
                    return Ok();
                }
                catch
                {
                    dbContextTransaction.Rollback();
                    return BadRequest("Model : " + model_detail_ck + "<br> Process : " + process_detail_ck + "<br> ไม่สามารถเพิ่มข้อมูลได้");
                }
            }
        }

        [HttpPost]
        [Route("UploadProcessCell")]
        public async Task<IActionResult> UploadProcessCell([FromForm] T_FILE_MODEL file)
        {
            using (var dbContextTransaction = context.Database.BeginTransaction())
            {
                string process_detail_ck = string.Empty;
                string cell_detail_ck = string.Empty;
                try
                {
                    string rootFolder = Directory.GetCurrentDirectory();
                    string pathString = @"\API site\files\jks_system\upload\";
                    string serverPath = rootFolder.Substring(0, rootFolder.LastIndexOf(@"\")) + pathString;
                    // Create Directory
                    if (!Directory.Exists(serverPath))
                    {
                        Directory.CreateDirectory(serverPath);
                    }

                    // string fullpath = serverPath + model.file_name;
                    string fullpath = Path.Combine(serverPath + file.file_name);
                    using (Stream stream = new FileStream(fullpath, FileMode.Create))
                    {
                        file.file_form.CopyTo(stream);
                        stream.Dispose();
                        stream.Close();
                    }

                    int i = 0;
                    using (StreamReader sr = new StreamReader(fullpath))
                    {
                        while (!sr.EndOfStream)
                        {
                            string line = sr.ReadLine();
                            var data = line.Split(',');

                            if (i > 0)
                            {
                                var process_data = context.M_PROCESS.Where(e => e.process_detail == data[0].Trim()).FirstOrDefault();
                                var cell_data = context.M_CELL.Where(e => e.cell_detail == data[1].Trim()).FirstOrDefault();
                                if (process_data == null || cell_data == null)
                                {
                                    process_detail_ck = data[0].Trim();
                                    cell_detail_ck = data[1].Trim();
                                    Console.WriteLine("null");
                                    return BadRequest("Process : " + process_detail_ck + "<br> Cell : " + cell_detail_ck + "<br> ไม่สามารถเพิ่มข้อมูลได้ เนื่องจากไม่มีใน Master");
                                }
                                else
                                {
                                    T_PROCESS_CELL model = new T_PROCESS_CELL();
                                    var vaules = await context.T_PROCESS_CELL.FirstOrDefaultAsync(x => x.process_code == process_data.process_code.ToString() && x.cell_code == cell_data.cell_code.ToString());
                                    if (vaules == null)
                                    {
                                        model.process_code = process_data.process_code.ToString();
                                        model.cell_code = cell_data.cell_code.ToString();

                                        context.Add(model);
                                        await context.SaveChangesAsync();
                                    }
                                }
                            }

                            i++;
                        }

                        sr.Dispose();
                        sr.Close();
                    }

                    System.IO.File.Delete(fullpath);

                    dbContextTransaction.Commit();
                    return Ok();
                }
                catch
                {
                    dbContextTransaction.Rollback();
                    return BadRequest("Process : " + process_detail_ck + "<br> Cell : " + cell_detail_ck + "<br> ไม่สามารถเพิ่มข้อมูลได้");
                }
            }
        }

        [HttpPost]
        [Route("UploadCellShift")]
        public async Task<IActionResult> UploadCellShift([FromForm] T_FILE_MODEL file)
        {
            using (var dbContextTransaction = context.Database.BeginTransaction())
            {
                string cell_detail_ck = string.Empty;
                string shift_detail_ck = string.Empty;
                try
                {
                    //-- string path = Directory.GetCurrentDirectory();
                    //-- string folder1 = path.Substring(path.LastIndexOf("\\") + 1);
                    //-- path = path.Remove(path.LastIndexOf("\\"));

                    //-- string fullpath = Path.Combine(path, "files", file.file_name);
                    // string fullpath = Path.Combine("./files/", file.file_name);

                    // using (Stream stream = new FileStream(fullpath, FileMode.Create))
                    // {
                    //     file.file_form.CopyTo(stream);
                    //     // var path = Path.Combine(Directory.GetCurrentDirectory(), file.file_name);
                    //     stream.Dispose();
                    //     stream.Close();
                    // }

                    string rootFolder = Directory.GetCurrentDirectory();
                    string pathString = @"\API site\files\jks_system\upload\";
                    string serverPath = rootFolder.Substring(0, rootFolder.LastIndexOf(@"\")) + pathString;
                    // Create Directory
                    if (!Directory.Exists(serverPath))
                    {
                        Directory.CreateDirectory(serverPath);
                    }

                    // string fullpath = serverPath + model.file_name;
                    string fullpath = Path.Combine(serverPath + file.file_name);
                    using (Stream stream = new FileStream(fullpath, FileMode.Create))
                    {
                        file.file_form.CopyTo(stream);
                        stream.Dispose();
                        stream.Close();
                    }

                    int i = 0;
                    using (StreamReader sr = new StreamReader(fullpath))
                    {
                        while (!sr.EndOfStream)
                        {
                            string line = sr.ReadLine();
                            var data = line.Split(',');

                            if (i > 0)
                            {
                                var cell_data = context.M_CELL.Where(e => e.cell_detail == data[0].Trim()).FirstOrDefault();
                                var shift_data = context.M_BLOCK_SHIFT.Where(e => e.shift_detail == data[1].Trim()).FirstOrDefault();
                                if (cell_data == null || shift_detail_ck == null)
                                {
                                    cell_detail_ck = data[0].Trim();
                                    shift_detail_ck = data[1].Trim();
                                    Console.WriteLine("null");
                                    return BadRequest("Cell : " + cell_detail_ck + "<br> Shift : " + shift_detail_ck + "<br> ไม่สามารถเพิ่มข้อมูลได้ เนื่องจากไม่มีใน Master");
                                }
                                else
                                {
                                    T_CELL_SHIFT model = new T_CELL_SHIFT();
                                    var vaules = await context.T_CELL_SHIFT.FirstOrDefaultAsync(x => x.cell_code == cell_data.cell_code.ToString() && x.shift_code == shift_data.shift_code.ToString());
                                    if (vaules == null)
                                    {
                                        model.cell_code = cell_data.cell_code.ToString();
                                        model.shift_code = shift_data.shift_code.ToString();

                                        context.Add(model);
                                        await context.SaveChangesAsync();
                                    }
                                }
                            }

                            i++;
                        }

                        sr.Dispose();
                        sr.Close();
                    }

                    System.IO.File.Delete(fullpath);

                    dbContextTransaction.Commit();
                    return Ok();
                }
                catch
                {
                    dbContextTransaction.Rollback();
                    return BadRequest("Cell : " + cell_detail_ck + "<br> Shift : " + shift_detail_ck + "<br> ไม่สามารถเพิ่มข้อมูลได้");
                }
            }
        }


        //////////////////////////////////////////////////////////////////////////
        //                          Download                                    //
        [HttpGet]
        [Route("StandardFormat")]
        public async Task<IActionResult> StandardFormat()
        {
            try
            {
                var result = await (from e in context.T_ST_DB
                                    select new
                                    {
                                        model = e.model,
                                        mercury = e.mercury,
                                        type = e.type,
                                        reader = e.reader,
                                        process_name = e.process_name,
                                        process_qty = e.process_qty,
                                        cell = e.cell
                                    }).OrderBy(x => x.model).ThenBy(x => x.mercury).ToListAsync();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }

        [HttpGet]
        [Route("NadamsFormat")]
        public async Task<IActionResult> NadamsFormat()
        {
            try
            {
                var get = context.T_NADAMS.OrderByDescending(c => c.date_time).Take(1).FirstOrDefault();
                int month = get.date_time.Month;
                int year = get.date_time.Year;
                // Console.WriteLine(month);
                // Console.WriteLine(year);

                var result = await (from e in context.T_NADAMS
                                    where e.date_time.Month == month && e.date_time.Year == year
                                    select new
                                    {
                                        date_time = e.date_time,
                                        body_no = e.body_no,
                                        model = e.model,
                                        mercury = e.mercury,
                                        shift = e.shift,
                                        cell = e.cell,
                                        qt_num = e.qt_num,
                                        qt_in_pallet = e.qt_in_pallet,
                                        status = e.status,
                                        pallet_no = e.pallet_no,
                                        carton_no = e.carton_no
                                    }).OrderBy(x => x.date_time).ThenBy(x => x.body_no).ThenBy(x => x.model)
                                    .ThenBy(x => x.mercury).ThenBy(x => x.shift).ThenBy(x => x.cell)
                                    .ToListAsync();

                if (result.Count() <= 0)
                {
                    return BadRequest("No Data");
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }

        [HttpGet]
        [Route("ManpowerFormat")]
        public async Task<IActionResult> ManpowerFormat()
        {
            try
            {
                var result = await (from e in context.V_MANPOWER
                                    select new
                                    {
                                        wc_detail = e.wc_detail,
                                        model_detail = e.model_detail,
                                        process_detail = e.process_detail,
                                        cell_detail = e.cell_detail,
                                        shift_detail = e.shift_detail,
                                        manpower = e.manpower,
                                        op_meister = e.op_meister,
                                        sp_meister = e.sp_meister,
                                        block_group_detail = e.block_group_detail,
                                        gb_cell_code = e.gb_cell_code
                                    }).OrderBy(x => x.wc_detail).ThenBy(x => x.model_detail)
                                .ThenBy(x => x.process_detail)
                                .ThenBy(x => x.cell_detail)
                                .ThenBy(x => x.shift_detail)
                                .ThenBy(x => x.manpower)
                                .ThenBy(x => x.op_meister)
                                .ThenBy(x => x.sp_meister)
                                .ThenBy(x => x.block_group_detail)
                                .ThenBy(x => x.gb_cell_code).ToListAsync();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }

        [HttpGet]
        [Route("WorkCenterFormat")]
        public async Task<IActionResult> WorkCenterFormat()
        {
            try
            {
                var result = await (from e in context.M_WORK_CENTER
                                    where e.statusactive == 1
                                    select new
                                    {
                                        wc_detail = e.wc_detail
                                    }).OrderBy(x => x.wc_detail).ToListAsync();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }

        [HttpGet]
        [Route("ModelFormat")]
        public async Task<IActionResult> ModelFormat()
        {
            try
            {
                var result = await (from e in context.M_MODEL
                                    where e.statusactive == 1
                                    select new
                                    {
                                        model_detail = e.model_detail,
                                        model_child = e.model_child
                                    }).OrderBy(x => x.model_detail).ToListAsync();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }

        [HttpGet]
        [Route("ProcessFormat")]
        public async Task<IActionResult> ProcessFormat()
        {
            try
            {
                var result = await (from e in context.M_PROCESS
                                    where e.statusactive == 1
                                    select new
                                    {
                                        process_detail = e.process_detail
                                    }).OrderBy(x => x.process_detail).ToListAsync();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }

        [HttpGet]
        [Route("CellFormat")]
        public async Task<IActionResult> CellFormat()
        {
            try
            {
                var result = await (from e in context.M_CELL
                                    where e.statusactive == 1
                                    select new
                                    {
                                        cell_detail = e.cell_detail
                                    }).OrderBy(x => x.cell_detail).ToListAsync();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }

        [HttpGet]
        [Route("BlockShiftFormat")]
        public async Task<IActionResult> BlockShiftFormat()
        {
            try
            {
                var result = await (from e in context.M_BLOCK_SHIFT
                                    where e.statusactive == 1
                                    select new
                                    {
                                        shift_detail = e.shift_detail
                                    }).OrderBy(x => x.shift_detail).ToListAsync();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }

        [HttpGet]
        [Route("BlockGroupFormat")]
        public async Task<IActionResult> BlockGroupFormat()
        {
            try
            {
                var result = await (from e in context.M_BLOCK_GROUP
                                    where e.statusactive == 1
                                    select new
                                    {
                                        block_group_code = e.block_group_code,
                                        block_group_detail = e.block_group_detail
                                    }).OrderBy(x => x.block_group_code).ToListAsync();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }

        [HttpGet]
        [Route("GBCellFormat")]
        public async Task<IActionResult> GBCellFormat()
        {
            try
            {
                var result = await (from e in context.M_GB_CELL_CODE
                                    where e.statusactive == 1
                                    select new
                                    {
                                        gb_cell_code = e.gb_cell_code,
                                        gb_cell_detail = e.gb_cell_detail
                                    }).OrderBy(x => x.gb_cell_code).ToListAsync();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }

        [HttpGet]
        [Route("TSSFormat")]
        public async Task<IActionResult> TSSFormat()
        {
            try
            {
                var result = await (from e in context.M_TSS
                                    where e.statusactive == 1
                                    select new
                                    {
                                        tss_code = e.tss_code,
                                        tss_detail = e.tss_detail
                                    }).OrderBy(x => x.tss_code).ToListAsync();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }

        //////////////////////////////////////////////////////////////////////////
        //                          Download Detail                             //
        [HttpGet]
        [Route("WorkcenterModel")]
        public async Task<IActionResult> WorkcenterModel()
        {
            try
            {
                var result = await (from e in context.V_WORK_CENTER_MODEL
                                    where e.statusactive == 1
                                    select new
                                    {
                                        wc_detail = e.wc_detail,
                                        model_detail = e.model_detail
                                    }).OrderBy(x => x.wc_detail).ThenBy(x => x.model_detail).ToListAsync();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }

        [HttpGet]
        [Route("ModelProcess")]
        public async Task<IActionResult> ModelProcess()
        {
            try
            {
                var result = await (from e in context.V_MODEL_PROCESS
                                    where e.statusactive == 1
                                    select new
                                    {
                                        model_detail = e.model_detail,
                                        process_detail = e.process_detail
                                    }).OrderBy(x => x.model_detail).ThenBy(x => x.process_detail).ToListAsync();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }

        [HttpGet]
        [Route("ProcessCell")]
        public async Task<IActionResult> ProcessCell()
        {
            try
            {
                var result = await (from e in context.V_PROCESS_CELL
                                    where e.statusactive == 1
                                    select new
                                    {
                                        process_detail = e.process_detail,
                                        cell_detail = e.cell_detail
                                    }).OrderBy(x => x.process_detail).ThenBy(x => x.cell_detail).ToListAsync();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }

        [HttpGet]
        [Route("CellShift")]
        public async Task<IActionResult> CellShift()
        {
            try
            {
                var result = await (from e in context.V_CELL_SHIFT
                                    where e.statusactive == 1
                                    select new
                                    {
                                        cell_detail = e.cell_detail,
                                        shift_detail = e.shift_detail
                                    }).OrderBy(x => x.cell_detail).ThenBy(x => x.shift_detail).ToListAsync();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }


    }

}