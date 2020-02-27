using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer), typeof(Collider2D))]
public class Block : MonoBehaviour
{
	private bool placed = false;
	new private Collider2D collider;
	private SpriteRenderer spriteRenderer;
	private List<Collider2D> collisions = new List<Collider2D>();

	private void Start()
	{
		spriteRenderer = GetComponent<SpriteRenderer>();
		collider = GetComponent<Collider2D>();
		SetSpriteColor(SpriteState.ValidPlace);
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		collisions.Add(collision);
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collisions.Contains(collision))
		{
			collisions.Remove(collision);
		}
	}

	private void SetSpriteColor(SpriteState state)
	{
		switch (state)
		{
			case SpriteState.Placed:
				spriteRenderer.color = new Color(1, 1, 1, 1);
				break;
			case SpriteState.ValidPlace:
				spriteRenderer.color = new Color(1, 1, 1, 0.5f);
				break;
			case SpriteState.InvalidPlace:
				spriteRenderer.color = new Color(1, 0.5f, 0.5f, 0.5f);
				break;
		}
	}

	public bool AttemptPlace()
	{
		if (collisions.Count == 0)
		{
			PlaceBlock();
			return true;
		}
		else return false;
	}

	private void PlaceBlock()
	{
		placed = true;
		SetSpriteColor(SpriteState.Placed);
	}

	private enum SpriteState
	{ 
		ValidPlace, InvalidPlace, Placed 
	}
}
