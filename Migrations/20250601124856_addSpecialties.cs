using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HospitalMVCProject.Migrations
{
    /// <inheritdoc />
    public partial class addSpecialties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("insert into Specialties (name, description, status) values ('Hematology', 'Energy-efficient lights that charge during the day and illuminate at night.', 1);\r\ninsert into Specialties (name, description, status) values ('Pulmonology', 'Oven-roasted sliced turkey, perfect for sandwiches.', 1);\r\ninsert into Specialties (name, description, status) values ('Radiology', 'Gluten-free almond flour, perfect for baking.', 1);\r\ninsert into Specialties (name, description, status) values ('Orthopedics', 'Savory pizza filled with pepperoni and cheese, ready to microwave.', 0);\r\ninsert into Specialties (name, description, status) values ('Pulmonology', 'Juicy and tender boneless chicken breasts.', 0);\r\ninsert into Specialties (name, description, status) values ('Ophthalmology', 'Durable jump rope for cardio workouts.', 0);\r\ninsert into Specialties (name, description, status) values ('Orthopedics', 'Lightweight and portable paddle board for water sports.', 1);\r\ninsert into Specialties (name, description, status) values ('Orthopedics', 'High-quality leather wallet with multiple compartments.', 0);\r\ninsert into Specialties (name, description, status) values ('Urology', 'Set of baking sheets for effortless baking.', 1);\r\ninsert into Specialties (name, description, status) values ('Urology', 'Crunchy granola clusters mixed with nuts and honey.', 0);\r\ninsert into Specialties (name, description, status) values ('Pediatrics', 'Creamy tahini made from ground sesame seeds.', 0);\r\ninsert into Specialties (name, description, status) values ('Pulmonology', 'A fragrant blend of Italian herbs for pasta sauces and marinades.', 1);\r\ninsert into Specialties (name, description, status) values ('Endocrinology', 'Delicious and fully cooked sliced ham, ready to eat.', 0);\r\ninsert into Specialties (name, description, status) values ('Internal Medicine', 'A pack of assorted nut and protein bars for a quick energy boost.', 0);\r\ninsert into Specialties (name, description, status) values ('Obstetrics & Gynecology', 'Durable toy designed for heavy chewers.', 0);\r\ninsert into Specialties (name, description, status) values ('Dermatology', 'Reusable suction cup hooks for hanging items.', 0);\r\ninsert into Specialties (name, description, status) values ('Endocrinology', 'Savory, protein-rich beef jerky for on-the-go snacking.', 1);\r\ninsert into Specialties (name, description, status) values ('Endocrinology', 'Non-contact thermometer for checking temperatures instantly.', 1);\r\ninsert into Specialties (name, description, status) values ('Gastroenterology', 'Soft and comfortable robe, perfect for lounging at home.', 0);\r\ninsert into Specialties (name, description, status) values ('Rheumatology', 'Aromatic long-grain basmati rice, perfect for curries.', 1);");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable("Specialties");
        }
    }
}
