using System;
using System.Collections;
using Steamworks;
using UnityEngine;

// Token: 0x02000032 RID: 50
public class Language_controller : MonoBehaviour
{
	// Token: 0x14000001 RID: 1
	// (add) Token: 0x0600015B RID: 347 RVA: 0x0000856C File Offset: 0x0000676C
	// (remove) Token: 0x0600015C RID: 348 RVA: 0x000085A0 File Offset: 0x000067A0
	public static event Language_controller.E_Language_update e_Language_update;

	// Token: 0x0600015D RID: 349 RVA: 0x000085D3 File Offset: 0x000067D3
	private void Awake()
	{
		Object.DontDestroyOnLoad(base.gameObject);
		if (Language_controller.st != null)
		{
			Object.Destroy(base.gameObject);
			return;
		}
		Language_controller.st = this;
	}

	// Token: 0x0600015E RID: 350 RVA: 0x000085FF File Offset: 0x000067FF
	private void Start()
	{
		base.StartCoroutine(this.IE_Language_setting());
	}

	// Token: 0x0600015F RID: 351 RVA: 0x0000860E File Offset: 0x0000680E
	private IEnumerator IE_Language_setting()
	{
		if (!SL_Data.d_Setting.Language_first_complite)
		{
			int I = 0;
			while (I < 10)
			{
				if (SteamManager.Initialized)
				{
					this.start_language_setting();
					I = 10;
				}
				else
				{
					I++;
				}
				yield return new WaitForSeconds(0.1f);
			}
			yield return new WaitForSeconds(0.1f);
			this.start_language_setting();
		}
		else
		{
			this.start_language_setting();
		}
		yield break;
	}

	// Token: 0x06000160 RID: 352 RVA: 0x00008620 File Offset: 0x00006820
	private void start_language_setting()
	{
		if (!EA.scroll_test)
		{
			Debug.Log("Только в редкаторе " + SL_Data.d_Setting.Language_first_complite.ToString());
			if (!SL_Data.d_Setting.Language_first_complite)
			{
				if (SL_Data.d_Setting.Language_name_Setting == null)
				{
					this.language_name = new D_Setting().Language_name_Setting;
					return;
				}
				this.language_name = SL_Data.d_Setting.Language_name_Setting;
				return;
			}
		}
		else
		{
			if (!SL_Data.d_Setting.Language_first_complite && SteamManager.Initialized)
			{
				this.language_name = SteamApps.GetCurrentGameLanguage();
				SL_Data.d_Setting.Language_name_Setting = this.language_name;
				SL_Data.d_Setting.Language_first_complite = true;
				SL_Data.st.Save_Setting();
				return;
			}
			if (SL_Data.d_Setting.Language_name_Setting == null)
			{
				this.language_name = new D_Setting().Language_name_Setting;
			}
			else
			{
				this.language_name = SL_Data.d_Setting.Language_name_Setting;
			}
			SL_Data.d_Setting.Language_first_complite = true;
		}
	}

	// Token: 0x06000161 RID: 353 RVA: 0x0000870C File Offset: 0x0000690C
	private void Language_update()
	{
		for (int i = 0; i < this.Language_variant.Length; i++)
		{
			if (this.Language_variant[i].Language_steam_name == this.language_name)
			{
				SL_Data.d_Setting.Language_name_Setting = this.language_name;
				Language_controller.E_Language_update e_Language_update = Language_controller.e_Language_update;
				if (e_Language_update != null)
				{
					e_Language_update();
				}
				SL_Data.st.Save_Setting();
				return;
			}
		}
	}

	// Token: 0x06000162 RID: 354 RVA: 0x00008775 File Offset: 0x00006975
	public void Language_update_index(int Index_languages)
	{
		this.language_name = this.Language_variant[Index_languages].Language_steam_name;
		this.Language_update();
	}

	// Token: 0x06000163 RID: 355 RVA: 0x00008794 File Offset: 0x00006994
	public St_main.Language_enum Language_enum_return()
	{
		for (int i = 0; i < this.Language_variant.Length; i++)
		{
			if (this.Language_variant[i].Language_steam_name == SL_Data.d_Setting.Language_name_Setting)
			{
				return this.Language_variant[i].language_Enum;
			}
		}
		return this.Language_variant[0].language_Enum;
	}

	// Token: 0x06000164 RID: 356 RVA: 0x000087FC File Offset: 0x000069FC
	public void Language_back_next(bool Back_Next)
	{
		for (int i = 0; i < this.Language_variant.Length; i++)
		{
			if (this.Language_variant[i].Language_steam_name == SL_Data.d_Setting.Language_name_Setting)
			{
				this.number_Language = i;
				break;
			}
		}
		if (Back_Next)
		{
			this.number_Language++;
			if (this.number_Language >= this.Language_variant.Length)
			{
				this.number_Language = 0;
			}
		}
		else
		{
			this.number_Language--;
			if (this.number_Language < 0)
			{
				this.number_Language = this.Language_variant.Length - 1;
			}
		}
		this.language_name = this.Language_variant[this.number_Language].Language_steam_name;
		this.Language_update();
	}

	// Token: 0x0400016C RID: 364
	[SerializeField]
	public Language_controller.Language_main[] Language_variant;

	// Token: 0x0400016D RID: 365
	private string language_name;

	// Token: 0x0400016E RID: 366
	private int number_Language;

	// Token: 0x0400016F RID: 367
	public static Language_controller st;

	// Token: 0x02000128 RID: 296
	// (Invoke) Token: 0x06000747 RID: 1863
	public delegate void E_Language_update();

	// Token: 0x02000129 RID: 297
	[Serializable]
	public struct Language_main
	{
		// Token: 0x040007CE RID: 1998
		public string Language_steam_name;

		// Token: 0x040007CF RID: 1999
		public St_main.Language_enum language_Enum;
	}
}
