
## 社区系统


### 通知消息表 `Community.Message`

字段名称|数据类型|长度|可空|备注
--------|:------:|:--:|:--:|----:
MessageId | bigint | 8 | False | 主键，消息编号
Subject | nvarchar | 100 | False | 消息主题
ContentPath | varchar | 200 | True | 消息内容
Status | byte | 1 | False | 状态(0:未发送, 1:发送中, 2:已发送, 3:删除)
StatusTime | datetime | - | False | 状态更新时间
StatusDescription | nvarchar | 100 | True | 状态描述
FromId | int | 4 | True | 发送人编号(空表示系统消息)
ToId | int | 4 | True | 接收人编号(空表示广播; 0表示用户的反馈信息)
ReadTime | datetime | - | True | 查收时间(仅限个人接受者)
CreatedTime | datetime | - | False | 创建时间


-------


### 论坛分组表 `Community.ForumGroup`

字段名称|数据类型|长度|可空|备注
--------|:------:|:--:|:--:|----:
SiteId | int | 4 | False | 主键，站点编号(所属企业)
GroupId | smallint | 2 | False | 主键，论坛分组编号
Name | nvarchar | 50 | False | 论坛组名
Icon | varchar | 100 | True | 显示图标
SortOrder | smallint | 2 | False | 排列顺序
Description | nvarchar | 500 | True | 描述信息


### 论坛表 `Community.Forum`

字段名称|数据类型|长度|可空|备注
--------|:------:|:--:|:--:|----:
ForumId | int | 4 | False | 主键，论坛编号
SiteId | int | 4 | False | 站点编号
GroupId | smallint | 2 | False | 论坛组编号
Name | nvarchar | 50 | False | 论坛名称
Description | nvarchar | 500 | True | 描述文本
CoverPicturePath | varchar | 200 | True | 封面图片路径
SortOrder | smallint | 2 | False | 排列顺序
IsPopular | bool | - | False | 是否热门版块
Visiblity | byte | 1 | False | 可见范围(0:禁用,即不可见; 1:企业内部范围可见; 2:所有人可见)
Accessibility | byte | 1 | False | 可访问性(0:无限制; 1:注册用户; 2:仅限版主)
TotalPosts | int | 4 | False | 累计帖子总数
TotalThreads | int | 4 | False | 累计主题总数
MostRecentThreadId | int | 4 | True | 最新主题的编号
MostRecentThreadSubject | nvarchar | 100 | True | 最新主题的标题
MostRecentThreadAuthorId | int | 4 | True | 最新主题的作者编号
MostRecentThreadAuthorName | nvarchar | 50 | True | 最新主题的作者名
MostRecentThreadAuthorAvatar | varchar | 150 | True | 最新主题的作者头像
MostRecentThreadTime | datetime | - | True | 最新主题的发布时间
MostRecentPostAuthorId | int | 4 | True | 最后回帖的作者编号
MostRecentPostAuthorName | nvarchar | 50 | True | 最后回帖的作者名
MostRecentPostAuthorAvatar | varchar | 150 | True | 最后回帖的作者头像
MostRecentPostTime | datetime | - | True | 最后回帖的时间
CreatedTime | datetime | - | False | 创建时间


### 版主表 `Community.Moderator`

字段名称|数据类型|长度|可空|备注
--------|:------:|:--:|:--:|----:
ForumId | int | 4 | False | 主键，论坛编号
UserId | int | 4 | False | 主键，用户编号


### 帖子表 `Community.Post`

字段名称|数据类型|长度|可空|备注
--------|:------:|:--:|:--:|----:
PostId | bigint | 8 | False | 主键，帖子编号
ThreadId | int | 4 | False | 所属主题编号
ContentPath | varchar | 200 | False | 活动内容文件的路径
ParentId | bigint | 8 | True | 应答的回复编号
Disabled | bool | - | False | 已被禁用(False)
IsApproved | bool | - | False | 是否审核通过
IsLocked | bool | - | False | 是否已锁定(锁定则不允许回复)
IsValued | bool | _ | False | 是否精华帖
TotalLikes | int | 4 | False | 累计点赞数
VisitorAddress | nvarchar | 100 | True | 访客地址(IP和位置信息)(192.168.0.1 湖北省武汉市)
VisitorDescription | varchar | 500 | True | 访客描述(浏览器代理信息)
CreatorId | int | 4 | False | 发帖人编号
CreatedTime | datetime | - | False | 发帖时间


