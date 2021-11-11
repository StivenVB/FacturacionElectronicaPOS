--Script Replica tablas FE HANA

---------------------------------------
--Creaci�n de la tabla @OK1_PMT_XML_LIN
CREATE TABLE "@OK1_PMT_XML_LIN" (
	"Code" NVARCHAR(50) NOT NULL ,
	 "LineId" INTEGER  NOT NULL ,
	 "Object" NVARCHAR(20),
	 "LogInst" INTEGER ,
	 "U_OK1_OBL" NVARCHAR(1) DEFAULT 'N',
	 "U_OK1_TAG" NVARCHAR(50),
	 "U_OK1_TABLA" NVARCHAR(50),
	 "U_OK1_CAMPO" NVARCHAR(50),
	 "U_OK1_TAGP" INTEGER,
	 "U_OK1_ETI"  NVARCHAR(MAX),
	 "U_OK1_CONS" NVARCHAR(1) DEFAULT 'N',
	 "U_OK1_ATB" NVARCHAR(1) DEFAULT 'N',
	 "U_OK1_TIPO" NVARCHAR(50),
	 "U_OK1_CONSULTA" NVARCHAR(1) DEFAULT 'N',
	 "U_OK1_ALIAS_CON" NVARCHAR(50),
	 "U_OK1_CAMPO_REL" NVARCHAR(50),
	 "U_OK1_VALIDACION" NVARCHAR(50),
	 "U_OK1_ORDEN" INTEGER,
	 "U_OK1_SPLIT" NVARCHAR(1) DEFAULT 'N',
	 "U_OK1_VAL_EXISTS" NVARCHAR(50),
	 "U_OK1_BLOQUEAR_RPTABLA" NVARCHAR(1) DEFAULT 'N',
	 "U_OK1_Version" INTEGER,
	 PRIMARY KEY ("Code",  "LineId")
);
---------------------------------------

---------------------------------------
--Creaci�n de la tabla @@OK1_PMT_XML_LIN1
CREATE TABLE "@OK1_PMT_XML_LIN1" (
	"Code" NVARCHAR(50) NOT NULL ,
	 "LineId" INTEGER NOT NULL ,
	 "Object" NVARCHAR(20),
	 "LogInst" INTEGER ,
	 "U_OK1_ALIAS_CON" NVARCHAR(50),
	 "U_OK1_ATB" NVARCHAR(1) DEFAULT 'N',
	 "U_OK1_BLOQUEAR_RPTABLA" NVARCHAR(1) DEFAULT 'N',
	 "U_OK1_CAMPO" NVARCHAR(50),
	 "U_OK1_CAMPO_REL" NVARCHAR(50),
	 "U_OK1_CONSULTA" NVARCHAR(1) DEFAULT 'N',
	 "U_OK1_CONS" NVARCHAR(1) DEFAULT 'N',
	 "U_OK1_ETI" NVARCHAR(MAX),
	 "U_OK1_OBL" NVARCHAR(1) DEFAULT 'N',
	 "U_OK1_ORDEN" INTEGER ,
	 "U_OK1_SPLIT" NVARCHAR(1) DEFAULT 'N',
	 "U_OK1_TABLA" NVARCHAR(50),
	 "U_OK1_TAGE" INTEGER,
	 "U_OK1_TAGP" INTEGER,
	 "U_OK1_TAG" NVARCHAR(50),
	 "U_OK1_TIPO" NVARCHAR(50),
	 "U_OK1_VALIDACION" NVARCHAR(50),
	 "U_OK1_VAL_EXISTS" NVARCHAR(50),
	 "U_OK1_Version" INTEGER,
	 PRIMARY KEY ("Code",  "LineId")
);
---------------------------------------

