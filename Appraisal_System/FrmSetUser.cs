using Appraisal_System.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Appraisal_System
{
    public partial class FrmSetUser : Form
    {
      private DelBindDgv _delBindDgv;//委托
        public FrmSetUser(DelBindDgv delBindDgv)
        {
            InitializeComponent();
            _delBindDgv = delBindDgv;
        }
        private Users _user;
        public FrmSetUser(DelBindDgv delBindDgv,int userId):this(delBindDgv)
        {
           
           _user = Users.ListAll().Find(m => m.Id == userId);
           
        }


        private void FrmSetUser_Load(object sender, EventArgs e)
        {
           
            List<AppraisalBases> appraisalBases = new List<AppraisalBases>();
            appraisalBases=(AppraisalBases.ListAll());
            cbxBase.DataSource = appraisalBases;
            cbxBase.DisplayMember = "BaseType";
            cbxBase.ValueMember = "Id";
            
            if(_user != null) { 
            txtUserName.Text = _user.UserName;
            cbxBase.SelectedValue = _user.BaseTypeId;
            cbxSex.Text = _user.Sex;
            chkIsStop.Checked = _user.IsDel;
            }
        }
        private void btnmSave_Click(object sender, EventArgs e)
        {
            string userName = txtUserName.Text.Trim();
            int baseTypeId = (int)cbxBase.SelectedValue;
            string sex = cbxSex.Text;
            bool isDel = chkIsStop.Checked;
            if (_user == null)
            {
                Users user = new Users
                {
                    UserName = userName,
                    BaseTypeId = baseTypeId,
                    PassWord = "111",
                    IsDel = isDel,
                    Sex = sex
                };
                Users.Insert(user);
                MessageBox.Show("用户添加成功");
            }
            else
            {
                _user.UserName = userName;
                _user.BaseTypeId = baseTypeId;
                _user.IsDel = isDel;
                _user.Sex = sex;
                Users.Update(_user);
                MessageBox.Show("用户修改成功；");
            }
            _delBindDgv();
            //this.Close();
        }
    }
}