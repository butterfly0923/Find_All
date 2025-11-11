using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x0200003C RID: 60
public class Start_Level_Manager : MonoBehaviour
{
	// Token: 0x0600019D RID: 413 RVA: 0x00009685 File Offset: 0x00007885
	private void Start()
	{
		SceneManager.LoadScene(this.levels_name[SL_Data.d_Game.current_level]);
	}

	// Token: 0x040001A6 RID: 422
	[SerializeField]
	private string[] levels_name;
}
