using System;
using System.Collections;
using Steamworks;
using UnityEngine;

// Token: 0x02000004 RID: 4
public class Achievement_manager : MonoBehaviour
{
	// Token: 0x06000005 RID: 5 RVA: 0x00002086 File Offset: 0x00000286
	private void Awake()
	{
		if (Achievement_manager.st != null)
		{
			Debug.Log("УДАЛИЛ STEAM ДУБЛИКАТ");
			Object.Destroy(base.gameObject);
		}
		else
		{
			Achievement_manager.st = this;
		}
		Object.DontDestroyOnLoad(base.gameObject);
	}

	// Token: 0x06000006 RID: 6 RVA: 0x000020BD File Offset: 0x000002BD
	private void Start()
	{
		this.Initialized_verification = SteamManager.Initialized;
		Debug.Log("SteamManager.Initialized :" + this.Initialized_verification.ToString());
	}

	// Token: 0x06000007 RID: 7 RVA: 0x000020E4 File Offset: 0x000002E4
	public void Achievement_complite_api(Enums_Steam.Achievement_E value)
	{
		this.Achievement_complite(value.ToString());
	}

	// Token: 0x06000008 RID: 8 RVA: 0x000020F9 File Offset: 0x000002F9
	public void Achievement_Start_Game()
	{
		base.StartCoroutine(this.IE_Achievement_Start_Game());
	}

	// Token: 0x06000009 RID: 9 RVA: 0x00002108 File Offset: 0x00000308
	private IEnumerator IE_Achievement_Start_Game()
	{
		yield return new WaitForSeconds(2f);
		this.Achievement_complite(this.Start_Game);
		yield break;
	}

	// Token: 0x0600000A RID: 10 RVA: 0x00002118 File Offset: 0x00000318
	public void Achievement_hot_help_item_count_check()
	{
		Debug.Log(string.Format("Achievement_hot_help_item_count_check() - {0}", SL_Data.d_Game.ACH_hot_help_item_count));
		for (int i = 0; i < this.count_hot_help.Length; i++)
		{
			Debug.Log(string.Format("CHECK Achievement_hot_help_item_count_check() - {0} - {1}", i, SL_Data.d_Game.ACH_hot_help_item_count));
			if (SL_Data.d_Game.ACH_hot_help_item_count >= this.count_hot_help[i].count_item_find && SL_Data.d_Game.ACH_hot_help_item_count < this.count_hot_help[i].count_item_find + 2)
			{
				this.Achievement_complite(this.count_hot_help[i].Ach_name);
				return;
			}
		}
	}

	// Token: 0x0600000B RID: 11 RVA: 0x000021D1 File Offset: 0x000003D1
	public void Achievement_Help()
	{
		this.Achievement_complite(this.Use_Help);
	}

	// Token: 0x0600000C RID: 12 RVA: 0x000021DF File Offset: 0x000003DF
	public void Achievement_End_Game()
	{
		this.Achievement_complite(this.End_Game);
	}

	// Token: 0x0600000D RID: 13 RVA: 0x000021F0 File Offset: 0x000003F0
	public void Achievement_stady(int index_level, int index_stady)
	{
		for (int i = 0; i < this.stady_complite.Length; i++)
		{
			if (this.stady_complite[i].level_index == index_level && this.stady_complite[i].stady_index == index_stady)
			{
				this.Achievement_complite(this.stady_complite[i].Ach_level_name);
			}
		}
	}

	// Token: 0x0600000E RID: 14 RVA: 0x0000224F File Offset: 0x0000044F
	public void Achievement_group_items(Enums_Localization.Items_E item_value)
	{
		this.Achievement_complite(item_value.ToString());
	}

	// Token: 0x0600000F RID: 15 RVA: 0x00002264 File Offset: 0x00000464
	public void Achievement_complite(string achievement)
	{
		base.StartCoroutine(this.Dubl_Ach(achievement));
		Debug.Log(string.Format("{0} !_!_!_!_!_!_! ПРОВЕРКА НА АЧИВКУ", SteamUserStats.GetAchievement(achievement, out this.Check_It)));
		Debug.Log("Achi: " + achievement + " TRUE");
		if (this.Initialized_verification && SteamUserStats.GetAchievement(achievement, out this.Check_It))
		{
			Debug.Log(string.Format("{0} !_!_!_!_!_!_! ПРОВЕРКА НА АЧИВКУ", SteamUserStats.GetAchievement(achievement, out this.Check_It)));
			this.Achievement_Complite_Status = SteamUserStats.SetAchievement(achievement);
			Debug.Log("Achi: " + achievement + " update - " + this.Achievement_Complite_Status.ToString());
			this.History_Achievement();
		}
	}

