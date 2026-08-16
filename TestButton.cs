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
		
		this.MetaVarsUpdate();// do all the updating based on vars

		
		//AudioStreamPlayer
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

		NodePath path = (NodePath)GetMeta("ShowLabel", "");// on press toggle label
		
		bool incrementDay = (bool)GetMeta("IncrementDay",false);
		int AddSupplies = (int)GetMeta("AddSupplies",0);
		int AddAmmo = (int)GetMeta("AddAmmo",0);
		bool HideAfterPressed = (bool)GetMeta("HideAfterPressed",false);
		bool Reset = (bool)GetMeta("ResetGame",false);
		
		AudioStream sound = (AudioStream)GetMeta("PlaySound",false);
		

		if (sound != null)
		{
			AudioStreamPlayer  SoundNode = (AudioStreamPlayer)GetNode("/root/NpcInteraction/AudioStreamPlayerFX");
			SoundNode.Stream = sound;
			SoundNode.Play();
			
		}

		//*
		 if ( TestGlobal != "")
		{
			//Globals global = (Globals)GetNode("/root/Globals");
			GD.Print(TestGlobal+" = "+ (Globals.GetMyStoryVars().GetGlobal(TestGlobal) ? "true": "false"));
		}//*/
		 
//show label
		if (path.ToString() != "")
		{
			Label ShowLabel = (Label)GetNode(path);
			ShowLabel.Visible = !ShowLabel.Visible;
		}

		if (incrementDay)
		{
			Globals.incrementDay();
		}

		if (AddSupplies != 0)
		{
			Globals.AddToSupplies(AddSupplies);
		}
		if (AddAmmo != 0)
		{
			Globals.AddToAmmo(AddAmmo);
		}

		if (HideAfterPressed)
		{
			this.Visible = false;
		}

		if ( SetGlobal != "")
		{
			Globals.GetMyStoryVars().SetGlobal(SetGlobal);
		}
		if ( Reset)
		{
			Globals.reset();
		}
		
		if ( SceneTransition != "")
		{
			GetTree().ChangeSceneToFile("res://"+SceneTransition);
		}
	}
	
	/// <summary>
	/// Metavars Update (usually happens when level is loaded, todo: able to be set to happen on update?
	/// </summary>
	public void MetaVarsUpdate()
	{

		//show on var//todo test
		string ShowOnVar = (string)GetMeta("ShowOnVar","");
		if (ShowOnVar != "")
		{
			if (Globals.GetMyStoryVars().GetGlobal(ShowOnVar))
			{
				this.Visible = true;

			}

		}
		//hide on var//todo test
		string HideOnVar = (string)GetMeta("HideOnVar","");
		if (Globals.GetMyStoryVars().GetGlobal(ShowOnVar))
		{
			this.Visible = true;

		}
	}
}