### 帖子点赞表 `Community.Liking`

字段名称|数据类型|长度|可空|备注
--------|:------:|:--:|:--:|----:
PostId | bigint | 8 | False | 主键，帖子编号
UserId | int | 4 | False | 主键，用户编号
Points | byte | 1 | False | 赞助积分
CreatedTime | datetime | - | False | 点赞时间


### 主题表 `Community.Thread`

字段名称|数据类型|长度|可空|备注
--------|:------:|:--:|:--:|----:
ThreadId | int | 4 | False | 主键，主题编号
ForumId | int | 4 | False | 所属论坛编号
Subject | nvarchar | 100 | False | 文章标题
Summary | nvarchar | 500 | True | 文章摘要
PostId | bigint | 8 | False | 内容帖子编号
CoverPicturePath | varchar | 200 | True | 封面图片路径
LinkUrl | varchar | 200 | True | 文章跳转链接
Status | byte | 1 | False | 状态(0:未发送, 1:发送中, 2:已发送, 3:已取消)
StatusTime | datetime | - | False | 状态更新时间
StatusDescription | nvarchar | 100 | True | 状态描述
Disabled | bool | - | False | 已被禁用(False)
IsApproved | bool | - | False | 是否审核通过
IsLocked | bool | - | False | 已被锁定（锁定则不允许回复）
IsPinned | bool | - | False | 是否置顶
IsValued | bool | - | False | 是否精华帖
IsGlobal | bool | - | False | 是否全局贴
TotalViews | int | 4 | False | 累计阅读数
TotalLikes | int | 4 | False | 累计点赞数
TotalReplies | int | 4 | False | 累计回帖数
PinnedTime | datetime | - | True | 置顶时间
GlobalTime | datetime | - | True | 全局时间
ViewedTime | datetime | - | True | 最后被阅读时间
MostRecentPostId | bigint | 8 | True | 最后回帖的帖子编号
MostRecentPostAuthorId | int | 4 | True | 最后回帖的作者编号
MostRecentPostAuthorName | nvarchar | 50 | True | 最后回帖的作者名称
MostRecentPostAuthorAvatar | nvarchar | 150 | True | 最后回帖的作者头像
MostRecentPostTime | datetime | - | True | 最后回帖的时间
CreatorId | int | 4 | False | 创建人编号
CreatedTime | datetime | - | False | 创建时间


### 用户发帖记录表 `Community.Posting`

字段名称|数据类型|长度|可空|备注
--------|:------:|:--:|:--:|----:
UserId | int | 4 | False | 主键，用户编号
PostId | long | 8 | False | 主键，帖子编号(零表示为主题)
ThreadId | int | 4 | False | 主题编号
ForumId | int | 4 | False | 论坛编号
Kind | byte | 1 | False | 内容类型(0:回复; 1:主题)
CreatedTime | datetime | - | False | 创建时间


### 用户配置表 `Community.UserProfile`

字段名称|数据类型|长度|可空|备注
--------|:------:|:--:|:--:|----:
UserId | int | 4 | False | 主键，用户编号
TotalPosts | int | 4 | False | 累计回复总数
TotalThreads | int | 4 | False | 累计主题总数
TotalInLikes | int | 4 | False | 累计收获的赞数
TotalOutLikes | int | 4 | False | 累计点击的赞数
MostRecentPostId | bigint | 8 | True | 最后回帖的帖子编号
MostRecentPostTime | datetime | - | True | 最后回帖的时间
MostRecentThreadId | int | 4 | True | 最新主题的编号
MostRecentThreadSubject | nvarchar | 100 | True | 最新主题的标题
MostRecentThreadTime | datetime | - | True | 最新主题的发布时间
CreatedTime | datetime | - | False | 创建时间