using DBEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DBContext
{
     public interface IApartmentRepository
    {
        List<EntityApartment> GetApartments();
        EntityApartment GetApartmentById(int idAparment);
        List<EntityApartment> GetApartmentsByIdProject(int idProject);
    }
}
