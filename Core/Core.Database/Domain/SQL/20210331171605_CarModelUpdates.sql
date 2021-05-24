START TRANSACTION;


DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20210331171605_CarModelUpdates') THEN
    ALTER TABLE "Cars" RENAME COLUMN "Status" TO "State";
    END IF;
END $$;

DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20210331171605_CarModelUpdates') THEN
    ALTER TABLE "Cars" ADD "ParkingAddress" text NULL;
    END IF;
END $$;

DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20210331171605_CarModelUpdates') THEN
    INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
    VALUES ('20210331171605_CarModelUpdates', '5.0.3');
    END IF;
END $$;
COMMIT;

