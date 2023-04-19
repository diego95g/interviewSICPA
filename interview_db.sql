/*==============================================================*/
/* DBMS name:      Microsoft SQL Server 2008                    */
/* Created on:     18/4/2023 0:09:24                            */
/*==============================================================*/


if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('DEPARTMENT') and o.name = 'FK_DEPARTME_ENTERPRIS_ENTERPRI')
alter table DEPARTMENT
   drop constraint FK_DEPARTME_ENTERPRIS_ENTERPRI
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('DEPARTMENT_EMPLOYEE') and o.name = 'FK_DEPARTME_DEPARTMEN_EMPLOYEE')
alter table DEPARTMENT_EMPLOYEE
   drop constraint FK_DEPARTME_DEPARTMEN_EMPLOYEE
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('DEPARTMENT_EMPLOYEE') and o.name = 'FK_DEPARTME_DEPARTMEN_DEPARTME')
alter table DEPARTMENT_EMPLOYEE
   drop constraint FK_DEPARTME_DEPARTMEN_DEPARTME
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('DEPARTMENT')
            and   name  = 'ENTERPRISE_DEPARTMENT_FK'
            and   indid > 0
            and   indid < 255)
   drop index DEPARTMENT.ENTERPRISE_DEPARTMENT_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('DEPARTMENT')
            and   type = 'U')
   drop table DEPARTMENT
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('DEPARTMENT_EMPLOYEE')
            and   name  = 'DEPARTMENT_EMPLOYEE_FK'
            and   indid > 0
            and   indid < 255)
   drop index DEPARTMENT_EMPLOYEE.DEPARTMENT_EMPLOYEE_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('DEPARTMENT_EMPLOYEE')
            and   name  = 'DEPARTMENT_EMPLOYEE2_FK'
            and   indid > 0
            and   indid < 255)
   drop index DEPARTMENT_EMPLOYEE.DEPARTMENT_EMPLOYEE2_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('DEPARTMENT_EMPLOYEE')
            and   type = 'U')
   drop table DEPARTMENT_EMPLOYEE
go

if exists (select 1
            from  sysobjects
           where  id = object_id('EMPLOYEE')
            and   type = 'U')
   drop table EMPLOYEE
go

if exists (select 1
            from  sysobjects
           where  id = object_id('ENTERPRISE')
            and   type = 'U')
   drop table ENTERPRISE
go

/*==============================================================*/
/* Table: DEPARTMENT                                            */
/*==============================================================*/
create table DEPARTMENT (
   ID_DEPARTMENT        int                  identity,
   ID_ENTERPRISE        int                  not null,
   CREATED_BY_DEPARTMENT varchar(50)          null,
   CREATED_DATE_DEPARTMENT datetime             null,
   MODIFIED_BY_DEPARTMENT varchar(50)          null,
   MODIFIED_DATE_DEPARTMENT datetime             null,
   STATUS_DEPARTMENT    bit                  null,
   DESCRIPTION_DEPARTMENT varchar(50)          null,
   NAME_DEPARTMENT      varchar(50)          null,
   PHONE_DEPARTMENT     varchar(50)          null,
   constraint PK_DEPARTMENT primary key nonclustered (ID_DEPARTMENT)
)
go

/*==============================================================*/
/* Index: ENTERPRISE_DEPARTMENT_FK                              */
/*==============================================================*/
create index ENTERPRISE_DEPARTMENT_FK on DEPARTMENT (
ID_ENTERPRISE ASC
)
go

/*==============================================================*/
/* Table: DEPARTMENT_EMPLOYEE                                   */
/*==============================================================*/
create table DEPARTMENT_EMPLOYEE (
   ID_EMPLOYEE          int                  not null,
   ID_DEPARTMENT        int                  not null,
   ID_DEPARTMENT_EMPLOYEE int                  identity,
   CREATED_BY_DEPARTMENT_EMPLOYEE varchar(50)          null,
   CREATED_DATE_DEPARTMENT_EMPLOYEE datetime             null,
   MODIFIED_BY_DEPARTMENT_EMPLOYEE varchar(50)          null,
   MODIFIED_DATE_DEPARTMENT_EMPLOYEE datetime             null,
   STATUS               bit                  null,
   constraint PK_DEPARTMENT_EMPLOYEE primary key nonclustered (ID_EMPLOYEE, ID_DEPARTMENT, ID_DEPARTMENT_EMPLOYEE)
)
go

/*==============================================================*/
/* Index: DEPARTMENT_EMPLOYEE2_FK                               */
/*==============================================================*/
create index DEPARTMENT_EMPLOYEE2_FK on DEPARTMENT_EMPLOYEE (
ID_DEPARTMENT ASC
)
go

/*==============================================================*/
/* Index: DEPARTMENT_EMPLOYEE_FK                                */
/*==============================================================*/
create index DEPARTMENT_EMPLOYEE_FK on DEPARTMENT_EMPLOYEE (
ID_EMPLOYEE ASC
)
go

/*==============================================================*/
/* Table: EMPLOYEE                                              */
/*==============================================================*/
create table EMPLOYEE (
   ID_EMPLOYEE          int                  identity,
   CREATED_BY_EMPLOYEE  varchar(50)          null,
   CREATED_DATE_EMPLOEE datetime             null,
   MODIFIED_BY_EMPLOEE  varchar(50)          null,
   MODIFIED_DATE_EMPLOYEE datetime             null,
   STATUS_EMPLOYEE      bit                  null,
   AGE_EMPLOYEE         int                  null,
   EMAIL_EMPLOYEE       varchar(50)          null,
   NAME_EMPLOYEE        varchar(50)          null,
   POSITION_EMPLOYEE    varchar(50)          null,
   SURNAME_EMPLOYEE     varchar(50)          null,
   constraint PK_EMPLOYEE primary key nonclustered (ID_EMPLOYEE)
)
go

/*==============================================================*/
/* Table: ENTERPRISE                                            */
/*==============================================================*/
create table ENTERPRISE (
   ID_ENTERPRISE        int                  identity,
   CREATED_BY_ENTERPRISE varchar(50)          null,
   CREATED_DATE_ENTERPRISE datetime             null,
   MODIFIED_BY_ENTERPRISE varchar(50)          null,
   MODIFIED_DATE_ENTERPRISE datetime             null,
   STATUS_ENTERPRISE    bit                  null,
   ADDRESS_ENTERPRISE   varchar(50)          null,
   NAME_ENTERPRISE      varchar(50)          null,
   PHONE_ENTERPRISE     varchar(50)          null,
   constraint PK_ENTERPRISE primary key nonclustered (ID_ENTERPRISE)
)
go

alter table DEPARTMENT
   add constraint FK_DEPARTME_ENTERPRIS_ENTERPRI foreign key (ID_ENTERPRISE)
      references ENTERPRISE (ID_ENTERPRISE)
go

alter table DEPARTMENT_EMPLOYEE
   add constraint FK_DEPARTME_DEPARTMEN_EMPLOYEE foreign key (ID_EMPLOYEE)
      references EMPLOYEE (ID_EMPLOYEE)
go

alter table DEPARTMENT_EMPLOYEE
   add constraint FK_DEPARTME_DEPARTMEN_DEPARTME foreign key (ID_DEPARTMENT)
      references DEPARTMENT (ID_DEPARTMENT)
go

