using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Reflection;

namespace JKSAPI
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<T_NADAMS_TEMP>().HasKey(table => new
            {
                table.date_time,
                table.mercury,
                table.qt_num
            });
        }        

        //"ConnStr": "server=cptsvs109\\cpttest;database=JKS_SYSTEM;trusted_connection=true;User ID=sa;Password=admincpt;Integrated Security=False;MultipleActiveResultSets=true;App=EntityFramework"
        //"ConnStr": "server=cptsvs109\\cpt03;database=JKS_SYSTEM;trusted_connection=true;User ID=sa;Password=admincpt;Integrated Security=False;MultipleActiveResultSets=true;App=EntityFramework"

        public DbSet<TB_Login> T_LOGIN { get; set; }
        public DbSet<TB_DATA_CELL> M_CELL { get; set; }
        public DbSet<TB_DATA_MODEL> M_MODEL { get; set; }
        public DbSet<TB_DATA_PROCESS> M_PROCESS { get; set; }
        public DbSet<TB_DATA_SHIFT> M_BLOCK_SHIFT { get; set; }
        public DbSet<TB_DATA_WC> M_WORK_CENTER { get; set; }
        public DbSet<TB_DATA_BLOCK_GROUP> M_BLOCK_GROUP { get; set; }
        public DbSet<TB_DATA_GB_CELL> M_GB_CELL_CODE { get; set; }
        public DbSet<TB_DATA_TSS> M_TSS { get; set; }


        public DbSet<T_WORK_CENTER_MODEL> T_WORK_CENTER_MODEL { get; set; }
        public DbSet<T_MODEL_PROCESS> T_MODEL_PROCESS { get; set; }
        public DbSet<T_PROCESS_CELL> T_PROCESS_CELL { get; set; }
        public DbSet<T_CELL_SHIFT> T_CELL_SHIFT { get; set; }
        public DbSet<T_MANPOWER> T_MANPOWER { get; set; }
        public DbSet<T_MANPOWER_SEARCH> T_MANPOWER_S { get; set; }


        public DbSet<V_WORK_CENTER_MODEL> V_WORK_CENTER_MODEL { get; set; }
        public DbSet<V_MODEL_PROCESS> V_MODEL_PROCESS { get; set; }
        public DbSet<V_PROCESS_CELL> V_PROCESS_CELL { get; set; }
        public DbSet<V_CELL_SHIFT> V_CELL_SHIFT { get; set; }
        public DbSet<V_MANPOWER> V_MANPOWER { get; set; }


        public DbSet<T_SUMMARY_JKS> T_SUMMARY_JKS { get; set; }
        public DbSet<T_SUMMARY_OT> T_SUMMARY_OT { get; set; }
        public DbSet<T_SUMMARY_TSS> T_SUMMARY_TSS { get; set; }
        public DbSet<T_SUMMARY_TSS_TEMP> T_SUMMARY_TSS_TEMP { get; set; }
        public DbSet<T_SUMMARY_TSS> T_SUMMARY_DATA { get; set; }

        public DbSet<V_SUMMARY_JKS_OT> V_SUMMARY_JKS_OT { get; set; }
        public DbSet<V_SUMMARY_TSS> V_SUMMARY_TSS { get; set; }
        public DbSet<T_NADAMS> T_NADAMS { get; set; }
        public DbSet<T_NADAMS_TEMP> T_NADAMS_TEMP { get; set; }
        public DbSet<T_ST_DB> T_ST_DB { get; set; }
        public DbSet<T_ST_DB_TEMP> T_ST_DB_TEMP { get; set; }
        public DbSet<V_CHART> V_CHART { get; set; }

        // from stored procedures
        public DbSet<S_SUMMARY_OUTPUT> S_SUMMARY_OUTPUT { get; set; }

        ///////////////////////////////////////// Report Summary
        public DbSet<V_Report_SummaryJKS> V_ReportSummaryJKS { get; set; }
        public DbSet<V_Report_SummaryOT> V_ReportSummaryOT { get; set; }
        public DbSet<V_Report_SummaryTSS> V_ReportSummaryTSS { get; set; }
        public DbSet<V_ReportHistory> V_ReportHistory { get; set; }

    }
}