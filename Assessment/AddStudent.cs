using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assessment
{
    public partial class AddStudent : Form
    {
        private List<Student> studentList;
        private List<int> newStudentScores = new List<int>();
        private EntryPage mainForm;

        public AddStudent()
        {
            InitializeComponent();
        }
        public AddStudent(List<Student> allStudents)
        {
            studentList = allStudents;
            InitializeComponent();
        }

        private void cancelNewStudentBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }





        private void okNewStudentBtn_Click(object sender, EventArgs e)
        {
            if (newStudentScores.Count > 0)
            {
                Student newStudent = new Student(name2Txt.Text, newStudentScores);
                studentList.Add(newStudent);
                this.Close();
            }
            else
            {
                MessageBox.Show("This Student Has No Scores - Please Enter Scores", "Enter score");
            }
        }

        private void addScoreBtn_Click(object sender, EventArgs e)
        {
            try
            {


                int value = Convert.ToInt32(score2Txt.Text);

                if (validScore(value))
                {
                    newStudentScores.Add(value);
                    scoreDisplayLbl.Text = printList(newStudentScores);
                    score2Txt.Clear();
                    score2Txt.Focus();
                }
                else
                {
                    MessageBox.Show("The Number You Have Entered Is Not Between 0 and 100, Please Try Again.", "Invalid score");
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Your Number Is Not Valid", "Invalid Entry");
            }
        }


        private void clearScoreBtn_Click(object sender, EventArgs e)
        {
            newStudentScores.Clear();
            scoreDisplayLbl.Text = null;
        }
        private bool validScore(int s)
        {
            return (s >= 0 && s <= 100);
        }

        public String printList(List<int> list)
        {
            String strList = null;
            foreach (int s in list)
            {
                strList += s + ", ";
            }
            strList = strList.Remove(strList.Length - 2);
            return strList;
        }

    }

}
