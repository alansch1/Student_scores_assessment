using System;
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
    public partial class AddScore : Form
    {
        private int addScore;
        private List<int> scoreList;

        public AddScore()
        {
            InitializeComponent();
            addScore4Txt.Focus();
        }

        public AddScore(List<int> inList)
        {
            scoreList = inList;
            InitializeComponent();
            addScore4Txt.Focus();
        }

        private void cancelScore4Btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void addScore4Btn_Click(object sender, EventArgs e)
        {
            try
            {
                addScore = Convert.ToInt32(addScore4Txt.Text);
                if (addScore >= 0 && addScore <= 100)
                {
                    scoreList.Add(addScore);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Please enter a number between 0 and 100.", "Try Again!");
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("This is not a Valid Number, Enter a Valid Number!", "Try Again!");
            }
        }

    }
}

