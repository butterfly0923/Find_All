using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

// Token: 0x020000AE RID: 174
public class Setting_dropdown : MonoBehaviour
{
	// Token: 0x060004E0 RID: 1248 RVA: 0x000176A8 File Offset: 0x000158A8
	private void OnEnable()
	{
		EA.Update_Language = (Action)Delegate.Combine(EA.Update_Language, new Action(this.Update_Language));
		this.dropdown_languages.onValueChanged.AddListener(new UnityAction<int>(this.Language_update));
		this.dropdown_resolution.onValueChanged.AddListener(new UnityAction<int>(this.Resolution_update));
		this.dropdown_screenMode.onValueChanged.AddListener(new UnityAction<int>(this.ScreenMode_update));
		this.dropdown_speed_interface.onValueChanged.AddListener(new UnityAction<int>(this.Speed_interface_update));
	}

	// Token: 0x060004E1 RID: 1249 RVA: 0x00017748 File Offset: 0x00015948
	private void OnDisable()
	{
		EA.Update_Language = (Action)Delegate.Remove(EA.Update_Language, new Action(this.Update_Language));
		this.dropdown_languages.onValueChanged.RemoveListener(new UnityAction<int>(this.Language_update));
		this.dropdown_resolution.onValueChanged.RemoveListener(new UnityAction<int>(this.Resolution_update));
		this.dropdown_screenMode.onValueChanged.RemoveListener(new UnityAction<int>(this.ScreenMode_update));
		this.dropdown_speed_interface.onValueChanged.RemoveListener(new UnityAction<int>(this.Speed_interface_update));
	}

	// Token: 0x060004E2 RID: 1250 RVA: 0x000177E5 File Offset: 0x000159E5
	private void Start()
	{
		this.language_setting();
		this.resolution_setting();
		this.screen_mode_setting();
		this.speed_interface_setting();
	}

	// Token: 0x060004E3 RID: 1251 RVA: 0x000177FF File Offset: 0x000159FF
	private void Update_Language()
	{
		this.screen_mode_setting();
		this.speed_interface_setting();
	}

