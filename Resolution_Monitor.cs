using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

// Token: 0x02000034 RID: 52
public class Resolution_Monitor : MonoBehaviour, IUpdateLanguage
{
	// Token: 0x14000002 RID: 2
	// (add) Token: 0x0600016B RID: 363 RVA: 0x000089F8 File Offset: 0x00006BF8
	// (remove) Token: 0x0600016C RID: 364 RVA: 0x00008A2C File Offset: 0x00006C2C
	public static event Resolution_Monitor.E_Graphics_update e_Graphics_update;

	// Token: 0x0600016D RID: 365 RVA: 0x00008A60 File Offset: 0x00006C60
	private void language_setting()
	{
		this.dropdown_languages.ClearOptions();
		this.optionsData_languages.Clear();
		if (SL_Data.d_Setting.Language_name_Setting != "english")
		{
			this.languages_dropdown_setting_flag = true;
		}
		for (int i = 0; i < this.language_name.Count; i++)
		{
			this.optionData_languages = new TMP_Dropdown.OptionData();
			this.optionData_languages.text = this.language_name[i].language_name;
			this.optionsData_languages.Add(this.optionData_languages);
		}
		this.dropdown_languages.AddOptions(this.optionsData_languages);
		for (int j = 0; j < this.language_name.Count; j++)
		{
			if (SL_Data.d_Setting.Language_name_Setting == this.language_name[j].language_steam)
			{
				this.dropdown_languages.value = j;
				return;
			}
		}
	}

	// Token: 0x0600016E RID: 366 RVA: 0x00008B44 File Offset: 0x00006D44
	public void Language_update(int I)
	{
		Debug.Log("Languages_update " + I.ToString() + " - " + this.languages_dropdown_setting_flag.ToString());
		if (!this.languages_dropdown_setting_flag)
		{
			Language_controller.st.Language_update_index(I);
		}
		else
		{
			this.languages_dropdown_setting_flag = false;
		}
		Debug.Log("Languages_update LAST" + I.ToString() + " - " + this.resolution_dropdown_setting_flag.ToString());
		SL_Data.st.Save_Setting();
	}

	// Token: 0x0600016F RID: 367 RVA: 0x00008BC3 File Offset: 0x00006DC3
	private void Awake()
	{
	}

	// Token: 0x06000170 RID: 368 RVA: 0x00008BC5 File Offset: 0x00006DC5
	private void OnEnable()
	{
		EA.Update_Language = (Action)Delegate.Combine(EA.Update_Language, new Action(this.Update_Language));
	}

	// Token: 0x06000171 RID: 369 RVA: 0x00008BE8 File Offset: 0x00006DE8
	private void OnDisable()
	{
		EA.Update_Language = (Action)Delegate.Combine(EA.Update_Language, new Action(this.Update_Language));
	}

	// Token: 0x06000172 RID: 370 RVA: 0x00008C0B File Offset: 0x00006E0B
	public void Update_Language()
	{
		this.screen_mode_setting();
	}

	// Token: 0x06000173 RID: 371 RVA: 0x00008C13 File Offset: 0x00006E13
	private void Start()
	{
		this.resolution_setting();
		this.screen_mode_setting();
	}

	// Token: 0x06000174 RID: 372 RVA: 0x00008C24 File Offset: 0x00006E24
	private void resolution_setting()
	{
		this.dropdown_resolution.ClearOptions();
		this.optionsData_resolution.Clear();
		if (SL_Data.d_Setting.ResolutionMonitor_Setting != 0)
		{
			this.resolution_dropdown_setting_flag = true;
		}
		this.resolutions = Screen.resolutions;
		for (int i = 0; i < this.resolutions.Length; i++)
		{
			this.resolutions_list.Add(new Vector2((float)this.resolutions[i].width, (float)this.resolutions[i].height));
		}
		for (int j = this.resolutions_list.Count - 1; j >= 0; j--)
		{
			if (!this.remote_resolution_variants.Contains(this.resolutions_list[j]))
			{
				this.remote_resolution_variants.Add(this.resolutions_list[j]);
				this.resolution_variants.Add(this.resolutions_list[j]);
				List<string> list = this.resolution_texts;
				Vector2 vector = this.resolutions_list[j];
				string str = vector.x.ToString();
				string str2 = " x ";
				vector = this.resolutions_list[j];
				list.Add(str + str2 + vector.y.ToString());
			}
		}
		for (int k = 0; k < this.resolution_variants.Count; k++)
		{
			this.optionData_resolution = new TMP_Dropdown.OptionData();
			this.optionData_resolution.text = this.resolution_texts[k];
			this.optionsData_resolution.Add(this.optionData_resolution);
		}
		this.dropdown_resolution.AddOptions(this.optionsData_resolution);
		Resolution_Monitor.Resolution_monitor_count = this.resolution_variants.Count;
		this.dropdown_resolution.value = SL_Data.d_Setting.ResolutionMonitor_Setting;
	}

