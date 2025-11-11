using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

// Token: 0x02000052 RID: 82
public class Camera_controller : MonoBehaviour
{
	// Token: 0x06000234 RID: 564 RVA: 0x0000BBAC File Offset: 0x00009DAC
	private void Awake()
	{
		Camera_controller.st = (Camera_controller)Set_Singleton.This<Camera_controller, Camera_controller>(this, Camera_controller.st);
		this.scroll_IA = Sa_IS.input_Main.am_play.Scroll;
		this.scroll_center_IA = Sa_IS.input_Main.am_play.Scroll_Center;
		this.left_click = Sa_IS.input_Main.am_play.Move_Map;
		this.Mouse_Position = Sa_IS.input_Main.All.Mouse_Position;
		this.WASD = Sa_IS.input_Main.am_play.WASD;
		this.R_key = Sa_IS.input_Main.am_play.R_key;
		this.F_key = Sa_IS.input_Main.am_play.F_key;
	}

	// Token: 0x06000235 RID: 565 RVA: 0x0000BC76 File Offset: 0x00009E76
	private void OnEnable()
	{
		this.scroll_IA.started += this.scrolling;
		this.scroll_center_IA.started += this.scroll_centertal_position;
	}

	// Token: 0x06000236 RID: 566 RVA: 0x0000BCA6 File Offset: 0x00009EA6
	private void OnDisable()
	{
		this.scroll_IA.started -= this.scrolling;
		this.scroll_center_IA.started -= this.scroll_centertal_position;
	}

	// Token: 0x06000237 RID: 567 RVA: 0x0000BCD6 File Offset: 0x00009ED6
	public void Max_coef()
	{
		this.max_scroll_coef = 50f;
	}

	// Token: 0x06000238 RID: 568 RVA: 0x0000BCE3 File Offset: 0x00009EE3
	private void Start()
	{
		this.start_setting_camera_view();
		this.set_start_camera_position();
		this.First_camera_position();
	}

	// Token: 0x06000239 RID: 569 RVA: 0x0000BCF7 File Offset: 0x00009EF7
	private void LateUpdate()
	{
		Cursor.visible = false;
		if (this.left_click.triggered)
		{
			this.First_camera_position();
			Cursor.visible = false;
			return;
		}
		if (this.left_click.ReadValue<float>() > 0f)
		{
			this.Move_camera_position_mouse();
		}
	}

	// Token: 0x0600023A RID: 570 RVA: 0x0000BD34 File Offset: 0x00009F34
	private void FixedUpdate()
	{
		if (this.WASD.ReadValue<Vector2>().x != 0f || this.WASD.ReadValue<Vector2>().y != 0f)
		{
			this.wasd_controll(this.WASD.ReadValue<Vector2>());
		}
		if (this.R_key.ReadValue<float>() > 0f)
		{
			this.scroll_update -= this.speed_scroll / 5f;
			this.scroll_update = ((this.scroll_update < this.min_scroll) ? this.min_scroll : this.scroll_update);
			this.scroll_update = ((this.scroll_update > this.max_scroll_coef) ? this.max_scroll_coef : this.scroll_update);
			if (this.coroutine_scroll == null)
			{
				this.coroutine_scroll = base.StartCoroutine(this.IE_scroll());
				return;
			}
		}
		else if (this.F_key.ReadValue<float>() > 0f)
		{
			this.scroll_update += this.speed_scroll / 5f;
			this.scroll_update = ((this.scroll_update < this.min_scroll) ? this.min_scroll : this.scroll_update);
			this.scroll_update = ((this.scroll_update > this.max_scroll_coef) ? this.max_scroll_coef : this.scroll_update);
			if (this.coroutine_scroll == null)
			{
				this.coroutine_scroll = base.StartCoroutine(this.IE_scroll());
			}
		}
	}

	// Token: 0x0600023B RID: 571 RVA: 0x0000BE98 File Offset: 0x0000A098
	private void start_setting_camera_view()
	{
		ValueTuple<Vector2, Vector2> valueTuple = Zone_manager.st.Map_Zone();
		this.left_down_vec2 = valueTuple.Item1;
		this.right_up_vec2 = valueTuple.Item2;
		this.start_position_camera = Level_Data.st.RT_current_stady().camera_position.position;
		float z = this.curve_z_position.Evaluate(this.start_position_camera.y);
		this.camera_main.transform.position = new Vector3(this.start_position_camera.x, this.start_position_camera.y, z);
		this.position_camera_moment = this.camera_main.transform.position;
		this.camera_transform = this.camera_main.transform;
		this.Camera_Z = this.camera_transform.position.z;
		this.scroll_value = this.center_scroll;
		this.scroll_update = this.center_scroll;
		this.camera_main.fieldOfView = this.curve_angle_camera_view.Evaluate(this.scroll_value / this.max_scroll);
	}

