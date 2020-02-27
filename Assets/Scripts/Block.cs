using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer), typeof(Collider2D))]
public class Block : MonoBehaviour
{
	new private Collider2D collider;
	private SpriteRenderer spriteRenderer;
	private List<Collider2D> collisions = new List<Collider2D>();
	private Color color;

	private void Start()
	{
		spriteRenderer = GetComponent<SpriteRenderer>();
		collider = GetComponent<Collider2D>();
		collider.isTrigger = true;
		color = spriteRenderer.color;
		SetSpriteColor(SpriteState.ValidBuild);
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		collisions.Add(collision);
		SetSpriteColor(collisions.Count == 0 ? SpriteState.ValidBuild : SpriteState.InvalidBuild);
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collisions.Contains(collision))
		{
			collisions.Remove(collision);
		}
		SetSpriteColor(collisions.Count == 0 ? SpriteState.ValidBuild : SpriteState.InvalidBuild);
	}

	/// <summary>
	/// Changes the color of the sprite to represent the block state.
	/// </summary>
	private void SetSpriteColor(SpriteState state)
	{
		switch (state)
		{
			case SpriteState.Placed:
				spriteRenderer.color = new Color(color.r, color.g, color.b, 1);
				break;
			case SpriteState.ValidBuild:
				spriteRenderer.color = new Color(color.r, color.g, color.b, 0.5f);
				break;
			case SpriteState.InvalidBuild:
				spriteRenderer.color = new Color(color.r, color.g * 0.5f, color.b * 0.5f, 0.5f);
				break;
		}
	}

	/// <summary>
	/// Places the block if conditions are appropriate.
	/// </summary>
	/// <returns>True if successful, false if unsuccessful.</returns>
	public bool AttemptPlace()
	{
		if (collisions.Count == 0)
		{
			PlaceBlock();
			return true;
		}
		else return false;
	}

	/// <summary>
	/// Places the block by enabling collisions and updating sprite visuals.
	/// </summary>
	private void PlaceBlock()
	{
		collider.isTrigger = false;
		SetSpriteColor(SpriteState.Placed);
	}

	private enum SpriteState
	{ 
		ValidBuild, InvalidBuild, Placed 
	}
}
