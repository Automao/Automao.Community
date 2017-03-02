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
	/// 表示用户发帖记录的实体类。
	/// </summary>
	public class Posting : Zongsoft.ComponentModel.NotifyObject
	{
		#region 静态字段
		public static readonly string AccessKey = "Community.Posting";
		#endregion

		#region 成员字段
		private int _userId;
		private long _postId;
		private int _threadId;
		private int _forumId;
		private PostingKind _kind;
		private DateTime _createdTime;
		#endregion

		#region 构造函数
		public Posting()
		{
			_createdTime = DateTime.Now;
		}
		#endregion

		#region 公共属性
		/// <summary>
		/// 获取或设置发帖用户的编号。
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
		/// 获取或设置发帖的帖子编号。
		/// </summary>
		public long PostId
		{
			get
			{
				return _postId;
			}
			set
			{
				this.SetPropertyValue(() => this.PostId, ref _postId, value);
			}
		}

		/// <summary>
		/// 获取或设置发帖对应的主题编号。
		/// </summary>
		public int ThreadId
		{
			get
			{
				return _threadId;
			}
			set
			{
				this.SetPropertyValue(() => this.ThreadId, ref _threadId, value);
			}
		}

		/// <summary>
		/// 获取或设置发帖所在的论坛编号。
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
		/// 获取或设置发布的帖子类型。
		/// </summary>
		public PostingKind Kind
		{
			get
			{
				return _kind;
			}
			set
			{
				this.SetPropertyValue(() => this.Kind, ref _kind, value);
			}
		}

		/// <summary>
		/// 获取或设置发帖的时间。
		/// </summary>
		public DateTime CreatedTime
		{
			get
			{
				return _createdTime;
			}
			set
			{
				this.SetPropertyValue(() => this.CreatedTime, ref _createdTime, value);
			}
		}
		#endregion
	}
}
