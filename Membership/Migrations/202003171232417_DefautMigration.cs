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
            storedProcedureCode.Append("AS" + Environment.NewLine);
            storedProcedureCode.Append("BEGIN" + Environment.NewLine);
            storedProcedureCode.Append(@"SELECT * from dbo.Member order by Id" + Environment.NewLine);
            storedProcedureCode.Append("END" + Environment.NewLine);

            this.Sql(storedProcedureCode.ToString());
        }
        
        public override void Down()
        {
            this.Sql("DROP PROCEDURE dbo.Get_ReportData_Members");
        }
    }
}
