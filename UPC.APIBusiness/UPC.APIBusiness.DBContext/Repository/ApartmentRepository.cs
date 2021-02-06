using Dapper;
using DBEntity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DBContext
{
    public class ApartmentRepository : BaseRepository, IApartmentRepository
    {
        public List<EntityApartment> GetApartments()
        {
            var returnEntity = new List<EntityApartment>();

            try
            {
                using (var db = GetSqlConnection())
                {
                    const string sql = @"usp_ObtenerDepartamentos";
                    returnEntity = db.Query<EntityApartment>(sql, commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }

            return returnEntity;
        }

        public List<EntityApartment> GetApartmentsByIdProject(int idProject)
        {
            var returnEntity = new List<EntityApartment>();

            try
            {
                using (var db = GetSqlConnection())
                {
                    var p = new DynamicParameters();
                    p.Add(name: "@IDPROYECTO", value: idProject, dbType: DbType.Int32, direction: ParameterDirection.Input);

                    const string sql = @"usp_ObtenerDepartamento_By_IdProject";
                    returnEntity = db.Query<EntityApartment>(sql, param: p, commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return returnEntity;
        }
    

        public EntityApartment GetApartmentById(int idAparment)
        {
            var returnEntity = new EntityApartment();

            try
            {
                using (var db = GetSqlConnection())
                {
                    var p = new DynamicParameters();
                    p.Add(name: "@IDDEPARTAMENTO", value: idAparment, dbType: DbType.Int32, direction: ParameterDirection.Input);

                    const string sql = @"usp_ObtenerDepartamento_By_Id";
                    returnEntity = db.Query<EntityApartment>(sql, param: p, commandType: CommandType.StoredProcedure).FirstOrDefault();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return returnEntity;
        }

    }
}
