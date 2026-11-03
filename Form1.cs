using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Registration_student_Fee
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. Validation - Hubinta in Magaca iyo ID-ga la geliyay
                if (string.IsNullOrWhiteSpace(txtStudentName.Text))
                {
                    MessageBox.Show("Fadlan geli magaca ardayga!", "Qalad", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtStudentName.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtStudentId.Text))
                {
                    MessageBox.Show("Fadlan geli ID-ga ardayga!", "Qalad", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtStudentId.Focus();
                    return;
                }

                // 2. Hubinta Tirada Courses-ka (1 ilaa 8)
                if (!int.TryParse(txtCourses.Text, out int courses) || courses < 1 || courses > 8)
                {
                    MessageBox.Show("Tirada maaddooyinka (Courses) waa inay u dhaxaysaa 1 ilaa 8!", "Qalad", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCourses.Focus();
                    return;
                }

                // 3. Hubinta Study Level-ka (1 ilaa 4)
                if (!int.TryParse(txtStudyLevel.Text, out int studyLevel) || studyLevel < 1 || studyLevel > 4)
                {
                    MessageBox.Show("Sannadka waxbarashada (Study Level) waa inuu ahaadaa 1 ilaa 4!", "Qalad", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtStudyLevel.Focus();
                    return;
                }

                // 4. Transport Fee
                if (!decimal.TryParse(txtTransportFee.Text, out decimal transportFee))
                {
                    transportFee = 0m;
                }

                // 5. Fee per course marka loo eego Level-ka
                decimal feePerCourse = 0m;
                switch (studyLevel)
                {
                    case 1: feePerCourse = 40m; break;
                    case 2: feePerCourse = 45m; break;
                    case 3: feePerCourse = 50m; break;
                    case 4: feePerCourse = 55m; break;
                }

                // Basic Tuition Fee
                decimal basicTuitionFee = feePerCourse * courses;

                // 6. Discount Calculation (10% discount haddii courses >= 6)
                decimal discountPercentage = 0m;
                if (courses >= 6)
                {
                    discountPercentage = 0.10m;
                }

                decimal discountAmount = basicTuitionFee * discountPercentage;
                decimal finalTuitionFee = basicTuitionFee - discountAmount;

                // --- XISAABTA FINAL AMOUNT ---
                decimal finalAmount = finalTuitionFee + transportFee;

                // 7. Natiijada oo ku soo baxaysa MessageBox Pop-up
                string resultMessage = "=== NATIIJADA DIWANGELINTA ARDAYGA ===\n\n" +
                                       "Student Name: " + txtStudentName.Text + "\n" +
                                       "Student ID: " + txtStudentId.Text + "\n" +
                                       "Number of Courses: " + courses + "\n" +
                                       "Study Level: Year " + studyLevel + "\n" +
                                       "-----------------------------------------\n" +
                                       "Basic Tuition Fee: $" + basicTuitionFee.ToString("0.00") + "\n" +
                                       "Discount (" + (discountPercentage * 100) + "%): -$" + discountAmount.ToString("0.00") + "\n" +
                                       "Transport Fee: +$" + transportFee.ToString("0.00") + "\n" +
                                       "-----------------------------------------\n" +
                                       "FINAL AMOUNT: $" + finalAmount.ToString("0.00");

                MessageBox.Show(resultMessage, "Natiijada Xisaabta", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cillad ayaa dhacday: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtStudentName.Clear();
            txtStudentId.Clear();
            txtCourses.Clear();
            txtStudyLevel.Clear();
            txtTransportFee.Clear();
            txtStudentName.Focus();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnExit_Click_1(object sender, EventArgs e)
        {

        }
    }
}