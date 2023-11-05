using DataAccessLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary
{
    public class CarTypeData : ICarTypeData
    {
        private readonly ISqlDataAccess _db;

        public CarTypeData(ISqlDataAccess db)
        {
            _db = db;
        }

        public Task<List<CarTypeModel>> GetCarTypes()
        {
            string sql = "select * from dbo.CarTypes";

            return _db.LoadData<CarTypeModel, dynamic>(sql, new { });
        }

        public Task InsertCarType(CarTypeModel carType)
        {
            string sql = @"insert into dbo.CarType (CarType,Description)
                            values (@CarType,@Description);";

            return _db.SaveData(sql, carType);
        }
       
    }
}
