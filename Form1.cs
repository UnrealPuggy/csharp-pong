using System.Diagnostics;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Content;
using Rectangle = Content.Rectangle;


namespace Pong;

public partial class Form1 : Form
{


    private readonly System.Windows.Forms.Timer gameTimer;
    private readonly KeyState Key = new();

    private Entity Player = new(20, 10, 20, 120, Color.Lime);

    private Entity Ball = new(20, 20, 20, 20, Color.White);
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
        // gameTimer.Tick += new System.EventHandler(GameTick);
        gameTimer.Tick += GameTick;
        gameTimer.Start();
        KeyDown += KeyIsDown;
        KeyUp += KeyIsUp;

        // Console.WriteLine(gameTimer.ToString());
    }
    private int score = 0;
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
        score++;
        scoreLabel.Text = $"Score: {score}";
        scoreLabel.Left = ClientSize.Width / 2 - scoreLabel.Width / 2;


        Ball.updateDraw();
        Player.updateDraw();
        // Console.WriteLine("a");
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
