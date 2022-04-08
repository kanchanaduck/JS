using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace JKSAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DetailController : ControllerBase
    {
        private readonly DBContext context;
        public DetailController(DBContext context)
        {
            this.context = context;
        }

        [HttpGet]
        [Route("WorkcenterModel")]
        public async Task<ActionResult> WorkcenterModel()
        {
            var result = await (from e in context.V_WORK_CENTER_MODEL
                                where e.statusactive == 1
                                select new
                                {
                                    id = e.id,
                                    wc_code = e.wc_code,
                                    wc_detail = e.wc_detail,
                                    model_code = e.model_code,
                                    model_detail = e.model_detail
                                }).OrderBy(x => x.wc_detail).ThenBy(x => x.model_detail).ToListAsync();
            return Ok(result);
        }

        [HttpGet]
        [Route("WorkcenterModel/{id}")]
        public async Task<ActionResult> WorkcenterModel(string id)
        {
            var result = await (from e in context.V_WORK_CENTER_MODEL
                                where e.wc_detail == id && e.statusactive == 1
                                select new
                                {
                                    id = e.id,
                                    wc_code = e.wc_code,
                                    wc_detail = e.wc_detail,
                                    model_code = e.model_code,
                                    model_detail = e.model_detail

                                }).OrderBy(x => x.wc_detail).ThenBy(x => x.model_detail).ToListAsync();
            return Ok(result);
        }

        [HttpGet]
        [Route("ModelProcess")]
        public async Task<ActionResult> ModelProcess()
        {
            var result = await (from e in context.V_MODEL_PROCESS
                                where e.statusactive == 1
                                select new
                                {
                                    id = e.id,
                                    model_code = e.model_code,
                                    model_detail = e.model_detail,
                                    process_code = e.process_code,
                                    process_detail = e.process_detail
                                }).OrderBy(x => x.model_detail).ThenBy(x => x.process_detail).ToListAsync();
            return Ok(result);
        }

        [HttpGet]
        [Route("ModelProcess/{id}")]
        public async Task<ActionResult> ModelProcess(string id)
        {
            var result = await (from e in context.V_MODEL_PROCESS
                                where e.model_detail == id && e.statusactive == 1
                                select new
                                {
                                    id = e.id,
                                    model_code = e.model_code,
                                    model_detail = e.model_detail,
                                    process_code = e.process_code,
                                    process_detail = e.process_detail
                                }).OrderBy(x => x.model_detail).ThenBy(x => x.process_detail).ToListAsync();
            return Ok(result);
        }

        [HttpGet]
        [Route("ProcessCell")]
        public async Task<ActionResult> ProcessCell()
        {
            var result = await (from e in context.V_PROCESS_CELL
                                where e.statusactive == 1
                                select new
                                {
                                    id = e.id,
                                    process_code = e.process_code,
                                    process_detail = e.process_detail,
                                    cell_code = e.cell_code,
                                    cell_detail = e.cell_detail
                                }).OrderBy(x => x.process_detail).ThenBy(x => x.cell_detail).ToListAsync();
            return Ok(result);
        }

        [HttpGet]
        [Route("ProcessCell/{id}")]
        public async Task<ActionResult> ProcessCell(string id)
        {
            var result = await (from e in context.V_PROCESS_CELL
                                where e.process_detail == id && e.statusactive == 1
                                select new
                                {
                                    id = e.id,
                                    process_code = e.process_code,
                                    process_detail = e.process_detail,
                                    cell_code = e.cell_code,
                                    cell_detail = e.cell_detail
                                }).OrderBy(x => x.process_detail).ThenBy(x => x.cell_detail).ToListAsync();
            return Ok(result);
        }

        [HttpGet]
        [Route("CellShift")]
        public async Task<ActionResult> CellShift()
        {
            var result = await (from e in context.V_CELL_SHIFT
                                where e.statusactive == 1
                                select new
                                {
                                    id = e.id,
                                    cell_code = e.cell_code,
                                    cell_detail = e.cell_detail,
                                    shift_code = e.shift_code,
                                    shift_detail = e.shift_detail
                                }).OrderBy(x => x.cell_detail).ThenBy(x => x.shift_detail).ToListAsync();
            return Ok(result);
        }

        [HttpGet]
        [Route("CellShift/{id}")]
        public async Task<ActionResult> CellShift(string id)
        {
            var result = await (from e in context.V_CELL_SHIFT
                                where e.cell_detail == id && e.statusactive == 1
                                select new
                                {
                                    id = e.id,
                                    cell_code = e.cell_code,
                                    cell_detail = e.cell_detail,
                                    shift_code = e.shift_code,
                                    shift_detail = e.shift_detail
                                }).OrderBy(x => x.cell_detail).ThenBy(x => x.shift_detail).ToListAsync();
            return Ok(result);
        }

        [HttpGet]
        [Route("Manpower")]
        public async Task<ActionResult> Manpower()
        {
            var result = await (from e in context.V_MANPOWER
                                select new
                                {
                                    id = e.id,
                                    wc_code = e.wc_code,
                                    wc_detail = e.wc_detail,
                                    model_code = e.model_code,
                                    model_detail = e.model_detail,
                                    process_code = e.process_code,
                                    process_detail = e.process_detail,
                                    cell_code = e.cell_code,
                                    cell_detail = e.cell_detail,
                                    category = e.category,
                                    shift_code = e.shift_code,
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

        [HttpPost]
        [Route("Manpower/Search")]
        public async Task<ActionResult> Manpower(T_MANPOWER_SEARCH data)
        {
            var result = await (from e in context.V_MANPOWER
                                where e.wc_code == data.wc_code
&& e.model_code == data.model_code
&& e.process_code == data.process_code
&& e.cell_code == data.cell_code
&& e.shift_code == data.shift_code
                                select new
                                {
                                    //id = e.id,
                                    wc_code = e.wc_code,
                                    wc_detail = e.wc_detail,
                                    model_code = e.model_code,
                                    model_detail = e.model_detail,
                                    process_code = e.process_code,
                                    process_detail = e.process_detail,
                                    cell_code = e.cell_code,
                                    cell_detail = e.cell_detail,
                                    category = e.category,
                                    shift_code = e.shift_code,
                                    shift_detail = e.shift_detail,
                                    manpower = e.manpower,
                                    op_meister = e.op_meister,
                                    sp_meister = e.sp_meister,
                                    block_group_code = e.block_group_code,
                                    gb_cell_code = e.gb_cell_code
                                }).OrderBy(x => x.wc_detail).ThenBy(x => x.model_detail)
                                .ThenBy(x => x.process_detail)
                                .ThenBy(x => x.cell_detail)
                                .ThenBy(x => x.shift_detail)
                                .ThenBy(x => x.manpower)
                                .ThenBy(x => x.op_meister)
                                .ThenBy(x => x.sp_meister)
                                .ThenBy(x => x.block_group_code)
                                .ThenBy(x => x.gb_cell_code).ToListAsync();
            return Ok(result);
        }

    }
}