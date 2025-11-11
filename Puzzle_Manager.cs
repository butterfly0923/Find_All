using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.UI;

// Token: 0x0200002E RID: 46
public class Puzzle_Manager : MonoBehaviour
{
	// Token: 0x0600012A RID: 298 RVA: 0x000077F8 File Offset: 0x000059F8
	private void Awake()
	{
		this.background_image.color = new Color(1f, 1f, 1f, 0f);
		this.front_raycast_block.enabled = false;
		this.puzzle_full_image = this.puzzle_full_transform.GetComponent<Image>();
		this.puzzle_Full = this.puzzle_full_transform.GetComponent<Puzzle_Full>();
		this.puzzle_full_image.color = new Color(1f, 1f, 1f, 0f);
		this.puzzle_Full.Awake_setting(this);
		this.closed_puzzle_image = this.closed_puzzle_button.gameObject.GetComponent<Image>();
		this.closed_puzzle_image.color = new Color(1f, 1f, 1f, 0f);
		this.help_puzzle_image = this.help_puzzle_button.gameObject.GetComponent<Image>();
		this.help_puzzle_image.color = new Color(1f, 1f, 1f, 0f);
		this.closed_puzzle_button.gameObject.SetActive(false);
		this.help_puzzle_button.gameObject.SetActive(false);
		this.left_click = Sa_IS.input_Main.Puzzle_Play.Left_Click;
		this.escape = Sa_IS.input_Main.Puzzle_Play.Escape;
		this.Puzzle_segments = new Puzzle_Segment[this.Puzzle_segment_go.Length];
		for (int i = 0; i < this.Puzzle_segment_go.Length; i++)
		{
			this.Puzzle_segments[i] = this.Puzzle_segment_go[i].AddComponent<Puzzle_Segment>();
			this.Puzzle_segments[i].Awake_setting(this);
		}
		this.puzzle_Full.enabled = false;
		this.All_Object_Puzzle.SetActive(false);
		Sa_IS.Puzzle_open = false;
	}

	// Token: 0x0600012B RID: 299 RVA: 0x000079B4 File Offset: 0x00005BB4
	private void OnEnable()
	{
		this.left_click.started += this.End_move_segment;
		this.escape.started += this.Closed_Puzzle_Escape;
		this.closed_puzzle_button.onClick.AddListener(new UnityAction(this.Closed_Puzzle));
		this.help_puzzle_button.onClick.AddListener(new UnityAction(this.Open_help_button));
	}

	// Token: 0x0600012C RID: 300 RVA: 0x00007A28 File Offset: 0x00005C28
	private void OnDisable()
	{
		this.left_click.started -= this.End_move_segment;
		this.escape.started -= this.Closed_Puzzle_Escape;
		this.closed_puzzle_button.onClick.RemoveListener(new UnityAction(this.Closed_Puzzle));
		this.help_puzzle_button.onClick.RemoveListener(new UnityAction(this.Open_help_button));
	}

	// Token: 0x0600012D RID: 301 RVA: 0x00007A9B File Offset: 0x00005C9B
	public bool Move_new_segment(Puzzle_Segment mover_puzzle_segment_v)
	{
		if (!this.test_move_segment)
		{
			this.test_move_segment = true;
			base.StartCoroutine(this.IE_new_segment(mover_puzzle_segment_v));
			return true;
		}
		return false;
	}

	// Token: 0x0600012E RID: 302 RVA: 0x00007ABD File Offset: 0x00005CBD
	private IEnumerator IE_new_segment(Puzzle_Segment mover_puzzle_segment_v)
	{
		yield return new WaitForEndOfFrame();
		this.mover_puzzle_segment = mover_puzzle_segment_v;
		yield break;
	}

	// Token: 0x0600012F RID: 303 RVA: 0x00007AD3 File Offset: 0x00005CD3
	public void End_move_segment(InputAction.CallbackContext cc)
	{
		if (this.test_move_segment && this.mover_puzzle_segment != null)
		{
			this.mover_puzzle_segment.Segment_down();
			this.mover_puzzle_segment = null;
			base.StartCoroutine(this.IE_end_test_segment());
		}
	}

	// Token: 0x06000130 RID: 304 RVA: 0x00007B0A File Offset: 0x00005D0A
	private IEnumerator IE_end_test_segment()
	{
		yield return new WaitForEndOfFrame();
		this.test_move_segment = false;
		yield break;
	}

