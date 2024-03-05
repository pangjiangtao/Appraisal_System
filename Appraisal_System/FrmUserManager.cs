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
    public delegate void DelBindDgv();//自己声明一个类似string/int关键字(DElBindDgv)
    public partial class FrmUserManager : Form
    {
        DelBindDgv delBindDgv;//用关键字声明一个委托变量
        public FrmUserManager()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void FrmUserManager_Load(object sender, EventArgs e)
        {
            BindCBx();
            BindDgv();
           delBindDgv= BindDgv;
        }

        private void BindDgv()
        {
            string userName = txtUserName.Text.Trim();
            int baseTypeId = (int)cbxBase.SelectedValue;
            bool isStop = chkIsStop.Checked;
            dgvUserAppraisal.AutoGenerateColumns = false;
            List<UserAppraisalBases> userAppraisalBases = UserAppraisalBases.GetListJoinAppraisal();
            if (baseTypeId == 0)
            {
                dgvUserAppraisal.DataSource = userAppraisalBases.FindAll(m => m.UserName.Contains(userName)
            && m.IsDel == isStop);

            }
            else
            {
                dgvUserAppraisal.DataSource = userAppraisalBases.FindAll(m => m.UserName.Contains(userName)
                && m.BaseTypeId == baseTypeId && m.IsDel == isStop);
            }
        }

        private void BindCBx()
        {
            List<AppraisalBases> appraisalBases = new List<AppraisalBases>();

            //身份筛选？
            //方法一：
            /* appraisalBases.Add(new AppraisalBases
             {
                 Id=0,
                 BaseType="-查询所有-",
                 AppraisalBase=0,
                 IsDel= false
             });
             IEnumerable<AppraisalBases> appraisalBases1 = AppraisalBases.ListAll();*/

            appraisalBases.AddRange(AppraisalBases.ListAll());
            //方法二：
            appraisalBases.Insert(0, new AppraisalBases
            {
                Id = 0,
                BaseType = "-查询所有-",
                AppraisalBase = 0,
                IsDel = false
            });
            cbxBase.DataSource = appraisalBases;
            cbxBase.DisplayMember = "BaseType";
            cbxBase.ValueMember = "Id";

            /*  cbxBase.Text = "-查询所有-";
              cbxBase.Items.Add("-查询所有-");
              foreach (var appraisalBase in appraisalBases)
              {
                  cbxBase.Items.Add(appraisalBase.BaseType);
              }*/
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            BindDgv();
        }
        private void dgvUserAppraisal_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                tsmAdd.Visible = true;
                tsmEdit.Visible = false;
                tsmStart.Visible = false;
                tsmStop.Visible = false;
            }
        }

        private void dgvUserAppraisal_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
               
                if(e.RowIndex > -1)
                {
                    dgvUserAppraisal.Rows[e.RowIndex].Selected = true;
                    tsmAdd.Visible = true;
                    tsmEdit.Visible = true;
                   bool isDel =  (bool)dgvUserAppraisal.SelectedRows[0].Cells["IsDel"].Value;
                    if (isDel)
                    {
                        tsmStart.Visible = true;
                    }
                    else
                    {
                        tsmStop.Visible = true;
                    }
                    
                   
                }
            }
        }
        private void tsmAdd_Click(object sender, EventArgs e)
        {
            FrmSetUser frmSetUser = new FrmSetUser(delBindDgv);
            frmSetUser.ShowDialog();
            BindDgv();
        }
        private void tsmEdit_Click(object sender, EventArgs e)
        {
            int id =(int)dgvUserAppraisal.SelectedRows[0].Cells["Id"].Value;
            FrmSetUser frmSetUser = new FrmSetUser(delBindDgv,id);
            frmSetUser.ShowDialog();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dgvUserAppraisal_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        
    }
}
