using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Model
{
    public class ApplicationResources
    {
        private static Hashtable Items = new Hashtable();
        public static Hashtable GetItems
        {
            get
            {
                return Items;
            }
        }

        public static void AddItem(ResourceInfo resource, int type, int number)
        {
            //添加商品步骤分析：1检查购物车中是否有该类商品已经存在，如果没有就向购物车增加该商品；2如果有该商品，那么就对已经存在的该商品，数量累加1
            ApplicationResourseInfo item = (ApplicationResourseInfo)Items[resource.RIID];
            if (item == null)
            {
                Items.Add(resource.RIID, new ApplicationResourseInfo(type, resource, number));
            }
            else
            {
                item.Number += number;
                Items[resource.RIID] = item;
            }
        }

        public static void RemoveItem(int id)
        {
            //删除商品：1将存在于购物车当中的商品数量减1；2判断该商品数量是否为0，如果为0，我们将该商品彻底从购物车中删除，否则就更新购物车；
            ApplicationResourseInfo item = (ApplicationResourseInfo)Items[id];
            if (item == null)
            {
                return;
            }
            Items.Remove(id);
        }
    }
}
