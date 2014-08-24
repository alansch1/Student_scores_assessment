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
    public partial class UpdateScore : Form
    {
        private int tempIndex;
        private int tempScore;
        private List<int> tempList;

        public UpdateScore(List<int> inList, int inIndex)
        {
            InitializeComponent();
            tempIndex = inIndex;
            tempList = inList;
            tempScore = inList[inIndex];
            updateScore5Txt.Text = tempScore.ToString();
            updateScore5Txt.Focus();

        }

        private void cancelScore5Btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void updateScore5Btn_Click(object sender, EventArgs e)
        {
            try
            {

                tempScore = Convert.ToInt32(updateScore5Txt.Text);


                if (tempScore >= 0 && tempScore <= 100)
                {
                    tempList.RemoveAt(tempIndex); // Remove score at index specified
                    tempList.Insert(tempIndex, tempScore); // Insert new score at index specified
                    this.Close();
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Enter a valid number.", "Error");
            }
        }
    }
}

