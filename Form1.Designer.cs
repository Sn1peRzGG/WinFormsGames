using System;
using System.Drawing;
using System.Windows.Forms;

namespace WinFormGame
{
    partial class Form1
    {
        private TextBox guessNumberTextBox;
        private Button guessNumberButton;

        private readonly Random random = new Random();
        private int secretNumber;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label = new Label();
            comboBox = new ComboBox();
            showBtn = new Button();
            guessNumberTextBox = new TextBox();
            guessNumberButton = new Button();
            SuspendLayout();
            // 
            // label
            // 
            label.AutoSize = true;
            label.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label.Location = new Point(10, 10);
            label.Name = "label";
            label.Size = new Size(149, 23);
            label.TabIndex = 0;
            label.Text = "Choose your level:";
            // 
            // comboBox
            // 
            comboBox.Items.AddRange(new object[] { "Easy", "Medium", "Hard", "Ultra Hard" });
            comboBox.Location = new Point(160, 10);
            comboBox.Name = "comboBox";
            comboBox.Size = new Size(120, 28);
            comboBox.TabIndex = 0;
            // 
            // showBtn
            // 
            showBtn.AllowDrop = true;
            showBtn.AutoEllipsis = true;
            showBtn.BackColor = SystemColors.ActiveCaptionText;
            showBtn.Cursor = Cursors.Cross;
            showBtn.DialogResult = DialogResult.Continue;
            showBtn.Font = new Font("Unispace", 28F, FontStyle.Bold, GraphicsUnit.Point);
            showBtn.ForeColor = SystemColors.ButtonFace;
            showBtn.Location = new Point(200, 150);
            showBtn.Name = "showBtn";
            showBtn.Size = new Size(400, 120);
            showBtn.TabIndex = 2;
            showBtn.Text = "Let's play!";
            showBtn.UseVisualStyleBackColor = false;
            showBtn.Click += btnOnClick;
            // 
            // guessNumberTextBox
            // 
            guessNumberTextBox.Location = new Point(160, 50);
            guessNumberTextBox.Name = "guessNumberTextBox";
            guessNumberTextBox.Size = new Size(120, 27);
            guessNumberTextBox.TabIndex = 3;
            // 
            // guessNumberButton
            // 
            guessNumberButton.AllowDrop = true;
            guessNumberButton.AutoEllipsis = true;
            guessNumberButton.BackColor = SystemColors.ActiveCaptionText;
            guessNumberButton.Cursor = Cursors.Cross;
            guessNumberButton.DialogResult = DialogResult.Continue;
            guessNumberButton.Font = new Font("Unispace", 14F, FontStyle.Bold, GraphicsUnit.Point);
            guessNumberButton.ForeColor = SystemColors.ButtonFace;
            guessNumberButton.Location = new Point(300, 50);
            guessNumberButton.Name = "guessNumberButton";
            guessNumberButton.Size = new Size(100, 40);
            guessNumberButton.TabIndex = 4;
            guessNumberButton.Text = "Guess";
            guessNumberButton.UseVisualStyleBackColor = false;
            guessNumberButton.Click += GuessNumberButtonClick;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 500);
            Controls.Add(comboBox);
            Controls.Add(label);
            Controls.Add(showBtn);
            Controls.Add(guessNumberTextBox);
            Controls.Add(guessNumberButton);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "WinFormsGame";
            ResumeLayout(false);
            PerformLayout();
        }

        private void btnOnClick(object sender, EventArgs e)
        {
            if (comboBox.SelectedItem != null)
            {
                MessageBox.Show($"Your level is {comboBox.SelectedItem.ToString()}");
            }
            else
            {
                MessageBox.Show("Please choose a level first.");
            }
        }

        private void GuessNumberButtonClick(object sender, EventArgs e)
        {
            GuessNumber();
        }

        private void GuessNumber()
        {
            int userGuess;
            if (int.TryParse(guessNumberTextBox.Text, out userGuess))
            {
                if (userGuess == secretNumber)
                {
                    MessageBox.Show("Congratulations! You guessed the number!", "Result");
                    ChangeFormColor();
                    ResetGuessNumberGame();
                }
                else
                {
                    MessageBox.Show(userGuess < secretNumber
                        ? "The secret number is greater."
                        : "The secret number is smaller.", "Hint");
                }
            }
            else
            {
                MessageBox.Show("Please enter a number from 1 to 10.", "Error");
            }
        }

        private void ChangeFormColor()
        {
            BackColor = Color.FromArgb(random.Next(256), random.Next(256), random.Next(256));
        }

        private void ResetGuessNumberGame()
        {
            secretNumber = random.Next(1, 11);
        }

        #endregion

        private Label label;
        private ComboBox comboBox;
        private Button showBtn;
        private object components;
    }
}
