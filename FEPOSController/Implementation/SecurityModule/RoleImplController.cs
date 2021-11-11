using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FEPOSController.DTO.SecurityModule;
using FEPOSController.Mapper.SecurityModule;
using FEPOSModel.DbModel.SecurityModule;
using FEPOSModel.Implementation.SecurityModule;

namespace FEPOSController.Implementation.SecurityModule
{
    public class RoleImplController
    {
        private RoleImplModel model;
        public RoleImplController()
        {
            model = new RoleImplModel();
        }

        /// <summary>
        /// Creación de un registro
        /// </summary>
        /// <param name="dto">Información DTO</param>
        /// <returns>1: OK, 2: Excepción, 3: Ya existe</returns>
        public int RecordCreation(RoleDTO dto)
        {
            RoleDTOMapper mapper = new RoleDTOMapper();
            RoleDbModel dbModel = mapper.MapperT2T1(dto);
            return model.RecordCreation(dbModel);
        }

        public int RecordUpdate(RoleDTO dto)
        {
            RoleDTOMapper mapper = new RoleDTOMapper();
            RoleDbModel dbModel = mapper.MapperT2T1(dto);
            return model.RecordUpdate(dbModel);
        }

        public int RecordRemove(RoleDTO dto)
        {
            RoleDTOMapper mapper = new RoleDTOMapper();
            RoleDbModel dbModel = mapper.MapperT2T1(dto);
            return model.RecordRemove(dbModel);
        }

        public IEnumerable<RoleDTO> RecordList(string filter)
        {
            var list = model.RecordList(filter);
            RoleDTOMapper mapper = new RoleDTOMapper();
            return mapper.MapperT1T2(list);
        }

        public RoleDTO RecordSearch(int id)
        {
            var record = model.RecordSearch(id);
            if (record == null)
            {
                return null;
            }
            RoleDTOMapper mapper = new RoleDTOMapper();
            return mapper.MapperT1T2(record);
        }

        public RoleDTO RecordSearchByUser(int id)
        {
            var record = model.RecordSearchByUser(id);
            if (record == null)
            {
                return null;
            }
            RoleDTOMapper mapper = new RoleDTOMapper();
            return mapper.MapperT1T2(record);
        }
    }
}
