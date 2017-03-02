CREATE DATABASE IF NOT EXISTS `Automao` DEFAULT CHARACTER SET utf8;

USE `Automao`;

SET NAMES utf8;
SET TIME_ZONE='+08:00';


CREATE TABLE IF NOT EXISTS `Community_Message`
(
  `MessageId` bigint NOT NULL COMMENT '主键，消息编号',
  `Subject` varchar(100) NOT NULL COMMENT '消息标题',
  `ContentPath` varchar(200) DEFAULT NULL COMMENT '内容文件路径',
  `Status` tinyint(4) NOT NULL COMMENT '状态(0:未发送, 1:发送中, 2:已发送, 3:删除)',
  `StatusTime` datetime NOT NULL COMMENT '状态更改时间',
  `StatusDescription` varchar(100) DEFAULT NULL COMMENT '状态描述信息',
  `FromId` int(11) DEFAULT NULL COMMENT '发送人编号(空表示系统消息)',
  `ToId` int(11) DEFAULT NULL COMMENT '接收人编号(空表示广播; 0表示用户的反馈信息)',
  `ReadTime` datetime NULL COMMENT '查收时间(仅限个人接受者)',
  `CreatedTime` datetime NOT NULL COMMENT '创建时间',
  PRIMARY KEY (`MessageId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='通知消息表';

CREATE TABLE IF NOT EXISTS `Community_ForumGroup`
(
  `SiteId` int NOT NULL COMMENT '主键，站点编号',
  `GroupId` smallint NOT NULL COMMENT '主键，分组编号',
  `Name` varchar(50) NOT NULL COMMENT '论坛组名称',
  `Icon` varchar(100) NULL COMMENT '显示图标',
  `SortOrder` smallint NOT NULL DEFAULT 0 COMMENT '排列顺序',
  `Description` varchar(500) DEFAULT NULL COMMENT '描述文本',
  PRIMARY KEY (`SiteId`, `GroupId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='论坛分组表';

CREATE TABLE IF NOT EXISTS `Community_Forum`
(
  `ForumId` int NOT NULL COMMENT '主键，论坛编号',
  `SiteId` int NOT NULL COMMENT '站点编号',
  `GroupId` smallint NOT NULL COMMENT '论坛组编号',
  `Name` varchar(50) NOT NULL COMMENT '论坛名称',
  `Description` varchar(500) DEFAULT NULL COMMENT '描述文本',
  `CoverPicturePath` varchar(200) DEFAULT NULL COMMENT '封面图片文件路径',
  `SortOrder` smallint NOT NULL DEFAULT 0 COMMENT '排列顺序',
  `IsPopular` tinyint(1) NOT NULL DEFAULT 0 COMMENT '是否热门版块',
  `Visiblity` tinyint NOT NULL DEFAULT 0 COMMENT '可见范围(0:禁用,即不可见; 1:企业范围可见; 2: 所有人可见; 3:所有人可发帖)',
  `Accessibility` tinyint NOT NULL DEFAULT 0 COMMENT '可访问性(0:无限制; 1:注册用户; 2:仅限版主)',
  `TotalPosts` int NOT NULL DEFAULT 0 COMMENT '累计帖子总数',
  `TotalThreads` int NOT NULL DEFAULT 0 COMMENT '累计主题总数',
  `MostRecentThreadId` int NULL COMMENT '最新主题的编号',
  `MostRecentThreadSubject` nvarchar(100) NULL COMMENT '最新主题的标题',
  `MostRecentThreadAuthorId` int NULL COMMENT '最新主题的作者编号',
  `MostRecentThreadAuthorName` nvarchar(50) NULL COMMENT '最新主题的作者名',
  `MostRecentThreadAuthorAvatar` varchar(150) NULL COMMENT '最新主题的作者头像',
  `MostRecentThreadTime` datetime NULL DEFAULT NULL COMMENT '最新主题的发布时间',
  `MostRecentPostAuthorId` int NULL COMMENT '最后回帖的作者编号',
  `MostRecentPostAuthorName` nvarchar(50) NULL COMMENT '最后回帖的作者名',
  `MostRecentPostAuthorAvatar` varchar(150) NULL COMMENT '最后回帖的作者头像',
  `MostRecentPostTime` datetime NULL DEFAULT NULL COMMENT '最后回帖的时间',
  `CreatedTime` datetime NOT NULL COMMENT '创建时间',
  PRIMARY KEY (`ForumId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='论坛表';

CREATE TABLE IF NOT EXISTS `Community_Moderator`
(
  `ForumId` int NOT NULL COMMENT '主键，论坛编号',
  `UserId` int NOT NULL COMMENT '主键，用户编号',
  PRIMARY KEY (`ForumId`, `UserId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='版主表';

CREATE TABLE IF NOT EXISTS `Community_Post`
(
  `PostId` bigint NOT NULL COMMENT '主键，帖子编号',
  `ThreadId` int NOT NULL COMMENT '主题(文章)编号',
  `ContentPath` varchar(200) NULL COMMENT '内容文件的路径',
  `ParentId` bigint DEFAULT NULL COMMENT '父帖子编号(应答的回复编号)',
  `Disabled` tinyint(1) NOT NULL DEFAULT 0 COMMENT '是否已禁用',
  `IsApproved` tinyint(1) NOT NULL DEFAULT 1 COMMENT '是否已审核通过',
  `IsLocked` tinyint(1) NOT NULL DEFAULT 0 COMMENT '是否已锁定',
  `IsValued` tinyint(1) NOT NULL DEFAULT 0 COMMENT '是否精华帖',
  `TotalLikes` int NOT NULL DEFAULT 0 COMMENT '累计点赞数',
  `VisitorAddress` varchar(100) NULL COMMENT '访客地址(IP和地址信息)',
  `VisitorDescription` varchar(500) NULL COMMENT '访客描述(浏览器代理信息)',
  `CreatorId` int NOT NULL COMMENT '发帖人编号',
  `CreatedTime` datetime NOT NULL COMMENT '发帖时间',
  PRIMARY KEY (`PostId` DESC)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='帖子/回帖表';

CREATE TABLE IF NOT EXISTS `Community_Liking`
(
  `PostId` bigint NOT NULL COMMENT '主键，帖子编号',
  `UserId` int NOT NULL COMMENT '主键，用户编号',
  `Points` tinyint NOT NULL DEFAULT 0 COMMENT '赞助积分',
  `CreatedTime` datetime NOT NULL COMMENT '发帖时间',
  PRIMARY KEY (`PostId` DESC, `UserId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='帖子点赞表';

CREATE TABLE IF NOT EXISTS `Community_Posting`
(
  `UserId` int NOT NULL COMMENT '主键，用户编号',
  `PostId` bigint NOT NULL COMMENT '主键，帖子编号(零表示为主题)',
  `ThreadId` int NOT NULL COMMENT '主题积分',
  `ForumId` int NOT NULL COMMENT '论坛编号',
  `Kind` tinyint NOT NULL COMMENT '内容类型(0:回复; 1:主题)',
  `CreatedTime` datetime NOT NULL COMMENT '创建时间',
  PRIMARY KEY (`UserId`, `PostId` DESC)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='用户发帖记录表';

CREATE TABLE IF NOT EXISTS `Community_Thread`
(
  `ThreadId` int NOT NULL COMMENT '主键，主题(文章)编号',
  `ForumId` int NOT NULL COMMENT '所属论坛编号',
  `Subject` varchar(100) NOT NULL COMMENT '文章标题',
  `Summary` varchar(500) NOT NULL COMMENT '文章摘要',
  `PostId` bigint NOT NULL COMMENT '内容帖子编号',
  `CoverPicturePath` varchar(200) DEFAULT NULL COMMENT '封面图片文件路径',
  `LinkUrl` varchar(200) DEFAULT NULL COMMENT '文章跳转链接',
  `Status` tinyint(4) NOT NULL DEFAULT 0 COMMENT '状态(0:未发送, 1:发送中, 2:已发送, 3:已取消)',
  `StatusTime` datetime NOT NULL COMMENT '状态更改时间',
  `StatusDescription` varchar(100) DEFAULT NULL COMMENT '状态描述信息',
  `Disabled` tinyint(1) NOT NULL DEFAULT 0 COMMENT '已被禁用',
  `IsApproved` tinyint(1) NOT NULL DEFAULT 1 COMMENT '是否锁定(锁定则不允许回复)',
  `IsLocked` tinyint(1) NOT NULL DEFAULT 0 COMMENT '是否锁定(锁定则不允许回复)',
  `IsPinned` tinyint(1) NOT NULL DEFAULT 0 COMMENT '是否置顶',
  `IsValued` tinyint(1) NOT NULL DEFAULT 0 COMMENT '是否精华帖',
  `IsGlobal` tinyint(1) NOT NULL DEFAULT 0 COMMENT '是否全局贴',
  `TotalViews` int NOT NULL DEFAULT 0 COMMENT '累计阅读数',
  `TotalLikes` int NOT NULL DEFAULT 0 COMMENT '累计点赞数',
  `TotalReplies` int NOT NULL DEFAULT 0 COMMENT '累计回帖数',
  `PinnedTime` datetime DEFAULT NULL COMMENT '置顶时间',
  `GlobalTime` datetime DEFAULT NULL COMMENT '全局时间',
  `ViewedTime` datetime DEFAULT NULL COMMENT '最后被查看时间',
  `MostRecentPostId` bigint NULL COMMENT '最后回帖的帖子编号',
  `MostRecentPostAuthorId` int NULL COMMENT '最后回帖的作者编号',
  `MostRecentPostAuthorName` nvarchar(50) NULL COMMENT '最后回帖的作者名',
  `MostRecentPostAuthorAvatar` varchar(150) NULL COMMENT '最后回帖的作者头像',
  `MostRecentPostTime` datetime NULL DEFAULT NULL COMMENT '最后回帖的时间',
  `CreatorId` int NOT NULL COMMENT '作者编号',
  `CreatedTime` datetime NOT NULL COMMENT '创建时间',
  PRIMARY KEY (`ThreadId` DESC)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='文章/主题表';

CREATE TABLE IF NOT EXISTS `Community_UserProfile`
(
  `UserId` int NOT NULL COMMENT '主键，用户编号',
  `TotalPosts` int NOT NULL COMMENT '累计回复总数',
  `TotalThreads` int NOT NULL COMMENT '累计主题总数',
  `TotalInLikes` int NOT NULL COMMENT '累计收获的赞数',
  `TotalOutLikes` int NOT NULL COMMENT '累计点击的赞数',
  `MostRecentPostId` bigint DEFAULT NULL COMMENT '最后回帖的帖子编号',
  `MostRecentPostTime` datetime DEFAULT NULL COMMENT '最后回帖的时间',
  `MostRecentThreadId` int NOT NULL COMMENT '最新主题的编号',
  `MostRecentThreadSubject` nvarchar(100) NOT NULL COMMENT '最新主题的标题',
  `MostRecentThreadTime` datetime DEFAULT NULL COMMENT '最新主题的发布时间',
  `CreatedTime` datetime NOT NULL COMMENT '创建时间',
  PRIMARY KEY (`UserId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='用户配置表';
