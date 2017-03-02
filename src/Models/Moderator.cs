/*
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
using System.Collections.Generic;

namespace Automao.Community.Models
{
	/// <summary>
	/// 表示版主的业务实体类。
	/// </summary>
	public class Moderator : Zongsoft.ComponentModel.NotifyObject
	{
		#region 静态字段
		public static readonly string AccessKey = "Community.Moderator";
		#endregion

		#region 成员字段
		private int _forumId;
		private int _userId;
		#endregion

		#region 构造函数
		public Moderator()
		{
		}

		public Moderator(int forumId, int userId)
		{
			_forumId = forumId;
			_userId = userId;
		}
		#endregion

		#region 公共属性
		/// <summary>
		/// 获取或设置版主所属论坛编号。
		/// </summary>
		public int ForumId
		{
			get
			{
				return _forumId;
			}
			set
			{
				this.SetPropertyValue(() => this.ForumId, ref _forumId, value);
			}
		}

		/// <summary>
		/// 获取或设置版主的用户编号。
		/// </summary>
		public int UserId
		{
			get
			{
				return _userId;
			}
			set
			{
				this.SetPropertyValue(() => this.UserId, ref _userId, value);
			}
		}

		/// <summary>
		/// 获取或设置版主所属的论坛对象。
		/// </summary>
		public Forum Forum
		{
			get
			{
				return this.GetPropertyValue(() => this.Forum);
			}
			set
			{
				this.SetPropertyValue(() => this.Forum, value);
			}
		}

		/// <summary>
		/// 获取或设置版主的用户信息。
		/// </summary>
		public Zongsoft.Security.Membership.User User
		{
			get
			{
				return this.GetPropertyValue(() => this.User);
			}
			set
			{
				this.SetPropertyValue(() => this.User, value);
			}
		}
		#endregion
	}
}
