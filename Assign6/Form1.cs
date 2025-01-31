namespace SixthAssignment
{
    public partial class GameForm : Form
    {
        private readonly string[] choices = { "Rock", "Scissors", "Paper" };
        private readonly Random rng = new Random();

        public GameForm()
        {
            InitializeComponent();
        }

        private void DetermineWinner(string playerChoice, string aiChoice)
        {
            if (playerChoice == aiChoice)
            {
                lblResult.Text = "It's a draw!";
            }
            else if ((playerChoice == "Rock" && aiChoice == "Scissors") ||
                     (playerChoice == "Paper" && aiChoice == "Rock") ||
                     (playerChoice == "Scissors" && aiChoice == "Paper"))
            {
                lblResult.Text = "You won!";
            }
            else
            {
                lblResult.Text = "Computer won!";
            }
        }

        private void MakeComputerChoice(string playerChoice)
        {
            string aiChoice = choices[rng.Next(choices.Length)];
            lblComputerChoice.Text = $"Computer chose: {aiChoice}";
            lblPlayerChoice.Text = $"You chose: {playerChoice}";
            DetermineWinner(playerChoice, aiChoice);
        }

        private void btnRock_Click(object sender, EventArgs e)
        {
            MakeComputerChoice("Rock");
        }

        private void btnPaper_Click(object sender, EventArgs e)
        {
            MakeComputerChoice("Paper");
        }

        private void btnScissors_Click(object sender, EventArgs e)
        {
            MakeComputerChoice("Scissors");
        }
    }
}