	// Token: 0x0600023C RID: 572 RVA: 0x0000BFA8 File Offset: 0x0000A1A8
	private void scrolling(InputAction.CallbackContext cc)
	{
		this.scroll_update += ((this.scroll_IA.ReadValue<float>() > 0f) ? (-this.speed_scroll) : this.speed_scroll);
		this.scroll_update = ((this.scroll_update < this.min_scroll) ? this.min_scroll : this.scroll_update);
		this.scroll_update = ((this.scroll_update > this.max_scroll_coef) ? this.max_scroll_coef : this.scroll_update);
		if (this.coroutine_scroll == null)
		{
			this.coroutine_scroll = base.StartCoroutine(this.IE_scroll());
		}
	}

	// Token: 0x0600023D RID: 573 RVA: 0x0000C041 File Offset: 0x0000A241
	private void scroll_centertal_position(InputAction.CallbackContext cc)
	{
		this.scroll_update = this.center_scroll;
		if (this.coroutine_scroll == null)
		{
			this.coroutine_scroll = base.StartCoroutine(this.IE_scroll());
		}
	}

	// Token: 0x0600023E RID: 574 RVA: 0x0000C069 File Offset: 0x0000A269
	private IEnumerator IE_scroll()
	{
		while (this.scroll_update >= this.scroll_value + 0.01f || this.scroll_update <= this.scroll_value - 0.01f)
		{
			this.scroll_value = Mathf.Lerp(this.scroll_value, this.scroll_update, this.slerp_camera_view * Time.deltaTime * Mathf.Abs(this.smoothness_scrolling));
			yield return new WaitForSeconds(Time.deltaTime);
			this.camera_main.fieldOfView = this.curve_angle_camera_view.Evaluate(this.scroll_value / this.max_scroll);
			if (this.left_click.ReadValue<float>() == 0f)
			{
				this.First_camera_position();
				this.update_coef();
				this.test_zone_camera();
				this.set_camera_position();
			}
		}
		this.coroutine_scroll = null;
		yield break;
	}

	// Token: 0x0600023F RID: 575 RVA: 0x0000C078 File Offset: 0x0000A278
	private void First_camera_position()
	{
		ValueTuple<Vector2, Vector2> valueTuple = Zone_manager.st.Map_Zone();
		this.left_down_vec2 = valueTuple.Item1;
		this.right_up_vec2 = valueTuple.Item2;
		this.Screen_x = (float)Screen.width;
		this.Screen_y = (float)Screen.height;
		this.position_camera = new Vector3(this.camera_transform.position.x, this.camera_transform.position.y, this.Camera_Z);
		this.position_mouse_down = this.Mouse_Position.ReadValue<Vector2>();
	}

	// Token: 0x06000240 RID: 576 RVA: 0x0000C107 File Offset: 0x0000A307
	private void Move_camera_position_mouse()
	{
		this.update_coef();
		this.read_mouse_position();
		this.test_zone_camera();
		this.set_camera_position();
	}

	// Token: 0x06000241 RID: 577 RVA: 0x0000C121 File Offset: 0x0000A321
	public void Start_camera_position_event(Vector2 vector2)
	{
		this.position_mouse_down = vector2;
	}

	// Token: 0x06000242 RID: 578 RVA: 0x0000C130 File Offset: 0x0000A330
	public void Move_camera_position_event(Vector2 vector2)
	{
		ValueTuple<Vector2, Vector2> valueTuple = Zone_manager.st.Map_Zone();
		this.left_down_vec2 = valueTuple.Item1;
		this.right_up_vec2 = valueTuple.Item2;
		this.update_coef();
		this.position_camera_moment.x = vector2.x;
		this.position_camera_moment.y = vector2.y;
		this.test_zone_camera();
		this.set_camera_position();
	}

	// Token: 0x06000243 RID: 579 RVA: 0x0000C194 File Offset: 0x0000A394
	public ValueTuple<float, float> RT_Zoom_camera()
	{
		return new ValueTuple<float, float>(this.max_scroll_coef, this.scroll_value);
	}

	// Token: 0x06000244 RID: 580 RVA: 0x0000C1A7 File Offset: 0x0000A3A7
	public void Zoom_update(float value)
	{
		this.scroll_update = value;
		this.scroll_value = value;
		this.camera_main.fieldOfView = this.curve_angle_camera_view.Evaluate(this.scroll_value / this.max_scroll);
	}

