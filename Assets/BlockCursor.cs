using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockCursor : MonoBehaviour
{
	private BlockQueue blockQueue;
	private Camera mainCamera;
	private Block block;

	private void Start()
	{
		blockQueue = FindObjectOfType<BlockQueue>();
		mainCamera = Camera.main;
	}

	private void LoadBlock()
	{

	}

	private void Update()
	{
		if (Input.GetMouseButtonDown(0) && blockQueue.Count > 0)
		{
			Vector3 cursorPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
			cursorPosition.z = 0;
			Instantiate(blockQueue.GetNextBlock(), cursorPosition, Quaternion.identity);
		}
	}
}
