using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AdmissionCommittee.Models;

namespace AdmissionCommittee.Forms
{
    public partial class ApplicantsForm : Form
    {
        private readonly StudentModel targetStudent;
        public ApplicantsForm(ApplicantsForm? applicantsForm = null)
        {
            InitializeComponent();
            if(applicantsForm != null)
            {
                targetStudent = new StudentModel
                {
                    //id = applicantsForm.id,
                    //FullName = applicantsForm.Fullname,
                };
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }


        public StudentModel CurrentStudent => targetStudent;
    }
}
