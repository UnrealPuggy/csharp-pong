using System.Diagnostics;
using System.Drawing.Drawing2D;
using System.Media;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Pong.Content;
using Rectangle = Pong.Content.Rectangle;


namespace Pong;

public partial class Form1 : Form
{


    private readonly System.Windows.Forms.Timer gameTimer;
    private readonly KeyState Key = new();

    private readonly Entity Player = new(20, 10, 20, 120, Color.Lime);

    private readonly Entity Ball = new(20, 20, 20, 20, Color.White);
    private readonly Entity Computer = new(20, 10, 20, 120, Color.Red);
    public Form1()
    {
        InitializeComponent();
        gameTimer = new System.Windows.Forms.Timer
        {
            Enabled = true,
            Interval = 10
        };
        Ball.x = ClientSize.Width / 2 - 10;
        Ball.y = ClientSize.Height / 2 - 10;
        Ball.vy = 3;
        Ball.vx = 3;
        Computer.x = ClientSize.Width - 40;
        // gameTimer.Tick += new System.EventHandler(GameTick);
        gameTimer.Tick += GameTick;
        gameTimer.Start();
        KeyDown += KeyIsDown;
        KeyUp += KeyIsUp;

        // Console.WriteLine(gameTimer.ToString());
    }
    private int score = 0;
    string bounceSoundPath = FileUtils.ExtractEmbeddedAsset("Content/Sounds/bounce.wav");
    public void bounce()
    {
        // Assembly a = Assembly.GetExecutingAssembly();
        // Replace "<YourAssemblyName>" with your actual assembly name (usually your project name).
        // Replace "MyWavResource.wav" with the actual name of your WAV file (including extension) within the Resources folder.
        // Stream? s = a.GetManifestResourceStream("pong.Content.Sounds.bounce.wav");

        SoundPlayer e = new(bounceSoundPath);
        e.Play();

    }
    public void GameTick(object? sender, System.EventArgs e)
    {

        if (Key[Keys.W])
        {
            Player.y -= 5;
        }
        if (Key[Keys.S])
        {
            Player.y += 5;
        }
        Ball.x += Ball.vx;
        Ball.y += Ball.vy;

        if (Ball.x + Ball.width > ClientSize.Width - 40)
        {
            Ball.x = ClientSize.Width - 60;
            Ball.vx *= -1;
            bounce();
        }
        if (Ball.y + Ball.height > ClientSize.Height)
        {
            Ball.y = ClientSize.Height - 20;
            Ball.vy *= -1;
            bounce();
        }
        if (Ball.y < 0)
        {
            Ball.y = 0;
            Ball.vy *= -1;
            bounce();
        }
        if (Ball.IsColliding(Player))
        {
            bounce();
            score++;
            Ball.x = Player.x + Player.width;
            Ball.vx *= -1;
        }
        if (Ball.x < -20)
        {
            GameOver(this.score);
        }

        if (Player.y < -Player.height)
        {
            Player.y = ClientSize.Height;
        }
        if (Player.y > ClientSize.Height)
        {
            Player.y = -Player.height;
        }
        // score++;
        scoreLabel.Text = $"Score: {score}";
        scoreLabel.Left = ClientSize.Width / 2 - scoreLabel.Width / 2;
        Computer.x = ClientSize.Width - 40;

        Computer.y = Ball.y + 10 - Computer.height / 2;
        Computer.y = Math.Clamp(Computer.y, 0, ClientSize.Height - 120);
        Ball.updateDraw();
        Computer.updateDraw();
        Player.updateDraw();
        // Console.WriteLine("a");
    }
    private void GameOver(int score)
    {
        LosingLabel.Text = $"You Lost! You Had: {score} points!";
        LosingLabel.Left = ClientSize.Width / 2 - LosingLabel.Width / 2;
        LosingLabel.Top = ClientSize.Height / 2 - LosingLabel.Height / 2;

        Ball.visible = false;
        Player.visible = false;
        Computer.visible = false;

        scoreLabel.Visible = false;
        gameTimer.Enabled = false;
        LosingLabel.Visible = true;
    }
    private void KeyIsDown(object? sender, KeyEventArgs e)
    {
        Key[e.KeyCode] = true;



    }
    private void KeyIsUp(object? sender, KeyEventArgs e)
    {
        Key[e.KeyCode] = false;
    }
}
