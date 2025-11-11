using System;
using Steamworks;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

// Token: 0x0200003D RID: 61
public class End_Demo_Table : MonoBehaviour
{
	// Token: 0x0600019F RID: 415 RVA: 0x000096A5 File Offset: 0x000078A5
	private void OnEnable()
	{
		this.B_community_hub.onClick.AddListener(new UnityAction(this.Community_hub));
	}

	// Token: 0x060001A0 RID: 416 RVA: 0x000096C3 File Offset: 0x000078C3
	private void OnDisable()
	{
		this.B_community_hub.onClick.RemoveListener(new UnityAction(this.Community_hub));
	}

	// Token: 0x060001A1 RID: 417 RVA: 0x000096E1 File Offset: 0x000078E1
	private void Add_wishlist()
	{
	}

	// Token: 0x060001A2 RID: 418 RVA: 0x000096E3 File Offset: 0x000078E3
	private void Community_hub()
	{
		Action st_communers = Events_Menu_UI.St_communers;
		if (st_communers != null)
		{
			st_communers();
		}
		SteamFriends.ActivateGameOverlayToWebPage("https://steamcommunity.com/app/2191190/discussions/", EActivateGameOverlayToWebPageMode.k_EActivateGameOverlayToWebPageMode_Default);
	}

	// Token: 0x040001A7 RID: 423
	[SerializeField]
	private Button B_wishlist;

	// Token: 0x040001A8 RID: 424
	[SerializeField]
	private Button B_community_hub;
}