	// Token: 0x060004E4 RID: 1252 RVA: 0x00017810 File Offset: 0x00015A10
	private void language_setting()
	{
		this.language_name = Localization_manager.st.RT_languages_variant();
		this.dropdown_languages.ClearOptions();
		this.optionsData_languages = new List<TMP_Dropdown.OptionData>();
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

	// Token: 0x060004E5 RID: 1253 RVA: 0x00017904 File Offset: 0x00015B04
	public void Language_update(int I)
	{
		Debug.Log("Languages_update " + I.ToString() + " - " + this.languages_dropdown_setting_flag.ToString());
		if (!this.languages_dropdown_setting_flag)
		{
			Localization_manager.st.Set_Localization(this.language_name[I].language_steam);
		}
		else
		{
			this.languages_dropdown_setting_flag = false;
		}
		Debug.Log("Languages_update LAST" + I.ToString() + " - " + this.languages_dropdown_setting_flag.ToString());
		SL_Data.st.Save_Setting();
	}

	// Token: 0x060004E6 RID: 1254 RVA: 0x00017994 File Offset: 0x00015B94
	private void resolution_setting()
	{
		this.dropdown_resolution.ClearOptions();
		this.optionsData_resolution.Clear();
		if (SL_Data.d_Setting.ResolutionMonitor_Setting != 0)
		{
			this.resolution_dropdown_setting_flag = true;
		}
		this.resolutions = Screen.resolutions;
		foreach (Resolution resolution in this.resolutions)
		{
			this.resolutions_list.Add(new Vector2((float)resolution.width, (float)resolution.height));
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
		this.dropdown_resolution.value = SL_Data.d_Setting.ResolutionMonitor_Setting;
	}

	// Token: 0x060004E7 RID: 1255 RVA: 0x00017B34 File Offset: 0x00015D34
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

	// Token: 0x060004E8 RID: 1256 RVA: 0x00017C08 File Offset: 0x00015E08
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

	// Token: 0x060004E9 RID: 1257 RVA: 0x00017CC0 File Offset: 0x00015EC0
	public void ScreenMode_update(int I)
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

	// Token: 0x060004EA RID: 1258 RVA: 0x00017DD4 File Offset: 0x00015FD4
	private void speed_interface_setting()
	{
		this.dropdown_speed_interface.ClearOptions();
		this.optionsData_speed_interface.Clear();
		for (int i = 0; i < this.Speed_menu_game.Length; i++)
		{
			this.optionData_speed_interface = new TMP_Dropdown.OptionData();
			this.optionData_speed_interface.text = Localization_manager.st.LocalizationData.RT_local_text(this.Speed_menu_game[i].Speed_Interface_enum);
			this.optionsData_speed_interface.Add(this.optionData_speed_interface);
		}
		this.dropdown_speed_interface.AddOptions(this.optionsData_speed_interface);
		if (SL_Data.d_Setting.Speed_interface != 0)
		{
			this.speed_interface_dropdown_setting_flag = true;
		}
		this.dropdown_speed_interface.value = SL_Data.d_Setting.Speed_interface;
		SL_Data.st.Save_Setting();
	}

	// Token: 0x060004EB RID: 1259 RVA: 0x00017E94 File Offset: 0x00016094
	public void Speed_interface_update(int I)
	{
		Debug.Log("Speed_interface_update " + I.ToString() + " - " + this.speed_interface_dropdown_setting_flag.ToString());
		if (!this.speed_interface_dropdown_setting_flag)
		{
			SL_Data.d_Setting.Speed_interface = I;
			SL_Data.d_Setting.Speed_UI = this.Speed_menu_game[I].speed_menu;
			SL_Data.d_Setting.Speed_cards_UI = this.Speed_menu_game[I].speed_ui_game;
			SL_Data.d_Setting.Momental_speed_UI = (I >= this.Speed_menu_game.Length - 1);
		}
		else
		{
			this.speed_interface_dropdown_setting_flag = false;
		}
		Debug.Log("Speed_interface_update LAST " + I.ToString() + " - " + this.speed_interface_dropdown_setting_flag.ToString());
		SL_Data.st.Save_Setting();
	}

	// Token: 0x04000537 RID: 1335
	[Header("Выпадающее меню языков:")]
	[SerializeField]
	private TMP_Dropdown dropdown_languages;

	// Token: 0x04000538 RID: 1336
	private TMP_Dropdown.OptionData optionData_languages;

	// Token: 0x04000539 RID: 1337
	private List<TMP_Dropdown.OptionData> optionsData_languages;

	// Token: 0x0400053A RID: 1338
	private bool languages_dropdown_setting_flag;

	// Token: 0x0400053B RID: 1339
	[Header("Все языки и их написание:")]
	[SerializeField]
	private List<Structs.Language_steam_name> language_name;

	// Token: 0x0400053C RID: 1340
	private Resolution[] resolutions;

	// Token: 0x0400053D RID: 1341
	[Header("Разрешения мониторов которые требуется удалить из списка:")]
	[SerializeField]
	private List<Vector2> remote_resolution_variants;

	// Token: 0x0400053E RID: 1342
	private List<Vector2> resolutions_list = new List<Vector2>();

	// Token: 0x0400053F RID: 1343
	private List<Vector2> resolution_variants = new List<Vector2>();

	// Token: 0x04000540 RID: 1344
	private List<string> resolution_texts = new List<string>();

	// Token: 0x04000541 RID: 1345
	[Header("Выпадающее меню разрешений экрана:")]
	[SerializeField]
	private TMP_Dropdown dropdown_resolution;

	// Token: 0x04000542 RID: 1346
	private TMP_Dropdown.OptionData optionData_resolution;

	// Token: 0x04000543 RID: 1347
	private List<TMP_Dropdown.OptionData> optionsData_resolution = new List<TMP_Dropdown.OptionData>();

	// Token: 0x04000544 RID: 1348
	private bool resolution_dropdown_setting_flag;

	// Token: 0x04000545 RID: 1349
	[Header("Выпадающее меню модификаторов окна:")]
	[SerializeField]
	private TMP_Dropdown dropdown_screenMode;

	// Token: 0x04000546 RID: 1350
	private TMP_Dropdown.OptionData optionData_screenMode;

	// Token: 0x04000547 RID: 1351
	private List<TMP_Dropdown.OptionData> optionsData_screenMode;

	// Token: 0x04000548 RID: 1352
	private bool screenMode_dropdown_setting_flag;

	// Token: 0x04000549 RID: 1353
	[Header("Настройки локализации модификаторов окна:")]
	[SerializeField]
	private Setting_dropdown.Screen_mode_variant[] Language_screen_mode_variant;

	// Token: 0x0400054A RID: 1354
	[Header("Выпадающее меню скорости интерфейса:")]
	[SerializeField]
	private TMP_Dropdown dropdown_speed_interface;

	// Token: 0x0400054B RID: 1355
	private TMP_Dropdown.OptionData optionData_speed_interface;

	// Token: 0x0400054C RID: 1356
	private List<TMP_Dropdown.OptionData> optionsData_speed_interface = new List<TMP_Dropdown.OptionData>();

	// Token: 0x0400054D RID: 1357
	private List<string> speed_interface_list = new List<string>();

	// Token: 0x0400054E RID: 1358
	private bool speed_interface_dropdown_setting_flag;

	// Token: 0x0400054F RID: 1359
	[Header("Настройки скорости интерфейса меню/в игре:")]
	[SerializeField]
	private Setting_dropdown.Speed_interface[] Speed_menu_game;

	// Token: 0x020001F6 RID: 502
	[Serializable]
	private struct Screen_mode_variant
	{
		// Token: 0x04000A93 RID: 2707
		public Enums_Localization.Screen_mode_E Screen_mode_enum;

		// Token: 0x04000A94 RID: 2708
		public FullScreenMode Screen_mode;
	}

	// Token: 0x020001F7 RID: 503
	[Serializable]
	private struct Speed_interface
	{
		// Token: 0x04000A95 RID: 2709
		public Enums_Localization.Speed_interface_E Speed_Interface_enum;

		// Token: 0x04000A96 RID: 2710
		public float speed_menu;

		// Token: 0x04000A97 RID: 2711
		public float speed_ui_game;
	}
}
