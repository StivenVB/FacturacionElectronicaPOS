using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FEPOSController.DTO.SecurityModule;
using FEPOSModel.DbModel.SecurityModule;

namespace FEPOSController.Mapper.SecurityModule
{
    public class UserDTOMapper : GeneralMapper<UserDbModel, UserDTO>
    {
        public override UserDTO MapperT1T2(UserDbModel input)
        {
            RoleDTOMapper roleMapper = new RoleDTOMapper();
            return new UserDTO()
            {
                Id = input.Id,
                Name = input.Name,
                Lastname = input.Lastname,
                Cellphone = input.Cellphone,
                Email = input.Email,
                Document = input.Document,
                City = input.City,
                Password = input.Password,
                UserSessionId = input.UserSessionId,
                CurrentDate = input.CurrentDate,
                Removed = input.Removed,
                Roles = roleMapper.MapperT1T2(input.Roles),
                Token = input.Token
            };
        }

        public override IEnumerable<UserDTO> MapperT1T2(IEnumerable<UserDbModel> input)
        {
            foreach (var item in input)
            {
                yield return MapperT1T2(item);
            }
        }

        public override UserDbModel MapperT2T1(UserDTO input)
        {
            RoleDTOMapper roleMapper = new RoleDTOMapper();
            return new UserDbModel()
            {
                Id = input.Id,
                Name = input.Name,
                Lastname = input.Lastname,
                Cellphone = input.Cellphone,
                Email = input.Email,
                Document = input.Document,
                City = input.City,
                Password = input.Password,
                UserSessionId = input.UserSessionId,
                CurrentDate = input.CurrentDate,
                Removed = input.Removed,
                Roles = roleMapper.MapperT2T1(input.Roles),
                Token = input.Token
            };
        }

        public override IEnumerable<UserDbModel> MapperT2T1(IEnumerable<UserDTO> input)
        {
            foreach (var item in input)
            {
                yield return MapperT2T1(item);
            }
        }
    }
}
