using DBEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DBContext
{
    public interface IProjectRepository
    {
        List<EntityProject> GetProjects();
        EntityProject GetProjectByIdProject(int idProject);

        List<EntityProject> GetProjectsByParams(string parameters);
    }
}
