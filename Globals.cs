using Godot;
using System;
using Godot.Collections;


namespace Unreliable_Narratation_Jam;


public partial class Globals : Node
{
	private static StoryVars MyStoryVars;
	public override void _Ready()
	{
		MyStoryVars = new StoryVars();
		GD.Print("globals path");
		GD.Print(this.GetPath().ToString());
	}

	public static StoryVars GetMyStoryVars()
	{
		return MyStoryVars;
	}
	
	public static void incrementDay()
	{
		Globals.GetMyStoryVars().Day++;
	}

	public static void AddToSupplies(int value)
	{
		Globals.GetMyStoryVars().Supplies += value;
	}
	public static void AddToAmmo(int value)
	{
		Globals.GetMyStoryVars().Ammunition += value;
	}

	public static void reset()
	{
		Globals.GetMyStoryVars().reset();
	}
}

public class StoryVars
{
	public  int Day = 0;
	public  int Supplies = 0;//TODO update to higher number
	public  int Ammunition = 0;//TODO update to higher number

	public Dictionary<string, bool> WorldGlobals = new Dictionary<string, bool>();

	// adds or updates a global
	public void SetGlobal(string globalName, bool value = true)
	{
		if(WorldGlobals.ContainsKey(globalName))
		{
			WorldGlobals[globalName] = value;
		}
		else
		{
			WorldGlobals.Add(globalName, value);
		}
	}

	public bool GetGlobal(string globalName)
	{
		if (WorldGlobals.ContainsKey(globalName))
		{
			return WorldGlobals[globalName];
		}
		return false;
	}
	public void reset()
	{
		Day = 0;
		Supplies = 0;
		Ammunition = 5;
		WorldGlobals = new Dictionary<string, bool>();
	}

}
