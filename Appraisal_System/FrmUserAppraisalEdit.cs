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
    public partial class FrmUserAppraisalEdit : Form
    {
        private int _userId;
        private string _year;
        public FrmUserAppraisalEdit()
        {
            InitializeComponent();
        }
        public FrmUserAppraisalEdit(int userId,string year):this()
        {

            _userId = userId;
            _year = year;
        }

        private void FrmUserAppraisalEdit_Load(object sender, EventArgs e)
        {
            CreateContorls();
        }

        private void CreateContorls()
        {
            List<AppraisalCoefficients> appraisalCoefficients = AppraisalCoefficients.ListAll();
            foreach (var ac in appraisalCoefficients)
            {
                //Panel panel = new Panel();
                Label label = new Label
                {
                    Text = ac.AppraisalType,
                    Width = 60, 
                    Location = new Point(0, 4),

                };
                TextBox textBox = new TextBox
                {
                    Location = new Point(66, 0),
                    Width = 120,
                    Height = 26
                };
                flp.Controls.Add(label);
                flp.Controls.Add(textBox);
                //flp.Controls.Add(panel);
            }
        }
    }
}
