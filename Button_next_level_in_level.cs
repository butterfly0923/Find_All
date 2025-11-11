using System;
using UnityEngine;

// Token: 0x0200002A RID: 42
public class Button_next_level_in_level : MonoBehaviour
{
	// Token: 0x06000114 RID: 276 RVA: 0x0000755B File Offset: 0x0000575B
	public void Next_level_button()
	{
		Events_Menu_UI.level_load_map = true;
		Scene_load.st.Load_next_scene(this.Next_scene_name);
		Debug.Log("Переход на следующую сцену - " + this.Next_scene_name);
	}

	// Token: 0x04000126 RID: 294
	[SerializeField]
	private string Next_scene_name;
}
