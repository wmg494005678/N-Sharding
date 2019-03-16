/*==============================================================*/
/* Table: Meta_DataObject                                       */
/*  Note: 数据对象                                              */
/*==============================================================*/
IF NOT EXISTS( SELECT 1 FROM SYSOBJECTS WHERE ID = OBJECT_ID('Meta_DataObject') AND TYPE = 'U')
CREATE TABLE Meta_DataObject(
   ID                   varchar(36)          not null,   
   Name                 varchar(512)         not null,    
   Descriptions         varchar(1000)        null, 
   DataSourceName		varchar(128)         default 'default' not null, 
   LogicTableName		varchar(128)         not null, 
   IsTableSharding      varchar(5)           default 'False' not null, 
   IsDatabaseSharding   varchar(5)           default 'False' not null, 
   TableShardingStrategy varchar(36)         null,  
   DatabaseShardingStrategy varchar(36)      null,  
   IsView               varchar(5)           default 'False' not null,    
   IsLogicallyDeleted   varchar(5)           default 'False' not null,    
   Version		        int				     default 1 null,   
   Ext1                 varchar(256)         null,
   Ext2                 varchar(256)         null,
   Ext3                 varchar(256)         null, 
   Creator              varchar(128)         null,
   CreateTime           datetime  default getdate()  not null,
   LastModifier         varchar(128)         null,
   LastModifyTime       datetime  default getdate()  not null,
   constraint PK_Meta_DataObject primary key (ID)
)
GO

IF NOT EXISTS( SELECT 1 FROM SYS.INDEXES WHERE name = 'IDX_DataObjectName')
CREATE INDEX IDX_DataObjectName ON Meta_DataObject(Name);
GO

/*==============================================================*/
/* Table: Meta_DataObjectColumn                                 */
/*  Note: 数据对象列                                            */
/*==============================================================*/
IF NOT EXISTS( SELECT 1 FROM SYSOBJECTS WHERE ID = OBJECT_ID('Meta_DataObjectColumn') AND TYPE = 'U')
CREATE TABLE Meta_DataObjectColumn(
   ID                   varchar(36)          not null,   
   ColumnName           varchar(128)         not null,
   DisplayName          varchar(256)         not null,   
   DataObjectID         varchar(36)          not null,
   DataType  			varchar(32)          not null,      
   Length               int                  null, 
   Precision			int                  null, 
   DefaultValue			varchar(256)         null,
   IsNullable			varchar(5)           default 'True' not null, 
   IsPkColumn			varchar(5)           default 'False' not null, 
   IsSystem				varchar(5)           default 'False' not null,
   IsShardingColumn     varchar(5)           default 'False' not null,
   ColumnOrder          int                  null, 
   Ext1                 varchar(256)         null,
   Ext2                 varchar(256)         null,
   Ext3                 varchar(256)         null, 
   Creator              varchar(128)         null,
   CreateTime           datetime  default getdate()  not null,
   LastModifier         varchar(128)         null,
   LastModifyTime       datetime  default getdate()  not null,
   constraint PK_Meta_DataObjectColumn primary key (ID)
)
GO

IF NOT EXISTS( SELECT 1 FROM SYS.INDEXES WHERE name = 'IDX_DataObjectColumnDOID')
CREATE INDEX IDX_DataObjectColumnDOID ON Meta_DataObjectColumn(DataObjectID);
GO

/*==============================================================*/
/* Table: Meta_DomainModel                                      */
/*  Note: 领域模型                                              */
/*==============================================================*/
IF NOT EXISTS( SELECT 1 FROM SYSOBJECTS WHERE ID = OBJECT_ID('Meta_DomainModel') AND TYPE = 'U')
CREATE TABLE Meta_DomainModel(
   ID                   varchar(36)          not null,   
   Name                 varchar(512)         not null,    
   RootDomainObjectID   varchar(36)          not null, 
   IsCache              varchar(5)           default 'False' not null, 
   CacheStrategy		varchar(128)		 null,   
   IsLogicallyDeleted   varchar(5)           default 'False' not null,    
   DataLoaderConfig		varchar(128)         null,   
   Version		        int				     default 1 null,   
   Ext1                 varchar(256)         null,
   Ext2                 varchar(256)         null,
   Ext3                 varchar(256)         null, 
   Creator              varchar(128)         null,
   CreateTime           datetime  default getdate()  not null,
   LastModifier         varchar(128)         null,
   LastModifyTime       datetime  default getdate()  not null,
   constraint PK_Meta_DomainModel primary key (ID)
)
GO

