using Dapper;
using DBEntity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DBContext
{
    public class ProjectRepository : BaseRepository, IProjectRepository
    {
        public EntityProject GetProjectByIdProject(int idProject)
        {
            ApartmentRepository apartmentRepository = new ApartmentRepository();
            List<EntityApartment> entityApartments = new List<EntityApartment>();

            var returnEntity = new EntityProject();

            try
            {
                using (var db = GetSqlConnection())
                {
                    var p = new DynamicParameters();
                    p.Add(name: "@IDPROYECTO", value: idProject, DbType.Int32, direction: ParameterDirection.Input);

                    const string sql = @"usp_ObtenerProyecto_By_Id";
                    returnEntity = db.Query<EntityProject>(sql, param: p, commandType: CommandType.StoredProcedure).FirstOrDefault();
                }

                if(returnEntity != null)
                {
                    entityApartments = apartmentRepository.GetApartmentsByIdProject(idProject);

                    returnEntity.Apartments = entityApartments;
                }
            }
            catch(Exception e) 
            {
                throw new Exception(e.Message);
            }
            

            return returnEntity;
        }

        public List<EntityProject> GetProjects()
        {
            var returnEntity = new List<EntityProject>();

            try
            {
                using (var db = GetSqlConnection())
                {
                    const string sql = @"usp_ObtenerProyectos";
                    returnEntity = db.Query<EntityProject>(sql, commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
            

            return returnEntity;
        }

        public List<EntityProject> GetProjectsByParams(string parameters)
        {
            var returnEntity = new List<EntityProject>();

            try
            {
                using (var db = GetSqlConnection())
                {
                    var p = new DynamicParameters();
                    p.Add(name: "@BUSQUEDA", value: parameters, DbType.String, direction: ParameterDirection.Input);

                    const string sql = @"usp_BuscarProyectos";
                    returnEntity = db.Query<EntityProject>(sql, param: p, commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
            
            return returnEntity;
        }
    }
}
