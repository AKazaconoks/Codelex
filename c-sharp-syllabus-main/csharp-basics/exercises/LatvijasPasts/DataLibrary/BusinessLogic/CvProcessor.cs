using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using DataLibrary.DataAccess;
using DataLibrary.Models;

namespace DataLibrary.BusinessLogic
{
    public static class CvProcessor
    {
        public static int CreatePrimaryData(string firstName, string lastName, string phoneNumber,
            string emailAddress)
        {
            var data = new PrimaryDataModel
            {
                FirstName = firstName,
                LastName = lastName,
                PhoneNumber = phoneNumber,
                EmailAddress = emailAddress
            };

            var sql = @"INSERT INTO dbo.PrimaryData (FirstName, LastName, PhoneNumber, EmailAddress)
                            VALUES (@FirstName, @LastName, @PhoneNumber, @EmailAddress);";

            return SqlDataAccess.SaveData(sql, data);
        }

        public static int CreateEducationData(string educationName, string educationFaculty,
            string educationDirection,
            string educationLevel, string educationStatus, int primaryDataId)
        {
            var data = new EducationDataModel()
            {
                EducationName = educationName,
                EducationFaculty = educationFaculty,
                EducationDirection = educationDirection,
                EducationLevel = educationLevel,
                EducationStatus = educationStatus,
                PrimaryDataId = primaryDataId
            };

            var sql =
                @"INSERT INTO dbo.EducationData (EducationName, EducationFaculty, EducationDirection, EducationLevel, EducationStatus, PrimaryDataId)
                            VALUES (@EducationName, @EducationFaculty, @EducationDirection, @EducationLevel, @EducationStatus, @PrimaryDataId);";

            return SqlDataAccess.SaveData(sql, data);
        }

        public static int CreateWorkplaceSkillData(string skillDescription, string skillType, int workplaceId)
        {
            var data = new WorkplaceSkillDataModel()
            {
                SkillDescription = skillDescription,
                SkillType = skillType,
                WorkplaceId = workplaceId
            };

            var sql =
                @"INSERT INTO dbo.WorkplaceSkillData (SkillDescription, SkillType, WorkplaceId)
                            VALUES (@SkillDescription, @SkillType, @WorkplaceId);";

            return SqlDataAccess.SaveData(sql, data);
        }

        public static int CreateWorkplaceData(int primaryDataId, string workplaceName, string workplaceTitle,
            string workplaceTenure)
        {
            var data = new WorkplaceDataModel()
            {
                PrimaryDataId = primaryDataId,
                WorkplaceName = workplaceName,
                WorkplaceTitle = workplaceTitle,
                WorkplaceTenure = workplaceTenure
            };

            var sql =
                @"INSERT INTO dbo.WorkplaceData (PrimaryDataId, WorkplaceName, WorkplaceTitle, WorkplaceTenure)
                            VALUES (@PrimaryDataId, @WorkplaceName, @WorkplaceTitle, @WorkplaceTenure);";

            return SqlDataAccess.SaveData(sql, data);
        }

        public static int CreateLanguageData(string language, int primaryDataId)
        {
            var data = new LanguageDataModel()
            {
                Language = language,
                PrimaryDataId = primaryDataId,
            };

            var sql =
                @"INSERT INTO dbo.LanguageData (Language, PrimaryDataId)
                            VALUES (@Language, @PrimaryDataId);";

            return SqlDataAccess.SaveData(sql, data);
        }

        public static List<T> LoadData<T>(string tableName)
        {
            var sql = $"SELECT * FROM dbo.{tableName};";

            return SqlDataAccess.LoadData<T>(sql);
        }

        public static int GetLastInsertedId(string tableName)
        {
            using (var connection = new SqlConnection(SqlDataAccess.GetConnectionString()))
            {
                var query = $"SELECT IDENT_CURRENT('{tableName}')";
                using (var command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    var result = command.ExecuteScalar();
                    return Convert.ToInt32(result);
                }
            }
        }

        public static void DeletePrimaryData(int id)
        {
            var sql = @"DELETE FROM dbo.PrimaryData WHERE Id = @Id;";

            SqlDataAccess.DeleteData(sql, new { Id = id });
        }

        public static void UpdateData<T>(string tableName, T data)
        {
            var idColumn = "";
            switch (tableName)
            {
                case "EducationData":
                    idColumn = "EducationId";
                    break;
                case "WorkplaceSkillData":
                    idColumn = "SkillId";
                    break;
                default:
                    idColumn = "Id";
                    break;
            }
            var properties = typeof(T).GetProperties().Where(p => p.Name != idColumn);
            var columns = string.Join(", ", properties.Select(p => p.Name + " = @" + p.Name));
            var sql = $"UPDATE dbo.{tableName} SET {columns} WHERE {idColumn} = @{idColumn}";
            var parameters = new DynamicParameters();
            parameters.Add(idColumn, data.GetType().GetProperty(idColumn).GetValue(data));
            foreach (var property in properties)
            {
                parameters.Add(property.Name, property.GetValue(data));
            }
            SqlDataAccess.UpdateData(sql, parameters);
        }

    }
}