IF NOT EXISTS( SELECT 1 FROM SYS.INDEXES WHERE name = 'IDX_Meta_DomainModelName')
CREATE INDEX IDX_Meta_DomainModelName ON Meta_DomainModel(Name);
GO

/*==============================================================*/
/* Table: Meta_DomainObject                                     */
/*  Note: 领域对象                                              */
/*==============================================================*/
IF NOT EXISTS( SELECT 1 FROM SYSOBJECTS WHERE ID = OBJECT_ID('Meta_DomainObject') AND TYPE = 'U')
CREATE TABLE Meta_DomainObject(
   ID                   varchar(36)          not null,   
   Name                 varchar(512)         not null,    
   DomainModelID        varchar(36)          not null, 
   IsRootObject         varchar(5)           not null, 
   ParentObjectID		varchar(36)  		 null,   
   ClazzReflectType     varchar(512)         null,    
   PropertyName  		varchar(128)         null, 
   IsLazyLoad			varchar(5)           default 'False' not null, 
   DataObjectID         varchar(36)          not null,
   Ext1                 varchar(256)         null,
   Ext2                 varchar(256)         null,
   Ext3                 varchar(256)         null, 
   Creator              varchar(128)         null,
   CreateTime           datetime  default getdate()  not null,
   LastModifier         varchar(128)         null,
   LastModifyTime       datetime  default getdate()  not null,
   constraint PK_Meta_DomainObject primary key (ID)
)
GO

IF NOT EXISTS( SELECT 1 FROM SYS.INDEXES WHERE name = 'IDX_Meta_DomainObjectModelID')
CREATE INDEX IDX_Meta_DomainObjectModelID ON Meta_DomainObject(DomainModelID);
GO

IF NOT EXISTS( SELECT 1 FROM SYS.INDEXES WHERE name = 'IDX_Meta_DomainObjectDOID')
CREATE INDEX IDX_Meta_DomainObjectDOID ON Meta_DomainObject(DataObjectID);
GO

/*==============================================================*/
/* Table: Meta_DomainObjectElement                              */
/*  Note: 领域对象元素                                          */
/*==============================================================*/
IF NOT EXISTS( SELECT 1 FROM SYSOBJECTS WHERE ID = OBJECT_ID('Meta_DomainObjectElement') AND TYPE = 'U')
CREATE TABLE Meta_DomainObjectElement(
   ID                   varchar(36)          not null,   
   Name                 varchar(256)         not null,  
   Alias                varchar(256)         not null, 
   DisplayName          varchar(256)         not null,     
   DomainObjectID       varchar(36)          not null, 
   DataType  			varchar(32)          not null,      
   Length               int                  null, 
   Precision			int                  null, 
   DefaultValue			varchar(256)         null,
   IsAllowNull			varchar(5)           default 'True' not null, 
   ElementType          varchar(32)          not null, 
   DataColumnID         varchar(36)          not null, 
   PropertyType         varchar(512)         null,    
   PropertyName  		varchar(128)         null, 
   IsForQuery			varchar(5)           default 'True' not null,    
   Ext1                 varchar(256)         null,
   Ext2                 varchar(256)         null,
   Ext3                 varchar(256)         null, 
   Creator              varchar(128)         null,
   CreateTime           datetime  default getdate()  not null,
   LastModifier         varchar(128)         null,
   LastModifyTime       datetime  default getdate()  not null,
   constraint PK_Meta_DomainObjectElement primary key (ID)
)
GO

