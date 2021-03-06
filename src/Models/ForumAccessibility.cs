﻿/*
 * Authors:
 *   钟峰(Popeye Zhong) <9555843@qq.com>
 * 
 * Copyright (C) 2016 Automao. All rights reserved.
 * 
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 * 
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System;
using System.ComponentModel;

namespace Automao.Community.Models
{
	/// <summary>
	/// 表示论坛可访问性(发帖回帖)的枚举。
	/// </summary>
	public enum ForumAccessibility : byte
	{
		/// <summary>无限制，所有用户均可访问</summary>
		All,

		/// <summary>登录用户均可访问</summary>
		Users,

		/// <summary>仅限版主</summary>
		Moderators
	}
}
