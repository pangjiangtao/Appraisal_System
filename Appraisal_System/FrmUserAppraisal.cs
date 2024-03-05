using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Appraisal_System.Models;

namespace Appraisal_System
{
    public partial class FrmUserAppraisal : Form
    {
        public FrmUserAppraisal()
        {
            InitializeComponent();
        }
        
        private void FrmUserAppraisal_Load(object sender, EventArgs e)
        {
            SetCol();
            //获取需要扩展的表
            DataTable dtUser = UserAppraisalBases.GetDtJoinAppraisal();
            //获取系数表集合
            List<AppraisalCoefficients> appraisalCoefficients= AppraisalCoefficients.ListAll();
            //通过系数表来填充dtUser
            foreach (var item in appraisalCoefficients)
            {
                //添加系数名   Columns---添加列可用来
                dtUser.Columns.Add(new DataColumn
                {
                    ColumnName = "AppraisalType" + item.Id
                }) ;
                //添加系数值

                dtUser.Columns.Add(new DataColumn
                {
                    ColumnName = "AppraisalCoefficient" + item.Id
                });
                //添加计算方式

                dtUser.Columns.Add(new DataColumn
                {
                    ColumnName = "CalculationMethod" + item.Id
                });
            }

        }

        private void SetCol()
        {
            List<AppraisalCoefficients> appraisalCoefficients = AppraisalCoefficients.ListAll();
            List<DataGridViewTextBoxColumn> dataGridViewTextBoxColumns = new
            List<DataGridViewTextBoxColumn>();

            foreach (var appraisalCoefficient in appraisalCoefficients)
            {
                dataGridViewTextBoxColumns.Add(new DataGridViewTextBoxColumn
                {
                    HeaderText = appraisalCoefficient.AppraisalType,
                    Name = "AppraisalType" + appraisalCoefficient.Id.ToString(),
                    DataPropertyName = "AppraisalType" + appraisalCoefficient.Id.ToString(),
                    ReadOnly = true,
                    Width = 88
                });
                dataGridViewTextBoxColumns.Add(new DataGridViewTextBoxColumn
                {
                    HeaderText = "系数",
                    Name = "AppraisalCoefficient" + appraisalCoefficient.Id.ToString(),
                    DataPropertyName = "AppraisalCoefficient" + appraisalCoefficient.Id.ToString(),
                    ReadOnly = true,
                    Visible = false,
                    Width = 88
                });
                dataGridViewTextBoxColumns.Add(new DataGridViewTextBoxColumn
                {
                    HeaderText = "计算方式",
                    Name = "CalculationMethod" + appraisalCoefficient.Id.ToString(),
                    DataPropertyName = "CalculationMethod" + appraisalCoefficient.Id.ToString(),
                    ReadOnly = true,
                    Visible = false,
                    Width = 88
                });
                dgvUserAppraisal.Columns.AddRange(dataGridViewTextBoxColumns.ToArray());
                dgvUserAppraisal.Columns.Add(new DataGridViewTextBoxColumn
                {
                    HeaderText = "考核年度",
                    Name = "AssessmentYear",
                    DataPropertyName = "AssessmentYear",
                    ReadOnly = true,
                    Width = 166
                });
                dgvUserAppraisal.Columns.Add(new DataGridViewTextBoxColumn
                {
                    HeaderText = "实发年终奖",
                    Name = "YearBonus",
                    DataPropertyName = "AssessmentYear",
                    ReadOnly = true,
                    Width = 166
                });
            }
        }
    }
}
