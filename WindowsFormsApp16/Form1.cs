using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp16
{
    public partial class Form1 : Form
    {
        private TextBox displayTextBox;

        public Form1()
        {
            InitializeComponent();
            InitializeCalculator();
        }

        private void InitializeCalculator()
        {
            this.Text = "Калькулятор";
            this.Size = new System.Drawing.Size(300, 400);

            displayTextBox = new TextBox
            {
                Name = "displayTextBox",
                TextAlign = HorizontalAlignment.Right,
                Location = new System.Drawing.Point(10, 10),
                Size = new System.Drawing.Size(260, 40),
                Font = new System.Drawing.Font("Arial", 18),
                ReadOnly = true
            };
            this.Controls.Add(displayTextBox);

            string[] buttonLabels = {
                "7", "8", "9", "/",
                "4", "5", "6", "*",
                "1", "2", "3", "-",
                "0", ".", "=", "+"
            };

            Button[] btn = new Button[buttonLabels.Length];
            int row = 0;
            int col = 0;

            for (int i = 0; i < buttonLabels.Length; i++)
            {
                btn[i] = new Button
                {
                    Text = buttonLabels[i],
                    Name = "btn" + buttonLabels[i],
                    Location = new System.Drawing.Point(10 + col * 65, 70 + row * 50),
                    Size = new System.Drawing.Size(50, 40),
                    Font = new System.Drawing.Font("Arial", 14)
                };
                btn[i].Click += new EventHandler(Button_Click);
                this.Controls.Add(btn[i]);

                col++;
                if (col > 3)
                {
                    col = 0;
                    row++;
                }
            }
            Button clearButton = new Button
            {
                Text = "C",
                Name = "btnClear",
                Location = new System.Drawing.Point(10, 270),
                Size = new System.Drawing.Size(50, 40),
                Font = new System.Drawing.Font("Arial", 14)
            };
            clearButton.Click += new EventHandler(ClearButton_Click);
            this.Controls.Add(clearButton);
        }
        private void ClearButton_Click(object sender, EventArgs e)
        {
            displayTextBox.Text = "";
        }

        private void Button_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string buttonText = button.Text;

            if (buttonText == "=")
            {
                try
                {
                    string expression = displayTextBox.Text;
                    var result = new DataTable().Compute(expression, null);
                    displayTextBox.Text = result.ToString();
                }
                catch (Exception)
                {
                    displayTextBox.Text = "Ошибка";
                }
            }
            else if (buttonText == "C")
            {
                displayTextBox.Text = "";
            }
            else
            {
                displayTextBox.Text += buttonText;
            }
        }


    }
}