	// Token: 0x06000245 RID: 581 RVA: 0x0000C1DC File Offset: 0x0000A3DC
	private void wasd_controll(Vector2 value)
	{
		this.update_coef();
		if (Sa_IS.input_Main.am_play.Shift_mod.inProgress)
		{
			this.update_camera_position(value * this.WASD_multiplay * 3f);
		}
		else if (Sa_IS.input_Main.am_play.Alt_mod.inProgress)
		{
			this.update_camera_position(value * this.WASD_multiplay / 2f);
		}
		else
		{
			this.update_camera_position(value * this.WASD_multiplay);
		}
		this.test_zone_camera();
		this.set_camera_position();
	}

	// Token: 0x06000246 RID: 582 RVA: 0x0000C27C File Offset: 0x0000A47C
	private void update_coef()
	{
		this.coef_camera_y = this.curve_height_camera.Evaluate(this.scroll_value / this.max_scroll);
		this.coef_camera_x = this.curve_height_camera.Evaluate(this.scroll_value / this.max_scroll) * (this.Screen_x / this.Screen_y);
	}

	// Token: 0x06000247 RID: 583 RVA: 0x0000C2D4 File Offset: 0x0000A4D4
	private void update_camera_position(Vector2 vector2_value)
	{
		this.position_camera_moment.x = this.camera_transform.position.x + vector2_value.x / 2f;
		this.position_camera_moment.y = this.camera_transform.position.y + vector2_value.y / 2f;
	}

	// Token: 0x06000248 RID: 584 RVA: 0x0000C334 File Offset: 0x0000A534
	private void read_mouse_position()
	{
		float num = this.Screen_y / this.screen_y_coef * this.curve_angle_camera_view.Evaluate(this.center_scroll / this.max_scroll) / this.curve_angle_camera_view.Evaluate(this.scroll_value / this.max_scroll);
		this.position_camera_moment.x = this.position_camera.x + (this.position_mouse_down.x - this.Mouse_Position.ReadValue<Vector2>().x) / num;
		this.position_camera_moment.y = this.position_camera.y + (this.position_mouse_down.y - this.Mouse_Position.ReadValue<Vector2>().y) / num;
	}

	// Token: 0x06000249 RID: 585 RVA: 0x0000C3EC File Offset: 0x0000A5EC
	private void test_zone_camera()
	{
		if (this.position_camera_moment.x > this.right_up_vec2.x - this.coef_camera_x || this.position_camera_moment.x < this.left_down_vec2.x + this.coef_camera_x)
		{
			this.position_mouse_down = new Vector2(this.Mouse_Position.ReadValue<Vector2>().x, this.position_mouse_down.y);
		}
		if (this.position_camera_moment.y > this.right_up_vec2.y - this.coef_camera_y || this.position_camera_moment.y < this.left_down_vec2.y + this.coef_camera_y)
		{
			this.position_mouse_down = new Vector2(this.position_mouse_down.x, this.Mouse_Position.ReadValue<Vector2>().y);
		}
		if (this.position_camera.x >= this.right_up_vec2.x - this.coef_camera_x && this.position_camera.x <= this.left_down_vec2.x + this.coef_camera_x)
		{
			this.position_camera_moment.x = (this.right_up_vec2.x + this.left_down_vec2.x) / 2f;
			this.position_camera = new Vector3(this.position_camera_moment.x, this.position_camera.y, this.Camera_Z);
		}
		else if (this.position_camera_moment.x > this.right_up_vec2.x - this.coef_camera_x)
		{
			this.position_camera_moment.x = this.right_up_vec2.x - this.coef_camera_x;
			this.position_camera = new Vector3(this.camera_transform.position.x, this.position_camera.y, this.Camera_Z);
		}
		else if (this.position_camera_moment.x < this.left_down_vec2.x + this.coef_camera_x)
		{
			this.position_camera_moment.x = this.left_down_vec2.x + this.coef_camera_x;
			this.position_camera = new Vector3(this.camera_transform.position.x, this.position_camera.y, this.Camera_Z);
		}
		if (this.position_camera_moment.y > this.right_up_vec2.y - this.coef_camera_y)
		{
			this.position_camera_moment.y = this.right_up_vec2.y - this.coef_camera_y;
			this.position_camera = new Vector3(this.position_camera.x, this.camera_transform.position.y, this.Camera_Z);
			return;
		}
		if (this.position_camera_moment.y < this.left_down_vec2.y + this.coef_camera_y)
		{
			this.position_camera_moment.y = this.left_down_vec2.y + this.coef_camera_y;
			this.position_camera = new Vector3(this.position_camera.x, this.camera_transform.position.y, this.Camera_Z);
		}
	}

