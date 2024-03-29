﻿using mis4200_team15.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace mis4200_team15.DAL
{
    public class MIS4200Context : DbContext // inherits from DbContext

    {
        internal object businessUnitsId;

        public MIS4200Context() : base("name=DefaultConnection")

        {

            // this method is a 'constructor' and is called when a new context is created

            // the base attribute says which connection string to use

        }

        // Include each object here. The value inside <> is the name of the class,

        // the value outside should generally be the plural of the class name

        // and is the name used to reference the entity in code

        public DbSet<userDetails> userDetails { get; set; }

        public System.Data.Entity.DbSet<mis4200_team15.Models.Locations> Locations { get; set; }

        public System.Data.Entity.DbSet<mis4200_team15.Models.coreValues> coreValues { get; set; }

        public System.Data.Entity.DbSet<mis4200_team15.Models.UserValues> UserValues { get; set; }

        public System.Data.Entity.DbSet<mis4200_team15.Models.businessUnits> businessUnits { get; set; }

        public System.Data.Entity.DbSet<mis4200_team15.Models.Recognitions> Recognitions { get; set; }
    }
}