---------------------------------------
--Creaci�n de la tabla @OK1_PMT_XML_HEAD
CREATE TABLE "@OK1_PMT_XML_HEAD" (
	 "Code" NVARCHAR(50) NOT NULL ,
	 "Name" NVARCHAR(100),
	 "DocEntry" INTEGER NOT NULL ,
	 "Canceled" NVARCHAR(1) DEFAULT 'N',
	 "Object" NVARCHAR(20),
	 "LogInst" INTEGER,
	 "UserSign" INTEGER,
	 "Transfered" NVARCHAR(1) DEFAULT 'N',
	 "CreateDate" DATETIME,
	 "CreateTime" SMALLINT,
	 "UpdateDate" DATETIME,
	 "UpdateTime" SMALLINT,
	 "DataSource" NVARCHAR(1),
	 "U_Nompltf" NVARCHAR(100),
	 "U_encb" NVARCHAR(MAX),
	 "U_tipo" NVARCHAR(100),
	 "U_Plataforma1" NVARCHAR(50),
	 "U_def" NVARCHAR(1) DEFAULT 'N',
	 "U_OK1_CANT_DECI" INTEGER,
	 "U_OK1_CONV_DECI" NVARCHAR(50),
	 "U_OK1_FORM_FEC" NVARCHAR(50),
	 "U_OK1_FORM_HORA" NVARCHAR(50),
	 "U_OK1_DOC_DEF" NVARCHAR(50),
	 "U_OK1_PROV" NVARCHAR(50),
	 "U_OK1_PROV_NOM" NVARCHAR(50),
	 "U_OK1_NIT" NVARCHAR(50),
	 "U_OK1_TiEmRe" NVARCHAR(50),
	 "U_OK1_SEPARADOR" NVARCHAR(3) DEFAULT 'N\A',
	 "U_OK1_OTRO_CARA" SMALLINT,
	 "U_OK1_COMENT" NVARCHAR(MAX),
	 "U_defCont" NVARCHAR(1) DEFAULT 'N',
	 "U_SUBTIPOFE" NVARCHAR(100),
	 "U_CSS_Base" NVARCHAR(1) DEFAULT 'N',
	 "U_UBL" NVARCHAR(10) DEFAULT '2.0',
	 "U_xmlInactivo" NVARCHAR(1) DEFAULT 'N',
	 "U_OK1_CAN_DEC_AU" INTEGER,
	 PRIMARY KEY ("Code")
);

CREATE UNIQUE INDEX "KOK1_PMT_XML_HEAD_IK" ON "@OK1_PMT_XML_HEAD" ( "DocEntry" ASC );
---------------------------------------

---------------------------------------
--Creaci�n de la tabla @OK1_HIST_LIN2_FE
CREATE TABLE "@OK1_HIST_LIN2_FE" (
	 "Code" NVARCHAR(50) NOT NULL ,
	 "LineId" INTEGER  NOT NULL ,
	 "Object" NVARCHAR(20),
	 "LogInst" INTEGER,
	 "U_addInFaElectronica_AprobadoDIAN_FE" NVARCHAR(1) DEFAULT 'N',
	 "U_EnvPla" NVARCHAR(1) DEFAULT 'N',
	 "U_AprobPla" NVARCHAR(1) DEFAULT 'N',
	 "U_AprobCli" NVARCHAR(1) DEFAULT 'N',
	 "U_AproCliF" NVARCHAR(1) DEFAULT 'N',
	 "U_VlrDoc" DECIMAL(21,6),
	 "U_CodeDIAN" NVARCHAR(254),
	 "U_FecSincro" DATETIME,
	 "U_IdDoc" INTEGER,
	 "U_NomSerie" NVARCHAR(10),
	 "U_NumDoc" INTEGER,
	 "U_ResSincro" NVARCHAR(1) DEFAULT 'N',
	 "U_SerieDoc" NVARCHAR(10),
	 "U_Sincronizar" NVARCHAR(1) DEFAULT 'N',
	 "U_TipoDoc" NVARCHAR(30),
	 "U_DocSubType" NVARCHAR(10),
	 "U_NomDocSubType" NVARCHAR(30),
	 "U_requestId" NVARCHAR(100),
	 "U_ldf" NVARCHAR(150),
	 "U_Url" NVARCHAR(MAX),
	 "U_Uuid" NVARCHAR(100),
	 "U_ErrorSincro" NVARCHAR(1) DEFAULT 'N',
	 "U_Prefijo" NVARCHAR(10),
	 "U_Sufijo" NVARCHAR(10),
	 "U_Pausar" NVARCHAR(1) DEFAULT 'N',
	 "U_DocDescarga" NVARCHAR(150),
	 "U_EnvSAPPI" NVARCHAR(1) DEFAULT 'N',
	 "U_FecDoc" DATETIME,
	 "U_RutaQR" NVARCHAR(MAX),
	 "U_horaCUFE" SMALLINT,
	 "U_sucursal" INTEGER,
	 "U_OK1_URLPDF" NVARCHAR(MAX),
	 PRIMARY KEY ("Code", "LineId")
);
---------------------------------------

---------------------------------------
--Creaci�n de la tabla @OK1_HIST_LIN1_FE
 CREATE TABLE "@OK1_HIST_LIN1_FE" (
	"Code" NVARCHAR(50) NOT NULL ,
	 "LineId" INTEGER NOT NULL ,
	 "Object" NVARCHAR(20),
	 "LogInst" INTEGER,
	 "U_EnvPla" NVARCHAR(1) DEFAULT 'N',
	 "U_DocSubType" NVARCHAR(10),
	 "U_ErrorSincro" NVARCHAR(1) DEFAULT 'N',
	 "U_FecSincro" DATETIME,
	 "U_IdObjeto" NVARCHAR(30),
	 "U_IdSerie" NVARCHAR(10),
	 "U_NomDocSubType" NVARCHAR(30),
	 "U_NomSerie" NVARCHAR(10),
	 "U_ResulSincro" NVARCHAR(254),
	 "U_Sincronizar" NVARCHAR(1) DEFAULT 'N',
	 "U_Prefijo" NVARCHAR(10),
	 "U_Sufijo" NVARCHAR(10),
	 PRIMARY KEY ("Code", "LineId")
);
---------------------------------------

