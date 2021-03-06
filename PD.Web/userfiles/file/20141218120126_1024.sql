USE [GameManage]
GO
/****** Object:  Table [dbo].[ViewPwd]    Script Date: 12/15/2014 14:15:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ViewPwd](
	[ID] [varchar](32) NOT NULL,
	[RoleID] [varchar](32) NULL,
	[Server] [varchar](255) NULL,
	[Name] [varchar](32) NULL,
	[Time] [datetime] NULL,
	[IP] [varchar](32) NULL,
	[OrderID] [varchar](32) NULL,
	[Faction] [varchar](255) NULL,
	[Area] [varchar](255) NULL,
 CONSTRAINT [PK_PwdHistory] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[UserType]    Script Date: 12/15/2014 14:15:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[UserType](
	[ID] [varchar](32) NULL,
	[Name] [varchar](50) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[UserType] ([ID], [Name]) VALUES (N'05ab1ba8df824a0e9dedec80d0d5fbcb', N'客服')
INSERT [dbo].[UserType] ([ID], [Name]) VALUES (N'88f7b261ab9c470f9a8d4504a338f800', N'代练员')
INSERT [dbo].[UserType] ([ID], [Name]) VALUES (N'3a403a51a8df4b91928d45cbe2bc8820', N'合作商')
INSERT [dbo].[UserType] ([ID], [Name]) VALUES (N'08477ab683f94d229b626432a7a7be18', N'工作室')
/****** Object:  Table [dbo].[User]    Script Date: 12/15/2014 14:15:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[User](
	[UserID] [varchar](32) NOT NULL,
	[UserPassd] [varchar](100) NULL,
	[UserName] [varchar](100) NULL,
	[NickName] [varchar](50) NULL,
	[RealName] [varchar](50) NULL,
	[PinYin] [varchar](50) NULL,
	[QQ] [varchar](50) NULL,
	[YY] [varchar](50) NULL,
	[WW] [varchar](50) NULL,
	[Phone] [varchar](50) NULL,
	[RoleID] [varchar](32) NULL,
	[State] [varchar](50) NULL,
	[IsBqq] [int] NULL,
	[InsertTime] [datetime] NULL,
	[BYZD1] [varchar](50) NULL,
	[BYZD2] [varchar](50) NULL,
	[BYZD3] [varchar](50) NULL,
	[BYZD4] [varchar](50) NULL,
	[BYZD5] [varchar](50) NULL,
	[UserTypeID] [varchar](32) NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[User] ([UserID], [UserPassd], [UserName], [NickName], [RealName], [PinYin], [QQ], [YY], [WW], [Phone], [RoleID], [State], [IsBqq], [InsertTime], [BYZD1], [BYZD2], [BYZD3], [BYZD4], [BYZD5], [UserTypeID]) VALUES (N'10000', N'E10ADC3949BA59ABBE56E057F20F883E', N'ankj@live.com', N'admin', N'admin', N'A', N'13787001131', NULL, NULL, N'13787001131', N'a1a31285e0134fcebe4f448ede5cc15f', N'0', 0, CAST(0x0000A3E6017F721C AS DateTime), NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[User] ([UserID], [UserPassd], [UserName], [NickName], [RealName], [PinYin], [QQ], [YY], [WW], [Phone], [RoleID], [State], [IsBqq], [InsertTime], [BYZD1], [BYZD2], [BYZD3], [BYZD4], [BYZD5], [UserTypeID]) VALUES (N'9329fd199d504f13ba4371b781a3062c', N'a', N'a', N'a', N'a', N'a', N'a', N'a', N'a', N'a', N'2', N'1', 1, CAST(0x0000A3EB00A80228 AS DateTime), NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[User] ([UserID], [UserPassd], [UserName], [NickName], [RealName], [PinYin], [QQ], [YY], [WW], [Phone], [RoleID], [State], [IsBqq], [InsertTime], [BYZD1], [BYZD2], [BYZD3], [BYZD4], [BYZD5], [UserTypeID]) VALUES (N'bfc34b6e5da24fcc9500441c2cbff697', N'a', N'a', N'a', N'a', N'a', N'a', N'a', N'a', N'a', N'2', N'1', 1, CAST(0x0000A3EB00A85688 AS DateTime), NULL, NULL, NULL, NULL, NULL, NULL)
/****** Object:  Table [dbo].[TempInfo]    Script Date: 12/15/2014 14:15:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TempInfo](
	[ID] [varchar](32) NULL,
	[PID] [varchar](32) NULL,
	[AccountName] [varchar](50) NULL,
	[AccountPwd] [varchar](50) NULL,
	[PwdQuertion] [varchar](50) NULL,
	[PwdAnswer] [varchar](50) NULL,
	[RegTel] [varchar](50) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[TempInfo] ([ID], [PID], [AccountName], [AccountPwd], [PwdQuertion], [PwdAnswer], [RegTel]) VALUES (N'8ecd6368338a4256ba1b3245ffb9e710', N'b45a371cec3c4082aee756b6af74498c', N'88', NULL, NULL, NULL, NULL)
/****** Object:  Table [dbo].[TeamAccount]    Script Date: 12/15/2014 14:15:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TeamAccount](
	[ID] [varchar](32) NULL,
	[TID] [varchar](32) NULL,
	[AccID] [varchar](32) NULL,
	[Type] [varchar](32) NULL,
	[Enable] [bit] NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[TeamAccount] ([ID], [TID], [AccID], [Type], [Enable]) VALUES (N'53efc28e42d2404da8fe3becd6d8cbe0', N'12c58f3d603545d7992c6e8a8619173c', N'd92d20ea065146a78b08d1fb2b291eb7', N'PurchaseAccount', 1)
/****** Object:  Table [dbo].[Team]    Script Date: 12/15/2014 14:15:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Team](
	[ID] [varchar](32) NOT NULL,
	[TBH] [int] IDENTITY(1,1) NOT NULL,
	[CID] [varchar](32) NULL,
	[BgTime] [varchar](100) NULL,
	[Camp] [varchar](50) NULL,
	[Area] [varchar](50) NULL,
	[Server] [varchar](50) NULL,
	[Pattern] [varchar](50) NULL,
	[Command] [varchar](50) NULL,
	[State] [int] NULL,
	[Progress] [varchar](50) NULL,
	[BZ] [varchar](100) NULL,
	[BYZD1] [varchar](50) NULL,
	[BYZD2] [varchar](50) NULL,
	[BYZD3] [varchar](50) NULL,
	[BYZD4] [varchar](50) NULL,
	[BYZD5] [varchar](50) NULL,
	[Difficulty] [varchar](50) NULL,
 CONSTRAINT [PK_PVETeam] PRIMARY KEY CLUSTERED 
(
	[ID] ASC,
	[TBH] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'进度' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Team', @level2type=N'COLUMN',@level2name=N'Progress'
GO
SET IDENTITY_INSERT [dbo].[Team] ON
INSERT [dbo].[Team] ([ID], [TBH], [CID], [BgTime], [Camp], [Area], [Server], [Pattern], [Command], [State], [Progress], [BZ], [BYZD1], [BYZD2], [BYZD3], [BYZD4], [BYZD5], [Difficulty]) VALUES (N'12c58f3d603545d7992c6e8a8619173c', 1, N'f451bf00035d4ead96b74cfe7ea00560', N'11-25', N'1-4-272', N'2', N'', N'125', N'a', 0, N'1/2', N'bb', NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Team] ([ID], [TBH], [CID], [BgTime], [Camp], [Area], [Server], [Pattern], [Command], [State], [Progress], [BZ], [BYZD1], [BYZD2], [BYZD3], [BYZD4], [BYZD5], [Difficulty]) VALUES (N'8f6db23b9a8d48f0addd1956b3558af2', 2, N'f451bf00035d4ead96b74cfe7ea00560', N'', N'', N'', N'', N'', N'', 0, N'0/14', NULL, NULL, NULL, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Team] OFF
/****** Object:  Table [dbo].[Talent]    Script Date: 12/15/2014 14:15:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Talent](
	[ID] [varchar](32) NOT NULL,
	[Name] [varchar](32) NULL,
	[Job] [varchar](32) NULL,
	[Position] [varchar](32) NULL,
 CONSTRAINT [PK_Talent] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[Talent] ([ID], [Name], [Job], [Position]) VALUES (N'4b9b2c09db334649a460409ce8c4ede4', N'tt', NULL, NULL)
/****** Object:  Table [dbo].[Skill]    Script Date: 12/15/2014 14:15:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Skill](
	[ID] [varchar](32) NULL,
	[Name] [varchar](32) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[Skill] ([ID], [Name]) VALUES (N'75b36f1cd60445bb8bf91ac322d24faa', N'钓鱼')
/****** Object:  Table [dbo].[Role]    Script Date: 12/15/2014 14:15:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Role](
	[RoleID] [varchar](50) NOT NULL,
	[RoleName] [varchar](50) NULL,
	[Description] [varchar](50) NULL,
	[OrdeFiled] [varchar](50) NULL,
	[Enabled] [bit] NULL,
	[CreateTime] [datetime] NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[RoleID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[Role] ([RoleID], [RoleName], [Description], [OrdeFiled], [Enabled], [CreateTime]) VALUES (N'543b4511e77144e39e3051ab2a3c975f', N'管理员', N'测试管理员', NULL, 1, CAST(0x0000A3EA010D04C0 AS DateTime))
INSERT [dbo].[Role] ([RoleID], [RoleName], [Description], [OrdeFiled], [Enabled], [CreateTime]) VALUES (N'a1a31285e0134fcebe4f448ede5cc15f', N'超级管理员', N'管理员权限', NULL, 1, CAST(0x0000A3FF00B0016C AS DateTime))
/****** Object:  Table [dbo].[Reputation]    Script Date: 12/15/2014 14:15:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Reputation](
	[ID] [varchar](32) NOT NULL,
	[Name] [varchar](32) NULL,
 CONSTRAINT [PK_Reputation] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[Reputation] ([ID], [Name]) VALUES (N'af3294a8c44e4f4bbf093d2ccabd73e9', N'aa')
/****** Object:  Table [dbo].[PurchaseAccount]    Script Date: 12/15/2014 14:15:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PurchaseAccount](
	[ID] [varchar](32) NOT NULL,
	[AccountName] [varchar](50) NULL,
	[AccountPwd] [varchar](50) NULL,
	[Warcraft] [varchar](50) NULL,
	[RoleName] [varchar](50) NULL,
	[GameArea] [varchar](50) NULL,
	[GameServer] [varchar](50) NULL,
	[Job] [varchar](50) NULL,
	[Camp] [varchar](50) NULL,
	[Race] [varchar](50) NULL,
	[Sex] [varchar](50) NULL,
	[Level] [varchar](50) NULL,
	[PwdQuertion] [varchar](50) NULL,
	[PwdAnswer] [varchar](50) NULL,
	[Name] [varchar](50) NULL,
	[LastName] [varchar](50) NULL,
	[FirstName] [varchar](50) NULL,
	[Card] [varchar](50) NULL,
	[RegTel] [varchar](50) NULL,
	[EmailPwd] [varchar](50) NULL,
	[EmailPwdQuestion] [varchar](50) NULL,
	[EmailPwdAnswer] [varchar](50) NULL,
	[EmailPwdQuestion2] [varchar](50) NULL,
	[EmailPwdAnswer2] [varchar](50) NULL,
	[EmailPwdQuestion3] [varchar](50) NULL,
	[EmailPwdAnswer3] [varchar](50) NULL,
	[EmailSecurity] [varchar](50) NULL,
	[CardPicture] [varchar](255) NULL,
	[CardPicture2] [varchar](255) NULL,
	[PwdPicture] [varchar](255) NULL,
	[EmailPicture] [varchar](255) NULL,
	[Price] [decimal](18, 0) NULL,
	[Trade] [varchar](50) NULL,
	[Methods] [varchar](50) NULL,
	[InsertTime] [datetime] NULL,
	[BankName] [varchar](50) NULL,
	[BankProv] [varchar](50) NULL,
	[BankCity] [varchar](50) NULL,
	[BankAccount] [varchar](50) NULL,
	[BankPerson] [varchar](50) NULL,
	[SellerTel] [varchar](50) NULL,
	[PreOrderID] [varchar](50) NULL,
	[WangWang] [varchar](50) NULL,
	[QQ] [varchar](50) NULL,
	[SalesStatus] [varchar](50) NULL,
	[SalesPrice] [decimal](18, 0) NULL,
	[ResetStatus] [varchar](50) NULL,
	[KFName] [varchar](50) NULL,
	[BalanceTime] [datetime] NULL,
	[SalesTime] [datetime] NULL,
	[BuyStatus] [varchar](50) NULL,
	[GamePicture] [varchar](1024) NULL,
	[SalesURL] [varchar](256) NULL,
	[Achieve] [varchar](50) NULL,
	[UID] [varchar](32) NULL,
	[Talent] [varchar](256) NULL,
	[Pve] [varchar](256) NULL,
 CONSTRAINT [PK_PurchaseAccount] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[PurchaseAccount] ([ID], [AccountName], [AccountPwd], [Warcraft], [RoleName], [GameArea], [GameServer], [Job], [Camp], [Race], [Sex], [Level], [PwdQuertion], [PwdAnswer], [Name], [LastName], [FirstName], [Card], [RegTel], [EmailPwd], [EmailPwdQuestion], [EmailPwdAnswer], [EmailPwdQuestion2], [EmailPwdAnswer2], [EmailPwdQuestion3], [EmailPwdAnswer3], [EmailSecurity], [CardPicture], [CardPicture2], [PwdPicture], [EmailPicture], [Price], [Trade], [Methods], [InsertTime], [BankName], [BankProv], [BankCity], [BankAccount], [BankPerson], [SellerTel], [PreOrderID], [WangWang], [QQ], [SalesStatus], [SalesPrice], [ResetStatus], [KFName], [BalanceTime], [SalesTime], [BuyStatus], [GamePicture], [SalesURL], [Achieve], [UID], [Talent], [Pve]) VALUES (N'd92d20ea065146a78b08d1fb2b291eb7', N'waracc', N'123456', N'wow1', N'xx', N'三区', N'凤凰之神', N'aa', N'联盟', NULL, N'1', NULL, N'你成长的街道叫什么路?', N'xxx', N'小 蛮腰', N'蛮腰', N'小', N'111111', N'111111', N'123456', NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'141209034525504.png', N'141209034544237.jpg', NULL, NULL, CAST(50 AS Decimal(18, 0)), NULL, NULL, CAST(0x0000A3FC0103D01C AS DateTime), N'支付宝', N'天津', N'河东区', NULL, N'tt', NULL, NULL, NULL, NULL, N'0', CAST(0 AS Decimal(18, 0)), N'0', N'ankj@live.com', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
/****** Object:  Table [dbo].[PerRole]    Script Date: 12/15/2014 14:15:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PerRole](
	[ID] [varchar](32) NOT NULL,
	[RoleID] [varchar](32) NULL,
	[PID] [varchar](32) NULL,
 CONSTRAINT [PK_PerRole] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[PerRole] ([ID], [RoleID], [PID]) VALUES (N'018436ecae4a4321b58a12bf16107da0', N'a1a31285e0134fcebe4f448ede5cc15f', N'3f691451d296406698de4b0ca6b68339')
INSERT [dbo].[PerRole] ([ID], [RoleID], [PID]) VALUES (N'0a40eb19400a4cbdbf518926aa386432', N'a1a31285e0134fcebe4f448ede5cc15f', N'1d6488c50bef4da186f1529a379dfc73')
INSERT [dbo].[PerRole] ([ID], [RoleID], [PID]) VALUES (N'1f06f0830e9f4d82a51837aba035da2d', N'a1a31285e0134fcebe4f448ede5cc15f', N'91af2291a52b4e65a2a31efac3adef5e')
INSERT [dbo].[PerRole] ([ID], [RoleID], [PID]) VALUES (N'222867092289489388085e997fc035d9', N'a1a31285e0134fcebe4f448ede5cc15f', N'3ac8fc0df5574cfa9b5eb1ead41a7c1d')
INSERT [dbo].[PerRole] ([ID], [RoleID], [PID]) VALUES (N'2756d87940e94cf0ab9f5d367ce6297e', N'543b4511e77144e39e3051ab2a3c975f', N'E10ADC3949BA59ABBE56E077F20FHF3E')
INSERT [dbo].[PerRole] ([ID], [RoleID], [PID]) VALUES (N'28dc2b5e7d3545219b032f79f26b306f', N'a1a31285e0134fcebe4f448ede5cc15f', N'62ef5620c6704bad998881b8e056ccc6')
INSERT [dbo].[PerRole] ([ID], [RoleID], [PID]) VALUES (N'3ad24fe72462408c93e7663d99b69e47', N'a1a31285e0134fcebe4f448ede5cc15f', N'4d2ebb3f6cfb4ef18ca1b7b6e88bd4fd')
INSERT [dbo].[PerRole] ([ID], [RoleID], [PID]) VALUES (N'3e6cdacb9b9549b09596de7c3698d00c', N'a1a31285e0134fcebe4f448ede5cc15f', N'69a3cb109564410fa41ce5aafb4cda32')
INSERT [dbo].[PerRole] ([ID], [RoleID], [PID]) VALUES (N'3faa70fe00cd43e09c292a02dfe2fd75', N'a1a31285e0134fcebe4f448ede5cc15f', N'5da791f4912a47b39ec81e8c8f097157')
INSERT [dbo].[PerRole] ([ID], [RoleID], [PID]) VALUES (N'3fe57331b85c478683263223b5d7cfbb', N'a1a31285e0134fcebe4f448ede5cc15f', N'cfbd5b880865424d9f079016200a15ff')
INSERT [dbo].[PerRole] ([ID], [RoleID], [PID]) VALUES (N'477d992e30b74ffc87e0233982367c8a', N'a1a31285e0134fcebe4f448ede5cc15f', N'f646a69bbfd342aaa20904eeea7c6542')
INSERT [dbo].[PerRole] ([ID], [RoleID], [PID]) VALUES (N'4e26fbcc910a460489d2c42320e9e67d', N'a1a31285e0134fcebe4f448ede5cc15f', N'E10ADC3949BA59ABBE56E077F20FHF3E')
INSERT [dbo].[PerRole] ([ID], [RoleID], [PID]) VALUES (N'5a298b9a32ce48d78a2032b89be00acd', N'a1a31285e0134fcebe4f448ede5cc15f', N'6c35ab50372c47a28b7c94030114e673')
INSERT [dbo].[PerRole] ([ID], [RoleID], [PID]) VALUES (N'6b34974fa7cc454cb92d51592f3eb3f4', N'a1a31285e0134fcebe4f448ede5cc15f', N'ec18ebd1f282463fbecc4ecaea5fd1dd')
INSERT [dbo].[PerRole] ([ID], [RoleID], [PID]) VALUES (N'6f783036d5b14f969bae16d853462cf6', N'a1a31285e0134fcebe4f448ede5cc15f', N'ef9cbaa493b6400c82536e247120c45e')
INSERT [dbo].[PerRole] ([ID], [RoleID], [PID]) VALUES (N'70e4b5ca15024129979d0fffaba5f4b3', N'a1a31285e0134fcebe4f448ede5cc15f', N'b03cc7f8e7474c659fde3b7f575bd497')
INSERT [dbo].[PerRole] ([ID], [RoleID], [PID]) VALUES (N'75f4074c40ca44bfa9d41dbb79e3403d', N'a1a31285e0134fcebe4f448ede5cc15f', N'e68b0492b2414f8c831e19900698f40b')
INSERT [dbo].[PerRole] ([ID], [RoleID], [PID]) VALUES (N'79175312d465465e90a4a892db5bfb77', N'a1a31285e0134fcebe4f448ede5cc15f', N'740a99eaac8a472c80ea36920c1c415b')
INSERT [dbo].[PerRole] ([ID], [RoleID], [PID]) VALUES (N'7d7339d3cecf4ead928d62ef464f590e', N'a1a31285e0134fcebe4f448ede5cc15f', N'794163d425294c2eace5b59d4ff120b9')
INSERT [dbo].[PerRole] ([ID], [RoleID], [PID]) VALUES (N'8ae90e41defb4b8f8e0baeeb66638743', N'a1a31285e0134fcebe4f448ede5cc15f', N'815337b8290440408eaa8999aef4305b')
INSERT [dbo].[PerRole] ([ID], [RoleID], [PID]) VALUES (N'948caf1e2cf74196aa02e7a5b676bca2', N'a1a31285e0134fcebe4f448ede5cc15f', N'5cc0089621924db199ad215996d2fdbb')
INSERT [dbo].[PerRole] ([ID], [RoleID], [PID]) VALUES (N'9a125336f8a643209c02d6887fa9e3ed', N'a1a31285e0134fcebe4f448ede5cc15f', N'36e20af2ca314d95b006df4c47861e56')
INSERT [dbo].[PerRole] ([ID], [RoleID], [PID]) VALUES (N'a90ca980531d462dbe906896f8d56b18', N'a1a31285e0134fcebe4f448ede5cc15f', N'9682e588fa31418293813854fda60102')
INSERT [dbo].[PerRole] ([ID], [RoleID], [PID]) VALUES (N'abfa2e82332d4dfbae4dcb9373582737', N'a1a31285e0134fcebe4f448ede5cc15f', N'dcc7011ce4994ff5a634e1d272035e2f')
INSERT [dbo].[PerRole] ([ID], [RoleID], [PID]) VALUES (N'b16e8ecb419b41eab8dae21b4928a31a', N'a1a31285e0134fcebe4f448ede5cc15f', N'490def354d6145778251682564208a10')
INSERT [dbo].[PerRole] ([ID], [RoleID], [PID]) VALUES (N'b409e2a60f37493eaf44d2946334b49f', N'a1a31285e0134fcebe4f448ede5cc15f', N'8d386b43e5354d5ea600af223f90a0b3')
INSERT [dbo].[PerRole] ([ID], [RoleID], [PID]) VALUES (N'c53f36270c2847499ca3d7a2170579f8', N'a1a31285e0134fcebe4f448ede5cc15f', N'E10ADC3949BA59ABBE56E057F20FHF3E')
INSERT [dbo].[PerRole] ([ID], [RoleID], [PID]) VALUES (N'cc3674f0825b48a48e92777e7c03c045', N'a1a31285e0134fcebe4f448ede5cc15f', N'aa76b784326c4d858ddf4830ae676564')
INSERT [dbo].[PerRole] ([ID], [RoleID], [PID]) VALUES (N'cd542f6bf4e3456dbb8660da393638ef', N'a1a31285e0134fcebe4f448ede5cc15f', N'b87671763a7e42abb73675859abc9b4c')
INSERT [dbo].[PerRole] ([ID], [RoleID], [PID]) VALUES (N'd370fc4a7bb34f468f68bff92092d10c', N'a1a31285e0134fcebe4f448ede5cc15f', N'f691d045794442ce8132e49b1995ba7b')
INSERT [dbo].[PerRole] ([ID], [RoleID], [PID]) VALUES (N'd5d450db7c16424ca6ce1b906364036b', N'a1a31285e0134fcebe4f448ede5cc15f', N'5e6f6288e2804f3c93d63311dbb9628d')
INSERT [dbo].[PerRole] ([ID], [RoleID], [PID]) VALUES (N'ddb4b9f01777456686d78c2fd1839914', N'543b4511e77144e39e3051ab2a3c975f', N'3ac8fc0df5574cfa9b5eb1ead41a7c1d')
INSERT [dbo].[PerRole] ([ID], [RoleID], [PID]) VALUES (N'e03d0f154443421282e2e9614e8cc4a2', N'a1a31285e0134fcebe4f448ede5cc15f', N'6dffbc787f694c7085fee564c947c985')
INSERT [dbo].[PerRole] ([ID], [RoleID], [PID]) VALUES (N'e3b048c4d7024315a0c8093efbc35851', N'a1a31285e0134fcebe4f448ede5cc15f', N'd519de3ec9ed4446b4f8cc42dfadc2f2')
INSERT [dbo].[PerRole] ([ID], [RoleID], [PID]) VALUES (N'f1d221eba4484cb6a7267cf2bf59bc81', N'a1a31285e0134fcebe4f448ede5cc15f', N'5edd9da8b43b4fd4b4382e14b9e862e5')
INSERT [dbo].[PerRole] ([ID], [RoleID], [PID]) VALUES (N'f769ac7429484394907fcc0f331d1dc7', N'a1a31285e0134fcebe4f448ede5cc15f', N'cae415640bde43578842c887bbf6f7a0')
INSERT [dbo].[PerRole] ([ID], [RoleID], [PID]) VALUES (N'fb847a09c6ab440494e53784daad881e', N'a1a31285e0134fcebe4f448ede5cc15f', N'b5975169eaec48f5a80d03b6bd8af17e')
INSERT [dbo].[PerRole] ([ID], [RoleID], [PID]) VALUES (N'fc1b87c6664b477fa8a223f6578bf15a', N'a1a31285e0134fcebe4f448ede5cc15f', N'2029150c701845d8bf91216d5e7927f9')
/****** Object:  Table [dbo].[Permissions]    Script Date: 12/15/2014 14:15:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Permissions](
	[PID] [varchar](32) NOT NULL,
	[ParentID] [varchar](50) NULL,
	[PName] [varchar](50) NULL,
	[PUrl] [varchar](100) NULL,
	[Description] [varchar](50) NULL,
	[CreateTime] [datetime] NULL,
	[OpenType] [int] NULL,
	[Sort] [int] NULL,
 CONSTRAINT [PK_Permissions] PRIMARY KEY CLUSTERED 
(
	[PID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[Permissions] ([PID], [ParentID], [PName], [PUrl], [Description], [CreateTime], [OpenType], [Sort]) VALUES (N'1d6488c50bef4da186f1529a379dfc73', N'cae415640bde43578842c887bbf6f7a0', N'用户行为', N'/', NULL, CAST(0x0000A3EB00B25F48 AS DateTime), 0, 13)
INSERT [dbo].[Permissions] ([PID], [ParentID], [PName], [PUrl], [Description], [CreateTime], [OpenType], [Sort]) VALUES (N'2029150c701845d8bf91216d5e7927f9', N'b87671763a7e42abb73675859abc9b4c', N'订单管理', N'/order/OrdersSettled', NULL, CAST(0x0000A3EB00E3D7BC AS DateTime), 0, 1)
INSERT [dbo].[Permissions] ([PID], [ParentID], [PName], [PUrl], [Description], [CreateTime], [OpenType], [Sort]) VALUES (N'36e20af2ca314d95b006df4c47861e56', N'cae415640bde43578842c887bbf6f7a0', N'账号管理', N'/GameAcc/index', NULL, CAST(0x0000A3EB00B24904 AS DateTime), 0, 11)
INSERT [dbo].[Permissions] ([PID], [ParentID], [PName], [PUrl], [Description], [CreateTime], [OpenType], [Sort]) VALUES (N'3ac8fc0df5574cfa9b5eb1ead41a7c1d', N'E10ADC3949BA59ABBE56E057F20FHF3E', N'角色管理', N'/Role/RoleList', NULL, CAST(0x0000A3E9011575B0 AS DateTime), 0, 102)
INSERT [dbo].[Permissions] ([PID], [ParentID], [PName], [PUrl], [Description], [CreateTime], [OpenType], [Sort]) VALUES (N'3f691451d296406698de4b0ca6b68339', N'cae415640bde43578842c887bbf6f7a0', N'查看密码记录', N'/User/ViewPwd', NULL, CAST(0x0000A3EB00B269D4 AS DateTime), 0, 14)
INSERT [dbo].[Permissions] ([PID], [ParentID], [PName], [PUrl], [Description], [CreateTime], [OpenType], [Sort]) VALUES (N'490def354d6145778251682564208a10', N'6c35ab50372c47a28b7c94030114e673', N'代练员管理', N'/User/Index?UserTypeID=88f7b261ab9c470f9a8d4504a338f800', NULL, CAST(0x0000A3EB00B2C410 AS DateTime), 0, 17)
INSERT [dbo].[Permissions] ([PID], [ParentID], [PName], [PUrl], [Description], [CreateTime], [OpenType], [Sort]) VALUES (N'4d2ebb3f6cfb4ef18ca1b7b6e88bd4fd', N'b87671763a7e42abb73675859abc9b4c', N'订单统计', N'/', NULL, CAST(0x0000A3EB00B1F4A4 AS DateTime), 0, 9)
INSERT [dbo].[Permissions] ([PID], [ParentID], [PName], [PUrl], [Description], [CreateTime], [OpenType], [Sort]) VALUES (N'5cc0089621924db199ad215996d2fdbb', N'b87671763a7e42abb73675859abc9b4c', N'已结算订单', N'/', NULL, CAST(0x0000A3EB00B1E0B8 AS DateTime), 0, 8)
INSERT [dbo].[Permissions] ([PID], [ParentID], [PName], [PUrl], [Description], [CreateTime], [OpenType], [Sort]) VALUES (N'5da791f4912a47b39ec81e8c8f097157', N'b87671763a7e42abb73675859abc9b4c', N'添加团队副本任务', N'/Team/TeamAdd', NULL, CAST(0x0000A3EB00EE3158 AS DateTime), 0, 5)
INSERT [dbo].[Permissions] ([PID], [ParentID], [PName], [PUrl], [Description], [CreateTime], [OpenType], [Sort]) VALUES (N'5e6f6288e2804f3c93d63311dbb9628d', N'b03cc7f8e7474c659fde3b7f575bd497', N'Boss管理', N'/Boss/Index', NULL, CAST(0x0000A3FB00B6943C AS DateTime), 0, 0)
INSERT [dbo].[Permissions] ([PID], [ParentID], [PName], [PUrl], [Description], [CreateTime], [OpenType], [Sort]) VALUES (N'5edd9da8b43b4fd4b4382e14b9e862e5', N'6c35ab50372c47a28b7c94030114e673', N'员工通讯录', N'/User/Directory', NULL, CAST(0x0000A3EB00B350B0 AS DateTime), 0, 20)
INSERT [dbo].[Permissions] ([PID], [ParentID], [PName], [PUrl], [Description], [CreateTime], [OpenType], [Sort]) VALUES (N'62ef5620c6704bad998881b8e056ccc6', N'b87671763a7e42abb73675859abc9b4c', N'团队副本任务管理', N'/Team/TeamMana', NULL, CAST(0x0000A3EB00EE1B14 AS DateTime), 0, 4)
INSERT [dbo].[Permissions] ([PID], [ParentID], [PName], [PUrl], [Description], [CreateTime], [OpenType], [Sort]) VALUES (N'69a3cb109564410fa41ce5aafb4cda32', N'6c35ab50372c47a28b7c94030114e673', N'合作商管理', N'/User/Index?UserTypeID=3a403a51a8df4b91928d45cbe2bc8820', NULL, CAST(0x0000A3EB00B2FD7C AS DateTime), 0, 18)
INSERT [dbo].[Permissions] ([PID], [ParentID], [PName], [PUrl], [Description], [CreateTime], [OpenType], [Sort]) VALUES (N'6c35ab50372c47a28b7c94030114e673', N'', N'用户管理', N'/', NULL, CAST(0x0000A3EB00B27C94 AS DateTime), 0, 15)
INSERT [dbo].[Permissions] ([PID], [ParentID], [PName], [PUrl], [Description], [CreateTime], [OpenType], [Sort]) VALUES (N'6dffbc787f694c7085fee564c947c985', N'b03cc7f8e7474c659fde3b7f575bd497', N'服务器管理', N'/Server/Index', NULL, CAST(0x0000A3EB00B96E50 AS DateTime), 0, 25)
INSERT [dbo].[Permissions] ([PID], [ParentID], [PName], [PUrl], [Description], [CreateTime], [OpenType], [Sort]) VALUES (N'740a99eaac8a472c80ea36920c1c415b', N'6c35ab50372c47a28b7c94030114e673', N'修改密码', N'/User/MdfPwd', NULL, CAST(0x0000A3EB00B35B3C AS DateTime), 0, 21)
INSERT [dbo].[Permissions] ([PID], [ParentID], [PName], [PUrl], [Description], [CreateTime], [OpenType], [Sort]) VALUES (N'794163d425294c2eace5b59d4ff120b9', N'b03cc7f8e7474c659fde3b7f575bd497', N'职业管理', N'/Profession/Index', NULL, CAST(0x0000A3EB00B3B578 AS DateTime), 0, 23)
INSERT [dbo].[Permissions] ([PID], [ParentID], [PName], [PUrl], [Description], [CreateTime], [OpenType], [Sort]) VALUES (N'815337b8290440408eaa8999aef4305b', N'b03cc7f8e7474c659fde3b7f575bd497', N'成就管理', N'/Achieve/Index', NULL, CAST(0x0000A3FB00B66B38 AS DateTime), 0, 0)
INSERT [dbo].[Permissions] ([PID], [ParentID], [PName], [PUrl], [Description], [CreateTime], [OpenType], [Sort]) VALUES (N'8d386b43e5354d5ea600af223f90a0b3', N'6c35ab50372c47a28b7c94030114e673', N'用户类型管理', N'/UserType/Index', NULL, CAST(0x0000A3EB00E7B724 AS DateTime), 0, 21)
INSERT [dbo].[Permissions] ([PID], [ParentID], [PName], [PUrl], [Description], [CreateTime], [OpenType], [Sort]) VALUES (N'91af2291a52b4e65a2a31efac3adef5e', N'b87671763a7e42abb73675859abc9b4c', N'填写订单', N'/order/OrderAdd', NULL, CAST(0x0000A3EB00E9C1CC AS DateTime), 0, 3)
INSERT [dbo].[Permissions] ([PID], [ParentID], [PName], [PUrl], [Description], [CreateTime], [OpenType], [Sort]) VALUES (N'9682e588fa31418293813854fda60102', N'b87671763a7e42abb73675859abc9b4c', N'客人账号管理', N'/CustomerAcc/Index', NULL, CAST(0x0000A3F800F1BD8C AS DateTime), 0, 5)
INSERT [dbo].[Permissions] ([PID], [ParentID], [PName], [PUrl], [Description], [CreateTime], [OpenType], [Sort]) VALUES (N'aa76b784326c4d858ddf4830ae676564', N'b03cc7f8e7474c659fde3b7f575bd497', N'游戏区管理', N'/Area/Index', NULL, CAST(0x0000A3EB00B3C388 AS DateTime), 0, 24)
INSERT [dbo].[Permissions] ([PID], [ParentID], [PName], [PUrl], [Description], [CreateTime], [OpenType], [Sort]) VALUES (N'b03cc7f8e7474c659fde3b7f575bd497', N'', N'游戏信息管理', N'/', NULL, CAST(0x0000A3EB00B37E64 AS DateTime), 0, 22)
INSERT [dbo].[Permissions] ([PID], [ParentID], [PName], [PUrl], [Description], [CreateTime], [OpenType], [Sort]) VALUES (N'b5975169eaec48f5a80d03b6bd8af17e', N'b03cc7f8e7474c659fde3b7f575bd497', N'天赋管理', N'/Talent/Index', NULL, CAST(0x0000A3FF00AFEC54 AS DateTime), 0, 0)
INSERT [dbo].[Permissions] ([PID], [ParentID], [PName], [PUrl], [Description], [CreateTime], [OpenType], [Sort]) VALUES (N'b87671763a7e42abb73675859abc9b4c', N'', N'代练业务', N'/', NULL, CAST(0x0000A3EB00AC6980 AS DateTime), 0, 0)
INSERT [dbo].[Permissions] ([PID], [ParentID], [PName], [PUrl], [Description], [CreateTime], [OpenType], [Sort]) VALUES (N'cae415640bde43578842c887bbf6f7a0', N'', N'账号交易', N'/', NULL, CAST(0x0000A3EB00B23644 AS DateTime), 0, 10)
INSERT [dbo].[Permissions] ([PID], [ParentID], [PName], [PUrl], [Description], [CreateTime], [OpenType], [Sort]) VALUES (N'cfbd5b880865424d9f079016200a15ff', N'b87671763a7e42abb73675859abc9b4c', N'内部账号管理', N'/', NULL, CAST(0x0000A3EB00B1C498 AS DateTime), 0, 6)
INSERT [dbo].[Permissions] ([PID], [ParentID], [PName], [PUrl], [Description], [CreateTime], [OpenType], [Sort]) VALUES (N'd519de3ec9ed4446b4f8cc42dfadc2f2', N'b87671763a7e42abb73675859abc9b4c', N'借用账号管理', N'/', NULL, CAST(0x0000A3EB00B1D17C AS DateTime), 0, 7)
INSERT [dbo].[Permissions] ([PID], [ParentID], [PName], [PUrl], [Description], [CreateTime], [OpenType], [Sort]) VALUES (N'dcc7011ce4994ff5a634e1d272035e2f', N'b03cc7f8e7474c659fde3b7f575bd497', N'物品管理', N'/Equipment/Index', NULL, CAST(0x0000A3FB00B5CAAC AS DateTime), 0, 0)
INSERT [dbo].[Permissions] ([PID], [ParentID], [PName], [PUrl], [Description], [CreateTime], [OpenType], [Sort]) VALUES (N'E10ADC3949BA59ABBE56E057F20FHF3E', N'', N'权限管理', N'', NULL, NULL, NULL, 99)
INSERT [dbo].[Permissions] ([PID], [ParentID], [PName], [PUrl], [Description], [CreateTime], [OpenType], [Sort]) VALUES (N'E10ADC3949BA59ABBE56E077F20FHF3E', N'E10ADC3949BA59ABBE56E057F20FHF3E', N'栏目管理', N'/Role/PermissionsList', NULL, NULL, NULL, 100)
INSERT [dbo].[Permissions] ([PID], [ParentID], [PName], [PUrl], [Description], [CreateTime], [OpenType], [Sort]) VALUES (N'e68b0492b2414f8c831e19900698f40b', N'b03cc7f8e7474c659fde3b7f575bd497', N'副本管理', N'/Copy/Index', NULL, CAST(0x0000A3FB00B6AF30 AS DateTime), 0, 0)
INSERT [dbo].[Permissions] ([PID], [ParentID], [PName], [PUrl], [Description], [CreateTime], [OpenType], [Sort]) VALUES (N'ec18ebd1f282463fbecc4ecaea5fd1dd', N'cae415640bde43578842c887bbf6f7a0', N'添加新账号', N'/GameAcc/Create', NULL, CAST(0x0000A3EB00B25390 AS DateTime), 0, 12)
INSERT [dbo].[Permissions] ([PID], [ParentID], [PName], [PUrl], [Description], [CreateTime], [OpenType], [Sort]) VALUES (N'ef9cbaa493b6400c82536e247120c45e', N'6c35ab50372c47a28b7c94030114e673', N'客服管理', N'/User/Index?UserTypeID=05ab1ba8df824a0e9dedec80d0d5fbcb', NULL, CAST(0x0000A3EB00B9A30C AS DateTime), 0, 16)
INSERT [dbo].[Permissions] ([PID], [ParentID], [PName], [PUrl], [Description], [CreateTime], [OpenType], [Sort]) VALUES (N'f646a69bbfd342aaa20904eeea7c6542', N'E10ADC3949BA59ABBE56E057F20FHF3E', N'用户管理', N'/Role/Index', NULL, CAST(0x0000A3E90115CC68 AS DateTime), 0, 101)
INSERT [dbo].[Permissions] ([PID], [ParentID], [PName], [PUrl], [Description], [CreateTime], [OpenType], [Sort]) VALUES (N'f691d045794442ce8132e49b1995ba7b', N'6c35ab50372c47a28b7c94030114e673', N'工作室管理', N'/User/Index?UserTypeID=08477ab683f94d229b626432a7a7be18', NULL, CAST(0x0000A3EB00B343CC AS DateTime), 0, 19)
/****** Object:  Table [dbo].[PADetail]    Script Date: 12/15/2014 14:15:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PADetail](
	[ID] [varchar](50) NOT NULL,
	[Warcraft] [varchar](50) NULL,
	[Title] [varchar](42) NULL,
	[Title5173] [varchar](40) NULL,
	[TBTitle] [varchar](15) NULL,
	[Talent] [varchar](1024) NULL,
	[PVE] [varchar](256) NULL,
	[Equiplist] [varchar](256) NULL,
	[Arms] [varchar](1024) NULL,
	[OtherEquip] [varchar](256) NULL,
	[Reputation] [varchar](1024) NULL,
	[Expertise1] [varchar](256) NULL,
	[Expertise1Level] [varchar](256) NULL,
	[Expertise2] [varchar](256) NULL,
	[Expertise2Level] [varchar](256) NULL,
	[Fish] [varchar](256) NULL,
	[Cook] [varchar](256) NULL,
	[Archaeology] [varchar](256) NULL,
	[Horsemanship] [varchar](256) NULL,
	[HorsemanshipDetail] [varchar](1024) NULL,
	[Aid] [varchar](200) NULL,
	[Honor] [varchar](200) NULL,
	[Sports] [varchar](200) NULL,
	[Pet] [varchar](200) NULL,
	[Other] [varchar](200) NULL,
 CONSTRAINT [PK_PADetail] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[PADetail] ([ID], [Warcraft], [Title], [Title5173], [TBTitle], [Talent], [PVE], [Equiplist], [Arms], [OtherEquip], [Reputation], [Expertise1], [Expertise1Level], [Expertise2], [Expertise2Level], [Fish], [Cook], [Archaeology], [Horsemanship], [HorsemanshipDetail], [Aid], [Honor], [Sports], [Pet], [Other]) VALUES (N'111111111111111', N'aa', N'aaaa', N'11', N'22', N'tt', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[PADetail] ([ID], [Warcraft], [Title], [Title5173], [TBTitle], [Talent], [PVE], [Equiplist], [Arms], [OtherEquip], [Reputation], [Expertise1], [Expertise1Level], [Expertise2], [Expertise2Level], [Fish], [Cook], [Archaeology], [Horsemanship], [HorsemanshipDetail], [Aid], [Honor], [Sports], [Pet], [Other]) VALUES (N'1e8b661e9f324642a090f16bb1645529', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[PADetail] ([ID], [Warcraft], [Title], [Title5173], [TBTitle], [Talent], [PVE], [Equiplist], [Arms], [OtherEquip], [Reputation], [Expertise1], [Expertise1Level], [Expertise2], [Expertise2Level], [Fish], [Cook], [Archaeology], [Horsemanship], [HorsemanshipDetail], [Aid], [Honor], [Sports], [Pet], [Other]) VALUES (N'9666ccf8d2e644a48aedb2c8a3193bae', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[PADetail] ([ID], [Warcraft], [Title], [Title5173], [TBTitle], [Talent], [PVE], [Equiplist], [Arms], [OtherEquip], [Reputation], [Expertise1], [Expertise1Level], [Expertise2], [Expertise2Level], [Fish], [Cook], [Archaeology], [Horsemanship], [HorsemanshipDetail], [Aid], [Honor], [Sports], [Pet], [Other]) VALUES (N'9e122fb98a364e819e0eea2ef1fcd99d', N'wow1', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
/****** Object:  Table [dbo].[Order]    Script Date: 12/15/2014 14:15:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Order](
	[ID] [varchar](32) NOT NULL,
	[Type] [int] NULL,
	[AType] [int] NULL,
	[UserName] [varchar](50) NULL,
	[PassWord] [varchar](50) NULL,
	[WarcraftAccount] [varchar](50) NULL,
	[GameZone] [varchar](50) NULL,
	[GameService] [varchar](50) NULL,
	[GameName] [varchar](50) NULL,
	[Camp] [varchar](50) NULL,
	[Job] [varchar](50) NULL,
	[RoleName] [varchar](50) NULL,
	[Talent] [varchar](50) NULL,
	[PwdPicture] [varchar](50) NULL,
	[Pve] [varchar](100) NULL,
	[yAmount] [decimal](18, 2) NULL,
	[Amount] [decimal](18, 2) NULL,
	[yGold] [decimal](18, 2) NULL,
	[Gold] [decimal](18, 2) NULL,
	[LeveContent] [text] NULL,
	[FkBZ] [varchar](500) NULL,
	[Phone] [varchar](50) NULL,
	[QQ] [varchar](50) NULL,
	[WW] [varchar](50) NULL,
	[FullName] [varchar](50) NULL,
	[State] [int] NULL,
	[Astate] [int] NULL,
	[WuPin] [varchar](50) NULL,
	[Achievement] [varchar](50) NULL,
	[Team] [varchar](50) NULL,
	[Staff] [varchar](50) NULL,
	[CrateTime] [datetime] NULL,
	[BYZD1] [varchar](1000) NULL,
	[BYZD2] [varchar](50) NULL,
	[BYZD3] [varchar](50) NULL,
	[BYZD4] [varchar](50) NULL,
	[Desc] [varchar](50) NULL,
	[UID] [varchar](32) NULL,
 CONSTRAINT [PK_InternalAccount] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'订单类型' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Order', @level2type=N'COLUMN',@level2name=N'Type'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'账号类型' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Order', @level2type=N'COLUMN',@level2name=N'AType'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'子账号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Order', @level2type=N'COLUMN',@level2name=N'WarcraftAccount'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'天赋' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Order', @level2type=N'COLUMN',@level2name=N'Talent'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'订单状态' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Order', @level2type=N'COLUMN',@level2name=N'State'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'账号状态' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Order', @level2type=N'COLUMN',@level2name=N'Astate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'成就需求' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Order', @level2type=N'COLUMN',@level2name=N'Achievement'
GO
INSERT [dbo].[Order] ([ID], [Type], [AType], [UserName], [PassWord], [WarcraftAccount], [GameZone], [GameService], [GameName], [Camp], [Job], [RoleName], [Talent], [PwdPicture], [Pve], [yAmount], [Amount], [yGold], [Gold], [LeveContent], [FkBZ], [Phone], [QQ], [WW], [FullName], [State], [Astate], [WuPin], [Achievement], [Team], [Staff], [CrateTime], [BYZD1], [BYZD2], [BYZD3], [BYZD4], [Desc], [UID]) VALUES (N'DL1412010001', 0, 0, N'123123', N'123123123', N'111', N'', N'', NULL, N'', N'aa', N'吖吖', N'23123', N'', NULL, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), N'31231231', NULL, N'77', N'123123', N'123123', N'123123', 0, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
/****** Object:  Table [dbo].[Needs]    Script Date: 12/15/2014 14:15:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Needs](
	[ID] [varchar](32) NOT NULL,
	[OrderID] [varchar](32) NULL,
	[EID] [varchar](32) NULL,
	[Num] [varchar](50) NULL,
	[LeveContent] [varchar](500) NULL,
	[State] [int] NULL,
	[Explain] [varchar](500) NULL,
	[Type] [int] NULL,
	[GotTime] [datetime] NULL,
	[Days] [int] NULL,
 CONSTRAINT [PK_Needs] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[Needs] ([ID], [OrderID], [EID], [Num], [LeveContent], [State], [Explain], [Type], [GotTime], [Days]) VALUES (N'54e54f222b92494686287dcf0732a955', N'DL1412010001', NULL, NULL, N'声望:aa|等级：1-1|内部|限天', 0, NULL, 3, NULL, NULL)
INSERT [dbo].[Needs] ([ID], [OrderID], [EID], [Num], [LeveContent], [State], [Explain], [Type], [GotTime], [Days]) VALUES (N'a709b21d11744158862f612600027ef0', N'DL1412010001', NULL, NULL, N'加尔鲁什地狱咆哮成就', 0, NULL, 2, NULL, NULL)
INSERT [dbo].[Needs] ([ID], [OrderID], [EID], [Num], [LeveContent], [State], [Explain], [Type], [GotTime], [Days]) VALUES (N'b25d785cf9944db59459a4ed4963e069', N'DL1412010001', NULL, NULL, N'声望:aa|等级：1-1||限10天', 0, NULL, 3, NULL, NULL)
INSERT [dbo].[Needs] ([ID], [OrderID], [EID], [Num], [LeveContent], [State], [Explain], [Type], [GotTime], [Days]) VALUES (N'cedf381df13a4697b5471711b5200f21', N'DL1412010001', NULL, NULL, N'宝宝:闪电貂|内部|限10天', 0, NULL, 5, NULL, NULL)
INSERT [dbo].[Needs] ([ID], [OrderID], [EID], [Num], [LeveContent], [State], [Explain], [Type], [GotTime], [Days]) VALUES (N'd5ed12cbcefb44ae88e9a48794782f09', N'DL1412010001', NULL, NULL, N'加尔鲁什地狱咆哮成就', 0, NULL, 2, NULL, NULL)
INSERT [dbo].[Needs] ([ID], [OrderID], [EID], [Num], [LeveContent], [State], [Explain], [Type], [GotTime], [Days]) VALUES (N'eb4e15cf66d240f6b21e4fa1468edc5f', N'DL1412010001', NULL, NULL, N'声望:aa|等级：6-596|外包|限天', 0, NULL, 3, NULL, NULL)
INSERT [dbo].[Needs] ([ID], [OrderID], [EID], [Num], [LeveContent], [State], [Explain], [Type], [GotTime], [Days]) VALUES (N'f4a4269874a74e788a1449e945e3cd4a', N'DL1412010001', NULL, NULL, N'常规:打怪升级泡妞|外包|限30天', 0, NULL, 6, NULL, NULL)
/****** Object:  Table [dbo].[Lend]    Script Date: 12/15/2014 14:15:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Lend](
	[ID] [varchar](32) NULL,
	[AccountName] [varchar](32) NULL,
	[AccountPwd] [varchar](32) NULL,
	[Warcraft] [varchar](32) NULL,
	[GameArea] [varchar](32) NULL,
	[GameServer] [varchar](32) NULL,
	[RoleName] [varchar](32) NULL,
	[Job] [varchar](32) NULL,
	[Camp] [varchar](32) NULL,
	[LendType] [varchar](32) NULL,
	[UID] [varchar](32) NULL,
	[Talent] [varchar](256) NULL,
	[Pve] [varchar](256) NULL,
	[Desc] [varchar](256) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[Lend] ([ID], [AccountName], [AccountPwd], [Warcraft], [GameArea], [GameServer], [RoleName], [Job], [Camp], [LendType], [UID], [Talent], [Pve], [Desc]) VALUES (NULL, N'aaa', N'aa', N'aa', N'啊啊吖', NULL, N'aa', N'aa', N'联盟', NULL, NULL, NULL, NULL, NULL)
/****** Object:  Table [dbo].[HistoryInfo]    Script Date: 12/15/2014 14:15:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[HistoryInfo](
	[ID] [varchar](32) NULL,
	[PID] [varchar](32) NULL,
	[KFName] [varchar](32) NULL,
	[AccountName] [varchar](32) NULL,
	[AccountPwd] [varchar](32) NULL,
	[InsertTime] [datetime] NULL,
	[PwdQuertion] [varchar](256) NULL,
	[PwdAnswer] [varchar](256) NULL,
	[Name] [varchar](32) NULL,
	[Card] [varchar](32) NULL,
	[EmailPwd] [varchar](32) NULL,
	[EmailPwdQuestion] [varchar](256) NULL,
	[EmailPwdAnswer] [varchar](256) NULL,
	[EmailPwdQuestion2] [varchar](256) NULL,
	[EmailPwdAnswer2] [varchar](256) NULL,
	[EmailPwdQuestion3] [varchar](256) NULL,
	[EmailPwdAnswer3] [varchar](256) NULL,
	[RegTel] [varchar](32) NULL,
	[EmailSecurity] [varchar](32) NULL,
	[CardPicture] [varchar](256) NULL,
	[CardPicture2] [varchar](256) NULL,
	[PwdPicture] [varchar](256) NULL,
	[EmailPicture] [varchar](256) NULL,
	[IP] [varchar](256) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[HistoryInfo] ([ID], [PID], [KFName], [AccountName], [AccountPwd], [InsertTime], [PwdQuertion], [PwdAnswer], [Name], [Card], [EmailPwd], [EmailPwdQuestion], [EmailPwdAnswer], [EmailPwdQuestion2], [EmailPwdAnswer2], [EmailPwdQuestion3], [EmailPwdAnswer3], [RegTel], [EmailSecurity], [CardPicture], [CardPicture2], [PwdPicture], [EmailPicture], [IP]) VALUES (N'76968dd4a12047a8b44ef1dd7b53b837', N'd92d20ea065146a78b08d1fb2b291eb7', NULL, N'waracc', N'123456', NULL, N'你成长的街道叫什么路?', N'xxx', N'小 蛮腰', N'111111', N'123456', NULL, NULL, NULL, NULL, NULL, NULL, N'111111', NULL, N'141209034525504.png 141209034544237.jpg 141209034549884.jpg ', NULL, NULL, NULL, NULL)
INSERT [dbo].[HistoryInfo] ([ID], [PID], [KFName], [AccountName], [AccountPwd], [InsertTime], [PwdQuertion], [PwdAnswer], [Name], [Card], [EmailPwd], [EmailPwdQuestion], [EmailPwdAnswer], [EmailPwdQuestion2], [EmailPwdAnswer2], [EmailPwdQuestion3], [EmailPwdAnswer3], [RegTel], [EmailSecurity], [CardPicture], [CardPicture2], [PwdPicture], [EmailPicture], [IP]) VALUES (N'e5891a17d8e245d7b0697047cdcfc381', N'8ee9b7b877684770b15a4f9114e8be23', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'141203015505511.jpg 141203015511281.jpg ', NULL, NULL, NULL, NULL)
/****** Object:  Table [dbo].[GameServer]    Script Date: 12/15/2014 14:15:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[GameServer](
	[ID] [varchar](32) NOT NULL,
	[PID] [varchar](32) NULL,
	[Name] [varchar](50) NULL,
 CONSTRAINT [PK_GameServer] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[GameServer] ([ID], [PID], [Name]) VALUES (N'6f686a2c928d4c83945bf23de977db73', NULL, N'凤凰之神')
/****** Object:  Table [dbo].[GameRace]    Script Date: 12/15/2014 14:15:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[GameRace](
	[ID] [varchar](50) NOT NULL,
	[Name] [varchar](50) NULL,
 CONSTRAINT [PK_GameRace] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[GameProfession]    Script Date: 12/15/2014 14:15:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[GameProfession](
	[ID] [varchar](32) NULL,
	[Name] [varchar](50) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[GameProfession] ([ID], [Name]) VALUES (N'c4dc431ecb09491bbded781e4c8acfd9', N'法师')
INSERT [dbo].[GameProfession] ([ID], [Name]) VALUES (N'af3e25fccaec4903a01d38570cb43fcd', N'战士')
/****** Object:  Table [dbo].[GameArea]    Script Date: 12/15/2014 14:15:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[GameArea](
	[ID] [varchar](32) NULL,
	[Name] [varchar](50) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[GameArea] ([ID], [Name]) VALUES (N'3723d9ec540b479cad366e5ad24d7660', N'三区')
/****** Object:  Table [dbo].[Equipment]    Script Date: 12/15/2014 14:15:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Equipment](
	[ID] [varchar](32) NOT NULL,
	[BID] [varchar](32) NULL,
	[Name] [varchar](50) NULL,
	[GoodsLevel] [varchar](50) NULL,
	[Position] [varchar](50) NULL,
	[Img] [varchar](256) NULL,
	[Detail] [varchar](256) NULL,
	[BYZD3] [varchar](50) NULL,
	[BYZD4] [varchar](50) NULL,
	[TID] [varchar](32) NULL,
 CONSTRAINT [PK_Equipment] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[Equipment] ([ID], [BID], [Name], [GoodsLevel], [Position], [Img], [Detail], [BYZD3], [BYZD4], [TID]) VALUES (N'20c0edecc1b543aea2dbb11c55123bea', N'9fdc2603adaf495aac9c680f644a51dc', N'gg', N'111', N'手部', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Equipment] ([ID], [BID], [Name], [GoodsLevel], [Position], [Img], [Detail], [BYZD3], [BYZD4], [TID]) VALUES (N'cc64b953fd4444c2ba67f3eccff5ae60', N'9fdc2603adaf495aac9c680f644a51dc', N'aa', N'555', N'头部', NULL, NULL, NULL, NULL, NULL)
/****** Object:  Table [dbo].[CopyZone]    Script Date: 12/15/2014 14:15:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CopyZone](
	[ID] [varchar](32) NULL,
	[Name] [varchar](50) NULL,
	[CID] [varchar](32) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[CopyZone] ([ID], [Name], [CID]) VALUES (N'41ce857ec71d4240b2c29cdb5f514892', N'1区', NULL)
/****** Object:  Table [dbo].[Copy]    Script Date: 12/15/2014 14:15:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Copy](
	[ID] [varchar](32) NULL,
	[Name] [varchar](50) NULL,
	[Pattern] [varchar](50) NULL,
	[Difficulty] [varchar](50) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[Copy] ([ID], [Name], [Pattern], [Difficulty]) VALUES (N'f451bf00035d4ead96b74cfe7ea00560', N'决战xxoo', N'25', N'SS')
/****** Object:  Table [dbo].[Boss]    Script Date: 12/15/2014 14:15:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Boss](
	[ID] [varchar](32) NULL,
	[CID] [varchar](32) NULL,
	[CopyZID] [varchar](32) NULL,
	[Name] [varchar](50) NULL,
	[Src] [varchar](50) NULL,
	[Sort] [int] NULL,
	[BYZD1] [varchar](50) NULL,
	[BYZD2] [varchar](50) NULL,
	[BYZD3] [varchar](50) NULL,
	[BYZD4] [varchar](50) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[Boss] ([ID], [CID], [CopyZID], [Name], [Src], [Sort], [BYZD1], [BYZD2], [BYZD3], [BYZD4]) VALUES (N'9fdc2603adaf495aac9c680f644a51dc', N'f451bf00035d4ead96b74cfe7ea00560', N'41ce857ec71d4240b2c29cdb5f514892', N'傲之煞', NULL, 2, NULL, NULL, NULL, NULL)
INSERT [dbo].[Boss] ([ID], [CID], [CopyZID], [Name], [Src], [Sort], [BYZD1], [BYZD2], [BYZD3], [BYZD4]) VALUES (N'f86009d80a7a4b95997655568edcc51a', N'f451bf00035d4ead96b74cfe7ea00560', N'41ce857ec71d4240b2c29cdb5f514892', N'nn', NULL, 1, NULL, NULL, NULL, NULL)
/****** Object:  Table [dbo].[BaoBao]    Script Date: 12/15/2014 14:15:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[BaoBao](
	[ID] [varchar](32) NULL,
	[Name] [varchar](32) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[BaoBao] ([ID], [Name]) VALUES (N'3da200e41f1c4d43847358abc343d096', N'闪电貂')
/****** Object:  Table [dbo].[Achieve]    Script Date: 12/15/2014 14:15:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Achieve](
	[ID] [varchar](32) NULL,
	[Name] [varchar](50) NULL,
	[CopyID] [varchar](32) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[Achieve] ([ID], [Name], [CopyID]) VALUES (N'48e1dbbbfc67436682ff5e888fef2cc7', N'加尔鲁什地狱咆哮成就', N'f451bf00035d4ead96b74cfe7ea00560')
INSERT [dbo].[Achieve] ([ID], [Name], [CopyID]) VALUES (N'c216071adb294f89994e5ea9a9a2e8af', N'11111', N'f451bf00035d4ead96b74cfe7ea00560')
