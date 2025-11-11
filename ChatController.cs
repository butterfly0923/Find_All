using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

// Token: 0x020000BA RID: 186
public class ChatController : MonoBehaviour
{
	// Token: 0x0600052A RID: 1322 RVA: 0x00018922 File Offset: 0x00016B22
	private void OnEnable()
	{
		this.ChatInputField.onSubmit.AddListener(new UnityAction<string>(this.AddToChatOutput));
	}

	// Token: 0x0600052B RID: 1323 RVA: 0x00018940 File Offset: 0x00016B40
	private void OnDisable()
	{
		this.ChatInputField.onSubmit.RemoveListener(new UnityAction<string>(this.AddToChatOutput));
	}

	// Token: 0x0600052C RID: 1324 RVA: 0x00018960 File Offset: 0x00016B60
	private void AddToChatOutput(string newText)
	{
		this.ChatInputField.text = string.Empty;
		DateTime now = DateTime.Now;
		string text = string.Concat(new string[]
		{
			"[<#FFFF80>",
			now.Hour.ToString("d2"),
			":",
			now.Minute.ToString("d2"),
			":",
			now.Second.ToString("d2"),
			"</color>] ",
			newText
		});
		if (this.ChatDisplayOutput != null)
		{
			if (this.ChatDisplayOutput.text == string.Empty)
			{
				this.ChatDisplayOutput.text = text;
			}
			else
			{
				TMP_Text chatDisplayOutput = this.ChatDisplayOutput;
				chatDisplayOutput.text = chatDisplayOutput.text + "\n" + text;
			}
		}
		this.ChatInputField.ActivateInputField();
		this.ChatScrollbar.value = 0f;
	}

	// Token: 0x0400057F RID: 1407
	public TMP_InputField ChatInputField;

	// Token: 0x04000580 RID: 1408
	public TMP_Text ChatDisplayOutput;

	// Token: 0x04000581 RID: 1409
	public Scrollbar ChatScrollbar;
}
