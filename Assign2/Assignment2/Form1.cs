using System;
using System.Windows.Forms;

namespace Assignment2
{
    public partial class Form1 : Form
    {
        private const double ClassAPrice = 15.00;
        private const double ClassBPrice = 12.00;
        private const double ClassCPrice = 9.00;

        private TextBox textBoxClassA;
        private TextBox textBoxClassB;
        private TextBox textBoxClassC;
        private Button buttonCalculate;
        private Button buttonReset;
        private Button buttonExit;
        private Label labelRevenueA;
        private Label labelRevenueB;
        private Label labelRevenueC;
        private Label labelTotalRevenue;

        public Form1()
        {
            InitializeComponent();
            SetupUI();
        }

        private void SetupUI()
        {
            // Create and configure TextBoxes for ticket classes
            textBoxClassA = new TextBox { Location = new System.Drawing.Point(20, 30), Width = 100 };
            textBoxClassB = new TextBox { Location = new System.Drawing.Point(20, 80), Width = 100 };
            textBoxClassC = new TextBox { Location = new System.Drawing.Point(20, 130), Width = 100 };

            buttonCalculate = new Button { Text = "Calculate", Location = new System.Drawing.Point(20, 180) };
            buttonCalculate.Click += new EventHandler(buttonCalculate_Click);

            buttonReset = new Button { Text = "Reset", Location = new System.Drawing.Point(150, 180) };
            buttonReset.Click += new EventHandler(buttonReset_Click);

            buttonExit = new Button { Text = "Exit", Location = new System.Drawing.Point(280, 180) };
            buttonExit.Click += new EventHandler(buttonExit_Click);

            labelRevenueA = new Label { Location = new System.Drawing.Point(20, 220), Width = 200 };
            labelRevenueB = new Label { Location = new System.Drawing.Point(20, 250), Width = 200 };
            labelRevenueC = new Label { Location = new System.Drawing.Point(20, 280), Width = 200 };
            labelTotalRevenue = new Label { Location = new System.Drawing.Point(20, 310), Width = 200 };

            this.Controls.Add(textBoxClassA);
            this.Controls.Add(textBoxClassB);
            this.Controls.Add(textBoxClassC);
            this.Controls.Add(buttonCalculate);
            this.Controls.Add(buttonReset);
            this.Controls.Add(buttonExit);
            this.Controls.Add(labelRevenueA);
            this.Controls.Add(labelRevenueB);
            this.Controls.Add(labelRevenueC);
            this.Controls.Add(labelTotalRevenue);

            this.ClientSize = new System.Drawing.Size(400, 350);
            this.Text = "Ticket Sales Revenue";
        }

        private void buttonCalculate_Click(object sender, EventArgs e)
        {
            CalculateRevenue();
        }

        private void CalculateRevenue()
        {
            // Parse input values
            int classATickets = GetTicketCount(textBoxClassA.Text);
            int classBTickets = GetTicketCount(textBoxClassB.Text);
            int classCTickets = GetTicketCount(textBoxClassC.Text);

            double revenueA = ClassAPrice * classATickets;
            double revenueB = ClassBPrice * classBTickets;
            double revenueC = ClassCPrice * classCTickets;

            UpdateRevenueLabels(revenueA, revenueB, revenueC);
        }

        private int GetTicketCount(string input)
        {

            return int.TryParse(input, out int count) ? count : 0;
        }

        private void UpdateRevenueLabels(double revenueA, double revenueB, double revenueC)
        {
            labelRevenueA.Text = $"Class A Revenue: {revenueA:F2} euro";
            labelRevenueB.Text = $"Class B Revenue: {revenueB:F2} euro";
            labelRevenueC.Text = $"Class C Revenue: {revenueC:F2} euro";

            double totalRevenue = revenueA + revenueB + revenueC;
            labelTotalRevenue.Text = $"Total Revenue: {totalRevenue:F2} euro";
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            ResetFields();
        }

        private void ResetFields()
        {
            labelRevenueA.Text = "Class A Revenue: 0.00 euro";
            labelRevenueB.Text = "Class B Revenue: 0.00 euro";
            labelRevenueC.Text = "Class C Revenue: 0.00 euro";
            labelTotalRevenue.Text = "Total Revenue: 0.00 euro";

            textBoxClassA.Text = "0";
            textBoxClassB.Text = "0";
            textBoxClassC.Text = "0";
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
