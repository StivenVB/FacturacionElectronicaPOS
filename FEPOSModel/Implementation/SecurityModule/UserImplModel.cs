using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using FEPOSModel.DbModel.SecurityModule;
using FEPOSModel.Mappers.SecurityModule;
using FEPOSModel.Model;

namespace FEPOSModel.Implementation.SecurityModule
{
    public class UserImplModel
    {
        /// <summary>
        /// Se agrega un nuevo registro a los Users
        /// </summary>
        /// <param name="dbModel">Representa un objeto con la información del rol</param>
        /// <returns>Entero con la respuesta: 1. OK, 2. KO, 3. Ya existe</returns>
        public int RecordCreation(UserDbModel dbModel)
        {
            using (FEPOSDBEntities db = new FEPOSDBEntities())
            {
                try
                {
                    UserModelMapper mapper = new UserModelMapper();
                    SEC_USER record = mapper.MapperT2T1(dbModel);

                    record.CREATE_DATE = dbModel.CurrentDate;
                    record.CREATE_USER_ID = dbModel.UserSessionId;

                    db.SEC_USER.Add(record);
                    db.SaveChanges();
                    return 1;
                }
                catch
                {
                    return 2;
                }
            }
        }

        /// <summary>
        /// Actualización de un registro
        /// </summary>
        /// <param name="dbModel"></param>
        /// <returns></returns>
        public int RecordUpdate(UserDbModel dbModel)
        {
            using (FEPOSDBEntities db = new FEPOSDBEntities())
            {
                try
                {
                    var record = db.SEC_USER.Where(x => x.ID == dbModel.Id).FirstOrDefault();

                    if (record == null)
                    {
                        return 3;
                    }

                    record.NAME = dbModel.Name;
                    record.LASTNAME = dbModel.Lastname;
                    record.CELLPHONE = dbModel.Cellphone;
                    record.EMAIL = dbModel.Email;
                    record.DOCUMENT = dbModel.Document;
                    record.CITY = dbModel.City;
                    record.REMOVED = dbModel.Removed;
                    //record.USER_PASSWORD = dbModel.Password;
                    record.UPDATE_DATE = dbModel.CurrentDate;
                    record.UPDATE_USER_ID = dbModel.UserSessionId;

                    db.SaveChanges();
                    return 1;
                }
                catch
                {
                    return 2;
                }
            }
        }

        public IEnumerable<UserDbModel> RecordList(string filter)
        {
            using (FEPOSDBEntities db = new FEPOSDBEntities())
            {
                var listaLambda = db.SEC_USER.Where(x => !x.REMOVED && x.NAME.ToUpper().Contains(filter));
                UserModelMapper mapper = new UserModelMapper();
                var listaFinal = mapper.MapperT1T2(listaLambda).ToList();
                return listaFinal;
            }
        }

        public UserDbModel RecordSearch(int id)
        {
            using (FEPOSDBEntities db = new FEPOSDBEntities())
            {
                var record = db.SEC_USER.Where(x => !x.REMOVED && x.ID == id).FirstOrDefault();
                if (record != null)
                {
                    UserModelMapper mapper = new UserModelMapper();
                    return mapper.MapperT1T2(record);
                }
                return null;
            }
        }

        public int RecordRemove(UserDbModel dbModel)
        {
            using (FEPOSDBEntities db = new FEPOSDBEntities())
            {
                try
                {
                    var record = db.SEC_USER.Where(x => x.ID == dbModel.Id).FirstOrDefault();

                    if (record == null)
                    {
                        return 3;
                    }

                    record.REMOVED = true;
                    record.REMOVE_DATE = dbModel.CurrentDate;
                    record.REMOVE_USER_ID = dbModel.UserSessionId;

                    db.SaveChanges();
                    return 1;
                }
                catch
                {
                    return 2;
                }
            }
        }

        public int PasswordReset(string email, string newPassword)
        {
            using (FEPOSDBEntities db = new FEPOSDBEntities())
            {
                try
                {
                    var user = db.SEC_USER.Where(x => x.EMAIL == email).FirstOrDefault();
                    if (user == null)
                    {
                        return 3;
                    }

                    user.USER_PASSWORD = newPassword;
                    db.SaveChanges();
                    return 1;
                }
                catch
                {
                    return 2;
                }
            }
        }

        public int ChangePassword(string currentPassword, string newPassword, int userId, out string email)
        {
            email = "";
            using (FEPOSDBEntities db = new FEPOSDBEntities())
            {
                try
                {
                    var user = db.SEC_USER.Where(x => x.ID == userId && x.USER_PASSWORD == currentPassword).FirstOrDefault();
                    if (user == null)
                    {
                        return 3;
                    }

                    user.USER_PASSWORD = newPassword;
                    db.SaveChanges();
                    email = user.EMAIL;
                    return 1;
                }
                catch
                {
                    return 2;
                }
            }
        }

        public UserDbModel Login(UserDbModel dbModel)
        {
            using (FEPOSDBEntities db = new FEPOSDBEntities())
            {
                UserModelMapper mapper = new UserModelMapper();
                SEC_USER login = new SEC_USER();
                try
                {
                    login = (from user in db.SEC_USER
                                 where user.EMAIL.ToUpper().Equals(dbModel.Email.ToUpper()) && user.USER_PASSWORD.Equals(dbModel.Password)
                                 select user).FirstOrDefault();

                    if (login == null)
                    {
                        return null;
                    }

                    var date = dbModel.CurrentDate;
                    SEC_SESSION session = new SEC_SESSION()
                    {
                        USERID = login.ID,
                        LOGIN_DATE = date,
                        TOKEN_STATUS = true,
                        TOKEN = this.GetToken(String.Concat(login.ID, date)),
                        IP_ADDRESS = this.GetIpAddress()
                    };

                    db.SEC_SESSION.Add(session);
                    db.SaveChanges();
                   
                    
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex);
                }
                return mapper.MapperT1T2(login);
            }
        }

        private string GetToken(string key)
        {
            int HashCode = key.GetHashCode();
            return HashCode.ToString();
        }

        private string GetIpAddress()
        {
            string hostName = Dns.GetHostName();
            Console.WriteLine(hostName);
            // Get the IP  
            string myIP = Dns.GetHostEntry(hostName).AddressList[0].ToString();
            return myIP;
        }
    }
}
