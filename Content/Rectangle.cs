namespace Content
{
    public class Rectangle(int x, int y, int width, int height)
    {
        public int x = x;
        public int y = y;
        public int width = width;
        public int height = height;

        public bool AABB(Rectangle otherRec)
        {
            return this.x + this.width >= otherRec.x
            && this.x <= otherRec.x + otherRec.width && this.y + this.height >= otherRec.y && this.y <= otherRec.y + otherRec.height;
        }

        public void CloneOntoPictureBox(PictureBox box)
        {
            box.Top = this.y;
            box.Left = this.x;
            box.Width = this.width;
            box.Height = this.height;
        }
    }
}