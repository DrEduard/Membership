namespace Membership.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using System.Text;

    public partial class DefautMigration : DbMigration
    {
        public override void Up()
        {
            StringBuilder storedProcedureCode = new StringBuilder();

            storedProcedureCode.Append("CREATE PROCEDURE dbo.Get_ReportData_Members" + Environment.NewLine);
            storedProcedureCode.Append("@status int" + Environment.NewLine);
            storedProcedureCode.Append("AS" + Environment.NewLine);
            storedProcedureCode.Append("BEGIN" + Environment.NewLine);
            storedProcedureCode.Append(@"SELECT m.*, s.Name as Status from dbo.Member m join Status s on m.StatusId = s.Id where (@status = -1 or m.StatusId = @status) order by m.Id" + Environment.NewLine);
            storedProcedureCode.Append("END" + Environment.NewLine);

            this.Sql(storedProcedureCode.ToString());
        }
        
        public override void Down()
        {
            this.Sql("DROP PROCEDURE dbo.Get_ReportData_Members");
        }
    }
}
