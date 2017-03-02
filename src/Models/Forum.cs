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
using System.Collections.Generic;

namespace Automao.Community.Models
{
	/// <summary>
	/// 表示论坛的业务实体类。
	/// </summary>
	public class Forum : Zongsoft.ComponentModel.NotifyObject
	{
		#region 静态字段
		public static readonly string AccessKey = "Community.Forum";
		#endregion

		#region 成员字段
		private int _forumId;
		private int _siteId;
		private short _groupId;
		private short _sortOrder;
		private bool _isPopular;
		private int _totalPosts;
		private int _totalThreads;
		private int _mostRecentThreadId;
		private int _mostRecentThreadAuthorId;
		private int _mostRecentPostAuthorId;
		private bool _enabledPosting;
		private ForumVisiblity _visiblity;
		private ForumAccessibility _accessibility;
		private DateTime _createdTime;
		#endregion

		#region 构造函数
		public Forum()
		{
			_enabledPosting = true;
			_visiblity = ForumVisiblity.Public;
			_accessibility = ForumAccessibility.All;
			_createdTime = DateTime.Now;
		}
		#endregion

		#region 公共属性
		/// <summary>
		/// 获取或设置论坛编号，主键。
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
		/// 获取或设置论坛所属的站点编号。
		/// </summary>
		public int SiteId
		{
			get
			{
				return _siteId;
			}
			set
			{
				this.SetPropertyValue(() => this.SiteId, ref _siteId, value);
			}
		}

		/// <summary>
		/// 获取或设置论坛所属的组号。
		/// </summary>
		public short GroupId
		{
			get
			{
				return _groupId;
			}
			set
			{
				this.SetPropertyValue(() => this.GroupId, ref _groupId, value);
			}
		}

		/// <summary>
		/// 获取或设置论坛所属的 <see cref="ForumGroup"/> 分组对象。
		/// </summary>
		public ForumGroup Group
		{
			get
			{
				return this.GetPropertyValue(() => this.Group);
			}
			set
			{
				this.SetPropertyValue(() => this.Group, value);
			}
		}

		/// <summary>
		/// 获取或设置论坛所在分组中的排列序号。
		/// </summary>
		public short SortOrder
		{
			get
			{
				return _sortOrder;
			}
			set
			{
				this.SetPropertyValue(() => this.SortOrder, ref _sortOrder, value);
			}
		}

		/// <summary>
		/// 获取或设置论坛的名称(标题)。
		/// </summary>
		public string Name
		{
			get
			{
				return this.GetPropertyValue(() => this.Name);
			}
			set
			{
				this.SetPropertyValue(() => this.Name, value);
			}
		}

		/// <summary>
		/// 获取或设置论坛的描述文本。
		/// </summary>
		public string Description
		{
			get
			{
				return this.GetPropertyValue(() => this.Description);
			}
			set
			{
				this.SetPropertyValue(() => this.Description, value);
			}
		}

		/// <summary>
		/// 获取或设置论坛的封面图片路径。
		/// </summary>
		public string CoverPicturePath
		{
			get
			{
				return this.GetPropertyValue(() => this.CoverPicturePath);
			}
			set
			{
				this.SetPropertyValue(() => this.CoverPicturePath, value);
			}
		}

		/// <summary>
		/// 获取论坛封面图片的外部访问地址。
		/// </summary>
		public string CoverPictureUrl
		{
			get
			{
				return Zongsoft.IO.FileSystem.GetUrl(this.CoverPicturePath);
			}
		}

		/// <summary>
		/// 获取或设置一个值，表示论坛是否为热门版块。
		/// </summary>
		public bool IsPopular
		{
			get
			{
				return _isPopular;
			}
			set
			{
				this.SetPropertyValue(() => this.IsPopular, ref _isPopular, value);
			}
		}

		/// <summary>
		/// 获取或设置一个值，表示该论坛是否允许发帖。
		/// </summary>
		public bool EnabledPosting
		{
			get
			{
				return _enabledPosting;
			}
			set
			{
				this.SetPropertyValue(() => this.EnabledPosting, ref _enabledPosting, value);
			}
		}

		/// <summary>
		/// 获取或设置论坛的可见性。
		/// </summary>
		public ForumVisiblity Visiblity
		{
			get
			{
				return _visiblity;
			}
			set
			{
				this.SetPropertyValue(() => this.Visiblity, ref _visiblity, value);
			}
		}

		/// <summary>
		/// 获取或设置论坛的可访问性。
		/// </summary>
		public ForumAccessibility Accessibility
		{
			get
			{
				return _accessibility;
			}
			set
			{
				this.SetPropertyValue(() => this.Accessibility, ref _accessibility, value);
			}
		}

