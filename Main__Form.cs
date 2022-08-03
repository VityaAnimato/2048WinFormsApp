using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2048WinFormsApp
{
    public partial class Main__Form : Form
    {
        private int mapSize;
        private Label[,] lablesMap;
        private static Random random = new Random();
        private int bestValue;
        private int chance2 = 75;

        private User newUser = new User();

        public Main__Form()
        {
            var startForm = new StartForm();            
            startForm.ShowDialog();

            mapSize = Convert.ToInt32(startForm.fieldSizeComboBox.Text[0].ToString());
            newUser.Name = startForm.inputUserNameTextBox.Text;

            InitializeComponent();
        }

        private void Main__Form_Load(object sender, EventArgs e)
        {
            InitMap();
            bestScoreLabel.Text = ShowBestScore();
            GenerateNumber();
        }


        private void InitMap()
        {
            this.ClientSize = new Size(10 + 76*mapSize, 80 + 76*mapSize);

            lablesMap = new Label[mapSize, mapSize];
            for (int i = 0; i < mapSize; i++)
            {
                for (int j = 0; j < mapSize; j++)
                {
                    var newLable = CreateLable(i, j);
                    Controls.Add(newLable);
                    lablesMap[i, j] = newLable;
                }
            }
        }

        private void GenerateNumber() 
        {          
            for (int i = 0; i < mapSize * mapSize; i++)
            {
                var randomNumberLable = random.Next(mapSize * mapSize);
                var indexRow = randomNumberLable / mapSize;
                var indexColumn = randomNumberLable % mapSize;
                if (lablesMap[indexRow, indexColumn].Text == string.Empty)
                {

                    var diceRoll = random.Next(1, 101);
                    if (diceRoll <= chance2)
                    {
                        lablesMap[indexRow, indexColumn].Text = "2";
                    }
                    else
                    {
                        lablesMap[indexRow, indexColumn].Text = "4";
                    }
                    return;
                }
            }
        }


        private Label CreateLable(int indexRow, int indexColumn)
        {
            var label = new Label();
            label.BackColor = SystemColors.ButtonShadow;
            label.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            label.Size = new Size(70, 70);
            label.TextAlign = ContentAlignment.MiddleCenter;
            int x = 10 + indexColumn * 76;
            int y = 70 + indexRow * 78;
            label.Location = new Point(x, y);

            label.TextChanged += Label_TextChanged;

            return label;
        }

        private void Label_TextChanged(object? sender, EventArgs e)
        {
            var label = (Label)sender;
            var number = label.Text;
            label.BackColor = number switch
            {
                "" => SystemColors.ButtonShadow,
                "2" => Color.FromArgb(250, 70, 70),
                "4" => Color.FromArgb(230, 70, 70),
                "8" => Color.FromArgb(210, 70, 70),
                "16" => Color.FromArgb(190, 70, 70),
                "32" => Color.FromArgb(170, 70, 70),
                "64" => Color.FromArgb(150, 70, 70),
                "128" => Color.FromArgb(130, 70, 70),
                "256" => Color.FromArgb(110, 70, 70),
                "512" => Color.FromArgb(90, 70, 70),
                "1024" => Color.FromArgb(70, 70, 70),
                "2048" => Color.FromArgb(50, 70, 70),
                _ => SystemColors.ButtonShadow,
            };

        }


        private void Main__Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Right && e.KeyCode != Keys.Left && e.KeyCode != Keys.Down && e.KeyCode != Keys.Up)
            {
                return;
            }
            else if (e.KeyCode == Keys.Right)
            {
                MoveRight();
                
            }
            else if (e.KeyCode == Keys.Left)
            {
                MoveLeft();
                
            }
            else if (e.KeyCode == Keys.Up)
            {
                MoveUp();
                
            }
            else if (e.KeyCode == Keys.Down)
            {
                MoveDown();
                
            }

            if (CheckGameOver()) // not working correctly...
            {
                GameOver();
            }

            GenerateNumber();
            ShowScore();
        }

        private void MoveDown()
        {
            for (int j = 0; j < mapSize; j++)
            {
                for (int i = mapSize - 1; i >= 0; i--)
                {
                    if (lablesMap[i, j].Text != string.Empty)
                    {
                        for (int k = i - 1; k >= 0; k--)
                        {
                            if (lablesMap[k, j].Text != string.Empty)
                            {
                                if (lablesMap[i, j].Text == lablesMap[k, j].Text)
                                {
                                    var number = int.Parse(lablesMap[i, j].Text);
                                    newUser.Score += number * 2;
                                    lablesMap[i, j].Text = (number * 2).ToString();
                                    lablesMap[k, j].Text = string.Empty;

                                    Check2048(lablesMap[i, j].Text);
                                }
                                break;
                            }
                        }
                    }
                }
            }

            for (int j = 0; j < mapSize; j++)
            {
                for (int i = mapSize - 1; i >= 0; i--)
                {
                    if (lablesMap[i, j].Text == string.Empty)
                    {
                        for (int k = i - 1; k >= 0; k--)
                        {
                            if (lablesMap[k, j].Text != string.Empty)
                            {
                                lablesMap[i, j].Text = lablesMap[k, j].Text;
                                lablesMap[k, j].Text = string.Empty;

                                Check2048(lablesMap[i, j].Text);
                                break;
                            }
                        }
                    }
                }
            }
        }

        private void MoveUp()
        {
            for (int j = 0; j < mapSize; j++)
            {
                for (int i = 0; i < mapSize; i++)
                {
                    if (lablesMap[i, j].Text != string.Empty)
                    {
                        for (int k = i + 1; k < mapSize; k++)
                        {
                            if (lablesMap[k, j].Text != string.Empty)
                            {
                                if (lablesMap[i, j].Text == lablesMap[k, j].Text)
                                {
                                    var number = int.Parse(lablesMap[i, j].Text);
                                    newUser.Score += number * 2;
                                    lablesMap[i, j].Text = (number * 2).ToString();
                                    lablesMap[k, j].Text = string.Empty;

                                    Check2048(lablesMap[i, j].Text);

                                }
                                break;
                            }
                        }
                    }
                }
            }

            for (int j = 0; j < mapSize; j++)
            {
                for (int i = 0; i < mapSize; i++)
                {
                    if (lablesMap[i, j].Text == string.Empty)
                    {
                        for (int k = i + 1; k < mapSize; k++)
                        {
                            if (lablesMap[k, j].Text != string.Empty)
                            {
                                lablesMap[i, j].Text = lablesMap[k, j].Text;
                                lablesMap[k, j].Text = string.Empty;

                                Check2048(lablesMap[i, j].Text);
                                break;
                            }
                        }
                    }
                }
            }
        }

        private void MoveLeft()
        {
            for (int i = 0; i < mapSize; i++)
            {
                for (int j = 0; j < mapSize; j++)
                {
                    if (lablesMap[i, j].Text != string.Empty)
                    {
                        for (int k = j + 1; k < mapSize; k++)
                        {
                            if (lablesMap[i, k].Text != string.Empty)
                            {
                                if (lablesMap[i, j].Text == lablesMap[i, k].Text)
                                {
                                    var number = int.Parse(lablesMap[i, j].Text);
                                    newUser.Score += number * 2;
                                    lablesMap[i, j].Text = (number * 2).ToString();
                                    lablesMap[i, k].Text = string.Empty;

                                    Check2048(lablesMap[i, j].Text);

                                }
                                break;
                            }
                        }
                    }
                }
            }

            for (int i = 0; i < mapSize; i++)
            {
                for (int j = 0; j < mapSize; j++)
                {
                    if (lablesMap[i, j].Text == string.Empty)
                    {
                        for (int k = j + 1; k < mapSize; k++)
                        {
                            if (lablesMap[i, k].Text != string.Empty)
                            {
                                lablesMap[i, j].Text = lablesMap[i, k].Text;
                                lablesMap[i, k].Text = string.Empty;

                                Check2048(lablesMap[i, j].Text);
                                break;
                            }
                        }
                    }
                }
            }
        }

        private void MoveRight()
        {
            for (int i = 0; i < mapSize; i++)
            {
                for (int j = mapSize - 1; j >= 0; j--)
                {
                    if (lablesMap[i, j].Text != string.Empty)
                    {
                        for (int k = j - 1; k >= 0; k--)
                        {
                            if (lablesMap[i, k].Text != string.Empty)
                            {
                                if (lablesMap[i, j].Text == lablesMap[i, k].Text)
                                {
                                    var number = int.Parse(lablesMap[i, j].Text);
                                    newUser.Score += number * 2;                                   
                                    lablesMap[i, j].Text = (number * 2).ToString();
                                    lablesMap[i, k].Text = string.Empty;

                                    Check2048(lablesMap[i, j].Text);

                                }
                                break;
                            }
                        }
                    }
                }
            }

            for (int i = 0; i < mapSize; i++)
            {
                for (int j = mapSize - 1; j >= 0; j--)
                {
                    if (lablesMap[i, j].Text == string.Empty)
                    {
                        for (int k = j - 1; k >= 0; k--)
                        {
                            if (lablesMap[i, k].Text != string.Empty)
                            {
                                lablesMap[i, j].Text = lablesMap[i, k].Text;
                                lablesMap[i, k].Text = string.Empty;

                                Check2048(lablesMap[i, j].Text);

                                break;
                            }
                        }
                    }
                }
            }
        }


        private void Check2048(string score)
        {
            if (score == "2048")
            {               
                UserManager.Add(newUser);

                MessageBox.Show("2048! Вы выиграли!");
                MessageBox.Show("Играем снова *_*");
                Application.Restart();
            }

        }

        private bool CheckGameOver()
        {
            for (int i = 0; i < mapSize; i++)
            {
                for (int j = 0; j < mapSize; j++)
                {
                    if (lablesMap[i, j].Text == "")
                    {
                        return false;
                    }      
                }
            }

            for (int i = 0; i < mapSize - 1; i++)
            {
                for (int j = 0; j < mapSize - 1; j++)
                {
                    if (lablesMap[i, j].Text == lablesMap[i, j + 1].Text || lablesMap[i, j + 1].Text == lablesMap[i + 1, j].Text)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        private void GameOver()
        {
            UserManager.Add(newUser);

            MessageBox.Show("Игра проиграна... Пустых клеток не осталось...");
            MessageBox.Show("Играем снова *_*");
            Application.Restart();
        }


        private void ShowScore()
        {
            scoreLabel.Text = newUser.Score.ToString();
        }

        private string ShowBestScore()
        {
            var users = UserManager.GetAll();
            int bestScore = 0;
            foreach (var user in users)
            {
                if (user.Score > bestScore)
                {
                    bestScore = user.Score;
                }
            }
            return bestScore.ToString();
        }


        private void restartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void rulesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Используйте ←, →, ↑, ↓. \n\nЦель собрать плитку 2048. \n\nЕсли в одной строчке или в одном столбце находится более двух плиток одного номинала, то при сбрасывании они начинают соединяться с той стороны, в которую были направлены. Например, находящиеся в одной строке плитки (4, 4, 4) после хода влево превратятся в (8, 4), а после хода вправо — в (4, 8) \n\nЕсли не останется пустых клеток - проиграете(");
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void resultsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var resultForm = new ResultForm();
            resultForm.ShowDialog();
        }

    }
}
