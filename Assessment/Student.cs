using System;
using System.Collections.Generic;

namespace Assessment
{
	public class Student
	{
		private String Name;                                      // ------------- Variables ------------- //
		private List<int> Scores;

		public Student()                                         // ------------- Default Constructor ------------- //
		{
			Name = null;
			Scores = null;
		}

		public Student(string name, List<int> scores)          // ------------- Overloaded Constructor ------------- //
		{
			this.Name = name;
			this.Scores = scores;
		}

		public String getName()                                 // ------------- Setters and Getters ------------- //
		{
			return this.Name;
		}

		public void setName(string Name)
		{
			this.Name = Name;
		}

		public List<int> getScores()
		{
			return this.Scores;
		}

		public void setScores(List<int> Scores)
		{
			this.Scores = Scores;
		}

		// ------------- Helper Methods ------------- //

		/* Student.ToString */

		public String displayStudent()
		{
			String strStudent = null;
			String strName = getName();
			String strScore = null;

			foreach (int i in Scores)
			{
				strScore += ", " + i;
			}

			strStudent = strName + " - " + strScore.Remove(0, 2);
			return strStudent;
		}

		/* Total Score */

		public int getTotal()
		{
			int total = 0;
			foreach (int i in Scores)
			{
				total += i;
			}
			return total;
		}

		/* Count Score */

		public int getCount()
		{
			return Scores.ToArray().Length;
		}

		/* Average Score */

		public double getAverage()
		{
			int tempTotal;
			int tempCount;
			tempTotal = getTotal();
			tempCount = getCount();
			if (tempCount != 0)
			{
				return (tempTotal / tempCount);
			}
			else
			{
				return 0;
			}
		}
	}
}