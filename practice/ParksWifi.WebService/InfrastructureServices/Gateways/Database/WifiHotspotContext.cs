using Microsoft.EntityFrameworkCore;
using ParksWifi.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParksWifi.InfrastructureServices.Gateways.Database
{
    public class WifiHotspotContext : DbContext
    {
        public DbSet<DomainObjects.WifiHotspot> WifiHotspots { get; set; }

        public WifiHotspotContext(DbContextOptions<WifiHotspotContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            FillTestData(modelBuilder);
        }
        private void FillTestData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WifiHotspot>().HasData(
                new
                {
                    Id = 1L,
                    HotspotNumber = "Точка доступа №337",
                    ParkName = "Государственное автономное учреждение культуры города Москвы «Парк культуры и отдыха «Сокольники»",
                    Name = "Moscow_WiFi_Free",
                    Availability = "действует",
                },
                new
                {
                    Id = 2L,
                    HotspotNumber = "Точка доступа №242",
                    ParkName = "Государственное автономное учреждение культуры города Москвы «Музейно-парковый комплекс «Северное Тушино», парк «Северное Тушино»  ",
                    Name = "Moscow_WiFi_Free",
                    Availability = "действует",
                },
                 new
                 {
                     Id = 3L,
                     HotspotNumber = "Точка доступа №930",
                     ParkName = "Государственное бюджетное учреждение культуры города Москвы «Государственный Дарвиновский музей», территория около музея",
                     Name = "Moscow_WiFi_Free",
                     Availability = "действует",
                 },
                 new
                 {
                     Id = 4L,
                     HotspotNumber = "Точка доступа №917",
                     ParkName = "Государственное автономное учреждение культуры города Москвы «Парк культуры и отдыха «Фили», Парк 50-летия Октября",
                     Name = "Moscow_WiFi_Free",
                     Availability = "действует",
                 }
            );
        }
    }
}
