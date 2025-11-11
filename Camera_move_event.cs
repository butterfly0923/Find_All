using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

// Token: 0x02000054 RID: 84
public class Camera_move_event : MonoBehaviour
{
	// Token: 0x06000251 RID: 593 RVA: 0x0000C7E1 File Offset: 0x0000A9E1
	[ContextMenu("Start_move")]
	public void Start_move()
	{
		base.StartCoroutine(this.IE_Move_end());
	}

	// Token: 0x06000252 RID: 594 RVA: 0x0000C7F0 File Offset: 0x0000A9F0
	private IEnumerator IE_Move_end()
	{
		EA.Special_music_play(this.special_music);
		Sa_IS.Active_Input_map(Sa_IS.input_Main.am_void, true);
		yield return new WaitForSeconds(Time.deltaTime);
		ValueTuple<float, float> valueTuple = this.camera_controller.RT_Zoom_camera();
		float camera_max_zoom = valueTuple.Item1;
		float camera_current_zoom = valueTuple.Item2;
		Vector3 vector3_camera_start = this.camera_transform.position;
		float num = Vector2.Distance(this.move_end_point.position, this.camera_transform.position);
		float speed_math_value = this.speed_camera_move / num;
		float value = 0f;
		Debug.Log(string.Format("distance_value - {0}, speed_math_value - {1}", num, speed_math_value));
		this.camera_controller.Start_camera_position_event(vector3_camera_start);
		while (value <= 1f)
		{
			Debug.Log(string.Format("value - {0})", value));
			value += Time.deltaTime * speed_math_value;
			yield return new WaitForSeconds(Time.deltaTime);
			if (this.camera_zoom)
			{
				this.camera_controller.Zoom_update(Mathf.Lerp(camera_current_zoom, camera_max_zoom, value));
			}
			Vector3 v = Vector2.Lerp(vector3_camera_start, this.move_end_point.position, this.animation_curve.Evaluate(value));
			this.camera_controller.Move_camera_position_event(v);
		}
		UnityEvent unityEvent = this.event_end_move;
		if (unityEvent != null)
		{
			unityEvent.Invoke();
		}
		Sa_IS.Active_Input_map(Sa_IS.input_Main.am_play, true);
		yield break;
	}

	// Token: 0x04000299 RID: 665
	[SerializeField]
	private Camera_controller camera_controller;

	// Token: 0x0400029A RID: 666
	[Header("Настройка перемещения камеры:")]
	[SerializeField]
	private bool camera_zoom;

	// Token: 0x0400029B RID: 667
	[SerializeField]
	private Transform move_end_point;

	// Token: 0x0400029C RID: 668
	[SerializeField]
	private Transform camera_transform;

	// Token: 0x0400029D RID: 669
	[SerializeField]
	private float speed_camera_move;

	// Token: 0x0400029E RID: 670
	[SerializeField]
	private AnimationCurve animation_curve;

	// Token: 0x0400029F RID: 671
	[SerializeField]
	private UnityEvent event_end_move;

	// Token: 0x040002A0 RID: 672
	[SerializeField]
	private Enums_Audio.Special_music special_music;
}
