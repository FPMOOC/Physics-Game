using UnityEngine;

/// <summary>
/// Allows the placement of new blocks by the user, from the block queue.
/// </summary>
public class BlockCursor : MonoBehaviour
{
	private BlockQueue blockQueue;
	private Camera mainCamera;
	private Block block;

	private void Start()
	{
		blockQueue = FindObjectOfType<BlockQueue>();
		mainCamera = Camera.main;
		LoadBlock();
	}

	/// <summary>
	/// Grabs a block from the queue and has it follow the cursor.
	/// </summary>
	private void LoadBlock()
	{
		block = null;
		if (blockQueue.Count > 0)
		{
			GameObject blockObject = Instantiate(blockQueue.GetNextBlock(), GetCursorPosition(), Quaternion.identity);
			Block block = blockObject.GetComponent<Block>();
			this.block = block;
		}
	}

	private void Update()
	{
		// If the cursor is 'holding' a block set it to the current cursor position and attempt to place it on mouse down.
		if (block != null)
		{
			block.transform.position = GetCursorPosition();

			if (Input.GetMouseButtonDown(0) && block.AttemptPlace())
			{
				LoadBlock();
			}
		}
	}

	/// <summary>
	/// Get the 2D coordinates of the mouse cursor.
	/// </summary>
	private Vector3 GetCursorPosition()
	{
		Vector3 cursorPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
		cursorPosition.z = 0;
		return cursorPosition;
	}
}
