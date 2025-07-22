using System.Drawing.Text;
using System.Reflection;
using Pong.Content;

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
    private Label LosingLabel;
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
        // Replace "<YourAssemblyName>" with your actual assembly name (usually your project name).
        // Replace "MyWavResource.wav" with the actual name of your WAV file (including extension) within the Resources folder.
        // Font customFont = FontUtils.LoadFontFromStream(s, 20f);
        PrivateFontCollection fontCollection = new();
        fontCollection.AddFontFile(FileUtils.ExtractEmbeddedAsset("Content/Fonts/AndyBold.ttf")); // path to .ttf file

        LosingLabel = new();
        // new FontFamily()
        LosingLabel.Font = new Font(fontCollection.Families[0], 24);
        LosingLabel.AutoSize = true;

        scoreLabel = new();
        scoreLabel.Text = "Score: 0";
        scoreLabel.Font = new Font(fontCollection.Families[0], 24);
        scoreLabel.AutoSize = true;
        scoreLabel.Left = ClientSize.Width / 2 - scoreLabel.Width / 2;

        Controls.Add(LosingLabel);
        Controls.Add(Computer.pictureBox);
        Controls.Add(Ball.pictureBox);


        Controls.Add(Player.pictureBox);

        this.Text = "Pong";
        Controls.Add(scoreLabel);
    }

    #endregion
}