	// Token: 0x06000010 RID: 16 RVA: 0x0000231C File Offset: 0x0000051C
	private IEnumerator Dubl_Ach(string achievement)
	{
		yield return new WaitForSeconds(Random.Range(2f, 5f));
		if (this.Initialized_verification && SteamUserStats.GetAchievement(achievement, out this.Check_It))
		{
			Debug.Log(string.Format("{0} !_!_!_!_!_!_! ПРОВЕРКА НА АЧИВКУ", SteamUserStats.GetAchievement(achievement, out this.Check_It)));
			this.Achievement_Complite_Status = SteamUserStats.SetAchievement(achievement);
			Debug.Log("Achi: " + achievement + " update - " + this.Achievement_Complite_Status.ToString());
			this.History_Achievement();
		}
		yield break;
	}

	// Token: 0x06000011 RID: 17 RVA: 0x00002334 File Offset: 0x00000534
	public void Achievement_complite(string achievement, ref bool SL_Flag_Achievement)
	{
		if (!SL_Flag_Achievement)
		{
			Debug.Log("Achi: " + achievement + " TRUE");
			if (this.Initialized_verification && SteamUserStats.GetAchievement(achievement, out this.Check_It))
			{
				this.Achievement_Complite_Status = SteamUserStats.SetAchievement(achievement);
				SL_Flag_Achievement = true;
				Debug.Log("Achi: " + achievement + " update - " + this.Achievement_Complite_Status.ToString());
				this.History_Achievement();
			}
		}
	}

	// Token: 0x06000012 RID: 18 RVA: 0x000023A5 File Offset: 0x000005A5
	public bool End_Game_test_ach(string achievement)
	{
		return SteamUserStats.GetAchievement(achievement, out this.Check_It);
	}

	// Token: 0x06000013 RID: 19 RVA: 0x000023B3 File Offset: 0x000005B3
	private void History_Achievement()
	{
		if (this.Initialized_verification)
		{
			this.History_Achievement_status = SteamUserStats.StoreStats();
			Debug.Log("Active Steam: " + this.History_Achievement_status.ToString());
		}
	}

	// Token: 0x06000014 RID: 20 RVA: 0x000023E4 File Offset: 0x000005E4
	[ContextMenu("Clear_Achievement")]
	public void Clear_Achievement()
	{
		if (this.Initialized_verification)
		{
			uint numAchievements = SteamUserStats.GetNumAchievements();
			for (uint num = 0U; num < numAchievements; num += 1U)
			{
				string achievementName = SteamUserStats.GetAchievementName(num);
				SteamUserStats.ClearAchievement(achievementName);
				Debug.Log("Сброшено достижение - " + achievementName);
			}
			SteamUserStats.StoreStats();
		}
	}

	// Token: 0x04000004 RID: 4
	[SerializeField]
	private string Start_Game;

	// Token: 0x04000005 RID: 5
	[SerializeField]
	private string End_Game;

	// Token: 0x04000006 RID: 6
	[SerializeField]
	private string Use_Help;

	// Token: 0x04000007 RID: 7
	[SerializeField]
	private Achievement_manager.Stady_complite[] stady_complite;

	// Token: 0x04000008 RID: 8
	[SerializeField]
	private Achievement_manager.Count_hot_help[] count_hot_help;

	// Token: 0x04000009 RID: 9
	private bool Initialized_verification;

	// Token: 0x0400000A RID: 10
	private bool Achievement_Complite_Status;

	// Token: 0x0400000B RID: 11
	private bool Achievement_Clear_Status;

	// Token: 0x0400000C RID: 12
	private bool History_Achievement_status;

	// Token: 0x0400000D RID: 13
	private bool Check_It = true;

	// Token: 0x0400000E RID: 14
	public static Achievement_manager st;

	// Token: 0x020000DD RID: 221
	[Serializable]
	public struct Stady_complite
	{
		// Token: 0x04000648 RID: 1608
		public int level_index;

		// Token: 0x04000649 RID: 1609
		public int stady_index;

		// Token: 0x0400064A RID: 1610
		public string Ach_level_name;
	}

	// Token: 0x020000DE RID: 222
	[Serializable]
	public struct Puzzle_complite
	{
		// Token: 0x0400064B RID: 1611
		public int level_index;

		// Token: 0x0400064C RID: 1612
		public string Ach_puzzle_name;
	}

	// Token: 0x020000DF RID: 223
	[Serializable]
	public struct Count_hot_help
	{
		// Token: 0x0400064D RID: 1613
		public int count_item_find;

		// Token: 0x0400064E RID: 1614
		public string Ach_name;
	}
}
