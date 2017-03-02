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
using System.Collections.Generic;

namespace Automao.Community.Models
{
	/// <summary>
	/// 表示帖子的业务实体类。
	/// </summary>
	public class Post : Zongsoft.ComponentModel.NotifyObject
	{
		#region 静态字段
		public static readonly string AccessKey = "Community.Post";
		#endregion

		#region 成员字段
		private long _postId;
		private int _threadId;
		private bool _disabled;
		private bool _isApproved;
		private bool _isLocked;
		private bool _isValued;
		private int _totalViews;
		private int _totalLikes;
		private int _creatorId;
		private DateTime _createdTime;
		#endregion

		#region 构造函数
		public Post()
		{
			_createdTime = DateTime.Now;
		}
		#endregion

		#region 公共属性
		/// <summary>
		/// 获取或设置帖子编号，主键。
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
		/// 获取或设置帖子所属的主题编号。
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
		/// 获取或设置帖子所属的主题对象。
		/// </summary>
		public Thread Thread
		{
			get
			{
				return this.GetPropertyValue(() => this.Thread);
			}
			set
			{
				this.SetPropertyValue(() => this.Thread, value);
			}
		}

		/// <summary>
		/// 获取或设置帖子的内容文件路径。
		/// </summary>
		public string ContentPath
		{
			get
			{
				return this.GetPropertyValue(() => this.ContentPath);
			}
			set
			{
				this.SetPropertyValue(() => this.ContentPath, value);
			}
		}

		/// <summary>
		/// 获取或设置帖子的内容。
		/// </summary>
		public string Content
		{
			get
			{
				return this.GetPropertyValue(() => this.Content);
			}
			set
			{
				this.SetPropertyValue(() => this.Content, value);
			}
		}

		/// <summary>
		/// 获取或设置回帖的父贴编号。
		/// </summary>
		public long? ParentId
		{
			get
			{
				return this.GetPropertyValue(() => this.ParentId);
			}
			set
			{
				this.SetPropertyValue(() => this.ParentId, value);
			}
		}

		/// <summary>
		/// 获取或设置回帖的父贴。
		/// </summary>
		public Post Parent
		{
			get
			{
				return this.GetPropertyValue(() => this.Parent);
			}
			set
			{
				this.SetPropertyValue(() => this.Parent, value);
			}
		}

		/// <summary>
		/// 获取或设置一个值，表示是否禁用。
		/// </summary>
		public bool Disabled
		{
			get
			{
				return _disabled;
			}
			set
			{
				this.SetPropertyValue(() => this.Disabled, ref _disabled, value);
			}
		}

		/// <summary>
		/// 获取或设置一个值，表示帖子是否被审核通过。
		/// </summary>
		public bool IsApproved
		{
			get
			{
				return _isApproved;
			}
			set
			{
				this.SetPropertyValue(() => this.IsApproved, ref _isApproved, value);
			}
		}

		/// <summary>
		/// 获取或设置一个值，表示帖子是否被锁定，如果锁定则不允许回复。
		/// </summary>
		public bool IsLocked
		{
			get
			{
				return _isLocked;
			}
			set
			{
				this.SetPropertyValue(() => this.IsLocked, ref _isLocked, value);
			}
		}

		/// <summary>
		/// 获取或设置一个值，表示帖子是否为精华帖。
		/// </summary>
		public bool IsValued
		{
			get
			{
				return _isValued;
			}
			set
			{
				this.SetPropertyValue(() => this.IsValued, ref _isValued, value);
			}
		}

		/// <summary>
		/// 获取或设置帖子累计获得的点赞总数。
		/// </summary>
		public int TotalLikes
		{
			get
			{
				return _totalLikes;
			}
			set
			{
				this.SetPropertyValue(() => this.TotalLikes, ref _totalLikes, value);
			}
		}

		/// <summary>
		/// 获取或设置访问者的位置信息。
		/// </summary>
		public string VisitorAddress
		{
			get
			{
				return this.GetPropertyValue(() => this.VisitorAddress);
			}
			set
			{
				this.SetPropertyValue(() => this.VisitorAddress, value);
			}
		}

		/// <summary>
		/// 获取或设置访问者的描述信息。
		/// </summary>
		public string VisitorDescription
		{
			get
			{
				return this.GetPropertyValue(() => this.VisitorDescription);
			}
			set
			{
				this.SetPropertyValue(() => this.VisitorDescription, value);
			}
		}

		/// <summary>
		/// 获取或设置帖子作者编号。
		/// </summary>
		public int CreatorId
		{
			get
			{
				return _creatorId;
			}
			set
			{
				this.SetPropertyValue(() => this.CreatorId, ref _creatorId, value);
			}
		}

		/// <summary>
		/// 获取或设置帖子的创建时间。
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

		/// <summary>
		/// 获取或设置帖子作者对应的用户对象。
		/// </summary>
		public Zongsoft.Security.Membership.User Creator
		{
			get
			{
				return this.GetPropertyValue(() => this.Creator);
			}
			set
			{
				this.SetPropertyValue(() => this.Creator, value);
			}
		}

		/// <summary>
		/// 获取或设置帖子的子贴集，即回帖子集。
		/// </summary>
		public IEnumerable<Post> Children
		{
			get
			{
				return this.GetPropertyValue(() => this.Children);
			}
			set
			{
				this.SetPropertyValue(() => this.Children, value);
			}
		}
		#endregion
	}
}
