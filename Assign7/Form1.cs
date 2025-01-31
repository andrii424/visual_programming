namespace AssignmentSeven
{
    public partial class ExamForm : Form
    {
        private readonly char[] correctResponses = {
            'B', 'D', 'A', 'A', 'C', 'A', 'B', 'A', 'C', 'D',
            'B', 'C', 'D', 'A', 'D', 'C', 'C', 'B', 'D', 'A'
        };

        public ExamForm()
        {
            InitializeComponent();
        }

        private void btnCheckAnswers_Click(object sender, EventArgs e)
        {
            string fileName = "ExamResults.txt";
            string fileDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Templates\\MyWinFormsApp\\SeventhAssignment");
            string filePath = Path.Combine(fileDirectory, fileName);

            // Check if the directory exists
            if (!Directory.Exists(fileDirectory))
            {
                MessageBox.Show("The directory does not exist. Please check the file path.");
                return;
            }
            string[] studentAnswers;
            try
            {
                studentAnswers = File.ReadAllLines(filePath);
                if (studentAnswers.Length != 20)
                {
                    MessageBox.Show("The number of answers is incorrect. Please ensure the file contains exactly 20 answers.");
                    return;
                }
            }
            catch (IOException ex)
            {
                MessageBox.Show($"Error reading the file: {ex.Message}");
                return;
            }

            char[] formattedAnswers = new char[studentAnswers.Length];

            for (int i = 0; i < studentAnswers.Length; i++)
            {
                formattedAnswers[i] = studentAnswers[i].Trim().ToUpper()[0];
            }

            int correctAnswerCount = 0;
            List<int> wrongAnswers = new List<int>();

            for (int i = 0; i < studentAnswers.Length; i++)
            {
                if (formattedAnswers[i] == correctResponses[i])
                {
                    correctAnswerCount++;
                }
                else
                {
                    wrongAnswers.Add(i + 1);  
                }
            }

            int incorrectAnswerCount = 20 - correctAnswerCount;
            bool hasPassed = correctAnswerCount >= 15;

            lblResult.Text = hasPassed ? "Passed" : "Failed";
            lblCorrectCount.Text = $"Correct Answers: {correctAnswerCount}";
            lblIncorrectCount.Text = $"Incorrect Answers: {incorrectAnswerCount}";

            wrongAnswersListBox.Items.Clear();
            foreach (int questionNumber in wrongAnswers)
            {
                wrongAnswersListBox.Items.Add($"Question {questionNumber}");
            }
        }

        private void lblHeader_Click(object sender, EventArgs e)
        {
        }
    }
}
