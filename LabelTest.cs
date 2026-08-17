using Godot;
using System;
using Unreliable_Narratation_Jam;

public partial class LabelTest : Label
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		this.MetaVarsUpdate();// do all the updating based on vars

	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void MetaVarsUpdate()
	{
		string Override = (string)GetMeta("SetAsOverrideLabel","");

		switch (Override.ToLower())
		{
			case "ammo":
				this.Text = Globals.GetMyStoryVars().Ammunition.ToString();
				break;
			
			case "supplies":
				this.Text = Globals.GetMyStoryVars().Supplies.ToString();
				break;
			
			case "day":
				this.Text = Globals.GetMyStoryVars().Day.ToString();
				break;
		}
		
		//audio
		string SoundOnVar = (string)GetMeta("SoundOnVar","");
		AudioStream sound = (AudioStream)GetMeta("VarSound", false);
		if (sound != null && SoundOnVar !="")
		{
			if (Globals.GetMyStoryVars().GetGlobal(SoundOnVar))
			{
				AudioStreamPlayer SoundNode = (AudioStreamPlayer)GetNode("/root/NpcInteraction/AudioStreamPlayerFX");
				SoundNode.Stream = sound;
				SoundNode.Play();
			}

		}

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
		
		//show on day
		int ShowOnDay = (int)GetMeta("ShowOnDay",-1);
		if (Globals.GetMyStoryVars().Day == ShowOnDay)
		{
			this.Visible = true;

		}
	}
}
