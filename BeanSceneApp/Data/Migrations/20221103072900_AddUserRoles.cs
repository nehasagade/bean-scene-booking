using BeanSceneApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BeanSceneApp.Data.Migrations
{
    public partial class AddUserRoles : Migration
    {
        private MigrationBuilder? _migrationBuilder;
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            _migrationBuilder = migrationBuilder;

            // Add roles to roles table
            // Generated from https://guidgenerator.com/online-guid-generator.aspx
            CreateRole("6daa73c4-06fe-4cd1-8137-93e6c42d560c", "Customer");
            CreateRole("889549c5-e8fa-469c-a76a-23df1e4deaba", "Staff");
            CreateRole("1611da2a-d58d-4bd3-a372-d6a5f037b9cb", "Manager");

            // Add users to users table and assign the roles!
            CreateUser("f4e02aa0-aa88-451b-aaac-fe1e4ff89b7e", "manager@beanscene.com.au", "testP@55w0rd", "manager@beanscene.com.au", "0400 000 000", "One", "Manager", new string[] { "1611da2a-d58d-4bd3-a372-d6a5f037b9cb", "889549c5-e8fa-469c-a76a-23df1e4deaba" });
            CreateUser("ab3fb354-2bc1-4f28-b654-990d7cc7f78f", "staff@beanscene.com.au", "testP@55w0rd", "staff@beanscene.com.au", "0400 000 000", "One", "Staff", new string[] { "889549c5-e8fa-469c-a76a-23df1e4deaba" });
            CreateUser("32e90de2-8d25-4b11-ae7b-4e4137f92d97", "user@user.com.au", "testP@55w0rd", "user@user.com.au", "0400 000 000", "One", "User", new string[] { "6daa73c4-06fe-4cd1-8137-93e6c42d560c" });

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            _migrationBuilder = migrationBuilder;
            // Remove roles
            DeleteRole("6daa73c4-06fe-4cd1-8137-93e6c42d560c");
            DeleteRole("889549c5-e8fa-469c-a76a-23df1e4deaba");
            DeleteRole("1611da2a-d58d-4bd3-a372-d6a5f037b9cb");
        }

        /// <summary>
        /// Create an Identity
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        // Need to generate the id, because it could be different each time the migration is run.
        private void CreateRole(string id, string name)
        {
            // Create new object
            IdentityRole role = new IdentityRole();
            role.Id = id;
            role.Name = name;

            // Generate normalised name
            role.NormalizedName = name.ToUpperInvariant();

            // Genereate concurrency stamp
            role.ConcurrencyStamp = Guid.NewGuid().ToString();
            string[] fields = { "Id", "Name", "NormalizedName", "ConcurrencyStamp" };
            object[] data = { role.Id, role.Name, role.NormalizedName, role.ConcurrencyStamp };

            _migrationBuilder.InsertData("AspNetRoles", fields, data);
        }

        private void DeleteRole(string id)
        {
            // Delete roles
            _migrationBuilder.DeleteData("AspNetRoles", "Id", id);
        }

        /// <summary>
        /// Create new user
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        private void CreateUser(string id, string username, string password, string email, string? phone, string firstName, string lastName, string[]? roleIds)
        {
            // Create new object
            ApplicationUser user = new ApplicationUser();
            user.Id = id;
            user.UserName = username;
            user.Email = email;
            user.PhoneNumber = phone;
            user.FirstName = firstName;
            user.LastName = lastName;
            // Generate normalised username
            user.NormalizedUserName = username.ToUpperInvariant();
            user.NormalizedEmail = email.ToUpperInvariant();
            // Genereate concurrency stamp
            user.ConcurrencyStamp = Guid.NewGuid().ToString();
            // Security stamp
            user.SecurityStamp = Guid.NewGuid().ToString();
            // Generate password has from plaintext password
            PasswordHasher<ApplicationUser> hasher = new PasswordHasher<ApplicationUser>();
            user.PasswordHash = hasher.HashPassword(user, password);

            // Other data
            user.EmailConfirmed = true;
            user.PhoneNumberConfirmed = false;
            user.TwoFactorEnabled = false;
            user.LockoutEnabled = true;
            user.LockoutEnd = null;
            user.AccessFailedCount = 0;

            string[] fields = { "Id", "UserName", "NormalizedUserName", "Email", "NormalizedEmail", "EmailConfirmed", "PasswordHash", "SecurityStamp", "ConcurrencyStamp", "PhoneNumber", "PhoneNumberConfirmed", "TwoFactorEnabled", "LockoutEnabled", "AccessFailedCount", "FirstName", "LastName" };
            object[] data = { user.Id, user.UserName, user.NormalizedUserName, user.Email, user.NormalizedEmail, user.EmailConfirmed, user.PasswordHash, user.SecurityStamp, user.ConcurrencyStamp, user.PhoneNumber, user.PhoneNumberConfirmed, user.TwoFactorEnabled, user.LockoutEnabled, user.AccessFailedCount, user.FirstName, user.LastName };

            _migrationBuilder.InsertData("AspNetUsers", fields, data);

            // Assign role(s) to users
            if (roleIds != null)
            {
                foreach (var roleId in roleIds)
                {
                    AssignRoleToUser(user.Id, roleId);
                }
            }
        }

        private void DeleteUser(string id)
        {
            // Delete roles
            _migrationBuilder.DeleteData("AspNetUsers", "Id", id);
        }

        /// <summary>
        /// Assign the roles to users
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="roleId"></param>
        private void AssignRoleToUser(string userId, string roleId)
        {
            // TODO Validation - check role and users exists
            string[] fields = { "UserId", "RoleId" };
            object[] data = { userId, roleId };

            _migrationBuilder.InsertData("AspNetUserRoles", fields, data);
        }
    }
}