	// Token: 0x0600024A RID: 586 RVA: 0x0000C700 File Offset: 0x0000A900
	private void set_camera_position()
	{
		float z = this.curve_z_position.Evaluate(this.position_camera_moment.y);
		this.camera_transform.position = new Vector3(this.position_camera_moment.x, this.position_camera_moment.y, z);
	}

	// Token: 0x0600024B RID: 587 RVA: 0x0000C74B File Offset: 0x0000A94B
	private void set_start_camera_position()
	{
		this.camera_transform.position = new Vector3(this.start_position_camera.x, this.start_position_camera.y, this.Camera_Z);
	}

	// Token: 0x0400026F RID: 623
	[Header("Камера")]
	[SerializeField]
	private Camera camera_main;

	// Token: 0x04000270 RID: 624
	[SerializeField]
	private Transform camera_transform;

	// Token: 0x04000271 RID: 625
	[Header("Стартовая позиция камеры на уровне:")]
	[SerializeField]
	private Vector2 start_position_camera;

	// Token: 0x04000272 RID: 626
	[Header("График угола обзора камеры:")]
	[SerializeField]
	private AnimationCurve curve_angle_camera_view;

	// Token: 0x04000273 RID: 627
	[Header("График высота относительно угла обзора:")]
	[SerializeField]
	private AnimationCurve curve_height_camera;

	// Token: 0x04000274 RID: 628
	[Header("Параметры приближение/отдаления:")]
	[SerializeField]
	private float speed_scroll;

	// Token: 0x04000275 RID: 629
	[SerializeField]
	private float scroll_update;

	// Token: 0x04000276 RID: 630
	[SerializeField]
	private float scroll_value;

	// Token: 0x04000277 RID: 631
	[SerializeField]
	private float slerp_camera_view;

	// Token: 0x04000278 RID: 632
	[SerializeField]
	private float smoothness_scrolling;

	// Token: 0x04000279 RID: 633
	[SerializeField]
	private float min_scroll;

	// Token: 0x0400027A RID: 634
	[SerializeField]
	private float max_scroll;

	// Token: 0x0400027B RID: 635
	[SerializeField]
	private float max_scroll_coef;

	// Token: 0x0400027C RID: 636
	[SerializeField]
	private float center_scroll;

	// Token: 0x0400027D RID: 637
	[Header("Скорость перемещения WASD:")]
	[SerializeField]
	private float WASD_multiplay;

	// Token: 0x0400027E RID: 638
	[Header("Позиция камеры по оси Z:")]
	[SerializeField]
	private float Camera_Z;

	// Token: 0x0400027F RID: 639
	private Vector3 position_camera;

	// Token: 0x04000280 RID: 640
	private Vector3 position_mouse_down;

	// Token: 0x04000281 RID: 641
	[SerializeField]
	public Vector2 position_camera_moment;

	// Token: 0x04000282 RID: 642
	[SerializeField]
	public Transform zone_left_down;

	// Token: 0x04000283 RID: 643
	[SerializeField]
	public Transform zone_right_up;

	// Token: 0x04000284 RID: 644
	private Vector2 left_down_vec2;

	// Token: 0x04000285 RID: 645
	private Vector2 right_up_vec2;

	// Token: 0x04000286 RID: 646
	private float Screen_y;

	// Token: 0x04000287 RID: 647
	private float Screen_x;

	// Token: 0x04000288 RID: 648
	private float coef_camera_y;

	// Token: 0x04000289 RID: 649
	private float coef_camera_x;

	// Token: 0x0400028A RID: 650
	private InputAction scroll_IA;

	// Token: 0x0400028B RID: 651
	private InputAction scroll_center_IA;

	// Token: 0x0400028C RID: 652
	private Coroutine coroutine_scroll;

	// Token: 0x0400028D RID: 653
	private Coroutine coroutine_move;

	// Token: 0x0400028E RID: 654
	private InputAction left_click;

	// Token: 0x0400028F RID: 655
	private InputAction Mouse_Position;

	// Token: 0x04000290 RID: 656
	private InputAction WASD;

	// Token: 0x04000291 RID: 657
	private InputAction R_key;

	// Token: 0x04000292 RID: 658
	private InputAction F_key;

	// Token: 0x04000293 RID: 659
	[SerializeField]
	private float screen_y_coef;

	// Token: 0x04000294 RID: 660
	[SerializeField]
	private AnimationCurve curve_z_position;

	// Token: 0x04000295 RID: 661
	public static Camera_controller st;
}
