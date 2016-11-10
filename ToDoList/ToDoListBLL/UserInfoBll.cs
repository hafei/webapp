using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;

namespace ToDoListBLL
{
    public class UserInfoBll
    {
        DemoEntities dbContent = new DemoEntities();
        public UserInfo GetUserInfo(int id)
        {
            return dbContent.UserInfo.Where(t => t.Id == id).FirstOrDefault();
        }
        public List<UserInfo> GetUserInfo()
        {
            return dbContent.UserInfo.ToList();
        }

        public UserInfo Add(UserInfo model)
        {
            var userInfo = dbContent.UserInfo.Add(model);
            dbContent.SaveChanges();
            return userInfo;
        }
    }
}
