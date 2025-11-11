using System;
using UnityEngine;

// Token: 0x02000039 RID: 57
public class Item_Find_SOUND : MonoBehaviour
{
	// Token: 0x0600018D RID: 397 RVA: 0x0000944E File Offset: 0x0000764E
	private void Start()
	{
		this.audioSource.clip = this.audioClip;
		this.audioSource.volume = this.volume;
		this.audioSource.pitch = this.pitch;
	}

	// Token: 0x0600018E RID: 398 RVA: 0x00009483 File Offset: 0x00007683
	private void OnEnable()
	{
		Events_Menu_UI.Group_item_find_SOUND = (Action)Delegate.Combine(Events_Menu_UI.Group_item_find_SOUND, new Action(this.Find_Group));
	}

	// Token: 0x0600018F RID: 399 RVA: 0x000094A5 File Offset: 0x000076A5
	private void OnDisable()
	{
		Events_Menu_UI.Group_item_find_SOUND = (Action)Delegate.Remove(Events_Menu_UI.Group_item_find_SOUND, new Action(this.Find_Group));
	}

	// Token: 0x06000190 RID: 400 RVA: 0x000094C7 File Offset: 0x000076C7
	private void Find_Group()
	{
		this.audioSource.Play();
	}

	// Token: 0x0400019C RID: 412
	[SerializeField]
	private AudioSource audioSource;

	// Token: 0x0400019D RID: 413
	public AudioClip audioClip;

	// Token: 0x0400019E RID: 414
	[Range(0f, 1f)]
	public float volume;

	// Token: 0x0400019F RID: 415
	[Range(0f, 3f)]
	public float pitch;
}
