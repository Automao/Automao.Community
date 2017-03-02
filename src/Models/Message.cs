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
	public class Message : Zongsoft.ComponentModel.NotifyObject
	{
		#region 静态字段
		public static readonly string AccessKey = "Community.Message";
		#endregion

		#region 成员字段
		private long _messageId;
		private MessageStatus _status;
		private DateTime _statusTime;
		private int _fromId;
		private int _toId;
		private DateTime _createdTime;
		#endregion

		#region 构造函数
		public Message()
		{
			_createdTime = DateTime.Now;
		}
		#endregion

		#region 公共属性
		public long MessageId
		{
			get
			{
				return _messageId;
			}
			set
			{
				this.SetPropertyValue(() => this.MessageId, ref _messageId, value);
			}
		}

		public string Subject
		{
			get
			{
				return this.GetPropertyValue(() => this.Subject);
			}
			set
			{
				this.SetPropertyValue(() => this.Subject, value);
			}
		}

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

		public MessageStatus Status
		{
			get
			{
				return _status;
			}
			set
			{
				this.SetPropertyValue(() => this.Status, ref _status, value);
			}
		}

		public DateTime StatusTime
		{
			get
			{
				return _statusTime;
			}
			set
			{
				this.SetPropertyValue(() => this.StatusTime, ref _statusTime, value);
			}
		}

		public string StatusDescription
		{
			get
			{
				return this.GetPropertyValue(() => this.StatusDescription);
			}
			set
			{
				this.SetPropertyValue(() => this.StatusDescription, value);
			}
		}

		public int FromId
		{
			get
			{
				return _fromId;
			}
			set
			{
				this.SetPropertyValue(() => this.FromId, ref _fromId, value);
			}
		}

		public int ToId
		{
			get
			{
				return _toId;
			}
			set
			{
				this.SetPropertyValue(() => this.ToId, ref _toId, value);
			}
		}

		public DateTime? ReadTime
		{
			get
			{
				return this.GetPropertyValue(() => this.ReadTime);
			}
			set
			{
				this.SetPropertyValue(() => this.ReadTime, value);
			}
		}

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
