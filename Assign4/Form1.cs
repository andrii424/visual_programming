namespace Assignment_4
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            int inputNumber = int.Parse(txtInput.Text);
            int result = 1;
            int i = inputNumber;
            
            while (i > 0)
            {
                result *= i;
                i--;
            }
            
            lblResult.Text = result.ToString();
        }
    }
}