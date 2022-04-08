using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace JKSAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalcController : ControllerBase
    {
        private IConfiguration configuration;
        public CalcController(IConfiguration _configuration)
        {
            this.configuration = _configuration;
        }

        /// <summary>
        /// SP Calc actual output.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /Calc/calc_actual_output
        ///     {
        ///        "update_by": "admin"
        ///     }
        ///
        /// </remarks>
        [HttpPost]
        [Route("calc_actual_output")]
        public IActionResult calc_actual_output(Post_Calc_Actual data)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                string constr = this.configuration.GetConnectionString("ConnStr");
                using (SqlConnection con = new SqlConnection(constr))
                {
                    string query = "EXEC [dbo].[S_CALC_ACTUAL_OUTPUT] @update_by = N'" + data.update_by + "' ";
                    using (SqlCommand cmd = new SqlCommand(query))
                    {
                        cmd.Connection = con;
                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            sda.Fill(dt);
                            if (dt.Rows.Count > 0)
                            {
                                sda.Fill(ds);
                            }
                            else
                            {
                                return Ok("ไม่มีข้อมูลให้อัปเดต");
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
        /// SP Calc actual output manual.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /Calc/calc_actual_manual
        ///     {
        ///        "update_by": "admin",
        ///        "submit": "no",
        ///        "date_start": "2021-04-03"
        ///     }
        ///
        /// </remarks>
        [HttpPost]
        [Route("calc_actual_manual")]
        public IActionResult calc_actual_manual(Post_Calc_Actual data)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                string constr = this.configuration.GetConnectionString("ConnStr");
                using (SqlConnection con = new SqlConnection(constr))
                {
                    string query = "EXEC [dbo].[S_CALC_ACTUAL_MANUAL] @update_by = N'" + data.update_by + "',@submit = N'" + data.submit + "', @date_start = N'" + data.date_start + "' ";
                    using (SqlCommand cmd = new SqlCommand(query))
                    {
                        cmd.Connection = con;
                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            sda.Fill(dt);
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

    }
}