using System;

// Token: 0x0200005B RID: 91
public static class Enums_Localization
{
	// Token: 0x0200015E RID: 350
	public enum Language_E
	{
		// Token: 0x04000891 RID: 2193
		English_T,
		// Token: 0x04000892 RID: 2194
		Russian_T,
		// Token: 0x04000893 RID: 2195
		Japanese_T,
		// Token: 0x04000894 RID: 2196
		Schinese_T,
		// Token: 0x04000895 RID: 2197
		Czech_T,
		// Token: 0x04000896 RID: 2198
		Norwegian_T,
		// Token: 0x04000897 RID: 2199
		Dutch_T,
		// Token: 0x04000898 RID: 2200
		Polish_T,
		// Token: 0x04000899 RID: 2201
		Irish_T,
		// Token: 0x0400089A RID: 2202
		French_T
	}

	// Token: 0x0200015F RID: 351
	public enum Menu_E
	{
		// Token: 0x0400089C RID: 2204
		Start_T = 1,
		// Token: 0x0400089D RID: 2205
		Map_T = 3,
		// Token: 0x0400089E RID: 2206
		DLC_T = 5,
		// Token: 0x0400089F RID: 2207
		Setting_T = 7,
		// Token: 0x040008A0 RID: 2208
		Exit_T = 9,
		// Token: 0x040008A1 RID: 2209
		Reset_T = 11,
		// Token: 0x040008A2 RID: 2210
		Wishlist_T,
		// Token: 0x040008A3 RID: 2211
		Reset_level_T
	}

	// Token: 0x02000160 RID: 352
	public enum Setting_E
	{
		// Token: 0x040008A5 RID: 2213
		Resolution_T = 1,
		// Token: 0x040008A6 RID: 2214
		Screen_mode_T = 3,
		// Token: 0x040008A7 RID: 2215
		Language_name_T = 5,
		// Token: 0x040008A8 RID: 2216
		Music_T = 7,
		// Token: 0x040008A9 RID: 2217
		Sound_T = 9,
		// Token: 0x040008AA RID: 2218
		Helper_T = 11,
		// Token: 0x040008AB RID: 2219
		Next_card_selection_T = 13,
		// Token: 0x040008AC RID: 2220
		Glare_T = 15,
		// Token: 0x040008AD RID: 2221
		Max_FPS_T = 17,
		// Token: 0x040008AE RID: 2222
		Speed_interface_T = 19,
		// Token: 0x040008AF RID: 2223
		Sound_find_item_T = 21,
		// Token: 0x040008B0 RID: 2224
		Sound_find_group_T = 23
	}

	// Token: 0x02000161 RID: 353
	public enum Screen_mode_E
	{
		// Token: 0x040008B2 RID: 2226
		MaximizedWindow_T,
		// Token: 0x040008B3 RID: 2227
		Windowed_T,
		// Token: 0x040008B4 RID: 2228
		ExclusiveFullScreen_T
	}

	// Token: 0x02000162 RID: 354
	public enum Speed_interface_E
	{
		// Token: 0x040008B6 RID: 2230
		Normal_T = 1,
		// Token: 0x040008B7 RID: 2231
		Fast_T = 3,
		// Token: 0x040008B8 RID: 2232
		Very_fast_T = 5
	}

	// Token: 0x02000163 RID: 355
	public enum Add_Interface_E
	{
		// Token: 0x040008BA RID: 2234
		Puzzle_T = 1,
		// Token: 0x040008BB RID: 2235
		Next_level_T = 3,
		// Token: 0x040008BC RID: 2236
		Thanks_for_playing_T = 5
	}

