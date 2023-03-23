using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRServicesAPI.Migrations
{
    public partial class CreateViewLeaveDateSeries : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("CREATE OR REPLACE VIEW public.\"View_LeaveDateSeries\" AS select leaves.\"Id\", leaves.\"IdEmployee\", to_char(gs.gd, 'YYYY') as \"Year\", gs.gd as \"Date\" from \"Leaves\" leaves join lateral (select leaves.\"Id\", gd from generate_series(leaves.\"StartDt\", leaves.\"EndDt\", interval '1 day') gd) as gs on gs.\"Id\" = leaves.\"Id\"");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP VIEW IF EXISTS public.\"View_LeaveDateSeries\"");
        }
    }
}
