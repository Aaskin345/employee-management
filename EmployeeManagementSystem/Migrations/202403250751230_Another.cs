namespace EmployeeManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Another : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                        "dbo.LeaveApplications",
                        c => new
                        {
                            Id = c.Int(nullable: false, identity: true),
                            EmployeeId = c.Int(nullable: false),
                            NoOfDays = c.Int(nullable: false),
                            StartDate = c.DateTime(nullable: false),
                            EndDate = c.DateTime(nullable: false),
                            DurationId = c.Int(nullable: false),
                            LeaveTypeId = c.Int(nullable: false),
                            Description = c.String(),
                            StatusId = c.Int(nullable: false),
                            CreatedById = c.String(),
                            CreatedOn = c.DateTime(nullable: false),
                            ModifieById = c.String(),
                            ModifiedOn = c.DateTime(nullable: false),
                        })
                        .PrimaryKey(t => t.Id)
                        .ForeignKey("dbo.SystemCodeDetails", t => t.DurationId, cascadeDelete: true)
                        .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: true)
                        .ForeignKey("dbo.LeaveTypes", t => t.LeaveTypeId, cascadeDelete: true)
                        .ForeignKey("dbo.SystemCodeDetails", t => t.StatusId, cascadeDelete: false) // set cascadeDelete to false
                        .Index(t => t.EmployeeId)
                        .Index(t => t.DurationId)
                        .Index(t => t.LeaveTypeId)
                        .Index(t => t.StatusId);

        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LeaveApplications", "StatusId", "dbo.SystemCodeDetails");
            DropForeignKey("dbo.LeaveApplications", "LeaveTypeId", "dbo.LeaveTypes");
            DropForeignKey("dbo.LeaveApplications", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.LeaveApplications", "DurationId", "dbo.SystemCodeDetails");
            DropIndex("dbo.LeaveApplications", new[] { "StatusId" });
            DropIndex("dbo.LeaveApplications", new[] { "LeaveTypeId" });
            DropIndex("dbo.LeaveApplications", new[] { "DurationId" });
            DropIndex("dbo.LeaveApplications", new[] { "EmployeeId" });
            DropTable("dbo.LeaveApplications");
        }
    }
}