	// Token: 0x06000175 RID: 373 RVA: 0x00008DD8 File Offset: 0x00006FD8
	[ContextMenu("screen_mode_setting")]
	private void screen_mode_setting()
	{
		this.dropdown_screenMode.ClearOptions();
		this.optionsData_screenMode = new List<TMP_Dropdown.OptionData>();
		for (int i = 0; i < this.Language_screen_mode_variant.Length; i++)
		{
			this.optionData_screenMode = new TMP_Dropdown.OptionData();
			this.optionData_screenMode.text = Localization_manager.st.LocalizationData.RT_local_text(this.Language_screen_mode_variant[i].Screen_mode_enum);
			this.optionsData_screenMode.Add(this.optionData_screenMode);
		}
		this.dropdown_screenMode.AddOptions(this.optionsData_screenMode);
		if (SL_Data.d_Setting.FullScreenMode_Setting != 0)
		{
			this.screenMode_dropdown_setting_flag = true;
		}
		this.dropdown_screenMode.value = SL_Data.d_Setting.FullScreenMode_Setting;
	}

	// Token: 0x06000176 RID: 374 RVA: 0x00008E90 File Offset: 0x00007090
	public void ScreenMode_Update(int I)
	{
		if (!this.screenMode_dropdown_setting_flag)
		{
			SL_Data.d_Setting.FullScreenMode_Setting = I;
			Screen.SetResolution((int)this.resolution_variants[SL_Data.d_Setting.ResolutionMonitor_Setting].x, (int)this.resolution_variants[SL_Data.d_Setting.ResolutionMonitor_Setting].y, this.Language_screen_mode_variant[SL_Data.d_Setting.FullScreenMode_Setting].Screen_mode);
			Debug.Log(string.Concat(new string[]
			{
				this.Language_screen_mode_variant[SL_Data.d_Setting.FullScreenMode_Setting].Screen_mode.ToString(),
				" - ScreenMode_update ",
				I.ToString(),
				" - ",
				this.screenMode_dropdown_setting_flag.ToString()
			}));
		}
		else
		{
			this.screenMode_dropdown_setting_flag = false;
		}
		Debug.Log("ScreenMode_update LAST " + I.ToString() + " - " + this.screenMode_dropdown_setting_flag.ToString());
		SL_Data.st.Save_Setting();
	}

	// Token: 0x06000177 RID: 375 RVA: 0x00008FA4 File Offset: 0x000071A4
	public void Resolution_update(int I)
	{
		Debug.Log("Resolution_update " + I.ToString() + " - " + this.resolution_dropdown_setting_flag.ToString());
		if (!this.resolution_dropdown_setting_flag)
		{
			SL_Data.d_Setting.ResolutionMonitor_Setting = I;
			Screen.SetResolution((int)this.resolution_variants[SL_Data.d_Setting.ResolutionMonitor_Setting].x, (int)this.resolution_variants[SL_Data.d_Setting.ResolutionMonitor_Setting].y, this.Language_screen_mode_variant[SL_Data.d_Setting.FullScreenMode_Setting].Screen_mode);
		}
		else
		{
			this.resolution_dropdown_setting_flag = false;
		}
		Debug.Log("Resolution_update LAST" + I.ToString() + " - " + this.resolution_dropdown_setting_flag.ToString());
		SL_Data.st.Save_Setting();
	}

	// Token: 0x06000178 RID: 376 RVA: 0x00009078 File Offset: 0x00007278
	public void Speed_interface_Update(int I)
	{
		Debug.Log("Speed_interface_update " + I.ToString() + " - " + this.speed_interface_dropdown_setting_flag.ToString());
		if (!this.speed_interface_dropdown_setting_flag)
		{
			SL_Data.d_Setting.Speed_interface = I;
			SL_Data.d_Setting.Speed_scroll = this.speed_menu_game[I].speed_menu;
			SL_Data.d_Setting.Speed_UI = this.speed_menu_game[I].speed_menu;
			SL_Data.d_Setting.Speed_cards_UI = this.speed_menu_game[I].speed_ui_game;
			SL_Data.d_Setting.Momental_speed_UI = (I >= this.speed_menu_game.Length - 1);
		}
		else
		{
			this.speed_interface_dropdown_setting_flag = false;
		}
		Debug.Log("Speed_interface_update LAST " + I.ToString() + " - " + this.speed_interface_dropdown_setting_flag.ToString());
		SL_Data.st.Save_Setting();
	}

