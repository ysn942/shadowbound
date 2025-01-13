class_name MenuPrincipal
extends Control

@onready var Jouer = $MarginContainer/HBoxContainer/VBoxContainer/Button as Button
@onready var Options = $MarginContainer/HBoxContainer/VBoxContainer/Button2 as Button
@onready	 var start = preload("res://main.tscn") as PackedScene

func _ready():
	Jouer.button_down.connect(on_button_down)
	Options.button_down.connect(options)

func on_button_down() -> void:
	get_tree().change_scene_to_packed(start)
func options() -> void:
	pass
