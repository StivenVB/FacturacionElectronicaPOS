using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FEPOSModel.DbModel.SecurityModule;
using FEPOSModel.Model;

namespace FEPOSModel.Mappers.SecurityModule
{
    public class UserModelMapper : GeneralMapper<SEC_USER, UserDbModel>
    {
        public override UserDbModel MapperT1T2(SEC_USER input)
        {
            var roles = input.SEC_USER_ROLE.Select(x => x.SEC_ROLE).ToList();
            RoleModelMapper roleMapper = new RoleModelMapper();
            return new UserDbModel()
            {
                Id = input.ID,
                Name = input.NAME,
                Lastname = input.LASTNAME,
                Cellphone = input.CELLPHONE,
                Document = input.DOCUMENT,
                City = input.CITY,
                Email = input.EMAIL,
                Password = input.USER_PASSWORD,
                Removed = input.REMOVED,
                Roles = roleMapper.MapperT1T2(roles)
            };
        }

        public override IEnumerable<UserDbModel> MapperT1T2(IEnumerable<SEC_USER> input)
        {
            foreach (var item in input)
            {
                yield return MapperT1T2(item);
            }
        }

        public override SEC_USER MapperT2T1(UserDbModel input)
        {
            List<SEC_USER_ROLE> rolUsuario = new List<SEC_USER_ROLE>();
            foreach (RoleDbModel model in input.Roles)
            {
                rolUsuario.Add(new SEC_USER_ROLE() { USERID = input.Id, ROLEID = model.Id });
            }
            return new SEC_USER()
            {
                ID = input.Id,
                NAME = input.Name,
                LASTNAME = input.Lastname,
                CELLPHONE = input.Cellphone,
                DOCUMENT = input.Document,
                CITY = input.City,
                EMAIL = input.Email,
                USER_PASSWORD = input.Password,
                REMOVED = input.Removed,
                SEC_USER_ROLE = rolUsuario
            };
        }

        public override IEnumerable<SEC_USER> MapperT2T1(IEnumerable<UserDbModel> input)
        {
            foreach (var item in input)
            {
                yield return MapperT2T1(item);
            }
        }
    }
}
