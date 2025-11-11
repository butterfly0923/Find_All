using System;
using System.Collections;
using System.IO;
using Steamworks;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

// Token: 0x0200004C RID: 76
public class DLC_manager : MonoBehaviour
{
	// Token: 0x060001FC RID: 508 RVA: 0x0000AAB2 File Offset: 0x00008CB2
	private void Awake()
	{
		DLC_manager.st = (DLC_manager)Set_Singleton.This<DLC_manager, DLC_manager>(this, DLC_manager.st);
	}

	// Token: 0x060001FD RID: 509 RVA: 0x0000AACC File Offset: 0x00008CCC
	private void OnEnable()
	{
		Button button = this.button_first_load_scene;
		if (button != null)
		{
			button.onClick.AddListener(new UnityAction(this.Load_Free));
		}
		Button button2 = this.button_first_load_scene_down_panel;
		if (button2 != null)
		{
			button2.onClick.AddListener(new UnityAction(this.Load_Free));
		}
		EA.DLC_open_Extra_level = (Action)Delegate.Combine(EA.DLC_open_Extra_level, new Action(this.DLC_Extra_level_check));
		Button button3 = this.button_dlc_extra_buy;
		if (button3 != null)
		{
			button3.onClick.AddListener(new UnityAction(this.DLC_Extra_level_button));
		}
		Button button4 = this.button_dlc_extra_buy_down_panel;
		if (button4 != null)
		{
			button4.onClick.AddListener(new UnityAction(this.DLC_Extra_level_button));
		}
		Button button5 = this.button_extra_open;
		if (button5 != null)
		{
			button5.onClick.AddListener(new UnityAction(this.Load_DLC));
		}
		Button button6 = this.button_extra_open_down_panel;
		if (button6 != null)
		{
			button6.onClick.AddListener(new UnityAction(this.Load_DLC));
		}
		Button button7 = this.big_button_update_dlc;
		if (button7 != null)
		{
			button7.onClick.AddListener(new UnityAction(this.DLC_update));
		}
		Button button8 = this.button_Coloring_Book_buy;
		if (button8 != null)
		{
			button8.onClick.AddListener(new UnityAction(this.DLC_Coloring_Book_button));
		}
		Button button9 = this.button_Coloring_Book_open;
		if (button9 == null)
		{
			return;
		}
		button9.onClick.AddListener(new UnityAction(this.Open_Coloring_Book));
	}

	// Token: 0x060001FE RID: 510 RVA: 0x0000AC2C File Offset: 0x00008E2C
	private void OnDisable()
	{
		Button button = this.button_first_load_scene;
		if (button != null)
		{
			button.onClick.RemoveListener(new UnityAction(this.Load_Free));
		}
		Button button2 = this.button_first_load_scene_down_panel;
		if (button2 != null)
		{
			button2.onClick.AddListener(new UnityAction(this.Load_Free));
		}
		EA.DLC_open_Extra_level = (Action)Delegate.Remove(EA.DLC_open_Extra_level, new Action(this.DLC_Extra_level_check));
		Button button3 = this.button_dlc_extra_buy;
		if (button3 != null)
		{
			button3.onClick.RemoveListener(new UnityAction(this.DLC_Extra_level_button));
		}
		Button button4 = this.button_dlc_extra_buy_down_panel;
		if (button4 != null)
		{
			button4.onClick.RemoveListener(new UnityAction(this.DLC_Extra_level_button));
		}
		Button button5 = this.button_extra_open;
		if (button5 != null)
		{
			button5.onClick.RemoveListener(new UnityAction(this.Load_DLC));
		}
		Button button6 = this.button_extra_open_down_panel;
		if (button6 != null)
		{
			button6.onClick.RemoveListener(new UnityAction(this.Load_DLC));
		}
		Button button7 = this.big_button_update_dlc;
		if (button7 != null)
		{
			button7.onClick.RemoveListener(new UnityAction(this.DLC_update));
		}
		Button button8 = this.button_Coloring_Book_buy;
		if (button8 != null)
		{
			button8.onClick.RemoveListener(new UnityAction(this.DLC_Coloring_Book_button));
		}
		Button button9 = this.button_Coloring_Book_open;
		if (button9 == null)
		{
			return;
		}
		button9.onClick.RemoveListener(new UnityAction(this.Open_Coloring_Book));
	}

	// Token: 0x060001FF RID: 511 RVA: 0x0000AD8A File Offset: 0x00008F8A
	[ContextMenu("Steam exit")]
	private void Steam_Exit()
	{
		SteamAPI.Shutdown();
		Debug.Log("Останавливает стим точно!");
	}

