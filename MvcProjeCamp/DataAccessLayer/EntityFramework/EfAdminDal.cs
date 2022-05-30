using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Concrete.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfAdminDal : GenericRepository<Admin>, IAdminDal
    {
        public void AdminStatus(int id)
        {
            Admin admin;
            Context c = new Context();
           
            admin = c.Admins.Find(id);

            if (admin.AdminStatus)
            {
                admin.AdminStatus = false;
            }
            else
            {
                admin.AdminStatus |= true;
            }

            c.SaveChanges();
        }
    }
}
