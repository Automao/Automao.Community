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

using Zongsoft.Data;
using Zongsoft.Services;
using Zongsoft.Collections;
using Zongsoft.Security.Membership;

using Automao.Community.Models;

namespace Automao.Community.Services
{
	public class ForumService : Zongsoft.Data.DataService<Forum>
	{
		#region 构造函数
		public ForumService(Zongsoft.Services.IServiceProvider serviceProvider) : base(Forum.AccessKey, serviceProvider)
		{
		}
		#endregion

		protected override KeyValuePair[] GetKey(object[] values)
		{
			if(values.Length == 1)
				return KeyValuePair.CreatePairs(values, "ForumId");

			if(values.Length == 2)
				return KeyValuePair.CreatePairs(values, "SiteId", "GroupId");

			return base.GetKey(values);
		}

		protected override int OnInsert(DataDictionary<Forum> data, string scope)
		{
			
			data.TrySet(forum => forum.CreatedTime, DateTime.Now);

			return base.OnInsert(data, scope);
		}

		public IEnumerable<Thread> GetThreads(int forumId)
		{
			return this.DataAccess.Select<Thread>(Thread.AccessKey, Condition.Equal("ForumId", forumId), Sorting.Descending("CreatedTime"));
		}
	}
}
