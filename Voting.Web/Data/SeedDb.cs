﻿namespace Voting.Web.Data
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Voting.Web.Data.Entities;

    //using Common.Models;


    public class SeedDb
    {
        private readonly DataContext context;

        private Random random;

        public SeedDb(DataContext context)
        {
            this.context = context;
            this.random = new Random();
        }

        public async Task SeedAsync()
        {
            await this.context.Database.EnsureCreatedAsync();

            if (!this.context.Events.Any())
            {
                this.AddEvents("¿Poner cámaras?");
                this.AddEvents("Monitor grupo 2019-1");
                await this.context.SaveChangesAsync();
            }
        }
        private void AddEvents(string name)
        {
            this.context.Events.Add(new Event
            {
                Name = name,
                Description = "Descripción",
                EndDate = null,
                StarDate = null
            });
        }
    }
}
