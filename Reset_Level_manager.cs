using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

// Token: 0x020000A1 RID: 161
public class Reset_Level_manager : MonoBehaviour
{
	// Token: 0x0600048E RID: 1166 RVA: 0x00015B64 File Offset: 0x00013D64
	private void Awake()
	{
		Reset_Level_manager.st = (Reset_Level_manager)Set_Singleton.This<Reset_Level_manager, Reset_Level_manager>(this, Reset_Level_manager.st);
		this.escape = Sa_IS.input_Main.am_map_reset.escape;
	}

	// Token: 0x0600048F RID: 1167 RVA: 0x00015BA0 File Offset: 0x00013DA0
	private void OnEnable()
	{
		this.escape.started += this.no_reset;
		this.yes_reset_button.onClick.AddListener(delegate()
		{
			base.StartCoroutine(this.IE_yes_reset());
		});
		this.no_reset_button.onClick.AddListener(delegate()
		{
			base.StartCoroutine(this.IE_no_reset());
		});
		EA.Reset_level_check = (Action)Delegate.Combine(EA.Reset_level_check, new Action(this.reset_level_window_open));
	}

	// Token: 0x06000490 RID: 1168 RVA: 0x00015C1C File Offset: 0x00013E1C
	private void OnDisable()
	{
		this.escape.started -= this.no_reset;
		this.yes_reset_button.onClick.RemoveListener(delegate()
		{
			base.StartCoroutine(this.IE_yes_reset());
		});
		this.no_reset_button.onClick.RemoveListener(delegate()
		{
			base.StartCoroutine(this.IE_no_reset());
		});
		EA.Reset_level_check = (Action)Delegate.Remove(EA.Reset_level_check, new Action(this.reset_level_window_open));
	}

	// Token: 0x06000491 RID: 1169 RVA: 0x00015C98 File Offset: 0x00013E98
	private void reset_level_window_open()
	{
		base.StartCoroutine(this.IE_reset_level_window_open());
	}

	// Token: 0x06000492 RID: 1170 RVA: 0x00015CA7 File Offset: 0x00013EA7
	private IEnumerator IE_reset_level_window_open()
	{
		Sa_IS.Active_Input_map(Sa_IS.input_Main.am_void, true);
		yield return base.StartCoroutine(this.ui_reset.IE_Panel_On());
		Sa_IS.Active_Input_map(Sa_IS.input_Main.am_map_reset, true);
		yield break;
	}

	// Token: 0x06000493 RID: 1171 RVA: 0x00015CB6 File Offset: 0x00013EB6
	private IEnumerator IE_yes_reset()
	{
		Action reset_level = EA.Reset_level;
		if (reset_level != null)
		{
			reset_level();
		}
		Sa_IS.Active_Input_map(Sa_IS.input_Main.am_void, true);
		yield return base.StartCoroutine(this.ui_reset.IE_Panel_Off());
		yield break;
	}

	// Token: 0x06000494 RID: 1172 RVA: 0x00015CC5 File Offset: 0x00013EC5
	private void no_reset(InputAction.CallbackContext cc)
	{
		base.StartCoroutine(this.IE_no_reset());
	}

	// Token: 0x06000495 RID: 1173 RVA: 0x00015CD4 File Offset: 0x00013ED4
	private IEnumerator IE_no_reset()
	{
		Sa_IS.Active_Input_map(Sa_IS.input_Main.am_void, true);
		yield return base.StartCoroutine(this.ui_reset.IE_Panel_Off());
		Sa_IS.Active_Input_map(Sa_IS.input_Main.am_menu, true);
		yield break;
	}

	// Token: 0x040004B0 RID: 1200
	[SerializeField]
	private UI_Panel_Alpha ui_reset;

	// Token: 0x040004B1 RID: 1201
	[SerializeField]
	private Button yes_reset_button;

	// Token: 0x040004B2 RID: 1202
	[SerializeField]
	private Button no_reset_button;

	// Token: 0x040004B3 RID: 1203
	private InputAction escape;

	// Token: 0x040004B4 RID: 1204
	public static Reset_Level_manager st;
}