	// Token: 0x06000200 RID: 512 RVA: 0x0000AD9B File Offset: 0x00008F9B
	private void Start()
	{
		this.Set_level_button();
		this.DLC_Extra_level_check();
		if (this.big_go_button_update_dlc != null)
		{
			GameObject gameObject = this.big_go_button_update_dlc;
			if (gameObject == null)
			{
				return;
			}
			gameObject.SetActive(false);
		}
	}

	// Token: 0x06000201 RID: 513 RVA: 0x0000ADC8 File Offset: 0x00008FC8
	private void Set_level_button()
	{
		this.button_first_load_scene.gameObject.SetActive(this.Free_level);
		this.button_first_load_scene_down_panel.gameObject.SetActive(this.Free_level);
		this.button_dlc_extra_buy.gameObject.SetActive(!this.Free_level);
		this.button_extra_open.gameObject.SetActive(!this.Free_level);
		this.button_dlc_extra_buy_down_panel.gameObject.SetActive(!this.Free_level);
		this.button_extra_open_down_panel.gameObject.SetActive(!this.Free_level);
	}

	// Token: 0x06000202 RID: 514 RVA: 0x0000AE68 File Offset: 0x00009068
	private void DLC_Extra_level_check()
	{
		this.DLC_Extra_level_open = false;
		this.DLC_Coloring_Book_open = false;
		if (SteamManager.Initialized)
		{
			if (SteamApps.BIsDlcInstalled(DLC_manager.st.ID_Extra_level))
			{
				Debug.Log(string.Format("DLC с номером {0} установлен.", DLC_manager.st.ID_Extra_level));
				this.DLC_Extra_level_open = true;
			}
			else
			{
				Debug.Log(string.Format("DLC с номером {0} не установлен.", DLC_manager.st.ID_Extra_level));
				this.DLC_Extra_level_open = false;
			}
			bool flag = SteamApps.BIsDlcInstalled(DLC_manager.st.ID_Coloring_Book);
			if (SteamApps.BIsSubscribedApp(DLC_manager.st.ID_Coloring_Book))
			{
				Debug.Log(string.Format("DLC_Coloring_Book с номером {0} установлен.", DLC_manager.st.ID_Coloring_Book));
				this.DLC_Coloring_Book_open = true;
				if (!flag)
				{
					string text = this.FindGameDirectory();
					SteamApps.InstallDLC(this.ID_Coloring_Book);
					if (!Directory.Exists(text) && SteamApps.BIsSubscribedApp(DLC_manager.st.ID_Coloring_Book))
					{
						Debug.LogWarning(" Папка не найдена! Возможно, DLC не активирован. - " + text);
						SteamApps.InstallDLC(this.ID_Coloring_Book);
						this.DLC_Download_animation_start();
					}
				}
			}
			else
			{
				Debug.Log(string.Format("DLC_Coloring_Book с номером {0} не установлен.", DLC_manager.st.ID_Coloring_Book));
				this.DLC_Coloring_Book_open = false;
			}
		}
		else
		{
			Debug.LogWarning("Steam не инициализирован. Пожалуйста, запустите игру через Steam.");
		}
		if (this.Free_level)
		{
			this.button_first_load_scene.gameObject.SetActive(true);
			this.button_first_load_scene_down_panel.gameObject.SetActive(true);
			Button button = this.button_dlc_extra_buy;
			if (button != null)
			{
				button.gameObject.SetActive(false);
			}
			Button button2 = this.button_dlc_extra_buy_down_panel;
			if (button2 != null)
			{
				button2.gameObject.SetActive(false);
			}
			Button button3 = this.button_extra_open;
			if (button3 != null)
			{
				button3.gameObject.SetActive(false);
			}
			Button button4 = this.button_extra_open_down_panel;
			if (button4 != null)
			{
				button4.gameObject.SetActive(false);
			}
		}
		else
		{
			Button button5 = this.button_dlc_extra_buy;
			if (button5 != null)
			{
				button5.gameObject.SetActive(!this.DLC_Extra_level_open);
			}
			Button button6 = this.button_dlc_extra_buy_down_panel;
			if (button6 != null)
			{
				button6.gameObject.SetActive(!this.DLC_Extra_level_open);
			}
			Button button7 = this.button_extra_open;
			if (button7 != null)
			{
				button7.gameObject.SetActive(this.DLC_Extra_level_open);
			}
			Button button8 = this.button_extra_open_down_panel;
			if (button8 != null)
			{
				button8.gameObject.SetActive(this.DLC_Extra_level_open);
			}
		}
		Button button9 = this.button_Coloring_Book_buy;
		if (button9 != null)
		{
			button9.gameObject.SetActive(!this.DLC_Coloring_Book_open);
		}
		Button button10 = this.button_Coloring_Book_open;
		if (button10 == null)
		{
			return;
		}
		button10.gameObject.SetActive(this.DLC_Coloring_Book_open);
	}

