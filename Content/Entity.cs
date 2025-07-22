using System.Drawing.Drawing2D;

namespace Content;


public class Entity
{
    private readonly Rectangle rect;
    public readonly PictureBox pictureBox = new();

    public int vx = 0;
    public int vy = 0;

    public int x
    {
        get => rect.x;
        set => rect.x = value;
    }
    public int y
    {
        get => rect.y;
        set => rect.y = value;
    }
    public int width
    {
        get => rect.width;
        set => rect.width = value;
    }
    public int height
    {
        get => rect.height;
        set => rect.height = value;
    }
    public bool visible
    {
        get => pictureBox.Visible;
        set => pictureBox.Visible = value;
    }
    public Entity(int x, int y, int w, int h, Color color)
    {
        rect = new(x, y, w, h);
        pictureBox.BackColor = color;
        rect.CloneOntoPictureBox(pictureBox);
    }
    public bool IsColliding(Entity other)
    {
        return rect.AABB(other.rect);
    }


    public void updateDraw()
    {
        rect.CloneOntoPictureBox(pictureBox);
    }
}