using System;
using Godot;

public static class GameManager
{
    public static void SplitBlock (this PlayerBlock p, Bidivisor b)
    {
        Vector2 pos = p.GlobalPosition;
        pos.x = pos.x * -1 + 1920;
        PackedScene blockScene = (PackedScene)ResourceLoader.Load("res://Objects/PlayerBlock.tscn");
        PlayerBlock[] newBlocks = new PlayerBlock[2];
        for(int i = 0; i < 2; i++)
        {
            newBlocks[i] = (PlayerBlock)blockScene.Instance();
            newBlocks[i].duplicating = 8;
            b.GetTree().Root.GetChild(0).GetChild(1).AddChild(newBlocks[i]);
            newBlocks[i].Set("rotation_degrees", -b.RotationDegrees - 45 + 90*i);
            newBlocks[i].GlobalPosition = pos;
            newBlocks[i].jumpIndex = p.jumpIndex == 0 ? 1 : 0;
            newBlocks[i].MoveLocalY(-newBlocks[i].jump[(newBlocks[i].jumpIndex)]);
        }
        ((GameScene)(b.GetTree().Root.GetChild(0))).PlayerNumber.Remove(p);
        p.QueueFree();
    }
    
    public static Vector2 Rotate(this Vector2 v, double degrees)
    {
        return new Vector2(
            (float)(v.x * Math.Cos(degrees) - v.y * Math.Sin(degrees)),
            (float)(v.x * Math.Sin(degrees) + v.y * Math.Cos(degrees))
        );
    } 
}
