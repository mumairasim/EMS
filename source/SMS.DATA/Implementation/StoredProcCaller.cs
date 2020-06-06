using SMS.DATA.Infrastructure;
using SMS.DATA.Models.NonDbContextModels;
using System;
using System.Configuration;
using System.Data.SqlClient;

namespace SMS.DATA.Implementation
{
    public class StoredProcCaller : IStoredProcCaller
    {
        private readonly SqlConnection _connection;
        public StoredProcCaller()
        {
            var connStr = ConfigurationManager.ConnectionStrings["SmsConnection"].ConnectionString;
            _connection = new SqlConnection(connStr);
        }
        public UserInfo GetUserInfo(string UserName)
        {

            _connection.Open();
            SqlCommand cmd = new SqlCommand("GetUserInfobyusername", _connection);
            cmd.Parameters.AddWithValue("UserName", UserName);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            var rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                var imgSize = rdr["ImageSize"].ToString();
                var imageId = rdr["ImageId"].ToString() == "" ? Guid.Empty : Guid.Parse(rdr["ImageId"].ToString());
                return new UserInfo
                {
                    UserName = rdr["Username"].ToString(),
                    Email = rdr["Email"].ToString(),
                    FirstName = rdr["FirstName"].ToString(),
                    LastName = rdr["LastName"].ToString(),
                    CreationDate = (DateTime)rdr["CreatedDate"],
                    PermanentAddress = rdr["PermanentAddress"].ToString(),
                    Phone = rdr["Phone"].ToString(),
                    ImageName = rdr["ImageName"].ToString(),
                    ImagePath = rdr["ImagePath"].ToString(),
                    ImageSize = Convert.ToInt32(imgSize == "" ? "0" : imgSize),
                    ImageId = imageId,
                    PersonId = Guid.Parse(rdr["PersonId"].ToString()),
                    ImageExtension = rdr["ImageExtension"].ToString()
                };
            }
            _connection.Close();
            return null;
        }
    }
}
