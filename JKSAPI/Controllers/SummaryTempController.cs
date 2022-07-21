using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System;

namespace JKSAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SummaryTempController : ControllerBase
    {
        private readonly DBContext context;
        public SummaryTempController(DBContext context)
        {
            this.context = context;
        }


        [HttpPost]
        [Route("Tss/Search")]
        public async Task<ActionResult> Manpower(T_SUMMARY_TSS data)
        {
            var result = await (from e in context.T_SUMMARY_TSS
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
                                    loss_time = e.loss_time,
                                    respond = e.respond
                                }).ToListAsync();

            if (result == null)
            {
                return BadRequest("ไม่พบข้อมูล");
            }
            else
            {
                return Ok(result);
            }
        }


        [HttpPost]
        [Route("Tss/Add")]
        public async Task<ActionResult> AddTssTemp([FromBody] T_SUMMARY_TSS data)
        {
            var vaules = await context.T_SUMMARY_TSS.FirstOrDefaultAsync(
                x => x.date_input == data.date_input
                && x.wc_code == data.wc_code
                && x.model_code == data.model_code
                && x.process_code == data.process_code
                && x.cell_code == data.cell_code
                && x.shift_code == data.shift_code
                && x.tss_code == data.tss_code
                && x.extra_work_no == data.extra_work_no
                && x.manpower_pers == data.manpower_pers
                && x.tss_min == data.tss_min
                && x.mc_qty == data.mc_qty
                && x.respond == data.respond
                );

            if (vaules == null)
            {
                data.ins_date = DateTime.Now;
                context.Add(data);
                await context.SaveChangesAsync();
                return Ok("บันทึกข้อมูลสำเร็จ");
            }
            else
            {
                return Conflict("มีข้อมูลนี้ในระบบอยู่แล้ว");
            }
        }


        [HttpPut]
        [Route("Tss/Edit")]
        public async Task<ActionResult> EditTssTemp([FromBody] T_SUMMARY_TSS data)
        {
            var vaules = await context.T_SUMMARY_TSS.FirstOrDefaultAsync(
                x => x.date_input == data.date_input
                && x.wc_code == data.wc_code
                && x.model_code == data.model_code
                && x.process_code == data.process_code
                && x.cell_code == data.cell_code
                && x.shift_code == data.shift_code
                && x.tss_code == data.tss_code
                && x.extra_work_no == data.extra_work_no
                );

            if (vaules != null)
            {
                vaules.tss_code = data.tss_code;
                vaules.extra_work_no = data.extra_work_no;
                vaules.manpower_pers = data.manpower_pers;
                vaules.tss_min = data.tss_min;
                vaules.mc_qty = data.mc_qty;
                vaules.respond = data.respond;
                vaules.loss_time = data.loss_time;
                vaules.ins_date = DateTime.Now;
                vaules.ins_by = data.ins_by;

                await context.SaveChangesAsync();
                return Ok();
            }
            else
            {
                return NotFound("ไม่สามารถแก้ไขข้อมูลได้ เนื่องจากไม่มีข้อมูลในระบบ");
            }
        }

        [HttpPost]
        [Route("Tss/Delete")]
        public async Task<IActionResult> DeleteTssTemp([FromBody] T_SUMMARY_TSS data)
        {
            context.T_SUMMARY_TSS.Remove(context.T_SUMMARY_TSS.FirstOrDefault(
                x => x.date_input == data.date_input
                && x.wc_code == data.wc_code
                && x.model_code == data.model_code
                && x.process_code == data.process_code
                && x.cell_code == data.cell_code
                && x.shift_code == data.shift_code
                && x.tss_code == data.tss_code
                && x.extra_work_no == data.extra_work_no
            ));
            await context.SaveChangesAsync();
            return NoContent();
        }
    }
}