﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FEPOS.Models.SecurityModule;
using FEPOSController.DTO.SecurityModule;

namespace FEPOS.Mapper.SecurityModule
{
    public class UserModelMapper : GeneralMapper<UserDTO, UserModel>
    {
        public override UserModel MapperT1T2(UserDTO input)
        {
            RoleModelMapper roleMapper = new RoleModelMapper();
            return new UserModel()
            {
                Id = input.Id,
                Name = input.Name,
                Lastname = input.Lastname,
                Cellphone = input.Cellphone,
                Document = input.Document,
                City = input.City,
                Email = input.Email,
                Password = input.Password,
                Removed = input.Removed,
                Roles = roleMapper.MapperT1T2(input.Roles),
                Token = input.Token
            };
        }

        public override IEnumerable<UserModel> MapperT1T2(IEnumerable<UserDTO> input)
        {
            foreach (var item in input)
            {
                yield return MapperT1T2(item);
            }
        }

        public override UserDTO MapperT2T1(UserModel input)
        {
            RoleModelMapper roleMapper = new RoleModelMapper();
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
                Roles = roleMapper.MapperT2T1(input.Roles),
                Token = input.Token
            };
        }

        public override IEnumerable<UserDTO> MapperT2T1(IEnumerable<UserModel> input)
        {
            foreach (var item in input)
            {
                yield return MapperT2T1(item);
            }
        }
    }
}