---------------------------------------
--Creaci�n de la tabla @OK1_HIST_LIN3_FE
CREATE TABLE "@OK1_HIST_LIN3_FE" (
    "Code" NVARCHAR(50) NOT NULL ,
	 "LineId" INTEGER NOT NULL ,
	 "Object" NVARCHAR(20),
	 "LogInst" INTEGER ,
	 "U_IdDoc" INTEGER ,
	 "U_NomSerie" NVARCHAR(10),
	 "U_NumDoc" INTEGER ,
	 "U_SerieDoc" NVARCHAR(10),
	 "U_TipoDoc" NVARCHAR(30),
	 "U_DocSubType" NVARCHAR(10),
	 "U_NomDocSubType" NVARCHAR(30),
	 "U_IdIntento" INTEGER ,
	 "U_ResSincro" NVARCHAR(30) DEFAULT 'N',
	 "U_FecSincro" DATETIME,
	 "U_ErrorDes" NVARCHAR(MAX),
	 PRIMARY KEY ("Code", "LineId")
);
---------------------------------------

---------------------------------------
--Creaci�n de la tabla @OK1_HIST_LIN4_FE
CREATE TABLE "@OK1_HIST_LIN4_FE" (
     "Code" NVARCHAR(50) NOT NULL ,
	 "LineId" INTEGER NOT NULL ,
	 "Object" NVARCHAR(20),
	 "LogInst" INTEGER,
	 "U_VlrDoc" DECIMAL(21,6),
	 "U_IdDoc" INTEGER,
	 "U_NomSerie" NVARCHAR(10),
	 "U_NumDoc" INTEGER,
	 "U_SerieDoc" NVARCHAR(10),
	 "U_TipoDoc" NVARCHAR(30),
	 "U_DocSubType" NVARCHAR(10),
	 "U_NomDocSubType" NVARCHAR(30),
	 PRIMARY KEY ("Code", "LineId")
);
---------------------------------------

---------------------------------------
--Creaci�n de la tabla @OK1_CFG_FE
CREATE TABLE "@OK1_CFG_FE" (
	"Code" NVARCHAR(50) NOT NULL ,
	 "Name" NVARCHAR(100),
	 "DocEntry" INTEGER NOT NULL ,
	 "Canceled" NVARCHAR(1) DEFAULT 'N',
	 "Object" NVARCHAR(20),
	 "LogInst" INTEGER,
	 "UserSign" INTEGER,
	 "Transfered" NVARCHAR(1) DEFAULT 'N',
	 "CreateDate" DATETIME,
	 "CreateTime" SMALLINT,
	 "UpdateDate" DATETIME,
	 "UpdateTime" SMALLINT,
	 "DataSource" NVARCHAR(1),
	 "U_addInFaElectronica_NombreContacto_FE" NVARCHAR(254),
	 "U_addInFaElectronica_EmailContacto_FE" NVARCHAR(254),
	 "U_CuentaFE" NVARCHAR(254),
	 "U_IdCiaFE" NVARCHAR(254),
	 "U_PWSAcctFE" NVARCHAR(254),
	 "U_PWSCiaFE" NVARCHAR(254),
	 "U_FecUltCons"DATETIME,
	 "U_TokAcctFE" NVARCHAR(254),
	 "U_TokCiaFE" NVARCHAR(254),
	 "U_KEY_24H_FE" NVARCHAR(254),
	 "U_COD_VERF" NVARCHAR(254),
	 "U_cmp_prod" NVARCHAR(1) DEFAULT 'N',
	 "U_cmp_Activa" NVARCHAR(1) DEFAULT 'N',
	 "U_cmp_Url" NVARCHAR(MAX),
	 "U_tel_Contacto_FE" NVARCHAR(254),
	 "U_Codigo_Sucursal" NVARCHAR(254),
	 "U_Origen" NVARCHAR(254),
	 "U_Canal" NVARCHAR(254),
	 "U_Facturador" NVARCHAR(254),
	 "U_Url_Ambiente" NVARCHAR(MAX),
	 PRIMARY KEY ("Code")
);

CREATE UNIQUE INDEX "KOK1_CFG_FE_IK" ON "@OK1_CFG_FE" ( "DocEntry" ASC );
---------------------------------------