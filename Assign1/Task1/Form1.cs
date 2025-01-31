using System;
using System.Windows.Forms;
using System.Drawing;

namespace MyWinFormsApp
{
    public partial class Form1 : Form
    {
        private Button button1;
        private Label label2;
        private PictureBox pictureBox2;

        public Form1()
        {
            InitializeComponent();

            button1 = new Button();
            button1.Text = "Press";
            button1.Location = new System.Drawing.Point(30, 30);
            button1.Click += new EventHandler(Button1_Click);

            label2 = new Label();
            label2.Text = "I AM NOT FINE.";
            label2.Location = new System.Drawing.Point(30, 70);

            pictureBox2 = new PictureBox();
            pictureBox2.Location = new System.Drawing.Point(30, 110);
            pictureBox2.Size = new System.Drawing.Size(100, 100);
            pictureBox2.BackColor = Color.Blue;
            pictureBox2.Visible = false;

            this.Controls.Add(button1);
            this.Controls.Add(label2);
            this.Controls.Add(pictureBox2);
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("The button is pressed");
            label2.Text = "I AM FINE";
            pictureBox2.Visible = !pictureBox2.Visible;  
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
            Application.Exit();
        }
    }
}