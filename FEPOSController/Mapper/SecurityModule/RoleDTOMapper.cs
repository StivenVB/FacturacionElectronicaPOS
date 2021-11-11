using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FEPOSController.DTO.SecurityModule;
using FEPOSModel.DbModel.SecurityModule;

namespace FEPOSController.Mapper.SecurityModule
{
    public class RoleDTOMapper : GeneralMapper<RoleDbModel, RoleDTO>
    {
        public override RoleDTO MapperT1T2(RoleDbModel input)
        {
            return new RoleDTO()
            {
                Id = input.Id,
                Name = input.Name,
                Description = input.Description,
                Removed = input.Removed
            };
        }

        public override IEnumerable<RoleDTO> MapperT1T2(IEnumerable<RoleDbModel> input)
        {
            foreach (var item in input)
            {
                yield return MapperT1T2(item);
            }
        }

        public override RoleDbModel MapperT2T1(RoleDTO input)
        {
            return new RoleDbModel()
            {
                Id = input.Id,
                Name = input.Name,
                Description = input.Description,
                Removed = input.Removed
            };
        }

        public override IEnumerable<RoleDbModel> MapperT2T1(IEnumerable<RoleDTO> input)
        {
            foreach (var item in input)
            {
                yield return MapperT2T1(item);
            }
        }
    }
}
