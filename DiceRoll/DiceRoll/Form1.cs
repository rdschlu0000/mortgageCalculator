using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApplication1
{
    public partial class DiceRoll : Form
    {

        private Random roll = new Random();
        private int dice1;
        private int dice2;
        private int[] sum;
        private int i;
        private string Entry;
        private int count;
        private int count2;
        private int count3;
        private int[] average;
        private string[] averageCalc;
        private int[] resultCount;
        private bool found;
        private int index;
        private int track;
        private int numbercount;

        public DiceRoll()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            // Array to hold the sums of the dice rolls, array used to make file writing easier as it occurs ouside the for loop
            this.sum = new int[100];
            this.average = new int[100];

            // Ensures only one result set is present at a time
            ResultsBox.Items.Clear();

            // Simple iteration from 1 to 100
            for (i = 1; i < 101; i++)
            {

                // dice1 and dice2 are random numbers ranging from 1 and 6
                this.dice1 = roll.Next(1, 7);
                this.dice2 = roll.Next(1, 7);

                // calculates sum of the numbers
                this.sum[this.i - 1] = this.dice1 + this.dice2;
                this.average[this.i - 1] = this.sum[this.i - 1];

                // The if statements are only to properly align the data in the text box... OCD, I know...
                // 1 digit numbers
                if (this.i < 10)
                {

                    ResultsBox.Items.Add("Dice Roll " + this.i + ":  (" + this.dice1 + "," + this.dice2 + ") - Result = " + this.sum[this.i - 1]);

                }

                // 2 digit numbers
                else
                {

                    ResultsBox.Items.Add("Dice Roll " + this.i + ": (" + this.dice1 + "," + this.dice2 + ") - Result = " + this.sum[this.i - 1]);

                }

            }

        }

        // Event handler that saves the data to a text file
        private void button2_Click(object sender, EventArgs e)
        {

            // If the list box has items, save to file
            if (ResultsBox.Items.Count > 0)
            {

                using (StreamWriter outputfile = new StreamWriter("roll.txt"))
                {

                    int i;
                    for (i = 0; i < 100; i++)
                    {
                        // Write array contents to file
                        outputfile.WriteLine(this.sum[i]);
                    }

                    outputfile.Close();

                }

                using (StreamWriter outputfile = new StreamWriter("rollAverage.txt"))
                {

                    int i;
                    for (i = 0; i < 100; i++)
                    {
                        // Write array contents to file
                        outputfile.WriteLine(this.average[i]);
                    }

                    outputfile.Close();

                }

                Success form = new Success();

                form.ShowDialog();

                // Clear the list box after saving
                ResultsBox.Items.Clear();

            }

            // If no items are present, show error dialog
            else
            {

                Error message = new Error();

                message.ShowDialog();

            }
        }

        // Loads the data into the second list box if the roll.txt file is present
        private void button3_Click(object sender, EventArgs e)
        {

            this.count = 1;
            this.count2 = 2;
            this.averageCalc = new string[100];
            this.resultCount = new int[12];

            LoadBox.Items.Clear();
            AvgBox.Items.Clear();

            if (File.Exists("roll.txt"))
            {

                using (StreamReader inputfile = new StreamReader("roll.txt"))
                {

                    while (!inputfile.EndOfStream)
                    {

                        // one digit
                        if (count < 10)
                        {

                            this.Entry = inputfile.ReadLine();
                            LoadBox.Items.Add("Dice Roll " + this.count + ": " + " Result = " + this.Entry);
                            this.count++;

                        }

                        // two digit
                        else
                        {

                            this.Entry = inputfile.ReadLine();
                            LoadBox.Items.Add("Dice Roll " + this.count + ": " + "Result = " + this.Entry);
                            this.count++;

                        }

                    }

                    inputfile.Close();

                }

            }

            if (File.Exists("rollAverage.txt"))
            {

                this.count = 0;
                this.index = 0;
                this.count3 = 1;
                this.numbercount = 0;

                for (i = 1; i < 12; i++)
                {

                    resultCount[i - 1] = i + 1;

                }

                using (StreamReader inputfile = new StreamReader("rollAverage.txt"))
                {

                    while (!inputfile.EndOfStream)
                    {
                            this.Entry = inputfile.ReadLine();
                            this.averageCalc[this.count] = this.Entry;
                            this.count++;

                    }

                    inputfile.Close();

                    

                }

                while (this.index < this.averageCalc.Length)
                {

                    if (this.averageCalc[this.index] == "2")
                    {

                        this.resultCount[0]++;

                    }

                    if (this.averageCalc[this.index] == "3")
                    {

                        this.resultCount[1]++;

                    }

                    if (this.averageCalc[this.index] == "4")
                    {

                        this.resultCount[2]++;

                    }

                    if (this.averageCalc[this.index] == "5")
                    {

                        this.resultCount[3]++;

                    }

                    if (this.averageCalc[this.index] == "6")
                    {

                        this.resultCount[4]++;

                    }

                    if (this.averageCalc[this.index] == "7")
                    {

                        this.resultCount[5]++;

                    }

                    if (this.averageCalc[this.index] == "8")
                    {

                        this.resultCount[6]++;

                    }

                    if (this.averageCalc[this.index] == "9")
                    {

                        this.resultCount[7]++;

                    }

                    if (this.averageCalc[this.index] == "10")
                    {

                        this.resultCount[8]++;

                    }

                    if (this.averageCalc[this.index] == "11")
                    {

                        this.resultCount[9]++;

                    }

                    if (this.averageCalc[this.index] == "12")
                    {

                        this.resultCount[10]++;

                    }



                    this.index++;

                }




                while (this.count2 < 13)
                {
                
                        AvgBox.Items.Add("Dice Result (" + this.count2 + ") Occurances: " + (this.resultCount[this.count2 - 2] - this.count2));
                        this.count2++;

                }

            }

            else
            {

                Error message = new Error();

                message.ShowDialog();

            }
        }
    }
}
