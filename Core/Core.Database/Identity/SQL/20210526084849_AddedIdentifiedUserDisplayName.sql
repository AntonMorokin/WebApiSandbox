START TRANSACTION;


DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20210526084849_AddedIdentifiedUserDisplayName') THEN
    ALTER TABLE "AspNetUsers" ADD "DisplayName" text NULL;
    END IF;
END $$;

DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20210526084849_AddedIdentifiedUserDisplayName') THEN
    INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
    VALUES ('20210526084849_AddedIdentifiedUserDisplayName', '5.0.6');
    END IF;
END $$;
COMMIT;

