using Godot;
using System;

public partial class controlsperso : CharacterBody2D
{
	[Export] private float Speed = 200.0f;
	[Export] private float JumpForce = -400.0f;
	[Export] private int Gravity = 980;

	private Vector2 velocity = Vector2.Zero;
	private AnimationPlayer animPlayer;

	public override void _Ready()
	{
		// Vérification que l'AnimationPlayer est bien présent
		animPlayer = GetNode<AnimationPlayer>("AnimatedSprite2D");
		if (animPlayer == null)
		{
			GD.PrintErr("AnimationPlayer introuvable !");
		}
	}

	public override void _PhysicsProcess(double delta)
	{
		if (!IsOnFloor())
		{
			velocity.Y += Gravity * (float)delta;
		}

		float direction = Input.GetAxis("ui_left", "ui_right");
		velocity.X = direction * Speed;

		if (direction != 0 && IsOnFloor() && animPlayer != null)
		{
			animPlayer.Play("new_animation");
		}
		else if (IsOnFloor() && animPlayer != null)
		{
			animPlayer.Stop();
		}

		if (Input.IsActionJustPressed("ui_up") && IsOnFloor())
		{
			velocity.Y = JumpForce;
			animPlayer?.Play("default");
		}

		Velocity = velocity;
		MoveAndSlide();
	}
}
