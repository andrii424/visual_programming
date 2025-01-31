using System;
using System.Windows.Forms;

namespace Assignment3
{
    public partial class Form1 : Form
    {
        private TextBox textBoxWeight;
        private TextBox textBoxHeight;
        private Button buttonCalculate;
        private Label labelBMIResult;
        private Label labelStatus;

        public Form1()
        {
            InitializeComponent();
            SetupUI();
        }

        private void SetupUI()
        {
            // Create and configure TextBoxes for weight and height
            textBoxWeight = new TextBox { Location = new System.Drawing.Point(20, 30), Width = 100 };
            textBoxHeight = new TextBox { Location = new System.Drawing.Point(20, 80), Width = 100 };

            buttonCalculate = new Button { Text = "Calculate BMI", Location = new System.Drawing.Point(20, 130) };
            buttonCalculate.Click += new EventHandler(buttonCalculate_Click);

            labelBMIResult = new Label { Location = new System.Drawing.Point(20, 170), Width = 250 };
            labelStatus = new Label { Location = new System.Drawing.Point(20, 200), Width = 250 };

            this.Controls.Add(textBoxWeight);
            this.Controls.Add(textBoxHeight);
            this.Controls.Add(buttonCalculate);
            this.Controls.Add(labelBMIResult);
            this.Controls.Add(labelStatus);

            this.ClientSize = new System.Drawing.Size(300, 250);
            this.Text = "BMI Calculator";
        }

        private void buttonCalculate_Click(object sender, EventArgs e)
        {
            CalculateBMI();
        }

        private void CalculateBMI()
        {
            if (IsValidInput(textBoxWeight.Text, textBoxHeight.Text))
            {
                float weight = float.Parse(textBoxWeight.Text);
                float height = float.Parse(textBoxHeight.Text);
                float bmi = CalculateBodyMassIndex(weight, height);
                labelBMIResult.Text = $"BMI: {bmi:F2}";
                labelStatus.Text = GetWeightStatus(bmi);
            }
            else
            {
                labelStatus.Text = "Status: Please enter valid values.";
            }
        }

        private bool IsValidInput(string weightText, string heightText)
        {
            return float.TryParse(weightText, out _) && float.TryParse(heightText, out _);
        }

        private float CalculateBodyMassIndex(float weight, float height)
        {
            return (weight / (height * height)) * 703;
        }

        private string GetWeightStatus(float bmi)
        {
            if (bmi < 18.5)
                return "Status: Underweight";
            else if (bmi >= 18.5 && bmi <= 25)
                return "Status: Normal weight";
            else
                return "Status: Overweight";
        }
    }
}
