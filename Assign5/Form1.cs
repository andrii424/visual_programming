namespace FifthAssignment
{
    public partial class MainForm : Form
    {
        private int targetNumber;
        private int attempts;

        public MainForm()
        {
            InitializeComponent();
            GenerateRandomNumber();
        }

        private void GenerateRandomNumber()
        {
            Random generator = new Random();
            targetNumber = generator.Next(1, 101);
            attempts = 0;
        }

        private void btnCheckGuess_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtGuess.Text))
            {
                lblResult.Text = "Please enter a number!";
                return;
            }

            try
            {
                int userGuess = int.Parse(txtGuess.Text);
                attempts++;

                if (userGuess == targetNumber)
                {
                    lblResult.Text = "Congratulations! You've guessed the number!";
                }
                else if (userGuess < targetNumber)
                {
                    lblResult.Text = "The number is higher!";
                }
                else
                {
                    lblResult.Text = "The number is lower!";
                }

                lblAttempts.Text = $"Attempts: {attempts}";
            }
            catch (FormatException)
            {
                lblResult.Text = "Please enter a valid number.";
            }
        }

        private void btnNewGame_Click(object sender, EventArgs e)
        {
            GenerateRandomNumber();
            lblResult.Text = "A new game has started. Try to guess the number!";
            txtGuess.Clear();
            lblAttempts.Text = "Attempts: 0";
        }
    }
}
