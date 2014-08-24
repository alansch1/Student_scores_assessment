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
    public partial class UpdatePage : Form
    {
        private Student tempStudent;
        private List<int> originalList;

        public UpdatePage(Student inStudent)
        {
            tempStudent = inStudent; // Set Student
            originalList = new List<int>(tempStudent.getScores()); // Store the original list
            InitializeComponent();

            // Populate name textbox and score list
            studentNameDisplayLbl.Text = tempStudent.getName();
            foreach (int score in tempStudent.getScores())
            {
                score3List.Items.Add(score);
            }
        }

        private void cancel3Btn_Click(object sender, EventArgs e)
        {
            tempStudent.setScores(originalList);
			this.Close();
        }

        private void addScore3btn_Click(object sender, EventArgs e)
        {
            Form formAddScore = new AddScore(tempStudent.getScores());
            formAddScore.ShowDialog();
        }

        private void updateScoreBtn_Click(object sender, EventArgs e)
        {
            int index = this.score3List.SelectedIndex;
            if (index != -1)
            {
                Form formUpdateScore = new UpdateScore(tempStudent.getScores(), index);
                formUpdateScore.ShowDialog();
            }
        }

        private void ok3Btn_Click(object sender, EventArgs e)
        {
            if (tempStudent.getScores().Count > 0)
            {
                tempStudent.setScores(tempStudent.getScores());
                this.Close();
            }
            else
            {
                MessageBox.Show("No scores have been entered for this student", "Enter score");
            }
        }

        private void clearScore3Btn_Click(object sender, EventArgs e)
        {
            tempStudent.getScores().Clear();
            score3List.Items.Clear();
        }

        private void removeScore3Btn_Click(object sender, EventArgs e)
        {
            int i = this.score3List.SelectedIndex;
            if (i != -1)
            {
                this.score3List.Items.RemoveAt(i);
            }
        }

        private void UpdatePage_Activated(object sender, EventArgs e)
        {
            this.score3List.Items.Clear();
            foreach (int x in tempStudent.getScores())
            {
                this.score3List.Items.Add(x);
            }
        }

		private void UpdatePage_Activated_1(object sender, EventArgs e)
		{
			this.score3List.Items.Clear();				// Clear listbox
			foreach (int x in tempStudent.getScores()) // Rebuild listbox
			{
				this.score3List.Items.Add(x);
			}
		}
    }
}