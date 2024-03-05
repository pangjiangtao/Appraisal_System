using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Appraisal_System.Utility
{
    public static class ToModel
    {
        /*泛型：public static TModel DataRowToModel<TModel>(this DataRow dr)
        <>中写的是什么，返回值就写什么            this是一个扩展方法，扩展方法必须在静态类中，并且也必须是一个静态方法               
        */
        public static TModel DataRowToModel<TModel>(this DataRow dr)
        {
/*TYpe是一个类型声明，typeof()能获取()内的类型*/
          Type type = typeof(TModel);
          TModel md = (TModel)Activator.CreateInstance(type);
            //type.GetProperties()获取type中的所有属性
            foreach (var prop in type.GetProperties())
            {
                prop.SetValue(md,dr[prop.Name]);
            }
            return md;
        }
    }
}
