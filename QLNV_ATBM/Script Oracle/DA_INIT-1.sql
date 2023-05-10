BEGIN
EXECUTE IMMEDIATE 'DROP TABLE'||' DA_TABLE_NHANVIEN CASCADE CONSTRAINTS';
EXCEPTION
WHEN OTHERS THEN
      IF SQLCODE != -942 THEN
         RAISE;
      END IF;
END;
/
CREATE TABLE DA_TABLE_NHANVIEN(
    MANV VARCHAR2(5),
    TENNV VARCHAR2(50),
    PHAI VARCHAR2(3),
    NGAYSINH DATE,
    DIACHI VARCHAR2(50),
    SODT VARCHAR2 (5),
    LUONG VARCHAR2(1000),
    PHUCAP VARCHAR2(1000),
    VAITRO VARCHAR2(20),
    MANQL VARCHAR2(5),
    PHG VARCHAR2(10),
    CONSTRAINT DA_NHANVIEN_PK primary key (MANV)
);
---------------------------------------------------------------------------------------------------------------------------------------
BEGIN
EXECUTE IMMEDIATE 'DROP TABLE'||' DA_TABLE_PHONGBAN CASCADE CONSTRAINTS';
EXCEPTION
WHEN OTHERS THEN
      IF SQLCODE != -942 THEN
         RAISE;
      END IF;
END;
/
CREATE TABLE DA_TABLE_PHONGBAN(
    MAPB VARCHAR2(10),
    TENPB VARCHAR2(50),
    TRPHG VARCHAR2(5),
    CHINHANH VARCHAR2(20),
    LOAIPHONG VARCHAR2(20),
    CONSTRAINT DA_PHONGBAN_PK primary key (MAPB)
);
---------------------------------------------------------------------------------------------------------------------------------------
BEGIN 
EXECUTE IMMEDIATE 'DROP TABLE'||' DA_TABLE_DEAN CASCADE CONSTRAINTS';
EXCEPTION
WHEN OTHERS THEN
      IF SQLCODE != -942 THEN
         RAISE;
      END IF;
END;
/
CREATE TABLE DA_TABLE_DEAN(
    MADA VARCHAR2(5),
    TENDA VARCHAR2(50),
    NGAYBD DATE,
    PHONG VARCHAR2(10),
    CONSTRAINT DA_DEAN_PK primary key (MADA)
);
---------------------------------------------------------------------------------------------------------------------------------------
BEGIN 
EXECUTE IMMEDIATE 'DROP TABLE'||' DA_TABLE_PHANCONG CASCADE CONSTRAINTS';
EXCEPTION
WHEN OTHERS THEN
      IF SQLCODE != -942 THEN
         RAISE;
      END IF;
END;
/
CREATE TABLE DA_TABLE_PHANCONG(
    MANV VARCHAR2(5),
    MADA VARCHAR2(5),
    THOIGIAN NUMBER (2),
    CONSTRAINT DA_PHANCONG_PK primary key (MANV, MADA)
);

---------------------------------------------------------------------------------------------------------------------------------------
---------------------------------------------------------------------------------------------------------------------------------------
------------  NHAN VIEN  ------------
ALTER TABLE DA_TABLE_NHANVIEN
ADD CONSTRAINT FK_NHANVIEN_QUANLY
   FOREIGN KEY (MANQL)
   REFERENCES DA_TABLE_NHANVIEN (MANV) ON DELETE CASCADE;

ALTER TABLE DA_TABLE_NHANVIEN
ADD CONSTRAINT FK_NHANVIEN_PHONGBAN
   FOREIGN KEY (PHG)
   REFERENCES DA_TABLE_PHONGBAN (MAPB) ON DELETE CASCADE;
------------  PHONG BAN  ------------
ALTER TABLE DA_TABLE_PHONGBAN
ADD CONSTRAINT FK_PHONGBAN_NHANVIEN
   FOREIGN KEY (TRPHG)
   REFERENCES DA_TABLE_NHANVIEN (MANV) ON DELETE CASCADE;
----------------  DE AN  ----------------
ALTER TABLE DA_TABLE_DEAN
ADD CONSTRAINT FK_DEAN_PHONGBAN
   FOREIGN KEY (PHONG)
   REFERENCES DA_TABLE_PHONGBAN (MAPB) ON DELETE CASCADE;
------------  PHAN CONG  ------------   
ALTER TABLE DA_TABLE_PHANCONG
ADD CONSTRAINT FK_PHANCONG_NHANVIEN
   FOREIGN KEY (MANV)
   REFERENCES DA_TABLE_NHANVIEN (MANV) ON DELETE CASCADE;   
   
ALTER TABLE DA_TABLE_PHANCONG
ADD CONSTRAINT FK_PHANCONG_DEAN
   FOREIGN KEY (MADA)
   REFERENCES DA_TABLE_DEAN (MADA) ON DELETE CASCADE;      
   
BEGIN 
EXECUTE IMMEDIATE 'DROP TABLE'||' DA_TABLE_TEMP CASCADE CONSTRAINTS';
EXCEPTION
WHEN OTHERS THEN
      IF SQLCODE != -942 THEN
         RAISE;
      END IF;
END;
/
CREATE TABLE DA_TABLE_TEMP(QUERYY VARCHAR2(100));

BEGIN 
EXECUTE IMMEDIATE 'DROP TABLE'||' DA_TABLE_COUNT CASCADE CONSTRAINTS';
EXCEPTION
WHEN OTHERS THEN
      IF SQLCODE != -942 THEN
         RAISE;
      END IF;
