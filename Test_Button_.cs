using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

// Token: 0x02000084 RID: 132
public class Test_Button_ : MonoBehaviour, Iinteractive
{
	// Token: 0x06000362 RID: 866 RVA: 0x000108FC File Offset: 0x0000EAFC
	private void Awake()
	{
		this.Z_key = Sa_IS.input_Main.am_play.Z_key;
	}

	// Token: 0x06000363 RID: 867 RVA: 0x00010924 File Offset: 0x0000EB24
	private void OnEnable()
	{
		if (EA.scroll_test)
		{
			this.Z_key.started += this.Z_down;
			this.Z_key.canceled += this.Z_up;
		}
		if (EA.scroll_test)
		{
			Level_Data.All_button = (Action)Delegate.Combine(Level_Data.All_button, new Action(this.Button_this_collier));
		}
	}

	// Token: 0x06000364 RID: 868 RVA: 0x00010990 File Offset: 0x0000EB90
	private void OnDisable()
	{
		if (EA.scroll_test)
		{
			this.Z_key.started -= this.Z_down;
			this.Z_key.canceled -= this.Z_up;
		}
		if (EA.scroll_test)
		{
			Level_Data.All_button = (Action)Delegate.Remove(Level_Data.All_button, new Action(this.Button_this_collier));
		}
	}

	// Token: 0x06000365 RID: 869 RVA: 0x000109F9 File Offset: 0x0000EBF9
	private void Z_down(InputAction.CallbackContext cc)
	{
		this.Z_press = true;
	}

	// Token: 0x06000366 RID: 870 RVA: 0x00010A02 File Offset: 0x0000EC02
	private void Z_up(InputAction.CallbackContext cc)
	{
		this.Z_press = false;
	}

	// Token: 0x06000367 RID: 871 RVA: 0x00010A0C File Offset: 0x0000EC0C
	public void start_setting(List<GameObject> gameObject_add_v, GameObject[] gameObject_find_v, List<GameObject> gameObject_add_mesh_v, List<GameObject> gameObject_find_mesh_v, Find_event_main add_Object_Group_v)
	{
		this.color_main = new Color32((byte)Random.Range(0, 255), (byte)Random.Range(0, 255), (byte)Random.Range(0, 255), byte.MaxValue);
		this.text_name.color = this.color_main;
		this.add_go_prites = new SpriteRenderer[gameObject_add_v.Count];
		this.find_go_prites = new SpriteRenderer[gameObject_find_v.Length];
		this.add_Object_Group = add_Object_Group_v;
		this.text_name.text = add_Object_Group_v.gameObject.name;
		for (int i = 0; i < gameObject_add_v.Count; i++)
		{
			this.add_go_prites[i] = gameObject_add_v[i].GetComponent<SpriteRenderer>();
		}
		for (int j = 0; j < gameObject_find_v.Length; j++)
		{
			this.find_go_prites[j] = gameObject_find_v[j].GetComponent<SpriteRenderer>();
		}
		this.add_go_mesh = new MeshRenderer[gameObject_add_mesh_v.Count];
		this.find_go_mesh = new MeshRenderer[gameObject_find_mesh_v.Count];
		for (int k = 0; k < this.add_go_mesh.Length; k++)
		{
			this.add_go_mesh[k] = gameObject_add_mesh_v[k].GetComponent<MeshRenderer>();
		}
		for (int l = 0; l < this.find_go_mesh.Length; l++)
		{
			this.find_go_mesh[l] = gameObject_find_mesh_v[l].GetComponent<MeshRenderer>();
		}
	}

