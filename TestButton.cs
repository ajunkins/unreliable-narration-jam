using Godot;
using System;
using Unreliable_Narratation_Jam;

public partial class TestButton : Button
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
		GD.Print("Button was clicked!");
		string SceneTransition = (string)GetMeta("SceneTransition","");
		string SetGlobal = (string)GetMeta("SetGlobal","");
		string TestGlobal = (string)GetMeta("TestGlobal","");

		NodePath path = (NodePath)GetMeta("ShowLabel", "");
		
		bool incrementDay = (bool)GetMeta("IncrementDay","");
		
		//*
		 if ( TestGlobal != "")
		{
			//Globals global = (Globals)GetNode("/root/Globals");
			GD.Print(TestGlobal+" = "+ (Globals.GetMyStoryVars().GetGlobal(TestGlobal) ? "true": "false"));
		}//*/
		 
		if (path.ToString() != "")
		{
			Label ShowLabel = (Label)GetNode(path);
			ShowLabel.Visible = !ShowLabel.Visible;
		}

		if (incrementDay)
		{
			Globals.incrementDay();
		}

		if ( SetGlobal != "")
		{
			//Globals.GetMyStoryVars();
			//Globals global = (Globals)GetNode("/root/Globals");
			Globals.GetMyStoryVars().SetGlobal(SetGlobal);
		}
		
		if ( SceneTransition != "")
		{
			GetTree().ChangeSceneToFile("res://"+SceneTransition);
		}
	}
}
