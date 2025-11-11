using System;
using UnityEngine;
using UnityEngine.InputSystem;

// Token: 0x02000063 RID: 99
public static class Sa_IS
{
	// Token: 0x060002A3 RID: 675 RVA: 0x0000DAB0 File Offset: 0x0000BCB0
	public static void Active_Input_map(InputActionMap map, bool save_re_version = true)
	{
		if (map == Sa_IS.input_Main.am_play.Get())
		{
			Debug.Log("ТАЙМЕР ЗАПУЩЕН!");
			Action<bool> timer_play_stop = EA.Timer_play_stop;
			if (timer_play_stop != null)
			{
				timer_play_stop(true);
			}
		}
		else
		{
			Debug.Log("ТАЙМЕР ОСТАНОВЛЕН!");
			Action<bool> timer_play_stop2 = EA.Timer_play_stop;
			if (timer_play_stop2 != null)
			{
				timer_play_stop2(false);
			}
		}
		Debug.Log("включена - " + map.name);
		if (save_re_version)
		{
			if (Sa_IS.re_map == null)
			{
				Sa_IS.re_map = map;
			}
			else
			{
				Sa_IS.re_map = Sa_IS.main_map;
			}
			Sa_IS.main_map = map;
		}
		Sa_IS.input_Main.Disable();
		map.Enable();
		Sa_IS.input_Main.All.Enable();
		if (EA.scroll_test)
		{
			Action<string> update_key_map = Events_Menu_UI.Update_key_map;
			if (update_key_map == null)
			{
				return;
			}
			update_key_map(map.name);
		}
	}

	// Token: 0x060002A4 RID: 676 RVA: 0x0000DB7F File Offset: 0x0000BD7F
	public static void Re_Active_Input_map()
	{
		Sa_IS.Active_Input_map(Sa_IS.re_map, true);
	}

	// Token: 0x060002A5 RID: 677 RVA: 0x0000DB8C File Offset: 0x0000BD8C
	public static void Check_Active_Input_map(InputActionMap map)
	{
		if (!map.enabled)
		{
			Sa_IS.Active_Input_map(map, true);
		}
	}

	// Token: 0x060002A6 RID: 678 RVA: 0x0000DB9D File Offset: 0x0000BD9D
	public static string Return_map()
	{
		if (Sa_IS.main_map == null)
		{
			return "еще нет карты";
		}
		return Sa_IS.main_map.name;
	}

	// Token: 0x04000372 RID: 882
	public static Input_main re_input_Main;

	// Token: 0x04000373 RID: 883
	public static Input_main input_Main = new Input_main();

	// Token: 0x04000374 RID: 884
	public static InputActionMap re_map;

	// Token: 0x04000375 RID: 885
	public static InputActionMap main_map;

	// Token: 0x04000376 RID: 886
	public static bool Puzzle_open;
}
