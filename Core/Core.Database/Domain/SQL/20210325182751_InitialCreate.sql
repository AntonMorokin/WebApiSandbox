﻿CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
    "MigrationId" character varying(150) NOT NULL,
    "ProductVersion" character varying(32) NOT NULL,
    CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY ("MigrationId")
);

START TRANSACTION;


DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20210325182751_InitialCreate') THEN
    CREATE TABLE "Cars" (
        "CarId" integer NOT NULL GENERATED BY DEFAULT AS IDENTITY,
        "Number" text NOT NULL,
        "BrandName" text NOT NULL,
        "ModelName" text NOT NULL,
        "Color" text NULL,
        "ManufacturedDate" timestamp without time zone NOT NULL,
        "KilometersHaveBeenDriven" numeric NOT NULL,
        "Status" text NOT NULL,
        CONSTRAINT "PK_Cars" PRIMARY KEY ("CarId")
    );
    END IF;
END $$;

DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20210325182751_InitialCreate') THEN
    CREATE TABLE "Clients" (
        "ClientId" integer NOT NULL GENERATED BY DEFAULT AS IDENTITY,
        "FirstName" text NOT NULL,
        "LastName" text NOT NULL,
        "BirthDate" timestamp without time zone NOT NULL,
        "PhoneNumber" text NOT NULL,
        CONSTRAINT "PK_Clients" PRIMARY KEY ("ClientId")
    );
    END IF;
END $$;

DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20210325182751_InitialCreate') THEN
    CREATE TABLE "Drives" (
        "DriveId" integer NOT NULL GENERATED BY DEFAULT AS IDENTITY,
        "ClientId" integer NOT NULL,
        "CarId" integer NOT NULL,
        "StartingDateTime" timestamp without time zone NOT NULL,
        "StartingAddress" text NOT NULL,
        "FinishingDateTime" timestamp without time zone NULL,
        "FinishingAddress" text NOT NULL,
        "WayLength" numeric NOT NULL,
        CONSTRAINT "PK_Drives" PRIMARY KEY ("DriveId"),
        CONSTRAINT "FK_Drives_Cars_CarId" FOREIGN KEY ("CarId") REFERENCES "Cars" ("CarId") ON DELETE CASCADE,
        CONSTRAINT "FK_Drives_Clients_ClientId" FOREIGN KEY ("ClientId") REFERENCES "Clients" ("ClientId") ON DELETE CASCADE
    );
    END IF;
END $$;

DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20210325182751_InitialCreate') THEN
    CREATE UNIQUE INDEX "IX_Cars_Number" ON "Cars" ("Number");
    END IF;
END $$;

DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20210325182751_InitialCreate') THEN
    CREATE INDEX "IX_Drives_CarId" ON "Drives" ("CarId");
    END IF;
END $$;

DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20210325182751_InitialCreate') THEN
    CREATE INDEX "IX_Drives_ClientId" ON "Drives" ("ClientId");
    END IF;
END $$;

DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20210325182751_InitialCreate') THEN
    INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
    VALUES ('20210325182751_InitialCreate', '5.0.3');
    END IF;
END $$;
COMMIT;

