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
            BindeContorls();
        }

        private void BindeContorls()
        {
            List<UserAppraisals> userAppraisals = UserAppraisals.ListByUserIdAndYear(_userId, _year);
            foreach (var ua in userAppraisals)
            {
                var flCtrs = flp.Controls;
                foreach (Control flCtr in flCtrs)
                {
                    if (flCtr is Panel)
                    {
                        var plCtrs = flCtr.Controls;
                        foreach (var plCtr in plCtrs)
                        {
                            if (plCtr is TextBox)
                            {
                                int acId = Convert.ToInt32(((TextBox)plCtr).Name.Split('_')[1]);
                                ((TextBox)plCtr).Text =
                                    userAppraisals.Find(m => m.CoefficientId == acId).Count.ToString();
                            }
                        }

                    }
                }
            }
        }

        private void CreateContorls()
        {
            List<AppraisalCoefficients> appraisalCoefficients = AppraisalCoefficients.ListAll();
            foreach (var ac in appraisalCoefficients)
            {
                Panel panel = new Panel();
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
                    Height = 26,
                    Name = "txtAppraisalType_" + ac.Id
                };
                panel.Controls.Add(label);
                panel.Controls.Add(textBox);
                flp.Controls.Add(panel);
            }
        }
    }
}