	// Token: 0x06000368 RID: 872 RVA: 0x00010B58 File Offset: 0x0000ED58
	public void Button_this_collier()
	{
		if (this.Z_press)
		{
			this.Enable_test = false;
			if (this.coroutine != null)
			{
				base.StopCoroutine(this.coroutine);
			}
			for (int i = 0; i < this.add_go_prites.Length; i++)
			{
				this.add_go_prites[i].material.SetColor("Colos_Test_Sc", new Color(1f, 1f, 1f, 1f));
			}
			for (int j = 0; j < this.find_go_prites.Length; j++)
			{
				this.find_go_prites[j].material.SetColor("Colos_Test_Sc", new Color(1f, 1f, 1f, 1f));
			}
			for (int k = 0; k < this.add_go_mesh.Length; k++)
			{
				this.add_go_mesh[k].material.SetColor("Colos_Test_Sc", new Color(1f, 1f, 1f, 1f));
			}
			for (int l = 0; l < this.find_go_mesh.Length; l++)
			{
				this.find_go_mesh[l].material.SetColor("Colos_Test_Sc", new Color(1f, 1f, 1f, 1f));
			}
			this.add_Object_Group.Re_test_color();
			return;
		}
		Debug.Log("Test button down");
		this.Enable_test = !this.Enable_test;
		if (this.Enable_test)
		{
			this.coroutine = base.StartCoroutine(this.IE_Test_color());
			return;
		}
		if (this.coroutine != null)
		{
			base.StopCoroutine(this.coroutine);
		}
		for (int m = 0; m < this.add_go_prites.Length; m++)
		{
			this.add_go_prites[m].material.SetColor("Colos_Test_Sc", new Color(1f, 1f, 1f, 1f));
		}
		for (int n = 0; n < this.find_go_prites.Length; n++)
		{
			this.find_go_prites[n].material.SetColor("Colos_Test_Sc", new Color(1f, 1f, 1f, 1f));
		}
		for (int num = 0; num < this.add_go_mesh.Length; num++)
		{
			this.add_go_mesh[num].material.SetColor("Colos_Test_Sc", new Color(1f, 1f, 1f, 1f));
		}
		for (int num2 = 0; num2 < this.find_go_mesh.Length; num2++)
		{
			this.find_go_mesh[num2].material.SetColor("Colos_Test_Sc", new Color(1f, 1f, 1f, 1f));
		}
	}

	// Token: 0x06000369 RID: 873 RVA: 0x00010E0B File Offset: 0x0000F00B
	private IEnumerator IE_Test_color()
	{
		Debug.Log("КАРУТИНА ЗАПУСТИЛАСЬ");
		for (int i = 0; i < this.add_go_prites.Length; i++)
		{
			this.add_go_prites[i].material.SetColor("Colos_Test_Sc", this.color_main);
		}
		for (int j = 0; j < this.add_go_mesh.Length; j++)
		{
			this.add_go_mesh[j].material.SetColor("Colos_Test_Sc", this.color_main);
		}
		for (;;)
		{
			yield return new WaitForSeconds(this.delay_rele);
			for (int k = 0; k < this.find_go_prites.Length; k++)
			{
				this.find_go_prites[k].material.SetColor("Colos_Test_Sc", this.color_main);
			}
			for (int l = 0; l < this.find_go_mesh.Length; l++)
			{
				this.find_go_mesh[l].material.SetColor("Colos_Test_Sc", this.color_main);
			}
			yield return new WaitForSeconds(this.delay_rele);
			for (int m = 0; m < this.find_go_prites.Length; m++)
			{
				this.find_go_prites[m].material.SetColor("Colos_Test_Sc", new Color(1f, 1f, 1f, 1f));
			}
			for (int n = 0; n < this.find_go_mesh.Length; n++)
			{
				this.find_go_mesh[n].material.SetColor("Colos_Test_Sc", new Color(1f, 1f, 1f, 1f));
			}
		}
		yield break;
	}

	// Token: 0x0600036A RID: 874 RVA: 0x00010E1A File Offset: 0x0000F01A
	public void IStart()
	{
		throw new NotImplementedException();
	}

	// Token: 0x0600036B RID: 875 RVA: 0x00010E21 File Offset: 0x0000F021
	public void IClick()
	{
	}

	// Token: 0x04000405 RID: 1029
	[SerializeField]
	private SpriteRenderer[] add_go_prites;

	// Token: 0x04000406 RID: 1030
	[SerializeField]
	private MeshRenderer[] add_go_mesh;

	// Token: 0x04000407 RID: 1031
	[SerializeField]
	private SpriteRenderer[] find_go_prites;

	// Token: 0x04000408 RID: 1032
	[SerializeField]
	private MeshRenderer[] find_go_mesh;

	// Token: 0x04000409 RID: 1033
	[SerializeField]
	private Find_event_main add_Object_Group;

	// Token: 0x0400040A RID: 1034
	[SerializeField]
	private Color color_main;

	// Token: 0x0400040B RID: 1035
	[SerializeField]
	private TMP_Text text_name;

	// Token: 0x0400040C RID: 1036
	[SerializeField]
	private float delay_rele;

	// Token: 0x0400040D RID: 1037
	private InputAction Z_key;

	// Token: 0x0400040E RID: 1038
	private bool Z_press;

	// Token: 0x0400040F RID: 1039
	[SerializeField]
	private bool Enable_test;

	// Token: 0x04000410 RID: 1040
	private Coroutine coroutine;
}