END;
/
CREATE TABLE DA_TABLE_COUNT(
    OBJECT_NAME VARCHAR2(100),
    SOLUONG NUMBER
);

BEGIN 
EXECUTE IMMEDIATE 'DROP TABLE'||' DA_TABLE_DIARY CASCADE CONSTRAINTS';
EXCEPTION
WHEN OTHERS THEN
      IF SQLCODE != -942 THEN
         RAISE;
      END IF;
END;
/
CREATE TABLE DA_TABLE_DIARY AS SELECT DBUSERNAME, EVENT_TIMESTAMP, ACTION_NAME, SQL_TEXT, FGA_POLICY_NAME, CLIENT_PROGRAM_NAME FROM UNIFIED_AUDIT_TRAIL WHERE FGA_POLICY_NAME LIKE 'DA_%';

BEGIN 
EXECUTE IMMEDIATE 'DROP TABLE'||' DA_TABLE_KEY CASCADE CONSTRAINTS';
EXCEPTION
WHEN OTHERS THEN
      IF SQLCODE != -942 THEN
         RAISE;
      END IF;
END;
/
CREATE TABLE DA_TABLE_KEY(
    KEY_K VARCHAR2(100),
     RAW_KEY RAW(32)
);
/
--DROP TRIGGER DA_UP_KEY;
/*
CREATE OR REPLACE TRIGGER DA_UP_KEY
BEFORE UPDATE ON DA_TABLE_KEY FOR EACH ROW
DECLARE
    KEYOL VARCHAR2(100);
    RAW_KEY2 RAW(32);
    RAW_KEY1 RAW(32);
    V1 RAW(3000);
    V2 RAW(3000);
BEGIN
    SELECT KEY_K INTO KEYOL FROM DA_TABLE_KEY;
    SELECT RAW_KEY INTO RAW_KEY1 FROM DA_TABLE_KEY;
    IF :NEW.KEY_K != KEYOL AND :NEW.KEY_K != NULL
    THEN
        RAW_KEY2 := UTL_RAW.CAST_TO_RAW(:NEW.KEY_K);
        FOR rec IN (SELECT  NV.MANV, NV.LUONG, NV.PHUCAP FROM DA_TABLE_NHANVIEN NV) LOOP
                V1 :=  DBMS_CRYPTO.DECRYPT( SRC => rec.LUONG,
                                                                                TYP => DBMS_CRYPTO.DES_CBC_PKCS5,
                                                                                KEY => RAW_KEY1);
                V2 := DBMS_CRYPTO.ENCRYPT( SRC => V1,
                                                                                TYP => DBMS_CRYPTO.DES_CBC_PKCS5,
                                                                                KEY => RAW_KEY2);
                UPDATE DA_TABLE_NHANVIEN SET LUONG = V2 WHERE MANV = rec.MANV;
                  V1 :=  DBMS_CRYPTO.DECRYPT( SRC => rec.PHUCAP,
                                                                                TYP => DBMS_CRYPTO.DES_CBC_PKCS5,
                                                                                KEY => RAW_KEY1);
                V2 := DBMS_CRYPTO.ENCRYPT( SRC => V1,
                                                                                TYP => DBMS_CRYPTO.DES_CBC_PKCS5,
                                                                                KEY => RAW_KEY2);
                UPDATE DA_TABLE_NHANVIEN SET PHUCAP = V2 WHERE MANV = rec.MANV;
        END LOOP;
    END IF;
END;
*/

DECLARE
    RAW_KEY2 RAW(32);
BEGIN
        INSERT INTO DA_TABLE_KEY (KEY_K) VALUES('NHOM3_MAIYEUHETHONGTHONGTIN');
        RAW_KEY2 := UTL_RAW.CAST_TO_RAW('NHOM3_MAIYEUHETHONGTHONGTIN');
        UPDATE DA_TABLE_KEY SET RAW_KEY = RAW_KEY2 WHERE KEY_K = 'NHOM3_MAIYEUHETHONGTHONGTIN';
END;
/


CREATE OR REPLACE TRIGGER DA_ENCRYPT_NV
BEFORE INSERT OR UPDATE ON DA_TABLE_NHANVIEN
FOR EACH ROW
DECLARE
    V1 RAW(3000);
BEGIN
    
    IF INSERTING OR UPDATING('LUONG')
    THEN
        IF :NEW.LUONG IS NOT NULL 
        THEN
            SELECT RAW_KEY  INTO V1 FROM DA_TABLE_KEY;
            :NEW.LUONG := UTL_RAW.CAST_TO_RAW(:NEW.LUONG);
            :NEW.LUONG := DBMS_CRYPTO.ENCRYPT( SRC => :NEW.LUONG,
                                                                                TYP => DBMS_CRYPTO.DES_CBC_PKCS5,
                                                                                KEY => V1);
        ELSE
            :NEW.LUONG := NULL;
        END IF;
    END IF;
     IF INSERTING OR UPDATING('PHUCAP')
    THEN
        IF :NEW.PHUCAP IS NOT NULL 
        THEN
            SELECT RAW_KEY  INTO V1 FROM DA_TABLE_KEY;
            :NEW.PHUCAP := UTL_RAW.CAST_TO_RAW(:NEW.PHUCAP);
            :NEW.PHUCAP := DBMS_CRYPTO.ENCRYPT( SRC => :NEW.PHUCAP,
                                                                                TYP => DBMS_CRYPTO.DES_CBC_PKCS5,
                                                                                KEY => V1);
        ELSE
            :NEW.PHUCAP := NULL;
        END IF;
    END IF;
END;
