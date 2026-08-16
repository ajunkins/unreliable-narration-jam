using Godot;
using System;

public partial class ListButtons : ItemList
{
	private ItemList _itemList;

	public override void _Ready()
	{
		_itemList = GetNode<ItemList>("ItemList");
		_itemList.ItemSelected += OnItemListSelected;
	}

	private void OnItemListSelected(long index)
	{
		GD.Print($"Selected item index: {index}");
	}
}
