using System;
using UnityEngine;
using UnityEngine.InputSystem;

// Token: 0x02000023 RID: 35
public class Cursor_move : MonoBehaviour
{
	// Token: 0x060000E3 RID: 227 RVA: 0x00006CCC File Offset: 0x00004ECC
	private void Awake()
	{
		Cursor_move.st = this;
		this.Mouse_Position = Sa_IS.input_Main.All.Mouse_Position;
	}

	// Token: 0x060000E4 RID: 228 RVA: 0x00006CF7 File Offset: 0x00004EF7
	private void LateUpdate()
	{
		if (this.Mouse_Position.ReadValue<Vector2>() != this.mouse_position)
		{
			this.Cursor_Mouse_rectTransform.position = this.Mouse_Position.ReadValue<Vector2>();
		}
	}

	// Token: 0x040000D0 RID: 208
	[Header("Курсор мыши UI")]
	[SerializeField]
	private RectTransform Cursor_Mouse_rectTransform;

	// Token: 0x040000D1 RID: 209
	[SerializeField]
	private Vector2 mouse_position;

	// Token: 0x040000D2 RID: 210
	public static Cursor_move st;

	// Token: 0x040000D3 RID: 211
	private InputAction Mouse_Position;
}
