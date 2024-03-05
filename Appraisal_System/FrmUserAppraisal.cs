using System;
using System.Collections.Generic;
using System.Data;
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
            List<AppraisalCoefficients> appraisalCoefficients = AppraisalCoefficients.ListAll();
            //通过系数表来填充dtUser
            foreach (var item in appraisalCoefficients)
            {
                //添加系数名
                dtUser.Columns.Add(new DataColumn
                {
                    ColumnName = "AppraisalType"+item.Id
                });
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
            //添加考核年度
            dtUser.Columns.Add(new DataColumn
            {
                ColumnName = "AssessmentYear"
            }); 
            //添加实发年终奖
            dtUser.Columns.Add(new DataColumn
            {
                ColumnName = "YearBonus"
            });

            //给dtUser填充数据
            List<UserAppraisalCoefficients> userAppraisalCoefficients = UserAppraisalCoefficients.ListAll();
            for (int i = 0; i < dtUser.Rows.Count; i++)
            {
              var uacFilter =   userAppraisalCoefficients.FindAll(m => m.UserId == (int)dtUser.Rows[i]["Id"] && m.AssessmentYear ==
                Convert.ToInt32(cbxYear.Text));
                //系数计算的数组，用于存放每个考核类型的总系数
                double[] yearBonusArray = new double[uacFilter.Count];
                for (int j = 0; j < uacFilter.Count; j++)
                {
                    //获取AppraisalType对应的dtUser的ColumnName的值
                    //获取考核次数
                    string appraisalTypeKey = "AppraisalType" + uacFilter[j].CoefficientId;
                    double appraisalTypeCountValue = uacFilter[j].Count;
                    //获取考核系数
                    string appraisalCoefficientKey = "AppraisalCoefficient" + uacFilter[j].CoefficientId;
                    double appraisalCoefficientValue = uacFilter[j].AppraisalCoefficient;
                    //获取计算方式
                    string calculationMethodKey = "CalculationMethod" + uacFilter[j].CoefficientId;
                    int calculationMethodKeyValue = (int)uacFilter[j].CalculationMethod;
                    //给dtUser绑定值
                    dtUser.Rows[i][appraisalTypeKey] = appraisalTypeCountValue;
                    dtUser.Rows[i][appraisalCoefficientKey] = appraisalCoefficientValue;
                    dtUser.Rows[i][calculationMethodKey] = calculationMethodKeyValue;

                    //计算考核项系数
                    //"考核系数"* “次数”*“计算方式”
                    yearBonusArray[j] = appraisalCoefficientValue * appraisalTypeCountValue * calculationMethodKeyValue;

                }
                dtUser.Rows[i]["AssessmentYear"] = cbxYear.Text;
                //结算实发年终奖
                double yearBonusAll = 0;
                for (int j = 0; j < yearBonusArray.Length; j++)
                {
                    yearBonusAll += yearBonusArray[j];   
                }
                //计算实发年终奖
                double yearBonus = (1 + yearBonusAll) * Convert.ToDouble(dtUser.Rows[i]["AppraisalBase"]);
                //由于很有可能这个人迟到太多，钱被扣成了负数，如果是负数则为0
                dtUser.Rows[i]["YearBonus"] = yearBonus < 0 ? 0 : yearBonus;
            }
            dgvUserAppraisal.AutoGenerateColumns = false;
            dgvUserAppraisal.DataSource = dtUser;
        }

        private void SetCol()
        {
            List<AppraisalCoefficients> appraisalCoefficients = AppraisalCoefficients.ListAll();
            List<DataGridViewTextBoxColumn> dataGridViewTextBoxColumns = new List<DataGridViewTextBoxColumn>();

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
            }
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
                DataPropertyName = "YearBonus",
                ReadOnly = true,
                Width = 166
            });
        }
    }
}
