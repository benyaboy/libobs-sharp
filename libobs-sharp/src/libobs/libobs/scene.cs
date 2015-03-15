/***************************************************************************
	Copyright (C) 2014-2015 by Ari Vuollet <ari.vuollet@kapsi.fi>

	This program is free software; you can redistribute it and/or
	modify it under the terms of the GNU General Public License
	as published by the Free Software Foundation; either version 2
	of the License, or (at your option) any later version.

	This program is distributed in the hope that it will be useful,
	but WITHOUT ANY WARRANTY; without even the implied warranty of
	MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
	GNU General Public License for more details.

	You should have received a copy of the GNU General Public License
	along with this program; if not, see <http://www.gnu.org/licenses/>.
***************************************************************************/

using System;
using System.Runtime.InteropServices;

namespace OBS
{
	using obs_scene_t = IntPtr;

	using obs_sceneitem_t = IntPtr;
	using obs_source_t = IntPtr;

	using uint32_t = UInt32;

	public static partial class libobs
	{
		/* ------------------------------------------------------------------------- */
		/* Scenes */

		[DllImport(importLibrary, CallingConvention = importCall, CharSet = importCharSet)]
		public static extern obs_scene_t obs_scene_create(string name);

		[DllImport(importLibrary, CallingConvention = importCall)]
		public static extern void obs_scene_addref(obs_scene_t source);

		[DllImport(importLibrary, CallingConvention = importCall)]
		public static extern void obs_scene_release(obs_scene_t source);

		[DllImport(importLibrary, CallingConvention = importCall)]
		public static extern obs_source_t obs_scene_get_source(obs_scene_t scene);

		[DllImport(importLibrary, CallingConvention = importCall)]
		public static extern obs_scene_t obs_scene_from_source(obs_source_t source);

		[DllImport(importLibrary, CallingConvention = importCall)]
		public static extern obs_sceneitem_t obs_scene_find_source(obs_scene_t scene, string name);

		[UnmanagedFunctionPointer(importCall, CharSet = importCharSet)]
		public delegate bool sceneitem_enum_callback(obs_scene_t scene, obs_sceneitem_t sceneItem, IntPtr data);

		[DllImport(importLibrary, CallingConvention = importCall)]
		public static extern void obs_scene_enum_items(obs_scene_t scene, sceneitem_enum_callback callback, IntPtr param);

		[DllImport(importLibrary, CallingConvention = importCall)]
		public static extern obs_sceneitem_t obs_scene_add(obs_scene_t scene, obs_source_t source);

		[DllImport(importLibrary, CallingConvention = importCall)]
		public static extern void obs_sceneitem_addref(obs_sceneitem_t item);

		[DllImport(importLibrary, CallingConvention = importCall)]
		public static extern void obs_sceneitem_release(obs_sceneitem_t item);

		[DllImport(importLibrary, CallingConvention = importCall)]
		public static extern void obs_sceneitem_remove(obs_sceneitem_t item);

		//EXPORT obs_scene_t *obs_sceneitem_get_scene(const obs_sceneitem_t *item);

		[DllImport(importLibrary, CallingConvention = importCall)]
		public static extern obs_source_t obs_sceneitem_get_source(obs_sceneitem_t scene);

		[DllImport(importLibrary, CallingConvention = importCall)]
		public static extern void obs_sceneitem_select(obs_sceneitem_t item, [MarshalAs(UnmanagedType.I1)] bool select);

		[DllImport(importLibrary, CallingConvention = importCall)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool obs_sceneitem_selected(obs_sceneitem_t item);

		[DllImport(importLibrary, CallingConvention = importCall)]
		public static extern void obs_sceneitem_set_pos(obs_sceneitem_t item, out vec2 pos);

		[DllImport(importLibrary, CallingConvention = importCall)]
		public static extern void obs_sceneitem_set_rot(obs_sceneitem_t item, float rot_deg);

		[DllImport(importLibrary, CallingConvention = importCall)]
		public static extern void obs_sceneitem_set_scale(obs_sceneitem_t item, out vec2 scale);

		[DllImport(importLibrary, CallingConvention = importCall)]
		public static extern void obs_sceneitem_set_alignment(obs_sceneitem_t item, uint32_t alignment);

		//EXPORT void obs_sceneitem_set_order(obs_sceneitem_t *item, enum obs_order_movement movement);
		//EXPORT void obs_sceneitem_set_order_position(obs_sceneitem_t *item, int position);
		//EXPORT void obs_sceneitem_set_bounds_type(obs_sceneitem_t *item, enum obs_bounds_type type);
		//EXPORT void obs_sceneitem_set_bounds_alignment(obs_sceneitem_t *item, uint32_t alignment);
		//EXPORT void obs_sceneitem_set_bounds(obs_sceneitem_t *item, const struct vec2 *bounds);

		[DllImport(importLibrary, CallingConvention = importCall)]
		public static extern void obs_sceneitem_get_pos(obs_sceneitem_t item, out vec2 pos);

		[DllImport(importLibrary, CallingConvention = importCall)]
		public static extern float obs_sceneitem_get_rot(obs_sceneitem_t item);

		[DllImport(importLibrary, CallingConvention = importCall)]
		public static extern void obs_sceneitem_get_scale(obs_sceneitem_t item, out vec2 scale);

		[DllImport(importLibrary, CallingConvention = importCall)]
		public static extern uint32_t obs_sceneitem_get_alignment(obs_sceneitem_t item);

		//EXPORT enum obs_bounds_type obs_sceneitem_get_bounds_type(const obs_sceneitem_t *item);
		//EXPORT uint32_t obs_sceneitem_get_bounds_alignment(const obs_sceneitem_t *item);
		//EXPORT void obs_sceneitem_get_bounds(const obs_sceneitem_t *item, struct vec2 *bounds);
		//EXPORT void obs_sceneitem_get_info(const obs_sceneitem_t *item, struct obs_transform_info *info);
		//EXPORT void obs_sceneitem_set_info(obs_sceneitem_t *item, const struct obs_transform_info *info);

		[DllImport(importLibrary, CallingConvention = importCall)]
		public static extern void obs_sceneitem_get_draw_transform(obs_sceneitem_t item, out matrix4 transform);

		[DllImport(importLibrary, CallingConvention = importCall)]
		public static extern void obs_sceneitem_get_box_transform(obs_sceneitem_t item, out matrix4 transform);

		public enum obs_bounds_type : int
		{
			OBS_BOUNDS_NONE,            /**< no bounds */
			OBS_BOUNDS_STRETCH,         /**< stretch (ignores base scale) */
			OBS_BOUNDS_SCALE_INNER,     /**< scales to inner rectangle */
			OBS_BOUNDS_SCALE_OUTER,     /**< scales to outer rectangle */
			OBS_BOUNDS_SCALE_TO_WIDTH,  /**< scales to the width  */
			OBS_BOUNDS_SCALE_TO_HEIGHT, /**< scales to the height */
			OBS_BOUNDS_MAX_ONLY,        /**< no scaling, maximum size only */
		};
	}
}