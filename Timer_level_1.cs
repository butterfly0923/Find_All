using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

// Token: 0x0200004A RID: 74
public class Timer_level_1 : MonoBehaviour
{
	// Token: 0x060001E4 RID: 484 RVA: 0x0000A6E0 File Offset: 0x000088E0
	private void OnEnable()
	{
		EA.Timer_play_stop = (Action<bool>)Delegate.Combine(EA.Timer_play_stop, new Action<bool>(this.Update_Timer));
		EA.LEVEL_COMPLITE = (Action<int>)Delegate.Combine(EA.LEVEL_COMPLITE, new Action<int>(this.Level_complite));
	}

	// Token: 0x060001E5 RID: 485 RVA: 0x0000A730 File Offset: 0x00008930
	private void OnDisable()
	{
		EA.Timer_play_stop = (Action<bool>)Delegate.Remove(EA.Timer_play_stop, new Action<bool>(this.Update_Timer));
		EA.LEVEL_COMPLITE = (Action<int>)Delegate.Remove(EA.LEVEL_COMPLITE, new Action<int>(this.Level_complite));
	}

	// Token: 0x060001E6 RID: 486 RVA: 0x0000A77D File Offset: 0x0000897D
	private void Update_Timer(bool play_stop)
	{
		this.isTimerRunning = play_stop;
	}

	// Token: 0x060001E7 RID: 487 RVA: 0x0000A786 File Offset: 0x00008986
	private void Level_complite(int i)
	{
		this.isLevelCompleted = true;
		if (i == 0)
		{
			base.StartCoroutine(this.CheckAchievements());
		}
	}

	// Token: 0x060001E8 RID: 488 RVA: 0x0000A79F File Offset: 0x0000899F
	private void Start()
	{
		if (!this.old_game)
		{
			this.elapsedTime = SL_Data.d_Game.Timer_complite_level_1;
		}
		else
		{
			this.elapsedTime = SL_Data.d_Game.Timer_complite_level_old;
		}
		this.Update_Timer();
	}

	// Token: 0x060001E9 RID: 489 RVA: 0x0000A7D1 File Offset: 0x000089D1
	private void Update()
	{
		this.Update_Timer();
	}

	// Token: 0x060001EA RID: 490 RVA: 0x0000A7DC File Offset: 0x000089DC
	private void Update_Timer()
	{
		if (!this.old_game)
		{
			if (this.isTimerRunning && !this.isLevelCompleted)
			{
				this.elapsedTime += Time.deltaTime;
				SL_Data.d_Game.Timer_complite_level_1 = this.elapsedTime;
				this.UpdateTimerDisplay();
				return;
			}
		}
		else if (this.isTimerRunning && !this.isLevelCompleted)
		{
			this.elapsedTime += Time.deltaTime;
			SL_Data.d_Game.Timer_complite_level_old = this.elapsedTime;
			this.UpdateTimerDisplay();
		}
	}

	// Token: 0x060001EB RID: 491 RVA: 0x0000A864 File Offset: 0x00008A64
	private void UpdateTimerDisplay()
	{
		int num = Mathf.FloorToInt(this.elapsedTime / 60f);
		int num2 = Mathf.FloorToInt(this.elapsedTime % 60f);
		this.minutesText.text = num.ToString("00");
		this.secondsText.text = num2.ToString("00");
		this.colonText.text = ":";
	}

	// Token: 0x060001EC RID: 492 RVA: 0x0000A8D3 File Offset: 0x00008AD3
	private IEnumerator CheckAchievements()
	{
		foreach (Timer_level_1.Achievement achievement in this.achievements)
		{
			if (this.elapsedTime <= achievement.requiredTime)
			{
				this.SendAchievementEvent(achievement.name);
				yield return new WaitForSeconds(1f);
			}
		}
		List<Timer_level_1.Achievement>.Enumerator enumerator = default(List<Timer_level_1.Achievement>.Enumerator);
		yield break;
		yield break;
	}

	// Token: 0x060001ED RID: 493 RVA: 0x0000A8E2 File Offset: 0x00008AE2
	private void SendAchievementEvent(string achievementName)
	{
		Achievement_manager.st.Achievement_complite(achievementName);
		Debug.Log(string.Format("Achievement Unlocked: {0} at {1} seconds", achievementName, this.elapsedTime));
	}

	// Token: 0x060001EE RID: 494 RVA: 0x0000A90A File Offset: 0x00008B0A
	private void CheckFinalTime()
	{
		Debug.Log(string.Format("Level completed in: {0} seconds", this.elapsedTime));
	}

	// Token: 0x060001EF RID: 495 RVA: 0x0000A926 File Offset: 0x00008B26
	public void ResetTimer()
	{
		this.elapsedTime = 0f;
		this.UpdateTimerDisplay();
		this.isTimerRunning = false;
		this.isLevelCompleted = false;
	}

	// Token: 0x0400021D RID: 541
	private bool timer_update;

	// Token: 0x0400021E RID: 542
	[Header("UI Components")]
	public TMP_Text minutesText;

	// Token: 0x0400021F RID: 543
	public TMP_Text colonText;

	// Token: 0x04000220 RID: 544
	public TMP_Text secondsText;

	// Token: 0x04000221 RID: 545
	[Header("Timer Settings")]
	public bool isTimerRunning;

	// Token: 0x04000222 RID: 546
	public bool isLevelCompleted;

	// Token: 0x04000223 RID: 547
	[Header("Achievements")]
	public List<Timer_level_1.Achievement> achievements = new List<Timer_level_1.Achievement>();

	// Token: 0x04000224 RID: 548
	public float elapsedTime;

	// Token: 0x04000225 RID: 549
	[SerializeField]
	private bool old_game;

	// Token: 0x02000145 RID: 325
	[Serializable]
	public class Achievement
	{
		// Token: 0x04000830 RID: 2096
		public string name;

		// Token: 0x04000831 RID: 2097
		public float requiredTime;
	}
}
