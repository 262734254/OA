using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using IDAL.Resource;
using OAFactory;
using IDAL.Car;
using Model;


namespace BLL.Resource
{
    public class BorrowApplicationManager
    {
        private static AbstractDALFactory factory = AbstractDALFactory.ChooseFactory();

        private static IBorrowApplicationService borrowService = factory.CreateBorrowApplicationService();

        public static int Add(BorrowApplication item)
        {
            return borrowService.Add(item);
        }

        public static IList<BorrowApplication> SearchBorrowApplication(int baid, int type, string time,int uid)
        {
            UserInfo user = new UserInfo();
            user.UID = uid;
            BorrowApplication item = new BorrowApplication(baid, user, time, type, "", "", "");
            return borrowService.GetAllBorrowApplication(item);
        }

        public static int DeleteById(int id)
        {
            ApplicationResourceManager.Delete(id, 1,0);
            return borrowService.Delete(id);
        }

        public static BorrowApplication Get(int id)
        {
            return (BorrowApplication)borrowService.Get(id);
        }

        public static int Update(BorrowApplication item)
        {
            return borrowService.Update(item);
        }
    }
}