		/// <summary>
		/// 获取或设置论坛中的累计帖子总数。
		/// </summary>
		public int TotalPosts
		{
			get
			{
				return _totalPosts;
			}
			set
			{
				this.SetPropertyValue(() => this.TotalPosts, ref _totalPosts, value);
			}
		}

		/// <summary>
		/// 获取或设置论坛中的累积主题总数。
		/// </summary>
		public int TotalThreads
		{
			get
			{
				return _totalThreads;
			}
			set
			{
				this.SetPropertyValue(() => this.TotalThreads, ref _totalThreads, value);
			}
		}

		/// <summary>
		/// 获取或设置论坛中最新主题的编号。
		/// </summary>
		public int MostRecentThreadId
		{
			get
			{
				return _mostRecentThreadId;
			}
			set
			{
				this.SetPropertyValue(() => this.MostRecentThreadId, ref _mostRecentThreadId, value);
			}
		}

		/// <summary>
		/// 获取或设置论坛中最新主题的标题。
		/// </summary>
		public string MostRecentThreadSubject
		{
			get
			{
				return this.GetPropertyValue(() => this.MostRecentThreadSubject);
			}
			set
			{
				this.SetPropertyValue(() => this.MostRecentThreadSubject, value);
			}
		}

		/// <summary>
		/// 获取或设置论坛中最新主题的作者编号。
		/// </summary>
		public int MostRecentThreadAuthorId
		{
			get
			{
				return _mostRecentThreadAuthorId;
			}
			set
			{
				this.SetPropertyValue(() => this.MostRecentThreadAuthorId, ref _mostRecentThreadAuthorId, value);
			}
		}

		/// <summary>
		/// 获取或设置论坛中最新主题的作者名称。
		/// </summary>
		public string MostRecentThreadAuthorName
		{
			get
			{
				return this.GetPropertyValue(() => this.MostRecentThreadAuthorName);
			}
			set
			{
				this.SetPropertyValue(() => this.MostRecentThreadAuthorName, value);
			}
		}

		/// <summary>
		/// 获取或设置论坛中最新主题的作者头像。
		/// </summary>
		public string MostRecentThreadAuthorAvatar
		{
			get
			{
				return this.GetPropertyValue(() => this.MostRecentThreadAuthorAvatar);
			}
			set
			{
				this.SetPropertyValue(() => this.MostRecentThreadAuthorAvatar, value);
			}
		}

		/// <summary>
		/// 获取或设置论坛中最新主题的发布时间。
		/// </summary>
		public DateTime? MostRecentThreadTime
		{
			get
			{
				return this.GetPropertyValue(() => this.MostRecentThreadTime);
			}
			set
			{
				this.SetPropertyValue(() => this.MostRecentThreadTime, value);
			}
		}

		/// <summary>
		/// 获取或设置论坛中最后回帖的作者编号。
		/// </summary>
		public int MostRecentPostAuthorId
		{
			get
			{
				return _mostRecentPostAuthorId;
			}
			set
			{
				this.SetPropertyValue(() => this.MostRecentPostAuthorId, ref _mostRecentPostAuthorId, value);
			}
		}

		/// <summary>
		/// 获取或设置论坛中最后回帖的作者名称。
		/// </summary>
		public string MostRecentPostAuthorName
		{
			get
			{
				return this.GetPropertyValue(() => this.MostRecentPostAuthorName);
			}
			set
			{
				this.SetPropertyValue(() => this.MostRecentPostAuthorName, value);
			}
		}

		/// <summary>
		/// 获取或设置论坛中最后回帖的作者头像。
		/// </summary>
		public string MostRecentPostAuthorAvatar
		{
			get
			{
				return this.GetPropertyValue(() => this.MostRecentPostAuthorAvatar);
			}
			set
			{
				this.SetPropertyValue(() => this.MostRecentPostAuthorAvatar, value);
			}
		}

		/// <summary>
		/// 获取或设置论坛中最后回帖的时间。
		/// </summary>
		public DateTime? MostRecentPostTime
		{
			get
			{
				return this.GetPropertyValue(() => this.MostRecentPostTime);
			}
			set
			{
				this.SetPropertyValue(() => this.MostRecentPostTime, value);
			}
		}

		/// <summary>
		/// 获取或设置论坛的创建时间。
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
		/// 获取或设置论坛的版主集。
		/// </summary>
		public IEnumerable<Zongsoft.Security.Membership.User> Moderators
		{
			get
			{
				return this.GetPropertyValue(() => this.Moderators);
			}
			set
			{
				this.SetPropertyValue(() => this.Moderators, value);
			}
		}

		/// <summary>
		/// 获取或设置论坛的主题集。
		/// </summary>
		public IEnumerable<Thread> Threads
		{
			get
			{
				return this.GetPropertyValue(() => this.Threads);
			}
			set
			{
				this.SetPropertyValue(() => this.Threads, value);
			}
		}
		#endregion
	}
}
