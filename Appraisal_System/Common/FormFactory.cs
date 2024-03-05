using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Appraisal_System.Common
{
    internal class FormFactory
    {
       /* private static FrmUserManager frmUserManager;
        private static FrmBaseManager frmBaseManager;
        private static FrmNone frmNone;*/
        private static Form form;
        private static List<Form> forms = new List<Form>();
        /* public static Form CreateForm(int index)
         {
             HideFormAll();

             switch (index)
             {
                 case 0:

                     if (frmUserManager == null)
                     {
                         frmUserManager = new FrmUserManager();
                         forms.Add(frmUserManager);

                     }
                     form = frmUserManager;

                     break;

                 case 1:
                     if (frmBaseManager == null)
                     {
                         frmBaseManager = new FrmBaseManager();
                         forms.Add(frmBaseManager);

                     }
                     form = frmBaseManager;

                     break;
                 default:
                     if (frmNone == null)
                     {
                         frmNone = new FrmNone();
                         forms.Add(frmNone);

                     }
                     form = frmNone;
                     break;

             }
             return form;
         }*/

        private static List<Type> types;
        static FormFactory()
        {
            Assembly ass = Assembly.LoadFrom("Appraisal_System.exe");
            types = ass.GetTypes().ToList();


        }
        public static Form CreateForm(string formName)
        {
           
            HideFormAll();
            formName = formName == null ? "FrmNone" : formName;
            //Type[] types = ass.GetTypes().Where(m=>m.BaseType == typeof(Form)).ToArray();
            Form form = forms.Find(m => m.Name == formName);
            if(form == null)
            {
                Type type = types.Find(m => m.Name == formName);
                form = (Form)Activator.CreateInstance(type);
                forms.Add(form);

            }
            return form;
        }
        public static void HideFormAll()
        {
            foreach (var form in forms)
            {
                form.Hide();
            }
           /* frmUserManager?.Hide();
            frmBaseManager?.Hide();*/
        }
    }
}
