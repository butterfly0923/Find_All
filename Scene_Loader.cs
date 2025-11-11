using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// Token: 0x0200009F RID: 159
public class Scene_Loader : MonoBehaviour
{
	// Token: 0x0600046C RID: 1132 RVA: 0x00014FE7 File Offset: 0x000131E7
	private void Awake()
	{
		Object.DontDestroyOnLoad(base.gameObject);
		Scene_Loader.st = (Scene_Loader)Set_Singleton.Another<Scene_Loader, Scene_Loader>(this, Scene_Loader.st);
	}

	// Token: 0x0600046D RID: 1133 RVA: 0x00015009 File Offset: 0x00013209
	[ContextMenu("Start")]
	private void Start()
	{
		base.StartCoroutine(this.IE_Black_alpha_off());
	}

	// Token: 0x0600046E RID: 1134 RVA: 0x00015018 File Offset: 0x00013218
	private void OnEnable()
	{
		EA.Scene_load_event = (Action<int>)Delegate.Combine(EA.Scene_load_event, new Action<int>(this.Load_level_index));
		EA.Exit_game = (Action)Delegate.Combine(EA.Exit_game, new Action(delegate()
		{
			base.StartCoroutine(this.IE_Exit_game());
		}));
		EA.Load_level = (Action)Delegate.Combine(EA.Load_level, new Action(delegate()
		{
			base.StartCoroutine(this.IE_Load_level());
		}));
		SceneManager.sceneLoaded += delegate(Scene scene, LoadSceneMode mode)
		{
			base.StartCoroutine(this.IE_Black_alpha_off());
		};
	}

	// Token: 0x0600046F RID: 1135 RVA: 0x00015098 File Offset: 0x00013298
	private void OnDisable()
	{
		EA.Scene_load_event = (Action<int>)Delegate.Remove(EA.Scene_load_event, new Action<int>(this.Load_level_index));
		EA.Exit_game = (Action)Delegate.Remove(EA.Exit_game, new Action(delegate
		{
			base.StartCoroutine(this.IE_Exit_game());
		}));
		EA.Load_level = (Action)Delegate.Remove(EA.Load_level, new Action(delegate
		{
			base.StartCoroutine(this.IE_Load_level());
		}));
		SceneManager.sceneLoaded -= delegate(Scene scene, LoadSceneMode mode)
		{
			base.StartCoroutine(this.IE_Black_alpha_off());
		};
	}

	// Token: 0x06000470 RID: 1136 RVA: 0x00015116 File Offset: 0x00013316
	private IEnumerator IE_Load_level()
	{
		Debug.Log("SL_Data.d_Game.load_level - " + SL_Data.d_Game.load_level.ToString());
		Action end_scene = EA.End_scene;
		if (end_scene != null)
		{
			end_scene();
		}
		SL_Data.st.Save_Setting();
		SL_Data.st.Save_Game();
		yield return base.StartCoroutine(this.IE_Black_alpha_on());
		SceneManager.LoadScene(this.scenes_data.RT_name_scene(SL_Data.d_Game.load_level));
		yield break;
	}

	// Token: 0x06000471 RID: 1137 RVA: 0x00015125 File Offset: 0x00013325
	private IEnumerator IE_Exit_game()
	{
		SL_Data.st.Save_Setting();
		SL_Data.st.Save_Game();
		yield return base.StartCoroutine(this.IE_Black_alpha_on());
		Debug.Log("Выход из игры произошёл");
		Application.Quit();
		yield break;
	}

	// Token: 0x06000472 RID: 1138 RVA: 0x00015134 File Offset: 0x00013334
	private void Load_level_index(int i)
	{
		Debug.Log(string.Format("SL_Data.d_Game.load_level = {0}", i));
		SL_Data.d_Game.load_level = i;
		base.StartCoroutine(this.IE_Load_level());
	}

	// Token: 0x06000473 RID: 1139 RVA: 0x00015163 File Offset: 0x00013363
	public void Load_Free_Scene()
	{
		SL_Data.d_Game.load_level = 0;
		base.StartCoroutine(this.IE_Load_level());
	}

	// Token: 0x06000474 RID: 1140 RVA: 0x0001517D File Offset: 0x0001337D
	public void Load_DLC_Scene()
	{
		SL_Data.d_Game.load_level = 1;
		base.StartCoroutine(this.IE_Load_level());
	}

	// Token: 0x06000475 RID: 1141 RVA: 0x00015197 File Offset: 0x00013397
	public void Load_DLC_2_Scene()
	{
		SL_Data.d_Game.load_level = 2;
		base.StartCoroutine(this.IE_Load_level());
	}

	// Token: 0x06000476 RID: 1142 RVA: 0x000151B1 File Offset: 0x000133B1
	private IEnumerator IE_Black_alpha_on()
	{
		this.black_front.enabled = true;
		Color color_value = this.black_front.color;
		float value = 0f;
		while (value < 1f)
		{
			color_value.a = this.alpha_black_on.Evaluate(value);
			this.black_front.color = color_value;
			value += Time.deltaTime / this.delay_black_on;
			yield return new WaitForSeconds(Time.deltaTime);
		}
		color_value.a = this.alpha_black_on.Evaluate(1f);
		this.black_front.color = color_value;
		yield break;
	}

	// Token: 0x06000477 RID: 1143 RVA: 0x000151C0 File Offset: 0x000133C0
	private IEnumerator IE_Black_alpha_off()
	{
		this.black_front.enabled = true;
		Color color_value = this.black_front.color;
		float value = 1f;
		while (value > 0f)
		{
			color_value.a = this.alpha_black_off.Evaluate(value);
			this.black_front.color = color_value;
			value -= Time.deltaTime / this.delay_black_off;
			yield return new WaitForSeconds(Time.deltaTime);
		}
		color_value.a = this.alpha_black_off.Evaluate(0f);
		this.black_front.color = color_value;
		this.black_front.enabled = false;
		yield break;
	}

	// Token: 0x040004A4 RID: 1188
	[SerializeField]
	private Image black_front;

	// Token: 0x040004A5 RID: 1189
	[SerializeField]
	private AnimationCurve alpha_black_on;

	// Token: 0x040004A6 RID: 1190
	[SerializeField]
	private AnimationCurve alpha_black_off;

	// Token: 0x040004A7 RID: 1191
	[SerializeField]
	private float delay_black_on;

	// Token: 0x040004A8 RID: 1192
	[SerializeField]
	private float delay_black_off;

	// Token: 0x040004A9 RID: 1193
	[SerializeField]
	private Scenes_Data scenes_data;

	// Token: 0x040004AA RID: 1194
	public static Scene_Loader st;
}
