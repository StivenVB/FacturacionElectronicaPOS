using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FEPOSModel.DbModel.SecurityModule;
using FEPOSModel.Mappers.SecurityModule;
using FEPOSModel.Model;

namespace FEPOSModel.Implementation.SecurityModule
{
    public class RoleImplModel
    {
        /// <summary>
        /// Se agrega un nuevo registro a los roles
        /// </summary>
        /// <param name="dbModel">Representa un objeto con la información del rol</param>
        /// <returns>Entero con la respuesta: 1. OK, 2. KO, 3. Ya existe</returns>
        public int RecordCreation(RoleDbModel dbModel)
        {
            using (FEPOSDBEntities db = new FEPOSDBEntities())
            {
                try
                {
                    //Verifica si existe un rol con el nombre que se quiere crear el nuevo
                    if (db.SEC_ROLE.Where(x => x.NAME.ToUpper().Equals(dbModel.Name.ToUpper())).Count() > 0)
                    {
                        return 3;
                    }

                    RoleModelMapper mapper = new RoleModelMapper();
                    SEC_ROLE record = mapper.MapperT2T1(dbModel);

                    db.SEC_ROLE.Add(record);
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
        public int RecordUpdate(RoleDbModel dbModel)
        {
            using (FEPOSDBEntities db = new FEPOSDBEntities())
            {
                try
                {
                    var record = db.SEC_ROLE.Where(x => x.ID == dbModel.Id).FirstOrDefault();

                    if (record == null)
                    {
                        return 3;
                    }

                    record.NAME = dbModel.Name;
                    record.REMOVED = dbModel.Removed;
                    record.DESCRIPTION = dbModel.Description;
                    db.Entry(record).State = EntityState.Modified;
                    db.SaveChanges();
                    return 1;
                }
                catch
                {
                    return 2;
                }
            }
        }

        public IEnumerable<RoleDbModel> RecordList(string filter)
        {
            using (FEPOSDBEntities db = new FEPOSDBEntities())
            {
                var listaLambda = db.SEC_ROLE.Where(x => !x.REMOVED && x.NAME.ToUpper().Contains(filter));
                RoleModelMapper mapper = new RoleModelMapper();
                var listaFinal = mapper.MapperT1T2(listaLambda);
                return listaFinal.ToList();
            }
        }

        public RoleDbModel RecordSearch(int id)
        {
            using (FEPOSDBEntities db = new FEPOSDBEntities())
            {
                var record = db.SEC_ROLE.Where(x => !x.REMOVED && x.ID == id).FirstOrDefault();
                if (record != null)
                {
                    RoleModelMapper mapper = new RoleModelMapper();
                    return mapper.MapperT1T2(record);
                }
                return null;
            }
        }

        public RoleDbModel RecordSearchByUser(int id)
        {
            using (FEPOSDBEntities db = new FEPOSDBEntities())
            {
                var record = db.SEC_USER_ROLE.Where(x => x.USERID == id).FirstOrDefault();
                if (record != null)
                {
                    var role = db.SEC_ROLE.Where(x => !x.REMOVED && x.ID == record.ROLEID).FirstOrDefault();
                    RoleModelMapper mapper = new RoleModelMapper();
                    return mapper.MapperT1T2(role);
                }
                return null;
            }
        }

        public IEnumerable<RoleDbModel> CompleteRecordList(string filter)
        {
            using (FEPOSDBEntities db = new FEPOSDBEntities())
            {
                var listaLambda = db.SEC_ROLE.Where(x => x.NAME.ToUpper().Contains(filter.ToUpper())).ToList();

                var listaLambdaConv = new List<RoleDbModel>();

                foreach (var item in listaLambda)
                {
                    listaLambdaConv.Add(new RoleDbModel()
                    {
                        Id = item.ID,
                        Name = item.NAME,
                        Removed = item.REMOVED
                    });
                }
                return listaLambdaConv;
            }
        }

        public int RecordRemove(RoleDbModel dbModel)
        {
            using (FEPOSDBEntities db = new FEPOSDBEntities())
            {
                try
                {
                    var record = db.SEC_ROLE.Where(x => x.ID == dbModel.Id).FirstOrDefault();

                    if (record == null)
                    {
                        return 3;
                    }

                    record.REMOVED = true;

                    db.SaveChanges();
                    return 1;
                }
                catch
                {
                    return 2;
                }
            }
        }
    }
}
