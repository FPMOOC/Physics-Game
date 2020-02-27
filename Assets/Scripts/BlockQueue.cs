using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Manages a queue for the blocks that can be placed in a level.
/// </summary>
public class BlockQueue : MonoBehaviour
{
	[SerializeField]
	[Tooltip("The order of the blocks the player can place in the level.")]
	private GameObject[] levelBlocks;
	private Queue<GameObject> blocks = new Queue<GameObject>();

	public int Count => blocks.Count;

	private void Awake()
	{
		blocks = new Queue<GameObject>(levelBlocks);
	}

	/// <summary>
	/// Removes a block from the queue and returns it to the caller.
	/// </summary>
	public GameObject GetNextBlock()
	{
		return blocks.Dequeue();
	}
}
