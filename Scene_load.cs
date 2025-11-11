using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// Token: 0x02000031 RID: 49
public class Scene_load : MonoBehaviour
{
	// Token: 0x06000157 RID: 343 RVA: 0x0000851A File Offset: 0x0000671A
	private void Awake()
	{
		if (Scene_load.st != null)
		{
			Object.Destroy(Scene_load.st.gameObject);
		}
		Scene_load.st = this;
	}

	// Token: 0x06000158 RID: 344 RVA: 0x0000853E File Offset: 0x0000673E
	public void Load_next_scene(string name_scene)
	{
		base.StartCoroutine(this.IE_load_scene(name_scene));
	}

	// Token: 0x06000159 RID: 345 RVA: 0x0000854E File Offset: 0x0000674E
	private IEnumerator IE_load_scene(string name_scene)
	{
		this.front_black_block.enabled = true;
		Sa_IS.Active_Input_map(Sa_IS.input_Main.Void, true);
		Music_controller.st.load_new_scene_music_false(this.speed);
		Color color_value = this.front_black_block.color;
		while (color_value.a <= 1f)
		{
			color_value.a += Time.deltaTime * this.speed;
			this.front_black_block.color = color_value;
			yield return new WaitForFixedUpdate();
		}
		SceneManager.LoadScene(name_scene);
		yield break;
	}

	// Token: 0x04000168 RID: 360
	[SerializeField]
	private Image front_black_block;

	// Token: 0x04000169 RID: 361
	[SerializeField]
	private float speed;

	// Token: 0x0400016A RID: 362
	public static Scene_load st;
}
