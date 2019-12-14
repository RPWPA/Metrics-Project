using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tryingNew_Ideas
{
    public partial class Form1 : Form
    {
        //############################# Global Variables ###############################

        // Create a dictionary of integers, with string keys for AVC values for each language in DDL
        Dictionary<string, int> AVC_table = new Dictionary<string, int>();

        // Create another dictionary of integers, with string keys for GSC
        Dictionary<string, int> GSC_table = new Dictionary<string, int>();

        private Dictionary<string, int>.KeyCollection icoll, icoll_2;   // is a dictionary to 


        string[] TCF_Array = { "Data Communication", "Distributed Data Process",
                               "Preformance Criteria", "Heavly Utilized Hardware",
                               "High Transaction Rates", "Online Data Entery",
                               "Online Updating", "End-user Efficiency",
                               "Complex Computation", "Reusability",
                               "Ease of Installation", "Ease of Operation",
                               "Portability", "Maintaenability"};

        string[,] complexity_table = new string[,]
        {               {"External Interface Files" , "5", "7" , "10" },
                        {"Internal Logical Files"   , "7", "10", "15" },
                        {"External Input"           , "3", "4" , "6"  },
                        {"External Output"          , "4", "5" , "7"  },
                        {"External Inquiry"         , "3", "4" , "6"  }
        };

        int counter = 0;
        int btn2_Counter = 0;
        int Total_UFP = 0;
        int total_DI = 0;
        double total_TCF = 0;
        double FP_total = 0;

        //###############################################################################


        public Form1()
        {
            InitializeComponent();

            // Adding key/value pairs in AVC_table Dictionariy 
            AVC_table.Add("Assembly Language", 320);
            AVC_table.Add("C", 128);
            AVC_table.Add("COBOL/Fortran", 105);
            AVC_table.Add("Pascal", 90);
            AVC_table.Add("Ada", 70);
            AVC_table.Add("C++", 64);
            AVC_table.Add("Visual Basic", 32);
            AVC_table.Add("Object-Oriented Language", 30);
            AVC_table.Add("Smalltalk", 22);
            AVC_table.Add("Code Generators (Power Builder)", 15);
            AVC_table.Add("SQL/Oracle", 12);
            AVC_table.Add("Spreadsheets", 6);
            AVC_table.Add("Graphical Language (icons)", 4);
            //**************************************************//

            // Adding key/value pairs in GSC_table Dictionariy
            GSC_table.Add("No Influence", 0);
            GSC_table.Add("Incidental", 1);
            GSC_table.Add("Moderate", 2);
            GSC_table.Add("Average", 3);
            GSC_table.Add("Significant", 4);
            GSC_table.Add("Essential", 5);

        }


        private void Form1_Load(object sender, EventArgs e)
        {

            panel2.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;

            label1.Text = complexity_table[counter, 0];

            string[] row = new string[complexity_table.GetLength(1)];

            for (int j = 1; j < complexity_table.GetLength(1); j++)
            {
                row[j - 1] = complexity_table[counter, j];
            }

            dataGridView1.Rows.Add(row);
            // MessageBox.Show(rows.GetLength(0).ToString());
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && dataGridView1.CurrentCell.Value.ToString() != null)
            {
                Total_UFP += Int32.Parse(textBox1.Text) * Int32.Parse(dataGridView1.CurrentCell.Value.ToString());

                dataGridView1.Rows.Clear();
                textBox1.Text = "";
                if (counter < complexity_table.GetLength(0) - 1) // add 1 every click on button_1 untill it equals # rows of 2D_array
                {
                    counter++;
                    label1.Text = complexity_table[counter, 0];

                    string[] row = new string[complexity_table.GetLength(1)];
                    for (int j = 1; j < complexity_table.GetLength(1); j++)
                    {
                        row[j - 1] = complexity_table[counter, j];
                    }
                    dataGridView1.Rows.Add(row);
                }
                else
                {
                    dataGridView1.Visible = false;
                    button1.Visible = false;
                    textBox1.Visible = false;

                    //MessageBox.Show("Total UFP = " + Total_UFP.ToString()); 
                    label3.Visible = false;

                    label1.Text = ("Total UFP = " + Total_UFP.ToString());
                    label1.ForeColor = Color.DarkCyan;
                    label1.Font = new Font("", 22, FontStyle.Bold);
                    label1.Location = new Point(224, 10);

                    panel2.Visible = true;
                    button3.Visible = false;

                    label2.Text = TCF_Array[0];

                    icoll = GSC_table.Keys;
                    foreach (string s in icoll)
                    {
                        comboBox1.Items.Add(s);
                    }


                }
            }
            else
            {
                MessageBox.Show("Fill all fields!!!!");

            }

        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1_Click(this, new EventArgs());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            total_DI += GSC_table[comboBox1.Text];

            if (btn2_Counter < TCF_Array.Length - 1)
            {
                label2.Text = TCF_Array[btn2_Counter + 1]; // array start from 1
                btn2_Counter++;
            }
            else
            {
                MessageBox.Show("ended");

                button2.Visible = false;
                label2.Visible = false;
                comboBox1.Visible = false;
                label5.Visible = false;

                label4.Text = "DI = " + total_DI.ToString();

                button3.Visible = true;
                button3.Text = "Calculate TCF";


            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //MessageBox.Show(comboBox1.SelectedText);
            label5.Text = GSC_table[comboBox1.Text].ToString();

        }

        private void comboBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button2_Click(this, new EventArgs());
            }
        }


        private void button3_Click(object sender, EventArgs e)
        {
            total_TCF = 0.65 + (0.01 * total_DI);

            label5.ForeColor = Color.DarkCyan;
            label5.Font = new Font("", 22, FontStyle.Bold);
            label5.Text = ("Total TCF = " + total_TCF.ToString());
            label5.Visible = true;
            label5.Location = new Point(224, 10);

            button3.Visible = false;
            label4.Visible = false;
            panel3.Visible = true;
            label8.Visible = false;

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            label6.Visible = true;
            label6.Text = AVC_table[comboBox2.Text].ToString();

        }

        private void button6_Click(object sender, EventArgs e)
        {
            label10.Visible = false;
            comboBox2.Visible = false;
            button6.Visible = false;

            double LOC_total = FP_total * AVC_table[comboBox2.Text]; 
            label6.ForeColor = Color.DarkCyan;
            label6.Font = new Font("", 22, FontStyle.Bold);
            label6.Text = ("LOC = " + LOC_total.ToString());
            label6.Visible = true;
            label6.Location = new Point(224, 10);
        }

        private void comboBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button6_Click(this, new EventArgs());
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FP_total = (Total_UFP * total_TCF);

            label8.ForeColor = Color.DarkCyan;
            label8.Font = new Font("", 22, FontStyle.Bold);
            label8.Text = ("FP = UFP * TCF = " + (FP_total).ToString());
            label8.Visible = true;
            label8.Location = new Point(150, 10);

            button4.Visible = false;
            label7.Visible = false;

            panel4.Visible = true;
            label6.Visible = false;

            icoll_2 = AVC_table.Keys;
            foreach (string s in icoll_2)
            {
                comboBox2.Items.Add(s);
            }

        }
    }

}