	// Token: 0x04000173 RID: 371
	private Resolution[] resolutions;

	// Token: 0x04000174 RID: 372
	[Header("Разрешения мониторов которые требуется удалить из списка:")]
	[SerializeField]
	private List<Vector2> remote_resolution_variants;

	// Token: 0x04000175 RID: 373
	private List<Vector2> resolutions_list = new List<Vector2>();

	// Token: 0x04000176 RID: 374
	private List<Vector2> resolution_variants = new List<Vector2>();

	// Token: 0x04000177 RID: 375
	private List<string> resolution_texts = new List<string>();

	// Token: 0x04000178 RID: 376
	[Header("Выпадающее меню разрешений экрана:")]
	[SerializeField]
	private TMP_Dropdown dropdown_resolution;

	// Token: 0x04000179 RID: 377
	private TMP_Dropdown.OptionData optionData_resolution;

	// Token: 0x0400017A RID: 378
	private List<TMP_Dropdown.OptionData> optionsData_resolution = new List<TMP_Dropdown.OptionData>();

	// Token: 0x0400017B RID: 379
	private bool resolution_dropdown_setting_flag;

	// Token: 0x0400017C RID: 380
	public static int Resolution_monitor_count;

	// Token: 0x0400017D RID: 381
	[Header("Выпадающее меню модификаторов окна:")]
	[SerializeField]
	private TMP_Dropdown dropdown_screenMode;

	// Token: 0x0400017E RID: 382
	private TMP_Dropdown.OptionData optionData_screenMode;

	// Token: 0x0400017F RID: 383
	private List<TMP_Dropdown.OptionData> optionsData_screenMode;

	// Token: 0x04000180 RID: 384
	private bool screenMode_dropdown_setting_flag;

	// Token: 0x04000181 RID: 385
	[Header("Настройки локализации модификаторов окна:")]
	[SerializeField]
	private Resolution_Monitor.Screen_mode_variant[] Language_screen_mode_variant;

	// Token: 0x04000182 RID: 386
	[Header("Выпадающее меню языков:")]
	[SerializeField]
	private TMP_Dropdown dropdown_languages;

	// Token: 0x04000183 RID: 387
	private TMP_Dropdown.OptionData optionData_languages;

	// Token: 0x04000184 RID: 388
	private List<TMP_Dropdown.OptionData> optionsData_languages = new List<TMP_Dropdown.OptionData>();

	// Token: 0x04000185 RID: 389
	private bool languages_dropdown_setting_flag;

	// Token: 0x04000186 RID: 390
	[Header("Все языки и их написание:")]
	[SerializeField]
	private List<Structs.Language_steam_name> language_name;

	// Token: 0x04000187 RID: 391
	[Header("Выпадающее меню скорости интерфейса:")]
	[SerializeField]
	private TMP_Dropdown dropdown_speed_interface;

	// Token: 0x04000188 RID: 392
	private TMP_Dropdown.OptionData optionData_speed_interface;

	// Token: 0x04000189 RID: 393
	private List<TMP_Dropdown.OptionData> optionsData_speed_interface = new List<TMP_Dropdown.OptionData>();

	// Token: 0x0400018A RID: 394
	private List<string> speed_interface_list = new List<string>();

	// Token: 0x0400018B RID: 395
	private bool speed_interface_dropdown_setting_flag;

	// Token: 0x0400018C RID: 396
	[Header("Настройки локализации модификаторов окна:")]
	[SerializeField]
	private Resolution_Monitor.Screen_mode_variant[] speed_interface_language_variant;

	// Token: 0x0400018D RID: 397
	[Header("Настройки скорости интерфейса меню/в игре:")]
	[SerializeField]
	private Resolution_Monitor.Speed_interface[] speed_menu_game;

	// Token: 0x0200012D RID: 301
	// (Invoke) Token: 0x06000751 RID: 1873
	public delegate void E_Graphics_update();

	// Token: 0x0200012E RID: 302
	[Serializable]
	private struct Screen_mode_variant
	{
		// Token: 0x040007D8 RID: 2008
		public Enums_Localization.Screen_mode_E Screen_mode_enum;

		// Token: 0x040007D9 RID: 2009
		public FullScreenMode Screen_mode;
	}

	// Token: 0x0200012F RID: 303
	[Serializable]
	private struct Speed_interface
	{
		// Token: 0x040007DA RID: 2010
		public float speed_menu;

		// Token: 0x040007DB RID: 2011
		public float speed_ui_game;
	}
}
