using Godot;
using System;

public partial class DialogueButton : Button
{
	
	public override void _Ready()
	{	
		// Called when the node enters the scene tree for the first time.
		this.Pressed += ButtonPressed;
		GD.Print("Button test");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	
	private void ButtonPressed()
	{
		GD.Print($"{Name} was clicked!");
		string SceneTransition = (string)GetMeta("SceneTransition","");
		
		Node panel = GetParent();
		GD.Print($"Parent name: {panel.Name}");
		
		if ( SceneTransition != "")
		{
			GetTree().ChangeSceneToFile("res://"+SceneTransition);
		}
	}
}
