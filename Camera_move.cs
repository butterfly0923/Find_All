using System;
using UnityEngine;
using UnityEngine.InputSystem;

// Token: 0x02000009 RID: 9
public class Camera_move : MonoBehaviour
{
	// Token: 0x06000024 RID: 36 RVA: 0x0000270C File Offset: 0x0000090C
	private void Awake()
	{
		Sa_IS.Active_Input_map(Sa_IS.input_Main.Main, true);
		this.Click = Sa_IS.input_Main.Main.Left_Mouse_Click;
		this.Mouse_Position = Sa_IS.input_Main.Main.Mouse_position;
		this.Camera_main = this.Camera_go.GetComponent<Camera>();
		this.camera_transform = this.Camera_go.GetComponent<Transform>();
		this.position_camera = new Vector3(this.camera_transform.position.x, this.camera_transform.position.y, this.Camera_Z);
	}

	// Token: 0x06000025 RID: 37 RVA: 0x000027B1 File Offset: 0x000009B1
	private void LateUpdate()
	{
		if (this.Click.triggered)
		{
			Debug.Log("Кнопка нажата!");
			this.First_camera_position();
			return;
		}
		if (this.Click.ReadValue<float>() > 0f)
		{
			this.Move_camera_position_mouse();
		}
	}

	// Token: 0x06000026 RID: 38 RVA: 0x000027E9 File Offset: 0x000009E9
	private void FixedUpdate()
	{
	}

	// Token: 0x06000027 RID: 39 RVA: 0x000027EC File Offset: 0x000009EC
	private void First_camera_position()
	{
		this.Screen_x = (float)Screen.width;
		this.Screen_y = (float)Screen.height;
		this.position_camera = new Vector3(this.camera_transform.position.x, this.camera_transform.position.y, this.Camera_Z);
		this.position_mouse_down = this.Mouse_Position.ReadValue<Vector2>();
	}

	// Token: 0x06000028 RID: 40 RVA: 0x00002858 File Offset: 0x00000A58
	private void Move_camera_position_mouse()
	{
		Camera_move.position_camera_moment.x = this.position_camera.x + (this.position_mouse_down.x - this.Mouse_Position.ReadValue<Vector2>().x) / (this.Screen_y / 33f);
		Camera_move.position_camera_moment.y = this.position_camera.y + (this.position_mouse_down.y - this.Mouse_Position.ReadValue<Vector2>().y) / (this.Screen_y / 33f);
		this.position_mouse_down = new Vector2(this.Mouse_Position.ReadValue<Vector2>().x, this.position_mouse_down.y);
		this.position_mouse_down = new Vector2(this.position_mouse_down.x, this.Mouse_Position.ReadValue<Vector2>().y);
		this.camera_transform.position = new Vector3(Camera_move.position_camera_moment.x, Camera_move.position_camera_moment.y, this.Camera_Z);
		this.position_camera = this.camera_transform.position;
	}

	// Token: 0x0400001F RID: 31
	[Header("Камера:")]
	[SerializeField]
	private GameObject Camera_go;

	// Token: 0x04000020 RID: 32
	private Transform camera_transform;

	// Token: 0x04000021 RID: 33
	private Camera Camera_main;

	// Token: 0x04000022 RID: 34
	[Header("Позиция камеры по оси Z:")]
	[SerializeField]
	private float Camera_Z;

	// Token: 0x04000023 RID: 35
	private Vector3 position_camera;

	// Token: 0x04000024 RID: 36
	private Vector3 position_mouse_down;

	// Token: 0x04000025 RID: 37
	public static Vector2 position_camera_moment;

	// Token: 0x04000026 RID: 38
	private InputAction Mouse_Position;

	// Token: 0x04000027 RID: 39
	private InputAction Click;

	// Token: 0x04000028 RID: 40
	private float Screen_y;

	// Token: 0x04000029 RID: 41
	private float Screen_x;

	// Token: 0x0400002A RID: 42
	private Vector3 cursor_position_gamepad_void;
}
