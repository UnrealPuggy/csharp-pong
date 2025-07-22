namespace Pong;

partial class Form1
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code



    private Label scoreLabel;
    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {

        this.components = new System.ComponentModel.Container();
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(800, 450);
        this.BackColor = Color.Black;
        this.DoubleBuffered = true;
        this.ForeColor = Color.White;


        scoreLabel = new();
        scoreLabel.Text = "Score: 0";
        scoreLabel.Font = new Font(FontFamily.GenericMonospace, 24);
        scoreLabel.AutoSize = true;
        scoreLabel.Left = ClientSize.Width / 2 - scoreLabel.Width / 2;



        Controls.Add(Ball.pictureBox);


        Controls.Add(Player.pictureBox);

        this.Text = "My First Winform game";
        Controls.Add(scoreLabel);
    }

    #endregion
}
