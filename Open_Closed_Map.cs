using System;
using UnityEngine;
using UnityEngine.InputSystem;

// Token: 0x02000021 RID: 33
public class Open_Closed_Map : MonoBehaviour
{
	// Token: 0x060000AE RID: 174 RVA: 0x000061C0 File Offset: 0x000043C0
	private void Awake()
	{
		this.escape = Sa_IS.input_Main.Map.Escape;
	}

	// Token: 0x060000AF RID: 175 RVA: 0x000061E5 File Offset: 0x000043E5
	private void OnEnable()
	{
		this.escape.started += this.Closed_Map_Key;
	}

	// Token: 0x060000B0 RID: 176 RVA: 0x000061FE File Offset: 0x000043FE
	private void OnDisable()
	{
		this.escape.started += this.Closed_Map_Key;
	}

	// Token: 0x060000B1 RID: 177 RVA: 0x00006217 File Offset: 0x00004417
	private void Open_Map(bool menu_or_level)
	{
		Sa_IS.Active_Input_map(Sa_IS.input_Main.Void, true);
		this.open_menu_or_level = menu_or_level;
		this.map_scroll.Scroll_On_Off(true);
	}

	// Token: 0x060000B2 RID: 178 RVA: 0x00006241 File Offset: 0x00004441
	private void Closed_Map_Key(InputAction.CallbackContext cc)
	{
		this.Closed_Map();
	}

	// Token: 0x060000B3 RID: 179 RVA: 0x00006249 File Offset: 0x00004449
	public void Closed_Map()
	{
		this.map_scroll.Scroll_On_Off(false);
	}

	// Token: 0x060000B4 RID: 180 RVA: 0x00006257 File Offset: 0x00004457
	public void Map_Open_Finish()
	{
	}

	// Token: 0x060000B5 RID: 181 RVA: 0x00006259 File Offset: 0x00004459
	public void Map_Closed_Finish()
	{
		bool flag = this.open_menu_or_level;
	}

	// Token: 0x040000A6 RID: 166
	[SerializeField]
	private bool open_menu_or_level;

	// Token: 0x040000A7 RID: 167
	[SerializeField]
	private Main_Menu_Open_Closed map_scroll;

	// Token: 0x040000A8 RID: 168
	[SerializeField]
	private Main_Menu_Open_Closed menu_scroll;

	// Token: 0x040000A9 RID: 169
	private InputAction escape;
}
