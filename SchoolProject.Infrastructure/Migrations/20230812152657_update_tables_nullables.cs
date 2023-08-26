using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolProject.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class update_tables_nullables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Departments_Instractor_InsManager",
                table: "Departments");

            migrationBuilder.DropForeignKey(
                name: "FK_Ins_Subject_Instractor_InsId",
                table: "Ins_Subject");

            migrationBuilder.DropForeignKey(
                name: "FK_Ins_Subject_Subjects_SubID",
                table: "Ins_Subject");

            migrationBuilder.DropForeignKey(
                name: "FK_Instractor_Departments_DID",
                table: "Instractor");

            migrationBuilder.DropForeignKey(
                name: "FK_Instractor_Instractor_SupervisorId",
                table: "Instractor");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Departments_DID",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Departments_InsManager",
                table: "Departments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Instractor",
                table: "Instractor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ins_Subject",
                table: "Ins_Subject");

            migrationBuilder.RenameTable(
                name: "Instractor",
                newName: "Instractors");

            migrationBuilder.RenameTable(
                name: "Ins_Subject",
                newName: "Ins_Subjects");

            migrationBuilder.RenameIndex(
                name: "IX_Instractor_SupervisorId",
                table: "Instractors",
                newName: "IX_Instractors_SupervisorId");

            migrationBuilder.RenameIndex(
                name: "IX_Instractor_DID",
                table: "Instractors",
                newName: "IX_Instractors_DID");

            migrationBuilder.RenameIndex(
                name: "IX_Ins_Subject_SubID",
                table: "Ins_Subjects",
                newName: "IX_Ins_Subjects_SubID");

            migrationBuilder.RenameIndex(
                name: "IX_Ins_Subject_InsId",
                table: "Ins_Subjects",
                newName: "IX_Ins_Subjects_InsId");

            migrationBuilder.AlterColumn<string>(
                name: "SubjectNameEn",
                table: "Subjects",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "SubjectNameAr",
                table: "Subjects",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Period",
                table: "Subjects",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<decimal>(
                name: "degree",
                table: "StudentSubjects",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "Students",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.AlterColumn<string>(
                name: "NameEn",
                table: "Students",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "NameAr",
                table: "Students",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<int>(
                name: "DID",
                table: "Students",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Students",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.AlterColumn<int>(
                name: "InsManager",
                table: "Departments",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "DNameEn",
                table: "Departments",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "DNameAr",
                table: "Departments",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.AlterColumn<int>(
                name: "SupervisorId",
                table: "Instractors",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<decimal>(
                name: "Salary",
                table: "Instractors",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<string>(
                name: "Position",
                table: "Instractors",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "ENameEn",
                table: "Instractors",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "ENameAr",
                table: "Instractors",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Instractors",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Instractors",
                table: "Instractors",
                column: "InsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ins_Subjects",
                table: "Ins_Subjects",
                column: "InsSubId");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_InsManager",
                table: "Departments",
                column: "InsManager",
                unique: true,
                filter: "[InsManager] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_Instractors_InsManager",
                table: "Departments",
                column: "InsManager",
                principalTable: "Instractors",
                principalColumn: "InsId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Ins_Subjects_Instractors_InsId",
                table: "Ins_Subjects",
                column: "InsId",
                principalTable: "Instractors",
                principalColumn: "InsId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ins_Subjects_Subjects_SubID",
                table: "Ins_Subjects",
                column: "SubID",
                principalTable: "Subjects",
                principalColumn: "SubID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Instractors_Departments_DID",
                table: "Instractors",
                column: "DID",
                principalTable: "Departments",
                principalColumn: "DID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Instractors_Instractors_SupervisorId",
                table: "Instractors",
                column: "SupervisorId",
                principalTable: "Instractors",
                principalColumn: "InsId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Departments_DID",
                table: "Students",
                column: "DID",
                principalTable: "Departments",
                principalColumn: "DID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Departments_Instractors_InsManager",
                table: "Departments");

            migrationBuilder.DropForeignKey(
                name: "FK_Ins_Subjects_Instractors_InsId",
                table: "Ins_Subjects");

            migrationBuilder.DropForeignKey(
                name: "FK_Ins_Subjects_Subjects_SubID",
                table: "Ins_Subjects");

            migrationBuilder.DropForeignKey(
                name: "FK_Instractors_Departments_DID",
                table: "Instractors");

            migrationBuilder.DropForeignKey(
                name: "FK_Instractors_Instractors_SupervisorId",
                table: "Instractors");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Departments_DID",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Departments_InsManager",
                table: "Departments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Instractors",
                table: "Instractors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ins_Subjects",
                table: "Ins_Subjects");

            migrationBuilder.DropColumn(
                name: "degree",
                table: "StudentSubjects");

            migrationBuilder.RenameTable(
                name: "Instractors",
                newName: "Instractor");

            migrationBuilder.RenameTable(
                name: "Ins_Subjects",
                newName: "Ins_Subject");

            migrationBuilder.RenameIndex(
                name: "IX_Instractors_SupervisorId",
                table: "Instractor",
                newName: "IX_Instractor_SupervisorId");

            migrationBuilder.RenameIndex(
                name: "IX_Instractors_DID",
                table: "Instractor",
                newName: "IX_Instractor_DID");

            migrationBuilder.RenameIndex(
                name: "IX_Ins_Subjects_SubID",
                table: "Ins_Subject",
                newName: "IX_Ins_Subject_SubID");

            migrationBuilder.RenameIndex(
                name: "IX_Ins_Subjects_InsId",
                table: "Ins_Subject",
                newName: "IX_Ins_Subject_InsId");

            migrationBuilder.AlterColumn<string>(
                name: "SubjectNameEn",
                table: "Subjects",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SubjectNameAr",
                table: "Subjects",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Period",
                table: "Subjects",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "Students",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NameEn",
                table: "Students",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NameAr",
                table: "Students",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DID",
                table: "Students",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Students",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "InsManager",
                table: "Departments",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DNameEn",
                table: "Departments",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DNameAr",
                table: "Departments",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SupervisorId",
                table: "Instractor",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Salary",
                table: "Instractor",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Position",
                table: "Instractor",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ENameEn",
                table: "Instractor",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ENameAr",
                table: "Instractor",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Instractor",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Instractor",
                table: "Instractor",
                column: "InsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ins_Subject",
                table: "Ins_Subject",
                column: "InsSubId");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_InsManager",
                table: "Departments",
                column: "InsManager",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_Instractor_InsManager",
                table: "Departments",
                column: "InsManager",
                principalTable: "Instractor",
                principalColumn: "InsId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Ins_Subject_Instractor_InsId",
                table: "Ins_Subject",
                column: "InsId",
                principalTable: "Instractor",
                principalColumn: "InsId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ins_Subject_Subjects_SubID",
                table: "Ins_Subject",
                column: "SubID",
                principalTable: "Subjects",
                principalColumn: "SubID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Instractor_Departments_DID",
                table: "Instractor",
                column: "DID",
                principalTable: "Departments",
                principalColumn: "DID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Instractor_Instractor_SupervisorId",
                table: "Instractor",
                column: "SupervisorId",
                principalTable: "Instractor",
                principalColumn: "InsId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Departments_DID",
                table: "Students",
                column: "DID",
                principalTable: "Departments",
                principalColumn: "DID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
