using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using MISA.Web06.Core.Interface.Insfrastructure;
using MISA.Web06.Core.Interface.MISAAttribute;
using MySqlConnector;
namespace MISA.Web06.Infrastructure.Repository
{
    public class BaseRepository<MISAEntity> : IBaseRepository<MISAEntity>
    {
        #region Initialization
        /// <summary>
        /// Tạo kết nối
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        /// CreatedBy: ND_Tuan(15/08/2022)
        protected readonly string connectionString;
        protected MySqlConnection sqlConnection;


        public BaseRepository()
        {
            // Khai báo thông tin kết nối database:
            connectionString = "Host=3.0.89.182;" +
                           "Database=MISA.WEB06.NTUAN;" +
                           "User Id=dev;" +
                           "Password=12345678;";

            // Khởi tạo kết nối:
            sqlConnection = new MySqlConnection(connectionString);

            // Mở kết nối:
            sqlConnection.Open();
        }

        public void Dispose()
        {
            sqlConnection.Dispose();
            sqlConnection.Close();
        }
        #endregion

        #region Methods
        /// <summary>
        /// Lấy tất cả dữ liệu
        /// </summary>
        /// <returns></returns>
        /// CreatedBy: ND_Tuan(15/08/2022)
        // lay tat ca du lieu
        public IEnumerable<MISAEntity> GetAll()
        {
            // trả về tên hiện tại
            var className = typeof(MISAEntity).Name;
            using (sqlConnection = new MySqlConnection(connectionString))
            {
                // thuc hien truy van du lieu
                var entities = sqlConnection.Query<MISAEntity>($"SELECT * FROM {className}");
                return entities;
            }
        }


        /// <summary>
        /// Lấy dữ liệu theo Id
        /// </summary>
        /// <returns>Mã nhân viên</returns>
        /// CreatedBy: ND_Tuan(15/08/2022)
        public MISAEntity GetById(Guid entityId)
        {
            using (sqlConnection = new MySqlConnection(connectionString))
            {
                var className = typeof(MISAEntity).Name;
                //tao ket noi
                var sqlConnection = new MySqlConnection(connectionString);
                var sql = $"SELECT * FROM {className} WHERE {className}Id = @{className}Id";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add($"@{className}Id", entityId);
                // thuc hien truy van du lieu
                var entitys = sqlConnection.QueryFirstOrDefault<MISAEntity>(sql, param: parameters);
                return entitys;
            }
        }

        /// <summary>
        /// Thêm mới.
        /// </summary>
        /// <returns>Mã nhân viên</returns>
        /// CreatedBy: ND_Tuan(15/08/2022)
        public virtual int Insert(MISAEntity entity)
        {
            var className = typeof(MISAEntity).Name;
            using (sqlConnection = new MySqlConnection(connectionString))
            {
                var sql = $"Proc_Insert{className}";

                var res = sqlConnection.Execute(sql: sql, param: entity, commandType: System.Data.CommandType.StoredProcedure);
                return res;
            }

        }


        /// <summary>
        /// Sửa.
        /// </summary>
        /// <returns>Mã nhân viên</returns>
        /// CreatedBy: ND_Tuan(15/08/2022)
        /// <summary>
        public int Update(MISAEntity entity)
        {
            var className = typeof(MISAEntity).Name;
            using (sqlConnection = new MySqlConnection(connectionString))
            {
                var sql = $"Proc_Update{className}";

                var res = sqlConnection.Execute(sql: sql, param: entity, commandType: System.Data.CommandType.StoredProcedure);
                return res;
            }
        }

        /// <summary>
        /// Xóa bản ghi theo ID
        /// </summary>
        /// <returns></returns>
        /// CreatedBy: ND_Tuan(15/08/2022)
        public int Delete(Guid entityId)
        {
            var className = typeof(MISAEntity).Name;
            using (sqlConnection = new MySqlConnection(connectionString))
            {
                var sql = $"DELETE FROM {className} WHERE {className}Id = @{className}Id";
                var parameters = new DynamicParameters();
                parameters.Add($"@{className}Id", entityId);
                var res = sqlConnection.Execute(sql: sql, param: parameters);
                return res;
            }
        }

      

        #endregion



    }
}
