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
    public partial class EntryPage : Form
    {
		/* Variables */
		private List<Student> allStudents;
        private Student tempStudent;

		/* Default Constructor */
        public EntryPage()
        {
            InitializeComponent();
            allStudents = new List<Student>();
            allStudents = testStudentList();
        }

		/* Exit Button */
        private void exitBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

		/* Add new Student */
        private void addNewBtn_Click(object sender, EventArgs e)
        {
            Form newStudentForm = new AddStudent(allStudents);
            newStudentForm.ShowDialog();
        }

		/* Activate Page */
        private void EntryPage_Activated(object sender, EventArgs e)
        {
            rebuildList();
        }

		/* Update Button */
        private void updateBtn_Click(object sender, EventArgs e)
        {
            int index = this.listBox1.SelectedIndex;
            if (index != -1)
            {
                tempStudent = allStudents[index] as Student;

                // Pass student to dialog box
                Form updateScoresForm = new UpdatePage(tempStudent);
                updateScoresForm.ShowDialog();
            }
        }

		/* Change Selection Index */
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex >= 0)
            {
                int i = this.listBox1.SelectedIndex;
                if (i >= 0)
                {
                    tempStudent = allStudents[i] as Student;

                    this.scoreTotalLbl.Text = tempStudent.getTotal().ToString();
                    this.scoreCountLbl.Text = tempStudent.getCount().ToString();
                    this.scoreAverageLbl.Text = tempStudent.getAverage().ToString();
                }
            }
            else
            {
                tempStudent = null;
                this.scoreTotalLbl.Text = "";
                this.scoreCountLbl.Text = "";
                this.scoreAverageLbl.Text = "";
            }
        }

		/* Delete Button */
        private void deleteBtn_Click(object sender, EventArgs e)
        {
            if (this.listBox1.SelectedIndex >= 0)
            {
                int i = this.listBox1.SelectedIndex;
                this.listBox1.Items.RemoveAt(i);
                allStudents.RemoveAt(i);
                rebuildList();
            }
        }

		/* ---- Helper Methods ---- */

		/* Rebuild List */
        private void rebuildList()
        {
            this.listBox1.Items.Clear(); // Clear listbox
            foreach (Student s in allStudents) // Rebuild listbox
            {
                this.listBox1.Items.Add(s.displayStudent());
            }
            lblStudentCount.Text = "Students: " + listBox1.Items.Count.ToString();
        }

		/* Display Total, Count and Average Scores
		 * Clear text boxes if no selection is made */

	

		/* Test Students */
		private List<Student> testStudentList()
        {
            List<Student> studentList = new List<Student>();

            Student student1 = new Student();
			student1.setName("Will Bob");
            List<int> student1scores = new List<int> { 11, 21, 51 };
			student1.setScores(student1scores);
			studentList.Add(student1);


            Student student2 = new Student();
            student2.setName("Rick James");
            List<int> student2scores = new List<int> { 1, 2, 3 };
            student2.setScores(student2scores);
            studentList.Add(student2);


            Student student3 = new Student();
            student3.setName("Mr Burnes");
            List<int> student3scores = new List<int> { 21, 31, 13 };
            student3.setScores(student3scores);
            studentList.Add(student3);

            return studentList;
        }

		private void listBox1_SelectedIndexChanged_1(object sender, EventArgs e)
		{
			if (listBox1.SelectedIndex >= 0)
			{
				int i = this.listBox1.SelectedIndex;
				if (i >= 0)
				{
					tempStudent = allStudents[i] as Student;

					this.scoreTotalLbl.Text = tempStudent.getTotal().ToString();
					this.scoreCountLbl.Text = tempStudent.getCount().ToString();
					this.scoreAverageLbl.Text = tempStudent.getAverage().ToString();
				}
			}
			else
			{
				tempStudent = null;
				this.scoreTotalLbl.Text = "";
				this.scoreCountLbl.Text = "";
				this.scoreAverageLbl.Text = "";
			}
		}


    }
}