	// Token: 0x06000203 RID: 515 RVA: 0x0000B0F0 File Offset: 0x000092F0
	public void DLC_Extra_level_button()
	{
		Debug.Log(this.ID_Extra_level);
		if (SteamManager.Initialized)
		{
			if (SteamApps.BIsDlcInstalled(this.ID_Extra_level))
			{
				Debug.Log(string.Format("DLC с номером {0} установлен.", this.ID_Extra_level));
				this.DLC_Extra_level_check();
				return;
			}
			Debug.Log(string.Format("DLC с номером {0} не установлен.", this.ID_Extra_level));
			string str = "https://store.steampowered.com/app/";
			AppId_t id_Extra_level = this.ID_Extra_level;
			SteamFriends.ActivateGameOverlayToWebPage(str + id_Extra_level.ToString(), EActivateGameOverlayToWebPageMode.k_EActivateGameOverlayToWebPageMode_Default);
			if (this.big_go_button_update_dlc != null)
			{
				GameObject gameObject = this.big_go_button_update_dlc;
				if (gameObject == null)
				{
					return;
				}
				gameObject.SetActive(true);
				return;
			}
		}
		else
		{
			string str2 = "https://store.steampowered.com/app/";
			AppId_t id_Extra_level = this.ID_Extra_level;
			Application.OpenURL(str2 + id_Extra_level.ToString());
		}
	}

	// Token: 0x06000204 RID: 516 RVA: 0x0000B1C8 File Offset: 0x000093C8
	public void DLC_Coloring_Book_button()
	{
		Debug.Log(this.ID_Coloring_Book);
		if (SteamManager.Initialized)
		{
			if (SteamApps.BIsSubscribedApp(this.ID_Coloring_Book))
			{
				Debug.Log(string.Format("DLC Coloring Book с номером {0} установлен.", this.ID_Coloring_Book));
				this.DLC_Extra_level_check();
				return;
			}
			Debug.Log(string.Format("DLC Coloring Book с номером {0} не установлен.", this.ID_Coloring_Book));
			string str = "https://store.steampowered.com/app/";
			AppId_t id_Coloring_Book = this.ID_Coloring_Book;
			SteamFriends.ActivateGameOverlayToWebPage(str + id_Coloring_Book.ToString(), EActivateGameOverlayToWebPageMode.k_EActivateGameOverlayToWebPageMode_Default);
			if (this.big_go_button_update_dlc != null)
			{
				GameObject gameObject = this.big_go_button_update_dlc;
				if (gameObject == null)
				{
					return;
				}
				gameObject.SetActive(true);
				return;
			}
		}
		else
		{
			string str2 = "https://store.steampowered.com/app/";
			AppId_t id_Coloring_Book = this.ID_Coloring_Book;
			Application.OpenURL(str2 + id_Coloring_Book.ToString());
		}
	}

	// Token: 0x06000205 RID: 517 RVA: 0x0000B29E File Offset: 0x0000949E
	public void DLC_update()
	{
		if (this.big_go_button_update_dlc != null)
		{
			GameObject gameObject = this.big_go_button_update_dlc;
			if (gameObject != null)
			{
				gameObject.SetActive(false);
			}
		}
		this.DLC_Extra_level_check();
	}

	// Token: 0x06000206 RID: 518 RVA: 0x0000B2C6 File Offset: 0x000094C6
	public void Load_Free()
	{
		Debug.Log("Scene_load_event - 0");
		Action<int> scene_load_event = EA.Scene_load_event;
		if (scene_load_event == null)
		{
			return;
		}
		scene_load_event(0);
	}

	// Token: 0x06000207 RID: 519 RVA: 0x0000B2E2 File Offset: 0x000094E2
	public void Load_DLC()
	{
		Debug.Log("Scene_load_event - 1");
		Action<int> scene_load_event = EA.Scene_load_event;
		if (scene_load_event == null)
		{
			return;
		}
		scene_load_event(1);
	}

	// Token: 0x06000208 RID: 520 RVA: 0x0000B300 File Offset: 0x00009500
	public void Open_Coloring_Book()
	{
		string text = this.FindGameDirectory();
		Debug.Log(text ?? "");
		if (Directory.Exists(text))
		{
			Application.OpenURL(text);
			return;
		}
		if (SteamApps.BIsSubscribedApp(DLC_manager.st.ID_Coloring_Book))
		{
			Debug.LogWarning(" Папка не найдена! Возможно, DLC не активирован. - " + text);
			SteamApps.InstallDLC(this.ID_Coloring_Book);
			this.DLC_Download_animation_start();
		}
	}

	// Token: 0x06000209 RID: 521 RVA: 0x0000B364 File Offset: 0x00009564
	private string FindGameDirectory()
	{
		return Path.GetDirectoryName(Path.GetDirectoryName(Application.dataPath)) + "/Coloring Book/";
	}