IF NOT EXISTS( SELECT 1 FROM SYS.INDEXES WHERE name = 'IDX_Meta_DOElementDOID')
CREATE INDEX IDX_Meta_DOElementDOID ON Meta_DomainObjectElement(DomainObjectID);
GO

IF NOT EXISTS( SELECT 1 FROM SYS.INDEXES WHERE name = 'IDX_Meta_DOElementDOColumnID')
CREATE INDEX IDX_Meta_DOElementDOColumnID ON Meta_DomainObjectElement(DataColumnID);
GO


/*==============================================================*/
/* Table: Meta_Association                                      */
/*  Note: 领域对象关联表                                        */
/*==============================================================*/
IF NOT EXISTS( SELECT 1 FROM SYSOBJECTS WHERE ID = OBJECT_ID('Meta_Association') AND TYPE = 'U')
CREATE TABLE Meta_Association(
   ID                   varchar(36)          not null,   
   Name                 varchar(256)         not null,  
   DomainModelID        varchar(36)          not null,
   DomainObjectID        varchar(36)          not null,
   AssoDomainModelID    varchar(36)          not null,
   AssoDomainObjectID   varchar(36)          not null,
   AssociateType        varchar(36)          not null,     
   FilterCondition      varchar(1000)        null,   
   PropertyType         varchar(512)         null,    
   PropertyName  		varchar(128)         null, 
   IsLazyLoad			varchar(5)           default 'False' not null,    
   Ext1                 varchar(256)         null,
   Ext2                 varchar(256)         null,
   Ext3                 varchar(256)         null, 
   Creator              varchar(128)         null,
   CreateTime           datetime  default getdate()  not null,
   LastModifier         varchar(128)         null,
   LastModifyTime       datetime  default getdate()  not null,
   constraint PK_Meta_Association primary key (ID)
)
GO

IF NOT EXISTS( SELECT 1 FROM SYS.INDEXES WHERE name = 'IDX_Meta_AssociationDMID')
CREATE INDEX IDX_Meta_AssociationDMID ON Meta_Association(AssoDomainModelID);
GO

IF NOT EXISTS( SELECT 1 FROM SYS.INDEXES WHERE name = 'IDX_Meta_AssociationDOID')
CREATE INDEX IDX_Meta_AssociationDOID ON Meta_Association(AssoDomainObjectID);
GO

/*==============================================================*/
/* Table: Meta_AssociationItem                                  */
/*  Note: 领域对象关联项表                                      */
/*==============================================================*/
IF NOT EXISTS( SELECT 1 FROM SYSOBJECTS WHERE ID = OBJECT_ID('Meta_AssociationItem') AND TYPE = 'U')
CREATE TABLE Meta_AssociationItem(
   ID                   varchar(36)          not null,      
   SourceElementID      varchar(36)          not null,
   TargetElementID      varchar(36)          not null, 
   AssociationID        varchar(36)          not null, 
   Creator              varchar(128)         null,
   CreateTime           datetime  default getdate()  not null,
   LastModifier         varchar(128)         null,
   LastModifyTime       datetime  default getdate()  not null,
   constraint PK_Meta_AssociationItem primary key (ID)
)
GO

IF NOT EXISTS( SELECT 1 FROM SYS.INDEXES WHERE name = 'IDX_Meta_AssociationItem_AssoID')
CREATE INDEX IDX_Meta_AssociationItem_AssoID ON Meta_AssociationItem(AssociationID);
GO

/*==============================================================*/
/* Table: Meta_DataSource                                       */
/*  Note: 数据源表                                              */
/*==============================================================*/
IF NOT EXISTS( SELECT 1 FROM SYSOBJECTS WHERE ID = OBJECT_ID('Meta_DataSource') AND TYPE = 'U')
CREATE TABLE Meta_DataSource(
   Name                 varchar(128)         not null,      
   DbType               varchar(30)          not null,
   Description          varchar(256)         null, 
   IsSharding			varchar(5)           default 'False' not null,   
   Creator              varchar(128)         null,
   CreateTime           datetime  default getdate()  not null,
   LastModifier         varchar(128)         null,
   LastModifyTime       datetime  default getdate()  not null,
   constraint PK_Meta_DataSource primary key (Name)
)
GO

