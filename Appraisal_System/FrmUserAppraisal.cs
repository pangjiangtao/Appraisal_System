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
            List<AppraisalCoefficients> appraisalCoefficients = AppraisalCoefficients.ListAll();
            List<DataGridViewTextBoxColumn> dataGridViewTextBoxColumns = new List<DataGridViewTextBoxColumn>();

            foreach (var appraisalCoefficient in appraisalCoefficients)
            {
                dataGridViewTextBoxColumns.Add(new DataGridViewTextBoxColumn
                {
                    HeaderText = "AppraisalType"+ appraisalCoefficient.Id.ToString(),
                    Name =appraisalCoefficient.AppraisalType,
                    DataPropertyName = "AppraisalType" + appraisalCoefficient.Id.ToString(),
                    ReadOnly =true,
                    Width = 88
                });
                dataGridViewTextBoxColumns.Add(new DataGridViewTextBoxColumn
                {
                    HeaderText = "系数",
                    Name = "AppraisalCoefficient"+ appraisalCoefficient.Id.ToString(),
                    DataPropertyName = "AppraisalCoefficient" + appraisalCoefficient.Id.ToString(),
                    ReadOnly =true,
                    Width = 88
                });
                dataGridViewTextBoxColumns.Add(new DataGridViewTextBoxColumn
                {
                    HeaderText = "计算方式",
                    Name = "CalculationMethod" +appraisalCoefficient.Id.ToString(),
                    DataPropertyName = "CalculationMethod" + appraisalCoefficient.Id.ToString(),
                    ReadOnly = true,
                    Width = 88
                }) ;
            }
            dgvUserAppraisal.Columns.AddRange(dataGridViewTextBoxColumns.ToArray());
        }
    }
}
