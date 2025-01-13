using Godot;
using System;

public partial class MenuDeBase : Control
{
	[Export] private Button Jouer;
	[Export] private Button Options;
	private PackedScene start = (PackedScene)GD.Load("res://main.tscn");
	private PackedScene option = (PackedScene)GD.Load("res://menu_options.tscn");

	public override void _Ready()
	{
		Jouer = GetNode<Button>("MarginContainer/HBoxContainer/VBoxContainer/Button");
		Options = GetNode<Button>("MarginContainer/HBoxContainer/VBoxContainer/Button2");
		Jouer.ButtonDown += OnButtonDown;
		Options.ButtonDown += OptionsPressed;
	}

	private void OnButtonDown()
	{
		GetTree().ChangeSceneToPacked(start);
	}

	private void OptionsPressed()
	{
		GetTree().ChangeSceneToPacked(option);
	}
}
