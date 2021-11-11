﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FEPOSController.DTO.SecurityModule;
using FEPOSController.Mapper.SecurityModule;
using FEPOSController.Services;
using FEPOSModel.DbModel.SecurityModule;
using FEPOSModel.Implementation.SecurityModule;

namespace FEPOSController.Implementation.SecurityModule
{
    public class UserImplController
    {
        private UserImplModel model;
        public UserImplController()
        {
            model = new UserImplModel();
        }

        public int RecordCreation(UserDTO dto)
        {
            UserDTOMapper mapper = new UserDTOMapper();
            UserDbModel dbModel = mapper.MapperT2T1(dto);
            Encrypt enc = new Encrypt();
            var randomPassword = enc.RandomString(10);
            var newPassword = enc.CreateMD5(randomPassword);
            dbModel.Password = newPassword;
            int response = model.RecordCreation(dbModel);
            //verify if the user was save for to send email
            if (response == 1)
            {
                string content = String.Format("Hola {0}," +
                    " <br /> usted ha sido registrado en la plataforma FEPOS " +
                    "Sus credenciales de acceso son: <br /> " +
                    "<ul>" +
                    "<li>Usuario: {1}</li>" +
                    "<li>Contraseña: {2}</li>" +
                    "<li>Rol: " + dto.Roles.Select(x => x.Name).FirstOrDefault() +
                    "</ul>" +
                    "<br /> Cordial saludo, <br />" +
                    "Su equipo de seguridad", dto.Name, dto.Email, randomPassword);
                new Notifications().SendEmail("Registro de Usuario", content, dto.Email, dto.Name + " " + dto.Lastname);
            }
            return response;
        }

        public int RecordUpdate(UserDTO dto)
        {
            UserDTOMapper mapper = new UserDTOMapper();
            UserDbModel dbModel = mapper.MapperT2T1(dto);
            //dbModel.Password = new Encrypt().CreateMD5(dbModel.Password);
            return model.RecordUpdate(dbModel);
        }

        public int RecordRemove(UserDTO dto)
        {
            UserDTOMapper mapper = new UserDTOMapper();
            UserDbModel dbModel = mapper.MapperT2T1(dto);
            return model.RecordRemove(dbModel);
        }

        public IEnumerable<UserDTO> RecordList(string filter)
        {
            var list = model.RecordList(filter);
            UserDTOMapper mapper = new UserDTOMapper();
            return mapper.MapperT1T2(list);
        }

        public UserDTO RecordSearch(int id)
        {
            var record = model.RecordSearch(id);
            if (record == null)
            {
                return null;
            }
            UserDTOMapper mapper = new UserDTOMapper();
            return mapper.MapperT1T2(record);
        }

        public UserDTO Login(UserDTO dto)
        {
            UserDTOMapper mapper = new UserDTOMapper();
            UserDbModel dbModel = mapper.MapperT2T1(dto);
            dbModel.Password = new Encrypt().CreateMD5(dbModel.Password);
            var obj = model.Login(dbModel);
            return mapper.MapperT1T2(obj);
        }

        public int PasswordReset(string email)
        {
            Encrypt enc = new Encrypt();
            var randomPassword = enc.RandomString(10);
            var newPassword = enc.CreateMD5(randomPassword);
            var response = model.PasswordReset(email, newPassword);
            if (response == 1)
            {
                new Notifications().SendEmail("Password Reset", "Content...", email, "FEPOS.com");
            }
            return response;
        }

        public int ChangePassword(string currentPassword, string newPassword, int userId)
        {
            string email = string.Empty;
            var response = model.ChangePassword(currentPassword, newPassword, userId, out email);
            if (response == 1)
            {
                new Notifications().SendEmail("Password Change", "Content...", email, "FEPOS.com");
            }
            return response;
        }
    }
}
