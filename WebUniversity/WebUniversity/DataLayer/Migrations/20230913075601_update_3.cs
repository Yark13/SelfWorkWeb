using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebUniversity.Migrations
{
    public partial class update_3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Basic mathematics course", "Mathematics" },
                    { 2, "Basic English course", "English" },
                    { 3, "Basic history course", "History of world" },
                    { 24, "Some about world", "The Geografy" },
                    { 25, "About stars", "Astronomy" }
                });

            migrationBuilder.InsertData(
                table: "Groups",
                columns: new[] { "Id", "CourseID", "Name" },
                values: new object[,]
                {
                    { 1, 1, "MA-01" },
                    { 2, 1, "MA-02" },
                    { 3, 2, "EN-01" },
                    { 4, 2, "EN-02" },
                    { 5, 3, "HI-01(modified)" },
                    { 6, 3, "HI-02" },
                    { 13, 24, "SR-01" },
                    { 35, 3, "HI-03" },
                    { 39, 2, "Fi-01" },
                    { 46, 25, "ZI-1" },
                    { 54, 3, "HI-04" },
                    { 56, 24, "SR-02" },
                    { 58, 24, "HI-04" },
                    { 59, 3, "HI-04" }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "FirstName", "GroupId", "LastName" },
                values: new object[,]
                {
                    { 63, "John", 1, "Doe" },
                    { 64, "Jane", 1, "Doe" },
                    { 65, "Bob", 2, "Smith" },
                    { 66, "Alice", 2, "Smith" },
                    { 67, "David", 3, "Johnson" },
                    { 68, "Sarah", 4, "Johnson" },
                    { 69, "Mike", 4, "Brown" },
                    { 70, "Lisa", 4, "Brown" },
                    { 71, "Tom", 5, "Wilson" },
                    { 72, "Mary", 5, "Wilson" },
                    { 73, "Chris", 6, "Lee" },
                    { 74, "Kim", 6, "Lee" },
                    { 75, "Mark", 1, "Jones" },
                    { 76, "Emily", 1, "Jones" },
                    { 77, "Eric", 2, "Smith" },
                    { 78, "Grace", 2, "Johnson" },
                    { 79, "Alex", 3, "Brown" },
                    { 80, "Olivia", 3, "Wilson" },
                    { 81, "Ryan", 4, "Lee" },
                    { 82, "Rachel", 4, "Lee" },
                    { 83, "Daniel", 5, "Davis" },
                    { 84, "Maggie", 5, "Davis" },
                    { 85, "Ben", 6, "Wang" },
                    { 86, "Sophie", 6, "Wang" },
                    { 87, "Peter", 1, "Gonzalez" },
                    { 88, "Cindy", 1, "Gonzalez" },
                    { 89, "Adam", 2, "Allen" },
                    { 90, "Eva", 2, "Allen" },
                    { 91, "Frankov", 3, "Nguyen" },
                    { 92, "Amy", 3, "Nguyen" },
                    { 93, "John", 1, "Doe" },
                    { 94, "Jane", 1, "Doe" },
                    { 95, "Bob", 2, "Smith" },
                    { 96, "Alice", 2, "Smith" },
                    { 97, "David", 3, "Johnson" },
                    { 98, "Sarah", 3, "Johnson" },
                    { 99, "Mike", 4, "Brown" },
                    { 100, "Lisa", 4, "Brown" },
                    { 101, "Tom", 5, "Wilson" },
                    { 102, "Mary", 5, "Wilson" },
                    { 103, "Chris", 6, "Lee" },
                    { 104, "Kim", 6, "Lee" }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "FirstName", "GroupId", "LastName" },
                values: new object[,]
                {
                    { 105, "Mark", 1, "Jones" },
                    { 106, " Emily", 1, "Jones" },
                    { 107, "Eric", 2, "Smith" },
                    { 108, "Grace", 2, "Johnson" },
                    { 109, "Alex", 35, "Brown" },
                    { 110, "Olivia", 39, "Wilson" },
                    { 111, "Ryan", 4, "Lee" },
                    { 112, "Rachel", 46, "Lee" },
                    { 113, "Daniel", 5, "Davis" },
                    { 114, "Maggie", 5, "Davis" },
                    { 115, "Ben", 6, "Wang" },
                    { 116, "Sophie", 6, "Wang" },
                    { 117, "Peter", 1, "Gonzalez" },
                    { 118, "Cindy", 1, "Gonzalez" },
                    { 119, "Adam", 2, "Allen " },
                    { 120, "Eva", 2, "Allen " },
                    { 121, "Frank", 3, "Nguyen" },
                    { 122, "Amy", 3, "Nguyen" },
                    { 125, "Oleg", 4, "Lozynskyi" },
                    { 129, "Dmytro", 2, "Ivasuk" },
                    { 131, "Dmytro", 13, "Savchyn" },
                    { 136, "Oleg", 54, "Vasylyshyn" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Students_GroupId",
                table: "Students",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Groups_CourseID",
                table: "Groups",
                column: "CourseID");

            migrationBuilder.AddForeignKey(
                name: "FK_Groups_Courses_CourseID",
                table: "Groups",
                column: "CourseID",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Groups_GroupId",
                table: "Students",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Groups_Courses_CourseID",
                table: "Groups");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Groups_GroupId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_GroupId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Groups_CourseID",
                table: "Groups");

            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 71);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 72);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 73);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 74);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 75);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 76);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 77);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 78);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 79);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 80);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 81);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 82);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 83);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 84);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 85);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 86);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 87);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 88);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 89);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 90);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 91);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 92);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 93);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 94);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 95);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 96);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 97);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 98);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 99);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 100);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 102);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 103);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 104);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 105);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 106);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 107);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 108);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 109);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 110);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 111);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 112);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 113);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 114);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 115);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 116);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 117);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 118);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 119);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 120);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 121);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 122);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 125);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 129);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 131);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 136);

            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 25);
        }
    }
}
