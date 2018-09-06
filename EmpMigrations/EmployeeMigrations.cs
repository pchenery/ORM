using FluentMigrator;

namespace EmpMigrations
{
    [Migration(20180905203000)]
    public class EmployeeMigrations : Migration
    {
        public override void Up()
        {
            Create.Table("EmployeeNew")
                .WithColumn("Id").AsInt32().NotNullable().PrimaryKey().Identity()
                .WithColumn("FirstName").AsString().NotNullable()
                .WithColumn("LastName").AsCustom("NVARCHAR(50)").NotNullable()
                .WithColumn("BirthDate").AsDate().NotNullable()
                .WithColumn("Salary").AsDecimal(15, 4).NotNullable()
                .WithColumn("JobPositionId").AsInt32().NotNullable()

            .ForeignKey("FK_JobPosition", "JobPosition", "Id");
        }

        public override void Down()
        {
            Delete.ForeignKey("FK_JobPosition").OnTable("JobPosition");
            Delete.Table("EmployeeNew");
        }
    }
}