/*==============================================================*/
/* Table: Meta_DatabaseLink                                     */
/*  Note: 数据源表                                              */
/*==============================================================*/
IF NOT EXISTS( SELECT 1 FROM SYSOBJECTS WHERE ID = OBJECT_ID('Meta_DatabaseLink') AND TYPE = 'U')
CREATE TABLE Meta_DatabaseLink(
   Name                 varchar(128)         not null,      
   DataSourceName       varchar(128)         not null,
   ConnectionString     varchar(256)         not null, 
   IsDefault			varchar(5)           default 'False' not null,   
   Creator              varchar(128)         null,
   CreateTime           datetime  default getdate()  not null,
   LastModifier         varchar(128)         null,
   LastModifyTime       datetime  default getdate()  not null,
   constraint PK_Meta_DatabaseLink primary key (Name)
)
GO

/*==============================================================*/
/* Table: Meta_DatabaseTable                                    */
/*  Note: 数据表字典                                            */
/*==============================================================*/
IF NOT EXISTS( SELECT 1 FROM SYSOBJECTS WHERE ID = OBJECT_ID('Meta_DatabaseTable') AND TYPE = 'U')
CREATE TABLE Meta_DatabaseTable(
   Name                 varchar(128)         not null,      
   DatabaseLinkName     varchar(128)         not null,   
   Creator              varchar(128)         null,
   CreateTime           datetime  default getdate()  not null,
   LastModifier         varchar(128)         null,
   LastModifyTime       datetime  default getdate()  not null,
   constraint PK_Meta_DatabaseTable primary key (Name)
)
GO

/*==============================================================*/
/* Table: Meta_ShardingStrategy                                 */
/*  Note: 分区策略表                                            */
/*==============================================================*/
IF NOT EXISTS( SELECT 1 FROM SYSOBJECTS WHERE ID = OBJECT_ID('Meta_ShardingStrategy') AND TYPE = 'U')
CREATE TABLE Meta_ShardingStrategy(
   ID                   varchar(36)          not null,      
   DisplayName          varchar(256)         not null,
   ShardingType         varchar(16)          not null, 
   ShardingFactor		int                  null,
   AlgorithmExpression  varchar(2000)        null, 
   PostFixListConfig    varchar(8000)        null, 
   Creator              varchar(128)         null,
   CreateTime           datetime  default getdate()  not null,
   LastModifier         varchar(128)         null,
   LastModifyTime       datetime  default getdate()  not null,
   constraint PK_Meta_ShardingStrategy primary key (ID)
)
GO

/*==============================================================*/
/* Table: Meta_ShardingColumn                                   */
/*  Note: 分区列表                                              */
/*==============================================================*/
IF NOT EXISTS( SELECT 1 FROM SYSOBJECTS WHERE ID = OBJECT_ID('Meta_ShardingColumn') AND TYPE = 'U')
CREATE TABLE Meta_ShardingColumn(
   ID                   varchar(36)          not null,      
   ShardingStrategyID   varchar(36)          not null,
   DataObjectID         varchar(36)          not null, 
   DataColumnID         varchar(36)          not null, 
   Creator              varchar(128)         null,
   CreateTime           datetime  default getdate()  not null,
   LastModifier         varchar(128)         null,
   LastModifyTime       datetime  default getdate()  not null,
   constraint PK_Meta_ShardingColumn primary key (ID)
)
GO

IF NOT EXISTS( SELECT 1 FROM SYS.INDEXES WHERE name = 'IDX_Meta_ShardingColumn_DOID')
CREATE INDEX IDX_Meta_ShardingColumn_DOID ON Meta_ShardingColumn(DataObjectID);
GO

IF NOT EXISTS( SELECT 1 FROM SYS.INDEXES WHERE name = 'IDX_Meta_ShardingColumn_StrategyID')
CREATE INDEX IDX_Meta_ShardingColumn_StrategyID ON Meta_ShardingColumn(ShardingStrategyID);
GO



