using Godot;
using System;
using Unreliable_Narratation_Jam;

public partial class LabelTest : Label
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
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

	//show on var
	//hide on var


	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
