using System;
using UnityEngine;

// Token: 0x02000045 RID: 69
public class Load_Scene_old_game : MonoBehaviour
{
	// Token: 0x060001C5 RID: 453 RVA: 0x00009D69 File Offset: 0x00007F69
	public void New_Version()
	{
		Action<int> scene_load_event = EA.Scene_load_event;
		if (scene_load_event == null)
		{
			return;
		}
		scene_load_event(0);
	}

	// Token: 0x060001C6 RID: 454 RVA: 0x00009D7B File Offset: 0x00007F7B
	public void Old_Version()
	{
		Action<int> scene_load_event = EA.Scene_load_event;
		if (scene_load_event == null)
		{
			return;
		}
		scene_load_event(2);
	}
}
