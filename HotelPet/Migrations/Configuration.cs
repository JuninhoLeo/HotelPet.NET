﻿using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

namespace HotelPet.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<Entity.Contexto>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            SetSqlGenerator("MySql.Data.MySqlClient", new MySql.Data.EntityFramework.MySqlMigrationSqlGenerator());
        }

        protected override void Seed(Entity.Contexto context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