	// Token: 0x06000131 RID: 305 RVA: 0x00007B19 File Offset: 0x00005D19
	public int Return_Segment_Length()
	{
		return this.Puzzle_segment_go.Length;
	}

	// Token: 0x06000132 RID: 306 RVA: 0x00007B24 File Offset: 0x00005D24
	public string Return_Setting_Puzzle(bool[] segment_complite)
	{
		int num = 0;
		for (int i = 0; i < this.Puzzle_segment_go.Length; i++)
		{
			if (i % 2 != 0)
			{
				this.Puzzle_segments[i].Load_Status(segment_complite[i], this.left_down_puzzle, true);
			}
			else
			{
				this.Puzzle_segments[i].Load_Status(segment_complite[i], this.right_up_puzzle, false);
			}
			if (segment_complite[i])
			{
				num++;
			}
		}
		return num.ToString() + "/" + this.Puzzle_segment_go.Length.ToString();
	}

	// Token: 0x06000133 RID: 307 RVA: 0x00007BB0 File Offset: 0x00005DB0
	public bool[] Return_Puzzle_Save()
	{
		bool[] array = new bool[this.Puzzle_segments.Length];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = this.Puzzle_segments[i].Return_Finish_segment();
		}
		return array;
	}

	// Token: 0x06000134 RID: 308 RVA: 0x00007BEC File Offset: 0x00005DEC
	public void Puzzle_Segment_Complite(Puzzle_Segment puzzle_Segment_v)
	{
		int num = 0;
		for (int i = 0; i < this.Puzzle_segments.Length; i++)
		{
			if (this.Puzzle_segments[i].Return_Finish_segment())
			{
				num++;
			}
		}
		if (num >= this.Puzzle_segments.Length)
		{
			Action st_puzzle_complite = Events_Menu_UI.St_puzzle_complite;
			if (st_puzzle_complite != null)
			{
				st_puzzle_complite();
			}
			Events_Menu_UI.Puzzle_Complite(this);
			base.StartCoroutine(this.IE_Puzzle_Full());
			return;
		}
		Events_Menu_UI.Puzzle_Segment_Complite(this, num);
	}

	// Token: 0x06000135 RID: 309 RVA: 0x00007C61 File Offset: 0x00005E61
	private IEnumerator IE_Puzzle_Full()
	{
		this.closed_puzzle_button.interactable = false;
		this.help_puzzle_button.interactable = false;
		this.puzzle_complite_closed = true;
		this.puzzle_full_image.enabled = true;
		yield return new WaitForSeconds(0.5f);
		float value = 0f;
		while (value < 1f)
		{
			yield return new WaitForSeconds(Time.deltaTime);
			value += Time.deltaTime * this.speed_color;
			this.puzzle_full_image.color = new Color(1f, 1f, 1f, Mathf.Lerp(0f, 1f, value));
			this.closed_puzzle_image.color = new Color(1f, 1f, 1f, Mathf.Lerp(1f, 0f, value));
			this.closed_puzzle_button.gameObject.SetActive(false);
			this.help_puzzle_image.color = new Color(1f, 1f, 1f, Mathf.Lerp(1f, 0f, value));
			this.help_puzzle_button.gameObject.SetActive(false);
		}
		this.puzzle_Full.enabled = true;
		for (int i = 0; i < this.Puzzle_segment_go.Length; i++)
		{
			this.Puzzle_segment_go[i].SetActive(false);
		}
		yield break;
	}

	// Token: 0x06000136 RID: 310 RVA: 0x00007C70 File Offset: 0x00005E70
	public void Puzzle_Full_Load()
	{
		this.puzzle_full_image.color = new Color(1f, 1f, 1f, 1f);
		for (int i = 0; i < this.Puzzle_segment_go.Length; i++)
		{
			this.Puzzle_segment_go[i].SetActive(false);
		}
	}

	// Token: 0x06000137 RID: 311 RVA: 0x00007CC2 File Offset: 0x00005EC2
	private void Closed_Puzzle_Escape(InputAction.CallbackContext cc)
	{
		if (!this.puzzle_complite_closed && this.All_Object_Puzzle.activeSelf)
		{
			this.Closed_Puzzle();
		}
	}

	// Token: 0x06000138 RID: 312 RVA: 0x00007CDF File Offset: 0x00005EDF
	private void Closed_Puzzle()
	{
		if (this.All_Object_Puzzle.activeSelf)
		{
			this.Off_Puzzle();
		}
	}

	// Token: 0x06000139 RID: 313 RVA: 0x00007CF4 File Offset: 0x00005EF4
	public void On_Puzzle()
	{
		this.All_Object_Puzzle.SetActive(true);
		Sa_IS.Puzzle_open = true;
		base.StartCoroutine(this.IE_On_Off_Puzzle(true));
		Action help_end_item_find_complite = Events_Menu_UI.Help_end_item_find_complite;
		if (help_end_item_find_complite != null)
		{
			help_end_item_find_complite();
		}
		Sa_IS.Active_Input_map(Sa_IS.input_Main.All, true);
	}

	// Token: 0x0600013A RID: 314 RVA: 0x00007D46 File Offset: 0x00005F46
	private void Off_Puzzle()
	{
		base.StartCoroutine(this.IE_On_Off_Puzzle(false));
		this.closed_puzzle_button.interactable = false;
		this.help_puzzle_button.interactable = false;
		Sa_IS.Active_Input_map(Sa_IS.input_Main.All, true);
	}

	// Token: 0x0600013B RID: 315 RVA: 0x00007D83 File Offset: 0x00005F83
	private IEnumerator IE_On_Off_Puzzle(bool flag_on_off_v)
	{
		this.front_raycast_block.enabled = true;
		base.StartCoroutine(this.IE_Alpha_Button_Closed(flag_on_off_v));
		if (flag_on_off_v)
		{
			float value = 0f;
			while (value < 1f)
			{
				yield return new WaitForSeconds(Time.deltaTime);
				value += Time.deltaTime * this.speed_color * SL_Data.d_Setting.Speed_cards_UI;
				this.background_image.color = new Color(1f, 1f, 1f, Mathf.Lerp(0f, 1f, value));
			}
		}
		List<Puzzle_Segment> puzzle_Segments_list = new List<Puzzle_Segment>();
		for (int j = 0; j < this.Puzzle_segments.Length; j++)
		{
			puzzle_Segments_list.Add(this.Puzzle_segments[j]);
		}
		int num;
		for (int i = 0; i < puzzle_Segments_list.Count; i = num + 1)
		{
			int index = Random.Range(0, puzzle_Segments_list.Count);
			puzzle_Segments_list[index].Segment_On_Off(flag_on_off_v);
			puzzle_Segments_list.RemoveAt(index);
			yield return new WaitForSeconds(this.speed_open_new_segment / SL_Data.d_Setting.Speed_cards_UI);
			num = i;
		}
		for (int i = 0; i < puzzle_Segments_list.Count; i = num + 1)
		{
			puzzle_Segments_list[i].Segment_On_Off(flag_on_off_v);
			yield return new WaitForSeconds(this.speed_open_new_segment / SL_Data.d_Setting.Speed_cards_UI);
			num = i;
		}
		if (!flag_on_off_v)
		{
			float value = 0f;
			while (value < 1f)
			{
				yield return new WaitForSeconds(Time.deltaTime);
				value += Time.deltaTime * this.speed_color;
				this.background_image.color = new Color(1f, 1f, 1f, Mathf.Lerp(1f, 0f, value));
			}
		}
		if (flag_on_off_v)
		{
			Sa_IS.Active_Input_map(Sa_IS.input_Main.Puzzle_Play, true);
			this.closed_puzzle_button.interactable = true;
			this.help_puzzle_button.interactable = true;
			if (!SL_Data.d_Setting.Tutorial_Puzzle)
			{
				SL_Data.d_Setting.Tutorial_Puzzle = true;
				SL_Data.st.Save_Setting();
				Action open_Tutorial_Puzzle = Events_Menu_UI.Open_Tutorial_Puzzle;
				if (open_Tutorial_Puzzle != null)
				{
					open_Tutorial_Puzzle();
				}
			}
		}
		else
		{
			Sa_IS.Active_Input_map(Sa_IS.input_Main.am_play, true);
			this.All_Object_Puzzle.SetActive(false);
			Sa_IS.Puzzle_open = false;
		}
		this.front_raycast_block.enabled = false;
		yield break;
	}

	// Token: 0x0600013C RID: 316 RVA: 0x00007D99 File Offset: 0x00005F99
	private IEnumerator IE_Alpha_Button_Closed(bool on_off)
	{
		float value = 0f;
		if (on_off)
		{
			this.closed_puzzle_button.gameObject.SetActive(true);
			this.help_puzzle_button.gameObject.SetActive(true);
			while (value < 1f)
			{
				yield return new WaitForSeconds(Time.deltaTime);
				value += Time.deltaTime * this.speed_color;
				this.closed_puzzle_image.color = new Color(1f, 1f, 1f, Mathf.Lerp(0f, 1f, value));
				this.help_puzzle_image.color = new Color(1f, 1f, 1f, Mathf.Lerp(0f, 1f, value));
			}
		}
		else
		{
			while (value < 1f)
			{
				yield return new WaitForSeconds(Time.deltaTime);
				value += Time.deltaTime * this.speed_color;
				this.closed_puzzle_image.color = new Color(1f, 1f, 1f, Mathf.Lerp(1f, 0f, value));
				this.help_puzzle_image.color = new Color(1f, 1f, 1f, Mathf.Lerp(1f, 0f, value));
			}
			this.closed_puzzle_button.gameObject.SetActive(false);
			this.help_puzzle_button.gameObject.SetActive(false);
		}
		yield break;
	}

	// Token: 0x0600013D RID: 317 RVA: 0x00007DAF File Offset: 0x00005FAF
	public void Complite_Puzzle_Off()
	{
		Sa_IS.Puzzle_open = false;
		Debug.Log("VAR - ДОЛЖНА НАЧАТЬСЯ КАРУТИНА!");
		base.StartCoroutine(this.IE_Complite_Puzzle_Off());
	}

	// Token: 0x0600013E RID: 318 RVA: 0x00007DCE File Offset: 0x00005FCE
	private IEnumerator IE_Complite_Puzzle_Off()
	{
		float value = 0f;
		while (value < 1f)
		{
			yield return new WaitForSeconds(Time.deltaTime);
			value += Time.deltaTime * this.speed_color;
			this.background_image.color = new Color(1f, 1f, 1f, Mathf.Lerp(1f, 0f, value));
			this.closed_puzzle_button.gameObject.SetActive(false);
			this.help_puzzle_button.gameObject.SetActive(false);
		}
		this.All_Object_Puzzle.SetActive(false);
		yield break;
	}

	// Token: 0x0600013F RID: 319 RVA: 0x00007DDD File Offset: 0x00005FDD
	private void Open_help_button()
	{
		Action open_puzzle_help = Events_Menu_UI.Open_puzzle_help;
		if (open_puzzle_help == null)
		{
			return;
		}
		open_puzzle_help();
	}

	// Token: 0x0400013B RID: 315
	[SerializeField]
	private GameObject All_Object_Puzzle;

	// Token: 0x0400013C RID: 316
	[SerializeField]
	private GameObject[] Puzzle_segment_go;

	// Token: 0x0400013D RID: 317
	[SerializeField]
	private Puzzle_Segment[] Puzzle_segments;

	// Token: 0x0400013E RID: 318
	private InputAction left_click;

	// Token: 0x0400013F RID: 319
	private InputAction escape;

	// Token: 0x04000140 RID: 320
	[SerializeField]
	private Vector3 left_down_puzzle;

	// Token: 0x04000141 RID: 321
	[SerializeField]
	private Vector3 right_up_puzzle;

	// Token: 0x04000142 RID: 322
	[SerializeField]
	private Transform puzzle_full_transform;

	// Token: 0x04000143 RID: 323
	private Image puzzle_full_image;

	// Token: 0x04000144 RID: 324
	private Puzzle_Full puzzle_Full;

	// Token: 0x04000145 RID: 325
	[SerializeField]
	private Vector3 down_point;

	// Token: 0x04000146 RID: 326
	[SerializeField]
	private float down_scale;

	// Token: 0x04000147 RID: 327
	[SerializeField]
	private float speed_color = 2f;

	// Token: 0x04000148 RID: 328
	[SerializeField]
	private Button closed_puzzle_button;

	// Token: 0x04000149 RID: 329
	[SerializeField]
	private Button help_puzzle_button;

	// Token: 0x0400014A RID: 330
	private Image closed_puzzle_image;

	// Token: 0x0400014B RID: 331
	private Image help_puzzle_image;

	// Token: 0x0400014C RID: 332
	[SerializeField]
	private Image background_image;

	// Token: 0x0400014D RID: 333
	[SerializeField]
	private Image front_raycast_block;

	// Token: 0x0400014E RID: 334
	[SerializeField]
	private float speed_open_new_segment;

	// Token: 0x0400014F RID: 335
	private bool test_move_segment;

	// Token: 0x04000150 RID: 336
	private Puzzle_Segment mover_puzzle_segment;

	// Token: 0x04000151 RID: 337
	private bool Complite_Full;

	// Token: 0x04000152 RID: 338
	private bool puzzle_complite_closed;
}
