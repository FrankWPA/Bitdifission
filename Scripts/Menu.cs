using Godot;

public class Menu : Control
{
    private void _on_Play_pressed()
    {
        GetTree().ChangeScene("res://Scenes/GameModes.tscn");
    }
    
    public override void _Process(float delta)
    {
        if (Input.IsActionJustPressed("ui_cancel"))
        {
            GetTree().Quit();
        }
    }

	private void _on_Button_pressed()
    {
    	GetTree().Quit();
	}

	private void _on_Button2_pressed()
    {
    	GetTree().ChangeScene("res://Scenes/Credits.tscn");
	}
}









