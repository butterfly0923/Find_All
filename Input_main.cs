using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

// Token: 0x02000062 RID: 98
public class Input_main : IInputActionCollection2, IInputActionCollection, IEnumerable<InputAction>, IEnumerable, IDisposable
{
	// Token: 0x17000005 RID: 5
	// (get) Token: 0x0600027C RID: 636 RVA: 0x0000D1DD File Offset: 0x0000B3DD
	public InputActionAsset asset { get; }

	// Token: 0x0600027D RID: 637 RVA: 0x0000D1E8 File Offset: 0x0000B3E8
	public Input_main()
	{
		this.asset = InputActionAsset.FromJson("{\n    \"name\": \"Input_main\",\n    \"maps\": [\n        {\n            \"name\": \"Main\",\n            \"id\": \"664426c3-6793-44e3-a96f-d2856d0692f3\",\n            \"actions\": [\n                {\n                    \"name\": \"Mouse_position\",\n                    \"type\": \"Value\",\n                    \"id\": \"1a3e9043-1f6f-4fd3-9906-4de0704a0bdd\",\n                    \"expectedControlType\": \"Vector2\",\n                    \"processors\": \"\",\n                    \"interactions\": \"\",\n                    \"initialStateCheck\": true\n                },\n                {\n                    \"name\": \"Key_1\",\n                    \"type\": \"Button\",\n                    \"id\": \"19bf42e4-bb08-4929-9d27-a65c802744ba\",\n                    \"expectedControlType\": \"Button\",\n                    \"processors\": \"\",\n                    \"interactions\": \"\",\n                    \"initialStateCheck\": false\n                },\n                {\n                    \"name\": \"Left_Mouse_Click\",\n                    \"type\": \"Button\",\n                    \"id\": \"b88a25e4-f078-4d47-aa14-4aa8b1487472\",\n                    \"expectedControlType\": \"Button\",\n                    \"processors\": \"\",\n                    \"interactions\": \"\",\n                    \"initialStateCheck\": false\n                },\n                {\n                    \"name\": \"Scrolling\",\n                    \"type\": \"Value\",\n                    \"id\": \"2d4fc093-d97b-4ba7-af30-34631372cc8a\",\n                    \"expectedControlType\": \"\",\n                    \"processors\": \"\",\n                    \"interactions\": \"\",\n                    \"initialStateCheck\": true\n                }\n            ],\n            \"bindings\": [\n                {\n                    \"name\": \"\",\n                    \"id\": \"ac631ab9-d071-45f3-a423-3508176e09ec\",\n                    \"path\": \"<Mouse>/position\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"Mouse_Keyboard\",\n                    \"action\": \"Mouse_position\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"\",\n                    \"id\": \"0545b929-5be7-4c22-9df5-da9227578784\",\n                    \"path\": \"<Keyboard>/1\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"Mouse_Keyboard\",\n                    \"action\": \"Key_1\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"\",\n                    \"id\": \"b99f1bdb-15c8-4f15-b859-d2a01842ee3b\",\n                    \"path\": \"<Mouse>/leftButton\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"Mouse_Keyboard\",\n                    \"action\": \"Left_Mouse_Click\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"\",\n                    \"id\": \"8393300a-bae9-46e4-a9b9-d94b4dbf3b90\",\n                    \"path\": \"<Mouse>/scroll/x\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"\",\n                    \"action\": \"Scrolling\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": false\n                }\n            ]\n        },\n        {\n            \"name\": \"Add\",\n            \"id\": \"9e1fbb72-7870-4ae3-8fca-a5f96a5bf1da\",\n            \"actions\": [\n                {\n                    \"name\": \"Key_2\",\n                    \"type\": \"Button\",\n                    \"id\": \"cd1062ea-0055-46a2-8f48-dd392d67e190\",\n                    \"expectedControlType\": \"Button\",\n                    \"processors\": \"\",\n                    \"interactions\": \"\",\n                    \"initialStateCheck\": false\n                }\n            ],\n            \"bindings\": [\n                {\n                    \"name\": \"\",\n                    \"id\": \"634edc76-6d4a-40f5-852f-e0d979027cca\",\n                    \"path\": \"<Keyboard>/2\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"Mouse_Keyboard\",\n                    \"action\": \"Key_2\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": false\n                }\n            ]\n        },\n        {\n            \"name\": \"All\",\n            \"id\": \"ab346993-41b4-4540-9cbd-68fb85876ca3\",\n            \"actions\": [\n                {\n                    \"name\": \"Key_3\",\n                    \"type\": \"Button\",\n                    \"id\": \"6e35e198-49a5-4db1-92c5-7e81ec066d13\",\n                    \"expectedControlType\": \"Button\",\n                    \"processors\": \"\",\n                    \"interactions\": \"\",\n                    \"initialStateCheck\": false\n                },\n                {\n                    \"name\": \"Q_key\",\n                    \"type\": \"Button\",\n                    \"id\": \"23b0c02b-9925-4f88-bd52-10b596fcbd17\",\n                    \"expectedControlType\": \"Button\",\n                    \"processors\": \"\",\n                    \"interactions\": \"\",\n                    \"initialStateCheck\": false\n                },\n                {\n                    \"name\": \"Mouse_Position\",\n                    \"type\": \"Value\",\n                    \"id\": \"3f69224b-9b6c-49aa-8bdd-2aced8ce644e\",\n                    \"expectedControlType\": \"Vector2\",\n                    \"processors\": \"\",\n                    \"interactions\": \"\",\n                    \"initialStateCheck\": true\n                },\n                {\n                    \"name\": \"Z_key\",\n                    \"type\": \"Button\",\n                    \"id\": \"c490a5c1-ecec-418b-8a70-7d7e3198796a\",\n                    \"expectedControlType\": \"Button\",\n                    \"processors\": \"\",\n                    \"interactions\": \"\",\n                    \"initialStateCheck\": false\n                },\n                {\n                    \"name\": \"Reset_data_setting\",\n                    \"type\": \"Button\",\n                    \"id\": \"8929ac7b-5437-465c-a311-25f9531fd0fd\",\n                    \"expectedControlType\": \"Button\",\n                    \"processors\": \"\",\n                    \"interactions\": \"\",\n                    \"initialStateCheck\": false\n                },\n                {\n                    \"name\": \"Reset_data_game\",\n                    \"type\": \"Button\",\n                    \"id\": \"3bf3cfae-bb0d-4aaa-9bec-6caf4bc87d95\",\n                    \"expectedControlType\": \"Button\",\n                    \"processors\": \"\",\n                    \"interactions\": \"\",\n                    \"initialStateCheck\": false\n                },\n                {\n                    \"name\": \"Reset_data_press_key\",\n                    \"type\": \"Button\",\n                    \"id\": \"3553fe13-19e0-4085-8fa4-27aa27946ecd\",\n                    \"expectedControlType\": \"Button\",\n                    \"processors\": \"\",\n                    \"interactions\": \"\",\n                    \"initialStateCheck\": false\n                },\n                {\n                    \"name\": \"Reset_this_scene\",\n                    \"type\": \"Button\",\n                    \"id\": \"53666ccb-8c07-4159-a569-cd5f949707fd\",\n                    \"expectedControlType\": \"Button\",\n                    \"processors\": \"\",\n                    \"interactions\": \"\",\n                    \"initialStateCheck\": false\n                },\n                {\n                    \"name\": \"Test_Scroll\",\n                    \"type\": \"Button\",\n                    \"id\": \"41eaff40-f212-48bc-88b9-932fda81f300\",\n                    \"expectedControlType\": \"Button\",\n                    \"processors\": \"\",\n                    \"interactions\": \"\",\n                    \"initialStateCheck\": false\n                },\n                {\n                    \"name\": \"Test_Alpha\",\n                    \"type\": \"Button\",\n                    \"id\": \"2ae059ea-72e7-4761-9183-3359f9833b3b\",\n                    \"expectedControlType\": \"Button\",\n                    \"processors\": \"\",\n                    \"interactions\": \"\",\n                    \"initialStateCheck\": false\n                }\n            ],\n            \"bindings\": [\n                {\n                    \"name\": \"\",\n                    \"id\": \"f66fcb00-fd24-4515-a906-9a855b49fd85\",\n                    \"path\": \"<Keyboard>/3\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"Mouse_Keyboard\",\n                    \"action\": \"Key_3\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"\",\n                    \"id\": \"a285a7b6-8160-4336-a6d9-e51f4215d6df\",\n                    \"path\": \"<Keyboard>/q\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"Mouse_Keyboard\",\n                    \"action\": \"Q_key\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"\",\n                    \"id\": \"9411325d-8e33-4146-b709-2265d48ce97f\",\n                    \"path\": \"<Mouse>/position\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"Mouse_Keyboard\",\n                    \"action\": \"Mouse_Position\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"\",\n                    \"id\": \"53cfb539-f9b7-4c83-a9c0-75989487721e\",\n                    \"path\": \"<Keyboard>/z\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"Mouse_Keyboard\",\n                    \"action\": \"Z_key\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"\",\n                    \"id\": \"3edc0954-a0a3-4cdd-b011-0470daf6ccfb\",\n                    \"path\": \"<Keyboard>/o\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"Mouse_Keyboard\",\n                    \"action\": \"Reset_data_setting\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"\",\n                    \"id\": \"7e1ee361-a5e6-425d-a51d-e382435b2edc\",\n                    \"path\": \"<Keyboard>/i\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"Mouse_Keyboard\",\n                    \"action\": \"Reset_data_game\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"\",\n                    \"id\": \"3184b2a6-3308-4646-9a09-47c703bedf87\",\n                    \"path\": \"<Keyboard>/v\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"Mouse_Keyboard\",\n                    \"action\": \"Reset_data_press_key\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"\",\n                    \"id\": \"0560103e-e699-4d04-87c2-c3fd1d01cbb7\",\n                    \"path\": \"<Keyboard>/r\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"Mouse_Keyboard\",\n                    \"action\": \"Reset_this_scene\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"\",\n                    \"id\": \"1a6d7cb1-b6a0-4189-89c2-35892eb7f38b\",\n                    \"path\": \"<Keyboard>/t\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"Mouse_Keyboard\",\n                    \"action\": \"Test_Scroll\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"\",\n                    \"id\": \"38cc491c-e6a4-4127-a125-d4338915174d\",\n                    \"path\": \"<Keyboard>/p\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"Mouse_Keyboard\",\n                    \"action\": \"Test_Alpha\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": false\n                }\n            ]\n        },\n        {\n            \"name\": \"Menu_Main\",\n            \"id\": \"16ba27ac-2145-45aa-ad9b-df07333795ae\",\n            \"actions\": [\n                {\n                    \"name\": \"Escape\",\n                    \"type\": \"Button\",\n                    \"id\": \"458d2ae9-ac91-4818-9b39-4c03cbb1a351\",\n                    \"expectedControlType\": \"Button\",\n                    \"processors\": \"\",\n                    \"interactions\": \"\",\n                    \"initialStateCheck\": false\n                }\n            ],\n            \"bindings\": [\n                {\n                    \"name\": \"\",\n                    \"id\": \"f1f69227-27fb-447b-8a3f-a25a4c195b3f\",\n                    \"path\": \"<Keyboard>/escape\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"\",\n                    \"action\": \"Escape\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": false\n                }\n            ]\n        },\n        {\n            \"name\": \"Menu_Setting\",\n            \"id\": \"370aa694-fbaa-4ed0-89cc-ab85dbb0a7cf\",\n            \"actions\": [\n                {\n                    \"name\": \"Escape\",\n                    \"type\": \"Button\",\n                    \"id\": \"93fcb47a-327e-45f3-af52-69a321b27e41\",\n                    \"expectedControlType\": \"Button\",\n                    \"processors\": \"\",\n                    \"interactions\": \"\",\n                    \"initialStateCheck\": false\n                },\n                {\n                    \"name\": \"U\",\n                    \"type\": \"Button\",\n                    \"id\": \"fefab29c-9519-48a9-9c96-87a38b756ad9\",\n                    \"expectedControlType\": \"Button\",\n                    \"processors\": \"\",\n                    \"interactions\": \"\",\n                    \"initialStateCheck\": false\n                },\n                {\n                    \"name\": \"N\",\n                    \"type\": \"Button\",\n                    \"id\": \"be89cd59-d0eb-4276-9c34-5ea0742088e7\",\n                    \"expectedControlType\": \"Button\",\n                    \"processors\": \"\",\n                    \"interactions\": \"\",\n                    \"initialStateCheck\": false\n                }\n            ],\n            \"bindings\": [\n                {\n                    \"name\": \"\",\n                    \"id\": \"40b90f06-0c12-49a8-a966-b80b5cbf96b7\",\n                    \"path\": \"<Keyboard>/escape\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"\",\n                    \"action\": \"Escape\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"\",\n                    \"id\": \"12d2e84f-0d71-4ac1-9333-05db57aa06e2\",\n                    \"path\": \"<Keyboard>/u\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"\",\n                    \"action\": \"U\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"\",\n                    \"id\": \"7c8d8022-5fcd-430a-a4e7-7e9a4d2d4376\",\n                    \"path\": \"<Keyboard>/n\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"\",\n                    \"action\": \"N\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": false\n                }\n            ]\n        },\n        {\n            \"name\": \"End_Game\",\n            \"id\": \"e72c3700-d95e-4496-a4c3-0b48e123c122\",\n            \"actions\": [\n                {\n                    \"name\": \"Escape\",\n                    \"type\": \"Button\",\n                    \"id\": \"0e862c07-7ebd-4e48-8994-b1b869ba38d7\",\n                    \"expectedControlType\": \"Button\",\n                    \"processors\": \"\",\n                    \"interactions\": \"\",\n                    \"initialStateCheck\": false\n                }\n            ],\n            \"bindings\": [\n                {\n                    \"name\": \"\",\n                    \"id\": \"7c1e4c94-1108-4b69-870a-cfc188c53b2a\",\n                    \"path\": \"<Keyboard>/escape\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"\",\n                    \"action\": \"Escape\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": false\n                }\n            ]\n        },\n        {\n            \"name\": \"Menu_Reset\",\n            \"id\": \"68782d8b-9ca9-4a3c-a37f-629c37d44be2\",\n            \"actions\": [\n                {\n                    \"name\": \"Escape\",\n                    \"type\": \"Button\",\n                    \"id\": \"dc7c0a33-07bf-411b-a0b9-539fb98048b2\",\n                    \"expectedControlType\": \"Button\",\n                    \"processors\": \"\",\n                    \"interactions\": \"\",\n                    \"initialStateCheck\": false\n                }\n            ],\n            \"bindings\": [\n                {\n                    \"name\": \"\",\n                    \"id\": \"33d16d4a-7fd6-4105-8e7c-c5ab4e8c0a2a\",\n                    \"path\": \"<Keyboard>/escape\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"\",\n                    \"action\": \"Escape\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": false\n                }\n            ]\n        },\n        {\n            \"name\": \"Void\",\n            \"id\": \"9070add6-656f-40d4-94a0-f1c9a4bb9fc8\",\n            \"actions\": [\n                {\n                    \"name\": \"Escape\",\n                    \"type\": \"Button\",\n                    \"id\": \"13cb8543-495c-4ab0-bbb0-823eb97c3ea6\",\n                    \"expectedControlType\": \"Button\",\n                    \"processors\": \"\",\n                    \"interactions\": \"\",\n                    \"initialStateCheck\": false\n                }\n            ],\n            \"bindings\": [\n                {\n                    \"name\": \"\",\n                    \"id\": \"373c630b-1709-49ab-86c3-a624fdea9ffc\",\n                    \"path\": \"<Keyboard>/escape\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"\",\n                    \"action\": \"Escape\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": false\n                }\n            ]\n        },\n        {\n            \"name\": \"Map\",\n            \"id\": \"b2d54528-9b16-4e7a-a7f8-4faf521f8157\",\n            \"actions\": [\n                {\n                    \"name\": \"Escape\",\n                    \"type\": \"Button\",\n                    \"id\": \"4f461f3e-d267-4e6a-b93d-01b895b309b3\",\n                    \"expectedControlType\": \"Button\",\n                    \"processors\": \"\",\n                    \"interactions\": \"\",\n                    \"initialStateCheck\": false\n                }\n            ],\n            \"bindings\": [\n                {\n                    \"name\": \"\",\n                    \"id\": \"e6329b66-4689-45e8-81bb-f029a51dd7ae\",\n                    \"path\": \"<Keyboard>/escape\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"\",\n                    \"action\": \"Escape\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": false\n                }\n            ]\n        },\n        {\n            \"name\": \"C[...string is too long...]");
		this.m_Main = this.asset.FindActionMap("Main", true);
		this.m_Main_Mouse_position = this.m_Main.FindAction("Mouse_position", true);
		this.m_Main_Key_1 = this.m_Main.FindAction("Key_1", true);
		this.m_Main_Left_Mouse_Click = this.m_Main.FindAction("Left_Mouse_Click", true);
		this.m_Main_Scrolling = this.m_Main.FindAction("Scrolling", true);
		this.m_Add = this.asset.FindActionMap("Add", true);
		this.m_Add_Key_2 = this.m_Add.FindAction("Key_2", true);
		this.m_All = this.asset.FindActionMap("All", true);
		this.m_All_Key_3 = this.m_All.FindAction("Key_3", true);
		this.m_All_Q_key = this.m_All.FindAction("Q_key", true);
		this.m_All_Mouse_Position = this.m_All.FindAction("Mouse_Position", true);
		this.m_All_Z_key = this.m_All.FindAction("Z_key", true);
		this.m_All_Reset_data_setting = this.m_All.FindAction("Reset_data_setting", true);
		this.m_All_Reset_data_game = this.m_All.FindAction("Reset_data_game", true);
		this.m_All_Reset_data_press_key = this.m_All.FindAction("Reset_data_press_key", true);
		this.m_All_Reset_this_scene = this.m_All.FindAction("Reset_this_scene", true);
		this.m_All_Test_Scroll = this.m_All.FindAction("Test_Scroll", true);
		this.m_All_Test_Alpha = this.m_All.FindAction("Test_Alpha", true);
		this.m_Menu_Main = this.asset.FindActionMap("Menu_Main", true);
		this.m_Menu_Main_Escape = this.m_Menu_Main.FindAction("Escape", true);
		this.m_Menu_Setting = this.asset.FindActionMap("Menu_Setting", true);
		this.m_Menu_Setting_Escape = this.m_Menu_Setting.FindAction("Escape", true);
		this.m_Menu_Setting_U = this.m_Menu_Setting.FindAction("U", true);
		this.m_Menu_Setting_N = this.m_Menu_Setting.FindAction("N", true);
		this.m_End_Game = this.asset.FindActionMap("End_Game", true);
		this.m_End_Game_Escape = this.m_End_Game.FindAction("Escape", true);
		this.m_Menu_Reset = this.asset.FindActionMap("Menu_Reset", true);
		this.m_Menu_Reset_Escape = this.m_Menu_Reset.FindAction("Escape", true);
		this.m_Void = this.asset.FindActionMap("Void", true);
		this.m_Void_Escape = this.m_Void.FindAction("Escape", true);
		this.m_Map = this.asset.FindActionMap("Map", true);
		this.m_Map_Escape = this.m_Map.FindAction("Escape", true);
		this.m_Card_variant = this.asset.FindActionMap("Card_variant", true);
		this.m_Card_variant_Newaction = this.m_Card_variant.FindAction("New action", true);
		this.m_Puzzle_Play = this.asset.FindActionMap("Puzzle_Play", true);
		this.m_Puzzle_Play_Left_Click = this.m_Puzzle_Play.FindAction("Left_Click", true);
		this.m_Puzzle_Play_Escape = this.m_Puzzle_Play.FindAction("Escape", true);
		this.m_Puzzle_Play_Right_Click = this.m_Puzzle_Play.FindAction("Right_Click", true);
		this.m_Puzzle_Play_QE_rotate = this.m_Puzzle_Play.FindAction("QE_rotate", true);
		this.m_Editor = this.asset.FindActionMap("Editor", true);
		this.m_Editor_Z = this.m_Editor.FindAction("Z", true);
		this.m_am_void = this.asset.FindActionMap("am_void", true);
		this.m_am_void_Newaction = this.m_am_void.FindAction("New action", true);
		this.m_am_menu = this.asset.FindActionMap("am_menu", true);
		this.m_am_menu_escape = this.m_am_menu.FindAction("escape", true);
		this.m_am_setting = this.asset.FindActionMap("am_setting", true);
		this.m_am_setting_escape = this.m_am_setting.FindAction("escape", true);
		this.m_am_setting_U = this.m_am_setting.FindAction("U", true);
		this.m_am_setting_N = this.m_am_setting.FindAction("N", true);
		this.m_am_level_map = this.asset.FindActionMap("am_level_map", true);
		this.m_am_level_map_escape = this.m_am_level_map.FindAction("escape", true);
		this.m_am_map = this.asset.FindActionMap("am_map", true);
		this.m_am_map_escape = this.m_am_map.FindAction("escape", true);
		this.m_am_map_reset = this.asset.FindActionMap("am_map_reset", true);
		this.m_am_map_reset_escape = this.m_am_map_reset.FindAction("escape", true);
		this.m_am_play = this.asset.FindActionMap("am_play", true);
		this.m_am_play_escape = this.m_am_play.FindAction("escape", true);
		this.m_am_play_Scroll = this.m_am_play.FindAction("Scroll", true);
		this.m_am_play_Scroll_Center = this.m_am_play.FindAction("Scroll_Center", true);
		this.m_am_play_Move_Map = this.m_am_play.FindAction("Move_Map", true);
		this.m_am_play_Mouse_Position = this.m_am_play.FindAction("Mouse_Position", true);
		this.m_am_play_Find_Group_1 = this.m_am_play.FindAction("Find_Group_1", true);
		this.m_am_play_Find_Group_2 = this.m_am_play.FindAction("Find_Group_2", true);
		this.m_am_play_Find_Group_3 = this.m_am_play.FindAction("Find_Group_3", true);
		this.m_am_play_WASD = this.m_am_play.FindAction("WASD", true);
		this.m_am_play_Z_key = this.m_am_play.FindAction("Z_key", true);
		this.m_am_play_Q_key = this.m_am_play.FindAction("Q_key", true);
		this.m_am_play_Shift_mod = this.m_am_play.FindAction("Shift_mod", true);
		this.m_am_play_Alt_mod = this.m_am_play.FindAction("Alt_mod", true);
		this.m_am_play_R_key = this.m_am_play.FindAction("R_key", true);
		this.m_am_play_F_key = this.m_am_play.FindAction("F_key", true);
		this.m_am_tutorial_1 = this.asset.FindActionMap("am_tutorial_1", true);
		this.m_am_tutorial_1_escape = this.m_am_tutorial_1.FindAction("escape", true);
		this.m_am_tutorial_2 = this.asset.FindActionMap("am_tutorial_2", true);
		this.m_am_tutorial_2_escape = this.m_am_tutorial_2.FindAction("escape", true);
		this.m_am_tutorial_setting = this.asset.FindActionMap("am_tutorial_setting", true);
		this.m_am_tutorial_setting_escape = this.m_am_tutorial_setting.FindAction("escape", true);
	}

	// Token: 0x0600027E RID: 638 RVA: 0x0000D8FD File Offset: 0x0000BAFD
	public void Dispose()
	{
		Object.Destroy(this.asset);
	}

	// Token: 0x17000006 RID: 6
	// (get) Token: 0x0600027F RID: 639 RVA: 0x0000D90A File Offset: 0x0000BB0A
	// (set) Token: 0x06000280 RID: 640 RVA: 0x0000D917 File Offset: 0x0000BB17
	public InputBinding? bindingMask
	{
		get
		{
			return this.asset.bindingMask;
		}
		set
		{
			this.asset.bindingMask = value;
		}
	}

	// Token: 0x17000007 RID: 7
	// (get) Token: 0x06000281 RID: 641 RVA: 0x0000D925 File Offset: 0x0000BB25
	// (set) Token: 0x06000282 RID: 642 RVA: 0x0000D932 File Offset: 0x0000BB32
	public ReadOnlyArray<InputDevice>? devices
	{
		get
		{
			return this.asset.devices;
		}
		set
		{
			this.asset.devices = value;
		}
	}

	// Token: 0x17000008 RID: 8
	// (get) Token: 0x06000283 RID: 643 RVA: 0x0000D940 File Offset: 0x0000BB40
	public ReadOnlyArray<InputControlScheme> controlSchemes
	{
		get
		{
			return this.asset.controlSchemes;
		}
	}

	// Token: 0x06000284 RID: 644 RVA: 0x0000D94D File Offset: 0x0000BB4D
	public bool Contains(InputAction action)
	{
		return this.asset.Contains(action);
	}

	// Token: 0x06000285 RID: 645 RVA: 0x0000D95B File Offset: 0x0000BB5B
	public IEnumerator<InputAction> GetEnumerator()
	{
		return this.asset.GetEnumerator();
	}

	// Token: 0x06000286 RID: 646 RVA: 0x0000D968 File Offset: 0x0000BB68
	IEnumerator IEnumerable.GetEnumerator()
	{
		return this.GetEnumerator();
	}

	// Token: 0x06000287 RID: 647 RVA: 0x0000D970 File Offset: 0x0000BB70
	public void Enable()
	{
		this.asset.Enable();
	}

	// Token: 0x06000288 RID: 648 RVA: 0x0000D97D File Offset: 0x0000BB7D
	public void Disable()
	{
		this.asset.Disable();
	}

	// Token: 0x17000009 RID: 9
	// (get) Token: 0x06000289 RID: 649 RVA: 0x0000D98A File Offset: 0x0000BB8A
	public IEnumerable<InputBinding> bindings
	{
		get
		{
			return this.asset.bindings;
		}
	}

	// Token: 0x0600028A RID: 650 RVA: 0x0000D997 File Offset: 0x0000BB97
	public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
	{
		return this.asset.FindAction(actionNameOrId, throwIfNotFound);
	}

	// Token: 0x0600028B RID: 651 RVA: 0x0000D9A6 File Offset: 0x0000BBA6
	public int FindBinding(InputBinding bindingMask, out InputAction action)
	{
		return this.asset.FindBinding(bindingMask, out action);
	}

	// Token: 0x1700000A RID: 10
	// (get) Token: 0x0600028C RID: 652 RVA: 0x0000D9B5 File Offset: 0x0000BBB5
	public Input_main.MainActions Main
	{
		get
		{
			return new Input_main.MainActions(this);
		}
	}

	// Token: 0x1700000B RID: 11
	// (get) Token: 0x0600028D RID: 653 RVA: 0x0000D9BD File Offset: 0x0000BBBD
	public Input_main.AddActions Add
	{
		get
		{
			return new Input_main.AddActions(this);
		}
	}

	// Token: 0x1700000C RID: 12
	// (get) Token: 0x0600028E RID: 654 RVA: 0x0000D9C5 File Offset: 0x0000BBC5
	public Input_main.AllActions All
	{
		get
		{
			return new Input_main.AllActions(this);
		}
	}

	// Token: 0x1700000D RID: 13
	// (get) Token: 0x0600028F RID: 655 RVA: 0x0000D9CD File Offset: 0x0000BBCD
	public Input_main.Menu_MainActions Menu_Main
	{
		get
		{
			return new Input_main.Menu_MainActions(this);
		}
	}

	// Token: 0x1700000E RID: 14
	// (get) Token: 0x06000290 RID: 656 RVA: 0x0000D9D5 File Offset: 0x0000BBD5
	public Input_main.Menu_SettingActions Menu_Setting
	{
		get
		{
			return new Input_main.Menu_SettingActions(this);
		}
	}

	// Token: 0x1700000F RID: 15
	// (get) Token: 0x06000291 RID: 657 RVA: 0x0000D9DD File Offset: 0x0000BBDD
	public Input_main.End_GameActions End_Game
	{
		get
		{
			return new Input_main.End_GameActions(this);
		}
	}

	// Token: 0x17000010 RID: 16
	// (get) Token: 0x06000292 RID: 658 RVA: 0x0000D9E5 File Offset: 0x0000BBE5
	public Input_main.Menu_ResetActions Menu_Reset
	{
		get
		{
			return new Input_main.Menu_ResetActions(this);
		}
	}

	// Token: 0x17000011 RID: 17
	// (get) Token: 0x06000293 RID: 659 RVA: 0x0000D9ED File Offset: 0x0000BBED
	public Input_main.VoidActions Void
	{
		get
		{
			return new Input_main.VoidActions(this);
		}
	}

	// Token: 0x17000012 RID: 18
	// (get) Token: 0x06000294 RID: 660 RVA: 0x0000D9F5 File Offset: 0x0000BBF5
	public Input_main.MapActions Map
	{
		get
		{
			return new Input_main.MapActions(this);
		}
	}

	// Token: 0x17000013 RID: 19
	// (get) Token: 0x06000295 RID: 661 RVA: 0x0000D9FD File Offset: 0x0000BBFD
	public Input_main.Card_variantActions Card_variant
	{
		get
		{
			return new Input_main.Card_variantActions(this);
		}
	}

	// Token: 0x17000014 RID: 20
	// (get) Token: 0x06000296 RID: 662 RVA: 0x0000DA05 File Offset: 0x0000BC05
	public Input_main.Puzzle_PlayActions Puzzle_Play
	{
		get
		{
			return new Input_main.Puzzle_PlayActions(this);
		}
	}

	// Token: 0x17000015 RID: 21
	// (get) Token: 0x06000297 RID: 663 RVA: 0x0000DA0D File Offset: 0x0000BC0D
	public Input_main.EditorActions Editor
	{
		get
		{
			return new Input_main.EditorActions(this);
		}
	}

	// Token: 0x17000016 RID: 22
	// (get) Token: 0x06000298 RID: 664 RVA: 0x0000DA15 File Offset: 0x0000BC15
	public Input_main.Am_voidActions am_void
	{
		get
		{
			return new Input_main.Am_voidActions(this);
		}
	}

	// Token: 0x17000017 RID: 23
	// (get) Token: 0x06000299 RID: 665 RVA: 0x0000DA1D File Offset: 0x0000BC1D
	public Input_main.Am_menuActions am_menu
	{
		get
		{
			return new Input_main.Am_menuActions(this);
		}
	}

	// Token: 0x17000018 RID: 24
	// (get) Token: 0x0600029A RID: 666 RVA: 0x0000DA25 File Offset: 0x0000BC25
	public Input_main.Am_settingActions am_setting
	{
		get
		{
			return new Input_main.Am_settingActions(this);
		}
	}

	// Token: 0x17000019 RID: 25
	// (get) Token: 0x0600029B RID: 667 RVA: 0x0000DA2D File Offset: 0x0000BC2D
	public Input_main.Am_level_mapActions am_level_map
	{
		get
		{
			return new Input_main.Am_level_mapActions(this);
		}
	}

	// Token: 0x1700001A RID: 26
	// (get) Token: 0x0600029C RID: 668 RVA: 0x0000DA35 File Offset: 0x0000BC35
	public Input_main.Am_mapActions am_map
	{
		get
		{
			return new Input_main.Am_mapActions(this);
		}
	}

	// Token: 0x1700001B RID: 27
	// (get) Token: 0x0600029D RID: 669 RVA: 0x0000DA3D File Offset: 0x0000BC3D
	public Input_main.Am_map_resetActions am_map_reset
	{
		get
		{
			return new Input_main.Am_map_resetActions(this);
		}
	}

	// Token: 0x1700001C RID: 28
	// (get) Token: 0x0600029E RID: 670 RVA: 0x0000DA45 File Offset: 0x0000BC45
	public Input_main.Am_playActions am_play
	{
		get
		{
			return new Input_main.Am_playActions(this);
		}
	}

	// Token: 0x1700001D RID: 29
	// (get) Token: 0x0600029F RID: 671 RVA: 0x0000DA4D File Offset: 0x0000BC4D
	public Input_main.Am_tutorial_1Actions am_tutorial_1
	{
		get
		{
			return new Input_main.Am_tutorial_1Actions(this);
		}
	}

	// Token: 0x1700001E RID: 30
	// (get) Token: 0x060002A0 RID: 672 RVA: 0x0000DA55 File Offset: 0x0000BC55
	public Input_main.Am_tutorial_2Actions am_tutorial_2
	{
		get
		{
			return new Input_main.Am_tutorial_2Actions(this);
		}
	}

	// Token: 0x1700001F RID: 31
	// (get) Token: 0x060002A1 RID: 673 RVA: 0x0000DA5D File Offset: 0x0000BC5D
	public Input_main.Am_tutorial_settingActions am_tutorial_setting
	{
		get
		{
			return new Input_main.Am_tutorial_settingActions(this);
		}
	}

	// Token: 0x17000020 RID: 32
	// (get) Token: 0x060002A2 RID: 674 RVA: 0x0000DA68 File Offset: 0x0000BC68
	public InputControlScheme Mouse_KeyboardScheme
	{
		get
		{
			if (this.m_Mouse_KeyboardSchemeIndex == -1)
			{
				this.m_Mouse_KeyboardSchemeIndex = this.asset.FindControlSchemeIndex("Mouse_Keyboard");
			}
			return this.asset.controlSchemes[this.m_Mouse_KeyboardSchemeIndex];
		}
	}

	// Token: 0x0400030E RID: 782
	private readonly InputActionMap m_Main;

	// Token: 0x0400030F RID: 783
	private Input_main.IMainActions m_MainActionsCallbackInterface;

	// Token: 0x04000310 RID: 784
	private readonly InputAction m_Main_Mouse_position;

	// Token: 0x04000311 RID: 785
	private readonly InputAction m_Main_Key_1;

	// Token: 0x04000312 RID: 786
	private readonly InputAction m_Main_Left_Mouse_Click;

	// Token: 0x04000313 RID: 787
	private readonly InputAction m_Main_Scrolling;

	// Token: 0x04000314 RID: 788
	private readonly InputActionMap m_Add;

	// Token: 0x04000315 RID: 789
	private Input_main.IAddActions m_AddActionsCallbackInterface;

	// Token: 0x04000316 RID: 790
	private readonly InputAction m_Add_Key_2;

	// Token: 0x04000317 RID: 791
	private readonly InputActionMap m_All;

	// Token: 0x04000318 RID: 792
	private Input_main.IAllActions m_AllActionsCallbackInterface;

	// Token: 0x04000319 RID: 793
	private readonly InputAction m_All_Key_3;

	// Token: 0x0400031A RID: 794
	private readonly InputAction m_All_Q_key;

	// Token: 0x0400031B RID: 795
	private readonly InputAction m_All_Mouse_Position;

	// Token: 0x0400031C RID: 796
	private readonly InputAction m_All_Z_key;

	// Token: 0x0400031D RID: 797
	private readonly InputAction m_All_Reset_data_setting;

	// Token: 0x0400031E RID: 798
	private readonly InputAction m_All_Reset_data_game;

	// Token: 0x0400031F RID: 799
	private readonly InputAction m_All_Reset_data_press_key;

	// Token: 0x04000320 RID: 800
	private readonly InputAction m_All_Reset_this_scene;

	// Token: 0x04000321 RID: 801
	private readonly InputAction m_All_Test_Scroll;

	// Token: 0x04000322 RID: 802
	private readonly InputAction m_All_Test_Alpha;

	// Token: 0x04000323 RID: 803
	private readonly InputActionMap m_Menu_Main;

	// Token: 0x04000324 RID: 804
	private Input_main.IMenu_MainActions m_Menu_MainActionsCallbackInterface;

	// Token: 0x04000325 RID: 805
	private readonly InputAction m_Menu_Main_Escape;

	// Token: 0x04000326 RID: 806
	private readonly InputActionMap m_Menu_Setting;

	// Token: 0x04000327 RID: 807
	private Input_main.IMenu_SettingActions m_Menu_SettingActionsCallbackInterface;

	// Token: 0x04000328 RID: 808
	private readonly InputAction m_Menu_Setting_Escape;

	// Token: 0x04000329 RID: 809
	private readonly InputAction m_Menu_Setting_U;

	// Token: 0x0400032A RID: 810
	private readonly InputAction m_Menu_Setting_N;

	// Token: 0x0400032B RID: 811
	private readonly InputActionMap m_End_Game;

	// Token: 0x0400032C RID: 812
	private Input_main.IEnd_GameActions m_End_GameActionsCallbackInterface;

	// Token: 0x0400032D RID: 813
	private readonly InputAction m_End_Game_Escape;

	// Token: 0x0400032E RID: 814
	private readonly InputActionMap m_Menu_Reset;

	// Token: 0x0400032F RID: 815
	private Input_main.IMenu_ResetActions m_Menu_ResetActionsCallbackInterface;

	// Token: 0x04000330 RID: 816
	private readonly InputAction m_Menu_Reset_Escape;

	// Token: 0x04000331 RID: 817
	private readonly InputActionMap m_Void;

	// Token: 0x04000332 RID: 818
	private Input_main.IVoidActions m_VoidActionsCallbackInterface;

	// Token: 0x04000333 RID: 819
	private readonly InputAction m_Void_Escape;

	// Token: 0x04000334 RID: 820
	private readonly InputActionMap m_Map;

	// Token: 0x04000335 RID: 821
	private Input_main.IMapActions m_MapActionsCallbackInterface;

	// Token: 0x04000336 RID: 822
	private readonly InputAction m_Map_Escape;

	// Token: 0x04000337 RID: 823
	private readonly InputActionMap m_Card_variant;

	// Token: 0x04000338 RID: 824
	private Input_main.ICard_variantActions m_Card_variantActionsCallbackInterface;

	// Token: 0x04000339 RID: 825
	private readonly InputAction m_Card_variant_Newaction;

	// Token: 0x0400033A RID: 826
	private readonly InputActionMap m_Puzzle_Play;

	// Token: 0x0400033B RID: 827
	private Input_main.IPuzzle_PlayActions m_Puzzle_PlayActionsCallbackInterface;

	// Token: 0x0400033C RID: 828
	private readonly InputAction m_Puzzle_Play_Left_Click;

	// Token: 0x0400033D RID: 829
	private readonly InputAction m_Puzzle_Play_Escape;

	// Token: 0x0400033E RID: 830
	private readonly InputAction m_Puzzle_Play_Right_Click;

	// Token: 0x0400033F RID: 831
	private readonly InputAction m_Puzzle_Play_QE_rotate;

	// Token: 0x04000340 RID: 832
	private readonly InputActionMap m_Editor;

	// Token: 0x04000341 RID: 833
	private Input_main.IEditorActions m_EditorActionsCallbackInterface;

	// Token: 0x04000342 RID: 834
	private readonly InputAction m_Editor_Z;

	// Token: 0x04000343 RID: 835
	private readonly InputActionMap m_am_void;

	// Token: 0x04000344 RID: 836
	private Input_main.IAm_voidActions m_Am_voidActionsCallbackInterface;

	// Token: 0x04000345 RID: 837
	private readonly InputAction m_am_void_Newaction;

	// Token: 0x04000346 RID: 838
	private readonly InputActionMap m_am_menu;

	// Token: 0x04000347 RID: 839
	private Input_main.IAm_menuActions m_Am_menuActionsCallbackInterface;

	// Token: 0x04000348 RID: 840
	private readonly InputAction m_am_menu_escape;

	// Token: 0x04000349 RID: 841
	private readonly InputActionMap m_am_setting;

	// Token: 0x0400034A RID: 842
	private Input_main.IAm_settingActions m_Am_settingActionsCallbackInterface;

	// Token: 0x0400034B RID: 843
	private readonly InputAction m_am_setting_escape;

	// Token: 0x0400034C RID: 844
	private readonly InputAction m_am_setting_U;

	// Token: 0x0400034D RID: 845
	private readonly InputAction m_am_setting_N;

	// Token: 0x0400034E RID: 846
	private readonly InputActionMap m_am_level_map;

	// Token: 0x0400034F RID: 847
	private Input_main.IAm_level_mapActions m_Am_level_mapActionsCallbackInterface;

	// Token: 0x04000350 RID: 848
	private readonly InputAction m_am_level_map_escape;

	// Token: 0x04000351 RID: 849
	private readonly InputActionMap m_am_map;

	// Token: 0x04000352 RID: 850
	private Input_main.IAm_mapActions m_Am_mapActionsCallbackInterface;

	// Token: 0x04000353 RID: 851
	private readonly InputAction m_am_map_escape;

	// Token: 0x04000354 RID: 852
	private readonly InputActionMap m_am_map_reset;

	// Token: 0x04000355 RID: 853
	private Input_main.IAm_map_resetActions m_Am_map_resetActionsCallbackInterface;

	// Token: 0x04000356 RID: 854
	private readonly InputAction m_am_map_reset_escape;

	// Token: 0x04000357 RID: 855
	private readonly InputActionMap m_am_play;

	// Token: 0x04000358 RID: 856
	private Input_main.IAm_playActions m_Am_playActionsCallbackInterface;

	// Token: 0x04000359 RID: 857
	private readonly InputAction m_am_play_escape;

	// Token: 0x0400035A RID: 858
	private readonly InputAction m_am_play_Scroll;

	// Token: 0x0400035B RID: 859
	private readonly InputAction m_am_play_Scroll_Center;

	// Token: 0x0400035C RID: 860
	private readonly InputAction m_am_play_Move_Map;

	// Token: 0x0400035D RID: 861
	private readonly InputAction m_am_play_Mouse_Position;

	// Token: 0x0400035E RID: 862
	private readonly InputAction m_am_play_Find_Group_1;

	// Token: 0x0400035F RID: 863
	private readonly InputAction m_am_play_Find_Group_2;

	// Token: 0x04000360 RID: 864
	private readonly InputAction m_am_play_Find_Group_3;

	// Token: 0x04000361 RID: 865
	private readonly InputAction m_am_play_WASD;

	// Token: 0x04000362 RID: 866
	private readonly InputAction m_am_play_Z_key;

	// Token: 0x04000363 RID: 867
	private readonly InputAction m_am_play_Q_key;

	// Token: 0x04000364 RID: 868
	private readonly InputAction m_am_play_Shift_mod;

	// Token: 0x04000365 RID: 869
	private readonly InputAction m_am_play_Alt_mod;

	// Token: 0x04000366 RID: 870
	private readonly InputAction m_am_play_R_key;

	// Token: 0x04000367 RID: 871
	private readonly InputAction m_am_play_F_key;

	// Token: 0x04000368 RID: 872
	private readonly InputActionMap m_am_tutorial_1;

	// Token: 0x04000369 RID: 873
	private Input_main.IAm_tutorial_1Actions m_Am_tutorial_1ActionsCallbackInterface;

	// Token: 0x0400036A RID: 874
	private readonly InputAction m_am_tutorial_1_escape;

	// Token: 0x0400036B RID: 875
	private readonly InputActionMap m_am_tutorial_2;

	// Token: 0x0400036C RID: 876
	private Input_main.IAm_tutorial_2Actions m_Am_tutorial_2ActionsCallbackInterface;

	// Token: 0x0400036D RID: 877
	private readonly InputAction m_am_tutorial_2_escape;

	// Token: 0x0400036E RID: 878
	private readonly InputActionMap m_am_tutorial_setting;

	// Token: 0x0400036F RID: 879
	private Input_main.IAm_tutorial_settingActions m_Am_tutorial_settingActionsCallbackInterface;

	// Token: 0x04000370 RID: 880
	private readonly InputAction m_am_tutorial_setting_escape;

	// Token: 0x04000371 RID: 881
	private int m_Mouse_KeyboardSchemeIndex = -1;

	// Token: 0x0200016E RID: 366
	public struct MainActions
	{
		// Token: 0x06000840 RID: 2112 RVA: 0x0002536D File Offset: 0x0002356D
		public MainActions(Input_main wrapper)
		{
			this.m_Wrapper = wrapper;
		}

		// Token: 0x1700010C RID: 268
		// (get) Token: 0x06000841 RID: 2113 RVA: 0x00025376 File Offset: 0x00023576
		public InputAction Mouse_position
		{
			get
			{
				return this.m_Wrapper.m_Main_Mouse_position;
			}
		}

		// Token: 0x1700010D RID: 269
		// (get) Token: 0x06000842 RID: 2114 RVA: 0x00025383 File Offset: 0x00023583
		public InputAction Key_1
		{
			get
			{
				return this.m_Wrapper.m_Main_Key_1;
			}
		}

		// Token: 0x1700010E RID: 270
		// (get) Token: 0x06000843 RID: 2115 RVA: 0x00025390 File Offset: 0x00023590
		public InputAction Left_Mouse_Click
		{
			get
			{
				return this.m_Wrapper.m_Main_Left_Mouse_Click;
			}
		}

		// Token: 0x1700010F RID: 271
		// (get) Token: 0x06000844 RID: 2116 RVA: 0x0002539D File Offset: 0x0002359D
		public InputAction Scrolling
		{
			get
			{
				return this.m_Wrapper.m_Main_Scrolling;
			}
		}

		// Token: 0x06000845 RID: 2117 RVA: 0x000253AA File Offset: 0x000235AA
		public InputActionMap Get()
		{
			return this.m_Wrapper.m_Main;
		}

		// Token: 0x06000846 RID: 2118 RVA: 0x000253B7 File Offset: 0x000235B7
		public void Enable()
		{
			this.Get().Enable();
		}

		// Token: 0x06000847 RID: 2119 RVA: 0x000253C4 File Offset: 0x000235C4
		public void Disable()
		{
			this.Get().Disable();
		}

		// Token: 0x17000110 RID: 272
		// (get) Token: 0x06000848 RID: 2120 RVA: 0x000253D1 File Offset: 0x000235D1
		public bool enabled
		{
			get
			{
				return this.Get().enabled;
			}
		}

		// Token: 0x06000849 RID: 2121 RVA: 0x000253DE File Offset: 0x000235DE
		public static implicit operator InputActionMap(Input_main.MainActions set)
		{
			return set.Get();
		}

		// Token: 0x0600084A RID: 2122 RVA: 0x000253E8 File Offset: 0x000235E8
		public void SetCallbacks(Input_main.IMainActions instance)
		{
			if (this.m_Wrapper.m_MainActionsCallbackInterface != null)
			{
				this.Mouse_position.started -= this.m_Wrapper.m_MainActionsCallbackInterface.OnMouse_position;
				this.Mouse_position.performed -= this.m_Wrapper.m_MainActionsCallbackInterface.OnMouse_position;
				this.Mouse_position.canceled -= this.m_Wrapper.m_MainActionsCallbackInterface.OnMouse_position;
				this.Key_1.started -= this.m_Wrapper.m_MainActionsCallbackInterface.OnKey_1;
				this.Key_1.performed -= this.m_Wrapper.m_MainActionsCallbackInterface.OnKey_1;
				this.Key_1.canceled -= this.m_Wrapper.m_MainActionsCallbackInterface.OnKey_1;
				this.Left_Mouse_Click.started -= this.m_Wrapper.m_MainActionsCallbackInterface.OnLeft_Mouse_Click;
				this.Left_Mouse_Click.performed -= this.m_Wrapper.m_MainActionsCallbackInterface.OnLeft_Mouse_Click;
				this.Left_Mouse_Click.canceled -= this.m_Wrapper.m_MainActionsCallbackInterface.OnLeft_Mouse_Click;
				this.Scrolling.started -= this.m_Wrapper.m_MainActionsCallbackInterface.OnScrolling;
				this.Scrolling.performed -= this.m_Wrapper.m_MainActionsCallbackInterface.OnScrolling;
				this.Scrolling.canceled -= this.m_Wrapper.m_MainActionsCallbackInterface.OnScrolling;
			}
			this.m_Wrapper.m_MainActionsCallbackInterface = instance;
			if (instance != null)
			{
				this.Mouse_position.started += instance.OnMouse_position;
				this.Mouse_position.performed += instance.OnMouse_position;
				this.Mouse_position.canceled += instance.OnMouse_position;
				this.Key_1.started += instance.OnKey_1;
				this.Key_1.performed += instance.OnKey_1;
				this.Key_1.canceled += instance.OnKey_1;
				this.Left_Mouse_Click.started += instance.OnLeft_Mouse_Click;
				this.Left_Mouse_Click.performed += instance.OnLeft_Mouse_Click;
				this.Left_Mouse_Click.canceled += instance.OnLeft_Mouse_Click;
				this.Scrolling.started += instance.OnScrolling;
				this.Scrolling.performed += instance.OnScrolling;
				this.Scrolling.canceled += instance.OnScrolling;
			}
		}

		// Token: 0x0400092C RID: 2348
		private Input_main m_Wrapper;
	}

	// Token: 0x0200016F RID: 367
	public struct AddActions
	{
		// Token: 0x0600084B RID: 2123 RVA: 0x000256CF File Offset: 0x000238CF
		public AddActions(Input_main wrapper)
		{
			this.m_Wrapper = wrapper;
		}

		// Token: 0x17000111 RID: 273
		// (get) Token: 0x0600084C RID: 2124 RVA: 0x000256D8 File Offset: 0x000238D8
		public InputAction Key_2
		{
			get
			{
				return this.m_Wrapper.m_Add_Key_2;
			}
		}

		// Token: 0x0600084D RID: 2125 RVA: 0x000256E5 File Offset: 0x000238E5
		public InputActionMap Get()
		{
			return this.m_Wrapper.m_Add;
		}

		// Token: 0x0600084E RID: 2126 RVA: 0x000256F2 File Offset: 0x000238F2
		public void Enable()
		{
			this.Get().Enable();
		}

		// Token: 0x0600084F RID: 2127 RVA: 0x000256FF File Offset: 0x000238FF
		public void Disable()
		{
			this.Get().Disable();
		}

		// Token: 0x17000112 RID: 274
		// (get) Token: 0x06000850 RID: 2128 RVA: 0x0002570C File Offset: 0x0002390C
		public bool enabled
		{
			get
			{
				return this.Get().enabled;
			}
		}

		// Token: 0x06000851 RID: 2129 RVA: 0x00025719 File Offset: 0x00023919
		public static implicit operator InputActionMap(Input_main.AddActions set)
		{
			return set.Get();
		}

		// Token: 0x06000852 RID: 2130 RVA: 0x00025724 File Offset: 0x00023924
		public void SetCallbacks(Input_main.IAddActions instance)
		{
			if (this.m_Wrapper.m_AddActionsCallbackInterface != null)
			{
				this.Key_2.started -= this.m_Wrapper.m_AddActionsCallbackInterface.OnKey_2;
				this.Key_2.performed -= this.m_Wrapper.m_AddActionsCallbackInterface.OnKey_2;
				this.Key_2.canceled -= this.m_Wrapper.m_AddActionsCallbackInterface.OnKey_2;
			}
			this.m_Wrapper.m_AddActionsCallbackInterface = instance;
			if (instance != null)
			{
				this.Key_2.started += instance.OnKey_2;
				this.Key_2.performed += instance.OnKey_2;
				this.Key_2.canceled += instance.OnKey_2;
			}
		}

		// Token: 0x0400092D RID: 2349
		private Input_main m_Wrapper;
	}

	// Token: 0x02000170 RID: 368
	public struct AllActions
	{
		// Token: 0x06000853 RID: 2131 RVA: 0x000257FB File Offset: 0x000239FB
		public AllActions(Input_main wrapper)
		{
			this.m_Wrapper = wrapper;
		}

		// Token: 0x17000113 RID: 275
		// (get) Token: 0x06000854 RID: 2132 RVA: 0x00025804 File Offset: 0x00023A04
		public InputAction Key_3
		{
			get
			{
				return this.m_Wrapper.m_All_Key_3;
			}
		}

		// Token: 0x17000114 RID: 276
		// (get) Token: 0x06000855 RID: 2133 RVA: 0x00025811 File Offset: 0x00023A11
		public InputAction Q_key
		{
			get
			{
				return this.m_Wrapper.m_All_Q_key;
			}
		}

		// Token: 0x17000115 RID: 277
		// (get) Token: 0x06000856 RID: 2134 RVA: 0x0002581E File Offset: 0x00023A1E
		public InputAction Mouse_Position
		{
			get
			{
				return this.m_Wrapper.m_All_Mouse_Position;
			}
		}

		// Token: 0x17000116 RID: 278
		// (get) Token: 0x06000857 RID: 2135 RVA: 0x0002582B File Offset: 0x00023A2B
		public InputAction Z_key
		{
			get
			{
				return this.m_Wrapper.m_All_Z_key;
			}
		}

		// Token: 0x17000117 RID: 279
		// (get) Token: 0x06000858 RID: 2136 RVA: 0x00025838 File Offset: 0x00023A38
		public InputAction Reset_data_setting
		{
			get
			{
				return this.m_Wrapper.m_All_Reset_data_setting;
			}
		}

		// Token: 0x17000118 RID: 280
		// (get) Token: 0x06000859 RID: 2137 RVA: 0x00025845 File Offset: 0x00023A45
		public InputAction Reset_data_game
		{
			get
			{
				return this.m_Wrapper.m_All_Reset_data_game;
			}
		}

		// Token: 0x17000119 RID: 281
		// (get) Token: 0x0600085A RID: 2138 RVA: 0x00025852 File Offset: 0x00023A52
		public InputAction Reset_data_press_key
		{
			get
			{
				return this.m_Wrapper.m_All_Reset_data_press_key;
			}
		}

		// Token: 0x1700011A RID: 282
		// (get) Token: 0x0600085B RID: 2139 RVA: 0x0002585F File Offset: 0x00023A5F
		public InputAction Reset_this_scene
		{
			get
			{
				return this.m_Wrapper.m_All_Reset_this_scene;
			}
		}

		// Token: 0x1700011B RID: 283
		// (get) Token: 0x0600085C RID: 2140 RVA: 0x0002586C File Offset: 0x00023A6C
		public InputAction Test_Scroll
		{
			get
			{
				return this.m_Wrapper.m_All_Test_Scroll;
			}
		}

		// Token: 0x1700011C RID: 284
		// (get) Token: 0x0600085D RID: 2141 RVA: 0x00025879 File Offset: 0x00023A79
		public InputAction Test_Alpha
		{
			get
			{
				return this.m_Wrapper.m_All_Test_Alpha;
			}
		}

		// Token: 0x0600085E RID: 2142 RVA: 0x00025886 File Offset: 0x00023A86
		public InputActionMap Get()
		{
			return this.m_Wrapper.m_All;
		}

		// Token: 0x0600085F RID: 2143 RVA: 0x00025893 File Offset: 0x00023A93
		public void Enable()
		{
			this.Get().Enable();
		}

		// Token: 0x06000860 RID: 2144 RVA: 0x000258A0 File Offset: 0x00023AA0
		public void Disable()
		{
			this.Get().Disable();
		}

		// Token: 0x1700011D RID: 285
		// (get) Token: 0x06000861 RID: 2145 RVA: 0x000258AD File Offset: 0x00023AAD
		public bool enabled
		{
			get
			{
				return this.Get().enabled;
			}
		}

		// Token: 0x06000862 RID: 2146 RVA: 0x000258BA File Offset: 0x00023ABA
		public static implicit operator InputActionMap(Input_main.AllActions set)
		{
			return set.Get();
		}

		// Token: 0x06000863 RID: 2147 RVA: 0x000258C4 File Offset: 0x00023AC4
		public void SetCallbacks(Input_main.IAllActions instance)
		{
			if (this.m_Wrapper.m_AllActionsCallbackInterface != null)
			{
				this.Key_3.started -= this.m_Wrapper.m_AllActionsCallbackInterface.OnKey_3;
				this.Key_3.performed -= this.m_Wrapper.m_AllActionsCallbackInterface.OnKey_3;
				this.Key_3.canceled -= this.m_Wrapper.m_AllActionsCallbackInterface.OnKey_3;
				this.Q_key.started -= this.m_Wrapper.m_AllActionsCallbackInterface.OnQ_key;
				this.Q_key.performed -= this.m_Wrapper.m_AllActionsCallbackInterface.OnQ_key;
				this.Q_key.canceled -= this.m_Wrapper.m_AllActionsCallbackInterface.OnQ_key;
				this.Mouse_Position.started -= this.m_Wrapper.m_AllActionsCallbackInterface.OnMouse_Position;
				this.Mouse_Position.performed -= this.m_Wrapper.m_AllActionsCallbackInterface.OnMouse_Position;
				this.Mouse_Position.canceled -= this.m_Wrapper.m_AllActionsCallbackInterface.OnMouse_Position;
				this.Z_key.started -= this.m_Wrapper.m_AllActionsCallbackInterface.OnZ_key;
				this.Z_key.performed -= this.m_Wrapper.m_AllActionsCallbackInterface.OnZ_key;
				this.Z_key.canceled -= this.m_Wrapper.m_AllActionsCallbackInterface.OnZ_key;
				this.Reset_data_setting.started -= this.m_Wrapper.m_AllActionsCallbackInterface.OnReset_data_setting;
				this.Reset_data_setting.performed -= this.m_Wrapper.m_AllActionsCallbackInterface.OnReset_data_setting;
				this.Reset_data_setting.canceled -= this.m_Wrapper.m_AllActionsCallbackInterface.OnReset_data_setting;
				this.Reset_data_game.started -= this.m_Wrapper.m_AllActionsCallbackInterface.OnReset_data_game;
				this.Reset_data_game.performed -= this.m_Wrapper.m_AllActionsCallbackInterface.OnReset_data_game;
				this.Reset_data_game.canceled -= this.m_Wrapper.m_AllActionsCallbackInterface.OnReset_data_game;
				this.Reset_data_press_key.started -= this.m_Wrapper.m_AllActionsCallbackInterface.OnReset_data_press_key;
				this.Reset_data_press_key.performed -= this.m_Wrapper.m_AllActionsCallbackInterface.OnReset_data_press_key;
				this.Reset_data_press_key.canceled -= this.m_Wrapper.m_AllActionsCallbackInterface.OnReset_data_press_key;
				this.Reset_this_scene.started -= this.m_Wrapper.m_AllActionsCallbackInterface.OnReset_this_scene;
				this.Reset_this_scene.performed -= this.m_Wrapper.m_AllActionsCallbackInterface.OnReset_this_scene;
				this.Reset_this_scene.canceled -= this.m_Wrapper.m_AllActionsCallbackInterface.OnReset_this_scene;
				this.Test_Scroll.started -= this.m_Wrapper.m_AllActionsCallbackInterface.OnTest_Scroll;
				this.Test_Scroll.performed -= this.m_Wrapper.m_AllActionsCallbackInterface.OnTest_Scroll;
				this.Test_Scroll.canceled -= this.m_Wrapper.m_AllActionsCallbackInterface.OnTest_Scroll;
				this.Test_Alpha.started -= this.m_Wrapper.m_AllActionsCallbackInterface.OnTest_Alpha;
				this.Test_Alpha.performed -= this.m_Wrapper.m_AllActionsCallbackInterface.OnTest_Alpha;
				this.Test_Alpha.canceled -= this.m_Wrapper.m_AllActionsCallbackInterface.OnTest_Alpha;
			}
			this.m_Wrapper.m_AllActionsCallbackInterface = instance;
			if (instance != null)
			{
				this.Key_3.started += instance.OnKey_3;
				this.Key_3.performed += instance.OnKey_3;
				this.Key_3.canceled += instance.OnKey_3;
				this.Q_key.started += instance.OnQ_key;
				this.Q_key.performed += instance.OnQ_key;
				this.Q_key.canceled += instance.OnQ_key;
				this.Mouse_Position.started += instance.OnMouse_Position;
				this.Mouse_Position.performed += instance.OnMouse_Position;
				this.Mouse_Position.canceled += instance.OnMouse_Position;
				this.Z_key.started += instance.OnZ_key;
				this.Z_key.performed += instance.OnZ_key;
				this.Z_key.canceled += instance.OnZ_key;
				this.Reset_data_setting.started += instance.OnReset_data_setting;
				this.Reset_data_setting.performed += instance.OnReset_data_setting;
				this.Reset_data_setting.canceled += instance.OnReset_data_setting;
				this.Reset_data_game.started += instance.OnReset_data_game;
				this.Reset_data_game.performed += instance.OnReset_data_game;
				this.Reset_data_game.canceled += instance.OnReset_data_game;
				this.Reset_data_press_key.started += instance.OnReset_data_press_key;
				this.Reset_data_press_key.performed += instance.OnReset_data_press_key;
				this.Reset_data_press_key.canceled += instance.OnReset_data_press_key;
				this.Reset_this_scene.started += instance.OnReset_this_scene;
				this.Reset_this_scene.performed += instance.OnReset_this_scene;
				this.Reset_this_scene.canceled += instance.OnReset_this_scene;
				this.Test_Scroll.started += instance.OnTest_Scroll;
				this.Test_Scroll.performed += instance.OnTest_Scroll;
				this.Test_Scroll.canceled += instance.OnTest_Scroll;
				this.Test_Alpha.started += instance.OnTest_Alpha;
				this.Test_Alpha.performed += instance.OnTest_Alpha;
				this.Test_Alpha.canceled += instance.OnTest_Alpha;
			}
		}

		// Token: 0x0400092E RID: 2350
		private Input_main m_Wrapper;
	}

	// Token: 0x02000171 RID: 369
	public struct Menu_MainActions
	{
		// Token: 0x06000864 RID: 2148 RVA: 0x00025FBF File Offset: 0x000241BF
		public Menu_MainActions(Input_main wrapper)
		{
			this.m_Wrapper = wrapper;
		}

		// Token: 0x1700011E RID: 286
		// (get) Token: 0x06000865 RID: 2149 RVA: 0x00025FC8 File Offset: 0x000241C8
		public InputAction Escape
		{
			get
			{
				return this.m_Wrapper.m_Menu_Main_Escape;
			}
		}

		// Token: 0x06000866 RID: 2150 RVA: 0x00025FD5 File Offset: 0x000241D5
		public InputActionMap Get()
		{
			return this.m_Wrapper.m_Menu_Main;
		}

		// Token: 0x06000867 RID: 2151 RVA: 0x00025FE2 File Offset: 0x000241E2
		public void Enable()
		{
			this.Get().Enable();
		}

		// Token: 0x06000868 RID: 2152 RVA: 0x00025FEF File Offset: 0x000241EF
		public void Disable()
		{
			this.Get().Disable();
		}

		// Token: 0x1700011F RID: 287
		// (get) Token: 0x06000869 RID: 2153 RVA: 0x00025FFC File Offset: 0x000241FC
		public bool enabled
		{
			get
			{
				return this.Get().enabled;
			}
		}

		// Token: 0x0600086A RID: 2154 RVA: 0x00026009 File Offset: 0x00024209
		public static implicit operator InputActionMap(Input_main.Menu_MainActions set)
		{
			return set.Get();
		}

		// Token: 0x0600086B RID: 2155 RVA: 0x00026014 File Offset: 0x00024214
		public void SetCallbacks(Input_main.IMenu_MainActions instance)
		{
			if (this.m_Wrapper.m_Menu_MainActionsCallbackInterface != null)
			{
				this.Escape.started -= this.m_Wrapper.m_Menu_MainActionsCallbackInterface.OnEscape;
				this.Escape.performed -= this.m_Wrapper.m_Menu_MainActionsCallbackInterface.OnEscape;
				this.Escape.canceled -= this.m_Wrapper.m_Menu_MainActionsCallbackInterface.OnEscape;
			}
			this.m_Wrapper.m_Menu_MainActionsCallbackInterface = instance;
			if (instance != null)
			{
				this.Escape.started += instance.OnEscape;
				this.Escape.performed += instance.OnEscape;
				this.Escape.canceled += instance.OnEscape;
			}
		}

		// Token: 0x0400092F RID: 2351
		private Input_main m_Wrapper;
	}

	// Token: 0x02000172 RID: 370
	public struct Menu_SettingActions
	{
		// Token: 0x0600086C RID: 2156 RVA: 0x000260EB File Offset: 0x000242EB
		public Menu_SettingActions(Input_main wrapper)
		{
			this.m_Wrapper = wrapper;
		}

		// Token: 0x17000120 RID: 288
		// (get) Token: 0x0600086D RID: 2157 RVA: 0x000260F4 File Offset: 0x000242F4
		public InputAction Escape
		{
			get
			{
				return this.m_Wrapper.m_Menu_Setting_Escape;
			}
		}

		// Token: 0x17000121 RID: 289
		// (get) Token: 0x0600086E RID: 2158 RVA: 0x00026101 File Offset: 0x00024301
		public InputAction U
		{
			get
			{
				return this.m_Wrapper.m_Menu_Setting_U;
			}
		}

		// Token: 0x17000122 RID: 290
		// (get) Token: 0x0600086F RID: 2159 RVA: 0x0002610E File Offset: 0x0002430E
		public InputAction N
		{
			get
			{
				return this.m_Wrapper.m_Menu_Setting_N;
			}
		}

		// Token: 0x06000870 RID: 2160 RVA: 0x0002611B File Offset: 0x0002431B
		public InputActionMap Get()
		{
			return this.m_Wrapper.m_Menu_Setting;
		}

		// Token: 0x06000871 RID: 2161 RVA: 0x00026128 File Offset: 0x00024328
		public void Enable()
		{
			this.Get().Enable();
		}

		// Token: 0x06000872 RID: 2162 RVA: 0x00026135 File Offset: 0x00024335
		public void Disable()
		{
			this.Get().Disable();
		}

		// Token: 0x17000123 RID: 291
		// (get) Token: 0x06000873 RID: 2163 RVA: 0x00026142 File Offset: 0x00024342
		public bool enabled
		{
			get
			{
				return this.Get().enabled;
			}
		}

		// Token: 0x06000874 RID: 2164 RVA: 0x0002614F File Offset: 0x0002434F
		public static implicit operator InputActionMap(Input_main.Menu_SettingActions set)
		{
			return set.Get();
		}

		// Token: 0x06000875 RID: 2165 RVA: 0x00026158 File Offset: 0x00024358
		public void SetCallbacks(Input_main.IMenu_SettingActions instance)
		{
			if (this.m_Wrapper.m_Menu_SettingActionsCallbackInterface != null)
			{
				this.Escape.started -= this.m_Wrapper.m_Menu_SettingActionsCallbackInterface.OnEscape;
				this.Escape.performed -= this.m_Wrapper.m_Menu_SettingActionsCallbackInterface.OnEscape;
				this.Escape.canceled -= this.m_Wrapper.m_Menu_SettingActionsCallbackInterface.OnEscape;
				this.U.started -= this.m_Wrapper.m_Menu_SettingActionsCallbackInterface.OnU;
				this.U.performed -= this.m_Wrapper.m_Menu_SettingActionsCallbackInterface.OnU;
				this.U.canceled -= this.m_Wrapper.m_Menu_SettingActionsCallbackInterface.OnU;
				this.N.started -= this.m_Wrapper.m_Menu_SettingActionsCallbackInterface.OnN;
				this.N.performed -= this.m_Wrapper.m_Menu_SettingActionsCallbackInterface.OnN;
				this.N.canceled -= this.m_Wrapper.m_Menu_SettingActionsCallbackInterface.OnN;
			}
			this.m_Wrapper.m_Menu_SettingActionsCallbackInterface = instance;
			if (instance != null)
			{
				this.Escape.started += instance.OnEscape;
				this.Escape.performed += instance.OnEscape;
				this.Escape.canceled += instance.OnEscape;
				this.U.started += instance.OnU;
				this.U.performed += instance.OnU;
				this.U.canceled += instance.OnU;
				this.N.started += instance.OnN;
				this.N.performed += instance.OnN;
				this.N.canceled += instance.OnN;
			}
		}

		// Token: 0x04000930 RID: 2352
		private Input_main m_Wrapper;
	}

	// Token: 0x02000173 RID: 371
	public struct End_GameActions
	{
		// Token: 0x06000876 RID: 2166 RVA: 0x00026391 File Offset: 0x00024591
		public End_GameActions(Input_main wrapper)
		{
			this.m_Wrapper = wrapper;
		}

		// Token: 0x17000124 RID: 292
		// (get) Token: 0x06000877 RID: 2167 RVA: 0x0002639A File Offset: 0x0002459A
		public InputAction Escape
		{
			get
			{
				return this.m_Wrapper.m_End_Game_Escape;
			}
		}

		// Token: 0x06000878 RID: 2168 RVA: 0x000263A7 File Offset: 0x000245A7
		public InputActionMap Get()
		{
			return this.m_Wrapper.m_End_Game;
		}

		// Token: 0x06000879 RID: 2169 RVA: 0x000263B4 File Offset: 0x000245B4
		public void Enable()
		{
			this.Get().Enable();
		}

		// Token: 0x0600087A RID: 2170 RVA: 0x000263C1 File Offset: 0x000245C1
		public void Disable()
		{
			this.Get().Disable();
		}

		// Token: 0x17000125 RID: 293
		// (get) Token: 0x0600087B RID: 2171 RVA: 0x000263CE File Offset: 0x000245CE
		public bool enabled
		{
			get
			{
				return this.Get().enabled;
			}
		}

		// Token: 0x0600087C RID: 2172 RVA: 0x000263DB File Offset: 0x000245DB
		public static implicit operator InputActionMap(Input_main.End_GameActions set)
		{
			return set.Get();
		}

		// Token: 0x0600087D RID: 2173 RVA: 0x000263E4 File Offset: 0x000245E4
		public void SetCallbacks(Input_main.IEnd_GameActions instance)
		{
			if (this.m_Wrapper.m_End_GameActionsCallbackInterface != null)
			{
				this.Escape.started -= this.m_Wrapper.m_End_GameActionsCallbackInterface.OnEscape;
				this.Escape.performed -= this.m_Wrapper.m_End_GameActionsCallbackInterface.OnEscape;
				this.Escape.canceled -= this.m_Wrapper.m_End_GameActionsCallbackInterface.OnEscape;
			}
			this.m_Wrapper.m_End_GameActionsCallbackInterface = instance;
			if (instance != null)
			{
				this.Escape.started += instance.OnEscape;
				this.Escape.performed += instance.OnEscape;
				this.Escape.canceled += instance.OnEscape;
			}
		}

		// Token: 0x04000931 RID: 2353
		private Input_main m_Wrapper;
	}

	// Token: 0x02000174 RID: 372
	public struct Menu_ResetActions
	{
		// Token: 0x0600087E RID: 2174 RVA: 0x000264BB File Offset: 0x000246BB
		public Menu_ResetActions(Input_main wrapper)
		{
			this.m_Wrapper = wrapper;
		}

		// Token: 0x17000126 RID: 294
		// (get) Token: 0x0600087F RID: 2175 RVA: 0x000264C4 File Offset: 0x000246C4
		public InputAction Escape
		{
			get
			{
				return this.m_Wrapper.m_Menu_Reset_Escape;
			}
		}

		// Token: 0x06000880 RID: 2176 RVA: 0x000264D1 File Offset: 0x000246D1
		public InputActionMap Get()
		{
			return this.m_Wrapper.m_Menu_Reset;
		}

		// Token: 0x06000881 RID: 2177 RVA: 0x000264DE File Offset: 0x000246DE
		public void Enable()
		{
			this.Get().Enable();
		}

		// Token: 0x06000882 RID: 2178 RVA: 0x000264EB File Offset: 0x000246EB
		public void Disable()
		{
			this.Get().Disable();
		}

		// Token: 0x17000127 RID: 295
		// (get) Token: 0x06000883 RID: 2179 RVA: 0x000264F8 File Offset: 0x000246F8
		public bool enabled
		{
			get
			{
				return this.Get().enabled;
			}
		}

		// Token: 0x06000884 RID: 2180 RVA: 0x00026505 File Offset: 0x00024705
		public static implicit operator InputActionMap(Input_main.Menu_ResetActions set)
		{
			return set.Get();
		}

		// Token: 0x06000885 RID: 2181 RVA: 0x00026510 File Offset: 0x00024710
		public void SetCallbacks(Input_main.IMenu_ResetActions instance)
		{
			if (this.m_Wrapper.m_Menu_ResetActionsCallbackInterface != null)
			{
				this.Escape.started -= this.m_Wrapper.m_Menu_ResetActionsCallbackInterface.OnEscape;
				this.Escape.performed -= this.m_Wrapper.m_Menu_ResetActionsCallbackInterface.OnEscape;
				this.Escape.canceled -= this.m_Wrapper.m_Menu_ResetActionsCallbackInterface.OnEscape;
			}
			this.m_Wrapper.m_Menu_ResetActionsCallbackInterface = instance;
			if (instance != null)
			{
				this.Escape.started += instance.OnEscape;
				this.Escape.performed += instance.OnEscape;
				this.Escape.canceled += instance.OnEscape;
			}
		}

		// Token: 0x04000932 RID: 2354
		private Input_main m_Wrapper;
	}

	// Token: 0x02000175 RID: 373
	public struct VoidActions
	{
		// Token: 0x06000886 RID: 2182 RVA: 0x000265E7 File Offset: 0x000247E7
		public VoidActions(Input_main wrapper)
		{
			this.m_Wrapper = wrapper;
		}

		// Token: 0x17000128 RID: 296
		// (get) Token: 0x06000887 RID: 2183 RVA: 0x000265F0 File Offset: 0x000247F0
		public InputAction Escape
		{
			get
			{
				return this.m_Wrapper.m_Void_Escape;
			}
		}

		// Token: 0x06000888 RID: 2184 RVA: 0x000265FD File Offset: 0x000247FD
		public InputActionMap Get()
		{
			return this.m_Wrapper.m_Void;
		}

		// Token: 0x06000889 RID: 2185 RVA: 0x0002660A File Offset: 0x0002480A
		public void Enable()
		{
			this.Get().Enable();
		}

		// Token: 0x0600088A RID: 2186 RVA: 0x00026617 File Offset: 0x00024817
		public void Disable()
		{
			this.Get().Disable();
		}

		// Token: 0x17000129 RID: 297
		// (get) Token: 0x0600088B RID: 2187 RVA: 0x00026624 File Offset: 0x00024824
		public bool enabled
		{
			get
			{
				return this.Get().enabled;
			}
		}

		// Token: 0x0600088C RID: 2188 RVA: 0x00026631 File Offset: 0x00024831
		public static implicit operator InputActionMap(Input_main.VoidActions set)
		{
			return set.Get();
		}

		// Token: 0x0600088D RID: 2189 RVA: 0x0002663C File Offset: 0x0002483C
		public void SetCallbacks(Input_main.IVoidActions instance)
		{
			if (this.m_Wrapper.m_VoidActionsCallbackInterface != null)
			{
				this.Escape.started -= this.m_Wrapper.m_VoidActionsCallbackInterface.OnEscape;
				this.Escape.performed -= this.m_Wrapper.m_VoidActionsCallbackInterface.OnEscape;
				this.Escape.canceled -= this.m_Wrapper.m_VoidActionsCallbackInterface.OnEscape;
			}
			this.m_Wrapper.m_VoidActionsCallbackInterface = instance;
			if (instance != null)
			{
				this.Escape.started += instance.OnEscape;
				this.Escape.performed += instance.OnEscape;
				this.Escape.canceled += instance.OnEscape;
			}
		}

		// Token: 0x04000933 RID: 2355
		private Input_main m_Wrapper;
	}

	// Token: 0x02000176 RID: 374
	public struct MapActions
	{
		// Token: 0x0600088E RID: 2190 RVA: 0x00026713 File Offset: 0x00024913
		public MapActions(Input_main wrapper)
		{
			this.m_Wrapper = wrapper;
		}

		// Token: 0x1700012A RID: 298
		// (get) Token: 0x0600088F RID: 2191 RVA: 0x0002671C File Offset: 0x0002491C
		public InputAction Escape
		{
			get
			{
				return this.m_Wrapper.m_Map_Escape;
			}
		}

		// Token: 0x06000890 RID: 2192 RVA: 0x00026729 File Offset: 0x00024929
		public InputActionMap Get()
		{
			return this.m_Wrapper.m_Map;
		}

		// Token: 0x06000891 RID: 2193 RVA: 0x00026736 File Offset: 0x00024936
		public void Enable()
		{
			this.Get().Enable();
		}

		// Token: 0x06000892 RID: 2194 RVA: 0x00026743 File Offset: 0x00024943
		public void Disable()
		{
			this.Get().Disable();
		}

		// Token: 0x1700012B RID: 299
		// (get) Token: 0x06000893 RID: 2195 RVA: 0x00026750 File Offset: 0x00024950
		public bool enabled
		{
			get
			{
				return this.Get().enabled;
			}
		}

		// Token: 0x06000894 RID: 2196 RVA: 0x0002675D File Offset: 0x0002495D
		public static implicit operator InputActionMap(Input_main.MapActions set)
		{
			return set.Get();
		}

		// Token: 0x06000895 RID: 2197 RVA: 0x00026768 File Offset: 0x00024968
		public void SetCallbacks(Input_main.IMapActions instance)
		{
			if (this.m_Wrapper.m_MapActionsCallbackInterface != null)
			{
				this.Escape.started -= this.m_Wrapper.m_MapActionsCallbackInterface.OnEscape;
				this.Escape.performed -= this.m_Wrapper.m_MapActionsCallbackInterface.OnEscape;
				this.Escape.canceled -= this.m_Wrapper.m_MapActionsCallbackInterface.OnEscape;
			}
			this.m_Wrapper.m_MapActionsCallbackInterface = instance;
			if (instance != null)
			{
				this.Escape.started += instance.OnEscape;
				this.Escape.performed += instance.OnEscape;
				this.Escape.canceled += instance.OnEscape;
			}
		}

		// Token: 0x04000934 RID: 2356
		private Input_main m_Wrapper;
	}

	// Token: 0x02000177 RID: 375
	public struct Card_variantActions
	{
		// Token: 0x06000896 RID: 2198 RVA: 0x0002683F File Offset: 0x00024A3F
		public Card_variantActions(Input_main wrapper)
		{
			this.m_Wrapper = wrapper;
		}

		// Token: 0x1700012C RID: 300
		// (get) Token: 0x06000897 RID: 2199 RVA: 0x00026848 File Offset: 0x00024A48
		public InputAction Newaction
		{
			get
			{
				return this.m_Wrapper.m_Card_variant_Newaction;
			}
		}

		// Token: 0x06000898 RID: 2200 RVA: 0x00026855 File Offset: 0x00024A55
		public InputActionMap Get()
		{
			return this.m_Wrapper.m_Card_variant;
		}

		// Token: 0x06000899 RID: 2201 RVA: 0x00026862 File Offset: 0x00024A62
		public void Enable()
		{
			this.Get().Enable();
		}

		// Token: 0x0600089A RID: 2202 RVA: 0x0002686F File Offset: 0x00024A6F
		public void Disable()
		{
			this.Get().Disable();
		}

		// Token: 0x1700012D RID: 301
		// (get) Token: 0x0600089B RID: 2203 RVA: 0x0002687C File Offset: 0x00024A7C
		public bool enabled
		{
			get
			{
				return this.Get().enabled;
			}
		}

		// Token: 0x0600089C RID: 2204 RVA: 0x00026889 File Offset: 0x00024A89
		public static implicit operator InputActionMap(Input_main.Card_variantActions set)
		{
			return set.Get();
		}

		// Token: 0x0600089D RID: 2205 RVA: 0x00026894 File Offset: 0x00024A94
		public void SetCallbacks(Input_main.ICard_variantActions instance)
		{
			if (this.m_Wrapper.m_Card_variantActionsCallbackInterface != null)
			{
				this.Newaction.started -= this.m_Wrapper.m_Card_variantActionsCallbackInterface.OnNewaction;
				this.Newaction.performed -= this.m_Wrapper.m_Card_variantActionsCallbackInterface.OnNewaction;
				this.Newaction.canceled -= this.m_Wrapper.m_Card_variantActionsCallbackInterface.OnNewaction;
			}
			this.m_Wrapper.m_Card_variantActionsCallbackInterface = instance;
			if (instance != null)
			{
				this.Newaction.started += instance.OnNewaction;
				this.Newaction.performed += instance.OnNewaction;
				this.Newaction.canceled += instance.OnNewaction;
			}
		}

		// Token: 0x04000935 RID: 2357
		private Input_main m_Wrapper;
	}

	// Token: 0x02000178 RID: 376
	public struct Puzzle_PlayActions
	{
		// Token: 0x0600089E RID: 2206 RVA: 0x0002696B File Offset: 0x00024B6B
		public Puzzle_PlayActions(Input_main wrapper)
		{
			this.m_Wrapper = wrapper;
		}

		// Token: 0x1700012E RID: 302
		// (get) Token: 0x0600089F RID: 2207 RVA: 0x00026974 File Offset: 0x00024B74
		public InputAction Left_Click
		{
			get
			{
				return this.m_Wrapper.m_Puzzle_Play_Left_Click;
			}
		}

		// Token: 0x1700012F RID: 303
		// (get) Token: 0x060008A0 RID: 2208 RVA: 0x00026981 File Offset: 0x00024B81
		public InputAction Escape
		{
			get
			{
				return this.m_Wrapper.m_Puzzle_Play_Escape;
			}
		}

		// Token: 0x17000130 RID: 304
		// (get) Token: 0x060008A1 RID: 2209 RVA: 0x0002698E File Offset: 0x00024B8E
		public InputAction Right_Click
		{
			get
			{
				return this.m_Wrapper.m_Puzzle_Play_Right_Click;
			}
		}

		// Token: 0x17000131 RID: 305
		// (get) Token: 0x060008A2 RID: 2210 RVA: 0x0002699B File Offset: 0x00024B9B
		public InputAction QE_rotate
		{
			get
			{
				return this.m_Wrapper.m_Puzzle_Play_QE_rotate;
			}
		}

		// Token: 0x060008A3 RID: 2211 RVA: 0x000269A8 File Offset: 0x00024BA8
		public InputActionMap Get()
		{
			return this.m_Wrapper.m_Puzzle_Play;
		}

		// Token: 0x060008A4 RID: 2212 RVA: 0x000269B5 File Offset: 0x00024BB5
		public void Enable()
		{
			this.Get().Enable();
		}

		// Token: 0x060008A5 RID: 2213 RVA: 0x000269C2 File Offset: 0x00024BC2
		public void Disable()
		{
			this.Get().Disable();
		}

		// Token: 0x17000132 RID: 306
		// (get) Token: 0x060008A6 RID: 2214 RVA: 0x000269CF File Offset: 0x00024BCF
		public bool enabled
		{
			get
			{
				return this.Get().enabled;
			}
		}

		// Token: 0x060008A7 RID: 2215 RVA: 0x000269DC File Offset: 0x00024BDC
		public static implicit operator InputActionMap(Input_main.Puzzle_PlayActions set)
		{
			return set.Get();
		}

		// Token: 0x060008A8 RID: 2216 RVA: 0x000269E8 File Offset: 0x00024BE8
		public void SetCallbacks(Input_main.IPuzzle_PlayActions instance)
		{
			if (this.m_Wrapper.m_Puzzle_PlayActionsCallbackInterface != null)
			{
				this.Left_Click.started -= this.m_Wrapper.m_Puzzle_PlayActionsCallbackInterface.OnLeft_Click;
				this.Left_Click.performed -= this.m_Wrapper.m_Puzzle_PlayActionsCallbackInterface.OnLeft_Click;
				this.Left_Click.canceled -= this.m_Wrapper.m_Puzzle_PlayActionsCallbackInterface.OnLeft_Click;
				this.Escape.started -= this.m_Wrapper.m_Puzzle_PlayActionsCallbackInterface.OnEscape;
				this.Escape.performed -= this.m_Wrapper.m_Puzzle_PlayActionsCallbackInterface.OnEscape;
				this.Escape.canceled -= this.m_Wrapper.m_Puzzle_PlayActionsCallbackInterface.OnEscape;
				this.Right_Click.started -= this.m_Wrapper.m_Puzzle_PlayActionsCallbackInterface.OnRight_Click;
				this.Right_Click.performed -= this.m_Wrapper.m_Puzzle_PlayActionsCallbackInterface.OnRight_Click;
				this.Right_Click.canceled -= this.m_Wrapper.m_Puzzle_PlayActionsCallbackInterface.OnRight_Click;
				this.QE_rotate.started -= this.m_Wrapper.m_Puzzle_PlayActionsCallbackInterface.OnQE_rotate;
				this.QE_rotate.performed -= this.m_Wrapper.m_Puzzle_PlayActionsCallbackInterface.OnQE_rotate;
				this.QE_rotate.canceled -= this.m_Wrapper.m_Puzzle_PlayActionsCallbackInterface.OnQE_rotate;
			}
			this.m_Wrapper.m_Puzzle_PlayActionsCallbackInterface = instance;
			if (instance != null)
			{
				this.Left_Click.started += instance.OnLeft_Click;
				this.Left_Click.performed += instance.OnLeft_Click;
				this.Left_Click.canceled += instance.OnLeft_Click;
				this.Escape.started += instance.OnEscape;
				this.Escape.performed += instance.OnEscape;
				this.Escape.canceled += instance.OnEscape;
				this.Right_Click.started += instance.OnRight_Click;
				this.Right_Click.performed += instance.OnRight_Click;
				this.Right_Click.canceled += instance.OnRight_Click;
				this.QE_rotate.started += instance.OnQE_rotate;
				this.QE_rotate.performed += instance.OnQE_rotate;
				this.QE_rotate.canceled += instance.OnQE_rotate;
			}
		}

		// Token: 0x04000936 RID: 2358
		private Input_main m_Wrapper;
	}

	// Token: 0x02000179 RID: 377
	public struct EditorActions
	{
		// Token: 0x060008A9 RID: 2217 RVA: 0x00026CCF File Offset: 0x00024ECF
		public EditorActions(Input_main wrapper)
		{
			this.m_Wrapper = wrapper;
		}

		// Token: 0x17000133 RID: 307
		// (get) Token: 0x060008AA RID: 2218 RVA: 0x00026CD8 File Offset: 0x00024ED8
		public InputAction Z
		{
			get
			{
				return this.m_Wrapper.m_Editor_Z;
			}
		}

		// Token: 0x060008AB RID: 2219 RVA: 0x00026CE5 File Offset: 0x00024EE5
		public InputActionMap Get()
		{
			return this.m_Wrapper.m_Editor;
		}

		// Token: 0x060008AC RID: 2220 RVA: 0x00026CF2 File Offset: 0x00024EF2
		public void Enable()
		{
			this.Get().Enable();
		}

		// Token: 0x060008AD RID: 2221 RVA: 0x00026CFF File Offset: 0x00024EFF
		public void Disable()
		{
			this.Get().Disable();
		}

		// Token: 0x17000134 RID: 308
		// (get) Token: 0x060008AE RID: 2222 RVA: 0x00026D0C File Offset: 0x00024F0C
		public bool enabled
		{
			get
			{
				return this.Get().enabled;
			}
		}

		// Token: 0x060008AF RID: 2223 RVA: 0x00026D19 File Offset: 0x00024F19
		public static implicit operator InputActionMap(Input_main.EditorActions set)
		{
			return set.Get();
		}

		// Token: 0x060008B0 RID: 2224 RVA: 0x00026D24 File Offset: 0x00024F24
		public void SetCallbacks(Input_main.IEditorActions instance)
		{
			if (this.m_Wrapper.m_EditorActionsCallbackInterface != null)
			{
				this.Z.started -= this.m_Wrapper.m_EditorActionsCallbackInterface.OnZ;
				this.Z.performed -= this.m_Wrapper.m_EditorActionsCallbackInterface.OnZ;
				this.Z.canceled -= this.m_Wrapper.m_EditorActionsCallbackInterface.OnZ;
			}
			this.m_Wrapper.m_EditorActionsCallbackInterface = instance;
			if (instance != null)
			{
				this.Z.started += instance.OnZ;
				this.Z.performed += instance.OnZ;
				this.Z.canceled += instance.OnZ;
			}
		}

		// Token: 0x04000937 RID: 2359
		private Input_main m_Wrapper;
	}

	// Token: 0x0200017A RID: 378
	public struct Am_voidActions
	{
		// Token: 0x060008B1 RID: 2225 RVA: 0x00026DFB File Offset: 0x00024FFB
		public Am_voidActions(Input_main wrapper)
		{
			this.m_Wrapper = wrapper;
		}

		// Token: 0x17000135 RID: 309
		// (get) Token: 0x060008B2 RID: 2226 RVA: 0x00026E04 File Offset: 0x00025004
		public InputAction Newaction
		{
			get
			{
				return this.m_Wrapper.m_am_void_Newaction;
			}
		}

		// Token: 0x060008B3 RID: 2227 RVA: 0x00026E11 File Offset: 0x00025011
		public InputActionMap Get()
		{
			return this.m_Wrapper.m_am_void;
		}

		// Token: 0x060008B4 RID: 2228 RVA: 0x00026E1E File Offset: 0x0002501E
		public void Enable()
		{
			this.Get().Enable();
		}

		// Token: 0x060008B5 RID: 2229 RVA: 0x00026E2B File Offset: 0x0002502B
		public void Disable()
		{
			this.Get().Disable();
		}

		// Token: 0x17000136 RID: 310
		// (get) Token: 0x060008B6 RID: 2230 RVA: 0x00026E38 File Offset: 0x00025038
		public bool enabled
		{
			get
			{
				return this.Get().enabled;
			}
		}

		// Token: 0x060008B7 RID: 2231 RVA: 0x00026E45 File Offset: 0x00025045
		public static implicit operator InputActionMap(Input_main.Am_voidActions set)
		{
			return set.Get();
		}

		// Token: 0x060008B8 RID: 2232 RVA: 0x00026E50 File Offset: 0x00025050
		public void SetCallbacks(Input_main.IAm_voidActions instance)
		{
			if (this.m_Wrapper.m_Am_voidActionsCallbackInterface != null)
			{
				this.Newaction.started -= this.m_Wrapper.m_Am_voidActionsCallbackInterface.OnNewaction;
				this.Newaction.performed -= this.m_Wrapper.m_Am_voidActionsCallbackInterface.OnNewaction;
				this.Newaction.canceled -= this.m_Wrapper.m_Am_voidActionsCallbackInterface.OnNewaction;
			}
			this.m_Wrapper.m_Am_voidActionsCallbackInterface = instance;
			if (instance != null)
			{
				this.Newaction.started += instance.OnNewaction;
				this.Newaction.performed += instance.OnNewaction;
				this.Newaction.canceled += instance.OnNewaction;
			}
		}

		// Token: 0x04000938 RID: 2360
		private Input_main m_Wrapper;
	}

	// Token: 0x0200017B RID: 379
	public struct Am_menuActions
	{
		// Token: 0x060008B9 RID: 2233 RVA: 0x00026F27 File Offset: 0x00025127
		public Am_menuActions(Input_main wrapper)
		{
			this.m_Wrapper = wrapper;
		}

		// Token: 0x17000137 RID: 311
		// (get) Token: 0x060008BA RID: 2234 RVA: 0x00026F30 File Offset: 0x00025130
		public InputAction escape
		{
			get
			{
				return this.m_Wrapper.m_am_menu_escape;
			}
		}

		// Token: 0x060008BB RID: 2235 RVA: 0x00026F3D File Offset: 0x0002513D
		public InputActionMap Get()
		{
			return this.m_Wrapper.m_am_menu;
		}

		// Token: 0x060008BC RID: 2236 RVA: 0x00026F4A File Offset: 0x0002514A
		public void Enable()
		{
			this.Get().Enable();
		}

		// Token: 0x060008BD RID: 2237 RVA: 0x00026F57 File Offset: 0x00025157
		public void Disable()
		{
			this.Get().Disable();
		}

		// Token: 0x17000138 RID: 312
		// (get) Token: 0x060008BE RID: 2238 RVA: 0x00026F64 File Offset: 0x00025164
		public bool enabled
		{
			get
			{
				return this.Get().enabled;
			}
		}

		// Token: 0x060008BF RID: 2239 RVA: 0x00026F71 File Offset: 0x00025171
		public static implicit operator InputActionMap(Input_main.Am_menuActions set)
		{
			return set.Get();
		}

		// Token: 0x060008C0 RID: 2240 RVA: 0x00026F7C File Offset: 0x0002517C
		public void SetCallbacks(Input_main.IAm_menuActions instance)
		{
			if (this.m_Wrapper.m_Am_menuActionsCallbackInterface != null)
			{
				this.escape.started -= this.m_Wrapper.m_Am_menuActionsCallbackInterface.OnEscape;
				this.escape.performed -= this.m_Wrapper.m_Am_menuActionsCallbackInterface.OnEscape;
				this.escape.canceled -= this.m_Wrapper.m_Am_menuActionsCallbackInterface.OnEscape;
			}
			this.m_Wrapper.m_Am_menuActionsCallbackInterface = instance;
			if (instance != null)
			{
				this.escape.started += instance.OnEscape;
				this.escape.performed += instance.OnEscape;
				this.escape.canceled += instance.OnEscape;
			}
		}

		// Token: 0x04000939 RID: 2361
		private Input_main m_Wrapper;
	}

	// Token: 0x0200017C RID: 380
	public struct Am_settingActions
	{
		// Token: 0x060008C1 RID: 2241 RVA: 0x00027053 File Offset: 0x00025253
		public Am_settingActions(Input_main wrapper)
		{
			this.m_Wrapper = wrapper;
		}

		// Token: 0x17000139 RID: 313
		// (get) Token: 0x060008C2 RID: 2242 RVA: 0x0002705C File Offset: 0x0002525C
		public InputAction escape
		{
			get
			{
				return this.m_Wrapper.m_am_setting_escape;
			}
		}

		// Token: 0x1700013A RID: 314
		// (get) Token: 0x060008C3 RID: 2243 RVA: 0x00027069 File Offset: 0x00025269
		public InputAction U
		{
			get
			{
				return this.m_Wrapper.m_am_setting_U;
			}
		}

		// Token: 0x1700013B RID: 315
		// (get) Token: 0x060008C4 RID: 2244 RVA: 0x00027076 File Offset: 0x00025276
		public InputAction N
		{
			get
			{
				return this.m_Wrapper.m_am_setting_N;
			}
		}

		// Token: 0x060008C5 RID: 2245 RVA: 0x00027083 File Offset: 0x00025283
		public InputActionMap Get()
		{
			return this.m_Wrapper.m_am_setting;
		}

		// Token: 0x060008C6 RID: 2246 RVA: 0x00027090 File Offset: 0x00025290
		public void Enable()
		{
			this.Get().Enable();
		}

		// Token: 0x060008C7 RID: 2247 RVA: 0x0002709D File Offset: 0x0002529D
		public void Disable()
		{
			this.Get().Disable();
		}

		// Token: 0x1700013C RID: 316
		// (get) Token: 0x060008C8 RID: 2248 RVA: 0x000270AA File Offset: 0x000252AA
		public bool enabled
		{
			get
			{
				return this.Get().enabled;
			}
		}

		// Token: 0x060008C9 RID: 2249 RVA: 0x000270B7 File Offset: 0x000252B7
		public static implicit operator InputActionMap(Input_main.Am_settingActions set)
		{
			return set.Get();
		}

		// Token: 0x060008CA RID: 2250 RVA: 0x000270C0 File Offset: 0x000252C0
		public void SetCallbacks(Input_main.IAm_settingActions instance)
		{
			if (this.m_Wrapper.m_Am_settingActionsCallbackInterface != null)
			{
				this.escape.started -= this.m_Wrapper.m_Am_settingActionsCallbackInterface.OnEscape;
				this.escape.performed -= this.m_Wrapper.m_Am_settingActionsCallbackInterface.OnEscape;
				this.escape.canceled -= this.m_Wrapper.m_Am_settingActionsCallbackInterface.OnEscape;
				this.U.started -= this.m_Wrapper.m_Am_settingActionsCallbackInterface.OnU;
				this.U.performed -= this.m_Wrapper.m_Am_settingActionsCallbackInterface.OnU;
				this.U.canceled -= this.m_Wrapper.m_Am_settingActionsCallbackInterface.OnU;
				this.N.started -= this.m_Wrapper.m_Am_settingActionsCallbackInterface.OnN;
				this.N.performed -= this.m_Wrapper.m_Am_settingActionsCallbackInterface.OnN;
				this.N.canceled -= this.m_Wrapper.m_Am_settingActionsCallbackInterface.OnN;
			}
			this.m_Wrapper.m_Am_settingActionsCallbackInterface = instance;
			if (instance != null)
			{
				this.escape.started += instance.OnEscape;
				this.escape.performed += instance.OnEscape;
				this.escape.canceled += instance.OnEscape;
				this.U.started += instance.OnU;
				this.U.performed += instance.OnU;
				this.U.canceled += instance.OnU;
				this.N.started += instance.OnN;
				this.N.performed += instance.OnN;
				this.N.canceled += instance.OnN;
			}
		}

		// Token: 0x0400093A RID: 2362
		private Input_main m_Wrapper;
	}

	// Token: 0x0200017D RID: 381
	public struct Am_level_mapActions
	{
		// Token: 0x060008CB RID: 2251 RVA: 0x000272F9 File Offset: 0x000254F9
		public Am_level_mapActions(Input_main wrapper)
		{
			this.m_Wrapper = wrapper;
		}

		// Token: 0x1700013D RID: 317
		// (get) Token: 0x060008CC RID: 2252 RVA: 0x00027302 File Offset: 0x00025502
		public InputAction escape
		{
			get
			{
				return this.m_Wrapper.m_am_level_map_escape;
			}
		}

		// Token: 0x060008CD RID: 2253 RVA: 0x0002730F File Offset: 0x0002550F
		public InputActionMap Get()
		{
			return this.m_Wrapper.m_am_level_map;
		}

		// Token: 0x060008CE RID: 2254 RVA: 0x0002731C File Offset: 0x0002551C
		public void Enable()
		{
			this.Get().Enable();
		}

		// Token: 0x060008CF RID: 2255 RVA: 0x00027329 File Offset: 0x00025529
		public void Disable()
		{
			this.Get().Disable();
		}

		// Token: 0x1700013E RID: 318
		// (get) Token: 0x060008D0 RID: 2256 RVA: 0x00027336 File Offset: 0x00025536
		public bool enabled
		{
			get
			{
				return this.Get().enabled;
			}
		}

		// Token: 0x060008D1 RID: 2257 RVA: 0x00027343 File Offset: 0x00025543
		public static implicit operator InputActionMap(Input_main.Am_level_mapActions set)
		{
			return set.Get();
		}

		// Token: 0x060008D2 RID: 2258 RVA: 0x0002734C File Offset: 0x0002554C
		public void SetCallbacks(Input_main.IAm_level_mapActions instance)
		{
			if (this.m_Wrapper.m_Am_level_mapActionsCallbackInterface != null)
			{
				this.escape.started -= this.m_Wrapper.m_Am_level_mapActionsCallbackInterface.OnEscape;
				this.escape.performed -= this.m_Wrapper.m_Am_level_mapActionsCallbackInterface.OnEscape;
				this.escape.canceled -= this.m_Wrapper.m_Am_level_mapActionsCallbackInterface.OnEscape;
			}
			this.m_Wrapper.m_Am_level_mapActionsCallbackInterface = instance;
			if (instance != null)
			{
				this.escape.started += instance.OnEscape;
				this.escape.performed += instance.OnEscape;
				this.escape.canceled += instance.OnEscape;
			}
		}

		// Token: 0x0400093B RID: 2363
		private Input_main m_Wrapper;
	}

	// Token: 0x0200017E RID: 382
	public struct Am_mapActions
	{
		// Token: 0x060008D3 RID: 2259 RVA: 0x00027423 File Offset: 0x00025623
		public Am_mapActions(Input_main wrapper)
		{
			this.m_Wrapper = wrapper;
		}

		// Token: 0x1700013F RID: 319
		// (get) Token: 0x060008D4 RID: 2260 RVA: 0x0002742C File Offset: 0x0002562C
		public InputAction escape
		{
			get
			{
				return this.m_Wrapper.m_am_map_escape;
			}
		}

		// Token: 0x060008D5 RID: 2261 RVA: 0x00027439 File Offset: 0x00025639
		public InputActionMap Get()
		{
			return this.m_Wrapper.m_am_map;
		}

		// Token: 0x060008D6 RID: 2262 RVA: 0x00027446 File Offset: 0x00025646
		public void Enable()
		{
			this.Get().Enable();
		}

		// Token: 0x060008D7 RID: 2263 RVA: 0x00027453 File Offset: 0x00025653
		public void Disable()
		{
			this.Get().Disable();
		}

		// Token: 0x17000140 RID: 320
		// (get) Token: 0x060008D8 RID: 2264 RVA: 0x00027460 File Offset: 0x00025660
		public bool enabled
		{
			get
			{
				return this.Get().enabled;
			}
		}

		// Token: 0x060008D9 RID: 2265 RVA: 0x0002746D File Offset: 0x0002566D
		public static implicit operator InputActionMap(Input_main.Am_mapActions set)
		{
			return set.Get();
		}

		// Token: 0x060008DA RID: 2266 RVA: 0x00027478 File Offset: 0x00025678
		public void SetCallbacks(Input_main.IAm_mapActions instance)
		{
			if (this.m_Wrapper.m_Am_mapActionsCallbackInterface != null)
			{
				this.escape.started -= this.m_Wrapper.m_Am_mapActionsCallbackInterface.OnEscape;
				this.escape.performed -= this.m_Wrapper.m_Am_mapActionsCallbackInterface.OnEscape;
				this.escape.canceled -= this.m_Wrapper.m_Am_mapActionsCallbackInterface.OnEscape;
			}
			this.m_Wrapper.m_Am_mapActionsCallbackInterface = instance;
			if (instance != null)
			{
				this.escape.started += instance.OnEscape;
				this.escape.performed += instance.OnEscape;
				this.escape.canceled += instance.OnEscape;
			}
		}

		// Token: 0x0400093C RID: 2364
		private Input_main m_Wrapper;
	}

	// Token: 0x0200017F RID: 383
	public struct Am_map_resetActions
	{
		// Token: 0x060008DB RID: 2267 RVA: 0x0002754F File Offset: 0x0002574F
		public Am_map_resetActions(Input_main wrapper)
		{
			this.m_Wrapper = wrapper;
		}

		// Token: 0x17000141 RID: 321
		// (get) Token: 0x060008DC RID: 2268 RVA: 0x00027558 File Offset: 0x00025758
		public InputAction escape
		{
			get
			{
				return this.m_Wrapper.m_am_map_reset_escape;
			}
		}

		// Token: 0x060008DD RID: 2269 RVA: 0x00027565 File Offset: 0x00025765
		public InputActionMap Get()
		{
			return this.m_Wrapper.m_am_map_reset;
		}

		// Token: 0x060008DE RID: 2270 RVA: 0x00027572 File Offset: 0x00025772
		public void Enable()
		{
			this.Get().Enable();
		}

		// Token: 0x060008DF RID: 2271 RVA: 0x0002757F File Offset: 0x0002577F
		public void Disable()
		{
			this.Get().Disable();
		}

		// Token: 0x17000142 RID: 322
		// (get) Token: 0x060008E0 RID: 2272 RVA: 0x0002758C File Offset: 0x0002578C
		public bool enabled
		{
			get
			{
				return this.Get().enabled;
			}
		}

		// Token: 0x060008E1 RID: 2273 RVA: 0x00027599 File Offset: 0x00025799
		public static implicit operator InputActionMap(Input_main.Am_map_resetActions set)
		{
			return set.Get();
		}

		// Token: 0x060008E2 RID: 2274 RVA: 0x000275A4 File Offset: 0x000257A4
		public void SetCallbacks(Input_main.IAm_map_resetActions instance)
		{
			if (this.m_Wrapper.m_Am_map_resetActionsCallbackInterface != null)
			{
				this.escape.started -= this.m_Wrapper.m_Am_map_resetActionsCallbackInterface.OnEscape;
				this.escape.performed -= this.m_Wrapper.m_Am_map_resetActionsCallbackInterface.OnEscape;
				this.escape.canceled -= this.m_Wrapper.m_Am_map_resetActionsCallbackInterface.OnEscape;
			}
			this.m_Wrapper.m_Am_map_resetActionsCallbackInterface = instance;
			if (instance != null)
			{
				this.escape.started += instance.OnEscape;
				this.escape.performed += instance.OnEscape;
				this.escape.canceled += instance.OnEscape;
			}
		}

		// Token: 0x0400093D RID: 2365
		private Input_main m_Wrapper;
	}

	// Token: 0x02000180 RID: 384
	public struct Am_playActions
	{
		// Token: 0x060008E3 RID: 2275 RVA: 0x0002767B File Offset: 0x0002587B
		public Am_playActions(Input_main wrapper)
		{
			this.m_Wrapper = wrapper;
		}

		// Token: 0x17000143 RID: 323
		// (get) Token: 0x060008E4 RID: 2276 RVA: 0x00027684 File Offset: 0x00025884
		public InputAction escape
		{
			get
			{
				return this.m_Wrapper.m_am_play_escape;
			}
		}

		// Token: 0x17000144 RID: 324
		// (get) Token: 0x060008E5 RID: 2277 RVA: 0x00027691 File Offset: 0x00025891
		public InputAction Scroll
		{
			get
			{
				return this.m_Wrapper.m_am_play_Scroll;
			}
		}

		// Token: 0x17000145 RID: 325
		// (get) Token: 0x060008E6 RID: 2278 RVA: 0x0002769E File Offset: 0x0002589E
		public InputAction Scroll_Center
		{
			get
			{
				return this.m_Wrapper.m_am_play_Scroll_Center;
			}
		}

		// Token: 0x17000146 RID: 326
		// (get) Token: 0x060008E7 RID: 2279 RVA: 0x000276AB File Offset: 0x000258AB
		public InputAction Move_Map
		{
			get
			{
				return this.m_Wrapper.m_am_play_Move_Map;
			}
		}

		// Token: 0x17000147 RID: 327
		// (get) Token: 0x060008E8 RID: 2280 RVA: 0x000276B8 File Offset: 0x000258B8
		public InputAction Mouse_Position
		{
			get
			{
				return this.m_Wrapper.m_am_play_Mouse_Position;
			}
		}

		// Token: 0x17000148 RID: 328
		// (get) Token: 0x060008E9 RID: 2281 RVA: 0x000276C5 File Offset: 0x000258C5
		public InputAction Find_Group_1
		{
			get
			{
				return this.m_Wrapper.m_am_play_Find_Group_1;
			}
		}

		// Token: 0x17000149 RID: 329
		// (get) Token: 0x060008EA RID: 2282 RVA: 0x000276D2 File Offset: 0x000258D2
		public InputAction Find_Group_2
		{
			get
			{
				return this.m_Wrapper.m_am_play_Find_Group_2;
			}
		}

		// Token: 0x1700014A RID: 330
		// (get) Token: 0x060008EB RID: 2283 RVA: 0x000276DF File Offset: 0x000258DF
		public InputAction Find_Group_3
		{
			get
			{
				return this.m_Wrapper.m_am_play_Find_Group_3;
			}
		}

		// Token: 0x1700014B RID: 331
		// (get) Token: 0x060008EC RID: 2284 RVA: 0x000276EC File Offset: 0x000258EC
		public InputAction WASD
		{
			get
			{
				return this.m_Wrapper.m_am_play_WASD;
			}
		}

		// Token: 0x1700014C RID: 332
		// (get) Token: 0x060008ED RID: 2285 RVA: 0x000276F9 File Offset: 0x000258F9
		public InputAction Z_key
		{
			get
			{
				return this.m_Wrapper.m_am_play_Z_key;
			}
		}

		// Token: 0x1700014D RID: 333
		// (get) Token: 0x060008EE RID: 2286 RVA: 0x00027706 File Offset: 0x00025906
		public InputAction Q_key
		{
			get
			{
				return this.m_Wrapper.m_am_play_Q_key;
			}
		}

		// Token: 0x1700014E RID: 334
		// (get) Token: 0x060008EF RID: 2287 RVA: 0x00027713 File Offset: 0x00025913
		public InputAction Shift_mod
		{
			get
			{
				return this.m_Wrapper.m_am_play_Shift_mod;
			}
		}

		// Token: 0x1700014F RID: 335
		// (get) Token: 0x060008F0 RID: 2288 RVA: 0x00027720 File Offset: 0x00025920
		public InputAction Alt_mod
		{
			get
			{
				return this.m_Wrapper.m_am_play_Alt_mod;
			}
		}

		// Token: 0x17000150 RID: 336
		// (get) Token: 0x060008F1 RID: 2289 RVA: 0x0002772D File Offset: 0x0002592D
		public InputAction R_key
		{
			get
			{
				return this.m_Wrapper.m_am_play_R_key;
			}
		}

		// Token: 0x17000151 RID: 337
		// (get) Token: 0x060008F2 RID: 2290 RVA: 0x0002773A File Offset: 0x0002593A
		public InputAction F_key
		{
			get
			{
				return this.m_Wrapper.m_am_play_F_key;
			}
		}

		// Token: 0x060008F3 RID: 2291 RVA: 0x00027747 File Offset: 0x00025947
		public InputActionMap Get()
		{
			return this.m_Wrapper.m_am_play;
		}

		// Token: 0x060008F4 RID: 2292 RVA: 0x00027754 File Offset: 0x00025954
		public void Enable()
		{
			this.Get().Enable();
		}

		// Token: 0x060008F5 RID: 2293 RVA: 0x00027761 File Offset: 0x00025961
		public void Disable()
		{
			this.Get().Disable();
		}

		// Token: 0x17000152 RID: 338
		// (get) Token: 0x060008F6 RID: 2294 RVA: 0x0002776E File Offset: 0x0002596E
		public bool enabled
		{
			get
			{
				return this.Get().enabled;
			}
		}

		// Token: 0x060008F7 RID: 2295 RVA: 0x0002777B File Offset: 0x0002597B
		public static implicit operator InputActionMap(Input_main.Am_playActions set)
		{
			return set.Get();
		}

		// Token: 0x060008F8 RID: 2296 RVA: 0x00027784 File Offset: 0x00025984
		public void SetCallbacks(Input_main.IAm_playActions instance)
		{
			if (this.m_Wrapper.m_Am_playActionsCallbackInterface != null)
			{
				this.escape.started -= this.m_Wrapper.m_Am_playActionsCallbackInterface.OnEscape;
				this.escape.performed -= this.m_Wrapper.m_Am_playActionsCallbackInterface.OnEscape;
				this.escape.canceled -= this.m_Wrapper.m_Am_playActionsCallbackInterface.OnEscape;
				this.Scroll.started -= this.m_Wrapper.m_Am_playActionsCallbackInterface.OnScroll;
				this.Scroll.performed -= this.m_Wrapper.m_Am_playActionsCallbackInterface.OnScroll;
				this.Scroll.canceled -= this.m_Wrapper.m_Am_playActionsCallbackInterface.OnScroll;
				this.Scroll_Center.started -= this.m_Wrapper.m_Am_playActionsCallbackInterface.OnScroll_Center;
				this.Scroll_Center.performed -= this.m_Wrapper.m_Am_playActionsCallbackInterface.OnScroll_Center;
				this.Scroll_Center.canceled -= this.m_Wrapper.m_Am_playActionsCallbackInterface.OnScroll_Center;
				this.Move_Map.started -= this.m_Wrapper.m_Am_playActionsCallbackInterface.OnMove_Map;
				this.Move_Map.performed -= this.m_Wrapper.m_Am_playActionsCallbackInterface.OnMove_Map;
				this.Move_Map.canceled -= this.m_Wrapper.m_Am_playActionsCallbackInterface.OnMove_Map;
				this.Mouse_Position.started -= this.m_Wrapper.m_Am_playActionsCallbackInterface.OnMouse_Position;
				this.Mouse_Position.performed -= this.m_Wrapper.m_Am_playActionsCallbackInterface.OnMouse_Position;
				this.Mouse_Position.canceled -= this.m_Wrapper.m_Am_playActionsCallbackInterface.OnMouse_Position;
				this.Find_Group_1.started -= this.m_Wrapper.m_Am_playActionsCallbackInterface.OnFind_Group_1;
				this.Find_Group_1.performed -= this.m_Wrapper.m_Am_playActionsCallbackInterface.OnFind_Group_1;
				this.Find_Group_1.canceled -= this.m_Wrapper.m_Am_playActionsCallbackInterface.OnFind_Group_1;
				this.Find_Group_2.started -= this.m_Wrapper.m_Am_playActionsCallbackInterface.OnFind_Group_2;
				this.Find_Group_2.performed -= this.m_Wrapper.m_Am_playActionsCallbackInterface.OnFind_Group_2;
				this.Find_Group_2.canceled -= this.m_Wrapper.m_Am_playActionsCallbackInterface.OnFind_Group_2;
				this.Find_Group_3.started -= this.m_Wrapper.m_Am_playActionsCallbackInterface.OnFind_Group_3;
				this.Find_Group_3.performed -= this.m_Wrapper.m_Am_playActionsCallbackInterface.OnFind_Group_3;
				this.Find_Group_3.canceled -= this.m_Wrapper.m_Am_playActionsCallbackInterface.OnFind_Group_3;
				this.WASD.started -= this.m_Wrapper.m_Am_playActionsCallbackInterface.OnWASD;
				this.WASD.performed -= this.m_Wrapper.m_Am_playActionsCallbackInterface.OnWASD;
				this.WASD.canceled -= this.m_Wrapper.m_Am_playActionsCallbackInterface.OnWASD;
				this.Z_key.started -= this.m_Wrapper.m_Am_playActionsCallbackInterface.OnZ_key;
				this.Z_key.performed -= this.m_Wrapper.m_Am_playActionsCallbackInterface.OnZ_key;
				this.Z_key.canceled -= this.m_Wrapper.m_Am_playActionsCallbackInterface.OnZ_key;
				this.Q_key.started -= this.m_Wrapper.m_Am_playActionsCallbackInterface.OnQ_key;
				this.Q_key.performed -= this.m_Wrapper.m_Am_playActionsCallbackInterface.OnQ_key;
				this.Q_key.canceled -= this.m_Wrapper.m_Am_playActionsCallbackInterface.OnQ_key;
				this.Shift_mod.started -= this.m_Wrapper.m_Am_playActionsCallbackInterface.OnShift_mod;
				this.Shift_mod.performed -= this.m_Wrapper.m_Am_playActionsCallbackInterface.OnShift_mod;
				this.Shift_mod.canceled -= this.m_Wrapper.m_Am_playActionsCallbackInterface.OnShift_mod;
				this.Alt_mod.started -= this.m_Wrapper.m_Am_playActionsCallbackInterface.OnAlt_mod;
				this.Alt_mod.performed -= this.m_Wrapper.m_Am_playActionsCallbackInterface.OnAlt_mod;
				this.Alt_mod.canceled -= this.m_Wrapper.m_Am_playActionsCallbackInterface.OnAlt_mod;
				this.R_key.started -= this.m_Wrapper.m_Am_playActionsCallbackInterface.OnR_key;
				this.R_key.performed -= this.m_Wrapper.m_Am_playActionsCallbackInterface.OnR_key;
				this.R_key.canceled -= this.m_Wrapper.m_Am_playActionsCallbackInterface.OnR_key;
				this.F_key.started -= this.m_Wrapper.m_Am_playActionsCallbackInterface.OnF_key;
				this.F_key.performed -= this.m_Wrapper.m_Am_playActionsCallbackInterface.OnF_key;
				this.F_key.canceled -= this.m_Wrapper.m_Am_playActionsCallbackInterface.OnF_key;
			}
			this.m_Wrapper.m_Am_playActionsCallbackInterface = instance;
			if (instance != null)
			{
				this.escape.started += instance.OnEscape;
				this.escape.performed += instance.OnEscape;
				this.escape.canceled += instance.OnEscape;
				this.Scroll.started += instance.OnScroll;
				this.Scroll.performed += instance.OnScroll;
				this.Scroll.canceled += instance.OnScroll;
				this.Scroll_Center.started += instance.OnScroll_Center;
				this.Scroll_Center.performed += instance.OnScroll_Center;
				this.Scroll_Center.canceled += instance.OnScroll_Center;
				this.Move_Map.started += instance.OnMove_Map;
				this.Move_Map.performed += instance.OnMove_Map;
				this.Move_Map.canceled += instance.OnMove_Map;
				this.Mouse_Position.started += instance.OnMouse_Position;
				this.Mouse_Position.performed += instance.OnMouse_Position;
				this.Mouse_Position.canceled += instance.OnMouse_Position;
				this.Find_Group_1.started += instance.OnFind_Group_1;
				this.Find_Group_1.performed += instance.OnFind_Group_1;
				this.Find_Group_1.canceled += instance.OnFind_Group_1;
				this.Find_Group_2.started += instance.OnFind_Group_2;
				this.Find_Group_2.performed += instance.OnFind_Group_2;
				this.Find_Group_2.canceled += instance.OnFind_Group_2;
				this.Find_Group_3.started += instance.OnFind_Group_3;
				this.Find_Group_3.performed += instance.OnFind_Group_3;
				this.Find_Group_3.canceled += instance.OnFind_Group_3;
				this.WASD.started += instance.OnWASD;
				this.WASD.performed += instance.OnWASD;
				this.WASD.canceled += instance.OnWASD;
				this.Z_key.started += instance.OnZ_key;
				this.Z_key.performed += instance.OnZ_key;
				this.Z_key.canceled += instance.OnZ_key;
				this.Q_key.started += instance.OnQ_key;
				this.Q_key.performed += instance.OnQ_key;
				this.Q_key.canceled += instance.OnQ_key;
				this.Shift_mod.started += instance.OnShift_mod;
				this.Shift_mod.performed += instance.OnShift_mod;
				this.Shift_mod.canceled += instance.OnShift_mod;
				this.Alt_mod.started += instance.OnAlt_mod;
				this.Alt_mod.performed += instance.OnAlt_mod;
				this.Alt_mod.canceled += instance.OnAlt_mod;
				this.R_key.started += instance.OnR_key;
				this.R_key.performed += instance.OnR_key;
				this.R_key.canceled += instance.OnR_key;
				this.F_key.started += instance.OnF_key;
				this.F_key.performed += instance.OnF_key;
				this.F_key.canceled += instance.OnF_key;
			}
		}

		// Token: 0x0400093E RID: 2366
		private Input_main m_Wrapper;
	}

	// Token: 0x02000181 RID: 385
	public struct Am_tutorial_1Actions
	{
		// Token: 0x060008F9 RID: 2297 RVA: 0x000281E5 File Offset: 0x000263E5
		public Am_tutorial_1Actions(Input_main wrapper)
		{
			this.m_Wrapper = wrapper;
		}

		// Token: 0x17000153 RID: 339
		// (get) Token: 0x060008FA RID: 2298 RVA: 0x000281EE File Offset: 0x000263EE
		public InputAction escape
		{
			get
			{
				return this.m_Wrapper.m_am_tutorial_1_escape;
			}
		}

		// Token: 0x060008FB RID: 2299 RVA: 0x000281FB File Offset: 0x000263FB
		public InputActionMap Get()
		{
			return this.m_Wrapper.m_am_tutorial_1;
		}

		// Token: 0x060008FC RID: 2300 RVA: 0x00028208 File Offset: 0x00026408
		public void Enable()
		{
			this.Get().Enable();
		}

		// Token: 0x060008FD RID: 2301 RVA: 0x00028215 File Offset: 0x00026415
		public void Disable()
		{
			this.Get().Disable();
		}

		// Token: 0x17000154 RID: 340
		// (get) Token: 0x060008FE RID: 2302 RVA: 0x00028222 File Offset: 0x00026422
		public bool enabled
		{
			get
			{
				return this.Get().enabled;
			}
		}

		// Token: 0x060008FF RID: 2303 RVA: 0x0002822F File Offset: 0x0002642F
		public static implicit operator InputActionMap(Input_main.Am_tutorial_1Actions set)
		{
			return set.Get();
		}

		// Token: 0x06000900 RID: 2304 RVA: 0x00028238 File Offset: 0x00026438
		public void SetCallbacks(Input_main.IAm_tutorial_1Actions instance)
		{
			if (this.m_Wrapper.m_Am_tutorial_1ActionsCallbackInterface != null)
			{
				this.escape.started -= this.m_Wrapper.m_Am_tutorial_1ActionsCallbackInterface.OnEscape;
				this.escape.performed -= this.m_Wrapper.m_Am_tutorial_1ActionsCallbackInterface.OnEscape;
				this.escape.canceled -= this.m_Wrapper.m_Am_tutorial_1ActionsCallbackInterface.OnEscape;
			}
			this.m_Wrapper.m_Am_tutorial_1ActionsCallbackInterface = instance;
			if (instance != null)
			{
				this.escape.started += instance.OnEscape;
				this.escape.performed += instance.OnEscape;
				this.escape.canceled += instance.OnEscape;
			}
		}

		// Token: 0x0400093F RID: 2367
		private Input_main m_Wrapper;
	}

	// Token: 0x02000182 RID: 386
	public struct Am_tutorial_2Actions
	{
		// Token: 0x06000901 RID: 2305 RVA: 0x0002830F File Offset: 0x0002650F
		public Am_tutorial_2Actions(Input_main wrapper)
		{
			this.m_Wrapper = wrapper;
		}

		// Token: 0x17000155 RID: 341
		// (get) Token: 0x06000902 RID: 2306 RVA: 0x00028318 File Offset: 0x00026518
		public InputAction escape
		{
			get
			{
				return this.m_Wrapper.m_am_tutorial_2_escape;
			}
		}

		// Token: 0x06000903 RID: 2307 RVA: 0x00028325 File Offset: 0x00026525
		public InputActionMap Get()
		{
			return this.m_Wrapper.m_am_tutorial_2;
		}

		// Token: 0x06000904 RID: 2308 RVA: 0x00028332 File Offset: 0x00026532
		public void Enable()
		{
			this.Get().Enable();
		}

		// Token: 0x06000905 RID: 2309 RVA: 0x0002833F File Offset: 0x0002653F
		public void Disable()
		{
			this.Get().Disable();
		}

		// Token: 0x17000156 RID: 342
		// (get) Token: 0x06000906 RID: 2310 RVA: 0x0002834C File Offset: 0x0002654C
		public bool enabled
		{
			get
			{
				return this.Get().enabled;
			}
		}

		// Token: 0x06000907 RID: 2311 RVA: 0x00028359 File Offset: 0x00026559
		public static implicit operator InputActionMap(Input_main.Am_tutorial_2Actions set)
		{
			return set.Get();
		}

		// Token: 0x06000908 RID: 2312 RVA: 0x00028364 File Offset: 0x00026564
		public void SetCallbacks(Input_main.IAm_tutorial_2Actions instance)
		{
			if (this.m_Wrapper.m_Am_tutorial_2ActionsCallbackInterface != null)
			{
				this.escape.started -= this.m_Wrapper.m_Am_tutorial_2ActionsCallbackInterface.OnEscape;
				this.escape.performed -= this.m_Wrapper.m_Am_tutorial_2ActionsCallbackInterface.OnEscape;
				this.escape.canceled -= this.m_Wrapper.m_Am_tutorial_2ActionsCallbackInterface.OnEscape;
			}
			this.m_Wrapper.m_Am_tutorial_2ActionsCallbackInterface = instance;
			if (instance != null)
			{
				this.escape.started += instance.OnEscape;
				this.escape.performed += instance.OnEscape;
				this.escape.canceled += instance.OnEscape;
			}
		}

		// Token: 0x04000940 RID: 2368
		private Input_main m_Wrapper;
	}

	// Token: 0x02000183 RID: 387
	public struct Am_tutorial_settingActions
	{
		// Token: 0x06000909 RID: 2313 RVA: 0x0002843B File Offset: 0x0002663B
		public Am_tutorial_settingActions(Input_main wrapper)
		{
			this.m_Wrapper = wrapper;
		}

		// Token: 0x17000157 RID: 343
		// (get) Token: 0x0600090A RID: 2314 RVA: 0x00028444 File Offset: 0x00026644
		public InputAction escape
		{
			get
			{
				return this.m_Wrapper.m_am_tutorial_setting_escape;
			}
		}

		// Token: 0x0600090B RID: 2315 RVA: 0x00028451 File Offset: 0x00026651
		public InputActionMap Get()
		{
			return this.m_Wrapper.m_am_tutorial_setting;
		}

		// Token: 0x0600090C RID: 2316 RVA: 0x0002845E File Offset: 0x0002665E
		public void Enable()
		{
			this.Get().Enable();
		}

		// Token: 0x0600090D RID: 2317 RVA: 0x0002846B File Offset: 0x0002666B
		public void Disable()
		{
			this.Get().Disable();
		}

		// Token: 0x17000158 RID: 344
		// (get) Token: 0x0600090E RID: 2318 RVA: 0x00028478 File Offset: 0x00026678
		public bool enabled
		{
			get
			{
				return this.Get().enabled;
			}
		}

		// Token: 0x0600090F RID: 2319 RVA: 0x00028485 File Offset: 0x00026685
		public static implicit operator InputActionMap(Input_main.Am_tutorial_settingActions set)
		{
			return set.Get();
		}

		// Token: 0x06000910 RID: 2320 RVA: 0x00028490 File Offset: 0x00026690
		public void SetCallbacks(Input_main.IAm_tutorial_settingActions instance)
		{
			if (this.m_Wrapper.m_Am_tutorial_settingActionsCallbackInterface != null)
			{
				this.escape.started -= this.m_Wrapper.m_Am_tutorial_settingActionsCallbackInterface.OnEscape;
				this.escape.performed -= this.m_Wrapper.m_Am_tutorial_settingActionsCallbackInterface.OnEscape;
				this.escape.canceled -= this.m_Wrapper.m_Am_tutorial_settingActionsCallbackInterface.OnEscape;
			}
			this.m_Wrapper.m_Am_tutorial_settingActionsCallbackInterface = instance;
			if (instance != null)
			{
				this.escape.started += instance.OnEscape;
				this.escape.performed += instance.OnEscape;
				this.escape.canceled += instance.OnEscape;
			}
		}

		// Token: 0x04000941 RID: 2369
		private Input_main m_Wrapper;
	}

	// Token: 0x02000184 RID: 388
	public interface IMainActions
	{
		// Token: 0x06000911 RID: 2321
		void OnMouse_position(InputAction.CallbackContext context);

		// Token: 0x06000912 RID: 2322
		void OnKey_1(InputAction.CallbackContext context);

		// Token: 0x06000913 RID: 2323
		void OnLeft_Mouse_Click(InputAction.CallbackContext context);

		// Token: 0x06000914 RID: 2324
		void OnScrolling(InputAction.CallbackContext context);
	}

	// Token: 0x02000185 RID: 389
	public interface IAddActions
	{
		// Token: 0x06000915 RID: 2325
		void OnKey_2(InputAction.CallbackContext context);
	}

	// Token: 0x02000186 RID: 390
	public interface IAllActions
	{
		// Token: 0x06000916 RID: 2326
		void OnKey_3(InputAction.CallbackContext context);

		// Token: 0x06000917 RID: 2327
		void OnQ_key(InputAction.CallbackContext context);

		// Token: 0x06000918 RID: 2328
		void OnMouse_Position(InputAction.CallbackContext context);

		// Token: 0x06000919 RID: 2329
		void OnZ_key(InputAction.CallbackContext context);

		// Token: 0x0600091A RID: 2330
		void OnReset_data_setting(InputAction.CallbackContext context);

		// Token: 0x0600091B RID: 2331
		void OnReset_data_game(InputAction.CallbackContext context);

		// Token: 0x0600091C RID: 2332
		void OnReset_data_press_key(InputAction.CallbackContext context);

		// Token: 0x0600091D RID: 2333
		void OnReset_this_scene(InputAction.CallbackContext context);

		// Token: 0x0600091E RID: 2334
		void OnTest_Scroll(InputAction.CallbackContext context);

		// Token: 0x0600091F RID: 2335
		void OnTest_Alpha(InputAction.CallbackContext context);
	}

	// Token: 0x02000187 RID: 391
	public interface IMenu_MainActions
	{
		// Token: 0x06000920 RID: 2336
		void OnEscape(InputAction.CallbackContext context);
	}

	// Token: 0x02000188 RID: 392
	public interface IMenu_SettingActions
	{
		// Token: 0x06000921 RID: 2337
		void OnEscape(InputAction.CallbackContext context);

		// Token: 0x06000922 RID: 2338
		void OnU(InputAction.CallbackContext context);

		// Token: 0x06000923 RID: 2339
		void OnN(InputAction.CallbackContext context);
	}

	// Token: 0x02000189 RID: 393
	public interface IEnd_GameActions
	{
		// Token: 0x06000924 RID: 2340
		void OnEscape(InputAction.CallbackContext context);
	}

	// Token: 0x0200018A RID: 394
	public interface IMenu_ResetActions
	{
		// Token: 0x06000925 RID: 2341
		void OnEscape(InputAction.CallbackContext context);
	}

	// Token: 0x0200018B RID: 395
	public interface IVoidActions
	{
		// Token: 0x06000926 RID: 2342
		void OnEscape(InputAction.CallbackContext context);
	}

	// Token: 0x0200018C RID: 396
	public interface IMapActions
	{
		// Token: 0x06000927 RID: 2343
		void OnEscape(InputAction.CallbackContext context);
	}

	// Token: 0x0200018D RID: 397
	public interface ICard_variantActions
	{
		// Token: 0x06000928 RID: 2344
		void OnNewaction(InputAction.CallbackContext context);
	}

	// Token: 0x0200018E RID: 398
	public interface IPuzzle_PlayActions
	{
		// Token: 0x06000929 RID: 2345
		void OnLeft_Click(InputAction.CallbackContext context);

		// Token: 0x0600092A RID: 2346
		void OnEscape(InputAction.CallbackContext context);

		// Token: 0x0600092B RID: 2347
		void OnRight_Click(InputAction.CallbackContext context);

		// Token: 0x0600092C RID: 2348
		void OnQE_rotate(InputAction.CallbackContext context);
	}

	// Token: 0x0200018F RID: 399
	public interface IEditorActions
	{
		// Token: 0x0600092D RID: 2349
		void OnZ(InputAction.CallbackContext context);
	}

	// Token: 0x02000190 RID: 400
	public interface IAm_voidActions
	{
		// Token: 0x0600092E RID: 2350
		void OnNewaction(InputAction.CallbackContext context);
	}

	// Token: 0x02000191 RID: 401
	public interface IAm_menuActions
	{
		// Token: 0x0600092F RID: 2351
		void OnEscape(InputAction.CallbackContext context);
	}

	// Token: 0x02000192 RID: 402
	public interface IAm_settingActions
	{
		// Token: 0x06000930 RID: 2352
		void OnEscape(InputAction.CallbackContext context);

		// Token: 0x06000931 RID: 2353
		void OnU(InputAction.CallbackContext context);

		// Token: 0x06000932 RID: 2354
		void OnN(InputAction.CallbackContext context);
	}

	// Token: 0x02000193 RID: 403
	public interface IAm_level_mapActions
	{
		// Token: 0x06000933 RID: 2355
		void OnEscape(InputAction.CallbackContext context);
	}

	// Token: 0x02000194 RID: 404
	public interface IAm_mapActions
	{
		// Token: 0x06000934 RID: 2356
		void OnEscape(InputAction.CallbackContext context);
	}

	// Token: 0x02000195 RID: 405
	public interface IAm_map_resetActions
	{
		// Token: 0x06000935 RID: 2357
		void OnEscape(InputAction.CallbackContext context);
	}

	// Token: 0x02000196 RID: 406
	public interface IAm_playActions
	{
		// Token: 0x06000936 RID: 2358
		void OnEscape(InputAction.CallbackContext context);

		// Token: 0x06000937 RID: 2359
		void OnScroll(InputAction.CallbackContext context);

		// Token: 0x06000938 RID: 2360
		void OnScroll_Center(InputAction.CallbackContext context);

		// Token: 0x06000939 RID: 2361
		void OnMove_Map(InputAction.CallbackContext context);

		// Token: 0x0600093A RID: 2362
		void OnMouse_Position(InputAction.CallbackContext context);

		// Token: 0x0600093B RID: 2363
		void OnFind_Group_1(InputAction.CallbackContext context);

		// Token: 0x0600093C RID: 2364
		void OnFind_Group_2(InputAction.CallbackContext context);

		// Token: 0x0600093D RID: 2365
		void OnFind_Group_3(InputAction.CallbackContext context);

		// Token: 0x0600093E RID: 2366
		void OnWASD(InputAction.CallbackContext context);

		// Token: 0x0600093F RID: 2367
		void OnZ_key(InputAction.CallbackContext context);

		// Token: 0x06000940 RID: 2368
		void OnQ_key(InputAction.CallbackContext context);

		// Token: 0x06000941 RID: 2369
		void OnShift_mod(InputAction.CallbackContext context);

		// Token: 0x06000942 RID: 2370
		void OnAlt_mod(InputAction.CallbackContext context);

		// Token: 0x06000943 RID: 2371
		void OnR_key(InputAction.CallbackContext context);

		// Token: 0x06000944 RID: 2372
		void OnF_key(InputAction.CallbackContext context);
	}

	// Token: 0x02000197 RID: 407
	public interface IAm_tutorial_1Actions
	{
		// Token: 0x06000945 RID: 2373
		void OnEscape(InputAction.CallbackContext context);
	}

	// Token: 0x02000198 RID: 408
	public interface IAm_tutorial_2Actions
	{
		// Token: 0x06000946 RID: 2374
		void OnEscape(InputAction.CallbackContext context);
	}

	// Token: 0x02000199 RID: 409
	public interface IAm_tutorial_settingActions
	{
		// Token: 0x06000947 RID: 2375
		void OnEscape(InputAction.CallbackContext context);
	}
}