	// Token: 0x02000164 RID: 356
	public enum Items_E
	{
		// Token: 0x040008BE RID: 2238
		VOID,
		// Token: 0x040008BF RID: 2239
		Ach_Racoon,
		// Token: 0x040008C0 RID: 2240
		Ach_Bag,
		// Token: 0x040008C1 RID: 2241
		Ach_Apple,
		// Token: 0x040008C2 RID: 2242
		Ach_Mouse,
		// Token: 0x040008C3 RID: 2243
		Ach_Chameleon,
		// Token: 0x040008C4 RID: 2244
		Ach_Bottle,
		// Token: 0x040008C5 RID: 2245
		Ach_Squirrel,
		// Token: 0x040008C6 RID: 2246
		Ach_Egg,
		// Token: 0x040008C7 RID: 2247
		Ach_Key,
		// Token: 0x040008C8 RID: 2248
		Ach_Star,
		// Token: 0x040008C9 RID: 2249
		Ach_Letter,
		// Token: 0x040008CA RID: 2250
		Ach_Candle,
		// Token: 0x040008CB RID: 2251
		Ach_Owl,
		// Token: 0x040008CC RID: 2252
		Ach_Bird,
		// Token: 0x040008CD RID: 2253
		Ach_Broom,
		// Token: 0x040008CE RID: 2254
		Ach_Cup,
		// Token: 0x040008CF RID: 2255
		Ach_Flower,
		// Token: 0x040008D0 RID: 2256
		Ach_Shovel,
		// Token: 0x040008D1 RID: 2257
		Ach_Lamp,
		// Token: 0x040008D2 RID: 2258
		Ach_Horseshoe,
		// Token: 0x040008D3 RID: 2259
		Ach_Dog,
		// Token: 0x040008D4 RID: 2260
		Ach_Cat,
		// Token: 0x040008D5 RID: 2261
		Ach_Сrocodile,
		// Token: 0x040008D6 RID: 2262
		Snail_DLC_T,
		// Token: 0x040008D7 RID: 2263
		Frog_DLC_T,
		// Token: 0x040008D8 RID: 2264
		Butterfly_DLC_T,
		// Token: 0x040008D9 RID: 2265
		Cup_and_saucer_DLC_T,
		// Token: 0x040008DA RID: 2266
		Glass_DLC_T,
		// Token: 0x040008DB RID: 2267
		Book_DLC_T,
		// Token: 0x040008DC RID: 2268
		Lizard_DLC_T,
		// Token: 0x040008DD RID: 2269
		Spider_DLC_T,
		// Token: 0x040008DE RID: 2270
		Pigeon_DLC_T,
		// Token: 0x040008DF RID: 2271
		Mouse_DLC_T,
		// Token: 0x040008E0 RID: 2272
		Apple_DLC_T,
		// Token: 0x040008E1 RID: 2273
		Potted_flower_DLC_T,
		// Token: 0x040008E2 RID: 2274
		Broom_DLC_T,
		// Token: 0x040008E3 RID: 2275
		Bottle_DLC_T,
		// Token: 0x040008E4 RID: 2276
		Table_lamps_DLC_T,
		// Token: 0x040008E5 RID: 2277
		Gear_DLC_T,
		// Token: 0x040008E6 RID: 2278
		Perfume_DLC_T,
		// Token: 0x040008E7 RID: 2279
		Bread_DLC_T,
		// Token: 0x040008E8 RID: 2280
		Bag_DLC_T,
		// Token: 0x040008E9 RID: 2281
		Guitar_DLC_T,
		// Token: 0x040008EA RID: 2282
		Promotional_poster_DLC_T,
		// Token: 0x040008EB RID: 2283
		Inkwell_DLC_T,
		// Token: 0x040008EC RID: 2284
		Dog_DLC_T,
		// Token: 0x040008ED RID: 2285
		Wall_clock_DLC_T,
		// Token: 0x040008EE RID: 2286
		Squirrel_DLC_T,
		// Token: 0x040008EF RID: 2287
		Hedgehog_DLC_T,
		// Token: 0x040008F0 RID: 2288
		Hawk_DLC_T,
		// Token: 0x040008F1 RID: 2289
		Key_DLC_T,
		// Token: 0x040008F2 RID: 2290
		Landline_DLC_T,
		// Token: 0x040008F3 RID: 2291
		Pie_DLC_T,
		// Token: 0x040008F4 RID: 2292
		Gramophone_DLC_T,
		// Token: 0x040008F5 RID: 2293
		Chandelier_DLC_T,
		// Token: 0x040008F6 RID: 2294
		Teapot_DLC_T,
		// Token: 0x040008F7 RID: 2295
		Globe_DLC_T,
		// Token: 0x040008F8 RID: 2296
		Sewer_hatch_DLC_T,
		// Token: 0x040008F9 RID: 2297
		Umbrella_DLC_T,
		// Token: 0x040008FA RID: 2298
		Smoking_pipe_DLC_T,
		// Token: 0x040008FB RID: 2299
		Policeman_DLC_T,
		// Token: 0x040008FC RID: 2300
		smoking_lady_DLC_T,
		// Token: 0x040008FD RID: 2301
		grandfather_with_a_cane_DLC_T,
		// Token: 0x040008FE RID: 2302
		gentleman_with_a_wine_glass_DLC_T,
		// Token: 0x040008FF RID: 2303
		grandfather_with_a_tea_DLC_T,
		// Token: 0x04000900 RID: 2304
		The_shepherd_DLC_T,
		// Token: 0x04000901 RID: 2305
		Flower_seller_DLC_T,
		// Token: 0x04000902 RID: 2306
		The_bus_driver_DLC_T,
		// Token: 0x04000903 RID: 2307
		Grandma_in_a_wheelchair_DLC_T,
		// Token: 0x04000904 RID: 2308
		Children_1_7_years_old_DLC_T
	}
}
