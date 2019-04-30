using System;

public class Box
{
    private string id;
    private Size size;

    public string ID { get => id; }
    public Size Size { get => size; }

    public Box()
    {
        this.id = Util.CreateUniqueID();
    }

    public Box(Size size) : this()
    {
        this.size = size;
    }
}