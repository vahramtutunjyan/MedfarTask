using Medfar.Interview.Types;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 

namespace Medfar.Interview.DAL.Repositories
{
    public class IndividualMessageRepository
    {
        private static string _connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=MEDFAR_DEV_INTERVIEW;Integrated Security=True";
        private static SqlConnection _dbConnection;

        public IndividualMessageRepository()
        {
        }

        public List<IndividualMessage> GetAll()
        {
            _dbConnection = new SqlConnection(_connectionString);
            SqlCommand command = new SqlCommand("SELECT * FROM IndividualMessage", _dbConnection);

            _dbConnection.Open();

            SqlDataReader reader = command.ExecuteReader();


            List<IndividualMessage> messages = new List<IndividualMessage>();
           
            while (reader.Read())
            {
                IndividualMessage message = new IndividualMessage();

                message.Id = (Guid) reader["Id"];
                message.Version = (int) reader["Version"];
                message.CreationDate = (DateTime) reader["CreationDate"];
                message.CreatedBy = (Guid) reader["CreatedBy"];
                message.LastUpdateDate = (DateTime?) reader["LastUpdateDate"];
                message.LastUpdatedBy = (Guid?) reader["LastUpdatedBy"];
                message.DeletionDate = (DateTime?) reader["DeletionDate"];
                message.DeletedBy = (Guid?) reader["DeletedBy"];
                message.ArchivalDate = (DateTime?) reader["ArchivalDate"];
                message.ArchivedBy = (Guid?) reader["ArchivedBy"];
                message.Subject = (string) reader["Subject"];
                message.Body = (string) reader["Body"];
                message.SendDate = (DateTime) reader["SendDate"];
                message.IsTask = (bool) reader["IsTask"];
                message.StartDate = (DateTime?) reader["StartDate"];
                message.DueDate = (DateTime?) reader["DueDate"];
                message.IsDraft = (bool) reader["IsDraft"];
                message.IsGroupTask = (bool?) reader["IsGroupTask"];
                message.DocumentPatientId = (Guid?) reader["DocumentPatientId"];
                message.FileName = (string) reader["FileName"];
                message.TypeTaskLookupId = (Guid?) reader["TypeTaskLookupId"];
                message.PriorityLookupId = (Guid?) reader["PriorityLookupId"];
                message.FromContactId = (Guid) reader["FromContactId"];

                messages.Add(message);
            }

            return messages;
        }

        public List<IndividualMessage> Search(string searchString, DateTime? fromDate, DateTime? toDate)
        {
            _dbConnection = new SqlConnection(_connectionString);

            string sqlQuery = @"SELECT * FROM " +
                                 " IndividualMessage " +
                                 " WHERE (subject like '%" + searchString + "%' OR Body like  '%" + searchString + "%' ) ";
            SqlCommand command = new SqlCommand(sqlQuery, _dbConnection);
            

            if (fromDate.HasValue)
            {
                sqlQuery += " AND SendDate >= '" + fromDate + "'";
            }
            if (toDate.HasValue)
            {
                sqlQuery += " AND SendDate <= '" + toDate + "'";
            }
            
            _dbConnection.Open();
            SqlDataReader reader = command.ExecuteReader();

            List<IndividualMessage> messages = new List<IndividualMessage>();
          
            while (reader.Read())
            {
                IndividualMessage message = new IndividualMessage();

                message.Id = (Guid)reader["Id"];
                message.Version = (int)reader["Version"];
                message.CreationDate = (DateTime)reader["CreationDate"];
                message.CreatedBy = (Guid)reader["CreatedBy"];
                message.LastUpdateDate = (DateTime?)reader["LastUpdateDate"];
                message.LastUpdatedBy = (Guid?)reader["LastUpdatedBy"];
                message.DeletionDate = (DateTime?)reader["DeletionDate"];
                message.DeletedBy = (Guid?)reader["DeletedBy"];
                message.ArchivalDate = (DateTime?)reader["ArchivalDate"];
                message.ArchivedBy = (Guid?)reader["ArchivedBy"];
                message.Subject = (string)reader["Subject"];
                message.Body = (string)reader["Body"];
                message.SendDate = (DateTime)reader["SendDate"];
                message.IsTask = (bool)reader["IsTask"];
                message.StartDate = (DateTime?)reader["StartDate"];
                message.DueDate = (DateTime?)reader["DueDate"];
                message.IsDraft = (bool)reader["IsDraft"];
                message.IsGroupTask = (bool?)reader["IsGroupTask"];
                message.DocumentPatientId = (Guid?)reader["DocumentPatientId"];
                message.FileName = (string)reader["FileName"];
                message.TypeTaskLookupId = (Guid?)reader["TypeTaskLookupId"];
                message.PriorityLookupId = (Guid?)reader["PriorityLookupId"];
                message.FromContactId = (Guid)reader["FromContactId"];

                messages.Add(message);
            }

            return messages;
        }

    }
}


