using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockQueue : MonoBehaviour
{
	[SerializeField]
	private GameObject[] levelBlocks;
	private Queue<GameObject> blocks = new Queue<GameObject>();

	public int Count => blocks.Count;

	private void Awake()
	{
		blocks = new Queue<GameObject>(levelBlocks);
	}

	public GameObject GetNextBlock()
	{
		return blocks.Dequeue();
	}
}
