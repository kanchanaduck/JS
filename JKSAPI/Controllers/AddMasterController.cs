using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System;
using Microsoft.EntityFrameworkCore;

namespace JKSAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AddMasterController : ControllerBase
    {
        private readonly DBContext context;
        public AddMasterController(DBContext context)
        {
            this.context = context;
        }

        [HttpPost]
        [Route("AddCellName")]
        public async Task<IActionResult> AddCellName([FromBody] TB_DATA_CELL data_cell)
        {
            var vaules = await context.M_CELL.FirstOrDefaultAsync(x => x.cell_detail == data_cell.cell_detail);

            if (vaules == null)
            {
                var values_last = await context.M_CELL.OrderByDescending(x => x.cell_code).Take(1).FirstOrDefaultAsync();
                string gen_code = "C-" + (Convert.ToInt32(values_last.cell_code.ToString().Substring(2, 3)) + 1).ToString("000");
                // Console.WriteLine(gen_code);

                data_cell.cell_code = gen_code;
                data_cell.statusactive = 1;
                data_cell.update_by = data_cell.update_by;
                data_cell.update_date = DateTime.Now;
                context.Add(data_cell);
                await context.SaveChangesAsync();
                return Ok();
            }
            else
            {
                var vaules2 = context.M_CELL.FirstOrDefault(x => x.cell_detail == data_cell.cell_detail && x.statusactive == 0);
                if (vaules2 == null)
                {
                    return BadRequest(data_cell.cell_detail + " มีข้อมูลอยู่ในระบบแล้ว");
                }
                else
                {
                    vaules2.statusactive = 1;
                    vaules2.update_by = data_cell.update_by;
                    vaules2.update_date = DateTime.Now;

                    var v_detail = context.T_CELL_SHIFT.FirstOrDefault(x => x.cell_code == vaules2.cell_code);
                    if (v_detail != null)
                    {
                        v_detail.statusactive = 1;
                        v_detail.update_by = data_cell.update_by;
                        v_detail.update_date = DateTime.Now;
                    }

                    await context.SaveChangesAsync();
                    return Ok();
                }
            }
        }

        [HttpPost]
        [Route("AddProductModel")]
        public async Task<IActionResult> AddProductModel([FromBody] TB_DATA_MODEL data_model)
        {
            var vaules = await context.M_MODEL.FirstOrDefaultAsync(x => x.model_detail == data_model.model_detail);

            if (vaules == null)
            {
                var values_last = await context.M_MODEL.OrderByDescending(x => x.model_code).Take(1).FirstOrDefaultAsync();
                string gen_code = "M-" + (Convert.ToInt32(values_last.model_code.ToString().Substring(2, 3)) + 1).ToString("000");
                data_model.model_code = gen_code;
                data_model.model_child = data_model.model_child;
                data_model.statusactive = 1;
                data_model.update_by = data_model.update_by;
                data_model.update_date = DateTime.Now;
                context.Add(data_model);
                await context.SaveChangesAsync();
                return Ok();
            }
            else
            {
                var vaules2 = context.M_MODEL.FirstOrDefault(x => x.model_detail == data_model.model_detail && x.statusactive == 0);
                if (vaules2 == null)
                {
                    return BadRequest(data_model.model_detail + " มีข้อมูลอยู่ในระบบแล้ว");
                }
                else
                {
                    vaules2.model_child = data_model.model_child;
                    vaules2.statusactive = 1;
                    vaules2.update_by = data_model.update_by;
                    vaules2.update_date = DateTime.Now;

                    var v_detail = context.T_MODEL_PROCESS.FirstOrDefault(x => x.model_code == vaules2.model_code);
                    if (v_detail != null)
                    {
                        v_detail.statusactive = 1;
                        v_detail.update_by = data_model.update_by;
                        v_detail.update_date = DateTime.Now;
                    }

                    await context.SaveChangesAsync();
                    return Ok();
                }
            }

        }

        [HttpPost]
        [Route("AddProcessName")]
        public async Task<IActionResult> AddProcessName([FromBody] TB_DATA_PROCESS data_process)
        {
            var vaules = await context.M_PROCESS.FirstOrDefaultAsync(x => x.process_detail == data_process.process_detail);

            if (vaules == null)
            {
                var values_last = await context.M_PROCESS.OrderByDescending(x => x.process_code).Take(1).FirstOrDefaultAsync();
                string gen_code = "P-" + (Convert.ToInt32(values_last.process_code.ToString().Substring(2, 3)) + 1).ToString("000");
                data_process.process_code = gen_code;
                data_process.statusactive = 1;
                data_process.update_by = data_process.update_by;
                data_process.update_date = DateTime.Now;
                context.Add(data_process);
                await context.SaveChangesAsync();
                return Ok();
            }
            else
            {
                var vaules2 = context.M_PROCESS.FirstOrDefault(x => x.process_detail == data_process.process_detail && x.statusactive == 0);
                if (vaules2 == null)
                {
                    return BadRequest(data_process.process_detail + " มีข้อมูลอยู่ในระบบแล้ว");
                }
                else
                {
                    vaules2.statusactive = 1;
                    vaules2.update_by = data_process.update_by;
                    vaules2.update_date = DateTime.Now;

                    var v_detail = context.T_PROCESS_CELL.FirstOrDefault(x => x.process_code == vaules2.process_code);
                    if (v_detail != null)
                    {
                        v_detail.statusactive = 1;
                        v_detail.update_by = data_process.update_by;
                        v_detail.update_date = DateTime.Now;
                    }

                    await context.SaveChangesAsync();
                    return Ok();
                }
            }
        }

        [HttpPost]
        [Route("AddBlockShift")]
        public async Task<IActionResult> AddBlockShift([FromBody] TB_DATA_SHIFT data_shift)
        {
            var vaules = await context.M_BLOCK_SHIFT.FirstOrDefaultAsync(x => x.shift_detail == data_shift.shift_detail);

            if (vaules == null)
            {
                var values_last = await context.M_BLOCK_SHIFT.OrderByDescending(x => x.shift_code).Take(1).FirstOrDefaultAsync();
                string gen_code = "S-" + (Convert.ToInt32(values_last.shift_code.ToString().Substring(2, 3)) + 1).ToString("000");
                data_shift.shift_code = gen_code;
                data_shift.statusactive = 1;
                data_shift.update_by = data_shift.update_by;
                data_shift.update_date = DateTime.Now;
                context.Add(data_shift);
                await context.SaveChangesAsync();
                return Ok();
            }
            else
            {
                var vaules2 = context.M_BLOCK_SHIFT.FirstOrDefault(x => x.shift_detail == data_shift.shift_detail && x.statusactive == 0);
                if (vaules2 == null)
                {
                    return BadRequest(data_shift.shift_detail + " มีข้อมูลอยู่ในระบบแล้ว");
                }
                else
                {
                    vaules2.statusactive = 1;
                    await context.SaveChangesAsync();
                    return Ok();
                }
            }
        }

        [HttpPost]
        [Route("AddWorkCenter")]
        public async Task<IActionResult> AddWorkCenter([FromBody] TB_DATA_WC data_wc)
        {
            var vaules = await context.M_WORK_CENTER.FirstOrDefaultAsync(x => x.wc_detail == data_wc.wc_detail);
            // ถ้าใน M_WORK_CENTER ยังไม่เคยมี wc_detail นี้ ให้เพิ่มข้อมูลใหม่ได้
            if (vaules == null)
            {
                var values_last = await context.M_WORK_CENTER.OrderByDescending(x => x.wc_code).Take(1).FirstOrDefaultAsync();
                string gen_code = "WC-" + (Convert.ToInt32(values_last.wc_code.ToString().Substring(3, 3)) + 1).ToString("000");
                data_wc.wc_code = gen_code;
                data_wc.statusactive = 1;
                data_wc.update_by = data_wc.update_by;
                data_wc.update_date = DateTime.Now;
                context.Add(data_wc);
                await context.SaveChangesAsync();
                return Ok();
            }
            else
            {
                // ถ้าใน M_WORK_CENTER เคยมี wc_detail นี้แล้ว
                // ให้เชค statusactive
                var vaules2 = context.M_WORK_CENTER.FirstOrDefault(x => x.wc_detail == data_wc.wc_detail && x.statusactive == 0);
                if (vaules2 == null)
                {
                    // ถ้าเท่ากับ 1 ก็คือมีอยู่แล้ว จะไม่สามารถเพิ่มข้อมูลได้
                    return BadRequest(data_wc.wc_detail + " มีข้อมูลอยู่ในระบบแล้ว");
                }
                else
                {
                    // ถ้าเท่ากับ 0 ให้ statusactive = 1
                    vaules2.statusactive = 1;
                    vaules2.update_by = data_wc.update_by;
                    vaules2.update_date = DateTime.Now;

                    var v_detail = context.T_WORK_CENTER_MODEL.FirstOrDefault(x => x.wc_code == vaules2.wc_code);
                    //ถ้าใน T_WORK_CENTER_MODEL มี wc_code ให้เปิดใช้งาน wc_code นั้น
                    if (v_detail != null)
                    {
                        v_detail.statusactive = 1;
                        v_detail.update_by = data_wc.update_by;
                        v_detail.update_date = DateTime.Now;
                    }

                    await context.SaveChangesAsync();
                    return Ok();
                }
            }
        }

        [HttpPost]
        [Route("AddBlockGroup")]
        public async Task<IActionResult> AddBlockGroup([FromBody] TB_DATA_BLOCK_GROUP data_blockgroup)
        {
            var vaules = await context.M_BLOCK_GROUP.FirstOrDefaultAsync(x => x.block_group_code == data_blockgroup.block_group_code);

            if (vaules == null)
            {
                data_blockgroup.statusactive = 1;
                data_blockgroup.update_by = data_blockgroup.update_by;
                data_blockgroup.update_date = DateTime.Now;
                context.Add(data_blockgroup);
                await context.SaveChangesAsync();
                return Ok();
            }
            else
            {
                var vaules2 = context.M_BLOCK_GROUP.FirstOrDefault(x => x.block_group_code == data_blockgroup.block_group_code && x.statusactive == 0);
                if (vaules2 == null)
                {
                    return BadRequest(data_blockgroup.block_group_code + " มีข้อมูลอยู่ในระบบแล้ว");
                }
                else
                {
                    vaules2.statusactive = 1;
                    await context.SaveChangesAsync();
                    return Ok();
                }
            }
        }

        [HttpPost]
        [Route("AddGbCellCode")]
        public async Task<IActionResult> AddGbCellCode([FromBody] TB_DATA_GB_CELL data_gbcellcode)
        {
            var vaules = await context.M_GB_CELL_CODE.FirstOrDefaultAsync(x => x.gb_cell_code == data_gbcellcode.gb_cell_code);

            if (vaules == null)
            {
                data_gbcellcode.statusactive = 1;
                data_gbcellcode.update_by = data_gbcellcode.update_by;
                data_gbcellcode.update_date = DateTime.Now;
                context.Add(data_gbcellcode);
                await context.SaveChangesAsync();
                return Ok();
            }
            else
            {
                var vaules2 = context.M_GB_CELL_CODE.FirstOrDefault(x => x.gb_cell_code == data_gbcellcode.gb_cell_code && x.statusactive == 0);
                if (vaules2 == null)
                {
                    return BadRequest(data_gbcellcode.gb_cell_code + " มีข้อมูลอยู่ในระบบแล้ว");
                }
                else
                {
                    vaules2.statusactive = 1;
                    await context.SaveChangesAsync();
                    return Ok();
                }
            }
        }

        [HttpPost]
        [Route("AddTss")]
        public async Task<IActionResult> AddWorkTss([FromBody] TB_DATA_TSS data_tss)
        {
            var vaules = await context.M_TSS.FirstOrDefaultAsync(x => x.tss_code == data_tss.tss_code);

            if (vaules == null)
            {
                data_tss.statusactive = 1;
                data_tss.update_by = data_tss.update_by;
                data_tss.update_date = DateTime.Now;
                context.Add(data_tss);
                await context.SaveChangesAsync();
                return Ok();
            }
            else
            {
                var vaules2 = context.M_TSS.FirstOrDefault(x => x.tss_code == data_tss.tss_code && x.statusactive == 0);
                if (vaules2 == null)
                {
                    return BadRequest(data_tss.tss_code + " มีข้อมูลอยู่ในระบบแล้ว");
                }
                else
                {
                    vaules2.statusactive = 1;
                    await context.SaveChangesAsync();
                    return Ok();
                }
            }
        }

    }
}