	// Token: 0x0600020A RID: 522 RVA: 0x0000B37F File Offset: 0x0000957F
	private void DLC_Download_animation_start()
	{
		base.StartCoroutine(this.IE_Check_end_down_load());
		if (this.coroutine != null)
		{
			base.StopCoroutine(this.coroutine);
		}
		this.coroutine = base.StartCoroutine(this.IE_BlinkRoutine());
	}

	// Token: 0x0600020B RID: 523 RVA: 0x0000B3B4 File Offset: 0x000095B4
	private IEnumerator IE_Check_end_down_load()
	{
		int check_test_time = 30;
		while (check_test_time > 0)
		{
			check_test_time--;
			yield return new WaitForSeconds(3f);
			if (SteamApps.BIsDlcInstalled(DLC_manager.st.ID_Coloring_Book) && SteamApps.BIsSubscribedApp(DLC_manager.st.ID_Coloring_Book))
			{
				this.DLC_Download_animation_end();
				break;
			}
		}
		yield break;
	}

	// Token: 0x0600020C RID: 524 RVA: 0x0000B3C3 File Offset: 0x000095C3
	private void DLC_Download_animation_end()
	{
		if (this.coroutine != null)
		{
			base.StopCoroutine(this.coroutine);
		}
		this.coroutine = base.StartCoroutine(this.IE_Alpha_end());
	}

	// Token: 0x0600020D RID: 525 RVA: 0x0000B3EB File Offset: 0x000095EB
	private IEnumerator IE_BlinkRoutine()
	{
		float timer = 0f;
		for (;;)
		{
			timer += Time.deltaTime * this.blinkSpeed;
			for (int i = 0; i < this.images.Length; i++)
			{
				this.images[i].color = new Color(this.images[i].color.r, this.images[i].color.g, this.images[i].color.b, this.fadeCurve.Evaluate(timer - (float)i));
			}
			yield return new WaitForSeconds(Time.deltaTime);
		}
		yield break;
	}

	// Token: 0x0600020E RID: 526 RVA: 0x0000B3FA File Offset: 0x000095FA
	private IEnumerator IE_Alpha_end()
	{
		for (;;)
		{
			for (int i = 0; i < this.images.Length; i++)
			{
				float a = this.images[i].color.a - Time.deltaTime * this.blinkSpeed;
				this.images[i].color = new Color(this.images[i].color.r, this.images[i].color.g, this.images[i].color.b, a);
			}
			yield return new WaitForSeconds(Time.deltaTime);
		}
		yield break;
	}

	// Token: 0x0400023C RID: 572
	[SerializeField]
	private bool Free_level;

	// Token: 0x0400023D RID: 573
	[SerializeField]
	private Button button_first_load_scene;

	// Token: 0x0400023E RID: 574
	[SerializeField]
	private Button button_first_load_scene_down_panel;

	// Token: 0x0400023F RID: 575
	[Header("DLC:")]
	[SerializeField]
	private bool DLC_Extra_level_open;

	// Token: 0x04000240 RID: 576
	[SerializeField]
	private Button button_dlc_extra_buy;

	// Token: 0x04000241 RID: 577
	[SerializeField]
	private Button button_extra_open;

	// Token: 0x04000242 RID: 578
	[SerializeField]
	private Button button_dlc_extra_buy_down_panel;

	// Token: 0x04000243 RID: 579
	[SerializeField]
	private Button button_extra_open_down_panel;

	// Token: 0x04000244 RID: 580
	[SerializeField]
	private GameObject big_go_button_update_dlc;

	// Token: 0x04000245 RID: 581
	[SerializeField]
	private Button big_button_update_dlc;

	// Token: 0x04000246 RID: 582
	[Header("DLC Coloring Book:")]
	[SerializeField]
	private bool DLC_Coloring_Book_open;

	// Token: 0x04000247 RID: 583
	[SerializeField]
	private Button button_Coloring_Book_buy;

	// Token: 0x04000248 RID: 584
	[SerializeField]
	private Button button_Coloring_Book_open;

	// Token: 0x04000249 RID: 585
	[Header("Настройки ссылки DLC_Extra:")]
	[SerializeField]
	public AppId_t ID_Extra_level;

	// Token: 0x0400024A RID: 586
	[Header("Настройки ссылки DLC_Coloring_Book:")]
	[SerializeField]
	public AppId_t ID_Coloring_Book;

	// Token: 0x0400024B RID: 587
	public static DLC_manager st;

	// Token: 0x0400024C RID: 588
	[Header("Настройки мигания")]
	public Image[] images;

	// Token: 0x0400024D RID: 589
	public float blinkSpeed = 1f;

	// Token: 0x0400024E RID: 590
	public AnimationCurve fadeCurve;

	// Token: 0x0400024F RID: 591
	private Coroutine coroutine;
}
