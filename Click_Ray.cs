using System;
using UnityEngine;
using UnityEngine.InputSystem;

// Token: 0x0200006C RID: 108
public class Click_Ray : MonoBehaviour
{
	// Token: 0x17000021 RID: 33
	// (get) Token: 0x060002C6 RID: 710 RVA: 0x0000DFCF File Offset: 0x0000C1CF
	private Vector3 mouse_position
	{
		get
		{
			return Mouse.current.position.ReadValue();
		}
	}

	// Token: 0x17000022 RID: 34
	// (get) Token: 0x060002C7 RID: 711 RVA: 0x0000DFE5 File Offset: 0x0000C1E5
	private Vector3 camera_position
	{
		get
		{
			return Camera.main.transform.position;
		}
	}

	// Token: 0x060002C8 RID: 712 RVA: 0x0000DFF8 File Offset: 0x0000C1F8
	private void Awake()
	{
		this.Click_find_item = Sa_IS.input_Main.am_play.Move_Map;
	}

	// Token: 0x060002C9 RID: 713 RVA: 0x0000E01D File Offset: 0x0000C21D
	private void OnEnable()
	{
		this.Click_find_item.started += this.Click_Item_Find_Down;
		this.Click_find_item.canceled += this.Click_Item_Find_Up;
	}

	// Token: 0x060002CA RID: 714 RVA: 0x0000E04D File Offset: 0x0000C24D
	private void OnDisable()
	{
		this.Click_find_item.started -= this.Click_Item_Find_Down;
		this.Click_find_item.canceled -= this.Click_Item_Find_Up;
	}

	// Token: 0x060002CB RID: 715 RVA: 0x0000E080 File Offset: 0x0000C280
	private void Update()
	{
		RaycastHit raycastHit;
		if (!Physics.Raycast(this.camera_position, Camera.main.ScreenPointToRay(this.mouse_position).direction, out raycastHit))
		{
			return;
		}
		if (raycastHit.collider.GetComponent<ICursorReaction>() != null)
		{
			raycastHit.collider.GetComponent<ICursorReaction>().ICheck();
		}
	}

	// Token: 0x060002CC RID: 716 RVA: 0x0000E0D5 File Offset: 0x0000C2D5
	private void Click_Item_Find_Down(InputAction.CallbackContext value)
	{
		this.mouse_position_click_down = Mouse.current.position.ReadValue();
	}

	// Token: 0x060002CD RID: 717 RVA: 0x0000E0F4 File Offset: 0x0000C2F4
	private void Click_Item_Find_Up(InputAction.CallbackContext value)
	{
		if (Vector3.Distance(this.mouse_position_click_down, this.mouse_position) > 15f)
		{
			return;
		}
		RaycastHit raycastHit;
		if (!Physics.Raycast(this.camera_position, Camera.main.ScreenPointToRay(this.mouse_position).direction, out raycastHit))
		{
			return;
		}
		Iinteractive component = raycastHit.collider.GetComponent<Iinteractive>();
		if (component == null)
		{
			return;
		}
		component.IClick();
	}

	// Token: 0x0400039D RID: 925
	private Vector3 mouse_position_click_down;

	// Token: 0x0400039E RID: 926
	private InputAction Click_find_item;
}
